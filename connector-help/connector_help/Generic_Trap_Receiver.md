---
uid: Connector_help_Generic_Trap_Receiver
---

# Generic Trap Receiver

The Generic Trap Receiver is used to capture and display all the traps for a specific IP address.

## About

### Version Info

| **Range** | **Key Features**                                | **Based on** | **System Impact** |
|-----------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                 | \-           | \-                |
| 1.0.1.x   | Display traps in a table. Lookup functionality. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/Host:** The polling IP of the device.

SNMP Settings:

- **Port Number:** The port of the connection device (default: *161*).

## Usage

### General

To capture traps, specify the IP addresses for which traps should be captured in the **Trap IP Sources** parameter, using a comma as separator. This page will then display an overview of the captured traps with their information (**OID**, **Source IP** and **Bindings**) in the **Traps** table.

If you also want an information event to be created on the DMA every time a trap is received, enable the **Information Events** parameter.

Via the **Auto Clear** page button, you can access settings to clean up the Traps table.

### Lookup Configuration

On this page, you can use the **Lookup Table** to have incoming trap OIDs replaced with an alias name. For this purpose, the parameter **Lookup Table State** must be enabled.

With the **Add Raw Value** parameter, you can add an OID to the lookup table. The **Clear Table** button can be used to delete all the raw values from the lookup table, except for some well-known values.

### Filter Trap

On this page, you can configure traps to be filtered so that certain traps will not be received. Regular expressions are supported.

### Update Trap

This page allows you to set up rules so that specific traps can update traps with a specific OID and alarm reference. From version 1.0.1.17 onwards, basic regular expressions using "\*" are supported.

From version 1.0.1.24 onwards, with the **Binding Alarm Index**, you can set up rules that are a combination of columns. To do so, specify a backslash ("\\) followed by a comma-separated list of bindings. Also add a row with the same specific OID to the **Filter Trap** page.

### Heartbeat Trap

This page allows you to set up sending and receiving of heartbeat traps. These traps can be used to test and monitor the DataMiner SNMP forwarding function.
