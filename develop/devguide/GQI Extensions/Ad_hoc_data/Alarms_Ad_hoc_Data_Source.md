---
uid: Alarms_Ad_hoc_Data_Source
---

# Fetching alarms using the Repository API

When you want to do additional custom processing on alarms, you can do so by using the Repository API. This is an API with read access on alarms and with support for all sorts of alarm filtering, alarm sorting, and limiting of the number of the retrieved alarms.

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using SLDataGateway.API.Querying;
using SLDataGateway.API.Repositories.CustomDataTableConfiguration;
using SLDataGateway.API.Repositories.Extensions;
using SLDataGateway.API.Repositories.Registry;
using SLDataGateway.API.Types.Repositories;

[GQIMetaData(Name = "Alarms Data Source")]
public class AlarmsDataSource : IGQIDataSource, IGQIOnInit, IGQIInputArguments, IGQIOnPrepareFetch, IGQIOnDestroy
{
    private static readonly GQIDateTimeArgument _fromArg = new GQIDateTimeArgument("From") { IsRequired = true };
    private static readonly GQIDateTimeArgument _untilArg = new GQIDateTimeArgument("Until") { IsRequired = false };

    private GQIDMS _dms;
    private IConnection _connection;
    private IGQILogger _logger;
    private DateTime _from;
    private DateTime _until;
    private IDatabaseRepositoryRegistry _registry;
    private IAlarmRepository _repository;
    private IEnumerable<Alarm> _alarms;

    private const int LIMIT = 1_000_000;
    private const int TIMEOUT = 120_000;
    private const int PAGE_SIZE = 10_000;

    private static GQIColumn Severity = new GQIStringColumn("Severity");
    private static GQIColumn Element = new GQIStringColumn("Element");
    private static GQIColumn Parameter = new GQIStringColumn("Parameter");
    private static GQIColumn Value = new GQIStringColumn("Value");
    private static GQIColumn Time = new GQIDateTimeColumn("Time");
    private static GQIColumn RootID = new GQIStringColumn("Root ID");
    private static GQIColumn ID = new GQIStringColumn("ID");

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        _dms = args.DMS;
        _logger = args.Logger;
        return default;
    }

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[]
        {
            _fromArg,
            _untilArg,
        };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _from = args.GetArgumentValue(_fromArg);
        args.TryGetArgumentValue(_untilArg, out _until);

        return default;
    }

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            Severity,
            Element,
            Parameter,
            Value,
            Time,
            RootID,
            ID,
        };
    }

    public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
    {
        _connection = _dms.GetConnection();
        _registry = CreateRegistry(_connection);
        _repository = CreateRepository(_registry);

        var filter = CreateFilter();

        var query = filter.Limit(LIMIT)
            .OrderByDescending(AlarmExposers.TimeOfArrival);

        _alarms = _repository.CreateReadQuery(query)
            .SetTimeout(TIMEOUT)
            .SetPageSize(PAGE_SIZE)
            .Execute();

        return default;
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = _alarms.Take(1_000).Select(CreateRow).ToArray();
        return new GQIPage(rows)
        {
            HasNextPage = rows.Length > 0,
        };
    }

    public OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)
    {
        _connection?.Dispose();
        _registry?.Dispose();
        _repository?.Dispose();
        return default;
    }

    private IDatabaseRepositoryRegistry CreateRegistry(IConnection connection)
    {
        IDatabaseRepositoryRegistry registry = null;
        try
        {
            registry = DatabaseRepositoryRegistry
                    .Builder?
                    .WithConnection(connection)?
                    .WithCustomDataTableConfiguration(CustomDataTableConfiguration.Global)?
                    .Build();
        }
        catch (Exception ex)
        {
            _logger.Error($"Error creating repository registry: {ex.Message}");
            throw new GenIfException($"Could not create repository registry. Exception '{ex.Message} - {ex.StackTrace} - {ex.InnerException}'.");
        }

        if (registry == null)
            throw new GenIfException("Could not create repository registry.");

        return registry;
    }

    private IAlarmRepository CreateRepository(IDatabaseRepositoryRegistry registry)
    {
        var repository = registry.Get<IAlarmRepository>();

        if (repository == null)
            throw new GenIfException("Could not create alarm repository.");

        return repository;
    }

    private FilterElement<Alarm> CreateFilter()
    {
        FilterElement<Alarm> filter = AlarmExposers.TimeOfArrival.GreaterThanOrEqual(_from);
        if (_until == default(DateTime))
        {
            _logger.Information($"Fetching alarm history from {_from.ToLongTimeString()} onwards.");
        }
        else
        {
            filter = filter.AND(AlarmExposers.TimeOfArrival.LessThan(_until));
            _logger.Information($"Fetching alarm history from {_from.ToString("F")} until {_until.ToString("F")}.");
        }

        return filter;
    }

    private GQIRow CreateRow(Alarm alarm)
    {
        return new GQIRow(new GQICell[]
        {
            new GQICell() { Value = alarm.Severity }, // "Severity"
            new GQICell() { Value = alarm.ElementName }, // "Element"
            new GQICell() { Value = alarm.ParameterName }, // "Parameter"
            new GQICell() { Value = alarm.Value }, // "Value"
            new GQICell() { Value = alarm.TimeOfArrival.ToUniversalTime() }, // "Time"
            new GQICell() { Value = alarm.TreeID.ToString() }, // "Root ID"
            new GQICell() { Value = alarm.AlarmID.ToString() }, // "ID"
        });
    }
}
```
