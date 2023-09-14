---
uid: Connector_help_Advantech_AMT_MC_16R-250L12-000
---

# Advantech AMT MC 16R-250L12-000

The Advantech AMT MC 16R-250L12-000 is a monitoring and control panel for redundant Solid State Block Up-Converters (SSPBs). This connector can be used to monitor this device.

## About

The monitoring and control panel is used for redundant high-power SSPBs, monitoring the status of two units in a redundant system and allowing control over the SSPBs. This device will monitor the slave SSPBs continuously, collecting and updating information as well as controlling the SSPBs as required, using the SC protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: 9600
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: None
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains general information and control settings for the controller, and displays the overall status of the units connected to it. More specifically, it provides information about the unit **Serial Number** and the **Units A, B** and **S Transmission Status**.

Several buttons are available, which can be used to **Reset Faults** and to switch to **Switch 1** or **2.**

In addition, the **Switch 1, 2** and **3 Alarm** and **Connection Status**, the **A/B Position Error** and **Path Status** are displayed, as well as the unit **Shroud Temperature**, the **PS1** and **PS2 Voltage**, and the **Redundancy Status**.

### SSPB Unit A

This page displays information related to SSPB Unit A, such as the **Unit A Status**, **Transmission** and **Mute/Unmute Status**. It also contains the **Unit A** **Transmission Power** and **Reflected Power**, **Frequency Shift**, **ALC Status** and **Value**, **Elapsed Time**, **Gain A** and **B**, **Low Power Threshold**, **Communication** and **Fault Status**, **Alarm Summaries**, **Reflected Power** and **Shutdown Status**.

In addition, the page displays the **Unit A** **Shroud** and **Hot Spot Temperature**, **P/S Voltage** and **Current**, and the unit **Serial Number**, **Software Revision Number**, **Version**, **Device Type**, **Power Class** and **Frequency Band**.

Finally, you can also find the **Unit A** **Reference Status**, and the **Unit A** **ALC Suspended**, **High**, **Low** and **Temperature Alarm** here.

### SSPB Unit B

This page displays information related to SSPB Unit B, such as the **Unit B Status**, **Transmission** and **Mute/Unmute Status**. It also contains the **Unit B** **Transmission Power** and **Reflected Power**, **Frequency Shift**, **ALC Status** and **Value**, **Elapsed Time**, **Gain A** and **B**, **Low Power Threshold**, **Communication** and **Fault Status**, **Alarm Summaries**, **Reflected Power** and **Shutdown Status**.

In addition, the page displays the **Unit B** **Shroud** and **Hot Spot Temperature**, **P/S Voltage** and **Current**, and the unit **Serial Number**, **Software Revision Number**, **Version**, **Device Type**, **Power Class** and **Frequency Band**.

Finally, you can also find the **Unit B** **Reference Status**, and the **Unit B** **ALC Suspended**, **High**, **Low** and **Temperature Alarm** here.

### SSPB Unit S

This page displays information related to SSPB Unit S, such as the **Unit S Status**, **Transmission** and **Mute/Unmute Status**. It also contains the **Unit S** **Transmission Power** and **Reflected Power**, **Frequency Shift**, **ALC Status** and **Value**, **Elapsed Time**, **Gain A** and **B**, **Low Power Threshold**, **Communication** and **Fault Status**, **Alarm Summaries**, **Reflected Power** and **Shutdown Status**.

In addition, the page displays the **Unit S** **Shroud** and **Hot Spot Temperature**, **P/S Voltage** and **Current**, and the unit **Serial Number**, **Software Revision Number**, **Version**, **Device Type**, **Power Class** and **Frequency Band**.

Finally, you can also find the **Unit S** **Reference Status**, and the **Unit S** **ALC Suspended**, **High**, **Low** and **Temperature Alarm** here.
