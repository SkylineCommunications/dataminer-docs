---
uid: Connector_help_Jersey_Microwave_KABDC-188193-2015-ODU
---

# Jersey Microwave KABDC-188193-2015-ODU

The Jersey Microwave KABDC-188193-2015-ODU connector displays all the operational properties of a Jersey Microwave Ka-Band Block Down Converter system, referred to as "parameters" in the connector. This redundancy switch system embodies multiple Jersey Microwave converters, an indoor controller and an outdoor controller referred to as the switch. It monitors the alarm output from the converters and the status of the latching transfer switches to provide complete status information to the user. Using the serial interface, the connector allows you to control the most important properties. You can for example adjust the switch state, set the attenuation or tune the reference frequency.

This connector was created to be as generic as possible. This way, you can use it for a complete KABDC system or for any individual unit of a KABDC system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                     |
|-----------|--------------------------------------------|
| 1.0.0.x   | JMC-048-05 (switch) JMC-338-05 (converter) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Main Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 19200
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: No
  - **FlowControl**: No

- Interface connection:

  - **IP address/host**: 192.168.17.46 (the factory default IP of the controller)
  - **IP port**: 4000
  - **Bus address**: Not required

### Initialization

At the top of the Alarms page, you can find a virtual DataMiner parameter that is intended to monitor the Power Supply Status. This placeholder will show "Not Initialized" by default. To be able to monitor the Power Supply Status, you need to have an active element using the Advantech ADAM IO driver. You then need to link the Power Supply Status parameter to the corresponding DataMiner parameter of the Advantech ADAM IO element. You can do so using the Element Connections module. For more information, refer to [Virtual elements used for element connections](xref:Virtual_elements#virtual-elements-used-for-element-connections).

Other than that, no additional configuration is necessary in a newly created element. The connector will start to poll the factory default switch address (S). Based on the switch status response, the number of connected converters is retrieved. Empty rows (equal to the number of converters) will be filled in in the Outdoor Units Table, with the factory default address in each row (converter 1: A, converter 2: B, etc.). Finally, the converter status polling will start, using the factory default addresses.

### Redundancy

No redundancy is defined in the connector.

## How to Use

### Monitor and Control Complete System

When a new element is created, the connector will be initialized to monitor and control a complete KABDC system by default.

### Monitor and Control Individual Unit

If you select the *Not Applicable* check box for the **Switch Address** selector at the top of the **General** page, switch polling will be disabled. All corresponding DataMiner parameters will then have the value "N/A". You will only be able to use the connector to monitor and control one or more converters.

The **Outdoor Units Table** has options to delete a row (in the Table Options column) and add a row (with the Add Row button). When you add a row, it will include a default polling address, which you can adjust if needed.

### General Page

On the General page, you can **monitor the switch** status response, as well as the identifiers for each unit type, represented by standalone DataMiner parameters. The switch status/identifier/alarm history commands are sent using the Switch Address that can be modified at the top of this page.

At the bottom of the page, you can find the **Outdoor Units Table**. This table allows you to **monitor and control the converters**. Each row represents a converter. The converter status/identifier commands are sent using the converter address that can be modified in the Address column.

Commands are sent directly after the value change in a cell is confirmed. However, keep in mind that **some value changes can take time** to be implemented.

### Settings Page

On the Settings page, you can **control the switch** and adjust the bus address of each individual unit.

**Warning!** The following commands write to **non-volatile storage**. Functions that write to non-volatile memory **should not be used in a real-time, dynamic situation** where the write cycle exceeds once every few hours. To do so would risk exceeding the life write cycles specified for the internal flash memory.

- Switch

  - Device Address Change
  - Extended Indicator Mode
  - Automatic Mode

- Converter

  - Device Address Change
  - Save Parameters (outdoor unit properties that can be adjusted for each unit in the Outdoor Units Table)

**Only use the address configurations when really needed**! Take care when you adjust the bus address in case there are multiple units on the bus, so you do not assign duplicate addresses. To adjust the bus address, follow the steps below:

1. Select a device.
1. Clear the current bus address.
1. Go to the General page and wait until "@" shows up as the new address for the device you just cleared.
1. Go back to the Settings page, select a new **unique** address and confirm.
1. Go back to the General page and wait until the new unique address is assigned.

### Alarms Page

On the Alarms page, you can monitor the Power Supply Status (if it is linked), as well as the 10 most recently detected alarms in reverse chronological order. The most recent alarm will be displayed at the top.

## Notes

The switch is only polled when the polling address (General page \> Switch Address at the top of the page) is not equal to "@" or "N/A".

A converter is only polled when the polling address (General page \> Outdoor Units table \> Address column) is not equal to "@".
