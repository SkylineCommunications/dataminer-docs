---
uid: Connector_help_Skyline_Communications_CDMR_Scheduler
---

# Skyline Communications CDMR Scheduler

This connector allows you to schedule the leak scan operation on CDMR Agents. It adjusts the number of concurrent scans based on user configuration and current scans running on the system.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created a new element, configure the following parameters on the **General** page:

- **Max Scans**: Limits the maximum number of scan operations.
- **Customer Selection**: Limits the scans to one customer or to a comma-separated list of customers. If you specify *All*, they will run for all customers.
- **Max Running Scans**: Determines the maximum number of concurrent scans.
- **Max Scan Time**: Determines if the concurrent scans should be reduced or increased. They will not go over the value specified with **Max Running Scans**.

## How to Use

On the **General** page:

- The **Start** button will discover the existing CDMR Agents in the system. The Agents will be filtered based on the user configuration of **Customer Selection** and **Max Scans.** The filtered Agents will be marked as **Pending Scans**. From these pending scans, the connector will select a number of **Running Scans**.
  The running scans have several possible outcomes:

- **Completed**: The scan was successfully completed.
  - **Not Running Long Enough**: There is not enough information to run the scan.
  - **Error**: An error occurred during the scan execution.

- The **Stop** button will stop the scan operation by removing the **Pending Scans** and **Running Scans.**
