---
uid: Connector_help_CE+T_TSI_via_T2S_ETH
---

# CE+T TSI via T2S ETH

The TSI via T2S ETH connector allows you to monitor a TSI inverter with up to 32 inverters through SNMPv1 communication.

## About

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial development | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.5.0                  |

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

The element has the following data pages:

- **General**: Displays general information related to the device.
- **UPS**: Displays the DC voltage and current of the battery.
- **Phases**: Displays voltage, current and power for each available phase.
- **AC-in and DC**: Displays the power, current and voltage for each DC and AC group.
- **Modules**: Contains general information for each active module (e.g. state, address, phase number, etc.).
- **AC Input/DC/AC Output**: The pages display AC or DC voltage, current and power information for each active module.
- **Temperature**: Displays the temperature for each active module.
- **Alarms**: Contains a list of alarms.
- **Configuration**: Contains a list of configuration values.
