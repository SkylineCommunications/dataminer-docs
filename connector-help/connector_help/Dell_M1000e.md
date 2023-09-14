---
uid: Connector_help_Dell_M1000e
---

# Dell M1000e

The **Dell M1000e** connector is designed to monitor a Dell M1000e blade server

## About

The connector uses **SNMP** to retrieve data from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.30                        |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page contains general device information, such as the **Name**, the **Firmware version**, the **Chassis Location**, the **Manufacturer**, etc.

It also displays a list of parameters indicating the current status of the different monitored modules.

### Power Tables Page

This page displays the following tables with information relating to power parameters:

- **CMC Power Table:** Displays electric values related to the chassis, such as the **Potential Power**, **Amps reading**, **Watts reading**, etc.
- **CMC Power Supply Unit Table**: Displays electric values related to the power supply units and information such as the **Location** and the **Monitoring Capabilities**.

### Traps Page

This page displays the **Traps Table**, which contains information about all the traps that have been received.

In addition, the page contains the configurable parameter **Trap Sources**, which allows you to configure specific SNMP sources, a **Traps Number** counter and a **Clear Table** button.

With the **Configuration** page button, you can open a pop-up page with the following generic parameters:

- **Traps Filter Status**: A configurable parameter to enable/disable a filter for displayed traps.

- **Traps Max Number**: The maximum number of traps that can be displayed. This value will only be used if the Trap Filter is enabled.

- **Traps Clean Up Amount**: The number of oldest traps removed from the Traps Table when the maximum is reached

- **Traps Clean Up Method**: There are three possible ways to clean up the Traps Table:

- Based on the number of rows. (Option Row Count.)
  - Based on how long the alarm has existed. (Option Trap Age.)
  - Based on a combination of both. In this case, the check on the 'Row Count' is done first. (Option Combo.)

- **Max Age Traps**: The maximum age of a trap allowed in the Traps Table.
