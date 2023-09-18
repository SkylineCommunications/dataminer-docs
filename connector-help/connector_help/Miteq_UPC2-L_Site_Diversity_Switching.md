---
uid: Connector_help_Miteq_UPC2-L_Site_Diversity_Switching
---

# Miteq UPC2-L Site Diversity Switching

The **Miteq UPC2-L** is a unit designed for satellite communications systems. This connector can be used to monitor and configure the upconverter (UPC).

## About

This is a **serial** or **SNMP** connector used to monitor and control the **Miteq UPC2-L upconverter**.

### Version Info

| **Range** | **Description**                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                | Yes                 | Yes                     |
| 2.0.0.x          | Serial connection replaced by SNMP connection. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                         |
|------------------|---------------------------------------------------------------------|
| 1.0.0.x          | D205620V1.06 (System Controller), D206501V1.02 (Display Controller) |
| 2.0.0.x          | 209768 v1.15 (System Controller), 209769 v1.03 (Display Controller) |

## Installation and configuration

### Creation

#### Serial main connection (1.0.0.x range)

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device, between *64* and *95.*

#### SNMP main connection (1.0.1.x range)

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.

## Usage (1.0.0.x range)

### General

This page displays all information and configuration settings related to the entire unit.

This page can be used to check the overall status of the device, for example, the **Algorithm** the device is using or the currently **Active Receiver**.

The **Mode Status** parameter displays whether the device is in *local* or *remote* mode. *Local mode* means that settings can only be done via the front panel of the device, while *Remote mode* means that the settings can be done remotely. As such, it is important that the device's **Mode Status** is set to *Remote* if you want to change settings via the connector.

### Channels

This page displays information related to channels 1 to 10, with status parameters such as **Attenuator Impedance** or **Indicator**.

For each channel, you can configure certain settings, for example, the **Attenuator Operation Mode**, **Attenuation**, **Switch State** or **Switch Threshold Setting.** To do so, click the relevant page button to open the subpage with the settings.

Note that the **Ch XX Attenuation** parameters can only be set if **Ch XX Attenuator Operating Mode** is set to *Manual*. Furthermore, the **Attenuator** and **Switch** parameters are meaningless if **Ch XX Attenuator Operating Mode** and **Ch XX Switch Operating Mode** have the value *Not Present*.

### Receiver A/B

There are two pages available for the receivers: **Receiver A** and **Receiver B**. Both pages display the same information, but related to either receiver A or B.

These pages can be used to configure certain settings for the receiver, for example whether the receiver is active.

In addition, you can also access the **Downlink Signal Strength** and some other monitoring data via these pages.

One important point is the relation between the General page's **Algorithm** and this page's **Receiver Mode**. In case the algorithm used is *Diversity* or *Open-Loop*, only one receiver should be active at a time. As of version **1.0.0.4** of this connector, a pop-up message will be generated when one of these algorithms is used and an attempt is made to activate a second receiver. The second receiver will also **not be set as active** in this case. The standby mode is not affected by this, though.

### Ethernet

On this page, you can configure the following network parameters: **Ethernet IP Address**, **Ethernet Gateway Address**, **Ethernet Subnet Mask Address**, **Remote Ethernet IP Address** and **Remote UDP Port Number**.

### History Data

On this page, you can retrieve specific history data by specifying the **Command History Hour** and **Command History Minute** parameters. Then click the **Get Data** button and the following parameters will be filled in with the history value stored for the specified time: **Recorded Receiver A Downlink Signal Strength**, **Recorded Receiver B Downlink Signal Strength**, **Local Receiver Downlink Signal Strength** and **Remote Receiver Downlink Signal Strength**.

### UPC Event LOG

This page contains the **LOG Table**, which shows all the stored events with their associated **Event Date**, **Event Code** and (if relevant) **Attenuator Channel**.

The current number of stored entries is provided by the **Log Entries Count** parameter. To clear all the stored events in the device, use the **Clear LOGs** button.

## Usage (2.0.0.x range)

### General

This page consists of three sections:

- The **System Information** section contains general information about the system, including the **System Name**, **System Contact**, **System Location**, **System Clock**, **System Up Time** and the **System Password**.

- The **Firmware** section contains the **Specification Number** and **Version** of the **System Controller** and **Display Controller**.

