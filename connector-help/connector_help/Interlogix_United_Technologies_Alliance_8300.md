---
uid: Connector_help_Interlogix_United_Technologies_Alliance_8300
---

# Interlogix United Technologies Alliance 8300

The Interlogix United Technologies Alliance 8300 virtual connector is a connector made to read and track log files from **Aritech Access** devices.

## About

The **Interlogix United Technologies Alliance 8300** is a virtual connector that reads the access history database and reports the last time someone passed through each location defined in **Location** parameters.

Because of the large number of entries in the table, the table is divided over several pages that contain up to 500 entries. In order to see the latest entries in the table, you must re-open the element.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection. No user input is required during element creation.

### Configuration of Database Connection

To retrieve the formatted values from the database, the connection configuration has to be filled in. You can do this via the **DB Properties** page button on any of the **Main View** **xx** pages.

## Usage

### Main View Page xx

These pages display the latest access logged in each location. To change the name of the locations, use the page button **Set Location**.

### List

This page displays a table with a history of records.
