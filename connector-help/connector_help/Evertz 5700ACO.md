---
uid: Connector_help_Evertz_5700ACO
---

# Evertz 5700ACO

This driver is used to monitor and control the **Evertz 5700ACO** device.

The 5700ACO automatic changeovers are intended for use with two 5700MSC master clock/sync generators. The 5700ACO system uses mechanically latching relays to ensure maximum reliability and minimal disruption in the event of any failure, even power failures.

The changeover uses a voting system based on which source has the best signals and on whether the good signals on the current master are also present on the backup master.

## About

### Version Info

| **Range**            | **Key Features**                                     | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Manual/automatic changeover- Voting configuration | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0 47                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The driver has two main pages, the **General** page and the **Control** page.

- The **General** page contains device status parameters, such as **Firmware Version** and **Operation Mode**.
- The **Control** page is used to change the device configuration. You can for example configure the voting process and change the **Control Status** to manual/automatic.
