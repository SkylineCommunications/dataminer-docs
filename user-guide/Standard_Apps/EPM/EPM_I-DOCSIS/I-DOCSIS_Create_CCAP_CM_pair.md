---
uid: I-DOCSIS_Create_CCAP_CM_pair
---

# Creating a new CCAP/CM pair

To create CCAP/CM pairs, you can either create a single CCAP/CM pair, or create elements in bulk from a CSV file.

## Creating a single CCAP/CM pair

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

   This will open a pop-up window.

1. Click *Create single*.

1. In the **General** step:

   1. Define the element name (mandatory field).

      > [!NOTE]
      > The name of the collector element will consist of the defined element name with the suffix "_COLLECTOR".

   1. Select the host for the CCAP.

   1. Select the host for the collector.

1. In the **CCAP Details** step:

   1. Select the desired CCAP protocol.

   1. Select the desired protocol version. We recommend the production version.

   1. Enter the IP address (mandatory field).

   1. Enter the get community string that will be used by the CCAP to poll the device (SNMP).

   1. Enter the set community string that will be used by the CCAP to set information in the device (SNMP).

   1. Enter the get community string for the collector.

   1. Enter the set community string  for the collector.

   1. Enter the user for this device.

   1. Enter the password for this device.

1. In the **View Details** step, select the location where the CCAP/CM pair will be added in the EPM view structure.

1. Click *Create*.

The elements will be created with the following specifications:

- **CCAP:**

  - **Element name**: The defined element name.
  - **Protocol**: The selected protocol.
  - **Protocol version**: The selected version.
  - **IP address**: The defined IP address.
  - **Alarm template**: The default alarm template.
  - **Trend template**: The default trend template.
  - **Get community string CCAP**: The defined get community string for the CCAP.
  - **Set community string CCAP**: The defined set community string for the CCAP.
  - **Entity export directory**: The same directory as is set in the back end of the host.
  - **Entity import directory**: The same directory as is set in the back end of the host.
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
  - **Get community string Collector**: The defined get community string for the collector.
  - **Set community string Collector**: The defined set community string for the collector.
  - **Entity import directory**: The same directory as is set in the back end of the host.
  - **Entity import directory type**: Remote.
  - **System username**: The system username.
  - **System password**: The system password.

> [!NOTE]
> It may take some time before the elements are created. The larger the cluster, the longer it will take to create the elements.

## Creating CCAP/CM pairs in bulk from a CSV file

<!-- RN 37262 -->

1. In DataMiner Cube, go to apps > Automation.

1. In the pane on the left, select the script *EPM_I_DOCSIS_AddNewCcapCmPair*.

1. In the lower right corner, click *Execute*.

   This will open a pop-up window.

1. Click *Create bulk*.

1. Below the **Create Bulk** script text, enter the path of the CSV file.

   > [!NOTE]
   >
   > - The path has to be present in the host were the DMA is located.
   > - The CSV file has to have the following structure: ElementName, Ccap_DMA, Collector_DMA, Protocol, IpAddress, GetCommunityString, SetCommunityString,GetCommunityStringColl, SetCommunityStringColl, Network, Market, Hub, SystemUser, SystemPass.

1. Click *Create Bulk*.

The elements will be created with the specifications in the CSV file of each row.

Here is an example of the CSV file with the mandatory headers and the content of each row.

| ElementName | Ccap_DMA    | Collector_DMA | Protocol                  | IpAddress    | GetCommunityString | SetCommunityString | GetCommunityStringColl | SetCommunityStringColl | Network         | Market          | Hub            | SystemUser | SystemPass |
|-------------|-------------|----------------|---------------------------|--------------|---------------------|---------------------|------------------------|------------------------|-----------------|------------------|-----------------|-------------|------------|
| filename1   | SLC-H62-G05 | SLC-H62-G05    | CISCO CBR-8 CCAP Platform | 127.0.0.100  | getPublic           | setprivate          | collectorget           | collectorset           | GLOBAL NETWORK  | EAST MARKET 01   | EAST HUB 01     | US1         | 123        |
| filename2   | SLC-H62-G05 | SLC-H62-G05    | CISCO CBR-8 CCAP Platform | 127.0.0.101  | getprivate          | setPublic           | collectorget           | collectorset           | GLOBAL NETWORK  | EAST MARKET 01   | EAST HUB 01     | US2         | 123        |

> [!NOTE]
>
> - For the **Protocol** column, only the following values will be accepted: CISCO CMTS CCAP Platform, Arris E6000 CCAP Platform, Casa Systems CCAP Platform, CISCO CBR-8 CCAP Platform, Huawei 5688-5800 CCAP Platform.
> - Click the *Cancel* button in any window to close the Automation script at anytime.
