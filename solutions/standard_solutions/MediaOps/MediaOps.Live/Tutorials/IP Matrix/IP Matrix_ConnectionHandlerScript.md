---
uid: Tutorial_MediaOpsLive_IPMatrix_ConnectionHandlerScript
---

# Create a connection handler script for IP Matrix

A connection handler script is part of the MediaOps.LIVE mediation layer and is responsible for detecting and managing connections between endpoints for a specific connector (for example, a broadcast controller).

This tutorial walks you through the process of creating your own connection handler.

Expected duration: 60 minutes

> [!TIP]
> The following [documentation](xref:MediaOps.Live.Mediation#connection-handler) described in more detail what a connection handler is and how it is used in MediaOps Live.

## Prerequisites

- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) installed on your machine.
- [DIS](https://docs.dataminer.services/develop/TOOLS/DIS/Introduction.html) extension installed in Visual Studio.
- The `Generic Dynamic Table` connector, elements, endpoints and VSGs that were provisioned in [this tutorial](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual).

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Inherit from the ConnectionHandlerScript base class](#step-3-inherit-from-the-connectionhandlerscript-base-class)
- [Step 4: Implement `GetSupportedElements` and `GetSubscriptionInfo`](#step-4-implement-getsupportedelements-and-getsubscriptioninfo)
- [Step 5: Implement `ProcessParameterUpdate`](#step-5-implement-processparameterupdate)
- [Step 6: Implement `Connect` and `Disconnect`](#step-6-implement-connect-and-disconnect)
- [Step 7: Publish and test the script](#step-7-publish-and-test-the-script)

## Step 1: Create a new automation script

Create a new automation script in Visual Studio, using DIS.
You can follow the steps in the [DIS documentation](https://docs.dataminer.services/develop/TOOLS/DIS/Developing/Developing_Automation_scripts_as_Visual_Studio_solutions.html#creating-a-new-script-in-a-solution) to create a new automation script.

There are some important requirements to make sure the script is recognized as a connection handler script by the mediation layer:

- The script name should end with `_ConnectionHandler`: e.g. `IPMatrix_ConnectionHandler`.
- Folder: 'MediaOps/ConnectionHandlerScripts'
- Two input parameters:
  - `Action` (string)
  - `Input Data` (string)

## Step 2: Add NuGet packages and using statements

Add the following NuGet packages to your project:

- `Skyline.DataMiner.MediaOps.Live`
- `Skyline.DataMiner.MediaOps.Live.Automation`
- `Skyline.DataMiner.Dev.Automation`
- `Skyline.DataMiner.Core.DataMinerSystem.Automation`

Now you can add the following using statements to your script:

```csharp
using Skyline.DataMiner.MediaOps.Live.API;
using Skyline.DataMiner.MediaOps.Live.Automation;
```

## Step 3: Inherit from the ConnectionHandlerScript base class

Let the script inherit from the `ConnectionHandlerScript` base class.
The `Run` method is not needed anymore, as the base class already implements it, so you can remove it.
The base class will call the appropriate methods that you will implement in the next steps.

```csharp
using Skyline.DataMiner.MediaOps.Live.Automation.Mediation.ConnectionHandlers;

public class Script : ConnectionHandlerScript
{

}
```

Alternatively, you can also keep the `Script` class, and create a new class that inherits from `ConnectionHandler`.
In some situations this could be more flexible, for example when you dynamically want to call different connection handlers based on the input data.

```csharp
using Skyline.DataMiner.MediaOps.Live.Automation.Mediation.ConnectionHandlers;

public class Script
{
    public void Run(IEngine engine)
    {
        var handler = new Generic_Matrix_ConnectionHandler();
        handler.Execute(engine);
    }
}

public class Generic_Matrix_ConnectionHandler : ConnectionHandler
{

}
```

## Step 4: Implement `GetSupportedElements` and `GetSubscriptionInfo`

Now you can implement the required methods in your script. Each serves a different purpose when interacting with the mediation layer.

The first method that we will implement is `GetSupportedElements`.
This method should return a list of elements that are supported by this connection handler script.
The base class provides a list of elements that run on the same hosting DMA as the script. This list should be used to build the list of supported elements.

In our case, we want to support all elements that use the `Generic Dynamic Table` protocol and have a name that starts with `Decoder `.
We don't need to subscribe to the encoder elements, as they are only used as a source for the connection and their configuration is static.

```csharp
public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
{
    return elements.Where(e => e.Protocol == "Generic Dynamic Table");
}
```

The next method that we will implement is `GetSubscriptionInfo`.
This method tells the mediation layer which parameters to subscribe to on the supported elements. Both standalone and table parameters are supported.
When a parameter changes, the `ProcessParameterUpdate` method will be called with the new parameter value.

In our case, we want to subscribe to the `Entries` table (ID 200) on the decoder elements.

```csharp
public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
{
    return new[]
    {
        new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 200), // Entries Table
    };
}
```

## Step 5: Implement `ProcessParameterUpdate`

This method is called whenever a subscribed parameter changes on one of the supported elements.
Use these updates to connect or disconnect endpoints through the API.

This method should implement the following workflow:

- Inspect the updated and/or deleted rows.
- Find matching source and destination endpoints using `connectionEngine.Api`.
- Register new connections or disconnects using `connectionEngine.RegisterConnections()`.

In our case, we will check if the `IP In` row was updated. If so, we will check if a multicast IP is configured.
If a multicast IP is configured, we will try to find the corresponding source endpoint using the multicast IP.
Optionally you could also check if the source IP and port match, but in this case we only have the multicast IP available.
The destination endpoint can simply be found using the element ID, as there is only one destination endpoint per decoder element.

> [!NOTE]
> The destination endpoint is always mandatory. However, it could be that the corresponding source endpoint is not found.
> In that case it's still possible to register the connection, but with an unknown source endpoint.
> This could happen when the source endpoint is not (yet) provisioned in MediaOps.

```csharp
public override void ProcessParameterUpdate(IEngine engine, IConnectionHandlerEngine connectionEngine, ParameterUpdate update)
{
    if (update.ParameterId != 200)
    {
        // we are only interested in updates of the outputs table
        return;
    }

    var updatedConnections = new List<ConnectionUpdate>();

    var elementId = update.DmsElementId;
    var destinationEndpoint = connectionEngine.Api.Endpoints.GetByElement(elementId)
        .SingleOrDefault(e => e.Role == Role.Destination);

    if (destinationEndpoint == null)
    {
        throw new InvalidOperationException($"Element with ID {elementId} does not have a destination endpoint.");
    }

    if (update.UpdatedRows != null)
    {
        var row = update.UpdatedRows.Values.FirstOrDefault(x => String.Equals(x[1], "IP In"));
        if (row == null)
        {
            // No 'IP In' row found in the updated rows.
            return;
        }

        var multicastIp = Convert.ToString(row[4]);
        var isConnected = !String.IsNullOrWhiteSpace(multicastIp);

        if (isConnected)
        {
            var multicast = new Multicast(multicastIp);
            var sourceEndpoint = connectionEngine.Api.Endpoints.GetByMulticasts(new[] { multicast })
                .SingleOrDefault();

            if (sourceEndpoint != null)
            {
                // register connection between source and destination
                updatedConnections.Add(new ConnectionUpdate(sourceEndpoint, destinationEndpoint));
            }
            else
            {
                // source endpoint not found, register as connected to an unknown source
                updatedConnections.Add(new ConnectionUpdate(destinationEndpoint, isConnected: true));
            }
        }
        else
        {
            // register destination as disconnected
            updatedConnections.Add(new ConnectionUpdate(destinationEndpoint, isConnected: false));
        }
    }

    if (update.DeletedRows != null)
    {
        // not implemented for this example
    }

    if (updatedConnections.Count > 0)
    {
        connectionEngine.RegisterConnections(updatedConnections);
    }
}
```

## Step 6: Implement `Connect` and `Disconnect`

Finally, we will implement the `Connect` and `Disconnect` methods.
These methods are called when a connect or disconnect request is made through the API or the Control Surface application.

In these methods we will perform the necessary sets on the device element (in this case the decoder) to create or remove connections.
This typically involves setting (table) parameters or sending inter-app messages.

> [!NOTE]
> The mediation layer can provide requests in bulk, however in this example we will process them one by one.
> When the device connector supports bulk operations, it is recommended to use them for better performance.
> The example code below shows how to group the requests by element, so that you can perform a single bulk operation per element.

```csharp
public override void Connect(IEngine engine, IConnectionHandlerEngine connectionEngine, CreateConnectionsRequest createConnectionsRequest)
{
    var groupedByDestinationElement = createConnectionsRequest.Connections.GroupBy(x => x.DestinationEndpoint.Element);

    foreach (var group in groupedByDestinationElement)
    {
        var elementId = group.Key.Value;
        var element = engine.FindElement(elementId.AgentId, elementId.ElementId);

        foreach (var connection in group)
        {
            var endpoint = connection.SourceEndpoint;
            var multicastIP = endpoint.TransportTypeTSoIP.MulticastIP;

            // Connect by setting the multicast IP in the "IP In" row of the Entries table
            element.SetParameter("Text Value (Entries)", "IP In", multicastIP);
        }
    }
}

public override void Disconnect(IEngine engine, IConnectionHandlerEngine connectionEngine, DisconnectDestinationsRequest disconnectDestinationsRequest)
{
    var groupedByDestinationElement = disconnectDestinationsRequest.Destinations.GroupBy(x => x.Element);

    foreach (var group in groupedByDestinationElement)
    {
        var elementId = group.Key.Value;
        var element = engine.FindElement(elementId.AgentId, elementId.ElementId);

        foreach (var destination in group)
        {
            // Disconnect by clearing the multicast IP
            element.SetParameter("Text Value (Entries)", "IP In", String.Empty);
        }
    }
}
```

## Step 7: Publish and test the script

All the necessary code is now implemented. You can build the project to make sure there are no errors.
If the build is successful, you can publish the script to the DMA using DIS.

In the mediation element, on the 'Connection Handler Scripts' page, you should now see that the connection handler script is listed as available script.
The decoder elements should be linked automatically to this script. You can also link them manually if needed.

You can test the connection handler script by making some connections in the Control Surface low-code application.
Connections can be verified by looking at the button of the destination endpoint. The button should show the name of the connected source endpoint.
You can also check the device element directly.
