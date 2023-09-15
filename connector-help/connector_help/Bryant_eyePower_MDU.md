---
uid: Connector_help_Bryant_eyePower_MDU
---

# Bryant eyePower MDU

The Bryant eyePower MDU is a serial connector that is used to monitor and control the mains distribution unit of Bryant of the same name.

## About

This connector allows the user to read all the given measurements of this unit. Derived values are also calculated and displayed much the same as in the web interface, although with the addition of the apparent power and power factor for each outlet. These outlets can be toggled and monitored on their page. GPIs are displayed separately with their own controls.

### Relay version 1.2.5 (January 10th, 2014)

This firmware made several changes to the command and response structure, which causes some commands to fail in the 1.0.0.1 connector version. Please use connector version 1.0.0.2 from this point onwards.

### Connector version 1.0.0.2

This version supports the changes of relay version 1.2.5, and is still compatible with previous relay versions.

### Connector version 1.0.0.3

The environmental readings are now available as well. See Usage-General-Environmental Measurements.

## Installation and configuration

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device's relay processor, ranging from *0* to *121* inclusive.

## Usage

### General

This is the default page of the connector and shows the main measurements:

- **Measurements Main/Backup Power Supply**

- **Live/Neutral RMS** - The mains RMS voltage.
  - **Live/Neutral Peak** - The mains peak voltage.
  - **Voltage Crest Factor** - The derived voltage crest factor (peak over RMS).
  - **Frequency** - The mains frequency.
  - **Neutral/Earth RMS** - The RMS voltage between the neutral and earth lines.
  - When the unit only has a single supply, the backup values will gray out and state *Single Supply Unit*

- **Power Measurements**

- **Total Current RMS** - The combined current drawn from the input(s).
  - **Total Real Power** - The total real power (P) measured by the device.
  - **Total Apparent Power** - The apparent power (S) derived by multiplying the highest RMS input voltage and the total RMS current.
  - **Total Power Factor** - The ratio of the real power to the apparent power.

- **Other Measurements**

- **Bus Live/Neutral RMS** - The bus RMS voltage.
  - **DC Offset** - The measured DC offset of the supplied mains.

- **Environmental Measurements**

- **Internal Temperature** - The temperature measured inside the device.
  - **1-Wire Temperature** and **Humidity** - The measurements from the 1-Wire sensor.

### Outlets

This page displays the **Outlets Status And Control** table, which contains the measurements and controls of the 14 outlets. There is also a button to turn off all switches at once. The table contains the following information:

- **Outlet \[IDX\]** - The number of the outlet and index of this table row.
- **Outlet Switch** - Desired state of the switch. Can be toggled between *On* or *Off* with the toggle button.
- **Outlet Relay** - The actual state of the relay. Updates one second after the **Outlet Switch** is changed in DataMiner.
- **Outlet Fuse** - The detected state of the outlet's fuse. Displays *Fail* or *OK*.
- **RMS Current** - RMS current measured through this outlet.
- **Real Power** - The real power (P) measured on this outlet.
- **Apparent Power** - The apparent power (S) derived by multiplying the highest RMS input voltage with the RMS current of this socket.
- **Power Factor** - The ratio of the real power to the apparent power.
- **Turn Off All** - Turns off all outlets with a single command.

### GPI

This page only contains the **General Purpose IO** table for the 4 GPIs.

- **GPI \[IDX\]** - The GPI number and index of this table.
- **GPI Direction** - Sets the GPI as an *Input* or *Output*.
- **GPI Set** - Sets an output as *High* or *Low*.
- **GPI Measured** - Measured GPI value, *Low* for 0V and *High* when a voltage is present. Also works when GPI is set as output, and the user can check if the output is driven.

### Macros

This lists the 8 macros as seen on the web interface. Their name is followed by the enabled status. If the status is disabled, this will change the row's text color to a red tint. Use the **Run** button to send the GOTO command. No GOTO command can be sent if the macro is disabled. In that case, the text color is changed to red.

Note: row coloring and a clickable button are only supported in DataMiner Cube.

### Web Interface

This page will make an attempt to retrieve the device's web interface from the local computer. Consequently, this only works when the computer and the device are in the same network or when a VPN is set up.

## Notes

Because of a broken command in the device, **GPI** sets are performed with a bulk set. This will overwrite any changes made to the switches outside DataMiner since the last poll.

The measurements are polled at a five-second interval, slightly slower than the browser interface.

The settings and status are polled every 30 seconds, but also after every change made in DataMiner.

To change the polling frequency, use **Multiple Set** to change the **Timer base** of this element. This is the factor that will be multiplied with said timers.
