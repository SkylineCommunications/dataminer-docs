---
uid: GPON_components
---

# EPM GPON components

## Connectors

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the information for the different topology levels. By themselves, they are unable to extract any information from the devices. They rely on other connectors, specific to the technology, and on system connectors to feed information into the EPM engine.

For GPON, these are the required EPM connectors:

- [Skyline EPM Platform](https://catalog.dataminer.services/result/driver/7207)

- [Skyline EPM Platform GPON](https://catalog.dataminer.services/result/driver/7210)

- [Skyline EPM Platform GPON WM](https://catalog.dataminer.services/result/driver/7213)

### Data collection

These connectors interface with the main data sources (OLT, APIs, streams, etc.) to gather the required information for EPM to determine the logical and physical relationships of the different components. For instance, an OLT connector will poll the device and obtain the slot, ports, and chassis information needed to identify an ONT throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for GPON](xref:GPON_supported_technologies).

### System connectors

To gather the ONT operative data, the default method is a Kafka data stream provided by a third party. Usually this is an ACS if the GPON implementation has multiple vendors deployed (i.e. one vendor for the OLT and multiple vendors for the ONT).

A [Generic Kafka Consumer](https://catalog.dataminer.services/result/driver/7373) connector is available, which is able to retrieve information from any stream, as it does not process any of the received data. It only polls the data, ensures that its formatting is consistent, and stores it in a defined location:

For EPM GPON to function properly, however, the source for the Kafka stream needs to use the [Standard ONT JSON definition](xref:GPON_ONT_Json_definition). If your ONT operative data source does not use the defined format, contact the Skyline Sales team.

To take full advantage of the aggregation and topology capabilities of an EPM GPON implementation, you must make sure the location of the following data is known:

- **Subscriber data**: Contract ID, address, contracted speed, additional services, geographical coordinates, etc.

- **Network's Passive Elements inventory**: Splitter identification, fiber cable properties, etc.

This could be a database, a CRM, another data stream, local files (CSV or JSON), etc. To determine the effort to include such data sources in your system, contact the Skyline Sales team.

## Automation scripts

The GPON EPM Solution uses the following Automation scripts:

- **EpmBeToOLT**

- **EpmBeToOltPassives**

- **OltToWmGpon**

- **WmGponToOLT**

- **WmToBeGpon**

Each of these Automation scripts has a defined task. All of them use the DataMiner messaging system to request, provide, and sync data among EPM components.
