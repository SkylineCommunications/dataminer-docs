---
uid: Connector_help_Advantech_ADAM6050
---

# Advantech ADAM6050

The **Advantech ADAM6050** connector is a serial connector used to monitor and configure the inputs and outputs of the device.

## About

The **Advantech ADAM6050** is an 18-ch Isolated Digital I/O Modbus TCP Module, which supports High-to-Low Delay Output. With this connector, the outputs can be set for the device. The inputs are only monitored. It's also possible to set the user value, which is the value the user associates with the real value on the device. With the inversion setting, the user value will be the inverted value of the real value on the device.

## Installation and configuration

### Creation

When you create this element, only the IP address of the host and the port need to be configured.

### Installation

Before the connector can be used, the following .dll files have to be added in the directory *C:\Skyline DataMiner\ProtocolScripts*:

- Advantech.Adam.dll,
- Advantech.Common.dll,
- Advantech.Protocol.dll.

## Usage

### Main View page

The **Main** **View** page is only used to monitor the device settings. There are no write parameters.

### General page

The **General** page is similar to the Main View page, but on this page, the user can change settings for certain values.

### Configuration page

The **Configuration** page allows the user to set the **FSV** values for the different outputs. Also the **Communication** **WDT** and **P2P/GCL WDT** can be set. However, note that only one of the two can be *enabled* at the same time.

The set values for the FSVs and the WDT will only be set to the device when the **Apply** **FSV** button is clicked.

The **Host** **Idle** **Time** can also be viewed. This is the time that the host must be idle before the **FSV** values will be set to the outputs of the device.

### Backup page

The **Backup** page contains all the functionality for creating and restoring backups. When the **Create** **Backup** button is clicked, a backup of the current settings is made and the status of the backup is displayed. This backup will be saved in the folder *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Advantech ADAM6050*.

All backups will have a similar name. The name is formatted as follows: *\[Name of the element\]\_\[date\]\_\[time\].xml*.

It is also possible to restore the settings for the device to a backup that was taken for this type of device. There are two ways to do this: either the selected backup from the drop-down list can be restored, or the user can choose to restore the most recent backup for this type. The status of the restore will also be displayed.
