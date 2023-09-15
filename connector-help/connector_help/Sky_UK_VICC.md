---
uid: Connector_help_Sky_UK_VICC
---

# Sky UK VICC

This Sky UK VICC connector is capable of showing which event is the current on-air event. It can also display the future events and past events for a certain automation system and channel, configured by the user.

## About

This connector retrieves a text file (in JSON format) from the VICC API, containing a collection of events (current on-air events, past events and future events scheduled to be on air) on a certain channel from an automation system. Each event in the collection might be a program part, a commercial, etc. The target automation system and channel to monitor can be configured by the user.

HTTP requests are used in this connector to retrieve the information from the VICC application in two different polling modes: **Fast poll** polls the device every minute and **slow poll** polls the device every hour.
When there are changes, data updates are sent by the application using the SignalR interface. This connector is also able to retrieve data using a WebSocket connection. This way, this connector can poll the device periodically by HTTP and handle data update messages sent by the application's SignalR and process these using a WebSocket connection.

### Version Info

| **Range** | **Description**                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, with SignalR interface working. | No                  | Yes                     |
| 1.0.1.x          | Support VICC API 2.11.0.                         | No                  | Yes                     |
| 1.0.3.x          | Updated smart-serial to WebSocket connection.    | No                  | Yes                     |

### Product Info

| **Range** | **VICC Application Version** |
|------------------|------------------------------|
| 1.0.0.x          | V2.0                         |
| 1.0.1.x          | V2.11.0                      |
| 1.0.3.x          | V2.14.1                      |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or hostname of the server e.g. *bcam.broadcast.bskyb.com.*

- **IP port**: The IP port of the device, e.g. *80.*

- **Bus address**: This consists of the automation system and the channel to monitor, separated by a forward slash. If a proxy server needs to be bypassed, also specify *byPassProxy*. You can use a comma (",") or a semicolon (";") as a separator.
  For example: *byPassProxy;SYSTEM1/LVH* or *byPassProxy,SYSTEM1/LVH*.

*WebSocket SignalR Interface connection*

This connector uses a WebSocket connection to receive the data from the SignalR interface and requires the following input during element creation:

WEBSOCKET CONNECTION:

- **Type of port:** TCP/IP
- **IP address/host**: The polling IP of the device, e.g. *bcam.broadcast.bskyb.com.*
- **IP port**: The IP port of the device, e.g. *80*.
- **Timeout of a single command (ms):** The timeout value for SignalR KeepAlive messages. The default value is 30 seconds.
- **Number of retries:** The number of retries when a timeout is detected in the SignalR connection, with the SignalR Normal Retry Interval configured on the SignalR Configuration page. After this number of retries, the connector will retry indefinitely with the SignalR Max Retry Interval defined on the SignalR Configuration page. The default value is 10 retries.

## Usage

### Configuration

This page contains numerous settings and parameters related to the configuration of the connector.

- At the top of the page, you can find the name of the **system, channel and server** that are being monitored.
- Next to this, the detected number of **events on air** and **future events** are displayed.
- With a toggle button, you can set the **Polling Mode** to either *Fast* or *Slow*. In **fast** polling mode, this connector polls the application **every minute**; in **slow** polling mode, this connector polls the device every hour. This page also displays the **URL** that is being polled and the **Polling HTTP Status Code** received from that request.
- From version 1.0.1.1 of this connector onwards, the parameters **Maximum Number of Future Events** and **Maximum Number of Past Events** are also available on this page. These parameters allow you to specify how many events the element should poll from the API. To poll all 500 events, set Maximum Number of Future Events to *-1*.
- With the **Debug Logging** toggle button, you can determine whether additional debug logging information should be added in the log file of the element. In case you encounter difficulties establishing a SignalR connection, we highly recommend enabling this setting.
- The **Expected Follow Bus** parameter allows you to either define the full Follow Bus name or use a wildcard (e.g. LV\* refers to all Follow Buses that start with "LV"; \*VH refers to all Follow Buses that end with "VH"). Any events that do not match the specified name will be displayed in the **Follow Bus Mismatches Table**.
- Finally, this page also contains the **Duplicated Events Table**, which displays all detected scheduled items with the same start date/time. These duplicate events are **not included** in the Future Events table.

