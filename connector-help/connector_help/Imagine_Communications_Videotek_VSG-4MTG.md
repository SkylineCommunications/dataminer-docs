---
uid: Connector_help_Imagine_Communications_Videotek_VSG-4MTG
---

# Imagine Communications Videotek VSG-4MTG

The Videotek VSG-4MTG is a 3G/SD/HD master timing generator part of the Imagine Communications reference sync and timing platform. The unit is small in size, with redundant power supply inputs, and is low in power consumption and light in weight, making it perfect fit for all broadcast television and post production environments.

## About

SNMP connector to manage the Master Timing Generator.

### Version Info

| **Range** | **Description**                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x          | New firmware changes, OIDs shift, removal and addition of new parameters | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 3.0                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### -----Sources-----

### Source Selection

On this page, you can see and configure the **Source Select** (Primary, Secondary) as well as the **Jam Setup.**

### Phase Offsets

This page contains all the offsets for the **Primary** and **Secondary** **Sources**.

### Source Configuration

Configuration for various sources, including **GPS**, **VITC**, **LTC,** **PTP** and **NTP.**

### -----Outputs-----

### LTC Output

This page displays the LTC output information including output **Timing**, **Jam** **Sync**, and **LTC** related parameters dealing with **Time** **Code.**

### PTP Configuration

On this page one can find **PTP Configuration** parameters as well as parameters dealing with **ST 2059**, **IEEE** **1588**, and **AES 67.**

### NTP Configuration

This page holds the status for the **NTP Server.**

### DARS Word Clock

The mode for the output **DARS Word Clock** is shown here.

### Sync Output

This page shows different status for the following items **Sync Configurations, NTSC Pedestal, VITC Ten, Sync Format** along with page buttons linking to the output frame rate for the following resolutions **625, 525, 720p, 1080psf, 1080p, 1080i.**

### Sync Time Code

This page holds the various **VITC Status, TC Drop Frame Select, Bit Format, Source ID, Time Zone** and different types of **Offsets**. You can also find multiple page buttons linking to **VITC NTSC** **Lines** and **PAL**.

### Sync Jam

Various status parameters dealing with **Output Jam** can be found here, with five page buttons for each **Jam Schedule**. Inside each schedule the user can configure the **Period of Time**, **How Often**, **Day, Time** etc.

### Sync Timing

On this page you can find the **Horizontal, Vertical, and Frame Timing** options .

### -----Config-----

### GPIO

GPI out parameters are found here, for example **Input Function,** and **Polarity**

### Alarms

Status displaying if an alarm of that type is enable/disable, along with the parameters dealing with **Priority, Trigger Time, Clear TImes,** and **Acknowledge** for **Primiray**/**Secondary** **Source**, **Time Lock, GPS, PTP, NTP, ENET, VITC** etc.

### Settings

On this page you can find general read-only information about the device including **System Model, Fimware, MAC Address**. Also page buttons for some configurable parameters like **Reboot Unit**, **Screen Saver, Duration**, **IP** information, **DST Status**, **Time Information** and **Presets.**

### Source Status

This page containts various read-only parameters showing status information about **Time Base** items, **Primary, Secondary Source Selected**

### Input Status

On this page one can find different read-only parameters dealing with **Local Time, NTP, LTC, GPS, PTP, VITC** Inputs

### Output Status

Outout status for **PTP, NTP, LTC** along with **Sync Signal Type, Format, Offsets, VITC Lines**. Included here are **Time** parameters the **User Bits,** and **Drop Frame.**

### Alarms Status

Page contatining two tables, **Active**, and **History** alarms.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
