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

## Correlation rules

The I-DOCSIS EPM Solution uses the following Correlation rules:

- **EPM BE to WM**: Operates within the messaging system domain taking care of simple notifications between EPM back-end elements and Workflow Managers.
- **WM to EPM BE**: Operates within the messaging system domain taking care of simple notifications between Workflow Managers and EPM back-end elements.
- **EPM BE to EPM FE Passives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM back-end elements and the front-end element.
- **EPM FE to BE Passives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM front-end element and the back-end elements.

## Automation scripts

The I-DOCSIS EPM Solution uses the following Automation scripts:

- **CCAP to EPM FE**: Operates within the messaging system domain taking care of simple notifications between CCAP elements and the EPM engine.
- **EPM FE to EPM BE**: Operates within the messaging system domain taking care of simple notifications between the EPM front-end element and the back-end elements.
- **EPM BE to CCAP Pair**: Operates within the messaging system domain taking care of simple notifications between EPM back-end elements and CCAP collectors.
- **EPM BE to WM**: Operates within the messaging system domain taking care of simple notifications between EPM back-end elements and Workflow Managers.
- **WM to BE**: Operates within the messaging system domain taking care of simple notifications between Workflow Managers and EPM back-end elements.
- **EPM BE to FE Passives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM back-end elements and the front-end element.
- **EPM FE to BE Passives**: Operates within the messaging system domain taking care of simple notifications related to the subscriber’s integration between the EPM front-end element and the back-end elements.

## Dashboards

The I-DOCSIS EPM Solution includes the following dashboards:

- I-DOCSIS CCAP
- I-DOCSIS Channel Utilization
- I-DOCSIS Network
- I-DOCSIS Service Group [Fiber Node]
- I-DOCSIS Service Group [Fiber Node] - CM DS SNR OOS
- I-DOCSIS Customer Diagnosis tool - CM Info
- I-DOCSIS Customer Diagnosis Tool - Network Performance
- I-DOCSIS Global System Counts
- I-DOCSIS Cable Modem

## Visuals

The I-DOCSIS EPM Solution includes the following visual overviews:

- Network
- CCAP Core
- Service Group [Fiber Node]
