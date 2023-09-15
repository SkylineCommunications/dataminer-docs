---
uid: Connector_help_Evertz_7x00_General_Platform_Group_2
---

# Evertz 7x00 General Platform Group 2

The Evertz 7x00 General Platform connector is used to monitor and control an Evertz chassis containing different Evertz 7700/7800 series cards.

The chassis must include an **Evertz 7700-FC, Evertz 7800-FC, or Evertz 7801-FC** card in order to be functional. Data about the location of other cards is polled from this card. The Evertz 7700-FC/7800-FC/7801-FC is placed in slot 1; other cards are inserted into slots 2 to 15. A DVE will be created for each supported card. Data is polled via **SNMP**. Traps are supported to reduce the amount of polling. When a trap is received, the corresponding parameter is polled again to update its value.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based on**                                      | **System Impact**                                                                                                     |
|----------------------|---------------------------------------------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                  | Range 1.0.2.x of the Evertz 7x00 General Platform | \-                                                                                                                    |
| 1.0.1.x \[Obsolete\] | Discrete changes.                                 | 1.0.0.2                                           | Alarm templates, Visual Overview, Automation scripts                                                                  |
| 1.0.2.x \[Obsolete\] | Discrete changes.                                 | 1.0.1.4                                           | Alarm templates, Visual Overview, Automation scripts                                                                  |
| 1.0.3.x \[Obsolete\] | \-                                                | 1.0.2.11                                          | \-                                                                                                                    |
| 1.0.4.x \[SLC Main\] | Removed columns from fault polling configuration. | 1.0.3.3                                           | \-                                                                                                                    |
| 2.0.0.x              | Removed 7700ACO2HD and 7800R2X2-ACS-3G cards.     | 1.0.4.2                                           | The removed cards can no longer be polled using this connector. Standalone connectors are available for this instead. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |
| 2.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \- [Evertz 7x00 General Platform Group 2 - 7800R2x2-ACS](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800R2x2-ACS) <br>- [Evertz 7x00 General Platform Group 2 - 7800IDA8-3G](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800IDA8-3G) <br>- [Evertz 7x00 General Platform Group 2 - 7707GPS-DR](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7707GPS-DR) <br>- [Evertz 7x00 General Platform Group 2 - 7707GPS-DT](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7707GPS-DT) |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| 1.0.2.x   | No                  | Yes                     | \-                    | \- [Evertz 7x00 General Platform Group 2 - 7881IRD2-ATSC](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7881IRD2-ATSC) <br>- [Evertz 7x00 General Platform Group 2 - 7881DEC2MP2HD](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7881DEC2MP2HD) <br>- [Evertz 7x00 General Platform Group 2 - 7746FSHD](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7746FSHD)                                                                                                                                          |
| 1.0.3.x   | No                  | Yes                     | \-                    | \- [Evertz 7x00 General Platform Group 2- 7800TM23G](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800TM23G)                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| 1.0.4.x   | No                  | Yes                     | \-                    | \- [Evertz 7x00 General Platform Group 2 - 7800R2x2-ACS](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800R2x2-ACS)                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector displays information about the frame controller (Evertz 7700-FC/Evertz 7800-FC) and the inserted cards.

### Input Cards

The Input Cards page lists all the modules embedded in the chassis and their corresponding slots. If cards have been changed, use the **Refresh Cards** button to see the changes immediately. If you activate the **Automatically Delete Offline Rows** toggle button, cards that get removed from the frame will not be moved to the Input Cards \[DEL\] page.

### General

The General page displays general parameters for the **Evertz 7700-FC/Evertz 7800-FC** controller, such as the **Temperature**, **Power Supply**, etc.

### SNMP Config

On the SNMP Config page, you can configure the **SNMP** agent: the **trap** destination, the communities, etc.

## Supported cards

Depending on the connector range (see "System Info"), the cards below are supported.

### Evertz 7800R2x2-ACS

The 7800R2x2-ACS is a powerful low-latency hot-swappable GPS card. The [Evertz 7x00 General Platform - 7800R2x2-ACS](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800R2x2-ACS) connector is exported for DVEs representing this card.

- Supported types: 7800R2x2-ACS.

### Evertz 7800IDA8-2G

The 7800IDA8-3G is a powerful low-latency hot-swappable GPS card. The [Evertz 7x00 General Platform - 7800IDA8-2G](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800IDA8-3G) connector is exported for DVEs representing this card.

- Supported types: 7800IDA8-2G.

### Evertz 7707GPS-DR

The 7707GPS-DR is a powerful low-latency hot-swappable GPS card. The [Evertz 7x00 General Platform - GPS-DR-F2](xref:Connector_help_Evertz_7x00_General_Platform_-_7707GPS-DR-F2) connector is exported for DVEs representing this card.

- Supported types: 7707GPS-DR-F2.

### Evertz 7707GPS-DT

The 7707GPS-DR is a powerful low-latency hot-swappable GPS card. The [Evertz 7800R2x2-ACS-3G](xref:Connector_help_Evertz_7800R2x2-ACS-3G) connector is exported for DVEs representing this card.

- Supported types: 7707GPS-DT-F2.

### Evertz 7800R2x2-ACS

The 7800R2x2-ACS is a reliable SDI protection switch. The [Evertz 7800R2x2-ACS-3G](xref:Connector_help_Evertz_7800R2x2-ACS-3G) connector is exported for DVEs representing this card.

- Supported types: 7800R2x2-ACS-3G.

Evertz 7800TM2-3G

The 7800TM2-3G is a modular time code processor. The [Evertz 7x00 General Platform - 7800TM2-3G](xref:Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800TM23G) connector is exported for DVEs representing this card.

- Supported types: 7800TM2-3G.
