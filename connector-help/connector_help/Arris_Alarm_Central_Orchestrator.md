---
uid: Connector_help_Arris_Alarm_Central_Orchestrator
---

# Arris Alarm Central Orchestrator

The Arris Alarm Central Orchestrator connector is used to **receive Arris Alarm Central notifications**. The orchestrator will **forward** the received notifications via an **HTTP Post** to different AAC elements based on **patterns matching** the alarm IDs of the notifications.

## About

The Arris Alarm Central Orchestrator is an abstract connector that communicates with the Arris Alarm Central connector. The orchestrator connector is a **CPE manager** which provides **load balancing capabilities** for the AAC connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, default: *localhost*.
- **IP port**: The IP port of the destination, default: *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

The "General" page contains the **Orchestrator Table**. Initially, the table contains 16 entered **patterns \[0 - F\].** For each of these patterns the **destination DMA:Element** can be selected from a list that contains every Arris Alarm Central element present in the **cluster**. If the selected destination is on the **same DMA** as the AAC Orchestrator, then the Destination IP is **automatically set to "127.0.0.1"** and the port of the Destination element is found and filled, the **Destination IP (Orchestrator)** column will show, if for example, the destination port is 4000, **"127.0.0.1:4000".** If the destination is on **another DMA** in the cluster then the destination IP and Port of this DMA has to be **entered manually** in the format **Destination IP:Destination Port** (if not, data matching this pattern will be dropped).

When the AAC Orchestrator received a notification, it parses the notification for its ID and finds the **longest match** from the orchestrator table. It then determines the destination of this notification and **forwards** (by means of an HTTP Post) it to the correct AAC element. The port of the HTTP Post is retrieved from the **Webservice Port** of the corresponding AAC element.
For each pattern, a **counter** is kept indicating the number of **received notifications in the last minute**. This count is displayed in the **Notification Count** column.

Furthermore, it is possible to **delete existing pattern** from the orchestrator table or to **add new patterns** to the orchestrator table by right-clicking the table. These patterns have to be in **hex format**.

### Issue Type \[since v. 1.0.0.2\]

The "Issue Type" page contains the **Configuration Table**. This table displays a list of **AC Issue Types** and their correspondent **Service Impact** and **Issue Type.**

This table has to be imported from a .csv file:

1. Add the file path of the desired file in **CSV File Path**
1. Chose the file to be imported on **CSV File Name**
1. Click **Import CSV**

The **Service Impact** and **Issue Type** columns are editable.

The parameter **AC Issue Types with Outage** displays all the **AC Issue Types** in the table that have their **Issue Type** as "Outage" (case-insensitive). This parameter is automatically pushed to every element using Arris Alarm Central protocol with version 1.0.0.15, parameter id = 21: **Event Type Affected Devices.**

From version 1.0.0.3 onwards, a new list called **AC Upstream Issue Types with Outage** was added. The customer has to choose to which list the **AC Issue Type** (that have their **Issue Type** as "Outage") will be associated, using the **Forward Connection** column of the **Configuration Table.**

### Webservice

On the Webservice page, the Webservice **port** needs to be configured. When the port is configured the **state** will indicate **Ok** if the service is running or **Error** when the service fails, e.g. because of the port is already in use. If an error occurs, the **Webservice feedback** parameter shows the **information about this error.**
