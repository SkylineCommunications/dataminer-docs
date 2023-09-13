---
uid: Connector_help_CEFD_CDD-56xL_SNMP
---

# CEFD CDD-56xL SNMP

The CDD-56xL series are integrated IP demodulators that receive two or four independent 70/140 MHz or L-Band channels (depending on model) and combine the output into a single 10/100Base-T Ethernet port for transmission onto the LAN.

## About

This driver is intended to get/set information from/to the device via an Element in a DataMiner System, using SNMP commands.
To get more detailed information consult this website <http://www.comtechefdata.com/support/docs/satellitemodemdocs>

### Version Info

| **Range** | **Key Features**                                                                                                    | **Based on** | **System Impact**                                 |
|-----------|---------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------|
| 1.0.0.x   | Initial version                                                                                                     | \-           | \-                                                |
| 1.0.1.x   |                                                                                                                     | 1.0.0.8      |                                                   |
| 1.0.2.x   | Multiple tables now uses naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.1.3      | **Old trend data will be lost for these tables.** |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |
| 1.0.2.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, default *161*

- **Get community string**: The community string in order to read from the device. The default value is *public*.

- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Admin

Use this page to configure Mode, Access, Features, SNMP and Decryption related parameters:

- Mode

  - **Working Mode** - To define how the active demodulator is to operate in Vipersat or non-Vipersat Working Mode. Once this unit's role in the network is determined, this single point of configuration simplifies deployment.

- Access

  - **SMTP Server** - Specify the mail server *IP address* from where you want to send the e-mail.
  - **SMTP Domain** - Specify the *domain* of the e-mail server.
  - **SMTP Destination Name** - Specify the e-mail *recipient name*.
  - **Access List** - Use the Access List to grant access via HTTP and SNMP to a defined list of client machines. Select *Enabled* or *Disabled*. If *Disabled*, then any client machine will be able to connect via HTTP and SNMP.
  - **Host Access List** - The Host Access List is used to define which remote clients can connect when the Access List is *Enabled*. Each entry allows a user to specify an *IP address* and a *subnet mask* to define a unique class of machines that are allowed access. For IP 3 / Mask and IP 4 / Mask, make sure they are not *0.0.0.0/0*. An entry with *0.0.0.0/0* simply means any machine is allowed to access.

- Features

  - **Telnet / Ping Relay** - Click *Enabled* or *Disabled* to set either **Telnet** or **Ping Reply** functionality.
  - **Downlink Route All Available Multicast** - Select *Enabled* or *Disabled* to set operation for **Downlink Route All Available Multicast**.
  - **Header Compression** - Select *Enabled* or *Disabled* to set operation for **Header Compression**.

- SNMP

  - **Trap IP Primary / Trap IP Secondary** - Assign the SNMP **Trap IP Primary** and **Trap IP Secondary** addresses.
  - **Trap Version** - Use the drop-down list to set the **Trap Version** as *SNMPv1* or *SNMPv2*.
  - **Trap Community String** - Assign the SNMP **Trap Community String**. The Community String may consist of a minimum of 0 to a maximum of 20 alphanumeric characters in length.

- Decryption - *This is accessible only when the 3xDES FAST feature has been purchased and its FAST Access Code has been entered.*

  - **3xDES Decryption:** **Receive Keys 1 - 8**: 3xDES keys are used to decrypt traffic being received from the Satellite Interface. Each key is entered in hexadecimal format (48 digits max).

### Demod - Demod

Use this page on a per-demod basis to configure or review demodulator operating (Rx) parameters:

- **Rx Configuration**

  - Enter an operational value for each of the following parameters - **Frequency**, **Data Rate**, **Demod Acqusition Range**, **Eb/No Alarm Point**
  - Use the provided drop-down list/toggle button to set operation for each of the following parameters - **Decoder**, **Descrambling**, **Rx Spectrum Inversion**, **Rx Data Sense Inversion**
  - Use the provided button to set operation for each of the following parameters - **Rx Buffer Size, Re-Center Buffer**
  - The following operational statistics are provided on a read-only basis and cannot be changed - **Symbol Rate**, **Terminal Rx Frequency**

- **Internal Reference Adjust** - Enter an operational value for the following parameter.

- **Internal 10MHz** - External reference frequency.

- **Rx Monitor** - The following operational statistics are provided on a read-only basis and cannot be changed: **Eb/No**, **Signal Level**, **Frequency Offset**, **BER Multiplier.**

- **Alarm Mask** - Set the **Rx AGC**, **Eb/No**, or **LNB** (when available) Alarm Mask by clicking *Masked* or *Active*.

### Demod - Utilities

Use this page to configure the specified CDD-56X utility functions.

