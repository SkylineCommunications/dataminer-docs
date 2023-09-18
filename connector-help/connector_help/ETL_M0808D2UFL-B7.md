---
uid: Connector_help_ETL_M0808D2UFL-B7
---

# ETL M0808D2UFL-B7

The **ETL M0808D2UFL-B7** connector monitors and controls changes on the 8x8 matrix-switch L-band unit through a single serial protocol.

## About

The connector has one timer that polls every 500 seconds for slow-changing information. Nonetheless, the protocol actively seeks the device's information.

## Installation and Configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **Type**: The connection type, *TCP/IP* by default.
- **IP Address/Host**: The IP address/host used by the device if using TCP/IP.
- **Port**: Network port used by the device if using TCP/IP.
- **Bus address**: The bus number used by the device, *65* by default.

## Usage

### Main View Page

This page displays the current **matrix configuration** of the device, where you can visualize and configure the desired connections between the inputs (on the left) and the outputs (at the top).

With the **Set Crosspoint...** page button, you can configure the existing crosspoints for the input and output lines.

### General Page

This page displays the status of the **power supplies (Controller PSU 1-4)**. With the **Reset Device** button at the bottom of the page, you can reset the device.

### Mnemonics Page

This page displays the existing mnemonics regarding the inputs and the outputs (**Destination Mnemonic 1-8** and **Source Mnemonic 1-8).**

With the **Set Source/Destination Mnemonic** page buttons, you can set/configure the desired mnemonics for the inputs and the outputs of the device.

### Matrix Configuration Page

On this page you can view and configure the labels assigned to the inputs and outputs of the matrix and determine whether these should be visible or not (based on **Input/Output Selection, Input/Output Number**).

In addition, you can configure the **allowed/non-allowed** crosspoint configurations from the allowed input-output/output-inputs. You can also configure whether users can **lock** the input/outputs or not. This selection of allowed/non-allowed entries needs to be typed.

## Notes

Protocol version 2.1.1.1 is based on version 2.1.0.2, with added DCF functionality.
