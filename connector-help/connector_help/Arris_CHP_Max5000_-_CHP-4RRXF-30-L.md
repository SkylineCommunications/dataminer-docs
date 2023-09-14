---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-4RRXF-30-L
---

# Arris CHP Max5000 - CHP-4RRXF-30-L

The CHP-4RRXF-30-L cards are a group of cards with the system naming format 4RRXF. These cards are redundant or non-redundant quad return path receivers.

This connector uses SNMP to communicate with these devices.

## About

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Boot v001.008               |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000), from version 1.0.0.5 onwards.

## Usage

### General

This page contains card-specific hardware information and configuration options. **Names**, **Serial Number**, **Revisions** and the **generic hardware information** can be seen and configured here.

### Status

This page displays the generic status of the card, which includes **slot information**, **up time** and **alarm monitoring**.

You can also find more specific **Rx4 Status** information here, namely the **Rx4 Status Alarm Byte**, **Rx4 Status Mode of Operation** and **Rx4 Status Optical Data.**

### Rx Information

This page displays the **Rx Channel Control Table**, which shows the RF Status, Low Level, Status, Maintenance Mode and Attenuation Level for each Rx channel.

### Configuration

This page provides access to generic configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the card. You can also change the status of the **Front Panel Lock**, and **Blink** the card's front status LED.

From version 1.0.0.5 onwards, you can also change some system settings, specifically **Date/Time** and **Alarm Detection**, and perform a **Software Reset**.

### Optical Properties

This page contains information related to the device inputs. The **Wavelength** can be configured (1310 or 1550).

### Optical Passive Configuration

This page displays the different wavelength inputs. Note that the **Wavelength Type** could be CWDM or DWDM and Upstream or Downstream. When the type is CWDM, the wavelength value should be interpreted as an ITU channel number. When the type is DWM, the value should be interpreted as units of 1 nm.
