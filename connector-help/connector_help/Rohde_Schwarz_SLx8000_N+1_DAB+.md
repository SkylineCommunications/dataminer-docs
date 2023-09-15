---
uid: Connector_help_Rohde_Schwarz_SLx8000_N+1_DAB+
---

# Rohde Schwarz SLx8000 N+1 DAB+

The **Rohde Schwarz SLx8000 N+1 DAB+** is a low-power transmitter. It is reliable, compact and flexible and fills coverage gaps in transmitter networks.

These features make it ideal for use at small, remote transmitter sites that offer only limited space, are difficult to access and are affected by strong variations in power supply. The compact device can be used as a transmitter or retransmitter.

## About

This is a transmitter controller. SNMPv1 is used to retrieve information from the device.

This connector allows you to manage both the DAB transmitter devices and the exciter itself.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.47.0                      |

### Exported connectors

| **Exported Connector**                                                                                                        | **Description**    |
|------------------------------------------------------------------------------------------------------------------------------|--------------------|
| [Rohde Schwarz SLx8000 N+1 DAB+ - Transmitter](xref:Connector_help_Rohde_Schwarz_SLx8000_N%2B1_DAB%2B_-_Transmitter) | Transmitter module |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: the polling IP of the device e.g. *10.11.12.13*

SNMP settings:

- **Port number**: the port of the connected device, by default *161.*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays **system information** as well as additional information on the status of the rack system.

Multiple buttons and page buttons are available:

- **Restart button**: Restarts the software of the transmitter control unit.
- **Events page button**: Opens a pop-up window with a table listing the events present on the device. For each event, the table displays the current **Event State**, **Priority** and **Mask**. You can set both the **Event Priority** and the **Event Mask**.
- **Device Info page button**: Opens a pop-up window with a table containing information on the **software** and **hardware** of each specific installed module.
- **NTP Server page button**: Opens a pop-up window with the NTP configuration settings for the device. Some of these settings can be modified, such as **NTP Mode** or **NTP Sync Time Interval**.
- **Software Update page button:** Opens a pop-up window with the software update settings for the device, such as **Software Update Mode**, **Device Name** and **Device Group**.

### Transmitter

This page displays information regarding the transmitter status. Separate summary information for **Exciter A** and **Exciter B** is also available. The two tables displayed on this page complement each other.

There are also two page buttons:

- **DVE Config**: Opens a pop-up window containing the **DVE Table**. This table displays a list of all transmitters on the device. It is possible to **Remove All** entries, **Remove Rows** or apply the **Automatic Removal** option.
- **Transmitter Events**: Opens a pop-up window that displays the **Transmitter Events Table** for every transmitter. Some information is available, such as the **Name**, **Mask** and **Priority**.

### Program

This page displays the **Program Table**. This table contains important values for programs. It also allows you to activate or deactivate individual programs.

### Exciter

This page provides information on each of the exciters. The available parameters can be used to evaluate the status of each individual exciter. This page also contains three page buttons:

- **Exciter Input**: This button displays a pop-up page that provides **input** information, such as **Channel Name**, **Sync State**, **Seamless** and **Preselected**.
- **Exciter Service Information**: This button displays a pop-up page that provides **service** information, such as **Short Label**, **Start Address**, **Protection Level** and **Uncoded Data Rate**.
- **Exciter Precorrection**: This button displays a pop-up page that provides precorrection information, such as **Linear Correction**, **User State**, **Factory State** and **Restore Current Settings**.

### DAB

This page displays the general DAB settings, such as **Local Mode**, **Switch Over Mode** and **Channel Selection**.

This page also contains two page buttons:

- **Main Transmitter**: Opens a pop-up window containing two tables, **Main Transmitter Table** and **Transmitter A Table**. The two tables displayed on this page complement each other.
- **Reverse Transmitter**: This button displays a pop-up page that provides **Reverse DAB** information, such as **Program Present**, **Local Mode**, **Input Automatic** and **Warning Time Stamp**.

### DAB Events

This page displays the general DAB Event settings, such as **Local Mode Status**, **Switch Over Mode Status** and **Channel Selection Status**.

This page also contains two page buttons:

- **Main Events:** Opens a pop-up window containing two tables, **Main Transmitter Events** and **Transmitter A Events**. The two tables displayed on this page complement each other.
- **Reverse Events**: This button displays a pop-up page that provides **Reverse DAB Events** information, such as **Program Present Status**, **Local Mode Status**, **Input Automatic Status** and **Warning Time Stamp Status**.

### DAB Priority

This page displays the general DAB Priority settings, such as **Local Mode Priority**, **Switch Over Mode Priority** and **Channel Selection Priority**.

This page also contains two page buttons:

- **Main Priority Events:** Opens a pop-up window containing two tables, **Main Transmitter Priority** and **Transmitter A Priority**. The two tables displayed on this page complement each other.
- **Reverse Priority Events:** This button displays a pop-up page that provides **Reverse DAB Priority Events** information, such as **Program Present Priority**, **Local Mode Priority**, **Input Automatic Priority** and **Warning Time Stamp Priority**.

### Switch Over Unit

This page displays information on redundancy and switchover capabilities. This page allows you to configure the various parameters used to determine and trigger the switchover of the device.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
