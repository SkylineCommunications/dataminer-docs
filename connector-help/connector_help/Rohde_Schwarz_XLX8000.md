---
uid: Connector_help_Rohde_Schwarz_XLX8000
---

# Rohde Schwarz XLX8000

This connector has been developed for devices such as the **Rohde Schwarz XLX8000**. It polls several SNMP parameters and displays them on different pages. It also allows the user to configure certain settings. Traps are intercepted for status information.

## About

With three timers, all the **SNMP** parameters are polled and displayed on several pages. **Traps** are used to update the parameters on the **Status** page.

### Version Info

| **Range** | **Description**                                                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                            | Yes                 | Yes                     |
| 1.0.1.x          | Renamed single parameters and table column parameters to meet QA standards | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2100.4280                   |
| 1.0.1.x          | 2100.4280                   |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.250.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *broadcast*.

## Usage

### Status Page

The status information on this page is updated via traps. You can also clear every status parameter here.

This page also contains the **Events Transposer** page button, which displays alarm information in the **Events Transposer Table**.

### Input Page

This page contains the transposer setup, input status information and input configuration.

### Transposer Page

This page contains the filter and echo canceller configuration.

### RF Output Page

On this page, you can find amplifier, synthesizer, output, IQ adjust and precorrection settings.

### Reference Page

This page contains reference parameters.

### System Setup Page

This page contains general device information, as well as Tx and Rx settings. It also contains the following page buttons:

- **Product Information**: Displays information related to different modules in the **Product Information Table**.
- **Trap Settings**: Displays all the trap-related parameters and the **Trap Sink Table**.
- **RX1 Settings**: Displays the **Input 1 Settings Table**, which contains configuration parameters for Input 1.
- **RX2 Settings**: Displays the **Input 2 Settings Table**, which contains configuration parameters for Input 2.
- **Time Scheduler**: Displays all the time scheduling parameters in the **Time Scheduler Table**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
