---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-OA100B20-R
---

Motorola GX2-CM100 B - GX2-OA100B20-R

The **Motorola GX2-CM100 B - GX2-OA100B20-R** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-OA100B20-R.**

About

This connector provides a monitoring interface for the **Motorola GX2-OA100B20-R** module.

Ranges of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

Supported firmware version

| **Device Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 2.0.1.x          | B                           |

Installation and configuration

Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.2 onwards.

Usage

General

This page displays general information about the card, including the **Unit Name**, **Module Type**, **Firmware** and **Hardware Version**, **IP Address** and **Physical Address**.

Optical Amplifier

This page displays both **digital** and **analog** parameters. This includes the parameters **Input Power**, **Temperature**, **Fan Current**, **Output Power**, **TEC Current**, **Laser Power**, **Laser Power Setpoints**, **Constant Gain Setpoint** and **Module State**.

Alarms

This page contains all **Status** parameters.

Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
