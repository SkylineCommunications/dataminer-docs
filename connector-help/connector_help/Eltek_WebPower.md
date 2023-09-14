---
uid: Connector_help_Eltek_WebPower
---

# Eltek WebPower

The **Eltek WebPower** is an **adapter** that makes it possible to monitor and control DC power systems.

## About

The connector consists of different pages representing the different aspects of this device that can be monitored and controlled, for example **Inputs**, **Outputs**, **Voltage,** etc.

Information is polled from the device using **SNMP** calls. In addition, the original web interface of the device is available through the connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as **DC Plant Information**, the **System Date** and **Time**, and some monitored values related to the **Battery** and **Voltage**.

### Control Units

This page displays information related to the **Control Unit Temperature** and **Fan Speed** alarm states.

### Rectifiers

This page displays information about the rectifiers. This includes the **Rectifier Status Table**, which displays information such as the **Rectifier Status**, **Output Current**, **Output Voltage** and **Rectifier Temperature**.

### Solar Chargers

This page displays information about the rectifiers. This includes the **Solar Charger Status Table**, which displays information such as the **Solar Charger Status**, **Output Current**, **Output Voltage** and **Solar Charger Temperature**.

### Load

This page displays information about the load, such as the **Load Distribution Current** and the **Load Distribution Breaker Status**. The page also contains two tables: the **LVLD Table** and the **Load Monitor Units Table.**

### Battery

This page displays information about the battery, such as the **Battery Status**, the **Energy Log** and the **Cycle Log**. It also allows you to configure the **Alarm Limits**.

The page contains a number of page buttons. The page buttons **Monitor Units**, **Battery Banks** and **LVBD** provide access to a number of tables.

### Network Settings

On this page, you can enable or disable the **LITE** mode.
