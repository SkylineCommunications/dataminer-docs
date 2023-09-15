---
uid: Connector_help_Ziggo_Incident_Creator_Application
---

# Ziggo Incident Creator Application

Ticketing System for USMS tickets and trigger IVR.

## About

This connector will automatically create tickets based on correlated alarms. It also allows the operator to manually create tickets on existing alarms and even close them. The connector will list all created tickets and update their status from RSS feeds.

USMS tickets are forwarded towards Ziggo USMS Ticket Gateway connector and IVR is sent to Ziggo IVR Gateway connector.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Remote Elements

For each Gateway element, you need to configure the DMA ID and element ID on the **Remote Element Config** page.

### Configuration of RSS Feeds

On the **Ticket** page, the IP of the **RSS Feed Server** must be configured and an **RSS Refresh Time** must be set. This will update the **Ticket Table** with the info from the RRS feeds every x minutes. The **Resolved TTL** defines the time to live for each resolved ticket before it is deleted from the Ticket Table.

## Usage

### Tickets

The **Ticket** **Table** shows an overview of all alarms and the associated created tickets. It also contains tickets from the RSS feed server (if configured).

**Tickets stats** provides an overview of all ticket info grouped by platform. The TOTAL row contains statistics for all platforms.

### Ticket Config

To import data from a file, configure an import file in the **Import Config Table** and use the **Import** button. To check the result of the import, click the **Imported** page button. This imported data is used for different selection boxes during the creation of templates and tickets.

### Template

If you create a new template, it will be added in the **Template** table. Existing templates can be edited or deleted. Every template has its own preconfigured settings, used during the creation of new tickets.

A template can have multiple linked tasks. These are available in the **Template Task Table**. To edit a task, you need to configure the corresponding template.

### Remote Element Config

This page allows the configuration of the remote Gateway connectors (see "Installation and Configuration" section above).

### Source Tables

Within this page it is possible to find all the tables used to build the Tree Control seen in the **Tree Control Overview** page.

All tables are filled in automatically apart from the last one - **Time Window Table**. For this one, a button (Add...) is available in the **Tree Control Overview** page, where it is possible to set the start and end times for the time window, severity and platform.

The **Platform** table is filled in with the values found in the Element Properties (Platform Dashboard).

Note: for the **Start Time** and **End Time**, only the hour and minute matter but, it is important to choose also a day in the Start Time so that the **Day of the Week** can be filled in accordingly.

### Tree Control Overview

This tree control follows the next hierarchy (4 tables and relations between them):

1. Platform (detect from list of values in element property);
2. Severity (4 level: warning, minor, major, critical);
3. day of the week (7 days: monday, tuesday, wednesday, thursday, friday, saturday, sunday);
4. time window: (possibly) multiple time windows during which the time in which auto ticketing is allowed ( in form hh:mm-hh:mm).

### Close Incident Overview

- Index
- Incident ID
- DMA/Alarm ID
- Added On
- State
- Traffic State
- Retries
- Last GUID
- Last Updated

#### Closing Configuration

There is the possibility to enable **Detailed Logging** in the **Create and Close Config** page**.** If this setting is enabled, the connector is profiding you with all information of the flow of the connector in the logging of the element. If you disable this toggle button, only errors will be logged.

## Notes

For the creation of tickets and the configuration of templates, a custom Visio file and IAS is required.
