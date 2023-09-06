---
uid: Connector_help_IneoQuest_iVMS_ASM
---

# IneoQuest iVMS ASM

The **IneoQuest iVMS ASM** is a management system for OTT/multi-screen adaptive streaming. The iVMS ASM module will list all the connected probes with their respective data. Alarm monitoring and trending can be used to keep track of the probes, assets, streams, alarms, and their data. For easier navigation, a Visual Overview layer is available for this connector.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                            | **Based on** | **System Impact**                              |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|------------------------------------------------|
| 1.2.0.x              | \- Uses API calls to retrieve info about the probes, assets, streams, and alarms. - Uses SNMP to receive traps.                                                                             | \-           | \- New firmware using new API                  |
| 1.2.1.x              | \- A new API call is used to retrieve stream details. - The details are displayed as new columns in the Stream Monitoring Points table.                                                     | 1.2.0.2      | \-                                             |
| 1.2.2.x              | \- Open Alarms table renamed to Alarm Log and new Open Alarms table added. - DVE functionality added to create an element for each probe on demand.                                         | 1.2.1.3      | \- User interface changes.                     |
| 1.2.4.x \[SLC Main\] | Probe DVE removed. The following DVEs are created with this range: - IneoQuest iVMS ASM - Inspector Probe - IneoQuest iVMS ASM - Surveyor ABR Probe - IneoQuest iVMS ASM - IQDialogue Probe | 1.2.3.3      | \- User interface changes. - New DVE elements. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | 4.01.01.23             |
| 1.2.0.x   | 5.06.00                |
| 1.2.1.x   | 5.06.00                |
| 1.2.2.x   | 5.06.00                |
| 1.2.4.x   | 5.06.00                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                              | **Exported Components**                                                                                                                                                                                                                                                                                                                           |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | IneoQuest iVMS ASM - Inspector Probe IneoQuest iVMS ASM - Surveyor ABR Probe IneoQuest iVMS ASM - IQDialogue Probe |                                                                                                                                                                                                                                                                                                                                                   |
| 1.1.0.x   | No                  | Yes                     | IneoQuest iVMS ASM - Inspector Probe IneoQuest iVMS ASM - Surveyor ABR Probe IneoQuest iVMS ASM - IQDialogue Probe |                                                                                                                                                                                                                                                                                                                                                   |
| 1.2.0.x   | No                  | Yes                     | \-                                                                                                                 | \-                                                                                                                                                                                                                                                                                                                                                |
| 1.2.1.x   | No                  | Yes                     | \-                                                                                                                 |                                                                                                                                                                                                                                                                                                                                                   |
| 1.2.2.x   | No                  | Yes                     | \-                                                                                                                 | [IneoQuest iVMS ASM - Probe](xref:Connector_help_IneoQuest_iVMS_ASM_-_Probe)                                                                                                                                                                                                                                                              |
| 1.2.4.x   | No                  | Yes                     | \-                                                                                                                 | \- [IneoQuest iVMS ASM - Inspector Probe](/Driver%20Help/IneoQuest%20iVMS%20ASM%20-%20Inspector%20Probe.aspx) - [IneoQuest iVMS ASM - Surveyor ABR Probe](/Driver%20Help/IneoQuest%20iVMS%20ASM%20-%20Surveyor%20ABR%20Probe.aspx) - [IneoQuest iVMS ASM - IQDialogue Probe](xref:Connector_help_IneoQuest_iVMS_ASM_-_IQDialogue_Probe) |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SNMP Connection - SNMP

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *8001*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

When the element has been created, specify the **Username** and **Password** on the **General** page so that the connector can retrieve all the probes, assets, streams, and alarms info.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Range 1.2.2.x

In this range, **DVE functionality** was implemented, so that you can create a DVE element representing each probe, with the pages General, Assets, Streams, and Alarms. The name of the Open Alarms table in previous ranges was also changed to **Alarm Log**, and a **new Open Alarms** table was added.

In the Probes table, a new **Create DVE** column is available. Each row is by default set to *Disabled*. If you switch this to *Enabled*, a new row is created in the **DVE Probes** table, and a new probe element is created. If you switch to *Disabled* again, what happens depends on the **DVE Auto-Delete** option. If this option is enabled, the row and the element are deleted; otherwise, the **Detection Status** of the row changes to *Removed,* and the **Remove** button in the DVE Probes is enabled.

Two buttons are available that allow you to **Create All DVEs** or **Delete All DVEs** at once. In addition, when there are one or more rows in the DVE Probes table with Detection Status *Deleted*, there is a button at the bottom of the page that allows you to **Remove All Deleted** elements.

### Range 1.2.4.x

In this range, the DVEs **Inspector Probe**, **Surveyor ABR Probe**, and **IQDialogue Probe** are available. These DVEs can be configured on the **Probes** page and **DVE Options** subpage. The configuration is the same as in previous ranges, except that now there are 3 DVE tables with the configuration for the different types of DVEs.
