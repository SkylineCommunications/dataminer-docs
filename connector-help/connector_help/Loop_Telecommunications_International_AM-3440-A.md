---
uid: Connector_help_Loop_Telecommunications_International_AM-3440-A
---

# Loop Telecommunications International AM-3440-A

The Loop-AM3440-A/B/C series are Access DCS-MUXs that combine various digital access interfaces into E1 or T1 lines for convenient transport and switching. The Loop-AM3440 Access DCS-MUX provides access for a variety of TDM, IP and voice interfaces.

## About

This is an SNMP connector. It gets the information from the chassis and the connected cards. The chassis has 12 standard slots and 4 mini slots. The slot indexes range from 1 to 16, starting with the mini slots. The mini slots from 1 to 4 are named A, B, C and D, and the standard slots from 5 to 16 are named by number, starting at 1.

The communication method used is SNMP version 1.

Note: This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 0062                        |

### Exported connectors

| **Exported Connector**                                                                                                                              | **Description**               |
|----------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------|
| [Loop Telecommunications International AM-3440-A - FXO](xref:Connector_help_Loop_Telecommunications_International_AM-3440-A_-_FXO)       | Voice interface. 12 channels. |
| [Loop Telecommunications International AM-3440-A - 4EM](xref:Connector_help_Loop_Telecommunications_International_AM-3440-A_-_4EM)       | Four E&M voice interfaces.    |
| [Loop Telecommunications International AM-3440-A - 8EM](xref:Connector_help_Loop_Telecommunications_International_AM-3440-A_-_8EM)       | Eight E&M voice interfaces.   |
| [Loop Telecommunications International AM-3440-A - QuadE1](xref:Connector_help_Loop_Telecommunications_International_AM-3440-A_-_QuadE1) | E1 interfaces.                |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page contains information about the chassis system, main board and redundant board, such as the **System Description**, **System** **Up Time**, **System Date and Time**, **System Contact**, **System Name** and **System Location**, the **Main Board Serial Number**, **Main Board Hardware Version,** **Main Board Firmware Version** and the same parameters for the redundant board. It also displays information about the **Console Status** and **Support Small Voice Card.**

### Slots

This page contains the **Slots Table**, with information about the connected cards. It also contains the DVE management functionality to enable or disable the automatic removal of deleted modules, as well as the manual option to remove a deleted module or all deleted modules.

The page allows you to set the DVE creation option for each module separately or for all modules at once, and contains page buttons that display the DVE tables.

### FXO

This page contains a number of tables representing the port status of the FXO module:

- FXO Port Status Ringing Table
- FXO Port Status Off Hook Table
- FXO Port Status Tip Open Table
- FXO Port Status Line Broken Table
- FXO Port Status Ring-Ground Table
- FXO Port Status Battery-Reverse Table
- FXO Port Status Pulse-On Table
- FXO Port Status Alarm-On Table

### 4 E & M

This page contains the **QEM Status Table**, which displays the state of the **E LEDs, M LEDs, Alarms, Power** and **48V Support**.

### 8 E & M

This page contains the **EM Diagnostic Control Table**, which displays the state of the **E LEDs**, **M LEDs, TEST**, **Test Button Availability**, **Power** and **Up Link Status**.

### Quad E1

This page contains the **MQE1 Line Control Table**, which displays the state of the **Line Coding**, **Sa_bit, AIS**, **RAI, CRC, Idle Code, CAS Mode, Signaling Mode, CGA, Out of Service, Protect** and **Master**.
