---
uid: Connector_help_IneoQuest_iVMS_-_Probe
---

# IneoQuest iVMS - Probe

The IneoQuest iVMS - Probe is a probe that is monitored by the iVMS.

## About

The **IneoQuest iVMS** will send **SOAP** commands to receive a list of available probes and their statuses in the iVMS system. For each new probe in that list, a **Dynamic Virtual Element (DVE)** will automatically be created for separate monitoring. The user can decide afterwards whether they want to keep the DVE or remove it.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 4.0.1.x          | 5.08                        |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [IneoQuest iVMS](xref:Connector_help_IneoQuest_iVMS).

## Usage

### Main View

This page contains a table with detailed probe information (**Port Status**, **Active Flows**, etc.).

### Alarm

This page contains the same tables (**System Alarm Table**, **Program Alarm Table** and **Transport Alarm Table**) as the Alarm page of the main element, but only with the alarms for that specific probe.

### Flows

This page displays information related to the status of the flows for this specific probe.

### Programs

This page displays information related to the status of the programs for this specific probe and flow.
