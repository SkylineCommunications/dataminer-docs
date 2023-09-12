---
uid: Connector_help_Harmonic_Electra_X2
---

# Harmonic Electra X2

This connector displays the SNMP traps forwarded by the Harmonic NMX pertaining to the Harmonic Electra X2 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8, 9.2 (Harmonic NMX)  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of Harmonic NMX device managing the target device.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the Harmonic NMX device managing it.

## How to use

The **General** page of the element displays the alarms captured by DataMiner. You will need to specify the name of the device in order for the connector to retrieve the alarms sent by the Harmonic Electra X2.

On the **Alarm Settings** subpage, you can enable the clearing of alarms after a specific period of time. By default, this is disabled.
