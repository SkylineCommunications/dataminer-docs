---
uid: Connector_help_Socomec_BCMS720
---

# Socomec BCMS720

The **Socomec BCMS 720** is a robust and compact device that is used to monitor up to 72 single-phase branch circuits.

## About

With this connector, you can monitor and configure **Socomec BCMS720** devices with a **serial** connection. The serial connection uses the Modbus RTU protocol with 9600 bds.

The different parameters of the device are displayed on multiple pages.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

- **IP** **address/host**: The IP address of the serial gateway.
- **IP port**: The local TCP port of serial gateway.
- **Bus address**: The Modbus slave address, by default *1*.

## Usage

### Monitoring

This page displays information for **each branch:**

- **Current**
- **Minimum Current**
- **Maximum Current**
- **Rated Current**
- **Active Power**
- **Apparent Power**
- **Reactive Power**
- **Power Factor**
- **Power Factor Sign**
- **kWh**

In addition, you can **reset** the **min/max values** as well as the **kWh Values.**

**Branch names** can be **imported** with .csv files.

### Alarms

This page displays the 3 kinds of **current alarms for each branch:**

- **Zero Current Alarm**
- **High-Current Pre-Alarm**
- **Maximum Current Alarm**

With a page button, you can **configure** **thresholds** and **delays** for different alarms.

### Voltage Monitoring

This page displays all the voltages:

- **Phase 1 to Neutral**
- **Phase 2 to Neutral**
- **Phase 3 to Neutral**
- **Phase 1 to Phase 2**
- **Phase 2 to Phase 3**
- **Phase 3 to Phase 1**

The **frequency** is displayed here as well.

With a page button, all **alternate voltages** can be viewed.

### Main CT Monitoring

This page displays all the measured parameters of the **main CTs** (3 phase).

There is a button to reset the **main kWh**.

### Status

This page shows general alarms, such as:

- **Over Current Pre-Alarm**
- **Over Current Alarm**
- **Zero Current Alarm**
- **Over Voltage Main**
- **Under Voltage Main**
- **Over Voltage Alaternate**
- **Under Voltage Alternate**
- **Over Current Main**
- **Under Current Main**

All these alarms have a **latching** and a **non-latching** alarm. The latch is **clearable** from this page.

The page also displays the state of the 4 **digital inputs** on the Socomec BCMS720.

### Options

This page displays general options to **configure** the Socomec BCMS720.
