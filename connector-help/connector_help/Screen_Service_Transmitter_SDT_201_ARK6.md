---
uid: Connector_help_Screen_Service_Transmitter_SDT_201_ARK6
---

# Screen Service Transmitter SDT 201 ARK6

This connector is designed to communicate with transmitters using the DVB-T2 and Digital Repeater modes.

## About

The connector communicates with the device using **SNMP**, to change its configuration and to monitor its channel, power and modulation parameters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                            |
|------------------|------------------------------------------------------------------------|
| 1.0.0.x          | UC: *4.34* FPGA: *1.42* AL_BOARD: *1.4* GPS_BOARD: *8.47* SNMP: *2.15* |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default e.g. *public*.
- **Set community string:** The community string used when setting values on the device, by default e.g. *private*.

## Usage

### Home Page

This page contains general parameters that can be used to configure the device (**Transmission Mode**, **Station Identifier**, **LCD Stand-by**, **Reset**, and **Modes Management**).

### Input Section

On this page, you can monitor the **Word Rate**, **Input Bitrate**, **Filtered Bitrate**, etc. of the transmitter interfaces.

### Front End

This page displays all the parameters related to the front end. You can check the status using parameters such as **Carrier Offset**, **SNR**, **Signal Quality** or **Bitrate**.

Pre-signaling parameters are also monitored, such as **Input Stream Type**, **FFT Size, Modulation Scheme**, **Code Rate**, etc.

Finally, the page also displays the configuration, as well as post-configuration parameters like **FEF Type**.

### DVB-T2 Processing

This page allows you to manage important parameters related to the DVB-T2: **Input Selection or Output Channel and Power**.

You can also enable the **Input Autoswitch** and check the associated parameters (**Primary to Secondary Switch Counter**, ...).

### DVB-T2 Modulation Section

On this page, you can set DVB-T2 modulation parameters such as **Parameters Source** or **T2-MI PID Mode**.

The **Pre Signaling** and **Post Configuration** can be changed via page buttons.

If you change parameters, the new configuration is automatically updated in the *T2-MI* mode. However, in case the change is not taken into account, you can press the **Load Configuration** button.

### DVB-T2 Measure

This section provides measuring results of the modulation parameters configured in the preceding pages.

### Echo Settings

On this page, you can manage the alarm thresholds, using the parameters **Signal Quality Thresholds** and **MER Threshold**. "FE" and "Measure" thresholds can also be configured on this page.

### Echo Canceller

On this page, you can manage the **Threshold Fold Back** parameters and monitor the **Input** and **Residual Output Powers**, among others.

The **Clear Coefficient** button allows you to reset the Echo Correction coefficients.

### Output Section

On this page, you can select the **Frequency Reference**, view the **Optocouplers and Relays status**, change the **Output Power**, monitor the **Temperatures**, **FANs Speeds**, **Power Supplies (PS) Voltages** and **Currents**, and manage **Reflex Power** parameters.

You can also do **Resets** and adapt **Forward Power** and **Temperatures Alarming Thresholds** when necessary. The **Reset** button is used to reset the amplifier stage when it is switched off due to a Reflex Power High alarm.

### Network Status

This page displays information and statistics about the network interfaces of the device (**IP address**, **MAC address**, **Network Speed**, **Entered Packets count**, ...).

### Network Tx

On this page, you can select the **Source Port**, enable/disable the **ARP Keep Alive** option, and modify several parameters related to the **Output Channels** (**Destination IP**, **Destination Port**, **Protocol**, **Source Clock Reference**).

### Network Rx

This page allows you to enable or disable **IGMP** and to modify the input configuration **IP address**, **Local Port** or **Source Clock Reference**.

### SNMP Management Section

This page displays the **SNMP Management Addresses**, as well the associated **Mode**, **Delay** and **Delay Status** information.

### GPS Section

This page displays all GPS information (**Latitude**, **Longitude**, **UTC Date**, ...).

It also allows you to adjust the **GPS Frequency** and **Time Source** (for synchronization), check the **OCXO Status**, manage the **Holdover Mode** and configure the **NTP Server IP Address**.

### Alarms Section

This page displays generated alarms. It is possible to enable the sending of alarm traps to one or more **Alarm Trap Managers**. You can also configure whether the alarms will be displayed on the **LCD screen**, on the **Java Alarm Page Icon**, etc.

### Events Section

This page displays a table with generated events.

### Webpage

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
