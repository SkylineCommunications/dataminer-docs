---
uid: GPON_architecture
---

# EPM GPON architecture

The architecture for the GPON Technology on the EPM solution uses components that extract the information directly from the devices involved and third party systems (Databases, Data streams) to calculate and aggregate the overall network status based on the different Topology levels.

- [Front-end connector](#front-end-connector): KPI aggregator for the network.
- [Back-end connectors](#back-end-connectors): KPI aggregators in the topology's lower levels.
- [OLT Connectors](#olt-connectors): These connectors take care of technology-specific data collection and initial inventory from the OLT perspective.
- [ONT Data Connector](#ont-data-connector): This connector is responsible for the ONTs data reception and analysis. In our Solution, we use a Generic Kafka Stream to implement such capabilities.
- [System connectors](#system-connectors): These connectors are designed to operate as peripherals within the EPM Solution. For GPON, most of the system connector are related to include the physical network devices (if available) into the EPM aggregations and logical associations.

![EPM GPON architecture](~/user-guide/images/EPM_GPON_architecture.png)

## Front-end connector

The front-end connector allows the user to access all information from the EPM Solution from a single pane of glass. It is a lightweight connector that only contains the visual structure of the solution. It is optimized for aggregation at the highest level (Network) of the topology.

There is only one front-end element per DataMiner System, and it is aware of the existence of all collectors and back-end elements. To create reports or dashboards, this front-end element should be used.

## Back-end connectors

Back-end connectors take care of the aggregation of KPIs (Key Performance Indicators) and KQIs (Key Quality Indicators) of all topology levels above CPE (the lowest level) and below Network (the highest level).

One or more back-end elements, per technology, are placed on a DataMiner Agent (DMA). They carry out the aggregation logic in an independent and distributed fashion for all collectors placed on the DMA. In a system with multiple markets and hubs, for example, aggregations for a specific Hub are handled by a specific back-end element.

## OLT Connectors

These connectors extract from the device, information related to slots, ports, and ONT managed by the OLT. With this information (normally tables), it creates a logical association to provide the path to each one of the ONT. A full path representation should be something similar to OLT > Slot > Port > ONT.

It also registers the ONT operative data provided by the third party stream (a Kafka stream is the default), after it is parsed and analyzed.

## ONT Data connector

All operative data received for a GPON ONT is provided by a third party in a Kafka Stream, to process it, the solution uses the [Generic Kafka Consumer](https://catalog.dataminer.services/result/driver/7373). The received data is then parsed by a different set of [System connectors](#system-connectors) and finally aggregated according to the topology conditions.

## System connectors

System connectors are designed to operate as peripherals within the EPM Solution. Some system connectors interface with specific data sources (i.e. CRM, Network elements inventory, billing), and feed information into the logic of the main connectors (i.e. the OLT, back-end and front-end). Other system connectors perform logic required for the execution of specific workflows.

System elements (running system connectors) are typically distributed per DMA to ensure self-contained functionality.

> [!TIP]
> Now that you have the knowledge about the general Architecture, you can start your [GPON EPM Solution deployment](xref:GPON_deployment)
>
