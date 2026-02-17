---
uid: Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual
---

# Provision endpoints and virtual signal groups for Generic Matrix

In this tutorial, you will learn how to provision endpoints and virtual signal groups (VSGs) for the **Generic Matrix** connector.
These endpoints and VSGs will be used to visualize and manage the connections in the MediaOps.LIVE solution.

Expected duration: 30 minutes

## Ways to create endpoints and VSGs

There are three ways to create endpoints and VSGs:

- [Manually, using the Virtual Signal Groups low-code app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual). (This tutorial)
- [Through an automation script, using the MediaOps.LIVE API](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code).
- [Using the CSV import functionality in the Virtual Signal Groups app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import).

## Prerequisites

- [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector installed and an element exists on the DMA. The 1.0.1.X range is needed for this tutorial.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.

## Overview

- [Step 1: Create level and transport type](#step-1-create-level-and-transport-type)
- [Step 2: Create endpoints](#step-2-create-endpoints)
- [Step 3: Create virtual signal groups](#step-3-create-virtual-signal-groups)
- [Step 4: Create a test connection](#step-4-create-a-test-connection)

## Step 1: Create level and transport type

First, you need to create a level and transport type in MediaOps.LIVE.
In this tutorial for the Generic Matrix connector, we will use the 'Video' level and 'SDI' transport type.
You can skip this step if the level and transport type already exist.

To do this, follow these steps:

1. Open the `Virtual Signal Groups` low-code app in your web browser and log in with your credentials.
1. Navigate to the `Levels` tab, and press the `Transport Types` button in the header bar.
1. If the `SDI` transport type does not exist, create it by clicking the `New` button.
    - Name: `SDI`
1. Go back to the `Levels` tab.
1. Check if a level named `Video` already exists. If it does not exist, create it by clicking the `New` button.
    - Name: `Video`
    - Number: `0` (or the next available number)
    - Transport Type: `SDI`

## Step 2: Create endpoints

Next, you need to create endpoints for the inputs and outputs of the Generic Matrix connector.

To do this, follow these steps:

1. Navigate to the `Endpoints` tab in the `Virtual Signal Groups` app.
1. Click the `New` button to create a new endpoint. A popup window will appear.
1. Fill in the following details:
    - Name: `Matrix Input 1` (needs to be unique)
    - Role: `Source`
    - Element: Select the Generic Matrix element from the dropdown
    - Identifier: `1` (row key in the inputs or outputs table of the Generic Matrix connector). This identifier will be used later to link the endpoint back to the correct input or output in the element.
    - Control Element: leave empty
    - Control Element Identifier: leave empty
    - Transport Type: `SDI`
1. Click `Save` to create the endpoint.

Now you should see that the endpoint has been created linked to row key `1` of the inputs table of the Generic Matrix connector.
Repeat these steps to create more endpoints for inputs and outputs as needed.
Make sure to also create at least one destination endpoint.

## Step 3: Create virtual signal groups

Finally, you need to create virtual signal groups (VSGs). VSGs are logical groupings that allow creating connections between multiple endpoints at the same time.
In this case we will create a VSG for each endpoint that we created in the previous step.
The endpoints will be assigned to the VSG on the Video level, but this can be adjusted based on your needs.

To do this, follow these steps:

1. Navigate to the `Virtual Signal Groups` tab in the `Virtual Signal Groups` app.
1. Click the `New` button to create a new VSG. A popup window will appear.
1. Fill in the following details:
    - Name: `Matrix Input 1` (needs to be unique)
    - Description: a meaningful description (optional)
    - Role: `Source`
1. Click `Save` to create the VSG.

Now you should see that the VSG has been created. Next, you need to assign an endpoint to the VSG.

1. Click on the edit endpoints icon on the row of the VSG you just created. A side panel will open.
1. In the table at the top, select the `Video` level.
1. In the table at the bottom, select the endpoint you created in the previous step (e.g. `Matrix Input 1`).
1. Press the `Assign` button to assign the endpoint to the VSG.
1. You should now see that the endpoint is assigned on the Video level.

Repeat these steps to create more VSGs for inputs and outputs as needed.
Use role `Source` for input VSGs and role `Destination` for output VSGs.

## Step 4: Create a test connection

To be able to create a connection between a source and destination, you first need to create a connection handler script for Generic Matrix.
To do this, follow the steps in the [Create a connection handler script for Generic Matrix](xref:Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript) tutorial.

Once you have created the connection handler script, you can create a test connection.

1. Navigate to the `Control Surface` low-code application.
1. Search the virtual signal groups you created in the previous steps (source and destination).
1. Press the `Connect` button.
1. A connection should now be created between the source and destination.

## Up next

You're now able to create endpoints and virtual signal groups one-by-one manually in the app, but in many cases there will be too many to do this manually.
In the next tutorial, you will learn how to automate this process using an automation script.
To continue, see [Provision endpoints and virtual signal groups for Generic Matrix using code](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code).
