---
uid: Connector_help_Chloride_70-NET
---

# Chloride 70-NET

The **Chloride 70-NET** is a UPS Power Protection Battery. It makes sure that devices can remain powered during power outages.

## About

This connector allows the monitoring of attached devices, the health of the battery, and input and output parameters.

## Installation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Disabled: no value is needed here.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private.*

## Usage

### General Page

This page contains generic parameters such as the **Firmware/Software name, Agent Software Version** and **UPS Name**. **All Attached Devices** are also visible here. A **Control Settings** page button takes you to the **Shutdown and Reboot** options for the device.

### Battery Page

This page provides a visual overview of the **Battery Status** and its **Charge.**

### Input Page

This page contains all three phases for the **Input Voltage, Input Current, Input Frequency** and **Input True Power.**

### Output Page

This page contains the **Output Source, Frequency** and **Total Average Load.** The page also provides all three phases for the **Load, Voltage, Current** and **Power**.

### Alarms Page

On this page, you can view an alarm table indicating all **Alarms** present on the device, if any.

### UPS Test

This page allows a user to **Run, Abort** and follow up on tests with the UPS. The following types of tests are available:

- **General Systems Test**
- **Quick Battery Test**
- **Deep Battery Callibration**
