---
uid: Connector_help_ETI_ASM-1
---

# ETI ASM-1

The **ETI ASM-1** device is an automatic air dehydrator that supplies low-pressure air to keep waveguides and coaxial cables dry.

## About

This connector can be used to monitor the main environmental variables of the location where the device is installed, such as the temperature and pressure. It supports measurements in both the metric and the imperial system.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | NA                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection

- **IP address/host**: The polling IP of the device.

SNMP Settings

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

Once created, the element can be used immediately, The following data pages are available:

- **Global Alarms**: This page displays all global alarms. These are the alarms that apply for all the ports, such as low and high temperature or the leak rate of the system. The provided information is the result of parsing the response of the equipment to the request for the single parameter "alarms" (OID 1.3.6.1.4.1.32185.3.1.5) and the single parameter "testLeakRateSystem" (OID 1.3.6.1.4.1.32185.3.2.3).
- **Port Alarms**: This page contains alarms specific for ports, but only those alarms that are obtained by parsing the single parameter "alarms". The column "error" can be used as a filter to set an alarm on a port.
- **Port Statuses**: This page contains alarms and statuses of specific ports, such as the leak rate. The information on this page is based on the parameters "portTypes" (OID 1.3.6.1.4.32185.3.3.5), "testStatuses" (OID 1.3.6.1.4.1.32185.3.2.2) and the parameters with OID 1.3.6.1.4.1.32185.3.2.4 to OID 1.3.6.1.4.1.32185.3.2.11.
- **General**: This page contains information from the standard MIB-2, such as the location, system description, etc.
- **Status**: This page contains parameters related to the status of the device, such as the temperature. The page also contains the limits that are used to identify an error on the device. The units are displayed in metric and imperial units.
- **Web Interface**: This page displays the web interface of the device.
