---
uid: Connector_help_Envivio_4Caster_C4_2
---

# Envivio 4Caster C4 2

The Envivio 4Caster C4 2 is a connector that utilizes **SOAP over HTTP** in order to exchange information with the device.

## About

This connector implements the SOAP interface specification for exchanging information with the Envivio 4Caster C4 2. The connector lists the available services and the profiles in different tables. The user can also view the different audio and video streams for the profiles as well as the UDP, HTTP and RTMP outputs. There is also an alarm table listing the active alarms and their status. Aside from monitoring the device, the user can also upload new configuration files to the device and configure certain redundancy services.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 2.0.0.x          | Updated range   | No                  | Yes                     |
| 2.1.0.x          | New firmware    | No                  | Yes                     |
| 2.2.0.x          | New firmware    | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.1.0.x          | 6.x                         |
| 2.2.0.x          | 7.x                         |

## Installation and configuration

### Creation

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: *80* (automatically filled in by the connector).
- **Bus address**: Not required for this connector.

No other configuration is required for this connector to work.

## Usage

### General

This page displays the **System Model** and **Firmware Version.**

### Configuration

On this page, you can load and save configurations for the device.

### Port Redundancy

This page displays the **Redundancy Case Configuration Table** and **Redundancy Service Configuration Table.**

### Services Overview

This page contains all the services, profiles and corresponding inputs and outputs, displayed in a tree control.

### Services

On this page, the **Service Table** displays an overview of the available services on the device.

It contains subpages with information related to **audio**, **private** and **video inputs**.

It also contains subpages where you can **configure** the **audio** and **video** inputs.

### Profiles

This page displays the **Profile Table**, which contains the profiles found on the device. It is possible that old, removed profiles are still shown in this table, as these are not automatically deleted.

You can start/stop **profile recording** for the available profiles.

The page links to subpages containing the **audio** and **video** **tables**, **UDP**, **HTTP** and **RTMP** **Output tables**, and **private pass through**, **SCTE35** and **subtitling** streams.

It also contains subpages where you can **configure** the **audio** and **video** **tables**, **UDP**, **HTTP**, **Smooth Streaming** and **RTMP** **Output tables**, and **private pass through**, **SCTE35** and **subtitling** streams.

To push the updates to the device, on the **Upload User Configurations** page, press the **Encoding** button next to **Set User Configurations**.

From version 2.1.0.6 of the connector onwards, there are delete columns in the output tables: **Delete UDP Output**, **Delete HTTP Output**, **Delete Smooth Streaming Output** and **Delete RTMP Output**. When these are set to *Yes*, the output will be removed after the updates are pushed via the **Encoding** button.

### Alarms

This page contains a table with the active alarms. For each entry, the alarm state and severity are displayed.

### Performance

This page displays CPU usage and memory usage information. Note that these are averages and that the information is refreshed every 5 seconds.

A table with the CPU usage per core is also displayed on this page.

### System Configuration

This page displays the status of the SNMP connection, and the configuration of the physical and logical network interfaces.

The subpages contain information related to **input loss thresholds** and **time configuration**.

There are also subpages where you can **configure** the **network interfaces**, **input loss thresholds** and **time configuration**.

### Upload User Configurations

This page displays buttons that can be used to upload encoding and system user configurations to the device. The status of the upload process is also displayed, including error messages.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
