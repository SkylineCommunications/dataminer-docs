---
uid: Connector_help_British_Telecom_iVNP_3000
---

# British Telecom iVNP 3000

This connector can be used to display information of a **British Telecom iVNP 3000** device.

## About

This **SNMP** connector monitors the British Telecom iVNP 3000 platform.

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

### Card

This page displays the system's general information parameters.

- **Card Type**
- **Card SW Version**
- **Card Serial Number**
- **Card Description**
- **Card Alarm Status**
- **Card Destination OID**

The two page buttons at the top open the **Card Configuration** page and **History** page:

- The Card Configuration page displays the **Card Configuration Action** and **Configuration Error**. The Configuration Action consists of the buttons **Apply** and **Reset.**

- The History page shows the **iVNP History Log Table**, which has four columns:

- **Timestamp Event**
  - **Description Event**
  - **Duration Event**
  - **Status Event**

### Status

This page displays the **Switch Status** table, with the following parameters:

- **Alt Input Selected**
- **Output Loss Seconds Count**

Below this, the **Latency Monitor** table is displayed, which has the following columns:

- **Signal Present Alternate Input**
- **Signal Present IP Stream**
- **Absolute Latency**
- **Differential Latency**

### Management

The page displays the **Management Version** and **Management Statistics** parameters. These are the **Main**, **CLI**, **CGI** and **SNMP Module Version** and the **Fan Speed 1** and **2**, the **Temperature** and the **Alarm Status**.

Below that, you can find the **Power Supply Unit Table**, which displays the status of the different management PSUs.

This page contains the same page buttons as the Card page, which open the **Card Configuration** page and **History** page.

### Transport Status

This page contains five parameters related to the transport: **Network Loss Seconds Count**, **Good** and **Bad Mac Frame Count**, **Network Interface Physical Address** and **Network Interface Status**.

In addition, the page also displays Transport Interface parameters: the **IP Address**, **NetMask** and **Gateway**. You can set these three parameters on the **Transport Interface Configuration** subpage, via the **Configuration** page button at the top of the page.

### Encoder

This page displays two tables with information about the encoder.

The **Encoder Status** table displays the following information:

- **Input Sync Lock**
- **Input Bit Rate**
- **Input Alarm Status**
- **Input Loss Seconds Count**
- **Input Errored Seconds Count**
- **Input SES Seconds Count**

The **Encoder Configuration** table shows the **Input Status**, **TX** **Destination IP Address** and **Input** **Bit-Rate Ceiling**. You can set the values in this table in the **Pending Configuration** table, via the **Configuration** page button at the top of the page.

### Decoder

This page displays two tables with information about the decoder.

The **Decoder Status** table displays the following information:

- **Output Sync Lock**
- **Output Bit Rate**
- **Output Source IP Address**
- **Output Alarm Status**
- **Output Loss Seconds Count**
- **Output Errored Seconds Cout**
- **Output SES Seconds Count**
- **Output Post-FEC Los Packet Count**

The **Decoder Configuration** table shows the **Stream Decode Status**, **RX Destination IP Address** and **TX** **Source IP Address**. You can set the values in this table in the **Pending Configuration** table, via the **Configuration** page button at the top of the page.

### Traps

This page displays the traps received from the device and displays them in the **Trap Overview** table. The **row count** of this table is also displayed. Via the **Configuration** page button, you can set the **method of trap cleaning**, the **maximum count** and **maximum trap age**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

The configuration done by the user in the **Pending** **Configuration** table is only updated in the **Configuration** table after the **Apply** button is clicked on the **Card** **Configuration** pop-up page. Therefore, after you make changes in the Pending Configuration table, do not forget to use this button.