- The **UPC Algorithm** section is used to configure the algorithm used by the UPC. Here you can choose the desired algorithm and the sample time.

  Please note the following:

  - The **Closed-Loop Feedback Attenuation Channel** and **Closed-Loop Idle Time** settings are only applicable when the *Closed-Loop* algorithm is used.

  - The **Comparison Multiplier** and **Comparison Tolerance** settings are only applicable for the *Comparison* algorithm.

    Setting these values may fail if the applicable algorithm is not enabled.

  - The **Dual-Track Receiver Levels** and **Settings Mismatch** alarm will indicate a problem in the configuration if the *Dual-Track* algorithm is used.

  - The **Diversity Remote UPC Link** alarm will indicate a problem in the communication with the second receiver if the *Diversity Beacon* algorithm is used.

### Ethernet Interface

This page is used to configure the Ethernet Interface of the System.

You can set the **IP Address**, **Subnet Mask** and **Default Gateway** here. However, note that updating these values will cause the system to restart and may lead to an inability to communicate with the device.

This page also displays the **MAC Address** of the Ethernet Interface.

### Channels

This page displays the **Attenuation Channels** supported by the system. When a channel is not installed, the values of this channel will have the value *Not Installed*.

The **Mode**, **Attenuation**, **Clear Sky Attenuation**, **Attenuation Offset**, **Uplink Power Ratio** and **Maximum Step Size** of each channel can be configured. Note that the attenuation of the channel can only be set when the channel is in *Manual* mode.

The table also displays the **Attenuation Impedance**, an indication if the channel has reached its **UPCMAX** condition and an **alarm** indicating any faults with the channel.

### Receiver A/B

There are two pages available for the receivers: **Receiver A** and **Receiver B**. Both pages display the same information and settings, but related to either receiver A or B.

On these pages, the **Mode**, **Voltage Polarity** and **Calibration Points** can be configured. Note that when updating the Voltage Polarity value, the Calibration Data Points will be cleared and the calibration has to be performed again.

The pages also display the **Downlink Signal Strength**, **Input Voltage** and an **alarm** indicating any problems with the receiver.

The **Calibration Data Table** is used to configure the calibration points of the receiver:

- The **Voltage** column displays the voltage associated with the calibration point.
- The **Voltage Retrieval Method** column contains "*Calibration*" when the voltage of the point is manually set or "*Linear Interpolation*" when the voltage of the point is calculated using linear interpolation between two manually defined calibration points.
- The **Calibration Point Status** column displays "*Clear Sky Calibration Point*" when the calibration point is set as a Clear Sky calibration point, otherwise this column displays "*Calibration Point*".
- The **Clear Calibration Point** column can be used to clear the calibration point. This can only be done on manually calibrated points and will cause the voltage of the point to be calculated using linear interpolation. When there are less than two manually set points, linear interpolation is not possible, and the voltage of the points will be set to an exception value.
- The **Set to Receiver Input Voltage** column is used to set the voltage of the calibration point to the currently measured input voltage of the receiver.
- The **Set Clear Sky Calibration Point** column is used to set the calibration point as a Clear Sky Calibration point.

### Power Supply

This page contains monitoring information for the two redundant power supplies, specifically the voltages measured at the **+15.30**, **+5.30** and **-15.30** **outputs** of each power supply, together with an **alarm** value indicating if there is problem with the power supply.

Note that when the alarm value displays "Fail", this does not always mean that the power supply failed, but could also indicate that the power supply is not being used.

### SNMP Configuration

On this page, you can set the **SMNP Communities** and the **SNMP Trap Configuration**. Note that when the SNMP Communities are updated, the connector could be unable to perform any sets or gets on the device.

The **Trap Destination Address** should be set to the IP of the DMA in order for the connector to handle any traps sent by the UPC. The **Trap Repeat** setting is used to define the frequency at which uncleared traps are repeated. When this value is set to 0, the trap will only be sent when it occurs. The **Refresh Timer** is used to set the frequency at which traps are identified by the UPC.

Finally, the **Trap Test** button will can be used to test traps. It will cause the UPC to send a trap with the value "False Alarm".

### System Log

This page contains the **System Log Table**, which displays the latest system log entries (up to 64). Each entry has a **Timestamp**, which is the system time when the event took place, a description of the **Event** and, if applicable, the name of the **Attenuation Channel** to which the entry refers. You can refresh the System Log Table using the button at the bottom of the page.
