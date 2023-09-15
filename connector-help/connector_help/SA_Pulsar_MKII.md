---
uid: Connector_help_SA_Pulsar_MKII
---

# SA Pulsar MKII

The **Scientific Atlanta Pulsar MKII** is a TV modulator that is used to convert baseband audio and video signals into RF output signals ready to go into a cable network.

## About

This connector retrieves the information of several devices using serial communication, with the help of a serial-to-ethernet converter device.

With the config button, you can add the required IDs, each one of which will export the information to an **SA Pulsar MKII - Device** connector, from where the device can be managed. The Device Overview page displays the status and behavior of the device communication and allows DVE management.

### Version Info

| **Range** | **Description**                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                     | No                  | Yes                     |
| 1.0.1.x          | No                                                                                                  | Yes                 |                         |
| 1.0.2.x          | Allows the creation of virtual elements from a list of addresses added on the Device Overview page. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.0.2.x          | V02.08                      |

### Exported connectors

| **Exported Connector**   | **Description**                                                 |
|-------------------------|-----------------------------------------------------------------|
| SA Pulsar MKII - Device | Device monitoring and management Only supported in range: 1.0.2 |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP Port**: The IP port of the device.

## Usage

### Device Overview

This page displays a table listing the monitored devices. Via the **Config** page button, new elements can be added to this table, using the remote response address of the devices.

The page allows you to manage the polling functionality of the monitoring and to control the creation of the virtual element.

To remove a device from the list, use the **Delete** button in the **Actions** column. This will stop the polling process and will delete the element.

**Export a DVE** will generate a new element that allows the management and monitoring of a specific device.

In the **Name** column, you can customize the name of the generated DVE.
