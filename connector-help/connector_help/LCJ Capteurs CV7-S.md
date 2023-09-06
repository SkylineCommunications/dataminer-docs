---
uid: Connector_help_LCJ_Capteurs_CV7-S
---

# LCJ Capteurs CV7-S

The CV7-S is an anemometer, used for measuring wind speed and direction.

The CV7-S driver collects absolute parameters and average parameters over a period of 1, 10 and 20 minutes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | EW_6_4s3_FR - 6.4      |

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
- **IP port**: *161*
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The driver displays all data on the **Monitoring** page.

## Notes

The average temperature parameters are not polled from the device, but calculated by the driver. If the **timer base** is changed, the period over which the averages are calculated will not match the displayed period (e.g. 10 and 20 min).