- **Date** and **Time**

  - Enter a date in the form *MM/DD/YY* (where MM = month \[01 to 12\], DD = day \[01 to 31\] and YY = year \[00 to 99\]).
  - Enter a time using *HH:MM:SS* format (where HH = hour \[00 to 23\], MM = minutes \[00 to 59\], and SS = seconds \[00 to 59\]).
  - Time Sync - Time Synchronization related parameters.

- **Circuit ID Table** - Enter a **Circuit ID** string of up to 24 characters for each demodulator.

### Demod - Status

Use this page to view *read-only* information on a *per-demod* basis.

- **Model Number** - Unit's model number.
- **CPU Usage** - Percentage of the processor being used.
- **Temperature** - Unit returns the value of the internal temperature, in degrees Celsius.
- **Unit Fault** - Modem Unit Faults
- **Status Table** - Rx and LNB Faults.

### Demod - Events

Use this page to review read-only Faults or Alarms (Events) as logged by the unit on a system-wide basis during the course of normal operation.

- **Clear Events Log** - To delete all existing log entries from each one of the Demodulators. Choose one from the drop-down list. The log is then reset to one (1) entry: "**Info Log Cleared**".

### Demod - Statistics

Use this page to review read-only operating Statistics as logged by the unit on a per-demod basis during the course of normal operation.

- **Clear Statistics Log** - To delete all existing entries from each one of the Demodulators. Choose one from the drop-down list.

### Demod - LNB

When a Low Noise Block Down Converter (LNB) is installed, use this page to configure its operating parameters and to view the LNB status for L-Band operation.

- LNB Configuration

  - **LNB DC Supply Voltage** - Use the drop-down lists to turn either function *Off* or one of the *voltage* options.
  - **LNB 10MHz Reference** - Use the toggle button to turn either function *On* or *Off*.
  - **LNB Current Alarm Upper Limit** and **LNB Current Alarm Lower Limit** - Assign a value (in mA) ranging from 50 to 600 or from 10 to 400 respectively.
  - **LNB LO (Low Oscillator) Frequency** - Assign a value (in MHz) to the LO Frequency, and designate the value as a "+" (HIGH) or "-" (LOW) limit.

- LNB Monitor

  - **LNB Voltage** and **LNB Current** - These status fields are read-only and cannot be changed.

### IP - Ethernet / HDLC

Use this page to view the MAC address and Link Status, and set the IP address/mask, and mode/speed of the IP Module.

