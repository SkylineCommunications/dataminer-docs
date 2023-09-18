---
uid: Connector_help_Imagine_Communications_DA-HR6802+
---

# Imagine Communications DA-HR 6802+

The **Imagine Communications DA-HR6802+** connector is a serial connector combined with smart-serial that is used for monitor and configure the Amplifier card in a Imagine Communications frame. It is possible to activate alarming on all important parameters.

## About

Via this connector it is possible to monitor the Imagine Communications card, and also perform some sets.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x  | Initial version  | No  | No |
| 1.1.0.x  | Firmware update, based on 1.0.0.8Update interface<br>Add alarm priority<br>Remove unused parameters (input not locked, loss of input alarm, loss of lock alarm, loss of looped output)<br>Remap existing parameters on QAction(all, except loss of input)<br>Add new parameters (factory recall, loss of lock, soft reboot)<br>Rename parameters to conform to checklist<br>Revise QActions code in order to reduce SLProtocol calls | No  | Yes |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |
| 1.1.0.x          | 2.0                         |

## Configuration

### Connections

The **Imagine Communications DA-HR6802+** is a **serial** connector combined with **smart-serial** communication. During the creation of the **element** the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device (e.g. *172.32.65.38*)
- **IP port**: IP port of the device (fixed value: *4050*)
- **Bus address**: This is a combination of the frame number and slot number/id \<frameNumber **.** slotID\> (e.g. frame 1 & slot 12 at bus address: *1.12*)

**SMART-SERIAL CONNECTION:**

- **IP address/host**: The local DataMiner IP to receive responses (e.g. *172.0.0.50*)
- **IP port**: IP port of the DMA (fixed value: *4000*)

## Usage (Range 1.0.0.x)

### Alarms Page

On this page you can see some alarm parameters. (**Loss of Input**, **Input Not Locked** and **Loss of Looped Output**). The state of the alarms can be: "Alarm Inactive" or "Alarm Active". Alarming is available on these parameters.

Alarms can be *Enabled* or *Disabled* by Write buttons.

### Input Page

There is one page button: **Other**. On this page you can see the **Signal Presence**.

### Output Page

There is one page button: **Other**. On this page you can configure the **Slew Rate**. And monitor the **Locked Data Rate**.

### Processing Page

On this page the **Serial Number** and **License Key** are available. **License key** can be configured. There is also a page button named **Other.** On this page you can configure the **Loss of Input Alarm**, **Re-Clocking Mode** and **Loss of Lock Alarm**.

### Web Interface Page

On this page you can access the web interface of the Imagine Communications frame.

## Usage (Range 1.1.0.x)

### General

This page displays an overview of the alarms' status and the processing parameters.

### Parameters

This page contains two page buttons: **General** and **Processing**.

### Parameters/General

This page contains the **Serial Number**, **License Key**, **Factory Recall** and **Soft Reboot** parameters.

### Parameters/Processing

This page contains the **Signal Present**, **Reclocker Mode**, **Locked Data Rate** and **Slew Rate** parameters.

### Alarms

This page contains the status of the alarms, and two page buttons with the alarm configurations: **Toggle** and **Priority**.

### Alarms/Toggle

This page contains the toggle buttons for the alarms, in order to disable or enable them.

### Alarms/Priority

This page contains the priority buttons for the alarms.

### Web Interface Page

This page contains the web interface of the Imagine Communications frame.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **Serial** connector with **smart-Serial** connection means that there has to be a connection to a real device.

If there is a change on the device, then a response will be pushed to the DMA without having to send a poll request.
