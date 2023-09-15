---
uid: Connector_help_Ruckus_Wireless_vSCG_-_Zone
---

# Ruckus Wireless vSCG - Zone

The **Ruckus Wireless Virtualized SmartCell Gateway** (vSCG) is an NFV-based and cloud-ready WLAN controller for service providers and enterprises that require a high flexibility and resiliency in their WLAN deployment. This is an **SNMP- and HTTP**-based protocol for the Ruckus Wireless vSCG.

## About

This connector was designed to monitor and receive numerous statistics for the vSCG, the access points (APs) connected to it and the client stations (STAs) connected to these APs. In other words, the entire WLAN controlled by the vSCG can be monitored using this protocol, plus the different zones and the access points connected to these zones.

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

This connector is used by DVEs that are **automatically generated** when a user enables an instance of a zone in the **Zones Details Table** of the parent element.

## Usage

### Zones

On this page, the **General Parameters** related to the zone are displayed: **Name**, **IP Mode**, **Latitude**, **Longitude**, **Total of Access Points**, **Active Access Points**, **Connected STs**, **Active STAs**, **Inactive STAs**, **Current Month BW Utilization (Received and Transmitted)**, etc.

### SCG Access Points

This page shows all the access points that belong to the current zone in the **SCG AP Table**. Here, you can **enable or disable** the creation of a **DVE** for each individual access point.

### SCG WLAN

This page displays the **SCG WLAN Table**, which contains all information related to the WLANs that belong to the current zone. For each individual WLAN this information includes **SSID**, **Zone**, **Domain**, **Number of STA**, **Input Bit Rate**, **Output Bit Rate**, etc.

### SCG SoftGRE Tunnels

This page displays the **Total of SoftGRE Tunnels**, **Total Active**/**Inactivate SoftGRE Tunnels,** and the **SCG WLAN AP SoftGRE Statistics Table.**
