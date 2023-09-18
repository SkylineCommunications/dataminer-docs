---
uid: Connector_help_General_Dynamics_500_Tracking_Receiver
---

# General Dynamics 500 Tracking Receiver

This is a **serial** connector that shows the status of the different parameters of a **General Dynamics 500 Series Analog Tracking Receiver**.

## About

The **General Dynamics 500 Series Analog Tracking Receiver** has 2 models:

- The **Model 520** is a high-performance pseudo-monopulse tracking receiver using an analog signal.
- The **Model 550** is a general-purpose pseudo-monopulse tracking receiver employing digital signal detection and offering beacon power spectrum displays and internal BDC options.

The connector communicates via **serial communication**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | D.3.1.2                     |

## Installation and Configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

Serial Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

Serial Settings:

- **Port number**: The port of the connected device*.*

## Usage

### General Page

This page contains general information, such as **Software Revision**, **Hardware Revision**, **Local/Remote Control**, etc.

There are also several page buttons, which open the following subpages:

- **Faults**: Contains **Faults Status Information**, such as **Temperature**, **PLL**, **Track**, **Autophase Status**, etc.
- **Spurs**: Contains the **Spurs Table**, which contains parameters such as **Spur Start Frequency**, **Correction Frequency**, etc. This table allows you to correct spurious signals.
- **Bands**: Contains the **Bands Table**, which is used to operate the **RF Chain**, as well as parameters such as **Band Start Frequency**, **Local Oscillator Frequency**, etc.

### Receiver Page

This page contains **configuration and status information** about the receiver, with parameters such as the **Voltage Controller Oscillator**, the **Narrow Band Sweep Width**, and the **Beacon Control**.

From version 1.0.0.2 onwards, a number of additional parameters are available on this page. These include frequency-related parameters, BITE Generator information, and three new configuration sections, related to **IP/Serial**, the **Sum ADC** channel and the **Error DAC** channel.

In order to properly configure the **Serial** parameters or the **Sum ADC** parameters, select a value and then use the **Send to Receiver** button to send the configuration to the tracking receiver. You do not need to fill in all values in the sections. If a value isn't filled in, the current value will be used to configure the tracking receiver.

### Monopulse Page

This page shows information and allows you to change settings that relate to **Monopulse-only** tracking receivers. It contains parameters such as **Scanning Mode**, **XEL Axis Tracking Slope**, **XEL Axis Phase Shifter**, etc.

It also contains buttons to **Clear the Track Fault** and to start the **XEL Autophase** or **EL Autophase** process.

### I/O Status Page

This page contains information about the current I/O of the tracking receiver. It includes parameters such as the **Tracking Unit Temperature** and the **Signal Strength**.
