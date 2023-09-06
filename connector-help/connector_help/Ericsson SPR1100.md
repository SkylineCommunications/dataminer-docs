---
uid: Connector_help_Ericsson_SPR1100
---

# Ericsson SPR1100

The **Ericsson SPR1100** is a high-density broadcast video processor that allows operators to launch additional television services to the customers' homes, manage and migrate to MPEG-4 AVC, simplify time-shift TV ingest processing, and enable cost-efficient disaster recovery sites for business continuity.

## About

This driver is used to monitor and control an **Ericsson SPR1100** device. The driver uses **HTTP** requests to communicate with the device. The information of the device is shown on different pages. Some of the parameters can be set to a custom value. The driver uses tree views, tables and individual parameters to present its data.

### Ranges of the driver

| **Driver Range**            | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|-----------------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                     | Initial version for firmware 6.20.0.120456 or lower | No                  | No                      |
| 2.0.0.x                     | New version based on firmware above 6.20.0.120456   | Yes                 | No                      |
| 3.0.0.x (see Notes section) | Corrected naming for several tables.                | Yes                 | No                      |

### Supported firmware versions

| **Driver Range**            | **Device Firmware Version** |
|-----------------------------|-----------------------------|
| 1.0.0.x                     | 6.20.0.120456 or lower      |
| 2.0.0.x                     | Above 6.20.0.120456         |
| 3.0.0.x (see Notes section) | Above 6.20.0.120456         |

## Installation and Configuration

### Creation

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination. This is set to *80.*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Timing

All data gets retrieved from the device with a minimum delay of 6 seconds between each command sent to the device. This is according to specifications provided by Ericsson.

The driver has **6** **timers**:

- **Cisco Parameters**: Every 2 seconds, all switching parameters of Cisco elements in the DMS are retrieved.
- **Boosted Status Timer**: This timer is only run when the device is rebooted. It polls for the device status every 7 seconds to see whether the device is up again.
- **Alarm/Status Timer**: Every 30 seconds, the active alarms and status are polled.
- **Fast Timer**: Every minute, all fast data is polled, e.g. bitrates.
- **Medium Timer**: Every 10 minutes, all generic data concerning services, streams and components is polled.
- **Slow Timer**: Every hour, slowly updating data such as the build, firmware and software versions is updated.

## Usage

### General Page

This page displays two groups of information:

- **Board info**: General information about the board.
- **Current Device**: General information about the device that is currently in use.

There are nine buttons available on this page:

- **Delete Old Rows**: Removes all the rows in the tables that are no longer received.
- **Get Serial ID**: Requests a unique serial ID.
- **Refresh Data**: Refreshes the data manually.
- **Simulated Device**: Displays the status and IP address of the simulated device.
- **SNMP Trap Servers**: Displays the number of available servers and their IP addresses.
- **Fan Speed**: Displays information about the available fan devices and their speed expressed in RPM.
- **Software Version**: Displays information about the current software version.
- **Redundancy**: Displays the IP address, name and status of the primary and secondary devices.
- **Clean ElementStorage**: Cleans the element storage. Note: Before you **delete an element**, it is advisable to press this button. The driver uses a technique called element storage to keep the active configuration file stored in memory. Cleaning ElementStorage will remove this configuration for a short time.

### Board Overview

(only in the 2.0.0.X range)This page provides an overview of all slotted cards in the board, specifying information such as the **Card ID**, **Name**, **Build Date**, **Hardware/Software** **Version** and **Serial Number**.

### Alarms Page

This page contains the **Current** **Alarms** table, which displays the alarms that are currently active.

The possible severity values sent by the device are:

- Mask
- Cleared
- Warning
- Minor
- Major
- Critical

For a full list of possible alarms, refer to the "Addendum 1" section.

### Input Tree Page / Output Tree Page / Network Configuration Page

On these three pages, a tree control is displayed, featuring alarm bubble-up. This means that the highest severity in one of the nodes will be displayed on the highest node.

### Config Report Page

This page displays the **Current Transcode Configuration** table.

### Input Tables Page

On this page, tables with information related to the inputs are displayed. You can find a more structured overview combining these tables on the **Input Tree** page.

### Output Tables Page

On this page, tables with information related to the outputs are displayed. On the **Output Tree** page, a tree view is displayed combining the **Output Streams**, **Output Services**, **Output Components** and **Custom VAD** table.

### Network Configuration Tables Page

This page displays the **Network Configuration** and the **Ports Configuration** table. On the **Network Configuration** page, a tree view is displayed combining these two tables.

### License List Page

This page displays only one table, the **License List** table, which contains information on the different licenses.

### Configurations Page

On this page, you can set a **Remote Location** and a **Filename**, and then **Upload** or **Download** this file.

### Switching VLAN Page

On this page, the **Vlan Port 1** and **2** can be configured. With the **Refresh** button, you can update the different drop-down lists.

### Standalone 1+1 Redundancy Page

On this page, the status of the primary and secondary device is displayed, along with some other parameters.

A number of buttons are available:

