---
uid: Connector_help_Evertz_MVP_OV_-_Channel
---

# Evertz MVP OV - Channel

The MVP is a multi-image display and monitoring system. It provides a highly flexible, intuitive and comprehensive approach to virtual wall monitor applications. With the MVP, any input signal can be displayed on any output monitor without the need for DAs or upstream monitor routers.

## About

This protocol is created by the **Evertz MVP OV** connector. For each bus address (1-8), the **Evertz MVP OV** creates a DVE.

### Version Info

| **Range** | **Description**                                                                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | SNMP set not working                                                                       |                     |                         |
| 2.0.0.x          | Use of DVEs for each bus address instead of using the bus address to look at a single channel | \-                  | \-                      |

### Supported Firmware Versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and Configuration

### Configuration

The DVE is created by the parent connector protocol (**Evertz MVP OV**). It uses the name of the parent connector + the bus addres + the bus name.
e.g. **ParentName.1_BusName**

You can change the bus name in the HardwareControl Table on the parent connector.

## Usage

### Input

On this page, you can monitor VistaLINK parameters, such as **Loss of Video Sync**, **EDH Errors**, **Picture** settings and **Loss of Audio** and the **Input setting control** parameters.

### Notifications

This page displays two tables, the **Video** and **Audio Notifications Tables.**

### Video Fault

This page displays general parameters related to errors, such as **Error Duration Video**, **CC(1,2,3) Errors**, **Text Error**, **VITC Errors**.

### Audio Fault

This page displays the **Audio Definition** and **Audio Pair Definition Tables**.

### Hardware Control

On this page, general parameters are consolidated: **System Status**, **Tag Selector**, **Input Tags (A and B)**, **Trap Tag** and **MVP IDs**. The input + bus name is used to create the DVE.

### Audio Loudness

On this page, you can configure the **Loudness Measure Audio Program** (1 to 8) and **Audio Loud** settings.

### Audio Notifications

This page displays the **Management Fault Audio 2** and **Management Audio 3 Tables**.

### Dolby E

This page displays the **Dolby E definition Table**.

### Group 7 Notifications

This page displays the **Group 7 Notifications Table**.

### WST GPI

On this page, you can configure the **WST GPI** parameters.

### EIA 708

On this page, you can configure the **EIA 708** fault definition parameters.

### Monitor Control

On this page, you can configure the **Monitor Control** parameters such as Start, Stop, Reset, ... of monitoring/reporting of faults.

### RCTL GPI

On this page, you can configure the **RCTL GPI** Timecode parameters.

### SCTE 104 GPI

On this page, you can configure the **SCTE 104 GPI** error on time.
