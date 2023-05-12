---
uid: I-DOCSIS_Create_CCAP_CM_pair
---

# Creating a new CCAP/CM pair

To create a new CCAP/CM pair:

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

1. UI steps:

   **General**

   1. Define the element name.

      The name of the collector element will consist of the defined element name with the suffix "_COLLECTOR".

   1. Select one of the back-end DMAs.

   **CCAP Details**

   1. Select the desired CCAP protocol.

   1. Select the desired protocol version. We recommend to be the production version.

   1. Enter the IP Address.

   1. Define the desired community string.

   **View Details**

   1. Choose the location where the the CCAP/CM pair will be added according to the EPM view structure.

   **Interface Setting**

   1. Define the Username and password with an account that can access the **FE DMA**.

   1. Click *Create*.


The elements will be created with the following specifications:

- **CCAP:**

  - **Element name**: The defined element name.
  - **Protocol**: The selected protocol.
  - **Protocol version**: The selected version.
  - **IP address**: The defined IP address.
  - **Alarm template**: The default alarm template.
  - **Trend template**: The default trend template.
  - **Get community string**: The defined community string.
  - **Entity export directory**: `\\FE DMA Name\DataMiner EPM\DOCSIS`.
  - **Entity import directory**: `\\FE DMA Name\DataMiner EPM\DOCSIS`.
  - **Entity import directory type**: Remote.
  - **System username**: The system username.
  - **System password**: The system password.

- **Collector:**

  - **Element name**: The defined element name combined with the suffix "_COLLECTOR".
  - **Protocol** The [Generic DOCSIS CM Collector](https://catalog.dataminer.services/result/driver/4207) protocol.
  - **Protocol version**:The production version.
  - **IP address**: 127.0.0.1.
  - **Alarm template**: public.
  - **Trend template**: private.
  - **Get community string**: The defined community string.
  - **Entity import directory**: `\\FE DMA Name\DataMiner EPM\DOCSIS`.
  - **Entity import directory type**: Remote.
  - **System username**: The system username.
  - **System password**: The system password.
