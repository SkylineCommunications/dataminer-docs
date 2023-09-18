---
uid: Connector_help_Evertz_570ACO-X19-10G
---

# Evertz 570ACO-X19-10G

The Evertz 570ACO system uses mechanical latching relays to ensure maximum reliability and minimal disruption in the event of any failure, even a power failure.

This connector is used to monitor and receive traps from this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | ACO570X1910G-MIB       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this connector has several data pages:

- The **General** page displays the uptime, ID, name and location of the system.
- The **System** page contains various tables with information and settings, including card controls. At the bottom of the page, the **Configuration Management** section allows you to download and import a configuration.
- On the **Product Features, ACS Control, SDI Control, UPD Output, IP Input, PTP Control** and **Monitoring Control** pages you can find various tables with information and settings related to these subjects.
- The **Video Notify, Audio Notify, ANC Notify** and **Notify** pages display tables where you can read/change the state and value of traps.
