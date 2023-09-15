---
uid: Connector_help_Rover_Instruments_MFE_802
---

# Rover Instruments MFE 802

The **Rover Instruments MFE 802** is a digital multi-front end DVB device, specifically developed for broadcasters, to give them flexible and multi-task functionality thanks to its modular and cutting-edge design.

## About

The **Rover Instruments MFE 802** connector provides a monitoring interface to get/set information from/to the device.

Further information is available here: <http://www.roverinstruments.com/prodotti.php?idp=4&camblingua=2&changelan=yes&idprod=13>

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

General information about the device can be checked and set on this page. Also here is present the current alarms present on the device.

### SAT 8 PSK

Information related to the **Satellite Status**, **Configuration** and **Information** can be accessed here.

### COFDM 2K/8K

On this page is present the OFDM **Status**, **Configuration** and **Information**.

### Decoder

Decoder **Information**, **Status**, **Configuration** and **Alarms** and also **Mask** configuration is available on this page.

### Commom Interface

All information related to the **Commom** **Interface** can be found here.

### ASI Switch

All related **ASI Switch Configuration** is available under this page.

### ASI Analyzer

All information related to the **ASI Analyzer** can be found here.

### Advanced ASI Analyzer

All information related to the **Advanced** **ASI Analyzer** can be found here.

### Terrestrial T2

All information related to the **Terrestrial T2** can be found here.

### Dual Commom Interface

All information related to the **Dual** **Commom** **Interface** can be found here.

### Web Interface

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
