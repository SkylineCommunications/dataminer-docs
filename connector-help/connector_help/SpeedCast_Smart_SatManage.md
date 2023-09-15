---
uid: Connector_help_SpeedCast_Smart_SatManage
---

# SpeedCast Smart SatManage

The **SpeedCast Smart SatManage** connector can be used to retrieve data from a SatManage portal.

## About

The connector uses the SatManage API to retrieve data over **HTTP**.

A **DVE** is created for each site, though it is possible to enable/disable specific sites.

The GPS coordinates of each site are tracked and logged in a table. This table can be used for location trace capabilities in **DataMiner maps**.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Exported Connectors

| **Exported Connector**          | **Description**                 |
|--------------------------------|---------------------------------|
| SpeedCast Smart SatManage Site | A DVE is created for each site. |

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION:**

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration of the user credentials

On the **Configuration** page, specify the user credentials that are used to connect to the SetManage API.

## Usage

### Main element

### General

This page displays a table with all sites and associated parameters. The **Sites** page button opens a window where sites can be enabled or disabled.

### Location

This page displays the GPS trace table for all sites. This data is used for the location trace in DataMiner Maps.

### Configuration

On this page, an administrator can set the credentials that are used to connect to the API.

With the **Refresh Config** button, the connector can be forced to poll the site configuration. Normally, that information is refreshed every 15 minutes.

### Web Interface

This page displays the SetManage portal web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web
interface.

### Site DVEs

### General

This page contains the general parameters specific for this site, mostly used for configuration purposes.

### Location

This page displays location-related (GPS) parameters, such as the current location, distance heading and speed. The GPS trace table is also displayed on this page, but only containing the rows relevant for this site.

### Site Status

This page displays all statistical parameters that are collected from the API.

### Traffic Statistics

This page provides an overview of the bandwidth of all data that is currently transferred by this site. The traffic statistics are shown separately for TCP, UDP, HTTP, ICMP, IGMP, Reliable and Unreliable.
