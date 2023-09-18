---
uid: Connector_help_Omneon_Spectrum_System
---

# Omneon Spectrum System

This connector allows you to control the Omneon Spectrum System and its modules. Omneon's Spectrum System is a scalable multi-user network consisting of MediaStores, MediaDirectors, interface modules (MediaPorts) and a network manager. In addition to basic device interconnection, it provides disk-based storage and extensive network and file management services.

## About

This connector retrieves data using the SNMP protocol every 30 seconds. It will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

### Version Info

| **Range** | **Description**                                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                           | No                  | Yes                     |
| 2.0.0.x          | DVE support added.                                         | No                  | Yes                     |
| 2.0.1.x          | Redundant SNMP connection added.                           | No                  | Yes                     |
| 2.0.2.x          | Change to DVE names. View columns added in the DVE tables. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.5                         |
| 2.0.0.x          | 4.5                         |
| 2.0.1.x          | 4.5                         |
| 2.0.2.x          | 4.5                         |

### Exported connectors

| **Exported Connector**                                                                                | **Description**                                                                                                                |
|------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| [Omneon Spectrum System - Device](xref:Connector_help_Omneon_Spectrum_System_-_Device)       | Only supported from range 2.0.0.x onwards. Device modules (MediaDirectors and MediaPorts) registered with the Network Manager. |
| [Omneon Spectrum System - Player](xref:Connector_help_Omneon_Spectrum_System_-_Player)       | Only supported from range 2.0.1.x onwards. Player module.                                                                      |
| [Omneon Spectrum System - Enclosure](xref:Connector_help_Omneon_Spectrum_System_-_Enclosure) | Only supported from range 2.0.1.x onwards. Enclosure module.                                                                   |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The main polling IP of the device e.g. *10.10.250.150*.
- **Device address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNMP Secondary connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The backup polling IP of the device e.g. *10.10.250.149*.
- **Device address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### Main View

This page displays general configuration information and controls, including the **Manager Status**, which can be *Available* or *Not Available*.

The **View Export Tables** page button displays the current values for the Device DVE Export Table, Player DVE Export Table and Enclosure DVE Export Table. Every current DVE should be present in one of these tables.

The **Remove Traps** button clears all the trap information from the **Trap Details** column of the **Device Table**.

The **Automatic General DVE Creation** button determines the behavior of this connector when a new device/player/enclosure module row is added:

- If it is set to *Enabled*, the connector will automatically generate a new DVE for the new device. This is applied for every table for which **Automatic DVE Creation** is set to general configuration mode.
- If it is *Disabled*, the connector will not generate a DVE automatically. Instead, you will need to click the toggle button in the **DVE Status** column (setting it to 'ON') to generate a new DVE for this device. This is applied for every table for which **Automatic DVE Creation** is set to general configuration mode.
- If it is set to *Individual*, this will not apply any effect and you will need to configure the Automatic DVE creation separately for each relevant table.

**Refresh All DVEs State** will refresh the DVE status for every running DVE.

**Add All DVEs** will generate DVEs for every device/player/enclosure module found, while **Delete All DVEs** will delete all current DVEs.

### Device Info

The **Device Table** contains information about the device modules available in the system. The Row State column shows the state of the row in this table. If the Row State is *Deleted*, this means that the row was deleted from the Device Table, and the Delete DVE button will be enabled. Clicking the Delete DVE button will remove this DVE and this row in the Device Table. However, keep in mind that when you do so, all trend and alarm information for the DVE is lost.

The **Refresh Device DVEs State** button refreshes the status information for all device DVEs.

The **Add All Device DVEs** button creates DVEs for all the devices available in the Device Table and set its DVE Status column to *ON*. The **Delete All Device DVEs** button removes device DVEs that were created before and sets the DVE Status column to *OFF* for all the devices. You can also use the button in the **DVE Status** column to add or delete specific DVEs.

The **Automatic Device DVE Creation** button determines the behavior of this connector when a new device module row is added in the **Device Table**:

- If it is *Enabled*, this connector will automatically generate a new DVE for the new device.
- If it is *Disabled*, this connector will not generate a DVE automatically. Instead, you will need to click the toggle button in the **DVE Status** column (setting it to *ON*) to generate a new DVE for this device.
- If it is *General configuration*, the behavior of the connector for the Device Table DVEs will depend on the value of the **Automatic General DVE Creation** parameter.

The **Device DVE Loading Status** progress bar shows the progress of the loading of the DVEs. Note that there may be some delay before a DVE is shown in the Surveyor.

### Player Info

The **Player Table** contains information about the players registered for each device. The **Director Name** in this table corresponds to the Device Name. The Row State column shows the state of the row in this table. If the Row State is *Deleted*, this means that the row was deleted from the Player Table, and the Delete DVE button will be enabled. Clicking the Delete DVE button will remove this DVE and this row from the table. However, keep in mind that when you do so, all trend and alarm information for the DVE is lost.

The **Refresh Player DVEs State** button refreshes the status information for all player DVEs.

The **Add All Player DVEs** button creates DVEs for all the players available in the Player Table and set its DVE Status column to *ON*. The **Delete All Player DVEs** button removes player DVEs that were created before and sets the DVE Status column to *OFF* for all the devices. You can also use the button in the **DVE Status** column to add or delete specific DVEs.

The **Automatic Player DVE Creation** toggle button determines the behavior of this connector when a new player module row is added in the **Player Table**.

- If it is *Enabled*, the connector will automatically generate a new DVE for the new player.
- If it is *Disabled*, this connector will not generate a DVE automatically. Instead, you will need to click the toggle button in the **DVE Status** column (setting it to *ON*) to generate a new DVE for this device.
- If it is *General configuration*, the behavior of the connector for the Player Table DVEs will depend on the value of the **Automatic General DVE Creation** parameter.

The **Player DVE Loading Status** progress bar shows the progress of the loading of the DVEs. Note that there may be some delay before a DVE is shown in the Surveyor.

### Enclosure Info

This page displays the **Enclosure Table** with information about the Enclosures (MediaStores) registered for each device. The **Director Name** in this table corresponds to the Device Name. The Row State column shows the state of the row in this table. If the Row State is *Deleted*, this means that the row was deleted from the Enclosure Table, and the Delete DVE button will be enabled. Clicking the Delete DVE button will remove this DVE and this row from the table. However, keep in mind that when you do so, all trend and alarm information for the DVE is lost.

The **Refresh Enclosure DVEs State** button refreshes the status information for all enclosure DVEs.

The **Add All Enclosure DVEs** button creates DVEs for all the enclosures available in the Enclosure Table and set its DVE Status column to *ON*. The **Delete All Enclosure DVEs** button removes enclosure DVEs that were created before and sets the DVE Status column to *OFF* for all the devices. You can also use the button in the **DVE Status** column to add or delete specific DVEs.

The **Automatic Enclosure DVE Creation** toggle button determines the behavior of this connector when a new enclosure module row is added in the **Enclosure Table**.

- If it is *Enabled*, this connector will automatically generate a new DVE for the new enclosure module.
- If it is *Disabled*, this connector will not generate a DVE automatically. Instead you will need to click the toggle button in the **DVE Status** column (setting it to *ON*) to generate a new DVE for this device.
- If it is *General configuration*, the behavior of the connector for the Enclosure Table DVEs will depend on the value of the **Automatic General DVE Creation** parameter.

The **Enclosure DVE Loading Status** progress bar shows the progress of the loading of the DVEs. Note that there may be some delay before DVEs are shown in the Surveyor.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
