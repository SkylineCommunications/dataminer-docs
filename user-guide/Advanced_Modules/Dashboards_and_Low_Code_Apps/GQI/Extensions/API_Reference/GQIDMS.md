---
uid: GQIDMS
---

# GQIDMS

Available from DataMiner 10.3.4/10.4.0 onwards. <!-- RN 35701 -->

The `GQIDMS` class contains the following methods, which can be used to request information in the form of `DMSMessage` objects:

| Method | Function |
|--------|----------|
| `DMSMessage SendMessage(DMSMessage message)` | Sends a request that expects a single response. |
| `DMSMessage[] SendMessages(params DMSMessage[] messages)` | Sends multiple requests at once, or sends a request that expects multiple responses. |

Generally, an ad hoc data source implementation will want to add a private field where it can store the `GQIDMS` object to be used later in other callbacks when columns and rows are created.

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

> [!TIP]
> See also: [Example of retrieving data by means of DMS messages](#example-of-retrieving-data-by-means-of-dms-messages)

## Retrieving data by means of DMS messages

From DataMiner 10.3.4/10.4.0 onwards, ad hoc data sources can retrieve data by means of DMS messages. <!-- RN 35701 -->

To do so, the [*IGQIDataSource* interface](xref:IGQIDataSource) must implement the [*IGQIOnInit* interface](xref:IGQIOnInit), of which the `OnInit` method can also be used to initialize a data source:

```csharp
OnInitOutputArgs OnInit(OnInitInputArgs args)
```

When passed to the `OnInit` method, `OnInitInputArgs` will contain the following new property:

```csharp
GQIDMS DMS
```

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

### Example of retrieving data by means of DMS messages

Below you can find an example script that uses the [*GQIDMS* object](xref:GQIDMS) provided in the OnInitPutArgs to [create a data source of active client connections](#retrieving-data-by-means-of-dms-messages). The name of the data source, as defined in the *GQIMetaData* attribute, will be “Client connections”.

Two interfaces are implemented: [*IGQIDataSource*](xref:IGQIDataSource) and [*IGQIOnInit*](xref:IGQIOnInit). The `GetNextPage` method retrieves client connections using a *GetInfoMessage* request and returns a *GQIPage* containing the data.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net.Messages;

[GQIMetaData(Name = "Client connections")]
public class ClientConnectionSource : IGQIDataSource, IGQIOnInit
{
    private GQIDMS _dms;

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        _dms = args.DMS;
        return default;
    }

    public GQIColumn[] GetColumns()
    {
        // Return desired columns
        // Omitted for brevity
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var connections = GetConnections();
        var rows = connections.Select(CreateRow).ToArray();
        return new GQIPage(rows);
    }

    private IEnumerable<LoginInfoResponseMessage> GetConnections()
    {
        // Retrieve client connections from the DMS using a GetInfoMessage request
        var request = new GetInfoMessage(InfoType.ClientList);
        var responses = _dms.SendMessages(request);
        return responses.OfType<LoginInfoResponseMessage>();
    }

    private GQIRow CreateRow(LoginInfoResponseMessage connection)
    {
        // Return a GQIRow representing the client connection
        // Omitted for brevity
    }
}
```
