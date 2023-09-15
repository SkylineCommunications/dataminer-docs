---
uid: Connector_help_ETL_Systems_22320
---

# ETL Systems 22320

The Model D0124S3ULA-22320 is designed to take an incoming 950-2150 MHz signal and split it to twenty-four outputs with a nominal 0dB gain.

## About

This connector displays the status of the power supplies for the **ETL Systems 22320** device, retrieved from an element.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Element Connections

This connector requires connection to another element for the status of the pins connected to the device. See the table below:

| **Power Supply** | **Designation** | **Pin No.** |
|------------------|-----------------|-------------|
| PSU 1            | COMMON          | 1           |
| FAIL             | 2               |             |
| GOOD             | 3               |             |
| PSU 2            | COMMON          | 5           |
| FAIL             | 6               |             |
| GOOD             | 7               |             |



The "Fail" and "Good" pins of each power supply must be connected to another element using the Element Connections module avaiable in DataMiner.

## Usage

### General

This page displays the status of **Power Supply 1** and **Power Supply 2**.





