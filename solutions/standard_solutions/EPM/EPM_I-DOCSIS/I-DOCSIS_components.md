---
uid: I-DOCSIS_components
keywords: I-DOCSIS components
---

# EPM Integrated DOCSIS components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (CMTS and CCAP devices, APIs, etc.). For example, we use collector connectors to poll a CMTS device and obtain the necessary information needed to present DOCSIS data throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for Integrated DOCSIS](xref:I-DOCSIS_supported_technologies).

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

These are the required EPM connectors, which are included in the EPM Solution package:

- [Skyline EPM Platform](https://catalog.dataminer.services/details/f1dc139b-8da7-4607-9ffb-65087610b3ff)
- [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/details/b175a610-19d0-4281-99cc-359e09a7e859)
- [Skyline EPM Platform DOCSIS WM](https://catalog.dataminer.services/details/302ebc88-3c4b-42e2-bca3-058cc7d015c1)

## automation scripts

The Integrated DOCSIS EPM Solution uses the following automation scripts:

- **EpmConfig**: Sets the front-end configuration in the DMS to improve topology app performance.
- **EPM_I_DOCSIS_EpmFeToEpmBe**: Operates within the messaging system domain taking care of simple notifications between the EPM front-end element and the back-end elements.
- **EPM_I_DOCSIS_EpmBeToCcapPair**: Operates within the messaging system domain taking care of simple notifications between EPM back-end elements and CCAP collectors.
- **EPM_I_DOCSIS_AddNewCcapCmPair**: Allows the user to create a CCAP/CM pair from the EPM UI.<!-- RN 36459 -->
- **EPM_I_DOCSIS_AddSpectrumCcap**: Streamlines the provisioning of spectrum monitoring elements for CCAP elements.<!-- RN 42366 -->
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_DATA**: Used to retrieve all CM-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_DS_QAM_DATA**: Used to retrieve all DS QAM Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_US_QAM_DATA**: Used to retrieve all US QAM Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDM_DATA**: Used to retrieve all OFDM Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDMA_DATA**: Used to retrieve all OFDMA Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_DS_QAM_DATA**: Used to retrieve all CM DS QAM Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_US_QAM_DATA**: Used to retrieve all CM US QAM Channel-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_PASSIVE_DATA**: Used to retrieve all Passive relation-related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDM_DATA**: Used to retrieve all OFDM Channel–related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDMA_DATA**: Used to retrieve all OFDMA Channel–related data in dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_UNREACHABLE_CM**: Used to retrieve all CMs unreachable via ping but reported as operational by the CMTS.
- **EPM_I_DOCSIS_SetThresholdsTableToCollectors**: Used to update all collectors of any channel threshold changes made on the front end.

## Dashboards

The Integrated DOCSIS EPM Solution includes the following dashboards:

- AMPLIFIER/01. CM OVERVIEW
- AMPLIFIER/02. OFFLINE CM OVERVIEW
- AMPLIFIER/03. CPE MAP
- CM/01. CM OVERVIEW
- CM/02. CM DS QAM CHANNELS
- CM/03. CM US QAM CHANNELS
- CM/04. CM OFDM CHANNELS
- CM/05. CM OFDMA CHANNELS
- FIBER NODE UTILIZATION/DS FN Peak Utilization
- FIBER NODE UTILIZATION/US FN Peak Utilization
- INOC/CMs NOT AVAILABLE
- NODE/01. CM OVERVIEW
- NODE/02. OFFLINE CM OVERVIEW
- NODE/03. CPE MAP
- NODE SEGMENT/01. CM OVERVIEW
- NODE SEGMENT/02. OFFLINE CM OVERVIEW
- NODE SEGMENT/03. DS QAM CHANNELS
- NODE SEGMENT/04. US QAM CHANNELS
- NODE SEGMENT/05. OFDM CHANNELS
- NODE SEGMENT/06. OFDMA CHANNELS
- NODE SEGMENT/07. CPE MAP
- TAP/01. CM OVERVIEW
- TAP/02. OFFLINE CM OVERVIEW
- TAP/03. CPE MAP
- Top 50/DS FN Peak Utilization
- Top 50/US FN Peak Utilization
- SERVICE GROUP/01. CM OVERVIEW
- SERVICE GROUP/02. OFFLINE CM OVERVIEW
- SERVICE GROUP/03. DS QAM CHANNELS
- SERVICE GROUP/04. US QAM CHANNELS
- SERVICE GROUP/05. OFDM CHANNELS
- SERVICE GROUP/06. OFDMA CHANNELS
- US FN BREACH REPORT (OFDMA)
- US FN BREACH REPORT (SC-QAM)

> [!NOTE]
> To use the Top 50 dashboards, Data Aggregator must be installed and configured with certain queries. Please reach out to your Skyline representative to set this up if you would like to use those dashboards.

## Visuals

The Integrated DOCSIS EPM Solution includes the following visual overviews:

- Network
- Market
- Hub
- CCAP Core
- Service Group [Fiber Node]
- Node Segment
- Node
- Amplifier
- Tap
- Cable Modem
