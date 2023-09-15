---
uid: Connector_help_Comap_NSA
---

# Comap NSA

This serial connector is able to communicate with the **Comap NSA**. This device is a so-called **Uninterruptible Power Supply (UPS).** A wide range of parameters can be monitored. Internal alarm parameters are polled to enable the creation of alarms in DataMiner.

## About

This connector communicates with the device via the modbus serial communication protocol. The content of 129 registers is read by the connector once per minute.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.6                         |

## Installation and configuration

### Creation

#### Serial modbus connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Not specified.
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: No.
  - **FlowControl**: No.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *4001*. Range: *0-65535*.
  - **Bus address**: The bus address of the device, by default *1*. Range is *0-255*.

## Usage

The usage of this connector is not complex, as you can only use it to monitor parameters and not to change or delete anything on the device. The high number of parameters is divided over different pages.

### General Page

This page contains general information regarding the device, grouped in the boxes **Communication Settings**, **Info**, **Process** **Control** and **Statistics**.

In addition, the page also displays the **Remote Control Status**, originating from a byte interpreted bitwise.

### Engine Page

This page displays more details about the Engine of the Comap NSA, grouped in the boxes **Analog Computer**, **Engine Values** and **Info**.

You can set the **Controller Mode** of the device by selecting the mode in a drop-down list. If the value changes, it means that the set succeeded. More details can be viewed via the **Internal...** page button.

### Out Page

This page displays all information regarding the output of the device. The information is grouped in the boxes **Generator Values**, **Sync/Load Control** and **Volt/PF Control**.

### In Page

This page displays all information regarding the input of the device. The information is grouped in the box **Mains Values**.

### Alarms Pages

There are **16 Alarm Details Pages**, which are easily accessible below the first separator line. These pages contain all interesting alarm parameters (82 groups of three alarms in total).

The 16 Alarm Details Pages are:

- **BOC Under Alarms**
- **BOC Over Alarms**
- **BOC Other Alarms**
- **Emergencies Alarms**
- **Fuel Alarms**
- **GCB Alarms**
- **Generator Voltage Alarms**
- **Generator Other Alarms**
- **Mains Voltage Alarms**
- **Mains Power Alarms**
- **Mains Other Alarms**
- **MCB Alarms**
- **Oil Alarms**
- **Other Alarms**
- **SD Alarms**
- **Water Alarms**

On each of these 16 pages, the alarm parameters are grouped into **Alarm boxes**, titled with a description of the alarm. Each alarm parameter originates from 2 or 3 bits of a specific register, specified in the subtext of every parameter.

These **Alarm boxes** contain three values and are the result of dividing the bytes in three groups:

- **... Level 1:** The status of level 1 of this alarm:

  - Possible values are:

    - Inactive. (0)
    - N/A. (1;5)
    - Active, confirmed. (2)
    - Active, but blocked or delay still running. (3)
    - Previously active, not confirmed yet. (4)
    - Active, not confirmed yet. (6)
    - Active, not confirmed yet and blocked or delay still running. (7)

- **... Level 2:** The status of level 2 of this alarm:

  - Possible values are:

    - Inactive. (0)
    - N/A. (1;5)
    - Active, confirmed. (2)
    - Active, but blocked or delay still running. (3)
    - Previously active, not confirmed yet. (4)
    - Active, not confirmed yet. (6)
    - Active, not confirmed yet and blocked or delay still running. (7)

- **... Sensor Failure:** The status of the sensor of this alarm:

  - Possible values are:

    - Inactive. (0)
    - Active, confirmed. (1)
    - Previously active, not confirmed yet. (2)
    - Active, not confirmed yet. (3)

These alarm parameters are enabled for monitoring and trending. If the default alarm template is applied, each non-regular value (i.e. not *Inactive*) will cause the operator to be notified via the Alarm Console.
