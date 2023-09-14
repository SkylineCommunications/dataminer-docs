---
uid: Connector_help_RGB_Networks_TransAct_Packager
---

# RGB Networks TransAct Packager

This connector is used to monitor an RGB Networks TransAct Packager.

## About

The RGB TransAct Packager segments streams using adaptive streaming technology to deliver video and audio to computers, mobile devices and set-top boxes. The TransAct Packager ingests H.264 encoded video streams carried in an MPEG-2 transport stream (TS) and produces segmented output in multiple formats (RTMP, HLS, Microsoft Smooth Streaming,... ). The TransAct Packager can also ingest file-based content from RGB's TransAct Encoder/Transcoder to deliver just-in-time output for video-on-demand (VOD) or network digital video recorders.

Two external APIs are supported by the Packager: there is SNMP support for traps and basic configuration, and a full-featured XML-RPC interface for detailed configuration status and control. This connector only uses the XML-RPC interface.

## Installation and Configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify: *byPassProxy.* This is enabled by default.

## Usage

This connector contains 23 pages.

### General

This page displays general information about the connector: **Software** **Version**, **Time**, **CPU**, .

Controls are present on the page to manage the device: **Restart**, **Shutdown,** .

The **Credentials.** button links to a page where users can specify their username and password.

### System Status

This page contains miscellaneous data about the system: **CPU**, **Disk**, .

### Audio Map

This page displays all the audiomap tracks detected by the device. It is possible to add or delete tracks.

### Inputs

This page displays all the input streams in the device. You can view information about the programs, video streams, audio streams, etc.

### Outputs

This page displays all the output streams in the device.

### Package

This page allows you to group the inputs and outputs in packages. The page manages linear packaging only.

### Sessions

This page displays all the running sessions. Sessions can be stopped using the **Abort** button.

### Backup

This page allows you to **Save** or **Restore** the current configuration of the device. A backup can be taken via HTTP (saved on the device) or TFTP. For TFTP, **Host Server** and **File Name** must be filled in.

### Database

This page allows you to change the configuration of the database.

### Debug

This page allows you to specify the level of warning for different processes.

### Key Server

This page allows management of the Key Server and the Flash Access Server

### License

This page displays the license feature on this packager. The **Update.** button provides access to the license management.

The license can be updated in two ways:

- By directly filling in the string key in the **License File** text box.
- By uploading a file containing the license. This file must be located in the following DataMiner Documents folder: *Documents/RGB Networks TransAct Packager/\[Element Name\]/License*.

### Network

This page displays various network configurations: **Route Table**, **Ethernet Interfaces**, .

### NTP

This page displays the configuration of the NTP servers.

### Redundancy

This page allows you to configure the redundancy for the Packager.

### SNMP

This page displays parameters related to the SNMP Protocol, such as **Trap Servers.**

### Software Update

This page allows you to update the Packager.

The upload file must be located in the following DataMiner Documents folder: "*Documents/RGB Networks TransAct Packager/\[Element Name\]/Update*".

You will need to specify the **Username** and **Password** of a DataMiner user. In order to do this, it is recommended to create a user with minimal rights, dedicated to this task (e.g. Update/Update).

### Syslog Servers

This page displays information about the log servers.

### Users

This page allows you to manage the users of the system.

### Events

This page displays the events of the Packager.

### Log

This page displays the logs of the Packager.

### Task Manager

This page allows you to retrieve information about a specific task.

### Web Interface

The native web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
