---
uid: Connector_help_Eutelsat_Uplink_Manager
---

# Eutelsat Uplink Manager

The **Eutelsat Uplink Manager** is a custom-made connector for Eutelsat that allows you to monitor and swap Uplink Stations.

## About

The **Eutelsat Uplink Manager** is a connector that was tailor-made for Eutelsat, and which allows them to monitor the current Uplink Station for 6 different devices (REU01, REU02, REU03, REU04, REU05, FTVo).
It uses fixed presets for the **DMA** and **element IDs**.
The connector also allows to start or stop a connection to an uplink, or to swap the uplink station for a particular device, or for devices at once.
Before any action can be made, the user has to enter a password within the connector, and this password has to match the Administrator password.
All actions are logged in an **Actions Table**.

## Installation and Configuration

### Creation

This connector uses a **virtual** connection and does not need any user information.

Element Configuration
For each of the uplink stations, the current status is derived from 3 parameters that exist in 2 SNMP elements, so apart from creating an element you need to define 3 connections for each parameter.
Eg. REU01 Combiner 1 is connected to Linked Element REU01 GCL (the connector will only let you select among elements with **"Generic CGL Equipments"** connector, and within that element needs to be linked to a parameter Combiner 1 - Input 5 (read).
Again the connector will only let you select within the range of parameters that matches the connector specifications.
The third parameter is always connected to a **Newtec AZ210 element**, **Modem Redundancy (Read)** parameter.

## Configuration within the connector

### Administrator side

An Administrator with level 3 security needs to set the password on the **Administrator** page, this is the password that will be used to verify that the correct user has logged in.
The **Administrator** page is only available from a **page button** on the **General** page.

### User side unlocking

When a user starts the element, he can see the status of the current uplinks (*Rambouillet, Cagliari, None, Double Uplink* or *Undetermined*).
In order to make any changes though, he has to type in the password that was specified by the Administrator on the **Password field** on the right hand side.
Once that has happened, the element is locked for a time interval of 5 minutes. During this time interval this user can Start/Stop individual uplink stations, Swap individual uplink stations, or Swap all Uplink Stations.
He can also clear the **Actions table**, or individual lines in the **Actions Table**.

## Usage

### General

On the left hand side of the **General** page the status of each device (*REU01, REU02, REU03, REU04, REU05, FTVo*) is shown, with 3 buttons.
**Start/Stop CGL** will toggle the current status of the *Cagliari* uplink for that element, irrespective of its current state.
**Start/Stop RMB** will toggle the current status of the *Rambouillet* uplink for that element, irrespective of its current state.
**Swap Uplink** will first check the current status of the element (*Rambouillet*, *Cagliari* or another status).
If a swap is performed and the current status is *Rambouillet*, then the uplink to *Rambouillet* will be stopped, and after waiting for 10 seconds, the uplink to *Cagliari* will be started.
If a swap is performed but the current status is *Cagliari*, the uplink to *Cagliari* will be stopped, then after waiting for 10 seconds, the uplink to *Rambouillet* will be started.
If during the swap the stop of an uplink fails, then the start of the alternate uplink will not occur.
If the status is *Undetermined, None (no uplink active) or Double Uplink (both uplinks active)*, no swap will occur.
There is also a **Swap all Uplinks** button at the bottom left hand, and this will perform the **Swap Uplink** as described above for all uplinks in a row, with 10 seconds in between.
All actions are monitored and logged in the **Actions table**.

On the right hand side there is a **password field** that enables you to lock the **element**. Without this, no actions can be performed.
Below it there is a **Locked By** status, which shows the user that has locked the element, if any.
Underneath is a parameter called **Session End**, which lists the Date and Time when the element will be unlocked again.
Below it is an **Actions table**, which lists all the actions that have occurred.
Each row can be deleted individually with the **Delete Row** button, and below the table is the **Clear Table** button, which indeed clears the table.
