---
uid: Connector_help_Skyline_CRM_Simulator
---

# Skyline CRM Simulator

## About

SQM-DemoSubscriberData connector to offload data in DSL format. Latitude, longitude & offset parameters are configurable as well as the names and service package types.

This protocol is pure for CRM simulation.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 0.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Data

Contains of 4 tables, CM Data Table, Node Data Table, CMTS Data Table and Subscriber Data Table. All values found in these 4 tables are randomly generated. The generate the data, you must go to the Configurations page and click "Refresh Data". There is also the possibility to clear all data from the tables, this is done by the "Clear tables" button, can be found on top of the page.

### Simulated Data

Contains of 3 tables, CMTS location data, ServicePackage data and UsersNames data. This is the data which will be used to be able to create randomly combinations for the data page. Every cell found on this page is editable.

Only first row of the CMTS location data will be used!!!

### Configurations

Here you can import and export the "simulated data" to XML file. To do this you need to set a file location, e.g. D:\file.xml and push one of the 2 buttons (Import XML or Export XML).

The other import is trough the Topology Data, this exists of csv files which contains the CTMS, node and CM data. The folder structure for the Topology must be like mainFolder/CMCollector/... and mainFolder/ManagerID/...

Always be sure there is a file location set for any of these input fields!

Steps: 1) import the XML data 2) import Topology data (not the way around)
