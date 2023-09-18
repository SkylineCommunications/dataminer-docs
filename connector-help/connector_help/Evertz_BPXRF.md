---
uid: Connector_help_Evertz_BPXRF
---

# Evertz BPXRF

The **Evertz BPXRF** connector is used to monitor and control an Evertz chassis containing two Evertz 7703 cards.

## About

This connector monitors the input and output of different Evertz cards inside a single chassis.

Supported Cards:

- Evertz 7703PA
- Evertz 7703BPX

15 slots are available, which means that 14 cards can be added. Slot zero is reserved for the frame carrier.

Data is polled via SNMP protocol.

## Installation and Configuration

### Creation

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

The Evertz BPXRF connector displays information about the two kinds of supported cards. For each detected card, a child element will be created under the main element.
The connector contains 6 pages. The first 3 pages monitor the 7703PA card. The remaining 3 pages monitor the 7703BPX connector.

### General PA

This page displays data about the **Input Power** and miscellaneous data about the card, such as **Type**, **Firmware**, etc.

### Fault PA

This page lists all the alarms that can be reported by the 7703PA card. For each alarm, the user has the possibility to enable the traps or not.

Note that traps are not currently supported by this connector: nothing will happen if a trap is received.

### Control PA

This page allows the operator to set different parameters: **Gain**, **Output** **Level,** .

### General PX

This page displays data about the **Input Power** and miscellaneous data about the card, such as **Card Type**, **Current Active Channel**, etc.

### Fault BPX

This page lists all the alarms that can be reported by the card 7703BPX. For each alarm, the user has the possibility to enable the traps or not.

Note that traps are not currently supported by this connector: nothing will happen if a trap is received.

### Control BPX

This page allows the operator to set different parameters: **Threshold**, **Delay**, ...
