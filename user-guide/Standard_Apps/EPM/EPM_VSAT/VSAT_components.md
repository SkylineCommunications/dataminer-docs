---
uid: VSAT_components
---

# EPM VSAT components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (iDirect Evolution, iDirect Dialog, SES Skala, Intelsat Flex, etc.). For example, we use collector connectors to poll an iDirect Evolution NMS and obtain the necessary information needed to present remote information data throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for VSAT](xref:VSAT_supported_technologies).

#### iDirect Evolution

This is the collector connector required for the iDirect Evolution Platform. This collector was primarily tested on version 4.1 or later.

For more information, see [Verizon iDirect Evolution Platform Collector](https://catalog.dataminer.services/result/driver/5827).

#### iDirect Dialog

This is the collector connector required for the iDirect (formerly Newtec) Dialog Platform with Time Series Database (TSDB) integration.

For more information, see [Newtec Dialog Platform VSAT](https://catalog.dataminer.services/result/driver/7342).

#### CMDB

This is the collector connector that helps form relationships between various collectors and technology that are traditionally unrelated. It can provide additional business details of the customer to enhance the metrics and KPIs needed that are not obtained by the NMS collectors alone.

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

These are the required EPM connectors, which are included in the EPM Solution package:

- [Skyline EPM Platform](https://catalog.dataminer.services/result/driver/7207)
- [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209)
- [Skyline EPM Platform DOCSIS WM](https://catalog.dataminer.services/result/driver/7212)

## Peripherals

Peripherals are optional but not required as part of a standard deployment.

### Sun outage

DataMiner predicts, detects falls, and offers the current state details of each remote in the VSAT system referring to the sun outage events that might affect the transmission. These events normally occur twice a year when the day arc takes place directly behind the line of sight of a satellite and an earth station.

### Weather

DataMiner has flexibility of integration with any weather forecast service as it considers this variable a key factor capable of degrading and temporarily interrupting the signal delivery via VSAT. Operators receive automated detailed descriptions of the physical and remote falls that were correlated to weather conditions.

### PLM

During planned maintenance (PLM), DataMiner suppresses any diagnostic and platform falls alerts related to the event process. It works in conjunction with SRA modules.

## Correlation rules

The I-DOCSIS EPM Solution uses the following Correlation rules:

- **VERSATON REPORT AUTOMATION**
- **VERSATON SUN OUTAGE AUTOMATION**

## Automation scripts

The I-DOCSIS EPM Solution uses the following Automation scripts:

- **VERSATON REPORT AUTOMATION**
- **VERSATON SUN OUTAGE AUTOMATION**
- **EPM BE MESSAGE HANDLER**
- **EPM FE TO BE**
- **EPM MESSAGE HANDLER**
- 
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

## Visuals

The I-DOCSIS EPM Solution includes the following visual overviews:

- Network
- CCAP Core
- Service Group [Fiber Node]
