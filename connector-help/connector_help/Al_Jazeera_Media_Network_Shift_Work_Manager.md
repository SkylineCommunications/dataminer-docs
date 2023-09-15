---
uid: Connector_help_Al_Jazeera_Media_Network_Shift_Work_Manager
---

# Al Jazeera Media Network Shift Work Manager

This connector can be used to display a generic table with a list of employees.

## About

This connector can be used to display a list of employees and of who is on duty. The information in the connector is either specified manually in the element or imported from a CSV file.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page contains the **Employees table**. You can add new entries to this table via its context menu. To add a new entry, you will need to specify the first and last name of the employee.

### CSV Management

On this page, you can both **import** a CSV file containing the information for the Employees table, and **export** a CSV file with the information of the current Employees table.

With the **CSV Full Path** parameter, you can set the file path where the connector can find the CSV file with employee information for import or where such a file should be exported. A valid full path is required, which must end in ".csv".
