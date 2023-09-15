---
uid: Connector_help_Verimatrix_Video_PreProcessor
---

# Verimatrix Video PreProcessor

The **Verimatrix Video PreProcessor** is an offline encryption server. The VPP Server manages offline encryption of video files before storage on a VOD server. The VPP GUI provides the user interface for adding content to the VPP.

## About

This connector uses **SNMP** to monitor the **Verimatrix** **Video PreProcessor** device.

### Version Info

| **Range** | **Description**                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                          | No                  | Yes                     |
| 1.1.0.x          | Based on 1.0.0.1 Added support for firmware version 4.1. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.1.0.x          | 4.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *192.168.1.31*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays parameters such as the **System Name**, **System Up Time**, **State**, etc.

### Local Configuration

On this page, you can find the device local configuration, including the address configuration, the encryption level, etc.

### Master Configuration

Similar to the Local Configuration page, this page allows you to configure the master settings.
