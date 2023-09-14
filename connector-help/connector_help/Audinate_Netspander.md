---
uid: Connector_help_Audinate_Netspander
---

# Audinate Netspander

The Audinate Netspander is a infrastructure device that provides services to enable the building of scalable Dante networks within and accross subnets.

## About

A CSV config file can be used to load a set of unicast devices into the Dante network.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |

## Installation and configuration

### Creation

#### Serial connection

This connector requires the polling IP of the Audinate Netspander.

### Configuration of ...

The SLNetspander_1.0.0.1.dll needs to be available in C:\Skyline DataMiner\Files

## Usage

### General

The general page contains general information of the device, such as cpu load, Rx Bytes.

PTP

The PTP page contains PTP specific parameters.

Unicast Devices

This page shows the list of unicast devices that the netspander manages.

Input

This page allows you to load a input csv file to load unicast devices into the netspander.
