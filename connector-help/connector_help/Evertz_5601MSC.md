---
uid: Connector_help_Evertz_5601MSC
---

# EVERTZ 5601MSC

The **5601MSC Master Sync and Clock Generator** is a master sync pulse generator (SPG) and a master clock. It provides synchronizing signals and at the same time solves the problem of locking an in-house master clock system to the master video sync pulse generator.

## About

This connector allows the management of the Evertz 5601MSC device using the **SNMP** protocol. The device does not support multipleGetNext.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page contains the **System Description**, **Up Time**, **Contact** and other such parameters. It also displays the **Modem**, **NTP**, **IRIG** and **Change Counter** status.

### Input Page

This page contains the **GPI1**, **GPI2**, and **Synchro Link Status**. On the page, you can also view and configure **Time Reference**, **GPS** and **Frequency Reference** related parameters.

### Analog Sync Output Page

This page contains the **Sync Table**, in which you can monitor and configure parameters such as **Video Standard**, **Video VITC**, **Video Jam**, etc.

### LTC Output Page

This page contains the **Output LTC Table**, in which you can monitor and configure LTC related parameters such as **LTC Power**, **LTC Rate**, **LTC Jam Time**, etc.

### Output Settings Page

On this page, you can configure the parameters related to **GPS**, **10MHz**, **Video**, **Free Run**, **Global Pedestal** and **Preset** selection.

### Analog/SDI Test Generator Page

This page displays two tables, the **Test Generator Table** and the **Video Audio Group Control Table**. With these, you can generate each scenario of test generation.

The page also contains a page button, **Test Patterns**, that displays the available test patterns when clicked.

### ARS/AES Test Generator Page

This page displays configurable parameters relevant for **DARS/AES** test generation.

### Analog Audio Tone Generator Page

This page displays configurable parameters relevant for **Analog Audio** test generation.

### Faults Page

This page contains two tables:

- the **Ip Trap Address Table**, in which traps can be configured, and
- the **Mgmt Fault Table**, in which you can monitor the **Fault Status** for each type of fault, designated by its **Fault Name**.

### Configuration Page

On this page, you can configure the device with parameters such as the **Time setting**, **Date** and **Password**.

The page also contains a page button that leads to the device's **Visibility Control**.

### NTP Page

This page contains the **NTP Table**, where you can configure the device's NTP in the columns **NTP Restriction**, **NTP Restrict IP**, and **NTP Restrict Mask**.

### Modem Page

On this page you can configure the **Modem**.

The page contains two buttons: **Dial Now**, which will dial the number provided in the **Phone Number** parameter, and **Cancel Call**.

### Daylight Saving Time Page

On this page, you can configure the **Daylight Saving Time**.
