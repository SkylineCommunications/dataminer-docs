---
uid: Connector_help_NBCU_VOD_Manager_APP
---

# NBCU VOD Manager APP

The VOD Manager retrieves data from other elements to provide an overview of the VOD assets, including asset details, Witbe testing info and Conviva metrics.

## About

### Version Info

| **Range**            | **Key Features**                                                   | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Connection with Merlin Element and Witbe.                          | \-           | \-                |
| 1.0.1.x \[SLC Main\] | New logic added to do priority tests and reorder tables and pages. | 1.0.0.5      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

You can configure the communication with the following protocols:

- NBCU Witbe Maestro
- NBCU Merlin Collector

The VOD Manager exposes the parameter with ID 1 in order to receive asset details from the Merlin element. In the same way, it reports assets to that element if they have been parsed correctly in the configurable parameter ID of the General page. The test results retrieved by Witbe should be sent to the parameter with ID 2.

For testing assets, it is possible to create policies in order to define the devices that are going to test each asset. Policies can be created on the Policy page. A Default Policy can also be defined.

In the Assets table, the Policy Type column allows you to assign a policy to the corresponding asset. If no policy is assigned, the Default Policy will be used.
