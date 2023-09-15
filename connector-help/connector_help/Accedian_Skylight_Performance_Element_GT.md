---
uid: Connector_help_Accedian_Skylight_Performance_Element_GT
---

# Accedian Skylight Performance Element GT

The Accedian Skylight Performance Element GT connector reads csv.gz files from a specific directory, parses the data and displays it in a table.

History sets are implemented so that if trending is enabled, it will include the old data as well as the most recent data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | AMT_7.8.3_20905        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

To use this connector, you will need to add a row in the **File Paths** table and fill in the file path where the csv.gz files are stored for a single device.

For example, if G411-6194 is the serial number of the device, specify *C:\DataMiner\Accedian\G411-6194*

The CSV is a concatenation of:

- PAA Data Type
- Date
- PAA Type
- System
- Firmware Version
- Hardware Version
- Serial Number
- Index
- Name
- Status
- Operation Mode
- Packet Size
- Sampling Period
- Part Name
- Source MAX Address
- Destination MAX Address
- Ethernet Type
- Vlan 1 Encapsulation
- Vlan 1 Type
- Vlan1 ID
- Vlan1 Priority
- Vlan 2 Encapsulation
- Vlan 2 Type
- Vlan2 ID
- Vlan2 Priority
- Peer Address
- State
- Destination IP Address
- Source UDP Port
- Destination UDP Port
- DSCP
- ECN
- IGMP Ref Period
- Packet Loss Ref Period
- One-Way Ref Period
- Two-Way Ref Period
- Interval
- Samples
- Period
- Packet Loss NE Valid
- Packet Loss NE Samples
- Packet Loss NE
- Packet Loss Ratio NE
- Packet Loss FE Valid
- Packet Loss FE Samples
- Packet Loss FE
- One Way Delay Valid
- One Way Delay Samples
- One Way Delay Min
- One Way Delay Max
- One Way Delay Avg
- One Way Delay Exceed
- One Way DV Valid
- One Way DV Samples
- One Way DV Min
- One Way DV Max
- One Way DV Avg
- One Way DV Exceed
- Two Way Delay Valid
- Two Way Delay Samples
- Two Way Delay Min
- Two Way Delay Max
- Two Way Delay Avg
- Two Way Delay Exceed
- Two Way DV Valid
- Two Way DV Samples
- Two Way DV Min
- Two Way DV Max
- Two Way DV Exceed
- IGMP Join Delay Valid
- IGMP Join Delay Samples
- IGMP Join Delay Min
- IGMP Join Delay Max
- IGMP Join Delay Avg
- IGMP Join Delay Exceed
- IGMP Leave Delay Valid
- IGMP Leave Delay Samples
- IGMP Leave Delay Min
- IGMP Leave Delay Max
- IGMP Leave Delay Avg
- IGMP Leave Delay Exceed
- Model
