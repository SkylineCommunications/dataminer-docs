---
uid: Connector_help_CEFD_CDM_Qx
---

# CEFD CDM Qx

The CDM-Qx Multi-Channel Satellite Modem provides DoubleTalk Carrier-in-Carrier bandwidth compression capability, allowing transmit and receive carriers of a full-duplex satellite link to share the same transponder space.

## About

The CEFD CDM Qx connector allows the user to monitor and control a Comtech EF-Data CDM Qx device. The connector uses an **SNMP** and a **serial** connection to retrieve data from and set data on the device. The different device parameters are displayed on multiple pages according to subject.

## Installation and configuration

### Creation

This connector uses an SNMP connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The IP port of the device, e.g. *4000*.
- **Bus address**: The bus address of the device, e.g. *30*.

## Usage

### Main View page

This page contains three parameters: **Circuit** **ID**, **Unit** **Summary** **Alarm** and **Last** **Trap** **Since**.

### General page

On this page, the general parameters of the device are displayed. Some of these parameters can also be set to a preferred value.

The **Store** **Configuration** parameter causes the device to store the current modem configuration in a configuration memory location defined by the argument (*0* to *9*).

The **Load** **Configuration** parameter causes the device to retrieve a previously stored modem configuration from the configuration memory location defined by the argument (*0* to *9*).

Four page buttons are available at the bottom of the page. These each open a pop-up page with additional information regarding the subject described on the page button in question.

### Test Mode Config page

This page contains the **Tx Test Config** table.

For each row in the table, the **Tx** **Unit** **Test** **Mode** can be set.

### Modulator page

This page contains three tables:

- **Tx** **Status**: Displays the transmit status.
- **Tx** **Primary** **Settings**: Displays the primary settings of the transmission.
- **Tx** **Additional** **Settings**: Displays additional settings of the transmission.

### Demodulator page

This page contains three tables:

- **Rx** **Status**: Displays the receiver status.
- **Rx** **Primary** **Settings**: Displays the primary settings of the receiver.
- **Rx** **Additional** **Settings**: Displays additional settings of the receiver.

### Save / Load Configuration

On this page, you can save all parameter values to a .csv file. Afterwards, this same file can then be loaded, so that all parameters are set to the saved values.

- By default, the file will be stored in this folder: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\\PROTOCOLNAME\]*
- By default, the file will be named as follows: *backup_ELEMENTNAME_datetime*

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
