---
uid: Connector_help_Rohde_Schwarz_NSU
---

# Rohde & Schwarz NSU

The Rohde & Schwarz NSU is a control console for transmitters. This connector allows you to retrieve information from the device and **get and set data** on the modules listed below. It also acts as an event receiver for **SNMP traps**.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |
| 2.0.0.x   | DVEs added.      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                        |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Yes                 | No                      | \-                    | \-                                                                                             |
| 2.0.0.x   | Yes                 | Yes                     | \-                    | [Rohde Schwarz NSU - Transmitter](xref:Connector_help_Rohde_Schwarz_NSU_-_Transmitter) |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: the polling IP of the device e.g. *10.11.12.13*

SNMP Settings:

- **Port number**: the port of the connected device, by default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use - range 1.0.0.x

### General Page

This page displays **system information** as well as additional data on the status of the rack system.

Multiple buttons and page buttons are available:

- **Restart**: Restarts the software of the transmitter control unit.
- **Reset All Faults**: Resets all faults (in all modules) of the transmitter. An equivalent action would be to press RESET at the transmitter front panel.
- **Device Info:** Displays the product info table, with information on the software and hardware of each specific installed module.
- **NTP Server:** Displays the NTP configuration settings for the device. You can change these settings on this page.
- **Software Update:** Displays the software update settings for the device.

The page also displays two tables:

- **NSU Events Table:** Lists the NSU events present on the device. The available information includes the current **Event State**, **Event Priority** and **Event Mask**. You can set both the **Event Priority** and **Event Mask**.
- **Program Events Table**: Displays the configured program events of the device.

### Transmitter Page

This page displays information regarding the transmitter status. Separate summary information for both **Exciter A** and **Exciter B** is also available. The two tables displayed on this page complement each other.

There are also two page buttons:

- **Tx Events:** Displays the Tx Events Table, which lists all existing events on the device. This table is polled from the device on startup and the values are refreshed every time a trap is received. You can set the **Event Tx Mask** value for the event as well as the **Event Priority.**
- **RF Probes:** Displays the RF Probes tables. These tables complement each other and display information on existing RF probes.

### Transmitter Settings Page

This page provides information on the transmitter settings.

The **OST Settings** page button displays the **OST Table**, which contains important information on the **Output Stage** of the transmitters.

### Exciter Status Page

This page displays information regarding the available exciters. It contains two tables:

- **ISDBT Exciter Input Table:** This is an **ISDBT device table**, which means that elements with polling device set to *DVB* will not poll this table. The table provides information related to the inputs of each exciter.
- **Exciter Status Table:** This table provides information on the status of each individual exciter (A and B). The information on this page is also used to calculate the **SFN Delay parameters**.

There is also one page button, **SFN Delay**, which displays the calculated SFN delay parameters. The SFN values from the **Exciter Status Table** are used to calculate the absolute difference (delay) between exciters A and B.

### Exciter Settings Page

This page displays the **Exciter Pre-Correction Table** as well as the **ISDBT Transmission** and **Multiplexing Configuration Control Table**. These provide useful information on the exciters and allow you to set various parameters for each exciter.

### Program Page

This page displays the **Program Table**. This table contains important values for programs. It also allows you to activate or deactivate individual programs.

### Exciter Page

This page provides information on each of the exciters. The available parameters can be used to evaluate the status of each individual exciter. This page also contains two different page buttons:

- **SFN:** Displays SFN information in the **Exciter Status Delta Table**.
- **Exciter Events:** Displays SFN information in the **Exciter Events Table**. This table displays information on existing exciter events.

### Exciter Settings Page

This page displays information on the configuration and settings of each individual exciter (A and B). There are also two page buttons available on this page:

- **Exciter Pre-Corr Settings:** Displays both Exciter Pre-corrector Settings Tables. These tables provide useful information for monitoring.
- **Trans and Multiplexing:** Displays the Transmission and Multiplexing Configuration Control Table.

### Amplifier Page

This page provides summary information on the available amplifiers. This information can be used to monitor the status of the available amplifiers. There are several tables available on this page:

- **Rack Status Table:** This table provides information on each available transmitter, including temperatures and auxiliary power supply voltage.
- **Amplifier Status Tables:** These two tables complement one another and provide information on each amplifier per transmitter. The tables display voltage and electric current values as well as temperature values.

### Pump Unit Page

On this page, the **Pump Unit Events Table** is displayed. This table displays all the existing **Pump Unit Events** and their current state. The operator can set the **Event Mask** and **Event Priority** for each individual event. Like for other event tables, when a relevant trap is received, the corresponding event is polled again from the device in order to refresh its state.

### Switch Over Unit Page

This page displays information on redundancy and switchover capabilities. This page allows you to configure the various parameters used to determine and trigger the switchover of the device.

## How to Use - range 2.0.0.x

### General Page

This page displays **system information** as well as additional data on the status of the rack system.

Multiple buttons and page buttons are available:

- **Device Info Page Button:** Displays the product info table, with information on the software and hardware of each specific installed module.
- **NTP Server Page Button:** Displays the NTP configuration settings for the device. You can change these settings on this page.
- **NSU Events Page Button:** Displays the table of NSU events present on the device. The available information includes the current **Event State**, **Event Priority** and **Event Mask**. You can set both the **Event Priority** and **Event Mask**.
- **Software Update Page Button:** Displays the software update settings for the device.

### Transmitter Page

This page displays information regarding the transmitter status. Two tables, **Transmitter Status** and **Transmitter Settings**, are shown.

There are also several page buttons:

- **Events:** Displays the **Tx Events Table**, which lists all existing events on the device. This table is polled from the device on startup and the values are refreshed every time a trap is received. You can set the **Event Tx Mask** value for the event as well as the **Event Priority.**
- **RF Probes:** Displays the RF Probes tables. These tables complement each other and display information on existing RF probes.
- **OST:** Displays the **OST Commands Table**.
- **DVE Config**: Contains the **Automatic Removal** toggle button, which determines whether DVEs are automatically removed when the corresponding module is no longer available, as well as a button to **Remove All** DVEs.
- **Exciter Frequency**: Displays the **Commands Table**.

### Program Page

This page displays the **Program Table**. This table contains important values for programs. It also allows you to activate or deactivate individual programs.

### Rack + Amplifier Page

This page provides summary information on the available amplifiers. This information can be used to monitor the status of the available amplifiers. There are several tables available on this page:

- **Rack Status Table:** This table provides information on each available transmitter, including temperatures and auxiliary power supply voltage.
- **Amplifier Status Tables:** These two tables complement one another and provide information on each amplifier per transmitter. The tables display voltage and electric current values as well as temperature values.

### Switch Over Unit Page

This page displays information on redundancy and switchover capabilities. This page allows you to configure the various parameters used to determine and trigger the switchover of the device.