- **Redundancy Availability:** Enables or disables the redundancy availability.
- **Primary Config Copy:** Copies the configuration of the primary device.
- **Secondary Config Copy**: Copies the configuration of the secondary device.
- **Primary Active**: Sets the primary as the active device.
- **Secondary Active**: Sets the secondary as the active device.
- **Reboot Device**: Reboots the device.
- **Reset Card 1 - 6**: Resets the selected card.
- **Refresh Data**: Refreshes the displayed data.

### Device Logs Page

On this page, you can fill in the **Log File Location**, set the **Max** **Number of Log Files** and set **Enable Logging (10 min poll)** to *True* or *False*. With the **Get Logs** button, you can send a request to the device to get the log files.

### Current Config Page

On this page, you can view the **Current Local Config** via the **Show Current Config** button.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

Starting from driver range **2.0.0.x**, the Ericsson SPR1100 driver supports the usage of DCF and can only be used on a DMA with **9.0.0.0** as the minimum version.

### Connections

**Connection Properties** that can be used to filter a **Connection**:

- **Input TS IP**: TransportStream (Source IP:Port)
- **Output TS IP**: TransportStream (Destination IP:Port)
- **Input Service**: Service
- **Output Service**: Service

## Notes

The tree controls in this driver can only be displayed in DataMiner Cube.

Changing the element name will not automatically push the changes to the redundancy information of other elements, which means that a manual restart of the element with the name change is currently still necessary.

Version 3.0.0.x was created specifically for Proximus. The DisplayColumn option was replaced with Naming for all tables.

## Addendum 1: All Possible Alarms

(Build version: 6.23.0.137978)

(Please note that \[X\] indicates a number)

Over Temperature WarningOver TemperatureInvalid ParameterVideo/Audio Module ErrorPower On Self Test FailureInternal HW InformationOption Card Build Version MismatchInternal Reflex Operation CompromisedVideo Processor Boot FailureVideo Processor Alive Count FailureVideo \[X\] Input LockVideo \[X\] Input MismatchVideo \[X\] Input QualityVideo \[X\] Input PCRVideo \[X\] SCTE35Video \[X\] ConversionAudio Module ErrorAudio Module CPU loadingAudio DSP Failed to BootAudio \[X\] Input lockAudio \[X\] TS input errorAudio \[X\] Compressed audio not detectedAudio \[X\] Input frame CRC failureAudio \[X\] Unsupported sample rateEthernet interface Ctrl1 link down on Control networkEthernet interface Ctrl1 on Control network: duplicate IP detectedEthernet interface Ctrl2 link down on Control networkEthernet interface Ctrl2 on Control network: duplicate IP detectedControl Network LostVirtual IP address on Control network: duplicate IP detectedEthernet interface Data3 link down in Data Interface Group 3-4Ethernet interface Data3 in Data Interface Group 3-4: duplicate IP detectedEthernet interface Data4 link down in Data Interface Group 3-4Ethernet interface Data4 in Data Interface Group 3-4: duplicate IP detectedData Interface Group 3-4: Data Network LostVirtual IP address on Data Interface Group 3-4: duplicate IP detectedEthernet interface Data1 link down in Data Interface Group 1-2Ethernet interface Data1 in Data Interface Group 1-2: duplicate IP detectedEthernet interface Data2 link down in Data Interface Group 1-2Ethernet interface Data2 in Data Interface Group 1-2: duplicate IP detectedData Interface Group 1-2: Data Network LostVirtual IP address on Data Interface Group 1-2: duplicate IP detectedPrimary Ethernet interface not in use on Control NetworkPrimary Ethernet interface not in use on Data Interface Group 3-4Primary Ethernet interface not in use on Data Interface Group 1-2Network Configuration failedOption card failed to bootOption Card Comms Failure in slotHW Configuration Mismatch in slotUnrecognized Option Card in slotReferenced Output Stream Unavailable from slot 1Referenced Output Stream Unavailable from slot 2Referenced Output Stream Unavailable from slot 3Referenced Output Stream Unavailable from slot 4Referenced Output Stream Unavailable from slot 5Referenced Output Stream Unavailable from slot 6Fan Failure+12V A Failed+12V B FailedReal Time ClockNTP Server Response TimeoutInternal Hardware IssueHost Build Version MismatchSystem Clock Not LockedChassis Identity Not ProgrammedSelected Mux SCR Source is not presentHost Identity Not ProgrammedUncontrolled releaseNo identity licenseTS NIT is not validUnsupported Option CardUnsupported Software on Option CardPOIS URL not configuredInvalid POIS URL configuredPOIS connection failureInvalid response from POISLost Contact With PeerUnit UnavailableConfiguration MismatchRedundant Secondary ActiveVersion MismatchRedundancy Parameters UnavailableConflicting RolesConflicting IP AddressesConflicting StatusPairing MismatchMGP FailureMGP CollisionMGP SpuriousDatagram loss is greater than 0Sequence number errors in Transport StreamNo data available for Input Transport StreamInput Transport Stream running on BackupInput Transport Stream missingNo data available for Input TS (\[Additional Info\])
