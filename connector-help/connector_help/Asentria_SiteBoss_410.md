---
uid: Connector_help_Asentria_SiteBoss_410
---

# Asentria SiteBoss 410

The Asentria SiteBoss 410 connector is used to monitor models **410** and **412.** The main difference between these two devices is the number of contacts (6 in the 412 and 8 in the 410) and the presence of a humidity sensor (only in the 410).

The connector allows you to monitor general parameters (e.g. system uptime, location, tech support details, etc.) as well as input and output interfaces such as contacts, relays, sensors, and analog inputs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.11T                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### General

This page contains general information about the device, such as the model (and the model selector), system description and uptime, firmware version, etc.

With the **Model Selector** parameter, you can switch between device 410 and 412.

### Settings

This page contains passthrough and FTP information.

### SNMP Settings

This page contains SNMP settings such as the IP address.

### Tech Support

This page contains the parameters relevant to cases where technical support is needed, including a **Force Restart** button.

### Environment

This page contains information about the humidity and temperature sensors.

For the temperature value, no unit is displayed, as this can be set to Celsius or Fahrenheit. Alarm monitoring via the device can be enabled or disabled on this page.

### Sensor Trap Settings

This page contains the settings for the humidity and temperature sensors. This includes the possibility to send repeated traps and poll humidity parameters, and the relevant thresholds and alarm severities.

### Environment

This page contains information about analog 1 and 2 inputs. Alarm monitoring via the device can be enabled or disabled on this page.

### Analog Trap Settings

This page contains the settings for the analog 1 and 2 inputs. This includes the possibility to send repeated traps and poll analog parameters, and the relevant thresholds and alarm severities.

### Relays and Contacts

This page contains information about relay 1 and 2 outputs. It also allows you to send a pulse for a specific duration between 1 and 15 seconds. This pulse will always operate with the opposite value of the current state. For example, if the current state is opened and pulse duration is 5 seconds, a pulse with 5 seconds of closed state will be sent to the device.

This page also contains the page buttons to all contact pages. Each contact page contains the following information: Name, Alarms Enabled/Disabled, Time threshold, Trap Repeat, Contact State, Contact Active Direction, Return to Normal Trap, and Contact Alarm Severity,

### Alarms and Traps

This page displays information obtained from trap processing and severity information obtained from other parameters in the device.

It contains a table with a fixed number of rows (1 per type) and the following columns:

- **Instance**: The origin of an alarm/trap, e.g. *Analog 1*, *Contact 5*, *Humidity*.
- **Time**: The time when the trap was received (or the start-up time in case the element is started for the first time).
- **Alarm Description**: A concatenated string containing the instance and severity.
- **Severity**: The severity of the alarm (Normal, Warning, Minor, Major, Critical, Severe).
- **OID**: The OID of the trap. Can be empty when the element is just started. Can also be "Manually Cleared" if the Manual Clear button is pressed.
- **Manual Clear:** A button to manually clear a trap.
