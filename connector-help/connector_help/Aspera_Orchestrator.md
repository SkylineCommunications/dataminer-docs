---
uid: Connector_help_Aspera_Orchestrator
---

# Aspera Orchestrator

This protocol is used to interface with the Aspera Orchestrator platform. The Orchestrator platform uses containers as workflows, which consist of a series of connected steps, to automate the content collection, processing, and distribution. A workflow defines the series of actions to take. A workflow is started when a work order is created and launched. A work order is a runtime instance of a workflow, whereas a work step represents the smaller container in the system configuration.

The connector monitors all workflows, work orders and work steps. It also allows you to create new work orders and to monitor work orders from certain workflows.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default: 80
- **Bus address**: Default: *bypassproxy.*

### Initialization

The API access requires a user and a key. You can specify these on the General \> Connection Settings page.

## How to use

The element consists of the data pages detailed below.

### General

This page contains a tree view that provides a graphical overview of the workflows, work orders, and corresponding steps.

The page also contains the **Connection Settings** page button, which opens a page where you can fill in the API access credentials.

### Workflows

This page displays a table with all the workflows available in the system information. For each of the workflows, there is **Poll Workorders** toggle button, which allows you to enable or disable retrieval of work orders.

### Workorders

The polling range parameter at the top of this page is used as a filter to fetch work orders that are within a time range. By default, it is set to one day, meaning that it will look for work orders one day before and after.

Two page buttons are available:

- **Resources**: Displays a table with all resource names. You can add a resource by right-clicking the table and selecting **Add a row**.
- **New Workorders**: Incoming new work orders are displayed in a table. The definition of a work order is external to the protocol. To be able to create a work order, the create work order body must be set on the parameter with PID 500. The **Number of Rows Allowed** parameter allows you to configure the maximum number of rows in the table.

### Worksteps

This page contains a table with all the work steps available in the system. Depending on the workflow, there can be more or fewer work steps.
