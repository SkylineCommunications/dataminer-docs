---
uid: DIS_2.46
---

# DIS 2.46

## New features

### IDE

#### Set Param From: Parameter update locations [ID 37831]

When you right-click a parameter, you can now find a new option in the context menu: *Parameter Update Locations*

Clicking this option will open a new window that will show a list of all the locations where that parameter will (possibly) be updated.

Currently implemented:

- **Actions**: When a parameter is affected by one of the following action types: pow, multiply, increment, aggregate, changelength and go.
- **Groups**: When an SNMP parameter is included in a group.
- **Responses**: When a parameter is part of a response.
- **QActions**: When a parameter is set via `protocol.SetParameter` or `protocol.SetParameters`.

When you double-clicking on an item, you will be directed to the location of that item. You can also use the context menu to navigate and close the window at the same time.

#### Open Driver Help [ID 37964]

When you open a protocol XML file, the *DIS menu* will now include an *Administration* submenu, containing the *Open Driver Help* command. Selecting that command will open the default web browser and go to the connector help page on [DataMiner Connector Documentation](https://docs.dataminer.services/connector/index.html).

If no matching page can be found, you will be directed to a page explaining [how to add new connector documentation pages](xref:Connector_help_pages#adding-new-connector-documentation-pages).

### Validator

#### New checks and error messages [ID 37367]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 2.21.20 | UnrecommendedSshOptions                | Unrecommended option 'option' in Param 'pid'. |
| 2.21.21 | InvalidMixOfSshOptionsAndPortSettings  | Mixing option 'option' and PortSettings SSH is invalid. Param ID 'pid'. |

The *InvalidConnectionName* check (1.23.2) has been extended to expect *SSH Connection* for SSH connections.

### Snippets

#### New snippet: Interactive Toolkit [ID 37932]

A new snippet has been added that jump-starts the creation of interactive automation scripts with the [IAS Toolkit](https://www.nuget.org/packages/Skyline.DataMiner.Utils.InteractiveAutomationScriptToolkit).

It replaces the existing script class with a new one that contains boiler plate code that will help you work with the IAS Toolkit.

> [!NOTE]
> Due to snippet limitations, the NuGet package has to be added manually to the project.

## Changes

### Fixes

#### Table editor: Selected rows would not be visualized property [ID 37728]

In the Table Editor, selected rows would not be visualized properly, especially for *All Columns* and *All Displayed Columns*.

This has now been improved and made consistent with the DIS Tree View.
