---
uid: Connector_help_British_Telecom_iVNP_4000
---

# British Telecom iVNP 4000

This connector can be used to display information of a **British Telecom iVNP 4000** device.

## About

This **SNMP** connector monitors the British Telecom iVNP 4000 platform.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General

This page displays the system's general information parameters such as the **IVNP Type**, **Release Version**, **Serial Number** and **System Name.**

### Chassis

This page displays the system's temperatures and power supply units. The **Main** **FPGA** **Temperature** and **Chassis** **Temperature** are displayed as separate parameters. The different **FPGA** **Temperatures** can be found in the **I/O** **FPGA** **Temperature** table.

In the **Power** **Supply** **Unit** Table, the **Error** **Statuses** are displayed for each unit.

### Network

This page displays the **Network Interface** table and the **Cross Strap Interface** table. The former displays the **Physical Address** and **Network Status**, the latter contains the **Cross Strap Status**.

### Encoder

This page displays the inputs in the **Encoder** **Status** table:

- **Encoder Sync Lock**
- **Encoder Rate**
- **Encoder Loss Seconds Count**
- **Encoder Errored Seconds Count**
- **Encoder SES Seconds Count**
- **Encoder Alarm Status**
- **Encoder Physical Alarm**
- **Encoder Cross Strap Alarm**
- **Encoder Switch Alarm**
- **Encoder Misc Alarm**

The page also contains the **Encoder Configuration** table, which displays the **Service Name**, **Status**, **VLAN Assignment**, **Destination IP Address**, **UDP Port**, **Test Mode** and **Generic Config String**. You can set the values in this table in the **Pending Configuration** table, via the **Configuration** page button at the top of the page.

### Decoder

This page displays the outputs in the **Decoder Status** table, which has the following columns:

- **Decoder Sync Lock**
- **Decoder Rate**
- **Decoder Source IP Address**
- **Decoder Loss Seconds Count**
- **Decoder Errored Seconds Count**
- **Decoder SES Seconds Count**
- **Decoder Post-FEC Lost Packet Count**
- **Decoder Alarm Status**
- **Decoder IP Stream Alarm**
- **Decoder Cross Strap Alarm**
- **Decoder Switch Alarm**
- **Decoder Misc Alarm**

The page also contains the **Decoder Configuration** table, which displays the **Service Name**, **Status**, **VLAN** **Assignment**, **Destination IP** **Address**, **UDP Port**, **Test Mode** and **Generic Config String**. You can set the values in this table in the **Pending Configuration** table, via the **Configuration** page button at the top of the page.

### Switch Status

This page displays the **Encoder** and **Decoder Switch Status** tables, which both contain the following parameters:

- **Selected Input**
- **Out Loss Seconds Count**
- **Sync Lock**

### Channel

This page displays the **Channel Mode** table. Via the **Configuration** page button, you can also access the **Channel Mode Configuration** table. Both tables have a **Mode Status** column.

### Traps

This page displays the traps received from the device and displays them in the **Trap Overview** table. The **row count** of this table is also displayed. Via the **Configuration** page button, you can set the **method of trap cleaning**, the **maximum count** and **maximum trap age**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
