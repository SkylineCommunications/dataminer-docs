---
uid: Connector_help_Generic_File_Explorer
---

# Generic File Explorer

This connector can be used to move, copy and delete files from local or remote folders.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Select the action that you want to execute (Move, Copy, or Delete) and specify the source paths, destination paths, and file names for the operation. You can specify multiple sources, destinations, and file names, separating the different values with semicolons (";"), e.g. *X.doc;Y.jpg;Z.vtt*.

## Notes

The DLL **ProcessAutomation.dll** must be available in the system.
