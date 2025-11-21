---
uid: Scaling_Ad_hoc_Data_Source
---

# Scaling an ad hoc data source

Each time a query is executed, a new instance of the data source is created. This makes scalability crucial, especially when building the underlying data source is time-consuming or resource-intensive. Keep in mind that the code you are writing could be executed concurrently by many users.

To optimize performance when real-time data is not required, implement caching where appropriate, using a static cache. When querying data through the DMS interface, ensure that data is stored on a security group basis.

Be aware that multithreading affects both the static cache object and the cache itself. Use consistent locking mechanisms during heavy operations to prevent multiple costly computations from running simultaneously.

If needed, consider adding a circuit breaker to the ad hoc data source to reset the cache when necessary.

> [!NOTE]
> The code example below is incomplete. You will need to design the cache object to fit your specific requirements.

```csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net.Messages;

[GQIMetaData(Name = "Results")]
public class Results : IGQIDataSource, IGQIOnInit
{
    private static readonly GQIStringColumn _nameColumn = new GQIStringColumn("Name");
    private static readonly GQIStringColumn _kpiColumn = new GQIStringColumn("KPI");

    private static readonly ConcurrentDictionary<string, Cache> _groupToCache = new ConcurrentDictionary<string, Cache>(StringComparer.OrdinalIgnoreCase);
    private static readonly string _cacheBreakerPath = @"C:\Skyline DataMiner\Documents\Ad hoc cache\resultsCacheBreaker.txt";

    private GQIDMS _dms;
    private IGQILogger _logger;

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        _dms = args.DMS;
        _logger = args.Logger;
        return default;
    }

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
                _nameColumn,
                _kpiColumn,
        };
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var results = GetResults();
        var rows = results.Select(v =>
        {
            var cells = new GQICell[]
            {
                new GQICell() { Value = v.Identifier },
                new GQICell() { Value = v.Name },
            };
            return new GQIRow(v.Identifier, cells);
        }).ToArray();

        return new GQIPage(rows) { HasNextPage = false };
    }

    public IEnumerable<Result> GetResults()
    {
        var cache = GetCache();
        cache.EnsureInitialized(_dms, _logger);
        cache.EnsureUpdated(_dms, _logger);

        return cache.Results;
    }

    private Cache GetCache()
    {
        CheckCacheValidation();

        var securityGroupKey = GetSecurityGroupKey(_dms, _logger);
        if (!_groupToCache.TryGetValue(securityGroupKey, out var siteCache))
        {
            lock (_groupToCache)
            {
                if (!_groupToCache.TryGetValue(securityGroupKey, out siteCache))
                {
                    siteCache = new Cache(securityGroupKey);
                    _groupToCache[securityGroupKey] = siteCache;
                }
            }
        }

        return siteCache;
    }

    private void CheckCacheValidation()
    {
        if (!File.Exists(_cacheBreakerPath))
            return;

        lock (_groupToCache)
        {
            try
            {
                _logger.Information("Going to remove cache.");

                if (!File.Exists(_cacheBreakerPath))
                    return;

                _groupToCache.Clear();

                File.Delete(_cacheBreakerPath);

                _logger.Information("Remove cache.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Could not delete cache.");
            }
        }
    }

    private string GetSecurityGroupKey(GQIDMS dms, IGQILogger logger)
    {
        if (dms == null)
            throw new ArgumentNullException(nameof(dms));
        if (logger == null)
            throw new ArgumentNullException(nameof(logger));

        var responses = dms.SendMessages(new DMSMessage[] { new GetUserFullNameMessage(), new GetInfoMessage(InfoType.SecurityInfo) });
        var userName = responses?.OfType<GetUserFullNameResponseMessage>().FirstOrDefault()?.User;
        if (string.IsNullOrEmpty(userName))
        {
            logger.Error("User not found.");
            return null;
        }

        var securityResponse = responses?.OfType<GetUserInfoResponseMessage>().FirstOrDefault();
        var userGroups = securityResponse?.Users?
            .Where(u => String.Equals(u.Name, userName, StringComparison.InvariantCultureIgnoreCase))
            .FirstOrDefault()?.Groups?.OrderBy(x => x)?.ToArray() ?? new int[0];
        if (userGroups.Length == 0)
        {
            logger.Error("User is not part of any group.");
            return null;
        }

        return string.Join(";", userGroups);
    }
}
```

```csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Skyline.DataMiner.Analytics.GenericInterface;

public class Cache
{
    private const int TIMEOUT_SECONDS = 30;
    private readonly string _securityKey;
    private readonly object _lock = new object();
    private readonly ConcurrentDictionary<string, Result> _results = new ConcurrentDictionary<string, Result>(StringComparer.OrdinalIgnoreCase);
    private bool _isInitialized;

    public Cache(string securityKey)
    {
        if (string.IsNullOrWhiteSpace(securityKey))
            throw new ArgumentException("SecurityKey can't be empty.");

        _securityKey = securityKey;
    }

    public DateTime LastUpdate { get; private set; }

    public IEnumerable<Result> Results => _results.Values;

    internal void EnsureInitialized(GQIDMS dms, IGQILogger logger)
    {
        if (_isInitialized)
            return;

        lock (_lock)
        {
            if (_isInitialized)
                return;

            Initialize(dms, logger);
        }
    }

    internal void EnsureUpdated(GQIDMS dms, IGQILogger logger)
    {
        if (!_isInitialized)
            return;

        if (LastUpdate > DateTime.UtcNow - TimeSpan.FromSeconds(TIMEOUT_SECONDS))
            return;

        lock (_lock)
        {
            if (LastUpdate > DateTime.UtcNow - TimeSpan.FromSeconds(TIMEOUT_SECONDS))
                return;

            UpdateData(dms, logger);
        }
    }

    private void UpdateData(GQIDMS dms, IGQILogger logger)
    {
        logger.Information($"{_securityKey} - Fetching update.");

        /* Fetch update */

        logger.Information($"{_securityKey} - Fetching update done.");
        LastUpdate = DateTime.UtcNow;
    }

    private void Initialize(GQIDMS dms, IGQILogger logger)
    {
        logger.Information($"{_securityKey} - Initializing.");

        /* Initialize */

        logger.Information($"{_securityKey} - Initializing done.");

        _isInitialized = true;
    }
}
```
