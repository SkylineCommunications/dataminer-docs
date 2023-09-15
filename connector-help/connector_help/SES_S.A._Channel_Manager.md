---
uid: Connector_help_SES_S.A._Channel_Manager
---

# SES S.A. Channel Manager

The SES S.A. Channel Manager is a virtual connector that provides an overview of all the available satellite channels. The information is provided by multiple monitoring systems.

## About

The SES S.A. Channel Manager uses **inter-element communication** to obtain information about all satellite channels. The connector communicates with **SES S.A. TEMOS**, **SES S.A. DCMS** and **Integral Systems Monics Automon UDP** elements using remote gets and sets. It also communicates with **IRD** elements by using element connections.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Channels

This page contains the **Configuration File** drop-down menu. This menu displays the **CSV** files that contain the configuration of the **inter-element communication** between the SES S.A. Channel Manager and the other elements. The files must be located in the folder "*C:\Skyline DataMiner\Documents\SES S.A. Channel Manager\Configuration\\.* The button **Refresh File** refreshes the drop-down menu.

The configuration files must contain the exact name of the connectors and the PIDs of the parameters that the SES S.A. Channel Manager will obtain. The following table shows the order in which the information must be filled in:

| **Connector** | **Channel** | **Orbital Position** | **Satellite** | **Tube** | **Uplink** | **Customer** | **Deviation** | **ULF** | **ULPol** | **DLF** | **DLFPol** | **ChainUplink** | **Modulation** | **DCMS Name** | **DCMS Channel Key** | **EIRP DCMS** | **EIRP CSM** | **C/N** | **Eb/No** | **TsLock** | **Monics CM Updates** | **Time Since Last EIRP Update** | **Last Modified EIRP** | **Time since last update** |
|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
| SES S.A. TEMOS | 1001 | 1002 | 1014 | 1003 | 1009 | 1012 | 1026 | 1005 | 1006 | 1007 | 1008 | 1010 | 1013 | 1030 | 1031 |  |  |  |  |  |  |  |  |  |
| SES S.A. DCMS | 1015 | 1008 | 100 | 1016 | 1010 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Wellav UMH160R-IP | 102 | 100 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Inverto IDLV-5x00 | 107 | 108 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Scopus Network Technologies IRD-2900 |  | 861 | 80 | 203 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Wellav UMH 160 | 208 | 62 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Ericsson RX8200 | 75 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Integral Systems Monics Automon UDP | 2001 | 2011 |  | 2021 |  | 2022 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| Astro U148 | 11106 | 11118 | 11102 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| TeamCast Neptune | 2002 | 1507 |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |

Select a **CSV** configuration file and press the **Refresh Table** button to obtain the information from **SES S.A. TEMOS**, **SES S.A. DCMS** and **Integral Systems Monics Automon UDP** elements. This button also executes the script **Element Connection Channel Manager**, which creates the element connections with the **IRD** elements.

Note: To create the element connections with the IRDs, make sure these elements have the property **TRANSPONDER_ID**. This property indicates the channel(s) that the IRD is linked to.

The Channels page also contains the **Channel Table**, which displays an overview of all the satellite channels available in the **SES S.A TEMOS** element. The display key of this table contains the concatenation of the **Channel** and the configured preset in the **Alarm Preset column**.

The following information is included in this table**:**

- **Orbital Position**: *Source -\> SES S.A TEMOS*
- **Dev. Sat/IP**: *Source -\> SES S.A TEMOS*
- **EIRP DCMS**: *Source -\> SES S.A DCMS*
- **EIRP CSM**: *Source -\> Integral Systems Monics Automon UDP*
- **C/N**: *Source -\> IRDS*
- **TS Lock**: *Source -\> IRDS*

If you click **Refresh Alarm Template**, the SES S.A. Channel Manager will duplicate its alarm presets in the Alarm Presets tables of **SES S.A. TEMOS**, **SES S.A. DCMS** and **Integral Systems Monics Automon UDP** elements (but with a suffix "\_CM") and will then activate the presets on the channels of these elements.

Finally, the SES S.A. Channel Manager will create alarm templates for all the mentioned elements, based on its current alarm template, including the preset filters.

### Alarm Preset

To facilitate the process of creating alarm templates, the **Channel** table has an **Alarm Preset column**. The content of this column corresponds to the content of the **Alarm Preset Table** on the **Alarm Preset** page.

Configuring presets in the **Alarm Preset Table** can be done by importing an XML file. To do so:

1. Select the XML file using the **Select Alarm Preset File** drop-down list. Use the **Refresh** button to update the **Select Alarm Preset File** drop-down list if necessary.

   The connector looks for the XML files in the following directory: "*C:\Skyline DataMiner\Documents\SES S.A. Channel Manager\Configuration Alarm Presets".*

1. Click the button **Import File**.

You can also add a preset in the table by selecting **Create Preset** in the table's context menu. This way, you can add the presets one by one. To delete a preset, click the **Delete** button in the **Alarm Presets Table**. The **Remove All** button can be used to delete all the entries from the table at once. To save an alarm preset in an XML file, click the button **Export Alarm Preset**.

Once an alarm preset has been assigned to a certain channel, this preset name can be used as a filter when you create alarm templates in DataMiner. This will allow you to configure different thresholds for the same parameter depending on the alarm preset filter.

### Errors

This page contains the **Integral Systems Monics Automon UDP Error Table**, which displays any duplicate key errors that occur in the Integral Systems Monics Automon UDP elements.

This page also contains the **IRD Element Connection Error** **Table**, which displays any duplicate key errors that occur in the IRD elements.
