---
uid: Connector_help_Snell_Wilcox_RollCall_Logserver_-_Element
---

# Snell Wilcox RollCall Logserver - Element

This driver is used to create DVEs that show the information for each different device monitored by the parent driver **Snell Wilcox RollCall Logserver.**

## About

This is a smart-serial driver, which will receive log entries from a log server. Each log entry will be parsed and the parameters present will be added to a table.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Not available.              |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver Snell Wilcox RollCall Logserver.

## Usage

### General Page

This page shows a tree control. The first level contains the device slots, while the second level contains all the parameters for each slot.

### Slots Page

This page contains a table with all the slots available on the device.

### Parameters Page

This page contains a table with all parameters available on the device.
