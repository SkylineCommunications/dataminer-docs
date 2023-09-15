---
uid: Connector_help_Rohde_Schwarz_TMU9_DVBT2
---

# Rohde Schwarz TMU9 DVBT2

The R&S TMU9 DVBT2 is a compact-size, efficient and reliable transmitter with different possible standard configurations. Power consumption ranges from 300 W to 3.0 kW for digital standards, going up to 4.75 kW for analog standards. With an efficiency of up to 30 % in normal mode, it both saves energy and reduces CO2 emissions. Built-in bandpass filters ensure short delivery times and innovative configurations, such as MultiTX or N+1 systems in a single rack.

This **SNMP** connector is used to monitor and configure the **Rohde Schwarz TMU9 DVBT2** transmitter.

## About

This connector can be used to monitor parameters of the transmitter and configure it.

### Version Info

| **Range**     | **Description**                                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x              | New MIB implementation. Cooling page added                                         | No                  | Yes                     |
| 1.1.1.x \[SLC Main\] | Based on version 1.0.1.5 Parameter sequence changed. Analog mode parameters added. | No                  | Yes                     |
| 2.0.0.x              | Branch version based on 1.0.1.x. DVE functionality added.                          | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |
| 1.1.1.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general parameters related to the device, such as **system information and control**, **software updates**, **device and product info**, **Tx common control, functions and notification**, **GPS**, **UPS**, **date and time** configuration and **options management**.

### DVB-T2 Status

This page contains the **DVB-T2 State** monitoring table and the **DVB-T2 Status Notification** config table. It also contains a page button that allows access to the **DVB-T2 Sub State** monitoring table.

### DVB-T2 Setup

This page contains a set of monitoring and control tables, related to **Configuration**, **Localization**, **Individual Addressing (IA)**, **Channel**, **Frame Structure**, **Layer 1 (L1)** and **PLP**. It also contains a subpage with the **Sub Configuration** and **Sub Localization** tables.

### DVB-T2 Output

This page contains all monitoring and configuration parameters related to the output for every transmitter. These can be found in the following tables: **Output Localization**, **Output Channel**, **Output Frame Structure**, **Output Layer 1**, **Output PLP**, **Output PAPR-TR** and **Output FEF**. A subpage allows access to tables with additional information.

### ATV Video Input (1.1.1.x)

This page contains all the tables related to the ATV video: The **ATV Input Video**, **ATV Video State** and **ATV Video Config** table.

### ATV Audio Input (1.1.1.x)

This page contains all the table related to the ATV audio: The **ATV Input Audio**, **ATV Audio State** and **ATV Audio Config** table.

### Cooling

This page includes all pressure- and temperature-related parameters. It allows you to monitor the **inlet and outlet temperature state**, the **coolant pressure and temperature state** and the **coolant temperature** **configuration**. In addition, the **General Configuration** section allows you among others to set the **Cooling State** to *On* or *Off*, to configure the **Cooling Type**, to set the **Heat Exchangers per Rack** and the **Fans per Heat Exchanger**, to enable or disable the **Anti Freeze**, set the **Pumps Extra Flow Rate** and set the **Fan Max Speed**.

### Air Cooling State (1.1.1.x)

This page contains the **Air Cooling State** table.

### Air Cooling Notification (1.1.1.x)

This page contains the **Air Cooling Notification** table.

### Liquid State (1.1.1.x)

This page contains the **Liquid Cooling State** table.

### Liquid Notification (1.1.1.x)

This page contains the **Liquid Cooling Notification** table.

### Tx Transmitter

On this page, you can monitor the **Transmitter State** and both monitor and configure the **Transmitter Notification** and **Commands**.

### Tx Exciter

This page is similar to the Tx Transmitter page, displaying the **Exciter Notification**, **Commands** and **State**.

### Tx Exciter Automatic

This page contains the **Tx Exciter Automatic** table.

### Tx Input Interfaces

This page contains a set of tables with information on all inputs, namely **Notifications**, **IP** and **TS Feed**, **General Setup** and **Monitor**.

### Tx Input Sat

This page displays all Sat information and settings for every input, in the **Tuner**, **LNB**, **CAM**, **IP Output**, **General** and **Extras** tables.

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

This page displays the **MTx** **Notification** **Table.** In addition, it contains all information about **NPlus1**, including the **NPlus1** **Configuration** and **Status** monitoring, which can be accessed via page buttons.

### Configuration (1.0.1.5 and 1.1.1.x)

This page displays the display key parameters that can be configured in the tables.

### Traps (1.1.1.x)

This page displays the **Events** tables.

### DVE Modules (2.0.0.x)

This page contains the **DVE Table**. The DVEs representing the transmitters and exciters are created with the data in this table.

### Web Interface

On this page you can access the web interface of the Rohde Schwarz TMU9 DVBT2 transmitter. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
