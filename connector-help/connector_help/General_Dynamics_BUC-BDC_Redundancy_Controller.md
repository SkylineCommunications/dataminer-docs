---
uid: Connector_help_General_Dynamics_BUC-BDC_Redundancy_Controller
---

# General Dynamics BUC-BDC Redundancy Controller

Generic redundancy controller with serial interface. Redundant lock up-converter (BUC) and down-converter (BDC) systems contain either three converters in a 1:2 redundant configuration or two converters in a 1:1 redundant configuration. The systems include automatic switchover logic, redundant power supplies, and redundant AC line inputs. The systems are designed for installation at satellite earth stations in standard 19-inch EIA equipment racks.

## About

This protocol uses a **serial** connection to allow the user to monitor and configure the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains general information, including the **Number of Back Ups**, **Number of Non Back Ups** and **CIF Software Number**, as well as settings for the device, such as the **Reset Audio Alarm** button and the **automatic and manual switch control**, and also the **RF Switch** groups.

### Alarms

This page displays the **general status** of the device and **switches**, including **power supply** information.

## Notes

In order to make the connector functional for BUC and BDC devices, the RF switches are named from 1 to 8 and mapped as follows:

| **BUC**         | **Driver**     | **BDC**         |
|-----------------|----------------|-----------------|
| RF Switch \# 14 | RF Switch \# 1 | RF Switch \# 22 |
| RF Switch \# 15 | RF Switch \# 2 | RF Switch \# 23 |
| RF Switch \# 16 | RF Switch \# 3 | RF Switch \# 24 |
| RF Switch \# 17 | RF Switch \# 4 | RF Switch \# 25 |
| RF Switch \# 18 | RF Switch \# 5 | RF Switch \# 26 |
| RF Switch \# 19 | RF Switch \# 6 | RF Switch \# 27 |
| RF Switch \# 20 | RF Switch \# 7 | RF Switch \# 28 |
| RF Switch \# 21 | RF Switch \# 8 | RF Switch \# 29 |

| **BUC Group 1** | **Driver Group 1** | **BDC Group 1** |
|-----------------|--------------------|-----------------|
| RF Switch \# 14 | RF Switch \# 1     | RF Switch \# 22 |
| RF Switch \# 16 | RF Switch \# 3     | RF Switch \# 24 |
| RF Switch \# 18 | RF Switch \# 5     | RF Switch \# 26 |
| RF Switch \# 20 | RF Switch \# 7     | RF Switch \# 28 |
