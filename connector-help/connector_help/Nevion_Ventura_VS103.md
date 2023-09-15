---
uid: Connector_help_Nevion_Ventura_VS103
---

# Nevion Ventura VS103

With this connector, the **Nevion Ventura VS103 chassis** can be monitored, and new **DVE** elements can be created for the cards in the chassis slots.

## About

This connector monitors the Nevion Ventura VS103 chassis and supported cards through **SNMP** communication. Different connectors will be exported for the supported cards. A list can be found in the section "Exported Connectors" below.

### Version Info

| **Range**     | **Description**                                                                                                                                                                                                                                                               |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                                                              |
| 1.0.1.x              | Added DVE support for VS906 cards.                                                                                                                                                                                                                                            |
| 2.0.0.x              | Altered DVE support so each card has a different DVE. Added VS909 card support. Added VS902 card support.                                                                                                                                                                     |
| 2.0.1.x              | Merged configuration pending tables with current configuration tables. Implemented confirmation to immediately apply changes. DVE naming reviewed. **Because of changes, elements will have to be recreated to use this version. Older protocol versions should be deleted.** |
| 2.0.2.x              | New firmware support                                                                                                                                                                                                                                                          |
| 2.0.3.x \[SLC Main\] | **pollingRate** attribute and **MinimumRequiredVersion** tag introduced.                                                                                                                                                                                                      |

Notes:

- In version 1.0.1.2, support was added to create DVEs for VS906 cards.
- In version 2.0.0.1, DVE creation was separated to support different kinds of cards. At this point, DVE creation is supported for VS906 and VS909. The tables for each card type are adjusted to hide unused columns. The width of such columns is zero, so that they can still be opened from the header bar of the table.
- From version 2.0.0.4 onwards, connector help pages are created for each DVE. Usage information for each DVE has been moved to those separate pages. The input and output configuration flow tables have been added.
- In version 2.0.0.7, DCF and VS902 card support has been added
- From version 2.0.1.1 onwards, changes to card configuration fields are applied in the pending configuration tables and automatically applied to the current configuration.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Undetermined                |
| 1.0.1.x          | Undetermined                |
| 2.0.0.x          | Undetermined                |
| 2.0.1.x          | Undetermined                |
| 2.0.2.x          | Undetermined                |
| 2.0.3.x          | Undetermined                |

### Exported connectors

| **Exported Connector**        | **Description**                                                 |
|------------------------------|-----------------------------------------------------------------|
| Nevion Ventura VS901         | *In range 1.0.0.x* HD-SDI JPEG 2000 compression over GbE        |
| Nevion Ventura VS902         | *Before range 2.0.1.x* Video router module                      |
| Nevion Ventura VS906         | *Before range 2.0.1.x* A/D audio transport over IP module       |
| Nevion Ventura VS909         | *Before range 2.0.1.x* Media edge processor module              |
| Nevion Ventura VS103 - VS902 | *From range 2.0.1.x onwards* Video router module                |
| Nevion Ventura VS103 - VS906 | *From range 2.0.1.x onwards* A/D audio transport over IP module |
| Nevion Ventura VS103 - VS909 | *From range 2.0.1.x onwards* Media edge processor module        |

## Installation and configuration

### Creation

#### SNMP main connection

The Nevion Ventura VS103 is an SNMP connector. The IP needs to be configured during creation of the element.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: This is not required. If the value is 1, all the pages are shown. If the value is not filled in or other than 1, some pages are hidden (Interfaces, In-Band Management, Input Status and Output Status). The default value is *1*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Configuration

When a card of type VS906 or VS909 is inserted into the chassis, a DVE will automatically be created. However, if a card is removed, its row will continue to exist in the **Card Status** table (see "Card Status" below). To permanently remove the DVE, click the **Delete** button. If the **Row State** is *Deleted,* then the chassis has already removed this entry, but DataMiner keeps it so that its information is not lost without confirmation.

## Usage

### General

This page displays general information regarding the Nevion Ventura VS103:

- Device Temperature
- Alarm Status
- Main Status Table
- Fan Speeds

This page also contains the following page button:

- **Polling Details**: Provides access to a number of toggle buttons that can be used to enable/disable polling for some of the tables.

### Card Configuration

Aside from the **Main Configuration** and **Main Audio Configuration**, this page contains page buttons linking to the **Input** and **Output Configuration** pages.

These subpages display a set of tables with the **Input** and **Output Video**, **Audio** and **Flow Configuration**.

### Power Supply

On this page, the **Power Supply Status** column shows the status of each power supply.

### Interfaces

This page displays the standard SNMP ifTable **IP Interface Status**. It also contains an overview of the available **ASI Interfaces** and their status.

### In-Band Management

This page displays the **In-Band Management** table. Entries in this table are only available for Nevion Ventura VS103 - VS902 cards.

### Card Status

This page contains the **Card Status** and the **Card Configuration** tables. Both have one entry for each slot in the chassis.

In the **Card Status** table, you can delete invalidated rows and activate/deactivate DVEs with a toggle button.

In the **Card Configuration** table, you can manipulate the configuration files for each card separately.

### Input Status and Output Status Pages

These pages contain the **Status** and **Video Status** tables for the input and output with the appropriate values for each card.

### Card Alarm

On this page, the **Card Alarm Table** contains an entry for each possible alarm for each available card. The **Status** of the alarm is displayed as *On* or *Off*.

### Card History

All events that are logged can be found in the **Card History** on this page.

### Management History

This page displays the history of alarms for each of the chassis. The maximum number of lines in the table can be customized.

### Web Interface Page

This page displays the web interface of the chassis. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
