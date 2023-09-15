---
uid: Connector_help_Fujitsu_FLEXR
---

# Fujitsu FLEXR

The Fujitsu FLEXR is a management system used to maintain and monitor a wide variety of Fujitsu network elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                        |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Fujitsu FLEXR - Network Element](xref:Connector_help_Fujitsu_FLEXR_-_Network_Element) |

## Configuration

### Connections

#### SNMP Primary Connection.

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

#### SNMP Secondary Connection.

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Initialization

For both the main and backup connections, the authentication information can be configured in the **Redundancy** table via the **User Name** and **Password** columns.

Either the primary or the main connection can be selected, and both connections can be enabled or disabled, after which the connector will automatically continue with the preferred connection.

### Redundancy

The connector has a main and backup connection available.

## How to use

### General

The **General** page contains everything related to the device connections. All communication can be enabled or disabled via **Enable Communication**

If the connector is communicating with the device, the **Connection Status** will be *Connected*, otherwise it is *Not Connected*. If communication has been disabled, this state is *Manually Disconnected*.

### Alarms

The **Alarm** page contains a table showing all the received alarms.

### Inventory

The **Inventory** page shows all network elements in the inventory. This inventory has to be provisioned via a CSV file.

The Inventory table will generate DVE elements for each entry in the inventory CSV. Each DVE shows only the alarms corresponding with the relevant ID (based on the Source ID parameter in the Alarms table).

CSV example:

id;type
DeviceId1;Type1
DeviceId2;Type2
