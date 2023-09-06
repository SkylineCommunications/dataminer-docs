---
uid: Connector_help_Newtec_FRC0710
---

# Newtec FRC0710

The Newtec FRC0710 device is an IF to L-band upconverter with optional RF upconversion designed for a wide range of broadcast, telco and IP satellite applications. The Newtec FRC0710 connector can be used to monitor and configure key parameters of the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10.0.6                 |

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

The connector has different pages to monitor the device connection, power supplies and alarms.

The **Alarm Status page** displays the **Alarm Table**, which contains an overview of the state of all the possible alarms in the system. If an alarm has the status Fail, you can manually clear the alarm by clicking the corresponding **Clear** button. You can also see the corresponding Alarm Count, and you can reset this value to zero by clicking the **Reset** button.

On the **Control page**, you can set several parameters related to different aspects of input and output signals, like gain, operation bands and frequencies.

The **Alarm Settings page** contains parameters that allow you to enable/disable the **Overload** and **Underload** input alarms and the respective thresholds.
