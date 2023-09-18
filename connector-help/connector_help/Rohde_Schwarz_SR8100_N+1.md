---
uid: Connector_help_Rohde_Schwarz_SR8100_N+1
---

# Rohde Schwarz SR8100 N+1

With this connector, you can gather and view information from the device **Rohde Schwarz SR8100 N+1**, as well as configure the device.

## About

This SNMP connector is used to monitor the **Rohde Schwarz SR8100 N+1** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. 10.220.224.16

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, e.g. **System Description**, **Up Time**, **Software Version**.

The page also contains two page buttons:

- **Prod. Info**: Displays general information regarding the attached transmitters.
- **DVE Config**: Allows you to enable or disable DVE creation.

### Interface Page

This page displays a table with information on the interface of the device.

### Device Configuration Page

On this page, you can configure the device, with parameters such as **Sw Update Start**, **Sw Update Mode**, **Transmitter Restart**.

To configure the NTP settings, click the **NTP Config** page button.

### SNMP Configuration Page

On this page, you can configure the SNMP settings of the device.

### Transmitter Configuration

On this page, you can configure the transmitter.

### Transmitter Status

This page displays the transmitter general status, e.g. **Summary Fault**, **Power Supply.**

### Program Page

This page displays a table with the programs present on the device.

### Web Interface Page

This page displays the device's web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### DVE Pages

Each DVE has the following pages:

- **General Page**: Displays general parameters of the transmitter, e.g. Transmitter Name, Transmitter Mode.
- **Tx Configuration Page**: Allows the configuration of the transmitter.
- **Tx Status Page**: Displays the transmitter status. With the **Exciter A** and **Exciter B** page buttons, you can also view the status of the corresponding Exciter.
- **Input Status Page**: Displays the input status of the transmitters.
- **Analog Input Status Page**: Displays a table with the analog input status of the transmitter.
- **Modulation Status Page**: Displays the modulation status of the transmitter.
- **Outputstage Status Page**: Displays the output stage status of the transmitter.
