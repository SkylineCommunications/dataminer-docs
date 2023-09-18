---
uid: Connector_help_T-Vips_CP510
---

# T-Vips CP510

This connector is developed for the **T-Vips CP510**. It monitors the **services** and **PIDs** of the two inputs. In addition, alarms are also displayed in this connector.

## About

In the connector, the input services and PIDs are displayed in **1 table** each, and they can be **normalized**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *172.36.84.42.*

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

The connector consists of 5 pages.

### Main View

On this page, the **main information** about the devices is displayed, such as the uptime, name, etc.

### General

On this page, **System information** is displayed.

### Inputs

Both of the 2 inputs can be monitored on this page. Click the page buttons to see the **Services**, the **PIDs** and the **normalized values**.

### Alarms

On this page, the alarms of both inputs can be monitored. Click the **General Alarms...** page button to view general alarms with their description and severity, displayed in a table.

### Web Interface

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
