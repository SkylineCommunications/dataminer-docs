---
uid: Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript
---

# Create a connection handler script for Generic Matrix

A connection handler script is part of the MediaOps.LIVE mediation layer and is responsible for detecting and managing connections between endpoints for a specific connector (for example, a broadcast controller).

This tutorial walks you through the process of creating your own connection handler.

Expected duration: 60 minutes

> [!TIP]
> The following [documentation](xref:MediaOps.Live.Mediation#connection-handler) described in more detail what a connection handler is and how it is used in MediaOps Live.

## Prerequisites

- [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector installed and an element exists on the DMA. The 1.0.1.X range is needed for this tutorial.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) installed on your machine.
- [DIS](https://docs.dataminer.services/develop/TOOLS/DIS/Introduction.html) extension installed in Visual Studio.
- Some endpoints and virtual signal groups created in MediaOps. You can follow the steps in [this](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual) tutorial to create these.

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

- The script name should end with `_ConnectionHandler`: e.g. `Generic_Matrix_ConnectionHandler`.
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

```csharp
public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
{
    return elements.Where(e => e.Protocol == "Generic Matrix");
}
```

The next method that we will implement is `GetSubscriptionInfo`.
This method tells the mediation layer which parameters to subscribe to on the supported elements. Both standalone and table parameters are supported.
When a parameter changes, the `ProcessParameterUpdate` method will be called with the new parameter value.

```csharp
public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
{
    return new[]
    {
        new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 1100), // Outputs Table
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

In this example we will lookup the source and destination endpoints based on the element ID and the identifier from the table.
In a similar way, you could also use other properties, such as a multicast IP address.

> [!NOTE]
> The destination endpoint is always mandatory. However, it could be that the corresponding source endpoint is not found.
> In that case it's still possible to register the connection, but with an unknown source endpoint.
> This could happen when the source endpoint is not (yet) provisioned in MediaOps.

```csharp
public override void ProcessParameterUpdate(IEngine engine, IConnectionHandlerEngine connectionEngine, ParameterUpdate update)
{
    if (update.ParameterId != 1100)
    {
        // we are only interested in updates of the outputs table
        return;
    }

    var updatedConnections = new List<ConnectionUpdate>();

    var elementId = update.DmsElementId;

    // Handle updated rows
    if (update.UpdatedRows != null)
    {
        foreach (var row in update.UpdatedRows.Values)
        {
            var outputIdentifier = Convert.ToString(row[0]);
            var inputIdentifier = Convert.ToString(row[5]);

            var output = connectionEngine.Api.Endpoints.GetByRoleElementAndIdentifier(Role.Destination, elementId, outputIdentifier)
                ?? throw new InvalidOperationException($"Destination endpoint '{outputIdentifier}' not found for element '{elementId}'.");

            if (String.IsNullOrWhiteSpace(inputIdentifier))
            {
                // Connected input is empty, which means that the output is disconnected.
                updatedConnections.Add(new ConnectionUpdate(output, isConnected: false));
                continue;
            }

            var input = connectionEngine.Api.Endpoints.GetByRoleElementAndIdentifier(Role.Source, elementId, inputIdentifier);

            if (input != null)
            {
                updatedConnections.Add(new ConnectionUpdate(input, output));
            }
            else
            {
                updatedConnections.Add(new ConnectionUpdate(output, isConnected: true));
            }
        }
    }

    // Handle deleted rows
    if (update.DeletedRows != null)
    {
        foreach (var row in update.DeletedRows.Values)
        {
            var outputIdentifier = Convert.ToString(row[0]);

            var output = connectionEngine.Api.Endpoints.GetByRoleElementAndIdentifier(Role.Destination, elementId, outputIdentifier)
                ?? throw new InvalidOperationException($"Destination endpoint '{outputIdentifier}' not found for element '{elementId}'.");

            updatedConnections.Add(new ConnectionUpdate(output, isConnected: false));
        }
    }

    // Register the connections with the mediation layer.
    // This will update, for instance, the Control Surface application.
    if (updatedConnections.Count > 0)
    {
        connectionEngine.RegisterConnections(updatedConnections);
    }
}
```

## Step 6: Implement `Connect` and `Disconnect`

Finally, we will implement the `Connect` and `Disconnect` methods.
In these methods we will perform the necessary sets on the device element to create or remove connections.
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
            var rowKey = connection.DestinationEndpoint.Identifier;
            var sourceIdentifier = connection.SourceEndpoint?.Identifier ?? String.Empty;

            element.SetParameterByPrimaryKey("Connected Input (Router Control Outputs)", rowKey, sourceIdentifier);
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
            var rowKey = destination.Identifier;

            element.SetParameterByPrimaryKey("Connected Input (Router Control Outputs)", rowKey, String.Empty);
        }
    }
}
```

## Step 7: Publish and test the script

All the necessary code is now implemented. You can build the project to make sure there are no errors.
If the build is successful, you can publish the script to the DMA using DIS.

In the mediation element, on the 'Connection Handler Scripts' page, you should now see that the connection handler script is listed as available script.
If there is a Generic Matrix element on the same DMA, it should be linked automatically to this script. You can also link it manually if needed.

You can test the connection handler script by making some connections in the Control Surface low-code application.
Connections can be verified by looking at the button of the destination endpoint. The button should show the name of the connected source endpoint.
You can also check the device element directly.

## Final script

The following [repository on GitHub](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-GenericMatrix) contains the complete script that you can use as a reference.