- Ethernet

  - **MAC Address (read-only)** - This is set at the factory to a guaranteed unique address that cannot be modified by the user.
  - **Mode & Speed** - Use the drop-down list to select *Auto*, *10 Mbps Half Duplex*, *100 Mbps Half Duplex*, *10 Mbps Full Duplex* or *100 Mbps Full Duplex*.
  - **IP Address/Mask** - The user may enter the *IP Address*/*Mask* for the IP Module Ethernet Interface.

- VLAN Brouter - *In order for this feature to work, Header Compression must be purchased and available.* The VLAN Brouter feature allows VLAN tagged packets to be forwarded when in Brouter mode.

  - **VLAN Brouter Mode** - Use the toggle-button to select this mode as *Enabled* or *Disabled*. Note the following:

    - This mode can be enabled only when one of the Router modes is enabled.
    - When Managed Switch Mode is enabled, this feature is automatically disabled.

  - **VLAN Brouter Next Hop MAC Address** - When VLAN Brouter Mode is *Enabled*, the user may enter the **Next Hop MAC Address**, to which VLAN tagged packets are to be directed, into this text field.

- HDLC - Two IP Module Working Modes are available with Comtech EF Data IP-enabled products: **Managed Switch Mode** (formerly easyConnectTM) and **Router Mode**. For the CDD-56X Satellite Demodulator, three primary HDLC Addressing (Router) Modes are available - *Point-to-Point*, *Small Network*, and *Large Network*. Once the role of a particular CDM-IP Modem is determined in the network, this single point of configuration simplifies deployment. Use this page to specify the Router Mode for the CDM-IP modem/CDD-56X pairing.

  - **HDLC Address Mode** (read-only):

    - *Point-to-Point Mode* - To use in a Point-to-Point SCPC link where there are different IP subnets on either side of the link.
    - *Small Network Mode* - The Small Network Mode supports up to 255 remotes, as allowed using HDLC addressing. When set the unit will be on independent IP subnets; requires adding static routes to pass traffic between them.
    - *Large Network Mode* - This mode is similar to Small Network Mode, the exception being that a maximum of 32,766 remotes are allowed on a single shared satellite outbound carrier.

  - **Receive HDLC Addresses (Hex)** - The address may be assigned on a per-demod basis within the following ranges:

    - Point-to-Point - *No HDLC address -Not Defined*
    - Small Network - *0x1* to *0xFE*
    - Large Network - *0x1* to *0xFFFE*

### IP - Routes / IGMP

Use this page to enter static routes into the IP Module on a *per-demod* basis, for the purpose of routing IP traffic over the satellite or to another device on the local LAN and to manage multicast IP traffic over the satellite or to another device on the local LAN.

- **Routes/Multicast Table:** The current entries present in Route Table. To delete a route use the **Route Row Status** column option, *Delete*.

  - **Route Table Entry:**

    - **Name** - Assign a label for the Route Entry as a means to maintain the network. The assigned name cannot contain any whitespace and must be unique.

    - **IP Address/Mask** - This address defines the route to the destination network.

    - **Next Hop Address** - When the route is of type **Sat to Eth**, use the **Next Hop Address** to define the locally attached router's IP address that will be used to route to the destination network. This is the case when there is another subnet addressed to the modem on the LAN side. The address may be assigned, dependent on the selected Working Mode, within the following ranges:

      - *Point-to-Point* - No HDLC address
      - *Small Network* - 0x1 to 0xFE
      - *Large Network* - 0x1 to 0xFFFE

    - **Sat to Eth** - Select the valid packet handling value for routing to a destination network, using the drop-down list:

      - *Forward* - Multicast is only forwarded across link if both units have this feature enabled.
      - *Filter* - A multicast packet is received but there is no application associated with it.

- Demod as Server - Use this page to facilitate the use of IGMP (Internet Group Management Protocol) with configured multicast routes.

  - **Enable IGMP** - Use the toggle-button to select *Enabled* or *Disabled*. If enabled, the IP Module responds to IGMP queries for the configured multicast routes on the transmit side and generates IGMP queries on the receive side.

  - **IGMP Query Period** - Enter a query period value - from *1* to *600* seconds - into the text box.

  - **IGMP Maximum Response Time** - Enter a response time value that is less than the IGMPQuery Period minus one - from *1* to *598* seconds - into the text box.

  - **Missed Responses Before Leaving IGMP Group** - Enter the number of desired missed responses - from *1* to *30*  - into the text box.

  - **IGMP Table** - This *read-only* table lists the IGMP Groups that are active on the demodulator. This includes the **TTL** (Time to Live) for the entry; the **Client State** (Idle, Active, or Closing); and the **SRC** and **Group Entries**.

### Stats - Ethernet

Use this page to review ***read-only*** status information pertaining current operating statistics for Ethernet Rx. Click **Reset Stats** to allow the most recent statistics to display.

### Stats - IP

Use this page to review ***read-only*** status information pertaining to a variety of IP Routing Statistics - Sent/Received, Dropped, and Filtered. Click **Reset Stats** to allow the most recent statistics to display;

### Stats - WAN

Use this page to review ***read-only*** status information pertaining to current operating statistics for the WAN FPGA Rx, as well as logged Rx Errors. Click **Reset Statistics** to allow the most recent statistics to display.

### Maint

- Unit Information - Use this page to review ***read-only*** status information pertaining to the base unit and IP Module's firmware information for Boot, Active and Inactive Bulks. The Unit Uptime, Demod Serial Number, and IP Module Software Revision information is also provided here.

- Operations and Maintenance - Use this page to configure the unit's handling of firmware upon bootup.

  - **Boot From -** Determines which firmware version (includes Application, FPGA, and FFPGA) will be loaded upon bootup. Use the drop-down list to select:

    - *Latest* - Boots the newest firmware load based upon date.
    - *Image1* - Boots the firmware loaded into the first slot in permanent storage.
    - *Image2* - Boots the firmware loaded into the second slot in permanent storage.

  - **Upgrade To** - Determines which installed firmware (includes Application, FPGA, and FFPGA) that the demodulator will overwrite when upgrading with a new firmware download. Use the drop-down list to select:

    - *Oldest* - Overwrites the oldest firmware based upon date.
    - *Image1* - Overwrites the firmware loaded into the first slot in permanent storage.
    - *Image2* - Overwrites the firmware loaded into the second slot in permanent storage.

  - **Read Configuration From** - Specifies if configuration should be read from::

    - *File Stored in Flash* - Overwrites the oldest firmware based upon date.
    - *Factory Defaults* - Overwrites the firmware loaded into the first slot in permanent storage.

  - **Load** - Reloads the parameters from Flash memory. This may overwrite changes that have not yet been saved to Flash memory.

  - **Restore** - Uses the internal, hard-coded factory default parameters.

- Save/Reboot

  - **Save** - Causes all configuration changes made during this operational session to the demodulator and IP parameters to be stored to Flash memory. These updates are permanent until the user either initiates and saves a new round of settings updates, or restores all settings to the original factory defaults. Any changes made to the demodulators will be lost upon reset or power loss unless the changes are saved to permanent storage. This applies to all of the demodulator and IP parameters.
  - **Reboot** - Use this button to force the demodulator to reboot.

### Web Interface

Access the device web interface.

### FTP

FTP tool intended to upload and download files to and from device.
