---
uid: Connector_help_NEC_PNMS
---

# NEC PNMS

The NEC PNMS manages all PASOLINK/PASOLINK+ radio equipment under it and reports the summary status in the PASOLINK/PASOLINK+ radio network to the upper (higher-level) manager.

With this connector, it is possible to monitor a NEC PNMS. The connector creates a **DVE** for each different **source** it finds inside the received traps.

## About

### Version Info

| **Range**            | **Key Features**   | **Based on** | **System Impact** |
|----------------------|--------------------|--------------|-------------------|
| 1.0.0.x              | Sources monitoring | \-           | \-                |
| 2.0.0.x \[SLC Main\] | Sources monitoring | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (fixed value: *public*).
- **Set community string**: The community string used when setting values on the device (fixed value: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This connector displays a DVE table. DVE elements can be removed with the **Delete Element** button.

By default, the connector will make 100 DVE elements for the first 100 source IDs it finds in the received traps. You can customize this amount.

If the number of elements reaches 90 % of the maximum number of elements, a warning alarm can be created. If the maximum number of elements is reached, the alarm will go in critical state and no more elements will be created.

The parameters of the DVEs are grouped together by subject on different pages. All parameters represent states that are either **Normal** or in **Alarm**.
