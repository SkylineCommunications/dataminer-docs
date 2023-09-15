---
uid: Connector_help_RTS_Intercoms_ADAM-M_AIO
---

# RTS Intercoms ADAM-M AIO

This connector is designed to monitor and configure a mid-size modular matrix intercom, with 128+ ports in a compact 3RU (rack unit) package and full redundancy of the master controllers and power supplies. The matrix frame supports all current ADAM cards, including AIO-16, RVON-16, MADI-16 Plus, Tribus and MCII-e controllers. It also supports existing ADAM wiring schemes and options. The chassis plugs-and-plays anywhere, running on 90 to 264 Vac at 50/60 Hz.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.