### SignalR Configuration

This page contains parameters related to the SignalR connection as well as the **Leave Room**, **Join Room**, **Connect** and **Abort** buttons.

- The **SignalR Connection Status** parameter can have the following values:

- **Not Connected**: The connector is not connected to the SignalR server and is only capable of receiving data by HTTP polling
  - **Step 1**: The connector sent a Negotiate request to the SignalR server and is waiting for its response.
  - **Step 2**: The connector received the Negotiate response and has sent a Connect request to SignalR server
  - **Step 3**: The connector received a Connect response, has started to receive KeepAlive messages from the SignalR server and has sent a Start request.
  - **Step 4**: The connector has successfully received a Start response and has sent a JoinRoom request.
  - **Connected:** The connector has received a JoinRoom response and will receive data updates from the SignalR server.

- The buttons on this page can be used as follows:

- To enable SignalR messages reception, press the **Connect** button and wait until the **SignalR Connection Status** is *Connected*.
  - To stop receiving data updates but still receive KeepAlive messages from SignalR, press the **Leave Room** button.
  - To stop the SignalR Connection, press the **Abort** button and wait until the **SignalR Connection Status** is *Not Connected*. You can resume the connection once the status is *Not Connected* by pressing the **Connect** button.

- The **SignalR Connection Token** parameter shows the connection token used for the SignalR authentication. The default value is 0. If this is empty or set to the default value, a new connection token will be requested from the SignalR server when the Connect button is clicked. If a connection token is already defined, the connector will skip step 1 and use the token in step 2 (sending the Connect request).

- The **SignalR Timeout Status** shows the alarm status of the SignalR connection. If the connector does not receive a KeepAlive message for 30s, this parameter will be set to **Alarm** and the connector will try to reconnect automatically.

- **SignalR Last KeepAlive** shows the date and time when the last KeepAlive message was received by the connector.

- **SignalR Retry Counter** displays the number of retries that were executed to re-establish the SignalR communication.

- **SignalR Normal Retry Interval** is the delay time between SignalR Connection Retries when a timeout is detected in the SignalR connection.

- The **SignalR Max Retry Interval** parameter allows you to configure the interval that will be used after the retries configured in the SignalR configuration have taken place, in order to keep retrying during this delay time.

### On Air Event

This page displays all the attributes for the **On Air Event** detected in the VICC response (Start Type, Fixed Time, Duration, End Type, Segment, Type of Material, Event Number, Video Item, Start Date Time, Data Error in Schedule, Media Item Availability, Reserve Media Item Availability, Video Source On Screen Graphic Availability, On Screen Graphic Event ID, On Screen Graphic Reserve Availability, Subtitles Availability, Subtitles File ID, Voice Over Media Availability, Voice Over Media Event ID, Voice Over Media Reserve Availability, Voice Over Media Time Offset, VICC File Modified Date (oldest), VICC File Modified Date Table, Event Status, Master Follow Status, Master Follow Bus, Master Follow Tag; Clarity Event Number, Clarity Event Time Offset; Clarity Event 2 Number, Clarity Event 2 Time Offset; Watershed Start Time, Watershed End Time, Watershed Breach, Secondary Event Media Availability, Secondary Event Media Event ID, Secondary Event Media Reserve Availability, Widescreen Signaling Format, Widescreen Signaling Scheduled).

Via the Start Data Time page button you can access the **Data Distribution** pop-up page, where you can set the **Channel For User** and **Start Data Time** parameters. The subpage also contains a number of parameters related to first items, which are used in the Info on EWL - First Items workflow.

### Future Events

This page displays a table with all the instances of future events detected in the VICC response. This table has a column for each scheduled item property, with the same parameters as on the On Air Event page.
The display key for this table is "\[Event Number\]/\[Type of Material\]/\[Sequence Number\]".

### Past Events

This page displays a table with all the instances of past events detected in the VICC response. This table has a column for each scheduled item property, with the same parameters as on the On Air Event page.
The display key for this table is "\[Event Number\]/\[Type of Material\]/\[Sequence Number\]".
