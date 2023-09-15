---
uid: Connector_help_Hirschmann_Multimedia_Rover_TAB7
---

# Hirschmann Multimedia Rover TAB7

This is a monitoring device that can be used to perform direct measure testing or Round Robin measurements.

## About

Data and commands are retrieved/set through JSON commands.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.50a                       |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.5.1.27*.
- **IP port**: The IP port of the destination, e.g. *8888*.
- **Bus address**: *bypassproxy.*

## Usage

### Unit/Status

On this page, you can find parameters such as **Name**, **Serial Number**, **FW Version**, **uC Version**, **PSU1/2 Status**.

Via the **IP Address** page button, you can set the **Watchdog Timer**, **IP Config**, **IP Address**, **Network Mask**, **Gateway**, **Speed** and **Duplex**, and get the **MAC Address**.

### Measure

You can choose between *Round Robin* or *Monitor* mode with the **Status** parameter, and set the **Target Mode** to one of the following values: *ANALOG-TV*, *RADIO*, *DVB-C*.

The page contains a number of buttons that provide access to configuration options:

- Via the **Channel Panel** page button, you can among others set the **Target TV Mode**, **Target Symbol Rate** and **Target Frequency**.

- Via the **Thresholds Panel** page button, you can set the **Max Level**, **Max bBER** or **Max Vision/Snd2 Threshold**.

- Via the **Extra Settings Panel** page button, the **Target Audio Mismatch** or **Target Max Black Screen Size** can be configured.

- You can get the measure once with the **Get Measure** button or use the **Measure Config** page button to automate the process.

  This opens a subpage where you can specify the **Measure Mode** and disable/enable the **Automatic Measure**. If the **Measure Mode** is set to *Continous*, the measure is done with an interval of 1 second. If it is set to *Streaming*, the measure is done, after a delay of 1 second, streaming is started and then stopped, the process is paused during 3 seconds, the measure is done again, and so on.

In the **Measure Panel** section, parameters such as the **Measure Level**, **Measure Video Modulation** and **Radio Modulation** are displayed.

The **Streaming Status** parameter at the bottom of the page allows you to stop/start the streaming.

### Logger Status

When the **Status** is set to *Round Robin* (on the Measure page), this page displays information in the **Round Robin Table** . As the logger results are only coherent when the **Version** number is higher than or equal to *3*, the table is only filled in in that case.

If the device is in *Round Robin Cycle* mode, you can interrupt the process to make a direct measurement by setting **Lock RR** to locked. After 5 minutes, the device will return to *Round Robin Cycle*.

### RF Matrix

On this page, you can edit the **Matrix Port**.

### Round Robin Thresholds

This page contains the Round Robin Thresholds for Analog-TV (**RR Min Level**, **RR Max Level**, **Max Vision/Snd2**, ...), Radio FM (**Min Level (Radio FM)**, **Max Level (Radio FM)**), DVB-C QAM64-A (**Minimum Noise Margin (QAM64-A)**, ...), DVB-C QAM128-A (**Max bBER (QAM128-A)**, and DVB-C QAM256-A (**Max aBER (QAM256-A)**.

### Round Robin Plan

On this page, you can define the **Number of Programs** and, for each program, set the **Channel Mode**, **Type**, **Channel**, **Frequency**, **RF Matrix**, **Master Channel**, **Audio Frequency**, ...

### Firmware Upgrade

On this page, you can perform a firmware upgrade. To do so, you first need to set the complete path to the new firmware file in the **Firmware Path** parameter. Then click the **Upgrade** button to start the upgrade process. During the upgrade, normal polling is stopped, as the device enters into *BOOT* mode.

The **Upgrade Step** parameter indicates the stage of the current upgrade. The steps are:

1. **GO TO BOOT**: The device is set to BOOT mode.
1. **ERASE FLASH**: The flash memory is erased. (The **Erasing Flash** parameter shows the progress.)
1. **FIRMWARE SEND**: The firmware is sent, divided over pages of 64 KB (The total number of pages is displayed by the **Total Pages** parameter and the **Firmware Upload** parameter shows the upload progress.)
1. **TURN OFF METER**: The device is restarted, so that it can go back to normal mode and polling is automatically reactivated.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
