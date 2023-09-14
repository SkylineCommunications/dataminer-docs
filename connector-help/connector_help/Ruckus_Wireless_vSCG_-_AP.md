---
uid: Connector_help_Ruckus_Wireless_vSCG_-_AP
---

# Ruckus Wireless vSCG - AP

The **Ruckus Wireless Virtualized SmartCell Gateway** (vSCG) is an NFV-based and cloud-ready WLAN controller for service providers and enterprises that require a high flexibility and resiliency in their WLAN deployment. This is an **SNMP- and HTTP**-based protocol for the Ruckus Wireless vSCG.

## About

This connector was designed to monitor and receive numerous statistics for the vSCG, the access points (APs) connected to it and the client stations (STAs) connected to these APs. In other words, the entire WLAN controlled by the vSCG can be monitored using this protocol.

This connector is generated automatically by the connector **Ruckus Wireless vSCG**.

### Version Info

| **Range** | **Description**                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x          | New range that adds new HTTP connection and creation of DVEs. Supports node redundancy. Supports new firmware. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**        |
|------------------|------------------------------------|
| 1.0.1.x          | 3.4.1.0.329 (backwards compatible) |

## Installation and configuration

### Creation

This connector is used by DVEs that are **automatically generated** when a user enables an instance of an access point in the **SCG AP Table** in the parent element.

## Usage

### General

On this page, the **General Parameters** related to the access point are displayed: **MAC Address**, **Name**, **Group**, **Model**, **IP Address**, **Location**, **Serial Number**, **Mesh Role**, **Firmware Version**, etc.

### Statistics

This page contains numeric values, such as **Number of STAs**, **Transmitted and Received Bytes**, **Output and Input Bitrates**, **Received Idle Time**, **Transmitted Idle Time**, **Rx Packets Dropped**, **Tx Packets Dropped**, **System Currrent**, **Last Month BW Utilization For Tx and Rx**, etc

In addition, you can also find the following statuses here: **Connection**, **Configuration** and **Registration** **Status**.
