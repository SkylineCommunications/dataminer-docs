---
uid: Tutorial_MediaOpsLive_Tutorial_IPMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual
---

# Manually provisioning endpoints and virtual signal groups for an IP Matrix element

In this tutorial, you will learn how to provision endpoints and virtual signal groups (VSGs) for an **IP Matrix** solution. These endpoints and VSGs will be used to visualize and manage the connections in the MediaOps Live solution.

The mentioned IP Matrix solution is a setup where a set of devices generate streams with a fixed multicast (TSoIP). These multicast IPs are then routed to a set of receivers by dynamically configuring the multicast IPs on the receivers.

```mermaid
graph LR
    subgraph Encoder x
    E1[Role: Source<br />Multicast: 239.1.x.1]
    end

    subgraph Decoder x
    D1[Role: Destination]
    end

    E1 -. TSoIP multicast .-> D1
```

Expected duration: 30 minutes

> [!TIP]
> In this tutorial, the endpoints and virtual signal groups will be created manually using the Virtual Signal Groups app. Other ways to create endpoints and VSGs are [through an automation script using the MediaOps Live API](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code) or by [using the CSV import functionality](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import).

> [!NOTE]
> The content and screenshots of this tutorial were created using DataMiner 10.6.4 and MediaOps Live 1.0.0.

## Prerequisites

A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), where [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) is installed.

## Overview

