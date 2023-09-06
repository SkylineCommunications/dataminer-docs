---
uid: Connector_help_Eltek_Smartpack_2
---

# Eltek Smartpack 2

The Eltek Smartpack 2 is a controller that allows you to monitor and control DC power systems.

Information is polled from the device using SNMP calls. In addition, the original web interface of the device is available through the driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configuration of normal or lite mode

This protocol can be run in **NORMAL** mode (default) or in **LITE** mode. In **LITE** mode, only a very limited number of parameters is polled, so that less data traffic is generated.

To toggle between **NORMAL** mode and **LITE** mode, click the **LITE Protocol** toggle button on the **System Overview** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The driver consists of different pages that cover the various subsections that can be monitored/controlled for this device. You can find more information on these below.

### System Overview

This page displays general information about the device, such as the general **Status**, the physical **Location**, **Information** about the **System Model**, and the **Units** that are used.

### Mains

This page displays information about the **Mains**, such as the **Mains** **Status**, the **Energy Log**, and the **Outage Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Monitors Tables**, **Outage Tables** and **Voltage Table** provide access to a number of tables.

### Generator

This page displays information about the **Generator**, such as the **Generator** **Status**, the **Energy Log**, and the **Run Hours Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Energy Log Tables**, **Run Hours Tables** and **Daily Run Setup Table** provide access to a number of tables.

### Rectifiers

This page displays information about the **Rectifiers**, such as the **Rectifiers** **Status** and the **Energy Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Energy Log Tables** and **Rectifier Table** provide access to a number of tables.

### Solar Chargers

This page displays information about the **Solar Chargers**, such as the **Solar Chargers** **Status** and the **Energy Log**.

The page contains two page buttons. The **Configuration** page button provides access to all configurable parameters. The page button **Energy Log Tables** provides access to a number of tables.

### Dcdc

This page displays information about the **Dcdc**, such as the **Dcdc Number of Groups**.

The **Tables** page button provides access to Dcdc-related tables.

### Wind Chargers

This page displays information about the **Wind Chargers**, such as the **Wind Chargers Status**.

The page contains two page buttons. The **Configuration** page button provides access to all configurable parameters. The page button **Energy Log Tables** provides access to a number of tables.

### Load

This page displays information about the **Load**, such as the **Load Status** and the **Energy Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Energy Log Tables, Group Table, LVLD Table, Fuse Table** and **Voltage Table** provide access to a number of tables.

### Battery

This page displays information about the **Battery**, such as the **Battery** **Status**, the **Energy Log**, and the **Cycle Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Bank Tables, Energy Log Tables, Cycle Log Tables** provide access to a number of tables.

### Inputs

This page displays the **Input Control Unit Tables**, with parameters such as **Status** and **Value**.

### Outputs

This page displays the **Output Control Unit Tables**, with parameters such as **Status** and **Description**.

### Inverters

This page displays information about the **Inverters**, such as the **Energy Log** and the **Reactive** **Energy Log**.

The page contains a number of page buttons. The **Configuration** page button provides access to all configurable parameters. The page buttons **Energy Log Tables** and **Reactive Energy Log Tables** provide access to a number of tables.
