---
uid: Connector_help_Sunrise_UPC_RPD_Jobs
---

# Sunrise UPC RPD Jobs

The RPD Job element is a DataMiner element that will be used to register the jobs retrieved by the Netcracker application. This element will register messages coming to DataMiner and also from the CCAP (Converged Cable Access Platform) element. Messages sent back to the Netcracker application will not be registered.

## About

In order to configure an RPD (Remote PHY Device), different Netconf messages are loaded into the CCAP. A Netconf message is built based on an incoming job - a generic object in DataMiner that can be used to represent an external activity or event.

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | **Initial Version** | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any configuration during element creation.

## How to use

### General

An incoming job is registered in the Job Events table where the primary key is the Job Message Correlation ID.

![Capture.JPG](~/connector-help/images/Sunrise_UPC_RPD_Jobs_Capture.JPG)

The possible values for the Type column are: Activate, Replace or Deactivate, whereas for the State column are: Executed or Cancelled.



### Configuration

The user has the ability to limit the number of rows in the table by using the 'Maximum Number of Rows' parameter.

It is also possible to set the path for templates (a template is Netconf message which is a predefined XML file defined by the customer).
