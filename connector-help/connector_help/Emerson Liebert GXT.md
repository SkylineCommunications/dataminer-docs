---
uid: Connector_help_Emerson_Liebert_GXT
---

# Emerson Liebert GXT

This connector can be used to monitor UPS GXT platforms. It supports **GXT2,** **GXT3, GXT4**,and **GXT5** and receives information via **SNMP** communication. **SNMP traps** are received to update corresponding data. Depending on which type is used, GXT2, GXT3, GXT4, or GXT5, specific parameters will be retrieved in addition to the common parameters. When data cannot be retrieved for a particular parameter, the parameter will indicate *No Data.*

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                    |
|-----------|-----------------------------------------------------------|
| 1.0.0.x   | GXT2: 3.000.0 GXT3: 5.300.0GXT4:U170D210GXT5: MCUV130/190 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays a quick overview of the device status, including the **Device Info**, **Module** **Status**, **Battery**, **Input** and **Output.**

To consult additional info like **Reboot**, **Shutdown** **Cause** and **Tests**, click the corresponding page buttons.

### Alarms and Conditions

Here, you can find an overview of all the active alarms or conditions.

### Battery

This page contains all battery-related status parameters.

### Configuration

This page contains parameters related to the configuration of the device. Note that changing device settings with these parameters is not supported by all devices. (Some have hard-coded values.)

Available parameters are:

- **Expected Input Voltage**
- **Expected Input Frequency**
- **Configured Output Voltage**
- **Configured Output Frequency**
- **Output VA** (read only)
- **Configured Output Low Battery Time**
- **Audible Alarm**

Note: Muting the **Audible Alarm** will temporarily silence the alarm. At the point where the alarm would normally stop sounding, it will revert to *Enabled*.

### Monitor

This page contains measurement and status parameters related to input, output, and bypass. Several of these parameters are also available on the **General** page.

Some additional parameters include:

- **Bypass Frequency**, **Voltage**, and **Current**
- **Output Max** and **Min Volts**
- **Input Max** and **Min Volts**
- Etc.

### Network

This page contains **GXT2 Network** information.

## Notes

It is possible that some settings need to be configured on the device before the element is able to set up the connection and start polling the data. The steps below briefly explain how to proceed if polling does not start automatically:

1.  Open the web interface and select the tab **Configuration***.*

2.  Select the folder **SNMP** in the left section of the web interface.

3.  Enable all checkboxes on this page and set the **Heartbeat Trap Interval** to 1 minute. Note: You may need to click an **Edit** button first in order to be able to change settings.Note: You may be prompted to enter administrator credentials to proceed.Click **Save** when ready. The device may notify you that a restart is required to apply the changes; however, ignore the restart for now.

4.  In the left section of the web interface, select the folder **V1 Access** below the **SNMP** folder.

5.  Add 2 entries in the table: one with read access, the other with write access. Use *0.0.0.0* as the network name for both entries.Click **Save** when ready. The device may notify you that a restart is required to apply the changes; however, ignore the restart for now.

6.  In the left section of the web interface,just below **V1 Access**, select the folder **V1 Traps**. Click **Save** when ready.

7.  Add a trap entry and specify the IP of the DMA hosting the element. To be safe, you can also add one entry for each DMA in the cluster.Note: Use the same **Community**as specified in the V1 Access table.Note: Also enable the **Heartbeat** for this entry.Note: The default port *162* should be correct.Click **Save** when ready. The device may notify you that a restart is required to apply the changes.

8.  If the device displayed a pop-up message to notify you that a restart is required for the changes to take effect:

9.  1.  Click the **Restart** folder in the left section of the web interface.
    2.  Click the **Restart** button on this new page.Note: This should only restart the SNMP module and not the complete device.
