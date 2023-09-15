---
uid: Connector_help_Ateme_Titan_Live
---

# Ateme Titan Live

Through this connector is possible to gather and view information from the device **Ateme Titan Live**. It also gives the possibility to configure the device.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x | Initial version | No | Yes |
| 2.0.0.x | Updated the protocol according to new MIB (version 3.4) also added a DVE for each entry of the Device table. | No | Yes |
| 3.0.0.x | Added HTTP API features | No | Yes |
| 4.0.0.x | Implemented the full HTTP API | No | Yes |
| 4.0.1.x |  | No | Yes |
| 4.0.2.x | No | Yes |  |
| 4.0.3.x | Corrections to Service output logic. A new primary key format was introduced for all output tables | No | Yes |
| 4.0.4.x \[SLC Main\] | Primary key of trap table changed. Display key unchanged. | No | Yes |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |
| 3.0.0.x          | \-                          |
| 4.0.0.x          | 4.1.10.5                    |

## Installation and configuration

### Creation

On connector range 4.0.0.x it only uses HTTP connection.

### SNMP Connection

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. 10.24.4.138

**SNMP Settings:**

- **Port number**: the port of the connected device, default 161
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private.

### HTTP Connection

- **IP address/host**: The polling IP or URL of the destination, e.g: http://10.24.4.138
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

This connector will create a DVE for each device attached to the main device.

### General Page

This page displays a table with the blades present on the device

### Web Interface Page

This page displays the device web interface.

### Device Page (DVE)

This page will show general information about the device. E.g. **Device Name**, **Device State**, **Device Output** **URL**, etc.

### Service (DVE)

On this page is possible to find information regarding the service provided by this device. E.g. **Service Name**, **Service State**, etc..

### Blade (DVE)

This page shows information about the blade on which the device is connected. E.g. **Blade Name**, **Blade Serial Number**, etc.

## Usage - Range 4.0.0.x

To use this connector,  on **Security Settings** page, first set a Username and a Password to authenticate all HTTP sessions.

Since version 4.0.0.7, it is possible to export each service as a DVE. This can be configured from the Services page.

### General Page

This page displays the device general information, e.g. Device Name, Firmware Version, CPU Load, Memory Usage, etc.

### SDI Cards Page

This page displays a table with SDI cards information (card name, status, FPGA ID, FPGA version, Board ID, Board version) also a table containing SDI inputs information (card name, input number, has signal, video format, mode).

### Services Page

This page displays the Services table. This table has the service name, service status, streaming status, input information, and output information.
Also, the user can stop, delete and start a service or all services.

From version 4.0.0.8 onwards, a Manage button is available on the Services, which starts a wizard that allows you to configure some parameters for the Service. The wizard uses the Automation script *Ateme_Titan_Live_Manage_Service*.

### Version 4.0.0.2 or higher

The parameter contains an option to change the Format of the SDI Input Port Name. For legacy reasons, this cannot be changed automatically.

The old format is sdi-card-x Input y, the new format is sdi-card-x/y.

### Services Overview Page (Version 4.0.0.2 or higher)

This page contains a graphical overview of the Transport Stream structure, with the Audio, Video and Data streams.

This contains a link to the pop-up page called **Service Tables**.

### Service Tables (Version 4.0.0.2 or higher)

This page contains the Tables that are also shown in a tree control : **Services**, **Output Transport Streams**, **Output Audio Parameters**, **Output Video Parameters** and **Output Data Parameters**.

The **Services** table contains information such as the **Status**, the **Streaming Status**, **Input Type**, **Output**, **Video Format**.

The **Output Transport Streams** Table is an internal table that is only used to link the **Profile** to the **Streams** that are part of that profile.

The **Output Audio Parameters** Table contains information about each Output Audio Stream, such as the **Codec**, the **Bitrate**, and the **Sample Rate**..

The **Output Video Parameters** Table contains information about each Output Video Stream, such as the **Codec**, the **Bitrate**, the **Framerate**.

The **Output Data Parameters** Table contains information about each Output Data Stream, such as the **Codec**.
**Service Tables was renamed to Services Output Tables on version 4.0.2.1**

### Service Input Tables (Version 4.0.2.1 or higher)

This page contains the tables that also to reconfigure the settings of the IP inputs services: Active Input, TS Smoothing, TS Sync Loss Failover and Timeout, Sync Bytes Erros Failover, PAT Failover and Maximum time between 2 PAT, PMT Failover and Maximum time between 2 PMT, PID Errors Failover and Maximum time between 2 PID, Continuity Failover, Timeframe and Threshold.

### Hardware Monitoring Page

This page displays the CPU temperature, the Power supply status and a table with all the fan information.

### Main Services Status Page

This page displays a table with all main services (NTP, SDI, syslog, VCA, SNMPD, etc.) status.

### Alarms Page

This page displays a table with alarms. The user can see only open alarms or all alarms, this option is performed with the toggle button Filter Alarms Status.

### System Configuration Page

In this page the user can configure the time, SNMP and Syslog.

### Network Configuration Page

In this page the user can configure the device network. The page has four tables, Physical Interfaces, Routes, VLANs and Statmux Pool.

### Alarms Configuration Page

In this page the user can configure the alarms.

### Security Settings

This page allows the user to enter a username and password to authenticate all HTTP sessions. To use all Sets the user has to authenticate with the API user.

### Encoding Page (Version 4.0.0.8 or higher)

The services available on the device are separated on TS Services and Encoding Services tables.

### Web Interface Page

This page displays the device web interface.
