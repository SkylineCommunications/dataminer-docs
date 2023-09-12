---
uid: Connector_help_Skyline_CDMR_Task_Manager
---

# Skyline CDMR Task Manager

The driver can be used to display and control data on the Skyline Collaboration Platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                   | **Exported Components** |
|-----------|---------------------|-------------------------|---------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation: CDMR Task Controller CDMR Task Manager - Refresh Projects CDMR Task Manager - Refresh Tasks | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.

### Initialization

#### Credentials

The HTTP communication will not be up and running until the necessary HTTP credentials have been provided.
On the **General** page, the **user name** and **password** must be configured.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### Customers

On the **Customers** page, the **Refresh** button will trigger the mechanism to refresh the customer overview.

When you right-click a customer in the customer overview, the following options are available in the context menu:

- **Refresh:** Refreshes the selected customer.
- **Refresh Projects:** Refreshes the selected customer's projects.

### Projects

On the **Projects** page, the **Refresh** button will trigger the mechanism to refresh the projects overview.

When you right-click a project in the project overview, the following options are available in the context menu:

- **Refresh:** Refreshes the selected project.
- **Refresh Tasks:** Refreshes the selected project's tasks.

### Tasks

On the **Tasks** page, the **Refresh** button will trigger the mechanism to refresh the tasks overview.

To refresh a single task, right-click the task in the tasks overview, and select **Refresh** in the context menu.

### Inter Application Handlers

On the **Inter App** page, a handlers table has been implemented to handle the incoming communication.
