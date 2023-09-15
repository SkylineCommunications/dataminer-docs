---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-D2RRX-85-XQ-S
---

# Arris CHP Max5000 - CHP-D2RRX-85-XQ-S

The CHP-D2RRX-85-XQ-S dual digital return path receiver module contains two independent receiver circuits in a single slot CHP module, enabling up to 20 receivers, or 40 RF streams in a fully-loaded CHP chassis.

## About

This connector uses **SNMP** polling to communicate with the device.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.6.0                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000), from version 1.0.0.7 onwards.

## Usage

### General

This page contains card-specific hardware information and configuration options.

### Status

This page displays the generic status of the card, which includes **slot information**, **up time** and **alarming**.

### Rx Information

This page displays the **Rx Channel Control Table**, which contains the **RF Status**, **Low Level**, **Status**, **Maintenance Mode** and **Attenuation Level** for each **Rx Channel**.

### Configuration

This page provides access to generic configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the relevant card. You can also change the status of the **Front Panel Lock**, and **Blink** the card's front status LED.

From version 1.0.0.3 onwards, you can also change some system configuration settings, specifically **Date/Time** and **Alarm Detection**, and make a **Software Reset**.

From version 1.0.0.7 onwards, the license information is also displayed on this page.

### Alarm Configuration

This page displays the different alarms that can be configured on this card.

### Optical Properties

This page contains information related to the inputs of the device, and allows you to configure the **Wavelength** (1310 or 1550) .
