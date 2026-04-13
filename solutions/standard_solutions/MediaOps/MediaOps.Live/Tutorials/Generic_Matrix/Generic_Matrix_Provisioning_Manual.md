---
uid: Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual
---

# Manually provisioning endpoints and virtual signal groups for a Generic Matrix element

In this tutorial, you will learn how to provision endpoints and virtual signal groups (VSGs) for the **Generic Matrix** connector. These endpoints and VSGs will be used to visualize and manage the connections in the MediaOps Live solution.

There are three ways to create endpoints and VSGs:

- Manually, using the Virtual Signal Groups low-code app, as explained in the current tutorial.
- [Through an automation script, using the MediaOps Live API](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code).
- [Using the CSV import functionality in the Virtual Signal Groups app](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import).

Expected duration: 25 minutes

> [!NOTE]
> The content and screenshots of this tutorial were created using DataMiner 10.6.4 and MediaOps Live 1.0.0.

## Prerequisites

The DataMiner System you use for this tutorial must meet the following prerequisites:

- Range 1.0.1.x of the [Generic Matrix](https://catalog.dataminer.services/details/920cf3a9-ab1b-4c4c-8d67-bbffa1ca396a) connector is installed, and an element has been created using this connector.
- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) is installed.

## Overview

- [Step 1: Create level and transport type](#step-1-create-level-and-transport-type)
- [Step 2: Create endpoints](#step-2-create-endpoints)
- [Step 3: Create virtual signal groups](#step-3-create-virtual-signal-groups)

## Step 1: Create level and transport type

First, you need to create a level and transport type in MediaOps Live. In this tutorial, the *Video* level and *SDI* transport type will be used. If these already exist in your system, you can skip this step.

1. Open the Virtual Signal Groups app.

   ![The Virtual Signal Groups app on the DataMiner landing page](~/solutions/images/MO_Virtual_Signal_Groups_app_on_landing_page.png)

1. Go to the *Levels* page, and click the *Transport Types* button in the header bar.

   ![The Transport Types button in the Virtual Signal Groups app](~/solutions/images/MO_Transport_Types_button.png)

1. If the `SDI` transport type does not exist yet, create it by clicking the *New* button and specifying this transport type name.

   ![Pop-up window to create new transport type](~/solutions/images/MO_New_transport_type.png)

1. Back on the *Levels* page, if the `Video` level does not exist yet, create it by clicking the *New* button and specifying the following information:

   - *Name*: `Video`
   - *Number*: `0` (or the next available number)
   - *Transport Type*: `SDI`

   ![Pop-up window to create new level](~/solutions/images/MO_New_level_SDI.png)

## Step 2: Create endpoints

Next, you need to create endpoints for the inputs and outputs of the Generic Matrix connector.

1. In the Virtual Signal Groups app, go to the *Endpoints* page.

1. In the header bar, click the *New* button to create a new endpoint.

1. Fill in the following details in the pop-up window, and then click *Save*:

   - *Name*: `Matrix Input 1` (needs to be unique)
   - *Role*: `Source`
   - *Element*: Select the Generic Matrix element from the dropdown
   - *Identifier*: `1` (row key in the inputs or outputs table of the Generic Matrix connector). This identifier will be used later to link the endpoint back to the correct input or output in the element.
   - *Control Element*: Leave empty.
   - *Control Element Identifier*: Leave empty.
   - *Transport Type*: `SDI`

   ![Pop-up window to create new endpoint, with the necessary details filled in](~/solutions/images/MO_New_Endpoint_Generic_Matrix.png)

   In the *Endpoints* table, an endpoint should now be added that is linked to row key 1 of the inputs table of the Generic Matrix connector.

1. Repeat these steps to create more endpoints for inputs and outputs as needed. Make sure to also create at least one destination endpoint (with *Role* = `Destination`).

## Step 3: Create virtual signal groups

Next, virtual signal groups (VSGs) need to be created. These are logical groupings that allow the creation of connections between multiple endpoints at the same time. In this case, **a VSG must be created for each endpoint** created in the previous step. The endpoints will be assigned to the VSG on the *Video* level, but you can adjust this based on your needs.

1. In the Virtual Signal Groups app, go to the *Virtual Signal Groups* page.

1. In the header bar, click the *New* button to create a new VSG.

1. Fill in the following details in the pop-up window, and then click *Save*:

   - *Name*: `Matrix Input 1` (needs to be unique)
   - *Description*: A meaningful description (optional).
   - *Role*: `Source`

   ![Pop-up window to create new VSG, with the necessary details filled in](~/solutions/images/MO_New_VSG_Matrix_Input_1.png)

   In the table, a record will be added for the VSG.

1. Assign an endpoint to the VSG:

   1. Click the edit endpoints icon in the row of the VSG you have just created.

      ![Icon to edit endpoints in the Virtual Signal Groups table](~/solutions/images/MO_Edit_endpoints_icon.png)

      A side panel will open.

   1. In the table at the top, select the *Video* level.

   1. In the table at the bottom, select the endpoint you created in the previous step (e.g., *Matrix Input 1*).

   1. Click *Assign* to assign the endpoint to the VSG.

      ![Video level and Matrix Input 1 selected in side panel to assign endpoint](~/solutions/images/MO_Assign_endpoint_to_VSG.png)

      The endpoint will now be assigned on the *Video* level.

1. Repeat these steps to create more VSGs for inputs and outputs as needed, using the role *Source* for input VSGs and the role *Destination* for output VSGs.

## Up next

Now that you have created endpoints and VSGs, you can create a connection handler script by following the tutorial [Creating a connection handler script for a Generic Matrix element](xref:Tutorial_MediaOpsLive_GenericMatrix_ConnectionHandlerScript). Once that is done, you will be able to create connections between the encoders and decoders using the Control Surface app.

Alternatively, you can also explore how to create endpoints and virtual signal groups in a different way, as in many cases there will be too many to do this manually. You can either [automate this process using an automation script](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code) or [create endpoints and VSGs in bulk via CSV import](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import).
