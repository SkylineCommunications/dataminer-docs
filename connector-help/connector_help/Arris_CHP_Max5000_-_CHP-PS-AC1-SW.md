---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-PS-AC1-SW
---

# Arris CHP Max5000 - CHP-PS-AC1-SW

The CHP-PS-AC1-SW card is a power supply status card. It allows the user to see the status of the power supplies of the system. Typical usage includes a redundant pair of power supplies per chassis, which means that two of these cards will be used per chassis element.

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

This page displays the general status of the card, which includes **slot information**, **up time** and **alarming**. It also displays whether there is any alarm on the power supply unit, and displays information on the fans running on this card.

### Configuration

This page provides access to general configuration and actions, such as the **Module Reset**, **Factory Default** reset and **Slot Reset** for the relevant card. You can also change the status of the **Front Panel Lock**, and **Blink** the card's front status LED.

From version 1.0.0.3 onwards, the **Date/Time** and **Alarm Detection** can be configured, and it is possible to do a **Software Reset**.
