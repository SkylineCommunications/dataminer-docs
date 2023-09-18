---
uid: Connector_help_Puregas_P550W
---

# Puregas P550W

With this connector, you can gather and view information from the **Puregas P550W** device, a dehydrator.

## About

The Puregas P200W connector is used to monitor and control a Puregas P550W device. It provides an overview of the different parameters of the device along with its statuses and generated alarms.

The connector uses **SNMP** to retrieve the data from the device. All parameters are polled every 15 seconds.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**           |
|------------------|---------------------------------------|
| 1.0.0.x          | P550W(P012300V20) Dryer, Version 3.00 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, *e.g. 10.11.12.13.*
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value in the connector is *public*.
- **Set community string**: The community string used when setting values on the device. The default value in the connector is *private*.

## Usage

### General

On this page, you can find general information, such as the **Model Number**, the **Current Firmware Version** and **Device ID** and the **Current Date Time**.

### Status

This page displays the status of the following parameters: **Outlet Pressure, Tank Pressure, Humidity, Outlet Flow, Cabinet Temperature, Total Run Time, Last Run Time, System Status, Compressor Status, Fan Status** and **Heater Status**

### Alarms

On this page, you can check if there is an alarm on the following parameters: **High Flow Alarm, High Out Pressure, Low Out Pressure, High Humidity Alarm, High Cabinet Temperature, High Compressor Last Run Alarm, Maintenance Required, Total Alarm** and **P550 W Trap**

### Configuration

On this page, you can configure the system setup, for instance with the **Start Up Delay** and the **Alarm Delay**. For the alarm setup, you can configure the **High Flow, High Pressure, Low Pressure, High Humidity, High Compressor Last Run** and **Total Run Time Reset**.

The page also displays network setup parameters, such as **IP Address, Subnet Mask, Gateway Address** and **SNMP Trap Server**.

### Web Interface

This page provides access to the web interface provided by the device's web server. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
