---
uid: MediaOpsLive_ConnectionHandlerScript
description: "Create MediaOps Live connection handler scripts responsible for managing the connections for one specific connector."
---

# Connection handler scripts

A connection handler script is a custom script responsible for managing the connections for one specific connector (e.g., broadcast controller). It interacts with the [mediation layer](xref:MediaOps.Live.Mediation) to set up new connections and to update existing connections in the database.

To implement a connection handler script, you need to create a new class that derives from the `ConnectionHandler` base class. This abstract base class provides a framework to manage connections for a specific protocol by defining the methods that must be implemented. The derived class should override these methods to handle connector-specific logic.

> [!NOTE]
> The `ConnectionHandler` class is part of the *Skyline.DataMiner.MediaOps.Live* NuGet package.

```csharp
public class Script
{
    public void Run(IEngine engine)
    {
        var handler = new EVS_Cerebrum_ConnectionHandler();
        handler.Execute(engine);
    }
}

public class EVS_Cerebrum_ConnectionHandler : ConnectionHandler
{
    public override ConnectionHandlerConfiguration GetConfiguration()
    {
        // ...
    }

    public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
    {
        // ...
    }

    public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
    {
        // ...
    }

    public override void ProcessParameterUpdate(IEngine engine, IConnectionHandlerEngine connectionEngine, ParameterUpdate update)
    {
        // ...
    }

    public override void Connect(IEngine engine, IConnectionHandlerEngine connectionEngine, CreateConnectionsRequest createConnectionsRequest)
    {
        // ...
    }

    public override void Disconnect(IEngine engine, IConnectionHandlerEngine connectionEngine, DisconnectDestinationsRequest disconnectDestinationsRequest)
    {
        // ...
    }
}
```

## GetConfiguration() method

The `GetConfiguration` method is an optional override that allows the connection handler script to customize its configuration. When it is not overridden, the default configuration is used.

Currently, the configuration lets you customize the timeout for connect and disconnect operations. Both timeouts default to 10 seconds.

```csharp
    public override ConnectionHandlerConfiguration GetConfiguration()
    {
        return new ConnectionHandlerConfiguration
        {
            ConnectTimeout = TimeSpan.FromSeconds(30),
            DisconnectTimeout = TimeSpan.FromSeconds(30),
        };
    }
```

## GetSupportedElements() method

The `GetSupportedElements` method allows the connection handler script to indicate which elements it is designed to work with.

The method receives the list of available elements from the mediation layer and should return only those that are applicable to the connection handler. This filtering can be based on protocol, version, element type, etc.

```csharp
    public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
    {
        return elements.Where(e => e.Protocol == "My Device Protocol");
    }
```

## GetSubscriptionInfo() method

The purpose of this method is to let the mediation layer know which parameters (table or standalone), the connection handler script is interested in. The mediation layer will subscribe to these parameters and forward all changes.

```csharp
    public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
    {
        return new[]
        {
            new SubscriptionInfo(SubscriptionInfo.ParameterType.Standalone, 1000),
            new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 12100), // Routes
            new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 14100), // Sources
            new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 15100), // Destinations
        };
    }
```

Instead of using the constructor, you can also create the `SubscriptionInfo` objects with the `StandaloneParameter` and `Table` factory methods:

```csharp
    public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
    {
        return new[]
        {
            SubscriptionInfo.StandaloneParameter(1000),
            SubscriptionInfo.Table(12100), // Routes
            SubscriptionInfo.Table(14100), // Sources
            SubscriptionInfo.Table(15100), // Destinations
        };
    }
```

### Filtering on columns and row keys

For table parameters, you can narrow down the subscription so that only changes to specific columns and/or a specific row are reported. This reduces the number of updates the connection handler script has to process. You can apply these filters with the following methods, which can be chained onto a `SubscriptionInfo` object:

- `FilterColumn(int column)`: Only report changes to the specified column parameter ID.
- `FilterColumns(params ICollection<int> columns)`: Only report changes to the specified column parameter IDs.
- `FilterRowKey(string rowKey)`: Only report changes to the row with the specified row key. The provided key supports wildcards (`*` and `?`).

> [!NOTE]
> These filters are only applicable to table parameters. When you filter on columns, you must still provide the table parameter ID.

```csharp
    public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
    {
        return new[]
        {
            SubscriptionInfo.StandaloneParameter(1000),

            // Only report changes to columns 12102 and 12103 of the Routes table.
            SubscriptionInfo.Table(12100).FilterColumns(12102, 12103),

            // Only report changes to column 14102 of a specific row in the Sources table.
            SubscriptionInfo.Table(14100).FilterColumn(14102).FilterRowKey("Source 1"),
        };
    }
```

## ProcessParameterUpdate() method

The `ProcessParameterUpdate` method is triggered by the mediation layer whenever a parameter of a device element changes. Its purpose is to update the current connections (connect and disconnect) via the API.

Based on the parameter changes, the method should try to find the corresponding source and destination endpoints that match the new data. Endpoints can be retrieved using the convenience methods on the `connectionEngine` parameter (e.g., `GetEndpointsWithTransportMetadata`, `GetEndpointsWithElement`, or `GetEndpointsWithIdentifier`) or directly via the API object (`connectionEngine.Api.Endpoints`).

Example:

```csharp
    var sourceEndpoints = connectionEngine.GetEndpointsWithTransportMetadata(EndpointRole.Source, ...);
```

Once connections are detected, they should be registered using the `connectionEngine` provided as a parameter to the method. Disconnects also need to be registered. The endpoint objects retrieved using the code above should be used to create `ConnectionUpdate` objects. New connections overwrite existing connections, based on the destination endpoint. In most cases, there is no need to first retrieve the existing connections from the API.

> [!NOTE]
> If a connection is detected but the corresponding source endpoint cannot be found, the connection still has to be registered.

```csharp
    public override void ProcessParameterUpdate(IEngine engine, IConnectionHandlerEngine connectionEngine, ParameterUpdate update)
    {
        var updatedConnections = new List<ConnectionUpdate>();

        if (update.ParameterId != 12100)
        {
            if (update.UpdatedRows != null)
            {
                {
                    // ...
                }
            }

            if (update.DeletedRows != null)
            {
                // ...
            }
        }

        if (updatedConnections.Count > 0)
        {
            connectionEngine.RegisterConnections(updatedConnections);
        }
    }
```

## Connect() method

This method is executed to set up a new connection on a device or controller. It is intended to set the necessary parameters and/or send an InterApp message to the element. Connection changes will eventually cause a parameter update, which will be handled by `ProcessParameterUpdate` and will update the connection.

```csharp
    public override void Connect(IEngine engine, IConnectionHandlerEngine connectionEngine, CreateConnectionsRequest createConnectionsRequest)
    {
        foreach (var connectionRequest in createConnectionsRequest.Connections)
        {
            var source = connectionRequest.SourceEndpoint;
            var destination = connectionRequest.DestinationEndpoint;

            var sourceElement = engine.FindElementByKey(source.Element);
            var destinationElement = engine.FindElementByKey(destination.Element);

            // ...
        }
    }
```

## Disconnect() method

This method is executed to disconnect a connection on a device or controller. It is intended to set the necessary parameters and/or send an InterApp message to the element.

```csharp
    public override void Disconnect(IEngine engine, IConnectionHandlerEngine connectionEngine, DisconnectDestinationsRequest disconnectDestinationsRequest)
    {
        foreach (var destination in disconnectDestinationsRequest.Destinations)
        {
            var destinationElement = engine.FindElementByKey(destination.Element);

            // ...
        }
    }
```
