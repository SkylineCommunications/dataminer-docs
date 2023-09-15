---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-FANS
---

# Arris CHP Max5000 - CHP-FANS

The CHP-FANS contains information related to all the fans that are present in a specific chassis (CMM Card). This is not a physical card, but Arris maps all the fans from a specific chassis (monitored by a CMM card) using a different card type (CHP-FANS). Multiple chassis can be connected in a daisy chain, with each chassis containing up to 8 fans.

## About

This is an **SNMP** connector, which uses SNMP polling to communicate with the physical devices.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.6.0                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000), from version 1.0.0.6 onwards.

## Usage

### General

This page contains card-specific hardware information and configuration options.

### Fans

This page displays a table with information on the fans associated with a specific chassis.
