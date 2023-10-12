---
uid: GPON_architecture
---

# EPM GPON architecture

The EPM GPON Solution uses components that extract information directly from the involved devices and from third-party systems (databases, data streams) to calculate and aggregate the overall network status based on the different topology levels:

- [Front-end connector](#front-end-connector): KPI aggregator for the network.
- [Back-end connectors](#back-end-connectors): KPI aggregators in the topology's lower levels.
- [OLT connectors](#olt-connectors): These connectors take care of technology-specific data collection and initial inventory from the OLT perspective.
- [ONT data connector](#ont-data-connector): This connector is responsible for the ONT data reception and analysis. A generic Kafka stream is used to implement these capabilities.
- [System connectors](#system-connectors): These connectors are designed to operate as peripherals within the EPM Solution. For GPON, most of the system connectors are used to include the physical network devices (if available) in the EPM aggregations and logical associations.

![EPM GPON architecture](~/user-guide/images/EPM_GPON_architecture.png)

## Front-end connector

The front-end connector allows the user to access all information from the EPM Solution from a single pane of glass. It is a lightweight connector that only contains the visual structure of the solution. It is optimized for aggregation at the highest level (Network) of the topology.

There is only one front-end element per DataMiner System, and it is aware of the existence of all collectors and back-end elements. To create reports or dashboards, this front-end element should be used.

## Back-end connectors

Back-end connectors take care of the aggregation of KPIs (Key Performance Indicators) and KQIs (Key Quality Indicators) of all topology levels above CPE (the lowest level) and below Network (the highest level).

One or more back-end elements, per technology, are placed on a DataMiner Agent (DMA). They carry out the aggregation logic in an independent and distributed fashion for all collectors placed on the DMA. In a system with multiple markets and hubs, for example, aggregations for a specific hub are handled by a specific back-end element.

## OLT connectors

These connectors extract information related to slots, ports, and ONTs managed by the OLT. With this information, which is usually added in tables, a logical association is created to provide the path to each of the ONTs. A full path representation should be something similar to OLT > Slot > Port > ONT.

These connectors also register the ONT operative data provided by the third-party stream (by default a Kafka stream), after it is parsed and analyzed.

## ONT data connector

All operative data received for a GPON ONT is provided by a third party in a Kafka stream. To process it, the solution uses the [Generic Kafka Consumer](https://catalog.dataminer.services/result/driver/7373) connector. The received data is then parsed by a different set of [system connectors](#system-connectors) and finally aggregated according to the topology conditions.

## System connectors

System connectors are designed to operate as peripherals within the EPM Solution. Some system connectors interface with specific data sources (e.g. CRM, network elements inventory, billing), and feed information into the logic of the main connectors (i.e. the OLT, back-end, and front-end). Other system connectors perform logic required for the execution of specific workflows.

System elements (running system connectors) are typically distributed per DMA to ensure self-contained functionality.
