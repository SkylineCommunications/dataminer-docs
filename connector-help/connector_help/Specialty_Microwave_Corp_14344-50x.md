---
uid: Connector_help_Specialty_Microwave_Corp_14344-50x
---

# Specialty Microwave Corp 14344-50X

The Specialty Microwave Corp 14344-50X connector retrieves the power supply and input statuses through a serial connection. The connector allows the user to select an active coaxial input based on two existing ones.

## About

This connector polls the device every five seconds through a serial connection.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                            |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Information about the device firmware is unavailable. The current implementation is based on Revision 0 of the device's documentation. |

## Installation and configuration

This connector uses a **serial** connection and requires the following input during element creation:

Interface connection:

  - **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device. The range varies from 0 to 255.

## Usage

This connector has two pages.

### General Page

On the left side of this page, you can find information regarding the status of the device, such as the first and second power supply statuses (**Power Supply 1/2 Status**) and the **Communication Status** of the serial connection.

On the right side of the page, you can monitor and configure the active input on the **Active Connection**. The result of changing the active connection will appear at the **Switch Command Response**.

### Web Interface Page

This page displayes the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
