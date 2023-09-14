---
uid: Connector_help_CPI_SSPA_S5CI
---

# CPI SSPA S5CI

The **CPI SSPA S5CI** is a C-Band Solid State Power Amplifier.

## About

This connector allows you to manage the **CPI SSPA S5CI** via a serial connection.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                        |
|------------------|----------------------------------------------------|
| 1.0.0.x          | 01.01.05 (Main Controller Kernel Software Version) |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.14.11 (Moxa)*.
  - **IP port**: The IP port of the device, e.g. *4003*.
  - **Bus address**: Used to fill in the unit address, by default *48.*

## Usage

### General Page

This page contains both the **Main Controller** and **Front Panel Software Revisions**, as well as the **Band**, **Time**, **Time Zone**, **Web Interface**, **System State**, **Switch Controller Mode**, **Serial Number** and **Auto Log Time.**

The page contains three page buttons, which open the following subpages:

- *Configuration:* **BUC Unlock**, **Relay 1**, **Relay 2**, **Relay 3**, **Relay 4**, **High Reflected RF** and **Switch System** configuration parameters.
- *Network:* **IP Address**, **IP Gateway**, **IP Mask**, **NTP** and **SMTP** server.
- *Settings*: **Fwd** and **Rev Sampler Offset**, **Attenuator**, **Waveguide Switch**, **Attenuation Calibration**, **Power Copy** and **Switch Sequential Drive**.

Finally, there is also a button that can be used to **reset** all **faults**.

### Status

This page displays all alarms and faults states: **Control Point**, **ALC**, **Fault Recycled**, **Switch Inhibit**, **Fault Inhibit**, **BUC Unlock**, **Fwd Sampler**, **Rev Sampler**, **BBRAM**, **XProt**, **Hot Spot Under Temp**, **Latched**, etc.

The page contains seven page buttons, which open the following subpages:

- *PS (Power Supply):* All statuses related to **PS**: **Under** and **Over** **Voltage**, **AC**, **Heatsink**, **Comm**, **Current** **Limit** and **Fan Status**.
- *Cabinet:* **Over** and **Under** **Temperature**, **High** and **Low** **Temperature** **Trip** **Point Status**.
- *RF:* **Power Mode**, **High** and **Low RF**, **High** and **Low Reflected RF Status.**
- *Brick:* **Vd** **Over** and **Under** **Voltage**, **Over** **Temperature** **Switch**, **Hot** **Spot** **High** and **Low** **Temperature** **Trip** **Point Status**.
- *Fan:* All the **Fan** **Stall** **Statuses** are present in this page (1-6).
- *Comm:* **Front** **Panel** and **Main** **Board** **Status**.
- *Inlet:* **Over** and **Under** **Temperature**, **High** and **Low** **Temperature** **Trip** **Point** **Status**.

### Measurements

This page displays the **RF Output** and **Reflected RF Output Power** in different units (W, dBW and dBm), as well as the **PS** **Power** (1-4), the **PS** **Total** **Power**, **Maximum** **Amplifier** **Power**, **RF** **Input** and **Output** **Calibration** **Sample** **Points** (1-5).

The page contains three page buttons, which open the following subpages:

- *Temperature:* **Inlet**, **PS** **FET** (1-4), **PS** **Diode** (1-4) and **Brick** **Hot** **Spot** **Temperature**.
- *Voltage:* **PS Voltage** (1-4), **Vd Over** and **Under Trip Point**.
- *Current:* **Id Current**, **PS Current** (1-4) and **Id Over Current**.

### Trip Points

This page displays the **Low** and **High** values for the **RF** **Output**, **Reflected** **RF** and **RF** **Output** **Power** **SetPoints** **Alarms** in three different units (W, dBW, dBm).

### Amplifier

This page displays the **Amplifier** **Id**, **Amplifier** **Priority**, **Type** **Id**, **Type** **Number**, **Band** **Id**, **Location** **Id**, **Waveguide** **Switch** **Position** (1-4), **Amplifier** **State** (1-4), **Switch** **Mode** and **Positions**.

There is one subpage, which can be opened via the **Fans** page button. It contains the value for the **Fans** **Tachometer** (1-6) and the **Fan** **Control**.
