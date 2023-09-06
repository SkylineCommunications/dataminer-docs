---
uid: Connector_help_ETL_Systems_Genus_-_22544
---

# ETL Systems Genus - 22544

This module displays information about the ETL Systems Genus Hybrid 22544. The 22544 L-Band VSAT shelf is intended to operate over the frequency band of 850-2150 MHz. It features an 18 V LNB PSU, switchable 24 V or 48 V BUC, active or passive TX/RX amplifiers and selectable internal 10 MHz oscillator or external 10 MHz oscillator input.

This driver is exported by the parent driver [ETL Systems Genus](xref:Connector_help_ETL_Systems_Genus).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | e610 1v2 27/10/2020    |

## Configuration

The element using this driver is automatically created by the parent element using the [ETL Systems Genus](xref:Connector_help_ETL_Systems_Genus) driver. No user input is required.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays system information such as the **Summary Alarm** and the **Operation Time**of the board.
- **Control**: Allows you to set multiple control parameters of the board.
- **Monitoring**: Displays the **Alarms Status** of the board and information like **Voltage**, **Current** and **Temperature**.
