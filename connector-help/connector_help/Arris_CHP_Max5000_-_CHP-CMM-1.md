---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-CMM-1
---

# Arris CHP Max5000 - CHP-CMM-1

The CHP-CMM-1 card is a basic controller card for the Arris CHP Max5000 platform, but unlike the [CHP-SMM-2](xref:Connector_help_Arris_CHP_Max5000_-_CHP-SMM-2) card, it does not allow SNMP access. As a controller card, its main usage is to obtain the general information from other cards or elements contained in the platform. Each chassis should contain one controller card, and this card is a common option when SNMP is not required. The card also allows the user to see the general status of the cards it connects to.

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

The page also contains specific card information, such as the **Craft Software Status** and the **Relay Status**, and it displays if there is any alarm in **Modules**, **Fans** or **Hardware**. **Backplane Voltages** are also displayed.

### Configuration

This page provides access to general configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the relevant card. You can also change the status of the **Front Panel Lock**, and **Blink** the card's front status LED.

The page also contains specific card configuration options, such as the **Relay Trigger** configuration, and **Front Panel Control**.

From version 1.0.0.3 onwards, you can also change some system settings, i.e. the **Date/Time** and **Alarm Detection**, as well as do a **Software Reset**.
