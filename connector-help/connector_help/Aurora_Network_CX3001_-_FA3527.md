---
uid: Connector_help_Aurora_Network_CX3001_-_FA3527
---

# Aurora Network CX3001 - FA3527

The Aurora Network Node FA3527M connector is used by DVEs created by the Aurora Network CX3001 connector. A DVE is created for each high power EDFA module.

## About

The Dynamic Virtual Element has four pages:

- The **Status** page contains info about the optical power, lasers and module statuses.
- The **Alarming** page contains all the alarm information for the module, EDFA and lasers.
- The **User Setup** page contains information regarding the mode selection, laser setup and alarm setup.
- The **Module Info** page contains information about the module itself.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Aurora Network CX3001](xref:Connector_help_Aurora_Network_CX3001), from version 2.0.1.x onwards. For each high power EDFA found in the system, a virtual element will be created.

## Usage

### Status Page

This page contains status information for the optical power, lasers and module.

### Alarming Page

This page allows you to configure the severity/state for alarm monitoring on the module, EDFA and lasers. It also shows if an alarm is active and if it was active in the past.

With the **Clear** button in the bottom right corner, you can clear the alarm history for the DVE.

Note that because the device reacts slowly when a parameter is set, a delay of 1.5 seconds has been added. In some cases, it could occur that this is not enough, and there is a delay of 30 seconds (i.e. the next polling from the timer). This information can be important for the design of Automation scripts.

### User Setup Page

This page contains information regarding the mode selection, laser setup and alarm setup.

### Module Info Page

This page displays information about the module itself.
