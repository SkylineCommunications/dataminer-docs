---
uid: I-DOCSIS_components
---

# EPM I-DOCSIS components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (CMTS and CCAP devices, APIs, etc.). For example, we use collector connectors to poll a CMTS device and obtain the necessary information needed to present DOCSIS data throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for I-DOCSIS](xref:I-DOCSIS_supported_technologies).

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

These are the required EPM connectors, which are included in the EPM Solution package:

- [Skyline EPM Platform](https://catalog.dataminer.services/result/driver/7207)
- [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209)
- [Skyline EPM Platform DOCSIS WM](https://catalog.dataminer.services/result/driver/7212)

> [!NOTE]
> In versions prior to I-DOCSIS 6.1.7<!-- RN 36326 -->, Correlation rules and Automation scripts are used to enable communication between the back end and the Workflow Manager. However, starting from I-DOCSIS 6.1.7, inter-app communication is used for this instead, making those Correlation rules and Automation scripts unnecessary. This change in communication methodology should be taken into consideration when developing software for recent I-DOCSIS versions.

## Automation scripts

The I-DOCSIS EPM Solution uses the following Automation scripts:

- **EPM_I_DOCSIS_CCapToEpmFe**: Operates within the messaging system domain taking care of simple notifications between CCAP elements and the EPM engine.
- **EPM_I_DOCSIS_EpmFeToEpmBe**: Operates within the messaging system domain taking care of simple notifications between the EPM front-end element and the back-end elements.
- **EPM_I_DOCSIS_EpmBeToCcapPair**: Operates within the messaging system domain taking care of simple notifications between EPM back-end elements and CCAP collectors.
- **EPM_I_DOCSIS_EPMBeToFePassives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM back-end elements and the front-end element.
- **EPM_I_DOCSIS_EPMFeToBePassives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM front-end element and the back-end elements.
- **EPM_I_DOCSIS_AddNewCcapCmPair**: Allows the user to create a CCAP/CM pair from the EPM UI.
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_DATA**: Used to retrieve all CM-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_DS_QAM_DATA**: Used to retrieve all DS QAM Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_US_QAM_DATA**: Used to retrieve all US QAM Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDM_DATA**: Used to retrieve all OFDM Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_OFDMA_DATA**: Used to retrieve all OFDMA Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_DS_QAM_DATA**: Used to retrieve all CM DS QAM Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_CM_US_QAM_DATA**: Used to retrieve all CM US QAM Channel-related data in Dashboards using GQI.
- **EPM_I_DOCSIS_GQI_GET_ALL_PASSIVE_DATA**: Used to retrieve all Passive relation-related data in Dashboards using GQI.

## Dashboards

The I-DOCSIS EPM Solution includes the following dashboards:

- AMPLIFIER/01. CM OVERVIEW
- AMPLIFIER/02. OFFLINE CM OVERVIEW
- AMPLIFIER/03. CPE MAP
- CM/01. CM OVERVIEW
- CM/02. CM DS QAM CHANNELS
- CM/03. CM US QAM CHANNELS
- CM/04. CM OFDM CHANNELS
- CM/05. CM OFDMA CHANNELS
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
- SERVICE GROUP/01. CM OVERVIEW
- SERVICE GROUP/02. OFFLINE CM OVERVIEW
- SERVICE GROUP/03. DS QAM CHANNELS
- SERVICE GROUP/04. US QAM CHANNELS
- SERVICE GROUP/05. OFDM CHANNELS
- SERVICE GROUP/06. OFDMA CHANNELS

## Visuals

The I-DOCSIS EPM Solution includes the following visual overviews:

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
