---
uid: Connector_help_Broadcast_Automation_Systems_Equinox_TS
---

# Broadcast Automation Systems Equinox TS

The Broadcast Automation Systems Equinox TS connector is capable of remotely controlling recordings by the Equinox system. It is an HTTP REST-based web service, aiming to retrieve all information.

The Equinox TS is a logger for transmission streams that is mainly used for video capture, media monitoring and media archiving.

## About

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|-----------|------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version. | No                  | Yes                     |
| 1.1.0.x   | New firmware.    | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0                    |
| 1.1.0.x   | 7.0                    |

## Configuration

### Connections

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.80.117.4.*
- **IP port**: The IP port of the destination, e.g. *80*.
- **Bus address**: *bypassproxy.*

Note: In order to access the Equinox Web Service API, you need a dedicated login.

## Usage

### General

This page displays device information, such as **Version**, **Keep Alive**, **User Name**, and **Password**.

The EQKeepAlive function prevents a session timeout. Its frequency to keep the session alive is 60 seconds. A unique session identifier named "Guid" is returned by the EQAuthentication function. The EQKeepAlive function accepts this "Guid" parameter and returns 0 (server unavailable) or 1 (success).

### Global Settings

This page displays the global settings configured by the administrator.

The "User ID" and "Guid" are the input parameters of the function. The following parameters are returned by this function: **Global Settings ID**, **Logger Monitor Port**, **Webserver IP**, **Webserver** **MMS** **Port**, **Editor** **Server** **IP**, **Editor Server Port**, **SNMP Broadcast IP**, **Mail Server IP**, and **Mail Server Port**.

### Channel List

On this page, the **Logger Table** displays the allowed channels for the specified user.

The EQChannelList function belongs to a group of functions used for browsing the channels and their associated media clips. The following columns/parameters are present in the table: **Channel ID**, **Live URL**, **Channel Name**, **Image Name**, **Recorded URL**, **Recorded External URL**, **Network Path**, **Clone Channel Name**, **Logger Number**, **Logger Name**, **Logger IP**, **Port Name**, **Remote ID**, **Port Type,** **Record TS**, and **Port Status**.

The **Port Status** function returns the status of a specified port in a logger (*Port Started* or *Port Stopped*). You can find an extra column called "**Port Control**" in the table, which allows you to start or stop the service of a specified port in a logger. As input, the function accepts the parameters Logger IP, Port Name, Operation and Guid.
