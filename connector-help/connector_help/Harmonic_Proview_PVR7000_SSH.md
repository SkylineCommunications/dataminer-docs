---
uid: Connector_help_Harmonic_Proview_PVR7000_SSH
---

# Harmonic Proview PVR7000 SSH

The **Harmonic Proview PVR7000 SSH** is a single-rack-unit scalable receiver, DVB descrambler, multi-format video decoder/transcoder and MPEG stream processor.

## About

This connector is used for controlling and monitoring the Harmonic Proview PVR7000 via SSH.

### Version Info

| **Range** | **Description**                                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. Uses serial connection to retrieve alarm and input information | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and creation

### Creation

This connector uses an **SNMP** and/or **serial** connection and requires the following input during element creation:

#### SNMP connection

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial connection

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: 23 (telnet) or 22 (SSH)

## Usage

### General page

This page displays general information about the device. It also contains the **Login Status** and the **Login** page button. To start the communication, click the **Login** page button, fill in the username and password to access the device and click the **Login** button. The **Login Status** will then show whether the login succeeded or failed.

With the **Enable Multiplex Retrieval** toggle button, you can disable/enable the retrieval of multiplex data.

The **Device Info** page button shows all the connected hardware. Depending on the connected hardware, different information is retrieved.

### Alarm page

This page displays a table with the **active alarms** on the device.

### Demodulator Status Page

With the **Demodulator Port Selection** parameter, you can select a port to display all the relevant info on this page. The **Demodulator Status Table** is located here, along with three page buttons to **normalize** **the** **demodulator**.

### Demodulator Config page

With the **Demodulator Port Selection** parameter, you can select a port to display all the relevant info on this page. The **Demodulator Config Table** displays information about the available ports.

### CAM page

This page displays information about the **CAM** and **BISS** properties and the associated programs.

### Multiplex page

This page displays tables with information about the **Multiplex** input and output ports and their **Services**. At the bottom of the page, you can find the **Normalize Multiplex** and **Normalize PIDs** buttons. These will normalize the values for the respective tables. The normalized values then become available via the page button **Normalized Values**.

### XC page

This page contains the tables **Current Program XC**, **Current Program XC - Additional Info** and **Current TS XC**, which shows detailed information regarding the **XC** programs that are running on the device.

### Decoder page

This page contains the **Decoding Service** table.

### Video page

On this page, you can view and configure parameters related to the **Video** decoder. The page also contains the page buttons **Advanced** and **More**, which display more advanced video features.

### Audio1 page

On this page, you can view and configure parameters related to the **Audio 1** decoder. For more advanced information, click the page button **Advanced Audio 1**.

### Audio2 page

On this page, you can view and configure parameters related to the **Audio 2** decoder. For more advanced information, click the page button **Advanced Audio 2**.

### Output page

This page provides an overview of the **Physical** and **Socket Outputs** in the **Interfaces** **Table** and **Ethernet Output Sockets Table**, respectively.
