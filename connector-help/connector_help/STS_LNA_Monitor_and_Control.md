---
uid: Connector_help_STS_LNA_Monitor_and_Control
---

# STS LNA Monitor and Control

DataMiner connector to monitor and control an STS LNA Controller.

## About

This connector doesn't communicate directly with a device. Element connections are used to link parameters from this connector with contacts of an IO box driver.

Some parameters show the combined status of multiple IO contacts as a single parameter.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the remote contacts.

After creating an element, it must be linked with an IO contacts device, i.e. Advantech ADAM. This must be done via the "**Element Connections**" application in DataMiner Cube. For more information see the DataMiner help.

## Usage

### General

This page shows all parameters that have to do with the LNA controller. Some parameters show the combined status of multiple IO contacts.

### Contacts

This page displays all parameters that are linked with the external IO contacts device.

## Notes

NA
