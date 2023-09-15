---
uid: Connector_help_Geist_RCX
---

# Geist RCX

The **Geist RCX** connector was designed to monitor Geist's Power Monitoring (RCX) PDUs . These PDUs are rack-level units with circuit monitoring via a built-in web server, providing a comprehensive remote view on the power utilization of the installation. In addition to monitoring amps, volts, real power, apparent power, power factor and kWatt-hours, these units provide jacks for optional environmental monitoring.

## About

This connector uses **SNMP** to retrieve data from the device, making it possible to fully monitor the PDUs.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.12.7                      |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page contains general information about the device, such as the **Product** **Name**, the **System** **Uptime** and the **Mac Address**.

Additional info, such as the number of sensors of each type, can be accessed via the **Sensors Counts** page button.

### Airflow Info Page

This page contains information provided by airflow sensors. This information is displayed in a table called **Air Flow Sensor Table**.

It also displays a toggle button at the top of the page called **Polling Airflow Table**, which can be used to enable and disable the polling of this specific table.

### Smoke Alarm Page

This page contains information about the smoke alarm sensors, in the **Smoke Alarm Table**. There you can find information regarding the sensor's identification and its measured values.

Like the Airflow Info page, it also displays a toggle button called **Polling Smoke Alarm Table** to enable and disable the polling of this specific table.

### 3 Phase Outlet Control Page

This page contains information about the 3-phase outlet control. This information is displayed in a table called **3 Phase Outlet Control.**

Like the Airflow Info page, it also displays a toggle button called **Polling** **3 Phase Outlet Control Table** to enable and disable the polling of this specific table.

### Web Interface.

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
