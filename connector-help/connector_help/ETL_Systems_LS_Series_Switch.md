---
uid: Connector_help_ETL_Systems_LS_Series_Switch
---

# ETL Systems LS Series Switch

The **ETL Systems LS Series Switch** connector can be used to display and configure information of the ETL Systems Model-23178, Model-23179 and Model-23180.

## About

This protocol can be used to monitor and control the **ETL Systems LS Series Switch** platform.

The protocol also has alarming and trending.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP Address/host**: The polling IP of the device, e.g. *10.107.128.38*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Configuration

The connector is configured to update the **System Model** and the maximum value of **Channel** automatically, if a valid **System Name** is provided: *Model-23178*, *Model-23179* or *Model-23180*. If the **System Name** is not one of these three values, you will need to configure the **System Model** manually.

## Usage

### General Page

This page displays some general information about the device, such as :

- Model
- System Name
- System Uptime
- Etc.

### Configuration

This page displays configuration information regarding the device, such as:

- IP Address
- Gateway
- Trap Overview
- Etc.

### Web Interface

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
