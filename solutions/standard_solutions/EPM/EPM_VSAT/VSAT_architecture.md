---
uid: VSAT_architecture
---

# EPM VSAT architecture

The EPM Solution makes use of the following components:

- [Collector connectors](#collector-connectors): These connectors take care of technology-specific data collection and initial processing.

- [Backend connectors](#backend-connectors): These connectors take care of technology-specific aggregation of the data from the collector connectors.

- [Frontend connector](#frontend-connectors): This connector takes care of technology-agnostic data presentation. It allows users to view KPIs and other information based on the data received from the backend connectors.

- [System connectors](#system-connectors): These connectors are designed to operate as peripherals within the EPM Solution.

![EPM VSAT architecture](~/dataminer/images/EPM_VSAT_architecture.png)

## Collector connectors

At the core of the solution are collector connectors capable of interfacing with any physical and/or virtual data source (devices, APIs, etc.).

In a typical VSAT deployment, there are various types of service-delivery entities such as NMSs, third-party APIs, modems, servers, cable modems (CMs), routers, switches, and firewalls.

The EPM Solution integrates with these entity types, regardless of technology or vendor, via specific or generic connectors. These "collector" connectors operate at the lowest level of the EPM Solution. The connectors are optimized for data gathering and initial processing. Parameters stored at this level typically correspond to direct readings from data sources.

One or more collector elements are placed on a DMA, and they are locally managed by the corresponding backend elements.

## Backend connectors

Backend connectors take care of the aggregation of KPIs (Key Performance Indicators) and KQIs (Key Quality Indicators) of all topology levels above CPE (the lowest level) and below Network (the highest level).

One or more backend elements, per technology, are placed on a DataMiner Agent (DMA). They carry out the aggregation logic in an independent and distributed fashion for all collectors placed on the DMA. In a system with multiple markets and hubs, for example, aggregations for a specific Hub are handled by a specific backend element.

## Frontend connectors

The frontend connector allows the user to access all information from the EPM Solution from a single pane of glass. It is a lightweight connector that only contains the visual structure of the solution. It is optimized for aggregation at the highest level (Network) of the topology.

There is only one frontend element per DataMiner System, and it is aware of the existence of all collectors and backend elements. To create reports or dashboards, this frontend element should be used.

## System connectors

System connectors are designed to operate as peripherals within the EPM Solution. Some system connectors interface with specific data sources and feed information into the logic of the main connectors (i.e., the collector, backend and frontend connectors). Other system connectors perform logic required for the execution of specific workflows.

System elements (running system connectors) are typically distributed per DMA to ensure self-contained functionality.
