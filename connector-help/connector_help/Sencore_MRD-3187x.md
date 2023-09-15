---
uid: Connector_help_Sencore_MRD-3187x
---

# Sencore MRD-3187x

The Sencore MRD-3187x connector can be used to view real-time parameters from the device and to configure parameters of the device.

## About

This connector needs an SNMP connection to retrieve data from the device and to perform sets on it. The connector also provides information about cards installed in slots. In case slots are empty, it can occur that certain parameters remain "not initialized".

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | New version for Sencore MRD-3187x based on 3187a version 1.2.0.13. VsbTable and Decoders Table added from MIB files. General review according to development rules. Supported by MRD-3187A and MRD-3187B since version 1.2.0.12. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.4.0 base 22               |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information, such as the **Alias***,* **Serial Number***,* **Version***,* etc.

It also displays **fan error and temperature** information, and provides access to the following subpages:

- **Network**: Contains basic network information, such as the **IP Address** and **Subnet Mask**.

- **SNMP Setting**: Allows you to enable or disable the fan error trap and to set the community strings.

- **SNMP Tables**: Displays the Read Only Communication Table and Read Write Communication Table.

- **Genlock**: Allows you to set the Genlock format.

- **Unit Time**: Allows you to set the current date and time options.

- **HW Table**: Displays the Hardware Overview Table.

- **VSQ/QAM**: Displays the VSB Table, which contains important information about the input card:

  - Card Location
  - Card ID
  - Modulation Error Rate (MER)
  - Signal Lock Status
  - Signal Level Status
  - Channel
  - Low Signal Level Error Threshold
  - Low MER Error Threshold

- **Decoders:** Displays the Decoders Table, which includes the following information:

  - Tuning Mode
  - PCR PID
  - Video PID
  - Priority 1 Program Number
  - Priority 2 Program Number
  - Auto Program Number

### RDS1 - Input Status

This page displays an overview of the input status and settings. It contains the following page buttons:

- **PSI PAT**: Displays the PAT Overview table and PAT Programs Overview table.
- **PSI PMT**: Displays the PMT Overview table.
- **PSI ES**: Displays the ES Overview table.

### RDS1 - Input MPEG/IP

This page displays the input MPEG/IP settings. It contains the following page buttons:

- **Packets**: Displays an overview of packet parameters and allows you to reset counters.
- **Receive Groups**: Allows you to set up the RDS1 groups, including the IP address, destination port and multicast. **Clear IGMP Filter List** and **Send IGMP Report** buttons are available for each group.
- **MPEG/IP Receive Settings**: Displays the settings for the RDS Receive group.

### RDS1 - Input Dual MPEG/IP

This page displays the input dual MPEG/IP settings. It contains the following page buttons:

- **Connectors**: Displays the dual MPEG/IP connector settings.
- **Packets**: Contains an overview of the packet parameters.
- **Receive Groups**: Allows you to set up the RDS1 groups, including the IP address, destination port and multicast. A **Clear IGMP Filter List** button is available for each group.
- **MPEG/IP Receive Settings**: Displays the settings for the RDS Receive group.

### RDS1 - Input ASI/310M

This page provides an overview of the input ASI/310M parameters.

### RDS1 - Input DVB-S/S2

This page provides an overview of the input DVB-S/S2 parameters. Some of these parameters can be used to adjust the input settings.

### RDS1 - Input DVB-S/S2 (4 Inputs)

This page provides an overview of the input DVB-S/S2 parameters for inputs A to D. Page buttons provide access to the setup for each of the inputs.

### RDS1 - Service

On this page, you can find the RDS1 service configuration, RDS1 service video information and RDS1 service audio 1 and 2 information. The page contains the following page buttons:

- **BISS**
- **SCTE35**
- **Source** **ID**
- **CAS**: Displays CAS-related parameters, including the **DVB-CI Service Overview** and **DVB-CI Selected Service Overview** table.

### RDS1 - Output

