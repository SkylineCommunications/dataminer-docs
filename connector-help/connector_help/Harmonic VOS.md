---
uid: Connector_help_Harmonic_VOS
---

# Harmonic VOS

This connector retrieves monitoring information from the Harmonic VOS application, which runs on Amazon Web Services.

It allows you to monitor the services, sources, and destinations, as well as logs, notifications, and Origin Engine info.

A Visio file is provided with the connector to group data and allow easy navigation.

## About

### Version Info

| **Range**            | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version. Most parameters are read-only, but you can configure the Service Control State. A Visio drawing is available. | No                  | Yes                     |
| 1.1.0.x              | OAUTH2 authentication.                                                                                                         | No                  | Yes                     |
| 1.1.1.x \[SLC Main\] | Added new connection to improve polling rate.                                                                                  | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | API version 1.2.0.0.78  |
| 1.1.0.x   | API version 1.3.5.0.122 |
| 1.1.1.x   | API version 1.3.5.0.122 |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device. Add a **leading "https://" before the IP**. This is required in order to support multi-threaded polling.
- **IP port**: The IP port of the device, by default 443.
- **Device address**: The device address, by default *ByPassProxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### Services

This page displays an overview of all the services with their configuration. However, we recommend using the Visio drawing instead of the element data on this page.

Via the **Add Service** page button, you can access a subpage where you can add new services to the Harmonic VOS System.

### Sources Overview

This page contains a tree control overview of all the sources with the connected inputs.

### Destinations Overview

This page contains a tree control overview of all the destinations with the connected outputs and connected output delivery types.

### Sources

This page contains tables with all sources and inputs. However, we recommend using the Visio drawing instead of the element data on this page.

Via the **Add Source** page button, you can access a subpage where you can add new sources along with new inputs to the Harmonic VOS System.

### Destinations

This page contains tables with all destinations, outputs, and delivery types. However, we recommend using the Visio drawing instead of the element data on this page.

Via the **Add Destination** page button, you can access a subpage where you can add new destinations along with new outputs to the Harmonic VOS System.

### Profiles

This page contains multiple tables with all **Multiscreen**, **IPTV** and **Destination** **Profiles**. However, we recommend using the Visio drawing instead of the element data on this page.

There is a **Multiscreen Video Profiles** **Table** linked to the **Multiscreen Profiles** and also an **Audio Profiles** table linked to both **Multiscreen** and **IPTV Profiles**.

### Cloud Links

This page displays the **Cloud Link** **Table**. Each row in the table represents a cloud link, with the following information: **IP Address**, **Rank**, **Version**, **Uplink State**, etc.

### Nodes

This page displays the Nodes table, which shows the **virtual PODs** from the **Kubernetes** table. Each row in the table represents a transcoding stream related to Harmonic VOS, with the **Host Name** (instance of the virtual POD) and the **CPU** and **Memory** usage.

This page also displays a tree control that represents the relation between the data displayed in the connector and the **Kubernetes** **- Services** page of the device web interface. At the top level, the tree control displays the list of PODs. On the second level, for each virtual POD, the list of its services is displayed.

The number of virtual PODs could be the same as the number of services. You can find the number of nodes on the **Origin Engine** page.

### Origin Engine

This page contains global Origin Engine statistics. These are also available per server so that it is possible to monitor the **CPU** and **Memory**.

### Image Slates

This page lists all available slates in the **Images Table**. The URL will redirect towards the image. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### SCTE Logs

This page displays all system logs in the **Logs Table**.

With the **SCTE Log Polling** parameter at the top of this page, you can configure whether SCTE logs should be polled. The **SCTE Logs Row Count** parameter determines the maximum number of log rows kept in the table.

### Notifications

This page displays all notifications of the system in the **Notifications Table**. At the top of the page, summary parameters indicate the notifications count per state/severity. These parameters are mainly used for the Visio file.

At the bottom of the page, a button allows you to open the **Notification Types** subpage. This page displays the **Notification Types Table**, which contains all possible notification types that can be received.

### Configurations

This page contains connection parameters related to the configuration of this connector. There are two ways of authenticating with the API. The method of authentication is determined by the option selected for the **Method of Authorization** parameter:

- Via **Authorization Code Grant**: In order to retrieve information from the API, the parameters **Username** and **Password** need to be set. (Initial method.)
- Via **Client Credentials Grant**: You must first obtain and set the **Client ID** and **Client Secret**. You can do so by registering the app manually from the web UI. (This method is recommended by the vendor as the most secure.)

## Notes

For easy navigation between services and all the details per service, the Visio file is required.
