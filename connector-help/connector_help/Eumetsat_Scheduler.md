---
uid: Connector_help_Eumetsat_Scheduler
---

# Eumetsat Scheduler

The Eumetsat Scheduler connector processes XML files in order to either create or update jobs in the Jobs app with the ultimate purpose of scheduling events that will execute the content of those jobs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

The connector operates in two distinct modes:

- **Automatic Ingestion of XML Files**: Every polling time (defined on the Configuration page), the connector will automatically ingest all the files in the folder.
- **Validation/Inspection of each XML File:** The user will need to decide for each XML file whether it needs to be ingested into the system or rejected and deleted from the folder. This can be done with the buttons **Ingest** and **Reject**. To help with this decision, information is displayed in the Task Comparison table. This table summarizes the impact the new jobs from the XML file will have on existing jobs that are already running in the system.

To switch operating modes, enable or disable the **Validation/Inspection Mode** toggle button in the configuration table.

The connector displays **statistics** regarding the last imported XML files.

Options are available to **activate or suspend** all the tasks for a **particular station** (according to the information present on the **Stations page**). It is also possible to **force suspend all the tasks** in the future or to **force a retrieval of a schedule** file.

On the **Configuration** page, you can define the **path of the folder** where the XML files should be retrieved, as well as the **path to the XSD schema** validation file. This page also allows you to configure the **polling interval**, the **default job domain**, and the name of the **script** that will be executed upon processing.
