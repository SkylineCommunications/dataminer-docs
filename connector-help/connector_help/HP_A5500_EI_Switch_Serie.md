---
uid: Connector_help_HP_A5500_EI_Switch_Serie
---

# HP A5500 EI Switch Serie

This connector is used to monitor and configure the **HP A5500 EI Switch Serie.** It is based on the **HP ProCurve Manager**.

## About

An **SNMP** connection is needed for the connector so that it can retrieve and send information from/to the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.20.99 Release 2221P15     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device, such as the **Model**, **Software Description**, etc.

There are a several page buttons that can be used to configure or see information about the system:

- **System Info ...**
- **TCP/UDP Stats ...**
- **ICMP Stats ...**
- **IP Stats ...**
- **MAC Addresses ...**
- **Copy Config ...**
- **Reset Counters ...**
- **Redetect Config**
- **Save Configuration**

### Detailed Interface Info

This page contains the **Interface Table**, which displays all the interfaces along with their **Bandwidth**, **Admin State**, **Mtu**, etc.

With the **Measurement Config ...** page button, you can access the Measurement Configuration table.

### Detailed Interface Info - Rx

This page is similar to the **Detailed Interface Info** page, but only displays information about receiving.

### Detailed Interface Info - Tx

This page is similar to the **Detailed Interface Info** page, but only displays information about sending.

### IP Routing Info

This page displays a table with the IP Routing information from the device. The content of the table is only retrieved after you click the **Load** button in the right upper corner.

Two page buttons at the bottom of the page open a page where the **Address Translations** table and **ARP** **Table** can be loaded respectively.
