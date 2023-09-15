---
uid: Connector_help_Skyline_Flow_Collector
---

# Skyline Flow Collector

The **Skyline Flow Collector** connector can be used to capture and aggregate Netflow data.

## About

Cisco Netflow services provide network administrators with access to IP flow information from their network. Network elements such as routers and switches gather flow data and export it to the Netflow collector. The flow data includes details such as IP addresses, packet and byte counts, timestamps, types of services (ToS), applications ports, and input and output interfaces.

The connector uses a smart-serial connection to receive Netflow data packets from the devices.

Flows that fall within the same time frame and have the same key properties (i.e. the same source IP, source port, destination IP, destination port, etc.) are combined in one single summarized flow. The flows are then aggregated and stored in the database with three levels of detail:

- Detail 1: Flows are aggregated with a 1-minute granularity and kept in the database for at most 1 hour.
- Detail 2: Flows are aggregated with a 10-minute granularity (configurable) and kept in the database for at most 1 day
- Detail 3: Flows are aggregated with a 1-hour granularity and kept in the database for at most 1 month.

Before the detail 1 flows are written into the database, a top talkers optimization algorithm is applied. This means that only the flows that represent the most traffic in the network are recorded. By default, this value is set to 95%, but this can be changed by an operator. Keep in mind that this greatly affects the number of flows that will be stored in the database, because typically there are many very small flows that only represent 5% of the total traffic over the network.

All (aggregated) flows are stored in the Elasticsearch database. The data can be visualized in DataMiner dashboards.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Netflow v5, v9 and IPFIX    |

## Installation and configuration

### Creation

#### Smart-Serial Main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **Type of port**: By default *UDP/IP*.
  - **IP address/host**: Specify "*any*" to act as a server and receive data from all devices.
  - **IP port**: The IP port of the device, by default *2055*.

### Configuration

No additional configuration is needed after creating a new element with this protocol.

## Usage

### General

This page provides a summary of all statistics of the captured flows.

- **NetFlow Packet Counter**: The total number of received Netflow packets.
- **NetFlow Packet Rate**: The number of incoming packets/s that are currently processed (sum of all exporters).
- **NetFlow Flow Rate**: The number of incoming flows/s that are currently processed (sum of all exporters).
- **Parse Queue Size**: The number of Netflow packets that are in the queue, ready to be parsed in separate flows.
- **Aggregation Queue Size**: The number of flows in the queue that are ready to be processed by the aggregation engine.
- **Offload Queue Size**: The number of flows in the offload queue, ready to be stored in the database.
- **DNS Resolve Queue Size**: The number of IP addresses that still need to be resolved to their hostname.

### Exporters

This page provides a list of all Netflow exporters. An exporter is a device that sends out Netflow packets towards a Netflow collector.

New exporters are automatically added to the list. Use the context menu on the table to remove an exporter.

The configuration in the table can be overwritten by a **Skyline Flow Manager** element.

- **State**: Enables or disables the processing of incoming Netflow data.
- **Top Talkers**: The percentage of Netflow data that must be kept.
- **Packet Rate**: The number of incoming packets/s that are currently processed.
- **Flow Rate**: The number of incoming flows/s that are currently processed.
- **Uptime**: The uptime in the last received Netflow packet.
- **System Time**: The system time in the last received Netflow packet.
- **Netflow Version**: The version field in the last received Netflow packet.
- **Detail 1 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 1 aggregation.
- **Detail 2 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 2 aggregation.
- **Detail 3 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 3 aggregation.
- **Element**: Indicates to which router/switch element this exporter is linked.

### Aggregation

This page displays statistics regarding the aggregation of the flows. It also allows you to configure the aggregation windows that are used in the different aggregation stages.

- **Aggregation Queue Size**: The number of flows in the queue that are ready to be processed by the aggregation engine.
- **Detail 1 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 1 aggregation (average of all exporters).
- **Detail 2 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 2 aggregation (average of all exporters).
- **Detail 3 Compression Ratio**: The percentage of flows that are kept when comparing the number of flows before and after the detail 3 aggregation (average of all exporters).

Incoming flows are first aggregated in a window of 1 minute. This means that all flows that have an end time within the same minute and with the same key properties are combined into one aggregated flow.

The windows of the next aggregation phases (detail 2 and detail 3) are configurable:

- **First Aggregation Period**: The time interval that is used to aggregate the detail 1 flows (1 minute) into detail 2 flows. Default: *10 minutes.*
- **Second Aggregation Period**: The time interval that is used to aggregate the detail 2 flows into detail 3 flows. Default: *1 hour.*

### Offload

This page displays statistics regarding the offloading of the flows into the database.

- **Offload Queue Size**: The number of flows in the offload queue, ready to be stored in the database.
- **Offload Rate**: The number of flows/s that are currently offloaded to the database.
- **Detail 1 Flow Rate**: The number of detail 1 flows/s that are currently offloaded to the database.
- **Detail 2 Flow Rate**: The number of detail 2 flows/s that are currently offloaded to the database.
- **Detail 3 Flow Rate**: The number of detail 3 flows/s that are currently offloaded to the database.

### IP Mapping

This page displays the mapping between IP address and hostname. This information is collected using reverse DNS requests. New IP addresses are added to a queue, and each second one of them is resolved.

### IF Mapping

This page provides an overview of the mapping between the interfaces of the exporters and their name. This information is retrieved from the switch/router elements that are linked with the exporters, and is updated every minute.

### VLAN Mapping

This page provides an overview of the mapping between the VLAN IDs and their name. This information is retrieved from the switch/router elements that are linked with the exporters, and is updated every minute.

### Application Mapping

This page allows you to configure the mapping between an IP protocol/port and an application name. Use the context menu of the table to add or remove rows.

### AS Mapping

This page provides an overview of the mapping between the Autonomous System Number (ASN) and its name.

The connector also keeps track of the conversations between source and destinations. These conversations are stored in the AS Conversation Mapping Table.

The direction is not taken into account: traffic from AS1 to AS2 is considered the same conversation as traffic from AS2 to AS1.

### Configuration

On this page, you can configure the default initial settings that will be used for a newly detected Netflow exporter. The values can be overridden on the Exporters page.

- **New Exporter Default State**: Enables or disables the processing of incoming Netflow data.
- **New Exporter Default Top Talkers Percentage**: The percentage of Netflow data that must be kept.

## Notes

Netflow packets (raw bytes) are immediately added to the incoming data queue. This queue has a limited size of 200,000 *packets*. When this queue is full, it means that the connector was not able to process previous packets in time and new incoming data is dropped.
