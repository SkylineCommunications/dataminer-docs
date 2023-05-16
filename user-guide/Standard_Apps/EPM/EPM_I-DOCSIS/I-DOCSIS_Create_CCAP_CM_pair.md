---
uid: I-DOCSIS_Create_CCAP_CM_pair
---

# Creating a new CCAP/CM pair

To create a new CCAP/CM pair:

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

   This will open a wizard with several steps.

1. In the **General** step:

   1. Define the element name.

      > [!NOTE]
      > The name of the collector element will consist of the defined element name with the suffix "_COLLECTOR".

   1. Select one of the back-end DMAs.

1. In the **CCAP Details** step:

   1. Select the desired CCAP protocol.

   1. Select the desired protocol version. We recommend the production version.

   1. Enter the IP address.

   1. Enter the community string that will be used to poll the device (SNMP).

1. In the **View Details** step, select the location where the CCAP/CM pair will be added in the EPM view structure.

1. In the **Interface Setting** step, define the username and password of an account that can access the **front-end DMA**.

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

> [!NOTE]
> It may take some time before the elements are created. The larger the cluster, the longer it will take to create the elements.
