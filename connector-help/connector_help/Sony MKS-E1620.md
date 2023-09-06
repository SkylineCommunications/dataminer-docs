---
uid: Connector_help_Sony_MKS-E1620
---

# Sony MKS-E1620

This connector allows you to control a Sony MKS-R1620 (hardware panel). The main purpose of the connector is to communicate with and be controlled by the software panel.

## About

### Version Info

| **Range**            | **Key Features**   | **Based on** | **System Impact** |
|----------------------|--------------------|--------------|-------------------|
| 1.0.0.x              | Initial version    | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added DCF support. | 1.0.0.19     | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |
| 1.0.1.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: To set the DMA for this element in server mode, set this to ***any***.
  - **IP port**: The IP port of the destination.

#### SNMP Connection - SNMP

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page contains general info from the device such as the **Protocol Name** and **Protocol Version**, as well as**Panel Info** and **Extra Panel Info**.

On the **Change Panel Info** subpage, you can configure the**Panel Name**, **Panel User**,and **Panel Description**.

### Product Information

This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.

### Network

This page displays the **Interfaces** table, which shows the operational status of the interfaces available in the workstation.

### Panel Display

This page displays the **Panel Display** table. From this table, all the LCDs can be controlled.

When a button is cleared, the following settings will be implemented for that LCD:

- Color: black
- Tally: Low
- IconId: 0
- Line numbers: 0, label1="", label2="", label3=""
- Inversions: normal
- Blinking: false
- StringBlink: false

### Panel Configuration

This page allows you to control the **Brightness Panel, Beacon**, and **Auto Fill LCDs** settings. When Auto Fill LCDs is enabled, all info in the Panel Display table is sent to the device.

You can also change the **Rotary Command Settings**.

- In **Fast Mode**, the hardware panel will use a **buffer** **to capture commands** coming from the device.The timer for this is time-based, which means that when a certain time has passed, the buffer will be read and forwarded to the software panel. You can set the time for this with the parameter **Rotary Buffer Time**.You can set this to a very **fast pace**, in which case you can **set parameters without having to wait for feedback**, and therefore not make as many sets on the device and create less traffic in the system. However, **if the system is slow, you might need to wait too long** for the LCD to update, and you might overshoot your targeted value.
- In **Safe Mode**, the hardware panel will **wait for the software panel to confirm** if a set or update has been done on the remote device. While processing and waiting for the confirmation of the set, the connector will block any other input from the device on that rotary knob.To ensure no permanent locks can occur, a **timeout** is possible. You can set after how long this timeout should occur using the **Software Panel Timeout Time** parameter. When a command is received, the current time is saved, and the command is sent to the software panel. If a new command is then received, while the connector is still waiting for a response, it will check if the timeout time has passed. If it has passed, the new set will be sent to the software panel, the knob will again be locked, and the current time is saved.With this mode, parameters will be set a bit more slowly, but the advantage is that it can happen with **more accuracy**. However, if you want to change values at a quick pace, you will be limited by the time in which the end device can receive, process, and send back the new value. Because of this, it can appear as if sets are happening slowly, while actually it is usually the response of the device that is slow.

### Alarms

This page displays the **Error Status** table.

### Panel Errors

This page displays the **Panel Errors** table, which lists all the errors thrown after commands were sent to the panel.

### Traps

This page displays the **Traps Destination** table.
