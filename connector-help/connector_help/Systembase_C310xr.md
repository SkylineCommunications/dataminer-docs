---
uid: Connector_help_Systembase_C310xr
---

# Systembase C310xr

This connector is used to monitor and configure the **C310xr** codec from **Systembase**.

## About

The connector displays information about the different patches in a table and in a tree view. It is possible to disable some of the patches, so that the communication traffic over the network is kept to an absolute minimum.

### Version Info

| **Range** | **Description**                                                                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version.                                                                                                                                   | No                  | Yes                     |
| 1.0.0.2          | Renamed ISDN 1 to Channel 1 and ISDN 2 to Channel 2. Added extra ISDN status values. Fixed remote addresses starting with 0. Reduced polling rate. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The serial number of the device. This is necessary to establish communication with the device.

## Usage

### Overview

This page displays information about the patches in a tree view.

The refresh button next to the tree view allows you to refresh all patches for which the polling state is enabled.

### Configuration Table

This page displays information about the patches in a table.

The refresh button next to the table allows you to refresh all patches for which the polling state is enabled.
