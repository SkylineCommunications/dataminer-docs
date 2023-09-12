---
uid: Connector_help_Sony_PWS-110SC1-XVS-9000
---

# Sony PWS-110SC1 - XVS-9000

The Sony PWS-110SC1 is a Vision Mixer Controller to which different cards can be attached:

- Vision Mixer System Interface Units: MKS-X7700/X2700/X7099
- Vision Mixer Processor: XVS-6000/7000/8000/9000
- Vision Mixer Panel: ICP-X7000
- Vision Mixer Menu Panel: MKS-X7011

## About

This driver is designed to monitor the state of a Sony Vision Mixer Processor, which can be connected to a Sony PWS-110SC1, using **SNMP** communication.

This driver is exported by the parent driver **Sony PWS-110SC1**, from version 1.0.0.x onwards.

### Version Info

| **Range**            | **Key Features**                             | **Based on** | **System Impact**                                                                           |
|----------------------|----------------------------------------------|--------------|---------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                             | \-           | \-                                                                                          |
| 1.0.1.x \[SLC Main\] | Support for monitoring of Sony 2110 devices. | 1.0.0.24     | Pages renamed. NMI table renamed to IP IV Interface table. Columns of Device table renamed. |

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

### Range 1.0.0.x

The element created using this range of the driver has the following data pages:

- **Status**: This page displays detailed status information on the module, including the **Device ID**, **Manufacturer**, **Model**, **Destination**, **Serial Number**, **Category**, **Version**, **Model Suffix** and **Version Suffix**.
- **Alarms**: This page displays the **Error Statuses** connected to this module.
- **NMI**: This page allows you to connect this Vision Mixer Processor to the selected **NMI Interface**.
  Note: Only 1 NMI element can be connected to 1 slot on the device. You can check which NMI element is connected to which slot via the NMI table on the main element.
- **Product Info**: This page displays the **Module** table. This table contains the modules for this slot

### Range 1.0.1.x

The element created using this range of the driver has the following data pages:

- **Status**: This page displays detailed status information on the module, including the **Device ID**, **Manufacturer**, **Model**, **Destination**, **Serial Number**, **Category**, **Version**, **Model Suffix** and **Version Suffix**.
- **Alarms**: This page displays the **Error Statuses** connected to this module.
- **IP IV Interfaces**: This page allows you to connect this Vision Mixer Processor to the selected **NMI or Sony 2110 Interface**.
  Note: Only 1 NMI element can be connected to 1 slot on the device. You can check which NMI element is connected to which slot via the NMI table on the main element.
- **Product Info**: This page displays the **Module** table. This table contains the modules for this slot
