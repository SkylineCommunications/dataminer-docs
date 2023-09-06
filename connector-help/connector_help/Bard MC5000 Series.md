---
uid: Connector_help_Bard_MC5000_Series
---

# Bard MC5000 Series

Connector to integrate the functionalities of a modbus device. It contains the Holding Registers, Input Registers and the Alarms.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

**This subsection can only be omitted for a virtual connector**

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | MCS5000.1.0.8          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### serial

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Interface connection:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Type of Port:** \[TCP/IP, Serial or UDP/IP\] Default: TCP/IP

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The driver contains 4 different pages:


- **Holding Registers:**

The default page displays device Setpoints, which can be both read from and set by the user. To interact, click on a Setpoint to view its value, and you can modify and save changes as needed.

- **Input Registers:**

This page shows read-only Input Registers of the device, meaning you can only view their current values but cannot alter them.

- **Alarms:**

The "Alarms" page presents read-only Discrete Inputs, allowing you to observe active alarms or device conditions.

- **Web Interface:**

On the "Web Interface" page, you can access the device's web interface by clicking on the provided link or button.

