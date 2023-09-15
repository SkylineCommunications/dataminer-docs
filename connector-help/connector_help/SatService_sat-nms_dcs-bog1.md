---
uid: Connector_help_SatService_sat-nms_dcs-bog1
---

# SatService sat-nms dcs-bog1

**SatService sat-nms** is a Network Management System that can provide information and control of SCPC/MCPC VSAT stations and in general satellite ground stations from a central site.

## About

This connector allows the management of the **SatService sat-nms dcs-bog1** using an SNMPv2 connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

## Usage

This connector is able to poll up to 24 modulator cards. Information for each card is displayed on a different page.

### General

The General page displays information related to the unit itself such as **System Summary**, **Serial Number ID** and **System Information Faults**.

Via the **Overview Config** page button, you can view an overview of the polling of all cards.

### Demodulator X

The device supports up to 24 demodulator cards. Every card X (1-24) has its own page, which shows information such as **System Information**, **Transport Stream** and **Demodulator** **State**.

With the **Demodulator Polling State** toggle button, you can enable or disable the polling of the card.

### Web Interface.

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
