---
uid: Connector_help_Webeasy_Lite
---

# Webeasy Lite

The **Webeasy** **Lite** connector is a serial connector used to monitor the **Webeasy** **Lite** **airco** unit.

## About

The information that is retrieved from the **Webeasy** **Lite** can be divided into 2 groups. The first group are measurements. Since the Webeasy Lite is an airco unit, these measurements are temperatures, measurements of pressure, etc. The second group of parameters that is polled contains alarming parameters. These will indicate an interruption or alarm in the system, e.g. when the temperature is too high or low.

This connector also makes it possible to change certain settings for the Webeasy Lite.

## Installation and configuration

### Creation

Before the element can retrieve the correct information from the airco unit, the element needs to be created. The following settings need to be filled in or verified:

- **Type of port:** TCP/IP (already configured).
- **IP address/host:** The IP address of the Webeasy Lite.
- **IP Port:** The IP port used by the Webeasy Lite for TCP/IP communication

Once the element is created, the measurements and alarms will be polled every minute by default.

## Usage

### Algemeen (General)

The **General** **page** contains all parameters that display the measurements.

### Storingen (Alarms)

This **Alarm** **page** displays the state of the alarm parameters.

### Sturingen (Settings)

This page contains the settings that can be altered using the **Webeasy Lite** connector.
