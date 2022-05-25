---
uid: I-DOCSIS_components
---

# EPM I-DOCSIS components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (CMTS and CCAP devices, APIs, etc.). For example, we use collector connectors to poll a CMTS device and obtain the necessary information needed to present DOCSIS data throughout the EPM topology.

These connectors do not ship out with the solution packages. They need to be installed separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for I-DOCSIS](xref:DOCSIS_supported_technologies).

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

These are the required EPM connectors, which are included in the EPM Solution package:

- [Skyline EPM Platform](https://catalog.dataminer.services/result/driver/7207)
- [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209)
- [Generic DOCSIS CM Collector](https://catalog.dataminer.services/result/driver/4207)
- [Skyline EPM Platform DOCSIS WM](https://catalog.dataminer.services/result/driver/7212)

## Correlation rules

## Automation scripts

## Dashboards

## Visuals
