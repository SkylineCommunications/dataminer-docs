---
uid: Connector_help_T-VIPS_CP560
---

# T-VIPS CP560

The **T-VIPS CP560** is a DVB-T2 Gateway. It provides a central point of control for DVB-T2 and T2Lite networks. The CP560 encapsulates the transport stream into the DVB-T2 Modulator Interface. The T2-MI also controls the modulator parameters and provides the accurate timing and rate control required in a Single Frequency Network (SFN). The CP560 provides flexible interfacing with ASI or IP inputs, as well as T2-MI outputs over ASI and IP. It encapsulates MPEG Transport Streams in Physical Layer Pipe (single and multi-PLP).

## About

With this connector, you can monitor and configure the T-VIPS CP560 device, using an SNMP connection.

## Installation and configuration

### Creation

This connector uses an SNMP connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The port of the connected device, by default *161*.

## Usage

### General Information pages

The following pages display general information about the device:

- **General:** This page contains general information about the device, such as the **Product Name, Device Name, Serial Number, Temperature**, etc. You can also perform a delayed reset on the device here.
- **Alarm Log:** This page contains all the information related to the event history of the device.
- **Alarms:** This page contains all the information about the current alarms present on the device.
- **Port Mappings:** On this page, you can configure the device's ports as input/output, and configure the format of the output data.

### Input Related pages

The following pages display information related to the input:

- **Tree View:** This page displays a cascading tree view with the inputs of the device, its services and the PIDs of these services. You can also configure all parameters here, in the same way as on regular pages.
- **Inputs:** On this page, you can view all information related to the inputs, such as the **Label, Total Bitrate, Effective Bitrate**, etc. You can also configure the ports' **label**, **maximum bitrate** and **status** here.
- **Input Alarms:** On this page, you can view all information related to input-related alarms.
- **Services:** On this page, you can view the services present on each input, with parameters such as the **Service name, Bitrate, Alarm Status, Description**, etc.
- **PIDs:** On this page, you can view all the information on the processes that belong to each service, such as the **Bitrate, Errors, Average Bitrate**, etc.

### Output Related pages

The following pages display information related to the output:

- **Outputs:** On this page, you can view all the information on the output ports, such as **Label, Output Bitrate, Output Mode**, etc.
- **DVB T2:** This page displays all the information regarding the DVB T2 output parameters and their configuration, with parameters such as the **Symbols per frame, L1 Guard Interval, L1 Preamble Format, Birate, Frame Duration**, etc. You can also configure the T2 frame related parameters here, as well as the channel frequencies.
- **DVB T2 - SFN:** This page displays all the information regarding the DVB T2 - SFN configuration. It is possible to configure the **Timestamp Type, Leap Seconds** and the **Estimated Transmission Time.**
- **DVB T2 - PLP:** This page displays all the information regarding the DVB T2 - PLP configuration. It is possible to monitor and configure the **Bitrate, PLP Type, Modulation, Code Rate, FEC Type, Payload Type**, etc.
- **DVB T2 - MI:** This page displays all the information regarding the DVB T2 - MI configuration. It is possible to monitor and configure the **PCR interval, PCR Transmit, PMT Transmit, PAT Transmit**, etc.
- **DVB T2 - IA:** This page displays all the information regarding the DVB T2 - Individual Addressing configuration. It is possible to monitor and configure the **MISO Status, Clip Thresholds, Number of Iterations, ACE PAPR**, etc.

### Webpage

This page displays the web interface of the device.
