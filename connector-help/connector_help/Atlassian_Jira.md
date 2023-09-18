---
uid: Connector_help_Atlassian_Jira
---

# Atlassian Jira

The **Atlassian Jira** connector is used to **create and update tickets** on the **Atlassian Jira ticketing system**.

## About

The Atlassian Jira connector uses the official JSON REST API to create and update tickets in the ticketing interface.

### Version Info

| **Range** | **Description**                                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                     | No                  | Yes                     |
| 1.0.1.x          | Connector review.                                       | No                  | Yes                     |
| 3.0.0.x          | Based on 1.0.0.x. Dedicated branch for costumer VOO. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.2.11                      |
| 1.0.1.x          | 5.2.11 7.3.6                |
| 3.0.0.x          | 5.2.11 7.2.7                |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *443* (HTTPS).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of authentication

This connector uses **HTTPS** and needs credentials to create and update tickets. These credentials can be set on the **Advanced** page, which can be accessed via a page button on the **Configuration** page.
You can either configure **Username** and **Password**, or configure the **Authorization Key**.

## Usage

### Ticket Creation

This page displays information related to the JSON command used to create a ticket.

The **Create Query** parameter displays the actual **JSON** **command** that will be sent to the Atlassian Jira interface. The **Ticket Creation Table** can be used to inspect the JSON in a more user-friendly way. Clicking the **Execute** button will send the JSON as displayed in the Create Query parameter to the REST interface.

The **Create Query** and **Ticket Creation Table** are **synced** at all times, which means if either one of these is altered, the other table will also be altered.

The **Mode** column in the **Ticket Creation Table** can be used to **exclude certain rows** from the JSON command in the **Create Query** parameter.

The **Add Field** button at the bottom of the page opens the **Add Field** page, which can be used to add extra fields to the **Ticket Creation Table**. The fields that can be added can be fixed types (provided in a drop-down box), but you can also add custom fields.

### Configuration

This page contains additional configuration parameters.

On the left side of the page, you can find the **Update Settings** and **Log Settings**. These settings do not necessarily have to be specified, but they can be used to manage certain aspects of the connector.

- The **Update settings** are only used for tickets that are **updated automatically** with the **Advanced** parameter, for example from an Automation script. These settings make sure that there are **not too many ticket updates** in the specified period of time. When the **maximum is reached**, the ticket updates will be updated later once the interval has passed.
- The **Log Settings** can be used to manage the **number of entries** in the **Ticket Log Table**.

On the right side of the page, you can find the settings **necessary** **to create tickets**. The **Ticket Location URL** is used in the commands that **create** and **update** **tickets**. This parameter should contain the ticket URL, by default *rest/api/latest/issue*. The **Authentication** button can be used to set the basic authorization settings for the Atlassian Jira environment. This can be either the **Authorization Key** or a **Username** and **Password** combination.

The **Advanced** button can be used to immediately set certain values in the JSON command and send the command to the Atlassian Jira interface. The syntax for the Advanced parameter must be **\<GUID\>\|\<Action\>(*CREATE* or *UPDATE*)\|field;value\|field n;value n\|.** The fields specified in this parameter will be added to the existing fields in the **Ticket Creation Table** and the command will be sent immediately. This parameter can for example be used in combination with an Automation script that **generates tickets automatically**.

In range 3.0.0.x of the connector, the following features are added on this page:

- The **Alarms** table to add the alarms that are being processed by operators.
- The **Get Eligible Ticket** subpage to search incidents.
- A new feature to interact with the custom API for some specific **Endpoints**.
- The **Responses** table to log the responses of the device.

### Log

On this page, you can check if the JSON commands that were sent by the connector were successful or not.

The **Create Log Table** contains information about the latest commands that have been sent. When a JSON command is sent to the device, a new row is added to this table.

- The **Type** column indicates if a ticket was created manually or automatically. *Manual* means that the ticket was created by clicking the **Execute** button, while *Automatic* means that it was created via the **Advanced** parameter.
- The **Time** column indicates the **date and time** when the request to create the command was sent.
- The other columns in the table will only be filled in once the response from the Atlassian Jira is received. If the **ticket was successfully created**, the **Status** will be changed from *Pending* to *Ok* and the **Ticket ID**, **Ticket Key** and **Ticket URL** will be updated with the correct value. If the **ticket creation was unsuccessful**, the **Status** will be changed to *Failed* and the **response** will be added in the **Error Message** column.

The number of entries in the **Create Log Table** can be managed by setting the **Maximum Entries** and/or the **Remove Entries Older Than** parameter.

- Setting the **Maximum Entries** parameter will make sure that the oldest tickets are always deleted when a new row needs to be added and the maximum number of entries has been reached.
- The **Remove Entries Older Than** parameter can be used to clean the table on a daily basis. **Every** **24 hours**, all tickets older than the value in this parameter will be deleted.

### Statistics

This page allows you to monitor the number of tickets that are **created** and **updated** on a daily basis.

It contains the parameter groups **Create Statistics**, **Update Statistics** and **Total Statistics**.

- The **Create Statistics** show the **total** number of tickets that have been created and the number of tickets that were created **today** and **yesterday**. The total and daily created tickets counter can be reset.
- The **Update Statistics** and **Total Statistics** are very similar to the Create Statistics but show the statistics for the **updated tickets** and the **total statistics (create + update)**, respectively.

### JIRA Interface

This page can be used to access the **Atlassian JIRA interface**. Note that client PC needs to have access to the interface in order to be able to display this page.
