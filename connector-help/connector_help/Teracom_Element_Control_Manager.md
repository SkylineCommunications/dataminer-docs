---
uid: Connector_help_Teracom_Element_Control_Manager
---

# Teracom Element Control Manager

This protocol is used to automatically set and retrieve data from different elements in a cluster.

It scans the different views in the cluster for the technologies "FM", "DTTV" and "DAB". When these views are found, the physical sites they contain are listed up, as well as the various elements they contain.
Finally, automation data that is mapped according to technology and linked to a specific element is retrieved. In Visual Overview, adding commands for an element contained in a "technology" and "site" view is facilitated.

The protocol only communicates with the DMS in order to be able to retrieve/configure data from a central element.

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

### Initialization

First create the following view structure in the Surveyor:

- Technology View: DAB, DTTV or FM \> Site View (a physical location) \> the manageable element

Then create the following structure in the Automation module:

- Technology Folder: DAB, DTTV or FM \> Automation script linked to specific element

To make the protocol process these structures, configure the following parameters:

- If the **view structure** mentioned above is not available directly in the root view of the DMS, define the **root view** in the parameter **View Root**.
- Define the root folder for the Automation structure in the parameter **Automation Event Folder** (on the **Commands** page).

## How to use

The element consists of the pages detailed below.

- **Commands**: Lists the defined commands and the linked technology and protocol. A button is available to refresh all lists.
- **General**: Contains a table with actions, which allows the commands per site and technology to be executed. This table also contains feedback about the executed commands.
- **Actions Import/Export**: Allows you to import and export actions from/to a CSV file. To do so, specify the folder for the CSV file with the **Action Import / Export Folder Path** parameter. To select an import file, select it in the **Action File** drop-down box. Click the **Refresh** button if necessary to refresh the content of this drop-down box. Then click the **Import** or **Export** button, depending on which action you wish to take. The **Import / Export Logging** will show if a file was successfully imported or exported, or if any errors occurred.

## Notes

To execute the actions on the General page, the Visio file **Teracom Element Control Manager.vdsx** must be assigned to the element.
