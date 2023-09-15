---
uid: Connector_help_Albrecht_Elektronik_SDI-3G-7xx
---

# Albrecht Elektronik SDI-3G-7xx

The SDI Inserter / Databridge SDI-3G-7xx decodes, generates, formats and inserts data into a 3G, HD or SD-SDI signal.

## About

The Albrecht Elektronik SDI-3G-7xx connector is used to monitor and control an Albrecht Elektronik SDI-3G-7xx device. The information is displayed on one page, and settings can be modified.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Usage

### General page

The **General** page displays four blocks of data. The **General** block displays general information regarding the device. The three other blocks display a summary of the VBI Init tab of the web interface.

There is one page button available that will open a pop-up page on which the **Trap Table** is displayed.

### Setup Interfaces page

On this page, the user can set multiple parameters related to the interfaces. These settings will only be applied when the **Save and Reset** button is clicked.

Note that the **Default** **IP** and **Default** **Gateway** can only be modified when **Enable DHCP** is set to *Enabled*.

The **IP** **Address**, **Gateway**, **Subnet** **Mask** and **Primary** **DNS** can only be modified when **Enable** **DHCP** is set to *Not* *Enabled*.

### Login page

On this page, the user can fill in the credentials to log on to the device. If the credentials are correct, the **Login** **Status** will display *Connected*, otherwise it will display *Not* *Connected*.

### Webpage

The **Webpage** displays the web interface of the device.
