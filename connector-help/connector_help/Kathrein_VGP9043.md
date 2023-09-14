---
uid: Connector_help_Kathrein_VGP9043
---

# Kathrein VGP9043

The **Kathrein** **VGP9043** is an optical receiver.

## About

With this connector you can manage the Kathrein VGP9043 device using the **SNMP** protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | VGP 9042D -1G (HW_REV: 1A)  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### Main Page

This page contains general information about the device, such as the **Vendor**, **Model Number**, **Serial Number**, etc.

In addition, a number of monitored parameters are displayed, such as the **Internal Temperature** and **Tamper Status**.

Here, you can also find one central place for all configuration: the **Operations** page button.

### Advanced Page

This page consists of a number of different sections:

- The **Common** section contains parameters such as the **Type**, **Firmware ID** and **Number Paths**.
- The **States** section displays an overview of the states of the device.
- The **Measuring** section displays measured values such as the **DC Supply Voltage**.

### Configuration Page

This page contains this connector's configurable parameters for the **Ingres Control**.
