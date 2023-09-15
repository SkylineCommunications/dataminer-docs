---
uid: Connector_help_Harris_Flexiva10KW_IRTFM_Np1
---

# Harris Flexiva10KW IRTFM Np1

With this connector, information can be gathered and viewed from the device **Harris Flexiva10KW IRTFM Np1**. The connector also makes it possible to set values on the device.

## About

This connector is used to gather information from the **Harris Flexiva10KW IRTFM Np1** device.

### Version Info

| **Range** | **Description**        |
|------------------|------------------------|
| 1.0.0.x          | Initial version        |
| 1.0.1.x          | Added support for DVEs |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.0.1.x          | N/A                         |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general parameters of the **Harris Flexiva10KW IRTFM Np1** device:

- **FNM Plus1 Local Mode**
- **FNM Plus1 Control Unit Fault**
- **FNM Plus1 Switch Over Ready**
- **FNM Plus1 Switch Over Executed**
- **FNM Plus1 Switch Over fault**
- **FNM Plus1 Event Transmitter Index**

The page also displays the following configurable parameters:

- **FNM Plus1 Redundancy Switch Over**
- **FNM Plus1 Switch Over Mode**
- **FNM Plus1 Channel Selection**

### Main Transmitter Page

This page displays parameters related to the **Main Transmitter**:

- **FNM Plus1 RTRF Program Present**
- **FNM Plus1 RTOp Mode**
- **FNM Plus1 Main Transmitter table**

The table has two control buttons:

- **Refresh:** Refreshes the table parameters.
- **Polling:** Activates or deactivates the automatic polling of the table parameters.

### Transmitter A Page

This page displays a table, the **FNM Plus1 Transmitter A table**, with information regarding **Transmitter A**. The table has two control buttons:

- **Refresh:** Refreshes the table parameters.
- **Polling:** Activates or deactivates the automatic polling of the table parameters.

### Transmitter B Page

This page displays parameters related to **Transmitter B**:

- **FNM Plus1 TBRF Present**
- **FNM Plus1 TB Local Mode**
- **FNM Plus1 TB Fault**
- **FNM Plus1 TB Warning**

### Traps Controller Page

This page allows the user to activate or deactivate the traps sent by the device. It includes the following parameters:

- **FNM Plus1 Redundancy Switch Over Enable**
- **FNM Plus1 Local Mode Enable**
- **FNM Plus1 Control Unit Fault Enable**
- **FNM Plus1 Switch Over Mode Enable**
- **FNM Plus1 Switch Over Ready Enable**
- **FNM Plus1 Switch Over Executed Enable**
- **FNM Plus1 Switch Over Fault Enable**
- **FNM Plus1 Channel Selection Enable**
- **FNM Plus1 Transmitter B Reset Enable**
- **FNM Plus1 Transmitter B Mode Enable**
- **FNM Plus1 RTOp Mode Enable**
- **FNM Plus1 RTRF Program Present Enable**
- **FNM Plus1 TBRF Present Enable**
- **FNM Plus1 TB Local Mode Enable**
- **FNM Plus1 TB Fault Enable**
- **FNM Plus1 TB Warning Enable**

This page also contains two page buttons, **Main Transmitter.** and **Transmitter A.**, via which you can enable or disable the traps related to these transmitters.

### Harris General Page

This page displays general information about the Harris device status:

- **Reserve Tx Status Dvr Input Ok**
- **Reserve Tx Status Ps Sum Fault**
- **Reserve Tx Status Ps Sum Warning**
- **Reserve Tx Status Out Reflected Power**
- **Reserve Tx Status Out VSWR**

### Harris Main Tx Table Page

This page displays the **Main Tx Table**. The table has two control buttons:

- **Refresh:** Refreshes the table parameters.
- **Polling:** Activates or deactivates the automatic polling of the table parameters.

The table contains the following columns:

- **Main Tx Ps Sum Fault**
- **Main Tx Ps Sum Warning**
- **Main Tx Monitor Mode**

### Harris Tx Status Table Page

This page displays the **Main Tx Status Table**. The table has two control buttons:

- **Refresh:** Refreshes the table parameters.
- **Polling:** Activates or deactivates the automatic polling of the table parameters.

The table contains the following columns:

- **Main Tx Status Svr Input Ok**
