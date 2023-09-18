---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-OSW10B-R
---

# Motorola GX2-CM100 B - GX2-OSW10B-R

The **Motorola GX2-CM100 B - GX2-OSW10B-R** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-OSW10B-R**.

## About

This connector provides a monitoring interface for the **Motorola GX2-OSW10B-R** module.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | D                           |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.1 onwards.

## Usage

### General

This page displays general information about the card, including the **Unit Name**, **Module Type**, **Firmware** and **Hardware** **Version**, **IP Address** and **Physical Address**.

### Optical Switch

This page contains the parameters **Digital Switch Control**, **Operation Mode**, **Switch Mode**, **Revert Mode**, **Revert Time**, **Switch Monitor**, **Factory Default** and **Analog** **Input Level.**

It also contains a page button that displays among others a **counter** related to the **Digital Switch Monitor**. This counter will be increased each time the parent parameter (Digital Switch Monitor) changes from *Through* to *Crossover*. The subpage also includes a button that allows you to reset the value of the counter.

### Alarms

This page contains all **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
