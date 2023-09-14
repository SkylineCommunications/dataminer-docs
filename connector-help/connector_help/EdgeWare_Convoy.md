---
uid: Connector_help_EdgeWare_Convoy
---

# Edgeware Convoy

The **Edgeware Convoy** connector is used to retrieve info from an Edgeware Convoy Device.

## About

This connector supports two different APIs, both using HTTP connections:

- The Operator API is used for basic monitoring of the device (hosts, fault reports, etc.).
- The Account API is used to manage the content of the device (content, channel, recordings, etc.).

## Installation and configuration

### Creation

This connector uses 3 connections:

**Serial Connection**

This is an SSH connection, which is used to retrieved the keys needed for both APIs.

- **IP address/Host**: The polling IP or URL of the destination.
- **IP Port**: The SSH connection must use port 22. This is set by default and not editable.

**Operator API**

- **IP address/Host**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the Operator API.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.* This is enabled by default.

**Account API**

- **IP address/Host**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the Account API.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.* This is enabled by default.

## Usage

This connector contains 6 pages.

### Login

On this page, the credentials required for the communication must be filled in: **SSH Username**, **SSH Password**, **Operator Username**, **Account Username**.

When these data have been filled in, the connector will try to retrieve the API key for the specified Operator and Account users. The user will be created if necessary.

### Operations

This page contains all information available via the Operator API: the **Host Table** with basic metrics and the **Faults Table**.

### Content

This page displays the contents available in the device. You can upload content via the **Upload Content** page button.

Two options are supported for the upload of content: **FTP** and **Local**. The mode can be specified via the **Upload Type** toggle button.

In FTP mode, the **FTP Options** (Address, Username and Password) must be filled in. In that case, the **Upload Variant Location** refers to the remote FTP file that must be uploaded.

In local mode, the **Upload Variant Location** refers to the local file that must be uploaded. This file must be located on the DataMiner Agent. The content of the file will be pushed to the device via an HTTP POST request.

Once an upload has been started, the status of the upload can be checked in the **Upload Status Table**.

### Channels

This page displays the channels available in the device. A new channel can be added via the **Add Channel** page button.

### Recordings

This page list all the scheduled recordings. New recordings can be scheduled via the **Schedule Record** page button.

### Sessions

This page list all the sessions in the device.
