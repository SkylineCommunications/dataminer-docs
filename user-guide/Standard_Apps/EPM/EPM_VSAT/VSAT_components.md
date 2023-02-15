---
uid: VSAT_components
---

# EPM VSAT components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (iDirect Evolution, iDirect Dialog, SES Skala, Intelsat Flex, etc.). For example, we use collector connectors to poll an iDirect Evolution NMS and obtain the necessary information needed to present remote information data throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

#### iDirect Evolution

This is the collector connector required for the iDirect Evolution Platform. This collector was primarily tested on version 4.1 or later.

> [!TIP]
> For more information, see [Verizon iDirect Evolution Platform Collector](https://catalog.dataminer.services/result/driver/5827).

#### iDirect Dialog Platform VSAT

This is the collector connector required for the iDirect (formerly Newtec) Dialog Platform with Time Series Database (TSDB) integration.

> [!TIP]
> For more information, see [Newtec Dialog Platform VSAT](https://catalog.dataminer.services/result/driver/7342).

#### CMDB

This is the collector connector that helps form relationships between various collectors and technology that are traditionally unrelated. It can provide additional business details of the customer to enhance the metrics and KPIs needed that are not obtained by the NMS collectors alone.

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

EPM connectors ship with the EPM Solution package.

## Peripherals

Peripherals are optional but not required as part of a standard deployment.

### Sun outage

With DataMiner, a sun outage schedule can be made that predicts sun outages and the impact these may have on the signal and tracking of a VSAT terminal. DataMiner is capable of detecting sun outage events and offering the current state details of each remote in the VSAT system. Sun outages usually occur twice a year during the equinox in March and September.

> [!TIP]
> For more information on sun outage events, see [VSAT Sun Outages & Sun Fade Information](https://satoms.com/vsat-sun-outages/).

### Weather

DataMiner has flexibility of integration with any weather forecast service as it considers this variable a key factor capable of degrading and temporarily interrupting the signal delivery via VSAT. Operators receive automated detailed descriptions of any outages and/or degradation to the service because of weather conditions (e.g. rain fade).

### PLM

During planned maintenance (PLM), DataMiner suppresses any diagnostic and entity alerts related to the event process.

## Correlation rules

The VSAT EPM Solution uses the following Correlation rules:

- **VerSatOnReportCorrelation**: Correlation rule in charge of the synchronization of RDS subscribers (KPI, Entry, DCAT, etc.) by monitoring for *OnChange* and *OnUpdate* information events.

- **VrzVsatEventManager**: Correlation rule in charge of picking up all the events/alarms that should create a ticket request entry in the WM Ticketing protocol and send it to the Correlation rule that sends the requests to the proper ticketing element.

## Automation scripts

The VSAT EPM Solution uses the following Automation scripts:

- **VerSatOnReportAutomation**: Automation script in charge of updating and triggering the logic to keep RDS tables updated and synchronized across all DMAs (*Config Entry Subscribers*, *Entity Subscribers*, *KPI Entry Subscribers*, and *DCAT Profiles*).

  This Automation script is dependent on the following protocols:

  - Verizon Reports and Dashboards Solution: This protocol exports and imports data related to different collector elements.

  - Verizon WM RDS: This protocol manages the interaction between the Verizon Reports and Dashboards Solution protocol and the Profile Manager app. The information stored in the tables of the Verizon Reports and Dashboards Solution is stored in the Profile Manager app.

- **VerSatOnSunOutageAutomation**: Automation script in charge of handling sun outage protocol events.

  This Automation script is dependent on the following protocols:

  - Verizon WM DSM: This system protocol allows the Verizon DSM SO protocol to communicate with the Profile Manager.

  - Verizon DSM SO: This protocol is used to gather information via inter-element communication that will be exported to a location used by the Generic Sun Outage protocol. The information gathered consists of key parameters used during the calculation of sun outages. This protocol is purely a system protocol with this sole responsibility.

  The *VerSatOnSunOutageAutomation* script oversees collecting data from an information event triggered by Verizon DSM SO and passes it to Verizon WM DSM in order for that workflow manager to create, update, or remove a Profile Manager object. The information event is triggered from the context menus on the DSM SO protocol.

- **EPM BE Message Handler**: Automation script in charge of handling EPM back-end messages.

  This Automation script is dependent on the following protocols:

  - The [collector](#collector-connectors) that triggered the initial *EPM Message Handler* script:

    - iDirect Evolution

    - iDirect (Newtec) Dialog Platform VSAT

  - Verizon VSAT Platform Manager: This EPM protocol allows the aggregation of KPIs from different collector elements deployed in the Verizon infrastructure (e.g. Verizon iDirect Evolution Platform Collector).

  The *EPM BE Message Handler* script is in charge of communicating to the collector that the ID assignment files from the VSAT Platform Manager are ready for ingestion after the EPM back ends are done processing and setting the topology data in their respective tables.

- **EPM FE to BE**: Operates within the messaging system domain taking care of communication about the collector and entity the processed data originated from, between EPM front-end elements and the back-end elements.

  This Automation script is dependent on the following protocols:

  - The [collector](#collector-connectors) that triggered the initial *EPM Message Handler* script:

    - iDirect Evolution

    - iDirect (Newtec) Dialog Platform VSAT

  - Verizon VSAT Platform Manager: This EPM protocol allows the aggregation of KPIs from different collector elements deployed in the Verizon infrastructure (e.g. Verizon iDirect Evolution Platform Collector).

- **EPM Message Handler**: Automation script in charge of handling EPM messages.

  This Automation script is dependent on the following protocols:

  - The [collector](#collector-connectors) that triggered the initial *EPM Message Handler* script:

    - iDirect Evolution

    - iDirect (Newtec) Dialog Platform VSAT

  - Verizon VSAT Platform Manager: This EPM protocol allows the aggregation of KPIs from different collector elements deployed in the Verizon infrastructure (e.g. Verizon iDirect Evolution Platform Collector).

  The *EPM Message Handler* script is triggered from the collector after the ID request files for the entities are exported. It tells the EPM front end to ingest the request files.

## Dashboards app

The VSAT EPM Solution includes numerous dashboards, spread over the following folders:

- Performance

- Configuration

- Faults

- Other

![Dashboards app](~/user-guide/images/DashboardsApp.png)

### Performance

The *Performance* folder in the Dashboards app includes the following dashboards:

- CIRCUIT PERFORMANCE TABLE

- CIRCUIT PERFORMANCE TREND OTHER

- CIRCUIT PERFORMANCE TREND

- CUSTOMER PERFORMANCE AGGREGATED

- HUB FWD PERFORMANCE AGGREGATED

- HUB NETWORK UTILIZATION INF

- HUB RTN PERFORMANCE AGGREGATED

- HUB RTN UTILIZATION INF

- NMS PERFORMANCE AGGREGATED

### Configuration

The *Configuration* folder in the Dashboards app includes the following dashboards:

- CIRCUIT CONFIG

- HUB FWD CONFIG

- HUB RTN CONFIG

### Faults

The *Faults* folder in the Dashboards app includes the following dashboards:

- CIRCUIT ALARMS

- SYSTEM ALARMS

### Other

The *Other* folder in the Dashboards app includes the following dashboards:

- CIRCUIT PERFORMANCE & CONFIG

- MODCOD

- SUN OUTAGE ALL

- SUN OUTAGE NEXT
