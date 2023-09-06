---
uid: Connector_help_Sunrise_UPC_NetCracker_Interface
---

# Sunrise UPC NetCracker Interface

The Netcracker element is a DataMiner element that will be used as an interface with the JMS (JavaMessage Service).

## About

The communication between Netcracker and DataMiner will be done through the Java Message Service (JMS). This technology allows Netcracker to communicate to DataMiner asynchronously using JMS queries. Based on Netcracker documentation, two queues are used (hosted by Netcracker platform):

- JMS to DataMiner: Requests from Netcracker to DataMiner
- DataMiner to JMS: Responses from DataMiner to Netcracker

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

Any incoming job is registered in the Message Log table where the primary key is the Job Message Correlation ID.

![Capture2.JPG](~/connector-help/images/Sunrise_UPC_NetCracker_Interface_Capture2.JPG)

The possible values for the Type column are: Activate, Replace or Deactivate, whereas for the State column are: Error or OK.



### Configuration

The user is able to configure the number of rows of the Message Log table by using the 'Maximum Number of Rows' or the 'Kepp Record for' parameters.

![]()




