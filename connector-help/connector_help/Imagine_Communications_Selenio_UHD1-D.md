---
uid: Connector_help_Imagine_Communications_Selenio_UHD1-D
---

# Imagine Communications Selenio UHD1-D

The **Selenio UHD1** is a package containing a main application front module, a submodule plug-in, and a back module. The UHD1-D is a single-channel quad-link UHD-1-to-3G/HD/SD-SDI downconverter and frame synchronizer with embedded audio processing. Each SEL-UHD1 package includes a front module, submodule, and single back module with two HD-BNC SDI input connectors, two SDI inputs on SFP (one SFP+2ERX+NR+L dual HD-BNC input SFP is included), four HD-BNC SDI outputs, and a GPI/serial data port.

## About

This is an SNMP connector that implements the so-called "**dirty count**" mechanism for **polling**. This means that DataMiner does not actively poll the device, but instead only polls a table with all the parameters that have changed and then polls those OIDs. This table is polled every second. It is also important to note that this connector does not retrieve information for the entire shelf, but **only for the single boards** within, so the **board ID** will need to be provided in the field "**bus address**" when the element is created.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The board ID of the board this element is going to monitor.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Status

This page displays information about the **temperature** of the different components and the **hardware** and **firmware versions** of the different components. It also allows you to set the **reference standard** and the **reference lock mode**.

### Proc Amp Embedder 1

On this page, you can adjust the **gain**, **invert**, **mute**, **word length and format** for each **embedder 1**.

### Proc Amp Embedder 2

On this page, you can adjust the **gain**, **invert**, **mute**, **word length and format** for each **embedder 2**.

### Proc Amp Embedder 3

On this page, you can adjust the **gain**, **invert**, **mute**, **word length and format** for each **embedder 3**.

### Proc Amp Embedder 4

On this page, you can adjust the **gain**, **invert**, **mute**, **word length and format** for each **embedder 4**.

### Proc Amp and Color Corrector

On this page, you can adjust the gain for each **color component** of the **output channels** and configure other miscellaneous color settings, such as locking the **RGB offset controls**.

### Audio & Video TSG

This page contains information about the **test tones**.

### Input Delay and Sync

On this page, you can manage the **delay** options for every **audio channel**.

### Output Routing and Delay

On this page, you can select the **source** for every **output**.

### Input Control and Status

On this page, you can **control the inputs** and view their **status**.

### Video Input

This page displays information about the status of the **video** and **audio** in the inputs and the **CRC errors** associated with them.

### Video Output and Routing

On this page, you can set the conversion options, such as **TXX source**, the conversion output for **SDI inputs**, and the **downconversion output standard**.

### Video Sync and Delay

On this page, you can **control the frame sync options**, such as the actual video delay in frames. The page also displays whether the frame sync is frozen and allows you to set the frozen output video.

### Conversion and Advanced Video Processing

On this page, you can manage the **conversion options**.

### Web Interface

This device has a management web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the Imagine Communications Selenio 1UHD1 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Fixed interfaces

Virtual fixed interfaces:

- Top Left: parameter 1055, **inout**
- Top Right: parameter 1056, **inout**
- Bottom Left: parameter 1057, **inout**
- Bottom Right: parameter 1058, **inout**
- Link 1: parameter 1269, **inout**
- Link 2: parameter 1270, **inout**
- Link 3: parameter 1271, **inout**
- Link 4: parameter 1272, **inout**

Physical fixed interfaces:

- SDI Input 1: **in**
- SDI Input 2: **in**
- SDI Input 3: **in**
- SDI Input 4: **in**
- SDI Output 1: parameter 1120, **out**
- SDI Output 2: parameter 1121, **out**
- SDI Output 3: parameter 1122, **out**
- SDI Output 4: parameter 1123, **out**

### Connections

Internal connections:

- Between **SDI Input 1 - 4 and Top Left**, an external connection is created.
- Between **SDI Input 1 - 4 and Top Right**, an external connection is created.
- Between **SDI Input 1 - 4 and Bottom Left**, an external connection is created.
- Between **SDI Input 1 - 4 and Bottom Right**, an external connection is created.
- Between **SDI Input 1 - 4 and Link 1**, an external connection is created.
- Between **SDI Input 1 - 4 and Link 2**, an external connection is created.
- Between **SDI Input 1 - 4 and Link 3**, an external connection is created.
- Between **SDI Input 1 - 4 and Link 4**, an external connection is created.
- Between **Top Left and SDI Output 1-4**, an external connection is created.
- Between **Top Right and SDI Output 1-4**, an external connection is created.
- Between **Bottom Left and SDI Output 1-4**, an external connection is created.
- Between **Bottom Right and SDI Output 1-4**, an external connection is created.
- Between **Link 1 and SDI Output 1-4**, an external connection is created.
- Between **Link 2 and SDI Output 1-4**, an external connection is created.
- Between **Link 3 and SDI Output 1-4**, an external connection is created.
- Between **Link 4 and SDI Output 1-4**, an external connection is created.
