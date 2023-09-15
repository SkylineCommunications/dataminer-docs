---
uid: Connector_help_IMCI_Open-I_XL
---

# IMCI Open-I XL

This connector is used to monitor IMCI Open-I XL devices, i.e. **SNMP-based Network Element Managers**.

## About

With this connector, it is possible to monitor IMCI Open-I XL devices, such as the **IMCI Open-I 200XL** and **1000XL series**, with **SNMP**.

The different parameters from the device are displayed on multiple pages according to the subject of the parameters.

The connector implements traps to update the corresponding values and to generate alarms immediately.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 14.5.0, 15.5.0              |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string needed to read from the device. The default value is *public*.
- **Set community string:** The community string needed to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information, such as:

- **Model name**
- **Software Version**
- **IP information**
- **Time information**
- **Power supply information**

### Contact Input Page

This page displays a table where you can configure the **Contact Inputs**.

### Contact Outputs Page

This page displays a table with the **Contact Output** states and configuration settings for each output.

### Config Page

On this page, it is possible to configure **Traps**, **Rules** and **Dial in** settings

### Logs Page

This page displays a table with the **logs** of the device. The logs can be cleared with the **Clear Log** button.

### Comm Ports Page

This page displays a table with the **comm port** states and configuration settings for the comm ports.

### Interfaces Page

This page displays a table with the **interface** states and configuration settings for the interfaces.

### Ext Services Page

This page displays a table with the **external services** and configuration settings for the services.

### Access Page

This page displays a table with the **access** settings, such as:

- **Access Type**
- **Community**
- **IP Address**
- **Port Number**

### Traps Page

This page displays a table with the **traps** and their **Severity Value** and **Level**.

### Session User Page

This page displays a table with the **users** of the IMCI Open-I XL system with their settings.

### Serial Session Page

This page displays a table with the current **serial sessions**.

### Analog Input Page

This page displays a table with the **analog inputs** of the system and configuration settings for the analog inputs.

### Event Correlation Page

This page displays a table with the **event correlations**. It is also possible to enable or disable event correlation here.
