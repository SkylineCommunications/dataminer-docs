---
uid: Connector_help_Solarwinds_NPM_Event_Agent
---

# Solarwinds NPM Event Agent

This connector is used to retrieve events from a SolarWinds database system.

## About

### Version Info

| **Range**                | **Key Features**                                         | **Based on** | **System Impact**            |
|--------------------------|----------------------------------------------------------|--------------|------------------------------|
| 1.0.0.x                  | Initial version.                                         | \-           | \-                           |
| 2.0.0.x \[**Obsolete**\] | Changed protocol name to include vendor name.            | 1.0.0.4      | \-                           |
| 2.0.1.x \[SLC Main\]     | Reworked driver as most of the features stopped working. | 2.0.0.1      | Old trend data will be lost. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When creating a new element, you will need to enter the SQL database configuration on the **Configuration** page. The **Database Connection** parameter will indicate if the connection with the database was successful.

### Redundancy

Redundancy is not defined in the connector.

### Web Interface

There is no web interface available.

## How to Use

### Event mappings

In order to retrieve events from the SolarWinds database, you will need to define mappings in the **Clear Event Mappings** table. A mapping is a link of two event types, the alarm event type and the clear event type.

The **alarm event type** is the type of event that is used to indicate if an event is an active alarm, the linked **clear event type** is the event type that will be used to clear the active alarm. For example, when you map alarm event type 10 to clear event type 11 and you receive an event with event type 10, this event will be marked as an alarm in the Alarms table. When you later receive an event with event type 11 that references the previous event, this will cause the previous alarm to be cleared.

### Polling of hosts and event types

An overview of the event types can be found in the **Event Types** table. This table also allows you to enable or disable the polling of certain event types. We recommend to only enable polling of events that are defined in the Clear Event Mappings table.

There is an extra alarm poll filter on the **Hosts** page where you can also enable/disable certain hosts. Based on the enabled hosts and event types, the matching events/alarms in the near future will be polled.

The **Hosts** and **Event Types** tables work together to establish the alarm polling. Whenever one of these tables contains no enabled entries, no alarms will be polled. To enable or disable certain entries all at once after you have selected them, use the right-click menu of the relevant table.

### Display key customization

You can also customize the display key. However, note that the following requirements must be met for the display key:

- The display key **must start with the Alarm Event ID**. You can choose the sequence of the other parts.
- The different parts of the display key must be **separated by slashes**.
- Each part of the display key must be **identical to a column name** within the Alarms table (*Alarm Event ID*/*Network Node*/*Event Type*/etc.).
