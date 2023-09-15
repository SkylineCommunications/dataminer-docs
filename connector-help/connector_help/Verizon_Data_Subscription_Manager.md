---
uid: Connector_help_Verizon_Data_Subscription_Manager
---

# Verizon Data Subscription Manager

The Verizon Data Subscription Manager is a DataMiner connector that is intended to gather information from the Entity Subscribers and interact with the DataMiner SRM (Service & Resource Management) module in order to retrieve, add, update and delete pools and resources.

## About

This connector implements the logic to:

- Import and export files.
- Retrieve, add, update and delete SRM pools.
- Retrieve, add, update and delete resources.
- Manage custom ID assignment for pools and resources.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Verizon RDS

This page displays the **RDS Thread State**, the last successful thread (**RDS Last Successful Thread**), and the date and time of the last success (**RDS Last Successful** **Datetime**). It also contains an **Update** button, which can be used to trigger the import/export process.

The **RDS Configuration** page button opens a subpage with the **RDS File Configuration**, which consists of the following parameters:

- **RDS File Handling:** By default, this parameter is *Disabled*. If you set it to *Enabled,* the entire file handling operation will be executed.
- **RDS File Path:** The file path for the import/export files.
- **RDS Processing Time:** Allows you to specify how often the file handling should be executed if **RDS File Handling** is set to *Enabled***.**
- **RDS Provisioning File:** Displays the status of the file handling operation (*Idle* or *Processing*).
- The **Apply** button, which will apply the settings mentioned above.

### SRM Overview

This page displays the SRM overview parameters, such as the **Last Thread Action**, **Date/Time** and **State**.

### Pools

Pools are created by the SRM module in order to perform the logical grouping of resources that belong to the same category. The table on this page displays the available pools. A context menu allows you to add, update and delete pools.

The connector retrieves the available SRM pools:

- After startup, if **SRM Update Status** is enabled (on the Configuration page).
- According to the **SRM Update Timer** cycle, if **SRM Update Status** is enabled (on the Configuration page).
- Whenever the SRM **Update** button is used (on the Configuration page).

### Subscribers

Subscribers are connectors that allow for the automatic provisioning of SRM resources. Subscribers are retrieved from, added to, and updated in the SRM module in the form of resources. A context menu allows you to add, update and delete subscribers in the table on this page.

The connector retrieves the available SRM subscribers:

- After startup, if **SRM Update Status** is enabled (on the Configuration page).
- According to the **SRM Update Timer** cycle, if **SRM Update Status** is enabled (on the Configuration page).
- Whenever the SRM **Update** button is used (on the Configuration page).

Only subscribers with the same name as an existing DataMiner connector may be added. Subscribers will always be added to the VSAT-SUBSCRIBER-POOL. If this pool does not exist, it must be created upon the first subscriber addition request.

### Resources

The management of resources is the ultimate goal of the DataMiner SRM module. This connector will perform the dynamic retrieval, addition, and update of resources towards their integration in the Verizon DataMiner SRM system.

The connector retrieves the available SRM resources:

- After startup, if **SRM Update Status** is enabled (on the Configuration page).
- According to the **SRM Update Timer** cycle, if **SRM Update Status** is enabled (on the Configuration page).
- Whenever the SRM **Update** button is used (on the Configuration page).

Note that the connector will only retrieve the resources in the VSAT-RESOURCE-TYPE-POOL, as these represent the many different categories of resources to be targeted within the system.

Via the **Add Resource** page button, you can add resources types and their corresponding properties. Additions are first performed in the SRM VSAT-RESOURCE-TYPE-POOL. After a successful SRM resource type addition, the requesting element will then update its different sections accordingly.

### Configuration

This page displays the available configuration options, such as **SRM Update Status**, **SRM Update Timer**, **Auto Collect**, **Auto Delete**, **Auto Delete Delay**, etc.

## Revision History

DATE VERSION AUTHOR COMMENTS
01/11/2018 1.0.0.1 FRO, Skyline Reports and Dashboards Solution integration
17/10/2018 1.0.0.3 AIG, Skyline Resource Manager integration
