---
uid: Connector_help_Norkring_AS_Incident_Ticketing
---

# Norkring AS Incident Ticketing

This connector provides an interface between DataMiner and the Norkring AS Service Desk. It polls, creates and/or updates **Incidents**, **PAINs** and **Rodlampelogger** (red light logs).

## About

This connector connects DataMiner with the Norkring AS Service Desk Ticketing system. An element connected to SD will contain all the active tickets. Creating tickets in DataMiner should ideally be done by using the hyperlinks in the Alarm Console.

## Installation and configuration

### Creation

The read and write actions occur over two different connections for security reasons.

#### HTTP CONNECTION

This connection is used to send the GetIncident, GetPain and GetRLog SOAP requests.

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: A fixed destination port has been set to *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.
- **Timeout**: Although the HTTP interface internally follows the TCP/IP standards, please fill in a high enough value to receive large responses.
- **Retries**: Fill in how often a request must be retried when no response is received.

#### WRITE TO TOMCAT

This connection is used to send the write SOAP requests: CallServerMethod, login, logout and serverstatus. CallServerMethod has the methods *z_incident_create*, *z_incident_update_description*, *z_incident_set_outage_stop* and *z_rlog_create*.

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: A fixed destination port has been set to *8080.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.
- **Timeout**: Although the HTTP interface internally follows the TCP/IP standards, please fill in a high enough value so that ServiceDesk can process the requests in case there are many affected services.
- **Retries**: Determines how often a request must be retried when no response is received. Please use the default value of *0* to avoid conflicting requests to ServiceDesk.

### Configuration of credentials and settings

On the **General** page of the element, please make sure the following parameters are configured correctly:

- **Session Username**: The username with which DataMiner can send read requests and create a session on the write interface. This value must be filled in.
- **Session Password**: The password associated with the username above. To set an empty password, use the *Empty Password* option. Leaving the password set to *Not initialized* is not permitted.
- **Write Reattempt Delay**: The delay after a write attempt before the next try. This delay affects every request added to the caches separately.
- **Write Maximum Attempts**: The number of times a write request is attempted when a timeout happens or an unspecified error returns. After the first attempt, a delay is in effect as described above. The default value is *No Reattempts* (*1*).
- **Write Internal Timeout**: After a write request is sent, the element needs to wait a while for the data to become available. This parameter specifies how long the element will wait internally. Please note that requests with many affected services will have a large delay in ServiceDesk.

## Usage

### General

This page contains the settings, connection info and monitoring parameters. For more info on the settings, refer to the above section **Installation and configuration**: **Configuration of credentials and settings**.

Connection information:

- **Session ID**: The value of the currently active session used by the element. If this is empty, the element could not create a session and no write attempts will be made until a session has been made.

- **Session Last Message Time**: The last time a message has been received on the write interface. Used to determine if the session is still valid. ServiceDesk closes sessions after one hour of inactivity.

- **Write Session Connection Status**: Shows whether the session for the write interface is *Logged In*, is *L*ogged* Out* or has *Invalid Credentials*. Invalid credentials can occur when the username and passwords are *Not initialized*, when the username is *empty* or when the device reports that the credentials are invalid.

- **Read Session Status**: Displays any error information retrieved from ServiceDesk during polling. Displays either *OK: HTTP/1.1 200 OK* or *ERROR: \*,* where \* is the information fault included in the response or a dump of the response if it is not a valid SOAP message.

- **Write Session Status**: Displays any error information retrieved from ServiceDesk while attempting to communicate with the write interface. In addition to the Read Session Status, there is also a *WARNING: \*,* for when a write request is accepted, but contained non-critical validation errors on certain values.

- Buttons:

- **Create New Session**: Attempts to send a logout message and clears the session information in the element.
  - **Clear Write Status**: Since activity is low on the write interface, and the *callServerMethod* does not update the **Write Session Status**, this button can be used to set that status parameter to *OK*, stopping the alarm.

Monitor parameters:

- **~ in Last Poll**: The number of **Incidents**, **PAINs** and **Rodlampelogger** tickets in the latest poll cycle to ServiceDesk.
- **~ Count**: The number of active **Incidents**, **PAINs** and **Rodlampelogger** tickets in their respective tables.
- **~ in Cache**: The number of **Create Incidents**, **Update Incidents**, **End Incidents**, **Create Rodlampelogger** and **Close** **Rodlampelogger** write requests stored in the cache tables for further processing.

