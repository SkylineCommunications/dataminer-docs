---
uid: Connector_help_Tektronix_SPG8000_PTP_Interface
---

# Tektronix SPG8000 PTP Interface

This exported connector displays a PTP interface.

## About

### Product Info

| **Range**            | **Supported Firmware** |
|----------------------|------------------------|
| 1.0.1.x              | 3.0                    |
| 1.0.2.x \[SLC Main\] | 3.0                    |

## Configuration

The element using this connector is automatically created by the parent element using the connector **Tektronix SPG8000**, range 1.0.1.8. No further configuration is required.

## How to Use

This is a DVE child connector. It displays information gathered by the parent connector using SNMPv1. This DVE functionality is required to support the Skyline PTP Monitor Application.

The element using this connector has only one data page, the Port Status page, which contains the **PTP Status Table.** It displays the interface related to the DVE.
