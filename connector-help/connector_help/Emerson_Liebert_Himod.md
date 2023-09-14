---
uid: Connector_help_Emerson_Liebert_Himod
---

# Emerson Liebert Himod

With this connector, you can gather and view information from the device **Emerson Liebert Himod**, as well as configure the device.

## About

This connector uses SNMP to monitor the **Emerson Liebert Himod** device.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | No                      |
| 1.1.0.x          | New firmware based on 1.0.0.x (see below) | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \< 5.0.0.0                  |
| 1.1.0.x          | 5.0.0.0                     |

**Important Note**: In order to switch to a different connector range for elements that were created with a connector range that supports an old firmware version, it is advised to create the elements again.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.62*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time** and **Firmware Version**.

### Interfaces Page

This page displays a table with the status and statistics of the device's interfaces.

### Managed Devices Page

This page shows a table with the devices managed by this device.

### Events Page

This page displays a table with the events present on the device and the time when they were generated.

### Environmental Settings Page

On this page, you can configure the temperature and humidity settings of the device.

### System Status Page

This page displays the status of the device, with parameters such as **System State**, **General Alarm Output State** and **Cooling Capacity**.

### Configuration Page

On this page, you can configure the device, with parameters such as **Restart Delay**, **Sleep Mode**, **Humidity Control** and **Fan Speed mode**.

### Web Interface Page

This page displays the device's web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
