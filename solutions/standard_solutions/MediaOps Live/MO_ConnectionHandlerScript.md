---
uid: MediaOpsLive_ConnectionHandlerScript
---

# Connection Handler Script

The connection handler script is a custom script that is responsible to manage the connections for one specific connector (e.g. broadcast controller). It interacts with the mediation layer to setup new connections and to update existing connections in the database.

To implement a connection handler script, a new class needs to be created that derives from the 'ConnectionHandler' base class. This abstract base class provides a framework to manage connections for a specific protocol by defining the methods that must be implemented. The derived class should override these methods to handle connector specific logic.

> [!NOTE]
> The ConnectionHandler class is part of the Skyline.DataMiner.MediaOps.Live NuGet package.

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

## GetSupportedElements() method

The `GetSupportedElements` method allows the connection handler script to indicate which elements it is designed to work with.

The method receives the list of available elements from the mediation layer and should return only those that are applicable to the connection handler.
This filtering can be based on protocol, version, element type, etc.

```csharp
    public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
    {
        return elements.Where(e => e.ProtocolN == "My Device Protocol");
    }
```

## GetSubscriptionInfo() method

The purpose of this method is to let the mediation layer know in which parameters (table or standalone), the connection handler script is interested in.
The mediation layer will subscribe on these parameters and forward all changes.

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

## ProcessParameterUpdate() method

The `ProcessParameterUpdate` method is triggered by the mediation layer whenever a parameter of a device element changes. Its purpose is to update the current connections (connect and disconnect) via the API.

Based on the parameter changes, the method should try to find the corresponding source and destination endpoints that match the new data. Endpoints can be retrieved using the API object that can be found in the connectionEngine parameter.

Example:

```csharp
    var sourceEndpoints = connectionEngine.Api.Endpoints.GetByMulticasts(...);
```

Once connections are detected, they should be registered using the connectionEngine provided as a parameter to the method. Also disconnects need to be registered. The endpoint objects that were retrieved using the above code, should be used to create ConnectionInfo objects. New connections overwrite existing connections, based on the destination endpoint. In most cases, there is no need to first retrieve the existing connections from the API.

> [!NOTE]
> If a connection is detected but the corresponding source endpoint cannot be found, the connection must still be registered.

```csharp
    public override void ProcessParameterUpdate(IEngine engine, IConnectionHandlerEngine connectionEngine, ParameterUpdate update)
    {
        var updatedConnections = new List<ConnectionInfo>();

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

This method is being executed to setup a new connection on a device or controller. In this method it's the intention to set the necessary parameters and/or send an InterApp message to the element. Connection changes will eventually cause a parameter update, which will be handled by 'ProcessParameterUpdate' and update the connection.

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

This method is being executed to disconnect a connection on a device or controller. In this method it's the intention to set the necessary parameters and/or send an InterApp message to the element.

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
