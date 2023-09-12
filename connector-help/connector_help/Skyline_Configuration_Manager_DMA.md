---
uid: Connector_help_Skyline_Configuration_Manager_DMA
---

# Skyline Configuration Manager DMA

The Skyline Configuration Manager DMA connector is used to manage the scheduling of jobs (i.e. groups of tasks) on the elements of a given DataMiner Agent. On DataMiner System level, management is handled by an element running the Skyline Configuration Manager connector.

Once the target elements are specified in the manager's configuration tables, you can schedule jobs, such as retrieving configuration files or pushing previously saved configurations to those elements. You can access this functionality via the **Create Scheduler Task** button of the DMS Manager element, known as the Primary element. The specifications of these jobs and elements affected by them are determined by filtering job parameters such as periodicity (once, daily, etc.), time of execution, job type, configuration type, and the affected connectors, views, and Agents. The DMA Manager, known as the Secondary element, is then responsible for scheduling the respective DMA job and informing the Primary of any updates.

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

This connector uses a virtual connection and does not require any input during element creation.

An element running the Skyline Configuration Manager DMA can also be created using the element (Secondary) creation functionality of a Skyline Configuration Manager (Primary) connector.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page contains the Configuration Table with **info on the local target elements** (elements on which jobs can be performed).

The **Configurations** page contains a **comparison** record between the stored configurations in the repository.

The **Jobs** page contains a general **overview of the jobs scheduled on the element's Agent** and a page button that shows information about the associated job results.

The **Internal Configurations** page contains the list of the connectors run by the target elements on the DMA and of the respective parameters from which the element-related values in the Configuration Table are retrieved.
