---
uid: Connector_help_Audemat_Aztec_Golden_Eagle_DVB-T-H
---

# Audemat Aztec Golden Eagle DVB-T-H

This connector is used to monitor the **GOLDENEAGLE DVB-T**, a standalone DVB-T monitoring device used at the transmitter site or in the coverage area. The unit sequentially monitors a set list of channels and continuously verifies that the DVB-T network complies with requirements.

## About

This connector uses an **SNMP** connection to monitor the Audemat GOLDENEAGLE DVB-T.

Polling happens at different intervals, as described in the "Usage" section below. Note that all mentioned time intervals are applicable with the **Timer base** equal to *1* (default), but this can be changed on the default DataMiner page "General Parameters".

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.1.0                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Overview

On this page, you can find an overview of the data monitored by the device. The first level of the tree structure displays a list of monitored multiplexers, the next level displays the channels (services), and the last level displays the programs (PIDs) in the system.

If you select a multiplexer, extra tabs will immediately show all the programs from all channels. The **Alarm Flags** tab will display a list of error indicators.

### General

On this page, general system parameters are displayed, such as **Name**, **Version** and **Serial Number**.

Page buttons allow you to view the "raw" data as retrieved from the device.

Note: In versions prior to 1.0.0.10, you can view or configure the normal values for the **RF Level** by clicking the **Normalize RF Levels** button, and copy the current values to the **Nominal Levels Table** by clicking the **Normalize** button, so that they can be used for comparison with new measurements. However, this feature has been removed in version 1.0.0.10 as there is normalization support in alarm templates.

### Alarms

This page contains three tables:

- **Alarm Table**: Active alarms and the timestamp of their occurrence.
- **Alarm Flag Table**: Discreet alarm values for each multiplexer.
- **Alarm Flag Table (RAW SNMP DATA)**: The original SNMP data for the Alarm Flag Table. Since it makes no distinction between different alarm types, the information is transformed in the latter table.

### Monitored Multiplexes

This page displays the **Monitored Multiplexes Table**, which shows the multiplexes and their measurements and configuration. For performance reasons, different timers are used for the polling:

- The basic section of the SNMP table is polled every 5 seconds and contains:

- **Mpx Instance**
  - **Mpx Name**
  - **Mpx Source**
  - **Mpx Monitored**
  - **Mpx Receiver**
  - **Mpx DVB-H / DVB-T**

- The measurements are divided in two groups:

- **Mpx RF Level** and **Mpx MER** are polled every 2 seconds.
  - **Mpx BER**, **Mpx Per** and **Mpx C/N** are polled every 5 seconds.

- The other configuration data is polled every 24 hours.

- **Mpx Trap** columns are updated when traps are received.

### Monitored Services

This page displays the **Monitored Reference Services Table**, which is polled every 24 hours and contains basic service information.

### Monitored Components

This page displays the **Monitored Reference Components Table**, which is polled every 24 hours and contains basic component information.
