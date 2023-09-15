---
uid: Connector_help_Egatel_CCU9000
---

# Egatel CCU9000

The Egatel CCU9000 is a control unit device that is used to manage other Egatel TV transmission equipment.

## About

The Egatel CCU9000 connector will communicate with the device via SNMP, enabling the remote configuration of control parameters of the managed modules (such as digital transmitters and a GPS module).

### Version Info

| **Range** | **Description**                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                     | No                  | Yes                     |
| 1.1.0.x          | New version to support Firmware V12 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |
| 1.1.0.x          | V12                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP settings:

- **Port number**: The IP port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general CCU system settings, including the definition of the destination **IP addresses** and of the **Control** and **Operation modes**.

It also allows you to activate or deactivate **failure flags** and shows the active and inactive **CCU system failures**.

With the **Reset** button, you can trigger a reset of the CCU.

### Transmitters

This page contains parameters that allow you to configure **transmission settings** and to monitor the **working behavior** of the transmitters (time on, etc.).

The page contains several page buttons that open **subpages** with information related to each of the transmitters. Each of the subpages contains general information for the relevant transmitter, as well as settings such as the **channel bandwidth**, current **output power** and **power thresholds**. There are also toggle buttons available for the **transmitter failure flags** and the current **failure states** of the transmitter are indicated.

### SDDD

This page displays **general power settings**, such as the overall Nominal Power value, the Reflected Power and the number of amplifiers being used.

There is also information available regarding the actual **power module operation**, such as the currently active exciter and the defined Output Power Threshold, and regarding the **rack internal temperature** and associated turbine info.

The page contains several page buttons:

- The **Amplifier** page buttons display information on the behavior of each of the power amplifiers, including the power that is produced and transduced, and the internal currents and voltages.
- The **Exciters** page button displays more information on each exciter (A and B) and the corresponding **failure flags** and **states**.

Finally, the page also contains toggle buttons to enable or disable the monitoring of the power module **failure states**, and the corresponding **status** values are displayed.

### GPS

This page contains the **GPS settings** and the **failure switch** and **status** info.

### Notification Table

This page contains a table with the **last 100 System Notifications** (SNMP traps). The polling of this info can be disabled.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
