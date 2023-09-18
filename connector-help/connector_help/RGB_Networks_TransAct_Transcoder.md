---
uid: Connector_help_RGB_Networks_TransAct_Transcoder
---

# RGB Networks TransAct Transcoder

This connector is used to monitor an **RGB Networks TransAct Transcoder**.

## About

The TransAct transcoder is a software transcoder that supports both stream-to-stream (live) and file-to-file transcoding operations. It supports both IP and SDI inputs, and a wide variety of input and output formats

Two external APIs are supported by the VMG2: there is SNMP support for traps and basic configuration information, and a full-featured XML-RPC interface for detailed configuration. This connector only uses the XML-RPC interface.

## Installation and Configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *byPassProxy* (enabled by default).

## Usage

This connector contains 23 pages.

### General

This page displays general information about the connectors: **Software** **Version**, **Time**, **CPU**, etc.

The page also contains **Controls** to manage the device (**Restart**, **Shutdown,** etc.).

The **Credentials.** button links to a page where users can specify their username and password.

### System Status

This page displays miscellaneous data about the system (CPU, Disk, etc.).

### Audio Map

This page displays all the audiomap tracks detected by the device. You can add or delete tracks.

### Inputs

This page displays all the input streams in the device. You can find information about the programs, video streams, audio streams, etc.

### Outputs

This page displays all the output streams in the device.

### Profile

This page displays the different audio and video profiles.

### Workflows

On this page, the **Workflow Table** contains all the available workflows on the device. The different encoding steps of each workflow are displayed in the **Encoding Steps** table.

### Sessions

This page displays all the running transcoding sessions

### Database

This page allows you to change the configuration of the database.

### Debug

The **Debug** page allows you to specify the level of warning for different processes.

### Key Server

This page allows Key server management.

### License

This page displays the license feature on this transcoder. The **Update** button gives access to license management.

The license can be updated in two ways:

- By directly filling in the **License File** text box with a string key.
- By uploading a file containing the license. This file must be located in the following DataMiner Documents folder: "*Documents/RGB Networks TransAct Transcoder/\[Element Name\]/License*".

### Transcode

This page displays multiple statistics about the transcoding operations.

### Network

This page contains various network configuration options: **Route Table**, **Ethernet Interfaces**, etc.

### NTP

This page displays the configuration of the NTP servers.

### RTSP

This page displays multiple statistics about the RTSP status.

### SNMP

This page contains parameters related to the SNMP Protocol, such as **Trap Servers**.

### Software Update

This page allows you to update the transcoder. The upload file must be located in the following DataMiner Documents folder "*Documents/RGB Networks TransAct Transcoder/\[Element Name\]/Update*". You also have to specify the **Username** and **Password** of a DataMiner user. It is recommended to create a user with minimal rights dedicated to this task (e.g. Update/Update).

### Events

This page displays the events of the transcoder.

### Log

This page displays the logs of the transcoder.

### Task Manager

This page allows you to retrieve information about a specific task.

### Web interface

The native web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
