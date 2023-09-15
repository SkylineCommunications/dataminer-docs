---
uid: Connector_help_Elemental_Conductor
---

# Elemental Conductor

The **Elemental Conductor** is a video **encoder** network management system for live video delivery applications, offering comprehensive monitoring of video encoding.

## About

The **Elemental Conductor** connector is an **HTTP** connector that is used to monitor Elemental systems. With this connector, you can monitor conductor elements. These elements can include multiple nodes, such as live nodes in case of a Live Conductor, or file nodes in case of a File Conductor.

### Version Info

| **Range** | **Description**                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                               | No                  | Yes                     |
| 1.0.1.x          | New connector range based on 1.0.0.13                            | No                  | Yes                     |
| 1.1.0.x          | Remake of the connector, with similar layout as previous version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |
| 1.0.1.x          | Version 2.6                 |
| 1.1.0.x          | Version 3                   |

### Exported connectors

| **Exported Connector**    | **Description**                        |
|--------------------------|----------------------------------------|
| Elemental Conductor Node | Represents an Elemental Conductor node |

## Installation and configuration

### Creation

HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage (1.0.0.x and 1.0.1.x)

### Cluster Page

In the **Nodes table**, information will be added regarding all the nodes in the system, including the Conductor node. Many important values are displayed in this table, such as the **Hostname**, **IP Address**, **Status**, **Product (Conductor, Live or File)**, **Creation date**, **Version Nbr.** and **running events**. The number of running events for the Conductor node entry is the total of all the running events or jobs in the Live or File Nodes.

When the **Force Fail** button is clicked in the table, a command is sent to the Conductor device to **execute a force fail** on that specific node.

### Events/Jobs Page

On this page, there are two tables. The first table is the **Events/Jobs table**. Depending on the **conductor type (Live or File)**, this table will be filled either with events or jobs. This table is linked to the Nodes table. There are multiple buttons in the table to execute a specific command on an event or job, i.e. **Start**, **Stop/Cancel**, **Reset** and **Archive**.

The second table on this page is the **Outputs table**. In this table, all outputs are listed that are included in the events or jobs. For each entry, there is a link with an event or job. This table also allows users to execute commands individually for each output, with the **Start**, **Pause**, **Unpause** and **Archive** buttons.

### Channels Page

On this page, all channel data is available. This data is listed in separate tables.

The **Channels table** displays all the channels, with the following options: **Start**, **Stop**, **Pause** and **Unpause**.

**Channels Table** allows, as well, the user to define for each channel the transmitting node.

Aside from that, there is also the **Channels Inputs Group table**, **Channels Inputs table**, **Channels Outputs Group table** and **Channels Outputs table**. The Channels InOut table is used for the tree structure on the Overview Page.

### Statistics Page

The **Statistics table** displays all the statistics from all the nodes. There are three parameters containing the conductor statistics values: **Realtime**, **Total Frames/seconds** and **Queue Length** (Conductor File only).

All statistics are linked to their specific node.

### Alerts Page

The **Alerts table** displays all the alerts created in the system.

All alerts are linked to their specific node.

### Logs Page

The **Logs table** displays all the logs created in the system. In the column **Log URI**, you can select a log file and go to the log page through the browser.

All logs are linked to their specific node.

### Schedule Page

The **Schedule tree view** displays all schedules created in the system. This data is only polled for Conductor Live systems. There are no scheduled events on a Conductor File system.

The tree view contains a calendar view with years, months, days and schedules. If a schedule is of type "forever", then the schedules are displayed from today until 1 year in the future. All schedules are kept in the table for 1 year.

All schedules are linked individually to their specific node.

### Overview Page

The **Overview tree view** contains all information of the previous pages. The linking from all the tables to the **Nodes tables** results in one major tree view, where you can select data for each node such as: **Alerts**, **Events**/**Jobs**, **Channels**, **Logs**, **Schedule** and **Statistics**.

## Usage (1.1.0.x)

### Overview

The **Overview tree view** on this page contains all information of the previous pages, except the profiles. The linking from all the tables to the **Nodes** table results in one major tree view, where you can select data for each node such as **Channels**, **Channel Inputs**, **Channel Outputs**, **Channel Parameters**, **Alerts** and **Messages**.

### Cluster

This page contains the **Node Table**. This table contains information regarding each **Node** in the system, such as **IP Address**, **Version**, **Status**, number of **Channels**, **Inflight Channels**, **MPTS**, **Alerts** and **Messages**.

From this table, you can control if a node is **Enable**/**Disabled** for **DVE**.

### Channels

This page displays the **Channel Table** and **Channel Outputs Table:**

- The **Channel Table** displays information for each channel, such as the **Name**, **Node ID**, **Profile ID**, **Status**, **Elapsed**, **Buffer Average** and **Max** and **Dropped Frames**. The table also has a **Start** and **Stop** button, which can be used to start and stop channels.
- The **Channel Output Table** shows the Channel Outputs of each channel. It lists **Video Bitrate**, **Status**, **Elapsed**, **Width**, **Height**, **Audio Level**, **FPS**, **PCT**, **PCT RT**, **PSNR**, **URI** and **Content Source ID**.

The page also contains the **Channel Parameters** page button, which provides access to the **Channel Parameters Table** with more information regarding the channels, such as **Encoder SDI 1/2 Input**, **ESAM**, **Service ID**, **Service Name**, **Streams URL** and **bond0.400**.

### Alerts

This page lists the **active alerts**, with the following data: **Type**, **Name**, **Message**, **Last Set**, **Code**, **Alertable Type** and **ID**, **Node ID**, **Updated At** and **Readable Type**.

### Messages

This page displays the **Messages Table**, which is similar to the Alerts table.

### Profiles

On this page, the **Profile Table** displays information on the profiles: **Name**, **Permalink**, **Description**, **Loop All Inputs**, **Require Initial Timecode**, **Source**, **Backoff Time**, **Max Failures**, **Priority**, **Restart On Failure**, etc.

### Configurations

The **Username** and **API Key** parameters on this page are used to fill in the **logon credentials**. This is only needed **if the system is using authentication**.

**API Key is not** the same as **the password of the user** account. (See "Notes" section below.)

The **Connection Status** parameter shows if there is a connection to the device, or if you have used the wrong credentials.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The API Key that is needed to log on to an authenticated system is not the same as the password. To find the API Key, use the web interface, log on with the username and password, and go to *http://\<ipaddress_Conductor_Node\>/users.xml*.

If you cannot find the API Key there, check here instead: *http://\<ipaddress_Conductor_Node\>/user_profile*. Make sure that you do not copy "hidden spaces" before or after the key.
