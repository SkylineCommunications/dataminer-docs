---
uid: Connector_help_Sony_Signal_Processing_Unit-NXLK-IP50Y
---

# Sony Signal Processing Unit - NXLK-IP50Y

The **Sony NXL-FR316** and **Sony NXL-FR318** are processing units (chassis) to which different cards can be attached:

- IP converter boards: Sony NXL-IP40F/41F/42F/45F/50Y

## About

This connector is designed to monitor the state of the IP converter board that can be connected to a **Sony NXL-FR316** and **Sony NXL-FR318**, using **SNMP** communication.

This connector is exported by the parent connector **Sony Signal Processing Unit**, from version 1.0.0.x onwards.

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact**                            |
|----------------------|-----------------------------------------|--------------|----------------------------------------------|
| 1.0.0.x              | Initial version                         | \-           | \-                                           |
| 1.0.1.x \[SLC Main\] | Support monitoring of Sony 2110 devices | 1.0.0.14     | \- Button parameters renamed - Pages renamed |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.00                  |
| 1.0.1.x   | V1.00                  |

## Configuration

This connector is used by DVEs that are **automatically created** by the parent element. No user input is required.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Status

This page displays detailed status information on the module, including the **Device ID**, **Manufacturer**, **Model**, **Destination**, **Serial Number**, **Category, Version**, **Model Suffix** and **Version Suffix**.

### Alarms

This page displays the **Error Statuses** connected to this module.

### NMI / NMI Device

The NMI page in range 1.0.0.x has been renamed to NMI Device page in range 1.0.1.x, by means of an export rule.

### IP AV Interface

This page allows you to connect this IP board to the selected interface.

Note: Each interface can only be connected to 1 IP board connected to this chassis. You can check which interface element is connected to which IP board in the **IP AV Interface** table of the main element.
