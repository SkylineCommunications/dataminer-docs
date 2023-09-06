---
uid: Connector_help_WISI_Optopus
---

# WISI Optopus

The **WISI Optopus** is an Optical Platform for FTTx and HFC. With this SNMP driver, you can control and monitor the parameters of the device.

## About

With the **WISI** **Optopus** platform, any module can be mounted into any slot, so that fully customized individual configuration is possible, specific to the intended application.

Every card inserted into one of the 14 slots will generate its own individual **Dynamic Virtual Element** (**DVE**) when this option is enabled. In the DVE, you can configure parameters and alarm monitoring related to that card (**Current Alarms**, **Alarm Log** and **Alarm configuration**).

Note that two SNMP connections are established with the device. **SnmpConnection2** has a different **Set community string** because some parameters require a different level of permissions, as stated in the MIB file.

From version 1.0.0.18 onwards, SSH communication with the device server can be done using RSA authentication. More details can be found in the documentation of new features of firmware version 2.1.0.0.

For more information about the device, please refer to the website <http://wisi.de/en/business/products/optopus/>.

### Ranges of the driver

| **Driver Range** | **Description**                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                         | No                  | No                      |
| 1.0.1.x          | Tables display column changed to naming. | No                  | No                      |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version**                                                       |
|------------------|-----------------------------------------------------------------------------------|
| 1.0.0.x          | 1.0.0.0 BOOT_LX51 1.0.0.2 BOOT_LX_Module 1.0.0.4 BOOT_LX_Module 2.1.1.0 APPL_LX51 |
| 1.0.1.x          | 1.0.0.0 BOOT_LX51 1.0.0.2 BOOT_LX_Module 1.0.0.4 BOOT_LX_Module 2.1.1.0 APPL_LX51 |

### Exported drivers

| **Exported Protocol**                                                                  | **Description**                     |
|----------------------------------------------------------------------------------------|-------------------------------------|
| [WISI Optopus RF Amplifier](xref:Connector_help_WISI_Optopus_RF_Amplifier)       | LX70 Wideband Amplifier             |
| [WISI Optopus Ext Transmitter](xref:Connector_help_WISI_Optopus_Ext_Transmitter) | LX10 Longhaul Broadcast Transmitter |
| [WISI Optopus Transmitter](xref:Connector_help_WISI_Optopus_Transmitter)           | LX13 Dual CWDM Upstream Transmitter |
| [WISI Optopus OP Amplifier](xref:Connector_help_WISI_Optopus_OP_Amplifier)       | LX30 Optical Amplifier              |
| [WISI Optopus Us Receiver](xref:Connector_help_WISI_Optopus_Us_Receiver)         | LX22 Upstream Receiver              |
| [WISI Optopus Ds Receiver](xref:Connector_help_WISI_Optopus_Ds_Receiver)         | LX21 Downstream Receiver            |
| [WISI Optopus Passive Devices](xref:Connector_help_WISI_Optopus_Passive_Devices) | LDxx Passive Filter Modules         |
| [WISI Optopus Op Switch](xref:Connector_help_WISI_Optopus_Op_Switch)             | LX60 Optical Redundancy Switch      |

## Configuration

### Connections

This driver uses two Simple Network Management Protocol (SNMP) connections and requires the following input during element creation:

**SNMP Connection**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**SnmpConnection2:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *Wisi.*

### Configuration of the SSH connection

When the element starts for the first time, all default values are set. In order to set passwordless communication between the element and the WISI device using RSA authentication, some steps must be taken. These only have to be done once.

A pair of keys must be provided to the WISI elements. By default they must be located under the folder *C:\Skyline DataMiner\Documents\WISI Optopus\SFTP.* To accomplish this, use the element's **Documents** folder in DataMiner Cube. Just add the keys using the **Add document** function. This will trigger the synchronization of the files throughout the cluster.

The key files should be created using **Putty Key Generator**. They must be of type *RSA,* using the *Open SSH* format and with *1040* bits (see "1" in the picture below). Save the public key from the panel by copying it to a file with the name provided in **RSA Public Key File Name.** Then export the private key to a file using the menu and save the file with the same name as **RSA Private Key File Name** (see "2" in the picture below). There is no need to set a **Key passphrase**.

![Untitled.png](~/connector-help/images/WISI_Optopus_Untitled.png)

Notes:

- The first time the element connects to the WISI Optopus SSH server, an entry is added to the *knownhosts.txt* file created under the same folder mentioned above. It works as a proof that the element trusts the device's server.
- Password authentication is only used while the connection is set up for the first time. After the new public key is uploaded and set, the **SSH Authentication Methods** parameter will be set to *Only Public Key Auth*. However, it is possible to revert to Key or Password authentication on the **Security** subpage of the **Network** page.

## Usage

### General

This page displays general information about the device:

- **Identification:** Information about the network card.
- **Product Data:** Information about the vendor and the device.
- **MIB II System Group:** Information about the device.
- **General:** Temperature, and buttons that are used to reset the device.
- **Time Settings:** Time and date information.

### Device

On this page, you can configure slots 15 to 22. They are related to the **PS** (Power Source), **Fan Unit** and **SPF** (Small form-factor Pluggable Transceiver) slots. Click the **Rescan** button to update the table with the latest inserted cards.

### Network

This page displays parameters related to the headend network controller:

- **Interfaces Table:** This table contains information about the device interfaces.
- **SFTP**: Subpage where you can **Upload** and **Download** files towards the SFTP server incorporated on the device. Defaults values are filled in. To then update the firmware, use the **Firmware** page button.
- **TFTP**: Subpage with TFTP configuration options.
- **Trap Receiver**: Subpage where you can monitor and configure traps received from the device.
- **Firmware** and **Firmware Images**: Subpages with information about the firmware images kept in the device's memory.
- **OH51 Email** and **OH51 Receiver**: Only applicable for OH51 remote interface.

### Network - IP

This page displays parameters related to the headend network controller **IP**.

### Network - Other Protocols

This page displays parameters related to the headend network controller **TCP**, **UDP** and **ICMP**.

### Slots

This page provides information about slots 1 to 14.

- **All Modules DVE Creation:** Enables/disables DVE creation on all slots at once.

- **LX Slots Table:**

- **LX Slots Device Type String:** Allows you to set a virtual card. Set this to *None* to delete it. Every virtual card that has been set is displayed in the **HE Passive Table**, which you can reach via the **Passive** page button.
  - **Module DVE Creation** (Last column): Enables/disables DVE creation if a card is present in the slot.

- **Transmitters**, **Amplifiers**, **Receivers**, **Optical** and **Passive**: There are different types of cards available for this platform, and the corresponding parameters can be viewed through these page buttons. There is an additional type, **Passive**, for slots with a virtual card.

### Module Types

This page contains the tables that will generate the DVEs. If a DVE has been created, there will be a row in the table where that card type belongs.

### Alarms

Use this page to configure alarm monitoring.

- **Alarm Configuration:** Use this page button to configure which parameters will generate an alarm. They can be of type Analog (**Property Table**) or of type Discrete (**Discrete Property Table**).
- **Current Alarm Table:** Displays all active alarms.
- **Alarm Log Table:** Displays alarm log information.
