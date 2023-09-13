---
uid: Connector_help_CISCO_VDS-IS
---

# CISCO VDS-IS

Cisco Video Distribution Suite for Internet Streaming (VDS-IS) is an integrated system with a network-based architecture, Streaming Solution. The **Cisco VDS-IS connector** can be used to display information of and configure the Cisco VDS-IS system.

## About

**SNMP** and **HTTP** are used to retrieve parameters and display them on different pages.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version    | No                  | Yes                     |
| 1.0.1.x          | API implementation | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.2.1                       |
| 1.0.1.x          | 4.2.1                       |

### Exported connectors

| Exported Connector                             | Description                     |
|------------------------------------------------|---------------------------------|
| Cisco VDS-IS - Service Engine                  | Service Engine device           |
| Cisco VDS-IS - Service Router                  | Service Router device           |
| Cisco VDS-IS - Content Delivery System Manager | Content Delivery System Manager |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### System Description

This page displays general information about the system, such as the **System Description**, **System Up Time** and **API Credentials**.

### Interface

This page displays the system's **Network Interfaces Table**.

The parameters on this page are retrieved via SNMP.

### Groups

This page contains **9 page buttons** to the following pages. The parameters on these pages are retrieved via SNMP.

- **HTTP Group**: This page displays **CDS HTTP Requests** and **CDS HTTP Perf** (per second requests) parameters.
- **Movie Stream Group**: On this page, you will among others find the **Movie Streamer Total Requests** and monitoring parameters related to the Streamer.
- **Notification Info**: This page displays the name of the disk on which a **disk failure** event occurred.
- **FMS Group**: This page can be used to monitor the **FMS** server.
- **CAE Group**: On this page, you can find the total number of sent and received **CRREQ, CRRSP, CAREQ, CAIND** and **CANOT** messages, as well as information about the **Transcoded Content**.
- **HSS Group**: This page displays the number of sessions that have been started or stopped, the number of sessions that have failed, etc.
- **HLS Group**: This page displays the number of sessions that have been started or stopped, the number of sessions with errors, etc.
- **KCM Group**: This page displays information regarding **key request messages**.
- **CDS Generic Session Group**: This page displays information regarding the **active generic sessions**.

### WMT Group

This page displays WMT Proxy/Server information, such as **Requests** and **Errors**.

The parameters on this page are retrieved via SNMP.

### Alarm Group

This page contains a table with the generated alarms, as well as information about the displayed alarms.

The parameters on this page are retrieved via SNMP.

### CDSSR Group

This page contains page buttons that open subpages with information related to the CDSSR group. The parameters on these pages are retrieved via SNMP.

- **Overflowed**: The number of HTTP, API, ASX, RTSP, DNS, etc. requests that have overflowed.
- **Redirected**: The number of HTTP, API, ASX, RTSP, DNS, etc. requests that have been redirected to the Service Engines.
- **Requests Server**: The total number of requests and HTTP requests served.
- **Requests Received**: The total number of HTTP, API, ASX, RTSP, DNS, etc. requests received.
- **Statistic SE Table**: Table with the request statistics per Service Engine or per Service Engine IP.
- **Statistics History**: History statistics sample information.
- **DNS Queries**: Information regarding DNS Queries.
- **Not Redirected**: The number of requests that have not been redirected and the cause for this.
- **Service Monitor**: Table displaying the status of monitored objects.
- **Statistic Capacity**: The TPS of all the SR routing methods, as well as some additional information.
- **Statistics Content**: Table displaying request statistics per content origin.

### Devices

This page contains the **Device Table**, which displays a list of the devices, such as **Service Engines**, **Service Routers** and **Content Delivery System Managers**. The table also allows you to **control the DVE** associated to each device, for example using **Delete**, **Remove All Deleted** or the **Automatic DVE Deletion** toggle button.

The parameters on this page are retrieved via HTTP.

### Delivery Services

The page contains the **Delivery Service Table**, showing information like **Content Acquirer**, **Basic Authentication**, **Encryption**, **Local Manifest ID**, **Manifest URL**, **Content Origin ID**, **Content Provider ID**, **Origin FQDN**, etc.

The parameters on this page are retrieved via HTTP.

### Content Origin

This page displays the **Content Origin Table**, which contains information such as **Content Provider ID**, **Failover**, **Failure Alarm Duration**, **Recovery Alarm Duration**, **Switch To**, **Switch Time**, **FQDN**, **Origin FQDN**, etc.

There is also a **Switch to OS** page button, which requires you to select a **Content Origin ID** and **Origin Server**.

The parameters on this page are retrieved via HTTP.

### Files

This page contains the **File Table**, listing the files, their **Types** and other related information such as **Destination**, **Active**, **Last Change**, **Origin URL**, **TTL**, etc. You can also **Refetch** the file, **Apply Geo/IP** and **Register** the file.

The parameters on this page are retrieved via HTTP.

### CDN Statistics

The page contains the following parameters statistics related to the **Content Delivery Network (CDN)**:

- **Bandwidth Served**: **HTTP**, **Windows Media**, **Movie Streamer** and **Flash Media**.
- **Bandwidth Efficiency Gain**: **In**, **Out** and **Efficiency Gain**.
- **Streaming Session**: **Windows Media Unicast**, **Windows Media Multicast**, **Movie Streamer Unicast** and **Flash Media Unicast**.

The CDN statistics are retrieved every 5 minutes, as this is the minimum time frame in which the device holds statistical data. The current values are therefore calculated by the device as the average of the last 5 minutes.

The parameters on this page are retrieved via HTTP.

### HTTP Statistics

This page contains the **HTTP Streaming Statistics Table**, which contains the following parameters: **Requests**, **Bytes**, **Hit Rate** and **Updated**.

The statistics in the table are retrieved every 5 minutes, as this is the minimum time frame in which the device holds statistical data. The current values are therefore calculated by the device as the average of the last 5 minutes.

The parameters on this page are retrieved via HTTP.

### Server Engine Statistics

The page contains the following **statistics tables** related to the **Service Engine** devices:

- **Bandwidth Served**: **HTTP**, **Windows Media**, **Movie Streamer** and **Flash Media**.
- **Bandwidth Efficiency Gain**: **In**, **Out** and **Efficiency Gain**.
- **Streaming Session**: **Windows Media Unicast**, **Windows Media Multicast**, **Movie Streamer Unicast** and **Flash Media Unicast**.
- **CPU Utilization**

The server engine statistics are retrieved every 5 minutes, as this is the minimum time frame in which the device holds statistical data. The current values are therefore calculated by the device as the average of the last 5 minutes.

The parameters on this page are retrieved via HTTP.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
