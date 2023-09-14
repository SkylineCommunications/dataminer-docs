---
uid: Connector_help_Verimatrix_CSM
---

# Verimatrix CSM

The **Verimatrix CSM** provides certificate authority through its **VCA** module, a client interface through its **VCI** module and a key server through its **VKS** module:

- **VCA** manages the creation and maintenance of all PKI certificates required for system operation.
- **VCI** secures the interface between client devices and the headend server components.
- **VKS** generates and manages master channel key requests.

## About

This connector uses **SNMP** to monitor and control **Verimatrix CSM** device.

### Version Info

| **Range** | **Description**                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                          | No                  | Yes                     |
| 1.3.6.x          | Based on 1.0.0.1 Added support for firmware version 3.6. | No                  | Yes                     |
| 1.4.0.x          | Based on 1.3.6.1 Added support for firmware version 4.1. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.3.6.x          | 3.6                         |
| 1.4.0.x          | 4.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *192.168.1.31*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays parameters such as the **System Name**, **System Up Time**, **State**, etc.

### VCA Configuration

This page allows you to configure **VCA** module.

### VCI Configuration

This page allows you to configure **VCI** module.

### VKS Configuration

This page allows you to configure the **VKS** module.
