---
uid: GPON_components
---

# EPM GPON components

## Connectors

### EPM connectors

EPM connectors constitute the core of the EPM Solution. They carry out the necessary logic to aggregate and display the different topology levels information. By themselves, they are unable to extract any information from the devices, hence, they rely on other connectors, specific to the technology, and system connectors to feed information into the EPM engine.

For GPON, these are the required EPM connectors:

- [Skyline EPM Platform](https://catalog.dataminer.services/result/driver/7207)
- [Skyline EPM Platform GPON](https://catalog.dataminer.services/result/driver/7210)
- [Skyline EPM Platform GPON WM](https://catalog.dataminer.services/result/driver/7213)

### Data collection

These connectors interface with the main data sources (OLT, APIs, streams, etc.) to gather the required information for EPM to determine the logical and physical relationships of the different components. For instance, an OLT connector, will poll the device and obtain the Slot, Ports, and chassis information needed to identify an ONT throughout the EPM topology.

While these connectors ship out with the solution packages, they need to be contracted separately as necessary.

For an overview of the available collector connectors, see [Supported technologies for GPON](xref:GPON_supported_technologies).

### System connectors

To gather the ONT operative data, the default method is a Kafka data stream provided by a third party, normally an ACS if the GPON implementation has multiple vendors deployed (i.e. One vendor for the OLT and multiple vendors for the ONT).

Skyline has developed a generic Kafka Consumer collector that is able to retrieve information from any Stream, as it doesn't process any of the received data. It only polls the data, ensures that is consistent (formatting wise) and stores it in a defined location.

- [Generic Kafka Consumer](https://catalog.dataminer.services/result/driver/7373): The generic Kafka consumer

For EPM GPON to function properly however, the source for the Kafka stream needs to follow the [Standard ONT Data Json](xref:GPON_ONT_Json_definition). If your ONT operative data source does not follow the defined format, you'll need to contact our sales department to determine how to help you.

For each EPM GPON implementation and deploy that wants to take full advantage of the Aggregation and topology capabilities, it is required to know where the following data is located:

- **Subscriber data:** contract Id, address, contracted speed, additional services, geographical coordinates, among others
- **Network's Passive Elements inventory:** Splitter identification, Fiber cable properties, etc.

It could be a database, a CRM, another data stream, local files (csv or Json), anything really. To determine the effort to include such data sources to your system, please contact sales.

## Automation scripts

The GPON EPM Solution uses the following Automation scripts:

- **EpmBeToOLT**
- **EpmBeToOltPassives**
- **OltToWmGpon**
- **WmGponToOLT**
- **WmToBeGpon**

Each of these automation scripts has a defined task, all of them work within the dataminer messaging system to request, provide, and sync data among EPM components.
