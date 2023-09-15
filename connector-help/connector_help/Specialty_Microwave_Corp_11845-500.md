---
uid: Connector_help_Specialty_Microwave_Corp_11845-500
---

# Specialty Microwave Corp 11845-500

The Specialty Microwave Corp 11845-500 connector retrieves the **power supply** and **switch position** through a **serial connection**.

The Antenna Switching Panel, Part No. 11845-500, consists of a logic panel used in satellite communication earth stations. The system mechanism operates waveguide/coaxial switches to operator desired positions.

## About

This connector is designed to work with the **Antenna Switching Panel, Part No. 11845-500**. Using a serial connection, the connector sends a single command that requests the status of the power supplies and the position of the switches. Polling occurs every ten seconds.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                      |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Information about the device firmware is currently unavailable. The current implementation is based on Revision 0 of the device's documentation. |

## Installation and configuration

### Creation

#### Main connection

This connector uses a **serial** connection and requires the following input during element creation:

Interface connection:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device. The value has a range of *0* to *255* (default: *49*).

## Usage

This connector has one page.

### General

At the top of this page, information is displayed regarding the status of the device, such as the first and second power supply status (**Power Supply 1/2 Status**) and the **Communication Status** of the serial connection.

Below, the status of the switches (**Switch 23/24/25/26/27/28/29/30/31/32 Status**) is displayed, which indicates the position of each switch (**Position 1**, **Position 2**, or **NA**)
