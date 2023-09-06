---
uid: Connector_help_Generic_Webhook_Alarm_Table
---

# Generic Webhook Alarm Table

This connector shows received JSON objects in an Alarm Table. You can change the source URL and switch between HTTP and HTTPS requests.

## About

### Version Info

| **Range** | **Key Features**                                                                                                                                 | **Based on** | **System Impact** |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.1   | \- Inserting and modifying source URL.- Enabling/disabling automatic removal of rows in table.- Configuring rules for automatic removal of rows. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.1   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created the element, go to the **Webhook Config** page and configure the **URI** (defines the destination from which notifications are retrieved), **port number** (of the port that will be used to establish the connection), and **protocol** (HTTP or HTTPS). In case HTTPS is used, you will also need to select whether a specific available **certificate** is needed as well. Available certificates are displayed in dropdown menu.

## How to use

If the API specified during initialization is generating JSON objects with specific properties, alarms will be displayed in the Alarm Table.

The Webhook Config page contains all the parameters needed to establish a connection with an alarm API.

On the Table Config page, you can enable or disable the automatic removal of rows, and you can create rules for automatic removal by determining how long a row should be kept in table, what the maximum number of rows is in the table, whether alarms with normal severity are deleted, etc.

## Notes

Alarm properties that are supported by this connector are **alarm_id**, **severity**, **value**, **alarm_properties** (Property 1 - Property15).

This is an example JSON message:

{ "alarm_id": "alarm_id_error_1345", "severity": "critical", "value": "Bar" "alarm_properties": { "Property1": "SomeElement", "Property2": "Foo", "Property3": "NA", "Property4": "SomeValue1", "Property5": "SomeValue2", "Property6": "SomeResource", "Property7": "Fubar", "Property8": "test", "Property9": "yes", "Property10": "Fubar", "Property11": "Some Machine", "Property12": "Network is down", "Property13": "", "Property14": "", "Property15": "", }}
