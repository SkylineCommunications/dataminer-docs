---
uid: Connector_help_Enensys_T2_Edge
---

# Enensys T2 Edge

The **Enensys T2 Edge** device is a standalone product that enables the delivery of regional/local TV services over SFN DVB-T2 networks.

With this connector the user is able to monitor multiple KPIs and configure various settings of the abovementioned device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |



## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: \[The bus address of the device.\]

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays generic information about the device, temperature and GPS status. The user is also able to perform a **Reboot** or a **Factory Reset** on the device.

Through this page the user can access 3 subpages:

- Date Time: Configuration page where the user can change the **system time** (available in multiple formats), **NTP settings**, **time zone**, etc..
- Network: Presents the **Network Interfaces** table where the user can access and modify various information, **IPv4 address/netmask/gateway**, **Link Speed, Link Mode**, etc..
- IPV2: Displays two tables - **IP Statistics** and **IP Configuration**.

### Transport Stream

In this page, there is the **Services** table which enlists all current services and their details, such as, **video encoding type**, **list of video/audio PIDs**, **minimum** and **maximum** **bit rates**, **provider name**, etc..

It is also possible to select the **ASI input, reset the services bit rates** and **freeze the Services table**.

### Satellite

In this page, the user is able to monitor multiple KPIs of the both DVB-S/S2 Satellite inputs, such as: **Lock Status, Symbol Rate, BER, Modulation Code**, etc..

It is also possible to change the settings for both inputs, for example: **DVB Mode** (*Automatic* or *Manual*), **Satellite/LNB/Tuner frequencies**, **input Polarization** (*Vertical* or *Horizontal*) and **Band** (*Low-band* or *High-band*), etc..

### Headend

In this page, the user can change **Network**, **PLP Adaptation**, **Input** (Main and Secondary) and **Output** settings, as well as monitor the **ASI** and **Satellite Bit Rates** on both inputs.

Through this page 6 subpages can be accessed:

- SI Update: Presents the **SI Update** table, which allow the user to set which SI tables to output, per PLP; and multiple settings about the SI Processing
- Network: Displays both **Managed** and **Non Managed Frequency** tables, where the user is able to enable or disable them and set their frequency value.
- PLP Adaptation: Displays both **PLP Insertion** and **PLP Aggregation** tables
- Content Insertion: Let the user enable and configure the **Emergency Warning System** feature.
- Main PLP Monitor: Displays the list of all available PLPs on main input
- Sec PLP Monitor: Displays the list of all available PLPs on secondary input

### Alarms

This pages displays the alarms information and configuration through two tables:

- **Current Alarms**: The list of current alarms on the T2 Edge device.
- **Alarm Configuration**: Where the user can configure each possible alarm on the device

It is also possible to check the current alarm count on the device and the highest severity among them, through the **Current Alarm Count** and **Current Status** parameters, respectively.
