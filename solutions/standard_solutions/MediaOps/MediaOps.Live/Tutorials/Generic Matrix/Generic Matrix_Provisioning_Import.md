---
uid: Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import
---

# Import/Export endpoints and virtual signal groups using CSV file

In this tutorial, you will learn how to use the CSV import functionality in the Virtual Signal Groups low-code app to provision endpoints and virtual signal groups (VSGs) for the **Generic Matrix** connector.
These endpoints and VSGs will be used to visualize and manage the connections in the MediaOps.LIVE solution.

Expected duration: 15 minutes

## Ways to create endpoints and VSGs

There are three ways to create endpoints and VSGs:

- [Manually, using the Virtual Signal Groups low-code app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual).
- [Through an automation script, using the MediaOps.LIVE API](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code).
- [Using the CSV import functionality in the Virtual Signal Groups app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import). (This tutorial)

## Prerequisites

- [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector installed and an element exists on the DMA. The 1.0.1.X range is needed for this tutorial.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.

## Overview

- [Step 1: Create level and transport type](#step-1-create-level-and-transport-type)
- [Step 2: Export existing endpoints](#step-2-export-existing-endpoints)
- [Step 3: Export existing virtual signal groups](#step-3-export-existing-virtual-signal-groups)
- [Step 4: Import new endpoints](#step-4-import-new-endpoints)
- [Step 5: Import new virtual signal groups](#step-5-import-new-virtual-signal-groups)

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

## Step 2: Export existing endpoints

Now we will export the existing endpoints to a CSV file.
This will provide us with a template that we can use to create new endpoints.
The exported file will contain all the necessary columns and formatting required for the import.
The file can also be used to update existing endpoints.

To do this, follow these steps:

1. Navigate to the `Endpoints` tab in the `Virtual Signal Groups` app.
1. Click the `Export` button in the header bar. A popup window will appear.
1. In the popup window, provide a name for the export file, e.g., `endpoints_export.csv`.
1. Press the `Export` button to download the CSV file to your computer.

The exported CSV file will contain the following columns:

- ID
- Name
- Role
- Element
- Identifier
- Control Element
- Control Identifier
- Transport Type
- Other specific columns related to the transport type

## Step 3: Export existing virtual signal groups

Similar to the endpoints, we will now export the existing virtual signal groups to a CSV file.

1. Navigate to the `Virtual Signal Groups` tab in the `Virtual Signal Groups` app.
1. Click the `Export` button in the header bar. A popup window will appear.
1. In the popup window, provide a name for the export file, e.g., `virtual_signal_groups_export.csv`.
1. Press the `Export` button to download the CSV file to your computer.

The exported CSV file will contain the following columns:

- ID
- Name
- Description
- Role
- Endpoints on different levels (one column per level)

## Step 4: Import new endpoints

In this step, you will use the CSV file format to create new endpoints for the Generic Matrix element.  
The CSV import allows you to quickly add multiple endpoints at once, rather than creating them manually.  

1. Open the `endpoints_export.csv` file that you exported in [step 2](#step-2-export-existing-endpoints).
1. Delete all rows except the header row. The file should now look like this:

    ```csv
    ID;Name;Role;Element;Identifier;Control Element;Control Identifier;Transport Type;...
    ```

1. To create a new source endpoint for input 1 of the Generic Matrix element, add the following line to the CSV file:

    ```csv
    ;Matrix Input 1;Source;Matrix;1;;;SDI;;;
    ```

    The ID column is intentionally left empty, as it will be automatically assigned during the import.
    To update an existing endpoint, you would need to provide the ID of that endpoint.

    The above line will create a new source endpoint named `Matrix Input 1`, linked to row key `1` of the inputs table of element `Matrix`, using `SDI` as transport type.

1. Similarly, to create a new destination endpoint for output 1, add the following line to the CSV file.
This time we will use `Destination` as role and link it to row key `1` of the outputs table of the element.

    ```csv
    ;Matrix Output 1;Destination;Matrix;1;;;SDI;;;
    ```

    More lines can be added to create more endpoints as needed.

1. Save the CSV file after making the changes.

    The file should now look like this:

    ```csv
    ID;Name;Role;Element;Identifier;Control Element;Control Identifier;Transport Type;TSoIP-Source IP;TSoIP-Multicast IP;TSoIP-Port
    ;Matrix Input 1;Source;Matrix;1;;;SDI;;;
    ;Matrix Output 1;Destination;Matrix;1;;;SDI;;;
    ```

1. The file is now ready to be imported. To do so:
    1. Go back to the `Endpoints` tab in the `Virtual Signal Groups` app.
    1. Click the `Import` button in the header bar. A popup window will appear.
    1. Upload the modified CSV file by clicking the `Upload` button and selecting the file from your computer.
    1. Press the `Import` button to start the import process. The new endpoints should now appear in the list.

> [!NOTE]
> The CSV import can be used to create new endpoints as well as to update existing ones.
> Deleting endpoints is currently not supported through the CSV import.

## Step 5: Import new virtual signal groups

After adding the endpoints, the next step is to define and import the virtual signal groups (VSGs).
A VSG groups one or more endpoints together across different levels (e.g., video, audio, data), and is typically used to represent a logical signal flow in your system.

In this tutorial we will create a VSG for each endpoint that we created in the previous step.
The endpoints will be assigned on the `Video` level, but this can be adjusted based on your needs.
Make sure to use the same level for sources and destinations.

1. Open the `virtual_signal_groups_export.csv` file that you exported in [step 3](#step-3-export-existing-virtual-signal-groups).
1. Delete all rows except the header row. The file should now look like this:

    ```csv
    ID;Name;Description;Role;Endpoint (Video);Endpoint (Audio1);Endpoint (Audio2);Endpoint (Data)
    ```

1. We will now create a VSG for the source endpoint `Matrix Input 1` that we created in the previous step.

    To do this, add the following line to the CSV file:

    ```csv
    ;Matrix Input 1;;Source;Matrix Input 1;;;
    ```

    As you can see, the ID is again left empty because we want to create a new VSG. To update an existing VSG, you would need to provide the ID of that VSG.
    Make sure the `Role` column has `Source` as value.
    The endpoint is assigned on the Video level by placing the endpoint name in the corresponding column.
    Levels that are not used can be left empty.

1. In a similar way, to create a VSG for the destination endpoint `Matrix Output 1`, add the following line to the CSV file:

    ```csv
    ;Matrix Output 1;;Destination;Matrix Output 1;;;
    ```

    This time we use `Destination` as role and assign the endpoint again on the `Video` level.
    More lines can be added to create more VSGs as needed.

1. Save the CSV file after making the changes.

    The file should now look like this:

    ```csv
    ID;Name;Description;Role;Endpoint (Video);Endpoint (Audio1);Endpoint (Audio2);Endpoint (Data)
    ;Matrix Input 1;;Source;Matrix Input 1;;;
    ;Matrix Output 1;;Destination;Matrix Output 1;;;
    ```

1. The file is now ready to be imported. To do so:
    1. Go back to the `Virtual Signal Groups` tab in the `Virtual Signal Groups` app.
    1. Click the `Import` button in the header bar. A popup window will appear.
    1. Upload the modified CSV file by clicking the `Upload` button and selecting the file from your computer.
    1. Press the `Import` button to start the import process. The new virtual signal groups should appear in the list.

> [!NOTE]
> The CSV import can be used to create new virtual signal groups as well as to update existing ones.
> Deleting virtual signal groups is currently not supported through the CSV import.

## Up next

When you have finished this tutorial, you can continue with creating a [connection handler script](xref:Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript).
This script will use the endpoints and virtual signal groups that you created in this tutorial to visualize and manage connections.
