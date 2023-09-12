---
uid: Connector_help_Generic_SMB
---

# Generic SMB

This driver is used to retrieve the subfolders and files from a local or network shared folder.

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

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

After a new element is created, on the **General** page, you will need to specify the **folder** you would like to access, together with the **credentials** of a user who has access to that folder.

## How to Use

The driver will regularly retrieve the subfolders and files of the specified shared folder and store them in the element. These folders and files are displayed in a tree view.

Note that the tree view is limited to a maximum of eight levels. This means that it is possible that though a subfolder is retrieved correctly, it is not shown in the tree view. To verify these "missing" folders or files, you can check the Folders and Files tables.