Page buttons for read and write requests:

- **Custom Poll**: The **Custom Polling** page allows you to build a custom read request. Since only one value will be interpreted by ServiceDesk, to avoid confusion, all other values will be cleared whenever one of the values is set. This does not influence **Tickets Type**, however, as this is required to determine which table to poll.

- **Create Incident**, **Create Rodlampelogger**, **Update Incident** and **End Incident**:
  The ticket creation/update page can be used to add a write request to the element's cache. These values are also available for Automation scripts, so it is best to use the appropriate medium, which is likely to be the hyperlinks in the Alarm Console. When the create button is clicked, the mandatory values will be presented once more for validation. If one or more mandatory values are skipped, the write request will be denied and shown in the **~ Status Message** box. The values will not be cleared until a valid request has been made.

- **Incident Creation**: Mandatory values are **Event ID**, **Station INSA**, **Event Time** and **Description**.
  - **Rodlampelogg Creation**: Mandatory values are **Event ID**, **Station**, **Event Time** and **Description**.
  - **Incident Update Description**: Mandatory values are **SD Reference** and **Description**.
  - **Set Incident End Time**: Mandatory values are **SD Reference** and **Outage Stop Time**.

### Table Pages

- **Active Incidents** table: Contains active incidents and allows you to configure the **End Time** and **Description**. When you edit either of these values, you will be able to change additional mandatory values that this parameter depends on in a pop-up window. Feedback is also logged in the corresponding pop-up pages.
- **Active PAIN Tickets** table: Contains the active PAINs for which the expiration time, if provided, has not yet lapsed.
- **Active Rodlampelogger** table: Contains the active Rodlampelogger (red light logs).
- **Active Problems** table: Contains the active problems (closed or rejected problems are ignored).

**Refresh ~** Button: This will force a refresh of the corresponding table, removing all entries not received in the response. This is identical to the polling after startup and after every 24 hours (see Notes section for more info). The table will not be cleared on invalid responses.

### Treeviews

These pages contain a **tree view**-based control for their respective tickets. The **Incidents** and **PAINs** will also have subnodes for the **affected services**. Click the triangle next to a node to check if there are subnodes (affected services). When you select an incident or PAIN node, the associated values will be visible in the pane on the right, in a more user-friendly format than the entries in the table. Affected services are listed in the table below the information pane.

### Close Templates

All closed templates are listed in the **Close Templates Table**. These templates can be used to close an incident when you solve a ticket.

### Services

Because **Incidents** and **PAINs** can have multiple affected services, they are mapped in a separate table. To view the link between a ticket and an affected service, please use the tree view. The mapping tables only show the references and how the ticket affects the service, but not actual information about the service itself, aside from the **Service Name**.

The **Service Name** and **Service Outage Stop** value is displayed for each **incident**. For **PAIN-**affected services, the **Service Name**, **PAIN ID**, **Service Impact**, **Work Start**, **Work End**, **Outage Start** and **Outage End** are displayed.

### Caches

The cache tables store the write requests that have been made until they are processed by ServiceDesk or have failed to be sent too many times. Each operation has its own cache table (CT), and their order of processing is as follows:

1. **Rodlampelogg CT**
2. **Rodlampelogg Close CT**
3. **Incident Creation CT**
4. **Incident Update CT**
5. **Incident End CT**
6. **Incident Close CT**

This is the order in which each cache table will be emptied before the next one is processed. Tickets that have failed but still have retries left and have not reached their retry delay will be skipped. Which means that if no valid requests are found in the first table, the second one will be checked and so on.

## Notes

Once the necessary credentials have been provided, the element will periodically (by default every 30 seconds) poll the tickets tables. Initially, all active tickets are retrieved, but later on only the changes are requested. As a failsafe, the entire table is refreshed again every 24 hours.

No inactive tickets are returned when the table is refreshed. However, when polling for updates, the tickets that have become inactive are included once. This will set the values as received in the element's table, and delete the inactive tickets when the next polling cycle starts or when their expire time is exceeded.

Active **Incidents** are defined by their **Active Flag** value. For **PAINs** and **Rodlampelogger**, this depends on their **Expire Time**. If a value is provided and the current datetime exceeds this value, the ticket will be deleted from the table.
