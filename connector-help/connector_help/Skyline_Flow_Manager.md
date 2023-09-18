---
uid: Connector_help_Skyline_Flow_Manager
---

# Skyline Flow Manager

The **Skyline Flow Manager** connector can be used to manage multiple **Skyline Flow Collector** elements.

## About

With this connector, you add an extra layer on top of multiple Netflow collector elements. It makes the configuration and management of a cluster with multiple collector elements easier. All configuration and other information is combined in one single element, which is used as an application.

This is a virtual connector that does not communicate with devices, and because of that no traffic will be seen in the **Stream Viewer** for elements using this connector.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Collectors

This page provides a list of all collector elements that are managed. Each row shows a number of statistics for a collector:

- **Packet Rate**: Number of incoming packets that are currently processed (sum of all exporters).
- **Flow Rate**: Number of incoming flows that are currently processed (sum of all exporters).
- **Parse Queue Size**: Number of Netflow packets that are in the queue, ready to be parsed in separate flows.
- **Aggregation Queue Size**: Number of flows in the queue that are ready to be processed by the aggregation engine.
- **Offload Queue Size**: Number of flows in the offload queue, ready to be stored in the database.
- **Offload Rate**: Number of flows that are currently offloaded to the database.
- **DNS Resolves Queue**: Number of IP addresses that still need to be resolved to their hostname.

New collector elements are automatically added to the list. To remove a collector, use the table's context menu.

### Exporters

This page provides a list of all Netflow exporters. An exporter is a device that sends out Netflow packets towards a Netflow collector. The following information is included:

- **State**: Enables/disables the processing of incoming Netflow data.
- **Top Talkers**: Percentage of Netflow data that must be kept.
- **Packet Rate**: Number of incoming packets that are currently processed.
- **Flow Rate**: Number of incoming flows that are currently processed.
- **Uptime**: Uptime in the last received Netflow packet.
- **System Time**: System time in the last received Netflow packet.
- **Netflow Version**: Version field in the last received Netflow packet.
- **Detail 1 Compression Ratio**: Percentage of flows that are kept when comparing the number of flows before and after the detail 1 aggregation.
- **Detail 2 Compression Ratio**: Percentage of flows that are kept when comparing the number of flows before and after the detail 2 aggregation.
- **Detail 3 Compression Ratio**: Percentage of flows that are kept when comparing the number of flows before and after the detail 3 aggregation.
- **Element**: Indicates to which router/switch element this exporter is linked.

New exporters are automatically added to the list. To remove an exporter, use the table's context menu.

All settings are automatically synchronized with the collector elements every 10 seconds. The **Sync** button can be used to manually push the configuration to all configured collector elements.

### Application Mapping

This page allows you to configure the mapping between an IP protocol/port and an application name. Use the table's context menu to add or remove rows.

To send the configuration to all configured collector elements, press the **Sync** button.

### AS Mapping

This page provides an overview of the mapping between the Autonomous System Number (ASN) and its name.

The connector also keeps track of the conversations between source and destinations. These conversations are stored in the **AS Conversation Mapping Table**.

The direction is not taken into account: traffic from AS 1 to AS2 is considered the same conversation as traffic from AS2 to AS1.

#### Private AS Mapping

On this page, you can configure your own private/proprietary autonomous system mappings. Rows can be added or deleted via the context menu of the table.

Rows in the private range mapping table have priority over the rows that are defined in the mapping table of the public range.

#### Public AS Mapping

This page contains a table with all autonomous system mappings in the public range. These autonomous systems can be imported from a file with the following format:

\<id\>\<whitespace\>\<name\>

\<id\>\<whitespace\>\<name\>

An example file can be downloaded from RIPE: <https://ftp.ripe.net/ripe/asnames/asn.txt>.

### Configuration

On this page, you can configure the default initial settings that will be used for a newly detected Netflow exporter. The values can be overridden on the Exporters page.

- **New Exporter Default State**: Enables/disables the processing of incoming Netflow data.
- **New Exporter Default Top Talkers Percentage**: Percentage of Netflow data that must be kept.
