---
uid: Connector_help_Spectracom_SecureSync_GPS_Receiver
---

# Spectracom SecureSync GPS Receiver

This device provides multiple outputs used for networked devices and other technologies. The standard outputs are:

- 1 Pulse-Per-Second (1PPS): counts off seconds in a selected timescale (UTC, TAI or GPS).
- 10 MHz: used as a signal for control systems and clocks.
- Optional Cards: e.g. Precise Time Protocol (PTP), IRIG, etc.

These outputs are driven by their inputs. The standard inputs are:

- Global Positioning System (GPS)
- Network Time Protocol (NTP)
- Optional Cards: e.g. PTP (some cards are both in and output), extra 1PPS cards, etc.
- Manual

## About

This connector monitors only the inputs (GPS and NTP), since monitoring of the outputs is not necessary. The connector was not created to perform major configurations to the device or to log any events, as the device's web interface offers enough possibilities to do all this.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page provides **Device Information**, which contains a description of the device itself.

The **SNMP Settings** allow the user to *enable* or *disable* **Trap Authentication**. Similar to the web interface, the page button includes **Location** and **Contact** information.

The most important status information is available in **Time And Frequency Status**. It displays a summary of the device's states. Generally, if an error has occurred somewhere, you can see this here.

The page also allows the user to **Reboot** and **Upgrade** the device.

### Inputs

This page provides more information on the inputs. The **SecureSync** can be powered by an **AC Input**, a **DC Input** or both. **DC Input** is optional and provides a redundant and automatic power switchover if an input power fails.

The statuses of the **GPS Input** can be viewed in detail. The **1PPS**/**Time Validity** shows if the GPS signal can provide a trustworthy reference for the 1PPS signal and date-time information.

### NTP

This page displays the **Selected Reference Status**, which shows the used NTP status and configuration. A complete list of all the references can be found in the **Reference Status** table. In addition, some general NTP information is shown under the **NTP General** page button.

### Option Cards

This page displays the **Supported Optional Modules** table, where you can see which modules are available that can be monitored with this connector. To see the status of an option card, click the page button with the correct **Module Name.**

### Setup

On this page, the **Reference Priority** can be changed, which makes it possible to provide redundant inputs. A **Priority** is given from 1 (most important) to 15 (least important).

## Notes

Extra optional modules can be added to this device, but no MIBs were provided for any except the **PTP** module. The functionality of this connector is therefore limited to the standard inputs.
