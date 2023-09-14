---
uid: Connector_help_Audemat_Aztec_Goldeneagle_AM
---

# Audemat Aztec Goldeneagle AM

The **Audemat Aztec Goldeneagle AM** connector can be used to display and configure information regarding the related device.

## About

This protocol can be used to monitor and control the Audemat Aztec Goldeneagle AM device. An SNMP connection is used in order to successfully retrieve and configure the information of the device.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value, unless overridden in the connector, is *public*.
- **Set community string:** The community string used when setting values on the device. The default value, unless overridden in the connector, is *private*.

## Usage

The Audemat Aztec Goldeneagle AM protocol contains 4 main pages.

### General

This page contains information about the device, for instance: **Software Version**, **Serial Number**, etc.

There is also an additional page, **Channels Configuration**, which can be reached through the page button "**Channels...**". It contains an overview of the different channels.

### Radio Monitoring

Provides a table with **RF Low 1**, **RF Low 2**, **RF High**, **AF High** and **AF Low** for the available channels.

### Measurement

Provides a table with the **RF** and **Audio Level** for the available channels.

### Webpage

The web interface of the device
