---
uid: Connector_help_Interra_Orion_OTT
---

# Interra Orion OTT

ORION-OTT monitors ABR content, both VOD and Live, using user-defined automated / manual schedules. It checks for inconsistencies pertaining to ABR package compliance, manifest / playlist syntax, download errors, content quality and more. It can also be used for origin server load testing. The intuitive user interface of ORION-OTT presents the monitoring results of assets in an effective manner. You can drill down the monitoring runs to identify the most important issues, their location and occurrence(s) in an asset, along with more contextual information for debugging the issues. The web-based interface of ORION-OTT allows remote monitoring through any browser-enabled device giving users a comprehensive monitoring and reporting tool at their fingertips.

## About

This **HTTP** connector is used to monitor and configure the **Interra Orion OTT** Monitoring Platform.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | 1.6.2                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy* (default).

## Usage

### Configuration

This page contains the **username**, **password** and **session ID** as well as **Login**/**Logout** buttons to perform such tasks.

### Services

This page contains the **Services Table** which contains properties such as, **Service ID, Service Name, URL, User Content ID, Type, Status, Status Label, Format**.

### Services Summary

This page contains the **Services Summary Table** which contains properties such as, **Profile Name**, **Service ID, Service Name, Service Type, Status and** different types of errors divided by severity.

### Groups

This page contains the **Groups Table** which contains properties such as, **Group ID, Group Name, Content Type,** **Format, Time Schedule** and **Profile**.

### Alerts Summary

This page contains the **Query Duration** parameter that allows to modfy the alerts request and the **Alerts Summary Table** which contains two types of alerts, Recent and Active. It also shows more properties such as, **Service ID, Service Name, Type \[Recent, Active\], Variant, Start Time\[mm/dd/yy HH:MM:ss.ms\], Duration \[DD:HH:MM:ss:ms\], PID, Number, Level, Synopsis, Description**.

### Alerts Detailed

This page contains the **Alerts Detailed Table** which mainly contains the same properties of **Alerts Summary** table, but it works as alerts history with and implemented **Auto Clear** functionality embedded.

### Profiles

This page contains the **Profiles Table** which contains properties such as, **Profile ID, Profile Name, Type, Status, Description, Published XML,** and **Draft XML**.

### Monitors

This page contains the **Monitors Table** which contains properties such as, **Monitor ID, Monitor Name, IP Address, Port, Content Type, Status,** and **Storage Server Path**.

### Monitoring Summary

This page contains stats for the **Live Monirtoring Services** such as, **Active, Inactive, In Queue, Cleaned, Others,** and **Total**.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

20/02/2019 1.0.0.1 RBL, Skyline Initial version
