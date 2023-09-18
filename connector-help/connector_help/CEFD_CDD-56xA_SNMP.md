---
uid: Connector_help_CEFD_CDD-56xA_SNMP
---

# CEFD CDD-56xA SNMP

This connector uses an SNMP connection to manage the CEFD CDD-56xA demodulator.

## About

This connector is intended to get/set information from/to the device via an element in a DataMiner System, using SNMP commands.

To get more detailed information, refer to <http://www.comtechefdata.com/support/docs/satellitemodemdocs>.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|--------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version (based on CEFD CDD-56xL SNMP v1.0.1.3) | No                  | No                      |
| 1.1.0.x          | Firmware update                                        | No                  | No                      |
| 1.1.1.x          | Cassandra compliant                                    | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.3.1q                      |
| 1.1.0.x          | 1.4.2                       |
| 1.1.1.x          | 1.4.2                       |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[The community string used when reading values from the device, by default public\]
- **Set community string**: \[The community string used when setting values on the device, by default private\]

## Usage

### Admin

Use this page to configure Mode, Features, SNMP and Header Compression related parameters:

- SNMP

  - **Trap IP Primary / Trap IP Secondary** - Assign the SNMP **Trap IP Primary** and **Trap IP Secondary** addresses.
  - **Trap Version** - Use the drop-down list to set the **Trap Version** as *SNMPv1* or *SNMPv2*.
  - **Trap Community String** - Assign the SNMP **Trap Community String**. The Community String may consist of a minimum of 0 to a maximum of 20 alphanumeric characters in length.

- Mode

- **Working Mode** - To define how the active demodulator is to operate in Vipersat or non-Vipersat Working Mode. Once this unit's role in the network is determined, this single point of configuration simplifies deployment.

- Features

  - **Telnet / Ping Relay** - Click *Enabled* or *Disabled* to set either **Telnet** or **Ping Reply** functionality.
  - **Downlink Route All Available Multicast** - Select *Enabled* or *Disabled* to set operation for **Downlink Route All Available Multicast**.
  - **Header Compression** - Select *Enabled* or *Disabled* to set operation for **Header Compression**.

- Header Compression

- The page button provides a table to configure L2,L3,L4 and L5 header compression.

### Admin - Access

- **SMTP Server** - Specify the mail server *IP address* from where you want to send the e-mail.
- **SMTP Domain Name** - Specify the *domain* of the e-mail server.
- **SMTP Destination** - Specify the e-mail *recipient name*.
- **Access List** - Use the Access List to grant access via HTTP and SNMP to a defined list of client machines. Select *Enabled* or *Disabled*. If *Disabled*, then any client machine will be able to connect via HTTP and SNMP.
- **Host Access List Table** - The Host Access List is used to define which remote clients can connect when the Access List is *Enabled*. Each entry allows a user to specify an *IP address* and a *subnet mask* to define a unique class of machines that are allowed access. For IP 3 / Mask and IP 4 / Mask, make sure they are not *0.0.0.0/0*. An entry with *0.0.0.0/0* simply means any machine is allowed to access.

### Admin - Firmware

This page contains all boot information and configuration, such as uptime and available firmware packages.

- **Boot From -** Determines which firmware version (includes Application, FPGA, and FFPGA) will be loaded upon bootup. Use the drop-down list to select:

  - *Latest* - Boots the newest firmware load based upon date.
  - *Image1* - Boots the firmware loaded into the first slot in permanent storage.
  - *Image2* - Boots the firmware loaded into the second slot in permanent storage.

- **Upgrade To** - Determines which installed firmware (includes Application, FPGA, and FFPGA) that the demodulator will overwrite when upgrading with a new firmware download. Use the drop-down list to select:

  - *Oldest* - Overwrites the oldest firmware based upon date.
  - *Image1* - Overwrites the firmware loaded into the first slot in permanent storage.
  - *Image2* - Overwrites the firmware loaded into the second slot in permanent storage.

- **Load** - Reloads the parameters from Flash memory. This may overwrite changes that have not yet been saved to Flash memory.

- **Restore** - Uses the internal, hard-coded factory default parameters.

