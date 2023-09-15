---
uid: Connector_help_RedRat_irNetBox
---

# RedRat irNetBox

The **RedRat irNetBox-III** is a networked unit with 16 outputs, which allows you to **control multiple AV devices** via external **IR** emitter leads.

## About

The **RedRat irNetBox protocol** uses a simple TCP/IP connection to transmit **serial commands**.

The purpose of this connector is to allow the user to import several **devices** and **definitions** from an **XML** file and then manually select which device is connected to each **output**.

It is also possible to import **channel** information and then manually select to switch to a channel.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version | No                  | Yes                     |
| 1.0.1.x \[SLC_Main\] | DCF integration | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                     |
|------------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x          | MKIII 2.1.2 'Saulire' (c) RedRat Ltd 2013, USB-IF 1.01- irNetBox Network Control Protocol V3.03 |
| 1.0.1.x          | MKIII 2.1.2 'Saulire' (c) RedRat Ltd 2013, USB-IF 1.01- irNetBox Network Control Protocol V3.03 |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: *10001*
  - **Bus address**: *byPassProxy*

## Usage

### General

This page contains two main sections:

- **General Information**: Contains the firmware version, serial number, USB vendor ID, product ID, product version ID and error description.
- **Signal Capture Parameters**: Provides information about the **signal sampling algorithm**. There is also a button that can be used to **manually reset** these parameters to their **default state**.

### Device Overview

This page contains a large **Device Overview** table, which contains **imported IR AV device definitions**.

Each device can be given a **custom name** to increase user-friendliness. Devices can be deleted from the protocol by means of the **Delete** button in each row. The device information is then removed from the Device Overview table and from the Definitions Overview table.

This page also contains two page buttons:

- **Import**: Can be used to import devices. When this subpage is opened, by default, the connector automatically checks for XML files in the Documents folder. You can customize the folder where the connector checks by specifying a different path. You can select a device file name in a drop-down menu. If you then click the **Import** button, the connector will process the XML file and add the information to the **Device Overview** table. The device definitions (commands) are added to the **Device Definitions** table. In case of errors, you will be notified with a message.
- **Definitions**: Opens a subpage with a **tree control** that can be used to easily navigate through all devices and definitions by clicking on the branches.

### Output Overview

This page contains a large **Output Overview** table, which contains a row for each **physical IR output on the irNetBox**. Each output can be given a custom name to increase user-friendliness.

For each output, you can **select which device is connected** via a drop-down menu that contains all custom device names. When you select a device, the command drop-down menu is automatically updated with all the commands for the specific device. When you **select a command** from the drop-down menu, that command is **directly sent to the irNetBox**.

From version 1.0.1.2 onwards, at the top of the page, a parameter is available that can be used to specify the **DVE Name Format** with the following options:

- **Default**: The DVE name format is the default "ElementName.OutputPort".
- **Custom Name**: The DVE name is "Output Name" if there is a custom name and it is not the same as the port; otherwise the DVE name will be the default "ElementName.OutputPort".

### Channel Overview

This page contains a large **Channel Overview** table, which contains **imported channels**. Each channel row has a channel number and 16 columns, which represent the **physical IR outputs with buttons**. When you **click a button**, the protocol will **send the channel number to the IR output of the irNetBox** with the correct commands for the device that is connected to the output. If you press a button for an output for which no device is selected, you will be notified with a message.

This page also contains a page button:

- **Import**: Can be used to import channels. When this subpage is opened, by default, the connector automatically checks for CSV files in the Documents folder. You can customize the folder where the connector checks by specifying a different path. You can select a channel file name in a drop-down menu. If you then click the **Import** button, the connector will process the CSV file and add the information to the **Channel Overview** table. In case of errors, you will be notified with a message. In addition, a channel list can be deleted via the parameter **Delete Device Channel List**. To do so, select the channel list in the drop-down box and click the save option. The channel list will then be deleted.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the RedRat irNetBox protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

Note that DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- Output: **parameter 600, out**.

### Connections

There are no connections.
