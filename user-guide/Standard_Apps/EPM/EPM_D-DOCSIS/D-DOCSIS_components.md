---
uid: D-DOCSIS_components
---

# EPM D-DOCSIS components

## Connectors

### Collector connectors

Collector connectors interface with the main data sources (CMTS and CCAP devices, APIs, etc.). For example, we use collector connectors to poll a CMTS device and obtain the necessary information needed to present DOCSIS data throughout the EPM topology.

These connectors do not ship out with the solution packages. They need to be installed separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for D-DOCSIS](xref:D-DOCSIS_supported_technologies).

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information of the different topology levels. EPM connectors rely on collectors and system connectors to feed information into the EPM engine.

These are the required EPM connectors, which are included in the EPM Solution package:

- [Skyline CCAP Platform EPM](https://catalog.dataminer.services/result/driver/6833)
- [Skyline CCAP Platform WM](https://catalog.dataminer.services/result/driver/6831)

### System connectors

System connectors are supported for the purpose of peripheral integrations that interact with collectors and EPM connectors to handle specific use cases. For example, system connectors can be used to interface with specific CRM systems to retrieve Latitude and Longitude information for the customer-premises equipment displayed throughout the EPM topology.

These connectors do not ship out with the solution packages. They need to be installed separately as necessary.

The following system connectors are supported (but not required):

- [Cox Vecima R-PHY Monitor](https://catalog.dataminer.services/result/driver/7039)
- [Cox Ceeview Platform](https://catalog.dataminer.services/result/driver/7396)
- [Cox Smart PHY](https://catalog.dataminer.services/result/driver/6972)
- [Cox IDP EPM Connectivity](https://catalog.dataminer.services/result/driver/6929)
- [Cox HP Network Automation](https://catalog.dataminer.services/result/driver/7038)

## Automation scripts

The D-DOCSIS EPM Solution uses the following Automation scripts:

- EpmConfig
- FeToBe
- MessageToCollector
- MessageToFe
- MessageToWm
- WmMessageToCollector

## Dashboards

The D-DOCSIS EPM Solution includes the following dashboards:

- Market
- Hub
- CCAP
- Core Leaf
- Spine
- Node Leaf
- RPD

> [!NOTE]
> It is also possible to create custom dashboards to go with the EPM Solution.

## Visuals

The D-DOCSIS EPM Solution includes the following visual overviews:

- D-DOCSIS Network
- D-DOCSIS Market
- D-DOCSIS Hub
- Skyline CCAP Platform EPM: Includes visualization for CCAP, RPD, CM, Node Leaf, Core Leaf, and Spine entities

> [!NOTE]
>
> - Depending on the target system, changes to these visual overviews may be needed.
> - We highly recommend that any advanced visualization is configured to point towards DataMiner dashboards, so that Visual Overview is only used for simple visualizations.

## Templates

The D-DOCSIS EPM Solution includes several alarm and trend templates. These are intended to serve as an example and can be adjusted as necessary. The following templates are included:

- Alarm templates:

  - Skyline CCAP Platform EPM
  - Cisco/Cox CBR-8 CCAP Platform Collector
  - Cisco Manager CIN Platform
  - Juniper Networks Manager CIN Platform

- Trend templates:

  - Skyline CCAP Platform EPM
  - Cisco/Cox CBR-8 CCAP Platform Collector
  - Cisco Manager CIN Platform
  - Juniper Networks Manager CIN Platform
