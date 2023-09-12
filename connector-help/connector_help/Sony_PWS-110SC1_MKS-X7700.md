---
uid: Connector_help_Sony_PWS-110SC1_MKS-X7700
---

# Sony PWS-110SC1 - MKS-X7700

The Sony PWS-110SC1 is a Vision Mixer Controller to which different cards can be attached:

- Vision Mixer System Interface Units: MKS-X7700/X2700/X7099
- Vision Mixer Processor: XVS-6000/7000/8000/9000
- Vision Mixer Panel: ICP-X7000 (not supported)
- Vision Mixer Menu Panel: MKS-X7011

## About

This driver is designed to monitor the state of a Vision Mixer System Interface Unit, which can be connected to a Sony PWS-110SC1, using **SNMP** communication and **Ember+**.

This driver is exported by the parent driver **Sony PWS-110SC1**, from version 1.0.0.x onwards.

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                             | \-           | \-                |
| 1.0.1.x \[SLC Main\] | New features are only for DVEs of type XVS. | 1.0.0.24     | None              |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V2.60                  |
| 1.0.1.x   | V2.60                  |

## Configuration

### Initialization

This driver is used by DVEs that are **automatically created** by the parent element. No user input is required.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this driver has the following data pages:

- **Status**: This page displays detailed status information on the module, including the **Device ID**, **Manufacturer**, **Model**, **Destination**, **Serial Number**, **Category, Version**, **Model Suffix** and **Version Suffix**.
- **Alarms**: This page displays the **Error Statuses** connected to this module.
- **Product Info**: This page displays the **Module** table. This table contains the modules for this slot.
