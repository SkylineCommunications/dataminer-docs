---
uid: Connector_help_Novelsat_NS3000
---

# Novelsat NS3000

This is a snmp protocol for the **Novelsat NS3000** device and can be used to display and configure information from the modem.

## about

The connector needs a snmp connection to retrieve and set information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2011.3 (Build 4377)         |

## Installation and configuration

### Creation

#### SNMP connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

#### HTTP connection - Secondary

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### System

This page displays general information about the device like the firmware version, os version, ...

Here you can also update your software from the device.

### System Config

Here you find settings for the external electrical connections to/from the device for the **Ethernet Interface**, **Serial Interface,** **External Clock Input** and additional settings for the **Time & Date Reference** used by the Device. This page also allows the user to load, save and delete device configurations from the devices internal **System Database**.

### Modulator Line Config

On this page you will find current values for **Line Configuration** parameters specific to **Modulator Functionality.**

User Changeable parameters will include **Command Regions** for changes and updates to be applied.

### Modulator Channel Config

Here is 1 table available with the channel information, this table is also configurable.

- Modulator Channel Table

### Modulator Interface Config

On this page are 3 tables displayed that are related to interface of the modulator, with these 3 you can change the settings of the interface table of the device.

- Modulator Interface Test Table
- Modulator Interface ASI Table
- Modulator Ethernet Interface Table
- Modulator GigE Interface Table

### Modulator CID Config

This page allows the configuration of several **Caller ID (CID)** parameters.

### Modulator AUPC Config

This page contains the **Automatic Uplink Power Control (AUPC)** parameters.

### Demodulator Line Config

On this page you will find current values for **Line Configuration** parameters specific to **Demodulator functionality.**

User Changeable parameters will include **Command Regions** for changes and updates to be applied.

### Demodulator Channel Config

Here you find 4 parameters where you can configure the demodulator channel 1 and 2 range for ISI by defining their Lower Limit (From) and Upper Limit (To) values.

### Demodulator Interface Config

This page is the same as the Modulator Interface Config page but now it's for the demodulator.

- Demodulator Interface Test Table
- Demodulator Interface ASI Table
- Demodulator Ethernet Interface Table

### Modulator Interface Monitoring

On this page there is 1 table:

- Modulator Interface Table

### Modulator Ethernet Monitoring

There is also 1 Table on this page:

- Modulator Ethernet Table

### Modulator System Monitoring

Here you find 2 parameters about the modulator system: Board Temperature and Clock Source.

### Modulator ACM Monitoring

This page contains a table that monitors several **Adaptive Coding and Modulation (ACM)** parameters. At the bottom of the page, there is a button that allows the table to be cleared.

### Modulator AUPC Monitoring

This page contains multiple AUPC values that are being monitored.

### Demodulator Line Monitoring

This page displays a lot of information about the demodulator line, in the bottom right corner there is a button to reset the counters.

### Demodulator Interface Monitoring

This page contains 2 tables:

- Demodulator Interface Table
- Demodulator Ethernet Table

### Demodulator System Monitoring

Here you find the temperature of the FPGA and the Board, here is also the Clock source displayed.

### Alarm / Event Monitoring

Here are 2 tables displayed:

- Monitor Alarm Table
- Monitor Event Table

### Web Interface

If available, provides access via a Web Interface (http:// Port 80) into the specific device instance.

Note: May only be available when accessing from the actual DataMiner DMA (Not all Clients).

May also require additional entry of Access Credentials (User Name/Password).
