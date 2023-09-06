---
uid: Connector_help_Avaya_ERS_5000
---

# Avaya ERS 5000

The Avaya ERS 5000 is a high-performance stackable Ethernet routing switch. This driver is designed to monitor this device via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. 10.11.12.13.

SNMP Settings:

- **Port** **number:** The port of the connected device, by default 161.
- **Get community string:** The community string in order to read from the device.
- **Set community string:** The community string in order to set to the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Displays a general system overview of the device, including a system description, the authoritative ID, uptime, etc.
- **System Info**: Displays system information related to the device. More detailed information is available via page buttons.
- **Interface**: Contains information related to the MIB2 interfaces.
- **OSPF**: Displays information related to the Open Shortest Path First protocol. More detailed information is available via page buttons.
- **IP**: Displays IP-related information. Via the **IP Tables** button, you can find more detailed information in the IP Address, IP Default Router and IP Net to Media tables.
- **TFTP**: Displays information related to the Trivial File Transfer Protocol configuration.
- **VLAN**: Displays the number of VLANs and the number of **VLAN IGMP Snoop groups**, as well as other VLAN-related information. The **VLAN Tables** page button displays extended filtered services.
- **SSH**: Displays information related to the SSH configuration. The **SSH Tables** page button displays more detailed information.
- **CSU**: Allows you to manage CSU mode.
- **Chassis**: Allows you to manage the device configuration. More detailed information is available via page buttons.
- **Chassis S5**: Allows you to manage the ERS 5000 chassis configuration. Several page buttons are available that show specific tables.
- **SNMP Polling Control**: Allows you to manage the SNMP polling of the driver, in order to reduce the load of SNMP requests on the device.
