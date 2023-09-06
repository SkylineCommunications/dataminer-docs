---
uid: Connector_help_Vodafone_Service_Notes
---

# Vodafone Service Notes

This driver is an Enhanced Service that makes active alarms and subscribed elements available in the service.

Additionally it allows a user to add, adit and remove notes.

Enhanced Services require a DataMiner version of **9.0.3.0** or higher.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td><ul>
<li>Initial version</li>
</ul></td>
<td>Skyline Service Definition Basic 1.0.0.7</td>
<td>-</td>
</tr>
</tbody>
</table>



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

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

### General

The **Service Severity** displays the current alarm state of the service.

### Alarms

The **Active Service Alarms** table lists the alarms involved in this service. To enable this table, please set **Monitor Active Alarms** to *Enabled*.

### Elements

The **Service Element Status** table lists the child elements of the service and their alarm state.

Notes

The **Notes** table lists all the notes posted on the service. The context menu of the table can be used to **Add** or **Remove** notes. The **Edition** of a note can be performed directly by writing on the table **Title** or **Content** parameters.

## Notes

This driver has a Visio available to allow more user friendly interactions. The interaction between the vision and the driver is managed using the provided "Edit Note.xml" automation script.

Visio Icons reference:

![notes.png](~/connector-help/images/Vodafone_Service_Notes_notes.png) Opens Note visualizer

![add.png](~/connector-help/images/Vodafone_Service_Notes_add.png)Opens a dialog that prompts the Title and the Note the user wishes to add

![edit.png](~/connector-help/images/Vodafone_Service_Notes_edit.png)Opens a dialog that allows a user to edit the Title and Content


