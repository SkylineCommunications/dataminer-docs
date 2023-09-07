---
uid: I-DOCSIS_Create_CCAP_CM_pair
---

# Creating a new CCAP/CM pair

To create CCAP/CM pairs, you can either start from scratch, or start from a CSV file.

## Creating a new CCAP/CM pair from scratch

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

   This will open a wizard with several steps.

1. In the **General** step:

   1. Define the element name.

      > [!NOTE]
      > The name of the collector element will consist of the defined element name with the suffix "_COLLECTOR".

   1. Select one of the back-end DMAs for the CCAP.

   1. Select one of the back-end DMAs for the collector.

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

## Creating a new CCAP/CM pair from a CSV file

<!-- RN 37262 -->

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

   This will open a wizard with several steps.

1. Below the **Run automation** script text, enter the path of the CSV file.

   > [!NOTE]
   > The CSV file has to have the following structure: ElementName, Be_DMA, Collector_DMA, Protocol, IpAddress, CommunityString, Network, Market, Hub, SystemUser, SystemPass.

1. Click *Run automation*.

The elements will be created with the specifications in the CSV file of each row.

Here is an example of the CSV file with the mandatory headers and the content of each row.

| ElementName | Be_DMA               | Collector_DMA        | Protocol                  | IpAddress    | CommunityString | Network | Market          | Hub           | SystemUser | SystemPass |
|-------------|----------------------|----------------------|---------------------------|--------------|-----------------|---------|-----------------|---------------|------------|------------|
| filename1   | EPM-BE-PUE-LAB-DMA03 | EPM-BE-PUE-LAB-DMA03 | CISCO CMTS CCAP Platform  | 127.0.0.100  | AnyText          | BAJIO   | AGUASCALIENTES | CTC-AGS       | us1        | Pass1      |
| filename2   | EPM-BE-CLN-LAB-DMA04 | EPM-BE-PUE-LAB-DMA03 | Arris E6000 CCAP Platform | 127.0.0.101  | AnyText          | BAJIO   | AGUASCALIENTES | CTC-AGS       | us2        | Pass2      |

> [!NOTE]
> These are the only values accepted for the **Protocol** column: CISCO CMTS CCAP Platform, Arris E6000 CCAP Platform, Casa Systems CCAP Platform, CISCO CBR-8 CCAP Platform, Huawei 5688-5800 CCAP Platform.
