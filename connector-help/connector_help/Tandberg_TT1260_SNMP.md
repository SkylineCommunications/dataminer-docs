---
uid: Connector_help_Tandberg_TT1260_SNMP
---

# Tandberg TT1260 SNMP

The **Tandberg TT1260 SNMP** connector is an SNMP based connector used to monitor and configure the **Tandberg TT1260**. The device settings can be monitored and changed using the **TT1260 SNMP** connector.

# About

The **TT1260 SNMP** provides a monitoring interface to the **Tandberg TT1260** IRD device.

# Installation and configuration

## Creation

This is an **SNMP** connector. The **IP** need to be configured during creation of the **element**.

**SNMP CONNECTION:**

- **IP address/host**: the polling IP of the device eg 10.11.12.13

**SNMP Settings:**

- **Port number**: the port of the connected device, default 161
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private.

# Usage

## Main View Page

The **General** page displays the general status information of the device, for example **BER Rate, Audio Status, Video Status**.

## Quick Configuration Page

This page allows to configure parameters like **Input** **Frequency**, **Input** **Search Range**, **Input** **Symbol Rate**, etc.

## General

The **General** page displays general information of the device, for example **Control Mode**, **Device Address**.

## Demodulator

This page displays information about the **Demodulator**.

## Services Page

This page displays information about the **Services**.

## Video Page

This page presents tables with information regarding **Video**.

## Audio Page

This page presents tables with information regarding **Audio**.

## IP Module Page

This page presents tables with information regarding the **IP Module**, such as **Gateway**, **RTP Protocol**, **Encapsulation...**

## Web Interface

This page can be used to access the **web interface** of the device.
