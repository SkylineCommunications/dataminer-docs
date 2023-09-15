---
uid: Connector_help_GlenSound_Atomic_Copper_29S
---

# GlenSound Atomic Copper 29S

The **GlenSound Atomic Copper 29S** is a **Telephone Interface**.

The Glensound Copper 29 is a high-performance Telephone Balance Unit designed to interface with analogue telephone lines. A high-performance network echo canceller enables the unit to achieve excellent isolation between send and receive circuits.

## About

This connector uses **smart-serial** communication in order to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device
  - **Bus address**: Not required.

## Usage

This connector contains **5 pages**.

### General

This page displays the last received **Status**, and allows you to define the **DTMF Dial Number**. It contains 3 buttons: **Go Off Hook**, **Go On Hook** and **Answer Go Off Hook**.

### Settings

On this page, you can configure settings, such as **Disconnect Tone Coefficient**, **Disconnect Tone Threshold**, **Disconnect Tone Cadence**, **Disconnect Tone Off On**, **Country**, **Mute Rx** and **Tx**, **Acoustic** and **Line Echo Canceller**, **K-Break Disconnect**, **Tone Disconnect**, **Auto Answer**, **DAA FS**, **Conference Mode**, **Ducker**, **AGC**, **Noise Gate** and **B Leg Audio Function**.

### DAA Chiptset Pages

On these pages, you can configure settings regarding the **DAA Chipset** from the **Register 100 to 159**.
