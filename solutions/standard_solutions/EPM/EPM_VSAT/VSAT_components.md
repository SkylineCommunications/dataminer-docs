---
uid: VSAT_components
---

# EPM VSAT components

## Collector connectors

Collector connectors interface with the main data sources (iDirect Evolution, iDirect Dialog, SES Skala, Intelsat Flex, etc.). For example, we use collector connectors to poll an iDirect Evolution NMS and obtain the necessary information needed to present remote information data throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

The following connectors are currently compatible with EPM:

- [iDirect Evolution Platform VSAT](https://catalog.dataminer.services/details/67205de6-f339-43ea-9f1f-511c99d66337)
- [Newtec Dialog Platform VSAT](https://catalog.dataminer.services/details/cd6febc7-9b01-4a5d-bf28-9346d873da86)

The following connectors will become compatible in the future:

- [Hughes Pulse Platform VSAT](https://catalog.dataminer.services/details/e1efe456-e153-4ba2-bbb6-207408b6b493)
- [Intelsat Flex Platform VSAT](https://catalog.dataminer.services/details/c99eec97-7a93-47ae-acef-1c3ceef4face)
- [SES S.A. Skala](https://catalog.dataminer.services/details/177a52b3-2a9c-4915-a03f-77decc2aa34b)

## EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

The connectors ship with the EPM Solution package.

- [Skyline EPM Platform VSAT GEO](https://catalog.dataminer.services/details/11f62997-a866-4c02-9f64-03dcfcac96ed)

## Peripheral connectors

Peripherals are optional but not required as part of a standard deployment.

### Sun Outage

The *Generic Sun Outage* connector can predict sun outages and the impact these may have on the signal and tracking of a VSAT terminal. DataMiner is capable of detecting sun outage events and offering the current state details of each remote in the VSAT system. Sun outages usually occur twice a year during the equinox in March and September.

The *DSM SO* connector helps provide a way for users to map different parameters across various technologies against the required input parameters needed for import to the Sun Outage connector. Though this is not required, it does help automate and facilitate a hands-free implementation within the solution.

The connectors ship with the EPM Solution package.

- [Generic Sun Outage](https://catalog.dataminer.services/details/ada6ebaf-26a5-45d0-90d1-1025b1adda15)
- [Skyline EPM Platform VSAT DSM SO](https://catalog.dataminer.services/details/67205de6-f339-43ea-9f1f-511c99d66337)

> [!TIP]
> For more information on sun outage events, see [VSAT Sun Outages & Sun Fade Information](https://satoms.com/vsat-sun-outages/).

### Weather

DataMiner can be integrated with many weather forecast services as it considers this variable a key factor capable of degrading and temporarily interrupting the signal delivery via VSAT. The connector included in the EPM Solution package is capable of processing weather requests in bulk, ad hoc, and/or manually. It can be used to integrate with a variety of solutions depending on user requirements, such as Correlation, Remote & Weather Alarms, etc.

The connectors ship with the EPM Solution package.

- [Skyline Universal Weather](https://catalog.dataminer.services/details/6664b1b8-6975-4990-bb97-6df0b0239e2e)

## Automation scripts

The VSAT EPM Solution uses the Automation scripts detailed below.

### EPM GEO BE Handler

This script is in charge of communicating to the collector that the ID assignment files from the VSAT Platform Manager are ready for ingestion after the EPM back ends are done processing and setting the topology data in their respective tables.

This Automation script is dependent on the following connectors:

- [Collector(s)](#collector-connectors) that triggered the initial *EPM Message Handler* script.
- [Skyline EPM Platform VSAT GEO](#epm-connectors) handling the aggregation of KPIs from different collector elements.

### EPM GEO FE to BE

This script operates within the messaging system domain taking care of communication about the collector and the entity the processed data originated from, between EPM front-end elements and back-end elements.

This Automation script is dependent on the following connectors:

- [Collector(s)](#collector-connectors) that triggered the initial *EPM Message Handler* script.
- [Skyline EPM Platform VSAT GEO](#epm-connectors) handling the aggregation of KPIs from different collector elements.

### EPM Message Handler

This script is in charge of handling EPM messages. It is triggered from the collector after the ID request files for the entities are exported. It tells the EPM front end to ingest the request files.

This Automation script is dependent on the following connectors:

- [Collector(s)](#collector-connectors) that triggered the initial *EPM Message Handler* script.

### SkylineCommunications_SLC-AS-EPM_VSAT_Subscription_Manager

This script is in charge of centralizing the information of the subscription tables of different peripherals across all the DMAs. It receives the request from the elements to update/change a subscription table, it stores the updated information, and it sends it back to all elements to keep them updated with the latest changes.

This Automation script is dependent on the following connector:

- [Skyline EPM Platform VSAT DSM SO](#sun-outage), which triggers the initial script.
