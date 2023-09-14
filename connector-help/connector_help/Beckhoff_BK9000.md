---
uid: Connector_help_Beckhoff_BK9000
---

# Beckhoff BK9000

The Beckhoff BK9000 is a virtual connector that is used to provide information about the type and position of modules.

## About

The connector provides an overview of the different modules and allows the user to edit module types. Via a virtual connection, the Beckhoff BK9000 provides other elements with position information. This includes the module type and start and stop position.

### connector range 2.0.0

This connector help describes the 2.0.0 range of the connector. In this range, it is possible to change the number of modules dynamically by using a table.

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

The **PositionInfo** of the **Module Table** entries needs to be configured with a virtual connection to the **PositionInfo from BK9000** parameter of the relevant module connectors, e.g. the KL2622 connector.

## Usage

### General

This page displays the **Module Table**. This table displays three columns: **Module Name, Module Type** and **Module PositionInfo**.

The **Module Name** consists of "Module" followed by a number starting from 1.

The values in the **Module Type** column can be edited. You can choose between the following types:

- KL1104
- KL2134
- KL2622
- KL3064
- KL3122
- KL3202
- KL3152

After each modification in the **Module Type** column, the values in the **Module PositionInfo** column are recalculated. The PositionInfo is created depending on the type and the position of the module and other installed modules. It has the following format: *startposition*-*stopposition*\_*type.* A real example of such a value is *2-6_KL2134*.

The total number of entries in the table is shown underneath the table as **Number of Modules**.

With the two buttons, **Add module** and **Remove module**, you can respectively add a new entry to or remove the last entry from the Module Table.

If you enter a number in the **Wanted Number of Modules** parameter, the total number of entries in the table is changed to this new number. If this new number is smaller than the existing number of entries, the last entries are deleted. If the entered number is larger than the existing number of entries, new entries are added and the existing entries and their values are kept. Both the type and positionInfo of new entries in the table are initialized as 'None'. It is possible to delete all the entries, by entering the number "*0"*.
