---
uid: Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript
---

# Creating a connection handler script for a Generic Matrix element

A connection handler script is part of the MediaOps Live [mediation layer](xref:MediaOps.Live.Mediation) and is responsible for detecting and managing connections between endpoints for a specific connector (for example, a broadcast controller). This tutorial walks you through the process of creating your own connection handler.

Expected duration: 60 minutes

> [!TIP]
> For details about connection handler scripts and how they are used in MediaOps Live, refer to [Connection handler scripts](xref:MediaOps.Live.Mediation#connection-handler-scripts).

## Prerequisites

- Range 1.0.1.x of the [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector is installed on the DMA, and an element has been created using this connector.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) is installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) is installed on your machine.
- The [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) extension is installed in Visual Studio.
- Some endpoints and virtual signal groups have been created in MediaOps, for example via the tutorial [Manually provisioning endpoints and virtual signal groups for a Generic Matrix element](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual).

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Make the script inherit from the ConnectionHandlerScript base class](#step-3-make-the-script-inherit-from-the-connectionhandlerscript-base-class)
- [Step 4: Implement GetSupportedElements and GetSubscriptionInfo](#step-4-implement-getsupportedelements-and-getsubscriptioninfo)
- [Step 5: Implement ProcessParameterUpdate](#step-5-implement-processparameterupdate)
- [Step 6: Implement Connect and Disconnect](#step-6-implement-connect-and-disconnect)
- [Step 7: Publish and test the script](#step-7-publish-and-test-the-script)

## Step 1: Create a new automation script

Create a new automation script in Visual Studio, using DIS. For details, refer to the [DIS documentation](xref:Developing_Automation_scripts_as_Visual_Studio_solutions#creating-a-new-script-in-a-solution).

Make sure the following requirements are met, so that the mediation layer will recognize your script as a connection handler script:

- The script name should end with `_ConnectionHandler`, e.g., `Generic_Matrix_ConnectionHandler`.
- The script must be included in the folder `MediaOps/ConnectionHandlerScripts`.
- The following two input parameters must be present:
  - `Action` (string)
  - `Input Data` (string)

## Step 2: Add NuGet packages and using statements

1. Add the following NuGet packages to your project:

   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live`
   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live.Automation`
   - `Skyline.DataMiner.Dev.Automation`
   - `Skyline.DataMiner.Core.DataMinerSystem.Automation`

1. Add the following `using` statements to your script:

   ```csharp
   using Skyline.DataMiner.Solutions.MediaOps.Live.API;
   using Skyline.DataMiner.Solutions.MediaOps.Live.Automation;
   ```

## Step 3: Make the script inherit from the ConnectionHandlerScript base class

Next, you need to make the script inherit from the `ConnectionHandlerScript` base class. The `Run` method is no longer needed, as the base class already implements it, so you can remove it. The base class will call the appropriate methods that you will implement in the next steps.

```csharp
using Skyline.DataMiner.Solutions.MediaOps.Live.Automation.Mediation.ConnectionHandlers;

public class Script : ConnectionHandlerScript
{

}
```

Alternatively, you can also keep the `Script` class, and create a new class that inherits from `ConnectionHandler`. In some situations, this could be more flexible, for example when you want to dynamically call different connection handlers based on the input data.

```csharp
using Skyline.DataMiner.Solutions.MediaOps.Live.Automation.Mediation.ConnectionHandlers;

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

## Step 4: Implement GetSupportedElements and GetSubscriptionInfo

Now you can implement the required methods in your script. Each serves a different purpose when interacting with the mediation layer.

The first method to implement is `GetSupportedElements`. This method should return a list of elements that are supported by this connection handler script. The base class provides a list of elements that run on the same hosting DMA as the script. This list should be used to build the list of supported elements.

```csharp
public override IEnumerable<ElementInfo> GetSupportedElements(IEngine engine, IEnumerable<ElementInfo> elements)
{
    return elements.Where(e => e.Protocol == "Generic Matrix");
}
```

The next method to implement is `GetSubscriptionInfo`. This method tells the mediation layer which parameters to subscribe to on the supported elements. Both standalone and table parameters are supported. When a parameter changes, the `ProcessParameterUpdate` method will be called with the new parameter value.

```csharp
public override IEnumerable<SubscriptionInfo> GetSubscriptionInfo(IEngine engine)
{
    return new[]
    {
        new SubscriptionInfo(SubscriptionInfo.ParameterType.Table, 1100), // Outputs Table
    };
}
```

## Step 5: Implement ProcessParameterUpdate

The `ProcessParameterUpdate` method is called whenever a subscribed parameter changes on one of the supported elements. Use these updates to connect or disconnect endpoints through the API.

This method should implement the following workflow:

- Inspect the updated and/or deleted rows.
- Find matching source and destination endpoints using `connectionEngine.Api`.
- Register new connections or disconnections using `connectionEngine.RegisterConnections()`.

The example below will look up the source and destination endpoints based on the element ID and the identifier from the table. In a similar way, you could also use other properties, such as a multicast IP address.

> [!NOTE]
> The destination endpoint is always mandatory. However, it could be that the corresponding source endpoint is not found. In that case it is still possible to register the connection, but with an unknown source endpoint. This could happen when the source endpoint is not (yet) provisioned in MediaOps.

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

## Step 6: Implement Connect and Disconnect

Finally, you need to implement the `Connect` and `Disconnect` methods.

With these methods, the script will perform the necessary sets on the device element to create or remove connections. This typically involves setting (table) parameters or sending inter-app messages.

> [!NOTE]
> The mediation layer can provide requests in bulk; however, in this example they are processed one by one. When the device connector supports bulk operations, using them is recommended for better performance. The example code below shows how to group the requests by element, so that you can perform a single bulk operation per element.

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

1. Now that all the necessary code has been implemented, build the project to make sure there are no errors.

1. If the build is successful, publish the script to the DMA using DIS.

1. In DataMiner Cube, go to the *Connection Handler Scripts* page of the mediation element.

   On this page, you should see that the connection handler script is listed as an available script.

   If there is a Generic Matrix element on the same DMA, it should automatically be linked to this script. If needed, you can link it manually.

1. Test your connection handler script by making some connections to the Control Surface app. For details, refer to [step 4 of the manual provisioning tutorial](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual#step-4-create-a-test-connection).

   You can verify connections by looking at the button of the destination endpoint. The button should show the name of the connected source endpoint. Note that you can also check the device element directly in Cube.

> [!TIP]
> The [SLC-AS-MediaOps.LIVE-Tutorial-GenericMatrix](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-GenericMatrix) repository on GitHub contains the complete script that you can use as a reference.
