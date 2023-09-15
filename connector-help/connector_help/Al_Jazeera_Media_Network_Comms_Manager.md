---
uid: Connector_help_Al_Jazeera_Media_Network_Comms_Manager
---

# Al Jazeera Media Network Comms Manager

The Al Jazeera Media Network Comms Manager is a virtual connector used to manage a group of connections for a PCR. The PCR does not return information, and as such, is controlled virtually through the connector. No communication is required.

## About

The connector is constituted by a simple table where 3 things controllable: Instances, OS ID's and Tally Colors. These three parameters are used to control the PCR's. It's important to notice that no traffic will be seen in Stream Viewer. CSV functionality is also available.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### OS Management

In here, the **Tally State Table** can be found. Adding rows to this table can be done on the **Add New Row Instance** parameter. The **instance** needs to have the following format:

PCRxy_OSz

where xy is a number between 01 and 99, and z is a number starting on 1 or higher.

The **OS ID**'s should be unique, but are not enforced to allow the user to change between 2 ID's already assigned to different PCR's.

Here, the CSV Management page can be accessed too. The CSV Management page allows you to set the **full path file** to be used as the CSV (it needs a valid full path, and must end in .csv). It's possible to both **import** a CSV file containing the table configuration, and **export** a CSV file of the current table configuration,

## Notes

A Visio will be available for this connector.
