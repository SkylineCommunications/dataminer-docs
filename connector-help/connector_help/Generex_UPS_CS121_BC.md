---
uid: Connector_help_Generex_UPS_CS121_BC
---

# Generex UPS CS121 BC

The **Generex UPS CS121 BC** connector is an SNMP-based connector used for the management of UPS systems, to get UPS data via SNMP and display all available data and failures.

## About

This connector provides a monitoring interface to the **Generex UPS CS121 BC** device. It is based on the standard UPS MIB RFC 1628 MIB. The connector reacts to the 4 different traps that this device can send.

For more detailed information, see: <http://www.generex.de/generex/download/manuals/manual_CS121_en.pdf>

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Main View

This page displays general information on the device, for example **System Name**, **System** **Uptime**, .

### General

This page displays more general information as well as some performance indicators.

### Input

On this page, you can find information about the UPS input indicators.

### Output

On this page, you can find indicators of UPS output, similar to on the Input page.

### Bypass

This page displays information about the bypass system.

### Battery

This page displays information related to the battery status and health.

### Alarms

If there is any alarm present on the UPS, it will be shown here. As soon as there is an alarm, if traps are sent from the UPS, this table will be polled right away without waiting for the next poll.

### Test

This page displays information about future UPS tests. This information is also updated by a trap.

### Control

On this page, you can configure the UPS startup and shutdown.

### Configuration

On this page, you can configure settings related to the input, output and UPS timing.

### Site Manager

On this page, you can find information about the 8 configurable analog inputs, 8 digital inputs and 8 switchable relay contacs. It is also possible to view the 8 markers related to the alarm matrix, and the status of each of the site monitors.

### Transfer Switches

This page displays the settings for the automatic transfer switches.

### Auxiliary Ports

On this page, you can configure the auxiliary contacts to function as either an Input or an Output.

### Sensors

This page displays information about the sensor manager, which is a data measurement and collecting unit that allows the individual measurement and monitoring of 8 analog measurement devices (0-10V) and 4 digital alarm inputs or 4 outputs (open collectors).

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwiser it will not be possible to open the web interface.
