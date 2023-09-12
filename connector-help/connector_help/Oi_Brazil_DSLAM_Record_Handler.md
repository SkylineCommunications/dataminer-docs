---
uid: Connector_help_Oi_Brazil_DSLAM_Record_Handler
---

# Oi Brazil DSLAM Record Handler

This driver is intended to add, update or delete DSLAMs, to update front-end and back-end collectors after the operation, and to verify if the appropriate changes were successfully completed.

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

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver is intended to be used with a specific Visio file, so that a custom "Visual" page is available in the element. On this page, you can select an operation and scope in the drop-down boxes in order to execute the following actions:

- ADD SINGLE: Fill in a unique name along with the correct IP and the appropriate information in the drop-down boxes and then click Execute.
- ADD BULK: After clicking Execute, fill in all the information you would like to add to the DSLAM with the appropriate header and separating all values with commas or semicolons.
- UPDATE SINGLE: Select the entity you would like to update and click Execute to change all available fields and then apply changes.
- UPDATE BULK: Similar to ADD BULK. After clicking Execute, fill in all the entities you would like to update and their new values. Changing names is not possible using BULK, only using SINGLE.
- DELETE: Select the entity you would like to delete from the list and click Execute.

On the Data page of the driver, the following functionality is available:

- You can change how long the handler will wait for the collectors to update, how many retries are possible before the attempt is considered to have failed, and how long table entries stay in the table before they are cleaned up.
- You can also change the file path in order to move the CSV file.
- The refresh button can be used in case the operations take longer than expected so that the handler does not clear out an entry.