- [Step 1: Deploy the IP matrix elements](#step-1-deploy-the-ip-matrix-elements)
- [Step 2: Create level and transport type](#step-2-create-level-and-transport-type)
- [Step 3: Create endpoints](#step-3-create-endpoints)
- [Step 4: Create virtual signal groups](#step-4-create-virtual-signal-groups)

## Step 1: Deploy the IP matrix elements

This tutorial will make use of the [Generic Dynamic Table](https://catalog.dataminer.services/details/73b79bb5-0fb2-41ee-ae5f-c6b6020f909e) connector to simulate the IP matrix functionality. To deploy this connector and create the necessary elements:

1. Look up the package [Tutorial - SLC-AS-MediaOps.LIVE - IP Matrix](https://catalog.dataminer.services/details/02f6e3be-4244-4eee-97da-6919958377ef) in the Catalog.

1. Deploy the latest version of the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

This will automatically install the connector and create the following elements in your system:

- Four elements representing encoders (sources):

  - Name: `Encoder x` (x: 1 ... 4).
  - Each element has one row (*IP Out*) with multicast IP 239.1.x.1.

- Four elements representing decoders (destinations):

  - Name: `Decoder x` (x: 1 ... 4).
  - Each element has one row (*IP In*). The multicast IP will be configured dynamically.

## Step 2: Create level and transport type

Next, you need to create a level and transport type in MediaOps Live. In this tutorial, the *Video* level and *TSoIP* transport type will be used. If these already exist in your system, you can skip this step.

1. Open the Virtual Signal Groups app.

   ![The Virtual Signal Groups app on the DataMiner landing page](~/solutions/images/MO_Virtual_Signal_Groups_app_on_landing_page.png)

1. Go to the *Levels* page, and click the *Transport Types* button in the header bar.

   ![The Transport Types button in the Virtual Signal Groups app](~/solutions/images/MO_Transport_Types_button.png)

1. If the `TSoIP` transport type does not exist yet, create it by clicking the *New* button and specifying the following information:

   - *Name*: `TSoIP`
   - *Fields*: `Source IP`, `Multicast IP`, and `Port`

   ![Pop-up window to create new transport type, with the correct information specified](~/solutions/images/MO_New_transport_type_TSoIP.png)

1. Back on the *Levels* page, if the `Video` level does not exist yet, create it by clicking the *New* button and specifying the following information:

   - *Name*: `Video`
   - *Number*: `0` (or the next available number)
   - *Transport Type*: `TSoIP`

   ![Pop-up window to create new level](~/solutions/images/MO_New_level_TSoIP.png)

## Step 3: Create endpoints

Next, you need to create endpoints for the inputs and outputs of the encoders and decoders. Each encoder element has one output (IP Out) that will be used as a source endpoint. The endpoint should contain the multicast IP address that is configured in the element. This multicast IP will be used later to configure the destination when creating a connection.

1. In the `Virtual Signal Groups` app, go to the *Endpoints* page.

1. Create a first endpoint for an encoder:

   1. In the header bar, click *New*.

   1. Fill in the following details in the pop-up window:

      - *Name*: `Encoder 1` (needs to be unique)
      - *Role*: `Source`
      - *Element*: Select the `Encoder - 1` element.
      - *Identifier*: Can be left empty as there is only one endpoint for this element.
      - *Control Element*: Leave empty.
      - *Control Element Identifier*: Leave empty.
      - *Transport Type*: `TSoIP`

      As soon as you set the transport type to *TSoIP*, a new section will be displayed in the pop-up window where you can configure additional details.

   1. In the *TSoIP* section, fill in the multicast details:

      - *Source IP*: `10.0.0.1` (can be any valid IP address; not important for this tutorial)
      - *Multicast IP*: `239.1.1.1`. This is the multicast IP configured in the element. The third octet should match the encoder number (1-4).
      - *Port*: `5000` (can be any valid port, not important for this tutorial)

   1. Click *Save* to create the endpoint.

1. Repeat these steps to create endpoints for Encoder 2, Encoder 3, and Encoder 4.

   Now you should see that the source endpoints have been created linked to the correct elements.

   ![The configured source endpoints in the Virtual Signal Groups app](~/solutions/images/MO_Source_endpoints.png)

1. Create a first endpoint for a decoder:

   1. In the header bar, click *New*.

   1. Fill in the following details in the pop-up window:

      - *Name*: `Decoder 1` (needs to be unique)
      - *Role*: `Destination`
      - *Element*: Select the `Decoder 1` element from the dropdown
      - *Identifier*: Can be left empty as there is only one endpoint for this element.
      - *Control Element*: Leave empty.
      - *Control Element Identifier*: Leave empty.
      - *Transport Type*: `TSoIP`

      This time you do not need to provide details for the *TSoIP* section because this is a destination endpoint.

   1. Click *Save* to create the endpoint.

1. Repeat these steps to create endpoints for Decoder 2, Decoder 3, and Decoder 4.

   Now you should see that the destination endpoints have been created linked to the correct elements.

   ![The configured source and destination endpoints in the Virtual Signal Groups app](~/solutions/images/MO_Source_and_destination_endpoints.png)

## Step 4: Create virtual signal groups

Next, virtual signal groups (VSGs) need to be created. These are logical groupings that allow the creation of connections between multiple endpoints at the same time. In this case, **a VSG must be created for each endpoint** created in the previous step. The endpoints will be assigned to the VSG on the *Video* level, but you can adjust this based on your needs.

1. In the Virtual Signal Groups app, go to the *Virtual Signal Groups* page.

1. In the header bar, click the *New* button to create a new VSG.

1. Fill in the following details in the pop-up window, and then click *Save*:

   - *Name*: `Encoder 1` (needs to be unique)
   - *Description*: A meaningful description (optional).
   - *Role*: `Source`

   In the table, a record will be added for the VSG.

1. Assign an endpoint to the VSG:

   1. Click the edit endpoints icon in the row of the VSG you have just created.

      ![Icon to edit endpoints in the Virtual Signal Groups table](~/solutions/images/MO_Edit_endpoints_icon_IP_matrix.png)

      A side panel will open.

   1. In the table at the top, select the *Video* level.

   1. In the table at the bottom, select the endpoint you created in the previous step (e.g., *Encoder 1*).

   1. Click *Assign* to assign the endpoint to the VSG.

      ![Video level and Matrix Input 1 selected in side panel to assign endpoint](~/solutions/images/MO_Assign_endpoint_to_VSG_IP_matrix.png)

      The endpoint will now be assigned on the *Video* level.

1. Repeat these steps to create more VSGs for inputs and outputs as needed, using the role *Source* for the encoders and the role *Destination* for the decoders.

## Up next

Now that you have created endpoints and virtual signal groups for an IP matrix solution, you can create a connection handler script by following the tutorial [Creating a connection handler script for an IP Matrix element](xref:Tutorial_MediaOpsLive_IPMatrix_ConnectionHandlerScript). Once that is done, you will be able to create connections between the encoders and decoders using the Control Surface app.
