---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-SMM-2
---

# Arris CHP Max5000 - CHP-SMM-2

The CHP-SMM-2 card is an SNMP-enabled controller card for the Arris CHP Max5000 platform. This card works like a [CHP-CMM-1](xref:Connector_help_Arris_CHP_Max5000_-_CHP-CMM-1) card in general, but allows access by SNMP. As a controller card, its main usage is to obtain the general information from other cards or elements contained in the platform. It is possible for a single SMM card to be connected to several CMM cards in order to control/mediate more than one chassis.

## About

This is an **SNMP** connector, which uses SNMP polling to communicate with the physical devices.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.6.0                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000), from version 1.0.0.1 onwards.

## Usage

### General

This page contains card-specific hardware information and configuration options. **Names**, **Serial Number**, **Revisions** and the **generic hardware information** can be seen and configured here.

### Status

This page displays the general status of the card, which includes **slot information**, **up time** and **alarming**.

Specific card information can also be found here, namely the **polling status**, **Firmware download status** and **Discovery Lockout**.

### Configuration

This page provides access to general configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the relevant card. It's also possible to change the status of the **Front Panel Lock**, and to **Blink** the card's front status LED.

The page also contains specific card configuration options, such as **Firmware Download**, **Download Configuration Files** and **USB Mode**.

From version 1.0.0.3 onwards, you can also change some system settings, i.e. the **Date/Time** and **Alarm Detection**, as well as do a **Software Reset**.