- Save/Reboot

  - **Save** - Causes all configuration changes made during this operational session to the demodulator and IP parameters to be stored to Flash memory. These updates are permanent until the user either initiates and saves a new round of settings updates, or restores all settings to the original factory defaults. Any changes made to the demodulators will be lost upon reset or power loss unless the changes are saved to permanent storage. This applies to all of the demodulator and IP parameters.
  - **Reboot** - Use this button to force the demodulator to reboot.

### Admin - FAST

This page displays read only information about the installed options.

### Config - Demod

Use this page on a per-demod basis to configure or review demodulator operating (Rx) parameters:

- **Rx Configuration**

  - Enter an operational value for each of the following parameters - **Frequency**, **Data Rate**, **Demod Acquisition Range**, **Eb/No Alarm Point**
  - Use the provided drop-down list/toggle button to set operation for each of the following parameters - **Decoder**, **Descrambling**, **Rx Spectrum Inversion**, **Rx Data Sense Inversion**
  - Use the provided button to set operation for each of the following parameters - **Rx Buffer Size, Re-Center Buffer**
  - The following operational statistics are provided on a read-only basis and cannot be changed - **Symbol Rate**, **Terminal Rx Frequency**

- **Alarm Mask** - Set the **Rx AGC**, **Eb/No**, or **LNB** (when available) Alarm Mask by clicking *Masked* or *Active*.

### Config - LAN

Use this page to configure Network, Port or VLAN configurations.

### Config - ARP

Use this page to view **dynamic ARP** entries, or add/delete **static** entries.

### Config - Routes/IGMP

This page can be used to configure **IP routes** and **IGMP** settings.

### Config - WAN

This page includes the **Decryption** and **HDLC** configurations.

### Config - Utilities

Use this page to configure the specified CDD-56xA utility functions.

- **Date** and **Time**

  - Enter a date in the form *MM/DD/YY* (where MM = month \[01 to 12\], DD = day \[01 to 31\] and YY = year \[00 to 99\]).
  - Enter a time using *HH:MM:SS* format (where HH = hour \[00 to 23\], MM = minutes \[00 to 59\], and SS = seconds \[00 to 59\]).
  - Time Sync - Time Synchronization related parameters.

- **Circuit ID Table** - Enter a **Circuit ID** string of up to 24 characters for each demodulator.

### Config - LNB

When a Low Noise Block Down Converter (LNB) is installed, use this page to configure its operating parameters and to view the LNB status for L-Band operation.

- **LNB DC Supply Voltage** - Use the drop-down lists to turn either function *Off* or one of the *voltage* options.
- **LNB 10MHz Reference** - Use the toggle button to turn either function *On* or *Off*.
- **LNB Current Alarm Upper Limit** and **LNB Current Alarm Lower Limit** - Assign a value (in mA) ranging from 50 to 600 or from 10 to 400 respectively.
- **LNB LO (Low Oscillator) Frequency** - Assign a value (in MHz) to the LO Frequency, and designate the value as a "+" (HIGH) or "-" (LOW) limit.

### Status - Demod

- **Rx Monitor** - The following operational statistics are provided on a read-only basis and cannot be changed: **Eb/No**, **Signal Level**, **Frequency Offset**, **BER Multiplier.**
- **LNB Monitor** - **LNB Voltage** and **LNB Current.**

### Status - Logs

Use this page to review read-only operating Statistics as logged by the unit on a per-demod basis during the course of normal operation.

- **Clear Statistics Log** - To delete all existing entries from each one of the Demodulators. Choose one from the drop-down list.

### Status - Unit Info

This page displays general unit information.

- **Model Number** - Unit's model number.
- **CPU Usage** - Percentage of the processor being used.
- **Temperature** - Unit returns the value of the internal temperature, in degrees Celsius.
- **Unit Fault** - Modem Unit Faults
- **Status Table** - Rx and LNB Faults.

### Status - Traffic - Ethernet

This page displays ethernet statistics for each interface:

- **Traffic**
- **Management**
- **WAN**

### Status - Traffic - Router

This page displays statistical information about routed packets, dropped packets and filtered packets.

### Status - Traffic - WAN

This page displays the WAN FPGA Rx and Rx Error statistics for each demodulator.

### FTP

FTP tool intended to upload and download files to and from device.

### Web Interface

Access the device web interface.
Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
