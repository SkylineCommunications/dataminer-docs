---
uid: Connector_help_Skyline_IAM_DB_Provision
---

# Skyline IAM DB Provision

Within the IAM DB Solution, the **Skyline IAM DB Provision** connector is responsible for creating elements/views in the DMS.

## About

The **Skyline IAM DB Provision** element will retrieve data from the IAMDB MySQL database. It allows you to select the connectors for which you want elements/views to be created.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

On the **Settings** page of the element, you can add timestamps in the **Refresh Table**, which will determine when the connector starts provisioning. The timestamps need to be in the **HH:MM** **24-hour** format.

## Usage

The element created with this connector consists of the data pages described below.

### General

This page shows progress information about the element/view creation. **Import Progress** indicates the progress that has been made; **Import Status** shows a summary of the element/view creation.

### Protocols

This page contains the **Protocol Table**. In this table, you can toggle the creation of elements for each driver. The **Elements** button opens the Elements page in a pop-up window.

### Elements

This page contains the **Element Table**, which displays an overview of all the elements that have been created by the **Skyline IAM DB Provision** element.

### Settings

This page contains the database settings. The **Server**, **Database**, **Username** and **Password** are polled from the IAM DB element. In the **Refresh Table**, you can right click to select **Add TimeStamp** or **Delete All** to add a timestamp or delete all timestamps, respectively. The **Check Connection** button can be used to check the database settings on the IAM DB element again.

## Notes

The connector will offload two files to the folder *C:\Skyline DataMiner\DSL*. These files are used by the Skyline IAM DB element to update the element ID and view ID in the IAM DB.
