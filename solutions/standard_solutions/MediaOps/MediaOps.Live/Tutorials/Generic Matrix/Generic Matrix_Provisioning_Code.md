---
uid: Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code
---

# Provision endpoints and virtual signal groups for Generic Matrix using code

In this tutorial you will learn how to use the MediaOps Live API to provision endpoints and virtual signal groups for the Generic Matrix connector.
These endpoints are needed to visualize and manage the connections of the Generic Matrix connector in MediaOps Live.

Expected duration: 60 minutes

## Ways to create endpoints and VSGs

There are three ways to create endpoints and VSGs:

- [Manually, using the Virtual Signal Groups low-code app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual).
- [Through an automation script, using the MediaOps.LIVE API](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code). (This tutorial)
- [Using the CSV import functionality in the Virtual Signal Groups app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import).

## Prerequisites

- [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector installed and an element exists on the DMA. The 1.0.1.X range is needed for this tutorial.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) installed on your machine.
- [DIS](https://docs.dataminer.services/develop/TOOLS/DIS/Introduction.html) extension installed in Visual Studio.

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Create level and transport type](#step-3-create-level-and-transport-type)
- [Step 4: Provision source endpoints and VSGs](#step-4-provision-source-endpoints-and-vsgs)
- [Step 5: Provision destination endpoints and VSGs](#step-5-provision-destination-endpoints-and-vsgs)
- [Step 6: Publish and run the script](#step-6-publish-and-run-the-script)

## Step 1: Create a new automation script

In Visual Studio, create a new automation script. In this script, we will read the inputs and outputs of the matrix control, and provision the corresponding endpoints and virtual signal groups in MediaOps Live.

You can follow the steps in the [DIS documentation](https://docs.dataminer.services/develop/TOOLS/DIS/Developing/Developing_Automation_scripts_as_Visual_Studio_solutions.html#creating-a-new-script-in-a-solution) to create a new automation script.

The name of the script doesn't really matter, just choose something meaningful that fits within your project or solution.

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

Next, you need to get an instance of the MediaOps Live API in your script.
You can do this by using the `GetMediaOpsLiveApi` extension method on the `Engine` object.

```csharp
var api = engine.GetMediaOpsLiveApi();
```

## Step 3: Create level and transport type

Before we can create endpoints and virtual signal groups, we need to ensure that the required level and transport type exist in MediaOps Live.
In this tutorial, we will use the "Video" level and transport type "SDI".
Use the Virtual Signal Groups application to create these if they do not already exist.
Make sure the Video level uses SDI as transport type.

> [!NOTE]
> If needed, you can also create levels and transport types using the API (`api.Levels.CreateOrUpdate()` and `api.TransportTypes.CreateOrUpdate()` methods).

## Step 4: Provision source endpoints and VSGs

In this step we will create the source endpoints and virtual signal groups (VSGs) in MediaOps using the API.
Those will be based on the tables that are present in the Generic Matrix element.

The following code snippet shows how to read the rows of the input table and create the corresponding endpoints and VSGs.
Already existing endpoints and VSGs will be updated.

This method should be called from the `Run` or `RunSafe` method of your script.

> [!WARNING]
> Endpoint and virtual signal group names must be unique across your entire MediaOps.LIVE system.
> The script uses naming patterns like "Matrix Input {key}" and "Matrix Output {key}". If these names already exist from previous tutorials or other configurations, you should modify the naming logic in the script to ensure uniqueness.

```csharp

private void ProvisionSources(IEngine engine, Element element, MediaOpsLiveApi api)
{
    var elementId = new DmsElementId(element.DmaId, element.ElementId);

    // Get the video level and SDI transport type. They will assigned to the endpoints and virtual signal groups.
    var videoLevel = api.Levels.Read("Video");
    var sdiTransportType = api.TransportTypes.Read("SDI");

    // Get existing endpoints and virtual signal groups for the element.
    var existingEndpoints = api.Endpoints.Query()
        .Where(x => x.Role == Role.Source && x.Element == elementId)
        .SafeToDictionary(x => (x.Element, x.Identifier));

    var existingVirtualSignalGroups = api.VirtualSignalGroups
        .GetByEndpointIds(existingEndpoints.Values.Select(x => x.ID))
        .SafeToDictionary(x => x.Name);

    engine.GenerateInformation($"Found {existingEndpoints.Count} existing endpoints and {existingVirtualSignalGroups.Count} existing virtual signal groups for matrix inputs.");

    // Prepare lists to hold the new or updated endpoints and virtual signal groups.
    var newEndpoints = new List<Endpoint>();
    var newVirtualSignalGroups = new List<VirtualSignalGroup>();

    foreach (var key in element.GetTablePrimaryKeys("Router Control Inputs"))
    {
        var name = $"Matrix Input {key}";

        // Create the endpoint if it does not exist yet.
        if (!existingEndpoints.TryGetValue((elementId, key), out var endpoint))
        {
            endpoint = new Endpoint();
        }

        endpoint.Name = name;
        endpoint.Role = Role.Source;
        endpoint.Element = elementId;
        endpoint.Identifier = key;
        endpoint.TransportType = sdiTransportType;

        newEndpoints.Add(endpoint);

        // Create the virtual signal group if it does not exist yet.
        if (!existingVirtualSignalGroups.TryGetValue(name, out var vsg))
        {
            vsg = new VirtualSignalGroup();
        }

        vsg.Name = name;
        vsg.Role = Role.Source;
        vsg.AssignEndpointToLevel(videoLevel, endpoint);

        newVirtualSignalGroups.Add(vsg);
    }

    // Create or update the endpoints and virtual signal groups via the API.
    api.Endpoints.CreateOrUpdate(newEndpoints);
    api.VirtualSignalGroups.CreateOrUpdate(newVirtualSignalGroups);
}

```

## Step 5: Provision destination endpoints and VSGs

Similar to the previous step, we will now create the destination endpoints and virtual signal groups.

This method should be called from the `Run` or `RunSafe` method of your script.

```csharp

private void ProvisionDestinations(IEngine engine, Element element, MediaOpsLiveApi api)
{
    var elementId = new DmsElementId(element.DmaId, element.ElementId);

    var videoLevel = api.Levels.Read("Video");
    var sdiTransportType = api.TransportTypes.Read("SDI");

    var existingEndpoints = api.Endpoints.Query()
        .Where(x => x.Role == Role.Destination && x.Element == elementId)
        .SafeToDictionary(x => (x.Element, x.Identifier));

    var existingVirtualSignalGroups = api.VirtualSignalGroups
        .GetByEndpointIds(existingEndpoints.Values.Select(x => x.ID))
        .SafeToDictionary(x => x.Name);

    engine.GenerateInformation($"Found {existingEndpoints.Count} existing endpoints and {existingVirtualSignalGroups.Count} existing virtual signal groups for matrix outputs.");

    var newEndpoints = new List<Endpoint>();
    var newVirtualSignalGroups = new List<VirtualSignalGroup>();

    foreach (var key in element.GetTablePrimaryKeys("Router Control Outputs"))
    {
        var name = $"Matrix Output {key}";

        // Create the endpoint if it does not exist yet.
        if (!existingEndpoints.TryGetValue((elementId, key), out var endpoint))
        {
            endpoint = new Endpoint();
        }

        endpoint.Name = name;
        endpoint.Role = Role.Destination;
        endpoint.Element = elementId;
        endpoint.Identifier = key;
        endpoint.TransportType = sdiTransportType;

        newEndpoints.Add(endpoint);

        // Create the virtual signal group if it does not exist yet.
        if (!existingVirtualSignalGroups.TryGetValue(name, out var vsg))
        {
            vsg = new VirtualSignalGroup();
        }

        vsg.Name = name;
        vsg.Role = Role.Destination;
        vsg.AssignEndpointToLevel(videoLevel, endpoint);

        newVirtualSignalGroups.Add(vsg);
    }

    api.Endpoints.CreateOrUpdate(newEndpoints);
    api.VirtualSignalGroups.CreateOrUpdate(newVirtualSignalGroups);
}

```

## Step 6: Publish and run the script

Publish the script with DIS and run it on the DMA.
After running the script, you should see the newly created endpoints and virtual signal groups in the Virtual Signal Groups application.

## Final script

The following [repository on GitHub](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-GenericMatrix) contains the complete script that you can use as a reference.

## Up next

When you have finished this tutorial, you can continue with creating a [connection handler script](xref:Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript).
This script will use the endpoints and virtual signal groups that you created in this tutorial to visualize and manage connections.