On this page, you can switch video output parameters: output HD-SDI, output SD-SDI, output MPEG/IP and output dual MPEG/IP.

There are also page buttons to subpages with overview information and different video and audio parameters:

- **Overlays**
- **SDI Emb Audio**
- **Transmit Group**

### RDS1 - Output HD/SD-SDI

This page contains output HD/SD-SDI parameters. It also contains the following page buttons:

- **HD/SD-SDI**
- **SD-SDI VANC**
- **HD-SDI VANC**
- **VBI**
- **Overlays**
- **SDI Emb Audio**
- **Video Timing**

### RDS1 - Analog/Digital Audio

This page contains parameters related to analog/digital audio.

### RDS1 - PID Filter IP

This page contains settings for port 1 and 2, as well as global settings. Five page buttons are available, providing access to the parameters for transmit filter 1 to 5.

### RDS2 - Input Status

This page displays an overview of the input status and settings. It contains the following page buttons:

- **PSI PAT**: Displays the PAT Overview table and PAT Programs Overview table.
- **PSI PMT**: Displays the PMT Overview table.
- **PSI ES**: Displays the ES Overview table.

### RDS2 - Input MPEG/IP

This page displays the input MPEG/IP settings. It contains the following page buttons:

- **Packets**: Displays an overview of packet parameters and allows you to reset counters.
- **Receive Groups**: Allows you to set up the RDS1 groups, including the IP address, destination port and multicast. **Clear IGMP Filter List** and **Send IGMP Report** buttons are available for each group.
- **MPEG/IP Receive Settings:** Displays the settings for the RDS Receive group.

### RDS2 - Input Dual MPEG/IP

This page displays the input dual MPEG/IP settings. It contains the following page buttons:

- **Connectors**: Displays the dual MPEG/IP connector settings.
- **Packets**: Contains an overview of the packet parameters.
- **Receive Groups**: Allows you to set up the RDS2 groups, including the IP address, destination port and multicast. A **Clear IGMP Filter List** button is available for each group.
- **MPEG/IP Receive Settings:** Displays the settings for the RDS Receive group.

### RDS2 - Input ASI/310M

This page provides an overview of the input ASI/310M parameters.

### RDS2 - Input DVB-S/S2

This page provides an overview of the input DVB-S/S2 parameters. Some of these parameters can be used to adjust the input settings.

### RDS2 - Input DVB-S/S2 (4 Inputs)

This page provides an overview of the input DVB-S/S2 parameters for inputs A to D. Page buttons provide access to the setup for each of the inputs.

### RDS2 - Service

On this page, you can find the RDS2 service configuration, RDS2 service video information and RDS2 service audio 1 and 2 information. The page contains the following page buttons:

- **BISS**
- **SCTE35**
- **Source** **ID**
- **CAS**: Displays CAS-related parameters, including the **DVB-CI Service Overview** and **DVB-CI Selected Service Overview** table.

### RDS2 - Output

On this page, you can switch video output parameters: output HD-SDI, output SD-SDI, output MPEG/IP and output dual MPEG/IP.

There are also page buttons to subpages with overview information and different video and audio parameters:

- **Overlays**
- **SDI Emb Audio**
- **Transmit Group**

### RDS2 - Output HD/SD-SDI

This page contains output HD/SD-SDI parameters. It also contains the following page buttons:

- **HD/SD-SDI**
- **HD-SDI VANC**
- **SD-SDI VANC**
- **VBI**
- **Overlays**
- **SDI Emb Audio**
- **Video Timing**

### RDS2 - Analog/Digital Audio

This page contains parameters related to analog/digital audio.

### RDS2 - PID Filter IP

This page contains settings for port 1 and 2, as well as global settings. Five page buttons are available, providing access to the parameters for transmit filter 1 to 5.

### Configuration Files

On this page, you can select, save or set up configuration files for the device.

In addition, the **Username** and **Password** can be specified here.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
