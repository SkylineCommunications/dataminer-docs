---
uid: Connector_help_AKCP_SensorProbe4
---

# AKCP SensorProbe4

The AKCP SensorProbe4 is a high-speed, accurate, and intelligent monitoring device. It is an embedded host with a proprietary Linux-like OS, which includes TCP/IP stack, a built in web server, and full email and SNMP functionality. It has four auto-sense intelligent sensor ports, which work with a wide range of AKCP intelligent sensors. It can use any combination of sensors to monitor temperature, humidity, water leakage, airflow, security, and control relays. AKCP sensors can also be used to detect AC voltage and measure DC voltage. An integrated data collection and graphing package allows users to spot trends in the airflow, temperature, and humidity.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | SP4                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The SensorProbe4 will poll data using SNMP. All polled data is displayed on the corresponding element pages.

On the **General** page, you will find information about the device itself.

All sensor probe configuration can be done on the **Sensor Probe Config** page and subpages.

Sensor information can be found on the **Temperature**, **Humidity,** and **Switch Settings** pages.
