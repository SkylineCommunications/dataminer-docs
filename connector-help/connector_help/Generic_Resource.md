---
uid: Connector_help_Generic_Resource
---

# Generic Resource

The Generic Resource connector allows you to combine alarm states of different elements through element connections. It also allows the creation of virtual interfaces that are supported by DCF.

## About

### Version Info

| **Range**     | **Description**                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.1              | Initial version                                                 | Yes                 | Yes                     |
| 1.0.1.x \[SLC Main\] | Implementation of custom Input/Output table. Added DCF support. | Yes                 | Yes                     |

## Installation and configuration

## Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays the **Alarm Table** and the **Alarm State** (without the timeout state) together with the **Overall Alarm State** (with the timeout state).

The **DCF Interfaces** toggle button, which is disabled by default, can be enabled to allow access to the Interfaces page.

### Interfaces

This page displays the **Interfaces Table**. Via the context menu of this table, you can add inputs and outputs.

### Settings

This page displays the **Settings Table** and the **Selected Type**.

With the **Quick Type Table Set** parameter, you can populate the table with a single set.

## Notes

When the number of rows in the **Alarm table** is determined via **Selected Type**, the element connections can be configured under **Element Connections**.

For every key in the table, an element can be selected; as parameter, choose **\[Element Alarm State\].**
