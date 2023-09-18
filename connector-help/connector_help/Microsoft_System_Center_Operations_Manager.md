---
uid: Connector_help_Microsoft_System_Center_Operations_Manager
---

# Microsoft System Center Operations Manager

**Microsoft System Center Operations Manager** (**SCOM**) is a cross-platform data center monitoring system for operating systems and hypervisors. With this connector, a connection is made to the server hosting the SCOM application to extract monitoring information to DataMiner.
Polling happens via the SCOM DLLs (SDK binaries).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                                             |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Microsoft.EnterpriseManagement.Core.dll - 7.5.7487.142 Microsoft.EnterpriseManagement.OperationsManager.dll - 7.2.12150.0 Microsoft.EnterpriseManagement.Runtime.dll - 7.2.11719.0 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                               |
|-----------|---------------------|-------------------------|-----------------------|-------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Microsoft System Center Operations Manager - Category |

## Configuration

### Connections

#### SCOM Main Connection

This connector uses the SCOM connection and requires the following input during element creation:

SCOM CONNECTION:

- **IP address/host**: The polling IP of the SCOM server.

### Initialization

The following DLLs must be installed (in the folder C:\Skyline DataMiner\Files):

- Microsoft.EnterpriseManagement.Core.dll
- Microsoft.EnterpriseManagement.OperationsManager.dll
- Microsoft.EnterpriseManagement.Runtime.dll

These same DLLs must also be renamed with a prefix "M". This is needed to force the QAction to reference the DLLs from the Files folder instead of from the internal Microsoft folders:

- MMicrosoft.EnterpriseManagement.Core.dll
- MMicrosoft.EnterpriseManagement.OperationsManager.dll
- MMicrosoft.EnterpriseManagement.Runtime.dll

On the **Settings** page, the **Username** and **Password** must be filled in to communicate with the server.

Via the **Polling Manager** table, the intervals per request can be configured.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page contains a tree view of all Microsoft and Linux servers. Linked to that information are the Drives, Network cards, Linked Alerts and Events.

The data can also be accessed in table form on the **Servers**, **Alerts** or **Events** pages.

Polling intervals can be configured on the **Settings** page. Note that you can also use filters for the **Events** and **Alerts**. With these filters, you can limit the displayed data to what you want to view.

In the **Categories** table, you can define custom categories. This will be a first logical level for organizing the listed servers (i.e. the top level in the tree view).
Uncategorized servers are displayed under the *Default* category. For each category, you can choose to *enable* or *disable* DVE creation.
To **add**, **rename** or **remove** **categories**, right-click the table to use its context menu.

To link the servers to a certain category, change the value in the **Category Link** column of the **Servers** table.

## Notes

Since DVEs can be generated to represent the categories, it is important that each category name is unique in the DMS as an element name. If the name is not unique, a pop-up message will be displayed.
