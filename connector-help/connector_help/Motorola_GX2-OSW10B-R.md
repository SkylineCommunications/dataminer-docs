---
uid: Connector_help_Motorola_GX2-OSW10B-R
---

# Motorola GX2-OSW10B-R

The **Motorola GX2-OSW10B-R** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-OSW10B-R.**

## About

This connector provides a monitoring interface for the **Motorola GX2-OSW10B-R** chassis.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 2.0.0.x          | DVE focused     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | D                           |

## Usage

### General

This page displays general information about the card. **Unit Name**, **Module Type**, **Firmware** and **Hardware** version, **IP Address** and **Physical Address** are some of the parameters that can be found here.

### Optical Switch

This page contains the parameters **Digital Switch Control**, **Operation Mode**, **Switch Mode**, **Revert Mode**, **Revert Time**, **Switch Monitor**, **Factory Default** and **Analog** **Input Level**.

The page also contains a page button that includes a **counter** related to the **Digital Switch Monitor**. This counter will increase each time the parent parameter (Digital Switch Monitor) changes from *Through* to *Crossover*. There is also a button that allows you to reset the value of the counter.

### Alarms

This page contains all the **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
