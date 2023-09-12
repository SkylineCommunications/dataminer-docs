---
uid: Connector_help_SEE_Telecom_Acsys_Tx_Us
---

# SEE Telecom Acsys Tx Us

This protocol allows you to monitor the SEE Telecom Acsys Tx Us receiver. It uses an SNMP connection to poll the parameters found in the device.

The protocol uses two different timers: The fast timer group retrieves the most important parameters every 30 seconds, while the slow timer polls the remaining parameters every hour.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |
| 1.1.0.x   | Release version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.1.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The address of the device.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

## How to use

The element has the following data pages:

- **Main view**: Displays the optical power and temperature values.
- **General**: Displays technical information such as the device type, serial number and software version, as well as the voltage status, temperature and consumption.
- **Optical**: Displays the optical current, temperature, power, etc. In the **Normalize** section, you can configure settings to help normalize the optical power.
- **RF**: Displays the RF Power and AGC Level values. Also allows you to configure the RF switch and the attenuation.
