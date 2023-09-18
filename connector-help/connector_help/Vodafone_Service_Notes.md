---
uid: Connector_help_Vodafone_Service_Notes
---

# Vodafone Service Notes

This connector is used to create an enhanced service, in which active alarms and subscribed elements are available. It also allows you to add, edit, and remove notes.

The connector requires DataMiner version **9.0.3** or higher.

## About

### Version Info

| **Range**            | **Key Features** | **Based on**                             | **System Impact** |
|----------------------|------------------|------------------------------------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | Skyline Service Definition Basic 1.0.0.7 | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### General Page

The **Service Severity** displays the current alarm state of the service.

### Alarms Page

The **Active Service Alarms** table lists the alarms involved in this service. To enable this table, set **Monitor Active Alarms** to *Enabled*.

### Elements Page

The **Service Element Status** table lists the child elements of the service and their alarm state.

### Notes Page

The **Notes** table lists all the notes posted on the service. The context menu of the table can be used to **add** or **remove** notes. To **edit** a note, you can write directly in **Title** or **Content** parameters in the table.

## Notes

This connector has a Visio file available to allow more user-friendly interactions. The interaction between Visual Overview and the connector is managed using the provided "Edit Note.xml" Automation script.

Visio icons reference:

![notes.png](~/connector-help/images/Vodafone_Service_Notes_notes.png) Opens the note visualizer.

![add.png](~/connector-help/images/Vodafone_Service_Notes_add.png)Opens a dialog where you can specify the title and the note you want to add.

![edit.png](~/connector-help/images/Vodafone_Service_Notes_edit.png)Opens a dialog where you can edit a title and content.
