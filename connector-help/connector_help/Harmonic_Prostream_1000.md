---
uid: Connector_help_Harmonic_Prostream_1000
---

# Harmonic ProStream 1000

The ProStream 1000 stream processing platform is the ideal solution for multiplexing and scrambling of SD or HD video and audio services.

## About

This connector is intended to communicate with the device using SNMP and serial commands. Serial port is used to get information using HTTP GET and POST commands.

### Version Info

| **Range** | **Description**                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version                              | No                  | No                      |
| 1.0.1.x          | Addition of GbE stream and auto trap removal | No                  | Yes                     |
| 1.0.2.x          | DCF Support                                  | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                       |
|------------------|---------------------------------------------------|
| 1.0.0.x          | Software Version: 06.07.04.004 Boot Version 3.0.4 |
| 1.0.1.x          | Software Version: 06.07.04.004 Boot Version 3.0.4 |
| 1.0.2.x          | Software Version: 06.07.04.004 Boot Version 3.0.4 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

#### Serial serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

## Usage

### General

Use this page to access information about **Ethernet 1**, **2** and **3** Ports and also to **Main Card** related parameters.

Use the **Credentials ...** page button to set the login credentials. They must be the same as the ones used to access the web interface page.

### TreeView

Tree view of the cards available in the **Cards** page organized by name.

### Viewer

Use this page to save/restore XML configuration file. Write the name of the file in the **XML File To Send** field (use the name of the file plus ".xml" extension). The file must be available in the "*C:\Skyline DataMiner\Documents\Harmonic ProStream 1000\\*" folder. After that, press the **Send** button.

### Slots

This page shows how each slot in the back panel of the device is being used.

### Cards

This page will show for each type of card its related information.

### Ports

In this page is shown, for each **ASI** and **GbE** **Port** installed in the device, information about its ports.

### Ts In

**GbE Input AP** and **Input Ts** **Tables** are available here.

### Ts Out

**ASI Output AP, GbE Output AP** and **Output Ts** **Tables** are available here.

### E5

In this page is available the **E5 Table**.

### Recoders

In this page is present the **Recorder Table**.

### Counters

In this page is present the **Counters Tsin Table**.

## Services

**Config** **Service** **Input**, **Service Input** and **Service** **Output** **Tables** are present in the page.

### Streams

**Stream Input List**, **Service Stream Input List** and **Stream Output** **Tables** are available in this page.

### Cat

Allocated **CAT EMM**, and **CAT** **PIDs** are available in this page.

### Alarms

Table related with alarming are present in this page. With the button to enable and disable polling of SNMP. There is also a page button at the top when clicked it will open a new window to customize the time for the auto removal of traps.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
