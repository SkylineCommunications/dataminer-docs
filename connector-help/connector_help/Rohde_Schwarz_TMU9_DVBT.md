---
uid: Connector_help_Rohde_Schwarz_TMU9_DVBT
---

# Rohde Schwarz TMU9 DVBT

The R&S TMU9 DVBT2 is a compact-size, efficient and reliable transmitter with different possible standard configurations. Power consumption ranges from 300 W to 3.0 kW for digital standards, going up to 4.75 kW for analog standards. Built-in bandpass filters ensure short delivery times and innovative configurations, such as MultiTX or N+1 systems in a single rack.

This **SNMP** connector is used to monitor and configure the **Rohde Schwarz TMU9 DVBT** transmitter. This connector is based on the Rohde Schwarz TMU9 DVBT2 connector, range 2.0.0.x

## About

### Version Info

| **Range**            | **Key Features** | **Based on**                            | **System Impact** |
|----------------------|------------------|-----------------------------------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | Rohde Schwarz TMU9 DVBT2, range 2.0.0.x | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.4.25                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**               |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Rohde Schwarz TMU9 DVBT - Transmitter |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

You can find more information on the data pages of the connector below.

### General

This page displays general parameters related to the device, such as system information and control, software updates, device and product info, Tx common control, functions and notification, GPS, UPS, date and time configuration, and options management.

### DVB-T Status

This page contains the **DVB-T State** monitoring table and the **DVB-T2 Status Notification** config table.

### DVB-T Setup

This page contains a set of monitoring and control tables, related to **configuration**, **localization, and modulation.**

### DVB-T Output

This page contains all monitoring and configuration parameters related to the output for every transmitter.

### Tx Transmitter

On this page, you can monitor the **Transmitter State** and both monitor and configure the **Transmitter Notification** and **Commands**.

### Tx Exciter

This page is similar to the Tx Transmitter page, displaying the **Exciter Notification**, **Commands**, and **State**.

### Tx Exciter Automatic

This page contains the **Tx Exciter Automatic** table.

### Tx Input Interfaces

This page contains a set of tables with information on all inputs.

### Tx Input Sat

This page displays all Sat information and settings for every input.

### Tx Input Automatic

This page contains the **Automatic Notification** and **Automatic Configuration** tables, which allow full control over input automatic configuration.

### Tx Frequency Regulation

This page contains the **Notification** and **Setup** tables, allowing you to both monitor and configure the frequency regulation parameters. Additional information is also available in the **Frequency Regulation** **State** **Table**.

### Tx SFN

Similar to the Tx Frequency Regulation page, this page contains the **SFN Notification** and **Setup** tables, as well as the **SFN State** monitoring table.

### Tx Precorrection

This page contains a **Notification** table as well as **Linear** and **Non-Linear** **Setup** and **State** tables. It also includes the **Crest Factor Reduction** table for both monitoring and control.

### Tx Output Stage

On this page, you can monitor and configure the **Notification** and **Commands** tables, as well as monitor the **State** table.

### Tx Amplifier

On this page, you can configure the **Notification** and monitor the **State** and **PMx** tables.

### Tx Presets

On this page, you can **load and save presets** for every transmitter.

### Tx RF Sensors

This page contains the **Tx RF Sensors** **Notification** **Table** as well as the general **Tx RF** **Sensors** **Table**. The latter allows you to monitor and configure a large set of sensor-related parameters.

### MTx

This page displays the **MTx** **Notification** **Table**. Via page buttons, you can access information about the **Dual Drive Exciters and DVB Single Transmitter**.

### Air Cooling State

This page contains the **Air Cooling State, Air Cooling Notification, Air Cooling Pressure**, and **Air Cooling Fan** tables.

### Active Reserve

This page contains the parameters related to the **active reserve amplifiers and exciters**. More details can be found on the **AR Exciter Details** page.

### Polling Configuration

From version 1.0.0.3 onwards, a **Polling Configuration** table is available where you can define the polling intervals for the following groups of parameters:

- **General System**
- **General System Control**
- **System OR**
- **Interface**
- **Product Info**
- **Device Info**
- **Common Tx Notification**
- **Common Tx Functions**
- **Common Tx Control**
- **Option Management**
- **Date and Time Configuration**
- **UPS**
- **GPS**
- **DVB-T Output**
- **DVB-T Status**
- **Tx Transmitter Status**
- **Tx Transmitter Configuration**
- **Tx Exciter Status**
- **Tx Exciter Configuration**
- **Tx Input Interfaces Status**
- **Tx Input Interfaces Configuration**
- **Tx Input IP Feed**
- **Tx Input TS Feed**
- **Tx Input Sat General**
- **Tx Input Sat IP Output**
- **Tx Input Sat Feeds**
- **Tx Input Automatic Status**
- **Tx Input Automatic Configuration**
- **Tx Frequency Regulation Status**
- **Tx Frequency Regulation Configuration**
- **Tx SFN Status**
- **Tx SFN Configuration**
- **Tx Precorrection Status**
- **Tx Precorrection Configuration**
- **Tx Output Stage Status**
- **Tx Output Stage Configuration**
- **Tx Amplifier Status**
- **Tx Amplifier Configuration**
- **Tx Presets Status**
- **Tx Presets Configuration**
- **Tx RF Sensors Status**
- **Tx RF Sensors Configuration**
- **MTx**
- **Dual Drive General**
- **Dual Drive Exciter A**
- **Dual Drive Exciter B**
- **DVB Single Transmitter**
- **Air Cooling**
- **Active Reserve**

By default, polling for these groups is enabled, and they have the same polling intervals as in previous versions of the connector: 1 minute for fast parameters, 5 minutes for medium parameters, and 30 minutes for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

### DVE Modules

This page contains the **DVE Table**. The DVEs representing the transmitters and exciters are created with the data in this table.
