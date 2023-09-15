---
uid: Connector_help_DVEO_Streamer
---

# DVEO Streamer

The **DVEO Streamer** connector allows the monitoring of the input and output streams of a **DVEO Streamer** device

## About

This connector monitors the input and output streams of a **DVEO Streamer**.

All the data is retrieved via **HTTP-SOAP** protocol.

The connector displays information on 5 main pages :

- **Connection**: Allows users to enter their credentials and to start/stop polling the device.
- **General** **Input**: Lists all the input streams of the device and allows the user to start/stop the streams.
- **Input Details**: Displays more detailed information for each stream.
- **Input** **Tree View**: Contains the same data as the **Input details** page, but displayed in a tree view, making it easier to read.
- **Output**: Displays all the output streams.

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP Connection:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port**: The IP port of the destination*.*
- **Bus address**: If the proxy server has to be bypassed, specify: *bypassproxy.*

### Initialization

To start polling, enter your **User Name** and **Password** on the page **Connection**, and then click the **Connect** button.

If the connection succeeds, the **Connection Status** will display *Connected*, and the device will start polling. If the connection fails, **Status** will display *Authentification Failure*.

Note that the **User Name** and **Password** are saved in the database. If the device is restarted, it will try one time to connect to the device with the saved credentials.

## Usage

This connector contains 5 pages.

### Connection

This page allows users to enter their credentials and connect to or disconnect from the system.

### General Input

This page displays a table listing all the input streams of the system, regardless of their type.

The controls allow the user to **Start,** **Stop** or **Restart** each stream.

The table contains also information common to all kinds of streams: **Bitrate** and **Status**.

### Input Details

This page contains 4 tables: one for each type of stream (DVB, NET, Test, File).

Each table contains detailed information specific to each type of stream.

### Input Tree View

This page contains the same data as the **Input details** page, but displays it in a tree view, making it easier to read.

### Output

This page displays data about all the output streams.
