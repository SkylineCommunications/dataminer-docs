---
uid: Connector_help_Arris_Alarm_Central
---

# Arris Alarm Central

This connector is used to collect the alarms emitted by the **Arris Alarm Central** server.

## About

The **Arris Alarm Central** sends notifications to DataMiner via HTTP POST requests. This connector has a web service embedded that listens to those requests on a configurable port. Each notification is stored in a table.

### Version Info

| **Range** | **Description**                                                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                        | No                  | Yes                     |
| 2.0.0.x          | Changed protocol type to HTTP. The protocol can now forward HTTP posts. | No                  | Yes                     |

## Installation and Configuration

### Creation

#### Virtual connection (range 1.0.0.x)

This connector uses a virtual connection and does not require any input during element creation.

#### HTTP connection (range 2.0.0.x)

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: IP of the server that receives the forwarded HTTP posts. If HTTP post forwarding is disabled, this setting is not used, and any value can be specified, e.g. *localhost*.
- **IP Port**: Port of the web server at the server that receives the forwarded HTTP posts. If HTTP post forwarding is disabled, this setting is not used, and any value can be specified, e.g. *8080*. Default value: *8080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*. Default value: *bypassproxy*.

## Usage

### General

On this page, click the **Webservice** page button to select on which port the web service will be listening. The specified port number can range from 1025 to 65535.

All the notifications received by the element are displayed in the **Notifications Table**. You can manually delete an alarm. Cleared alarms will automatically be removed after a certain number of days. You can configure this number of days with the **Max Duration Alarms** parameter.

**Event Types Affected Devices** is a user-defined parameter that will contain a list of the event types, separated by pipe characters ("\|"), that will be used to find the total count of the **Affected Devices Event Type** (column in the **Notifications Table**). The number of affected devices is part of the information contained in the received notifications. In the total count of affected devices, only the highest detected severity is taken into account.

For example, if **Event Types Affected Devices** equals **USNOISE\|DSNOISE\|USFEC\|OUTAGE\|NCN_OUTAGE**, and in the notification we find the following:

- USFEC, critical = 20, USNOISE, minor = 25, OUTAGE, minor = 7,
  then this would result in **Affected Devices Event Type** equal to 20 affected devices. Only the highest severity (in this case **CRITICAL**) of the configured event types is counted.
- DSFEC, critical = 20, USNOISE, minor = 25, OUTAGE, minor = 7,
  then this would result in **Affected Devices Event Type** equal to 32 affected devices. The number of events with **minor** severity is added, since **DSFEC** is not on the **Event Types Affected Devices** list.

#### Version 2.0.0.x only

As of version 2.0.0.1, the Arris Alarm Central connector can forward the notifications received on the port configured on the **Webservice** subpage. These notifications are received as HTTP post notifications and are forwarded as such. The forwarding functionality can be enabled/disabled with the toggle button **HTTP Post Forwarding**.

For the post forwarding to work, a port and IP need to be configured in the element settings (see Creation section above).

The list defined in **Event Types Affected Devices** works as a filter to send new alarms northbound via HTTP post: if the received notification does not contain any of the defined event types, no HTTP post will be forwarded. However, when an already forwarded alarm receives an update, this update will also be forwarded, even if the event type linked to the alarm is different from the ones listed in the **Event Types Affected Devices**.

From version 2.0.0.4 onwards, the Arris Alarm Central connector can forward notifications to a second destination defined with the **Upstream HTTP Destination** parameter on the **HTTP Forward** subpage. These notifications are forwarded using the list defined in **Upstream Event Types Affected Devices** as a filter, as mentioned above. If a received notification contains an event type defined in both lists, the notification is forwarded to both destinations.
The total count of the **Affected Devices Event Type** is now associated with both lists: **Event Types Affected Devices** and **Upstream Event Types Affected Devices.**

### Path

Each notification can contain a path. All paths are gathered in the **Path Table**. Each path can have multiple NCNS, which are all listed in the **NCNS Table**.

### Root

The **Root Table** lists the root node of each notification.

### Fiber Nodes

Each notification can contain multiple fiber nodes. All the nodes are gathered in the **Fiber Nodes Table.**

### Issue Types

Each notification can contain multiple types of issues. All the issues are gathered in the **Issue Types Table.**

### Notes

Each notification can contain multiple notes. All the notes are gathered in the **Notes Table**.

### Inspection Points

Each notification can contain multiple inspection points. All the inspection points are gathered in the **Inspection Points Table**.

### Subscribers

Each notification can contain multiple subscribers. All the subscribers are gathered in the **Subscribers Table**.
