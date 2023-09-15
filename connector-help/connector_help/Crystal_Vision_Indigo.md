---
uid: Connector_help_Crystal_Vision_Indigo
---

# Crystal Vision Indigo

Crystal Vision Indigo is a frame that allows to connect many devices incluindo 3G and PSU.

## About

This connector is used to retrieve all data information and control the HPAK-2200 amplifier system.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 1.0.1.x          | No              | No                  |                         |
| 2.0.0.x          | No              | No                  |                         |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## About

The Crystal Vision Indigo connector makes it possible to monitor and control many devices connected to the chassis.

All data is retrieved using an SNMP connection. The bus address of an element is used to indicate the card number to poll.

### Configuration

No additional configuration is needed in the element.

## Usage

### General

This page displays general status information of the device, such as **Device Up Time, Device Contact and Device Name**.

### Modules

This page contains a table showing which **Board Type** is connected to the chassis.

### Frame Status

Contains three tables. The first one shows the **Frame Status** of old devices, the second table the **PSU** status and the last table shows the Frame Status of new devices.

### Coco 3G Status

This page shows a table with all the status properties of the board type Coco 3G connected to the chassis.

### Coco 3G Configuration

On this page there is a table, where you can configure all the gains for each device. There are parameters to configure the thresholds, lift..

### RGB

This page contains RGB lift and gain controls used for image adjustments in the RGB domain.

### Web Interface

Displays the web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
