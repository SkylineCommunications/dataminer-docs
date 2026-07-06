---
uid: GQI_Extensions_Retrieving_Data_From_DataMiner
---

# Retrieving data from DataMiner

GQI extensions can retrieve data from the DataMiner System (DMS) using [DMSMessage objects](xref:Skyline.DataMiner.Net.Messages).

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

## Choosing an approach

Choose the approach based on the API you use, the lifetime of the code that needs the connection, and whether the connection should be reusable.

- [Injecting IConnection](#injecting-iconnection): Use this when you need direct access to an active SLNet connection, for example in short-lived extensions or services, or to use existing DataMiner libraries that require an `IConnection`.
- [Injecting IGQIDMSInterface](#injecting-igqidmsinterface): Use this when you want to request a live connection when needed. This is useful for longer-running extensions or services, because `GetConnection()` can be called again if the connection was dropped.
- [Using OnInitInputArgs.DMS](#using-oninitinputargsdms): Use this with the legacy `SLAnalyticsTypes` API or when constructor injection is not available.

> [!TIP]
> To share or cache retrieved data across different GQI sessions, [IGQIDMSInterface](xref:GQI_IGQIDMSInterface) and [IConnection](xref:Skyline.DataMiner.Net.IConnection) can also be used via user-scoped GQI services. For more information, see [Retrieving data from DataMiner in services](xref:GQI_Extensions_Services#retrieving-data-from-dataminer-in-services).

## Injecting IConnection

From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, extensions using the `Skyline.DataMiner.Core.GQI.Extensions` API and the GQI DxM can use constructor injection to receive an [IConnection](xref:Skyline.DataMiner.Net.IConnection) instance.

This is the most direct option: the constructor receives an active connection that can be used immediately. This is ideal for short-lived extensions or services.

```csharp
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Core.GQI.Extensions;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages;

[GQIMetaData(Name = "Client connections")]
public sealed class ClientConnectionSource : IGQIDataSource
{
    private readonly IConnection _connection;

    public ClientConnectionSource(IConnection connection)
    {
        _connection = connection;
    }

    public GQIColumn[] GetColumns() => ...;

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var connections = GetConnections();
        var rows = connections.Select(CreateRow).ToArray();
        return new GQIPage(rows);
    }

    private IEnumerable<LoginInfoResponseMessage> GetConnections()
    {
        var request = new GetInfoMessage(InfoType.ClientList);
        var responses = _connection.HandleMessage(request);
        return responses.OfType<LoginInfoResponseMessage>();
    }

    private GQIRow CreateRow(LoginInfoResponseMessage connection) => ...;
}
```

> [!TIP]
> Because of its complexity, instead of interacting directly with the `IConnection` interface, the best way you can use it is by integrating with existing DataMiner libraries.

## Injecting IGQIDMSInterface

From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, extensions using the `Skyline.DataMiner.Core.GQI.Extensions` API and the GQI DxM can use constructor injection to receive an [IGQIDMSInterface](xref:GQI_IGQIDMSInterface) instance.

This option is slightly more indirect: call `GetConnection()` to get a live [IConnection](xref:Skyline.DataMiner.Net.IConnection). For longer-running extensions or services, this allows you to request a fresh connection if the previous connection was dropped.

```csharp
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Core.GQI.Extensions;
using Skyline.DataMiner.Net.Messages;

[GQIMetaData(Name = "Client connections")]
public sealed class ClientConnectionSource : IGQIDataSource
{
    private readonly IGQIDMSInterface _dmsInterface;

    public ClientConnectionSource(IGQIDMSInterface dmsInterface)
    {
        _dmsInterface = dmsInterface;
    }

    public GQIColumn[] GetColumns() => ...;

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var connections = GetConnections();
        var rows = connections.Select(CreateRow).ToArray();
        return new GQIPage(rows);
    }

    private IEnumerable<LoginInfoResponseMessage> GetConnections()
    {
        var request = new GetInfoMessage(InfoType.ClientList);
        var connection = _dmsInterface.GetConnection();
        var responses = connection.HandleMessage(request);
        return responses.OfType<LoginInfoResponseMessage>();
    }

    private GQIRow CreateRow(LoginInfoResponseMessage connection) => ...;
}
```

## Using OnInitInputArgs.DMS

From DataMiner 10.3.4/10.4.0 onwards<!-- RN 35701 -->, ad hoc data sources can use the [DMS](xref:GQI_OnInitInputArgs#properties) property of [OnInitInputArgs](xref:GQI_OnInitInputArgs). To access this property, implement [IGQIOnInit](xref:GQI_IGQIOnInit).

From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, when using the GQI DxM, [GQIDMS.GetConnection()](xref:GQI_GQIDMS#iconnection-getconnection) can be called again to receive a fresh connection if the underlying SLNet connection was dropped.

```csharp
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

    public GQIColumn[] GetColumns() => ...;

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var connections = GetConnections();
        var rows = connections.Select(CreateRow).ToArray();
        return new GQIPage(rows);
    }

    private IEnumerable<LoginInfoResponseMessage> GetConnections()
    {
        var request = new GetInfoMessage(InfoType.ClientList);
        var responses = _dms.SendMessages(request);
        return responses.OfType<LoginInfoResponseMessage>();
    }

    private GQIRow CreateRow(LoginInfoResponseMessage connection) => ...;
}
```

> [!IMPORTANT]
> `GQIDMS` can only be used during the lifetime of the associated extension instance. Do not store or reuse it outside that lifetime.
