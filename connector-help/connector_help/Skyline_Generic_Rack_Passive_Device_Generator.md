---
uid: Connector_help_Skyline_Generic_Rack_Passive_Device_Generator
---

# Skyline Generic Rack Passive Device Generator

The purpose of this virtual connector is to list devices not monitored by DataMiner (i.e. passive devices) that will be used in a rack overview representation (Visio file).

## About

This is a generic **virtual connector** designed to display passive devices on rack visual overviews without having to actively monitor them with an element in DataMiner.

### Version Info

| **Range** | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|-----------|------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version \[SLC Main\] | No                  | Yes                     |

## ConfigurationCreation

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

### Rack Passive Device Generator

This page displays the **Equipment** table, which allows you to add or delete rows via a button, context menu, or CSV file import. A row in this table represents a passive device. Each column in this table represents properties related to the passive devices that are used to dynamically position shapes in a rack overview (Visio file).

The following properties are available in the **Equipment** table: **Unit Name**, **Unit Rack Position**, **Unit Height**, **Rack View Name**, and Front/Rear **Position**.

If you want to import a CSV file, it must have the following structure:

`Display Key;Unit Name;Unit Rack Position;Unit Height;Rack View Name;Front/Rear`

> [!NOTE]
> Instead of a semicolon, it is also possible to use a comma (,) as the separator.
>
> Examples:
>
> - `Device Name 1;0;1;My View Name;Front`
> - `Device Name 2;1;2;My View Name;Rear`

An export to a CSV file will have the same structure as described above.
