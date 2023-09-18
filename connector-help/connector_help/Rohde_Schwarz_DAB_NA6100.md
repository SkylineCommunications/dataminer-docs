---
uid: Connector_help_Rohde_Schwarz_DAB_NA6100
---

# Rohde Schwarz DAB NA6100

DAB transmitter monitoring (including power values, exciter and amplifier states, input signal states, CCU monitoring, summary faults) with automatic input selection.

## About

This is an **SNMP** protocol. Traps are not implemented.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Configuration of the Output Power Percentage parameter

After element creation, the **Output Power Percentage** parameter will not yet be correct.
To correctly compute this parameter, the **Nominal Power** parameter must be set on the **General** page.

## Usage

### General

This page displays a number of status parameters, as well as two configuration parameters: **Operational Mode Tx** and **Selected Input**.

There is also a **Nominal** **Power** parameter, which can be configured with the expected output power for the transmitter. Once this parameter has been set, the **Output Power Percentage** parameter will contain the **Forward Power** multiplied by *100* and then divided by the **Nominal Power**.
Note: as long as this parameter has not been set, the calculated percentage will show *Infinity.*

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
