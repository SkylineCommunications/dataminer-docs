---
uid: Connector_help_Generic_SNMP
---

# Generic SNMP

With the Generic SNMP connector, it is possible to **measure parameters on SNMP-compliant devices.**

## About

Every 5 seconds, the connector performs GET requests on OIDs specified by the user. It displays those parameters either as a **numeric value, a string or a rate value**. The user can add, edit and delete multiple SNMP parameters in the **Parameter Table**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Any                         |

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device you want to test.
- **Device address**: Unavailable.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. This is device-specific.
- **Set community string**: The community string used when setting values on the device. This is device-specific.

## Usage

This connector has one **General** page, where you can **Add**, **Delete** or **Edit SNMP parameters**. All added parameters are listed in the **Parameter Table**.

For each parameter, an OID has to be specified so that an SNMP parameter can be measured.

With the **Type** option, you can specify whether to display a specified parameter as a numeric value, a string or a rate value. The **rate value** is the result after calculating the difference between the old and the new value, divided by the time difference between them. The **Multiply Numeric Value** parameter lets you multiply the received numeric values for a particular row.
