---
uid: Connector_help_Spirent_Lumos
---

# Spirent Lumos

**Spirent Lumos** provides a unified platform for the automation of service assurance workflows in networks that use a hybrid architecture of physical and virtual elements.

## About

This connector is used to handle SNMP traps from the device and will also send information from the retrieved Threshold Crossing traps to the CPE Collectors implemented for the IPVPN project.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains the **Threshold Crossing** and **Collections** tables.

It also contains two page buttons:

- **Clean Up Config:** Allows you to configure the automatic clearing of events from the Threshold Crossing and Collection Tables, via the **Trap Clean Up Method**, **Maximum Number** and **Age Traps** parameters.
- **Data Distribution**: Only relevant for the Threshold Crossing traps. Contains the **String** **Format** parameter, which allows you to set the format of the strings to be sent to CPE Collector, and the **Interval Data Distribution** parameter, which allows you to specify the time interval allowed ("00s" means immediate sending following trap receipt).
