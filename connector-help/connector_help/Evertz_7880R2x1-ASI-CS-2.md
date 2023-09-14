---
uid: Connector_help_Evertz_7880R2x1-ASI-CS-2
---

# Evertz 7880R2x1-ASI-CS-2

The **7880R2x1-ASI-CS-2** is a complete hardware-based solution for MPEG-2 feed redundancy switching. By providing automatic smart switching of the main signal to a backup signal, this solution offers protection to digital compressed signals. Controlled by the industry leading VistaLINKR PRO, it offers signal providers the capability to design automatic redundancy into their system and warn the operator the second a problem arises. By constantly monitoring the incoming signals, it detects when the signals reach a point where they are no longer suitable for broadcasting and automatically switches to a backup feed. All monitored and switching rules can be customized to meet broadcast, cable, satellite and IPTV needs.

## About

This **SNMP** connector is used to monitor and configure the **Evertz 7880R2x1-ASi-CS-2** redundancy controller.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Version 1.1.0 Build 4860    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **Card Type** and **CPLD Version**.

For users who have at least security level 2, the page also contains a **Reset Card** button.

### Inputs

This page contains the **Input**, **Error Monitor** and **Input Control** tables:

- The **Input** table contains the following columns:

- **Input**: The index that is used to index several tables in this MIB. There are only 4 inputs (input stream 1 to 4) for the card with Card Type 7X80R2x1-ASI-CS-2.
  - **Input State**: Displays whether the card is receiving the stream on the input (*Active*) or not (*Inactive*).
  - **Number of Programs**: Displays the number of programs detected in the input stream.
  - **Number of Known PIDs**: Displays the number of known PIDs detected in the input stream.
  - **Input Bit Rate**: Displays the average bit rate for the input stream (with the units bits/sec).
  - **Transport Stream ID**: Displays the transport stream ID that is being read from the PAT Table.
  - **Network ID**: Displays the network ID read from the transport stream.
  - **Network Name**: Displays the network name read from the transport stream.

- The **Error Monitor** table contains the following columns:

- **Input Status**: Displays the status of the input (*OK* or *Critical*).
  - **Syntax Error Status**: Displays the status of syntax errors (*None*, *Warning*, *Minor*, *Major* or *Critical*).
  - **User Defined Error Status**: Displays the status of the user-defined errors (*No Error* or *Critical Error*).

- The **Input Control** table contains the following columns:

- **Max TS Bit Rate**: Allows you to set the max bit rate for this transport stream. If this setting displays 0, this means it is not configured. Range: 100 to 75,000 kbps.
  - **Min TS Bit Rate**: Allows you to set the minimum bitrate. Range: 100 to 75,000 kbps.
  - **Clear All Stats**: Allows you to clear all the statistics and restart monitoring of the stream.
  - **PID Displayed Mode**: Allows you to specify how the PID numbers should be displayed (*Decimal* or *Hex*).
  - **TSID Displayed Mode**: Allows you to specify how the **Transport Stream ID** should be displayed (*Decimal* or *Hex*).
  - **Expected TSID**: Allows you to set the expected **Transport Stream ID**.
  - **Expected Number of PIDs**: Allows you to set the number of expected PIDs.
  - **Probe Mode**: Allows you to set the mode for the Probe (*ATSC*, *DVB* or *MPEG*).

The page also contains page buttons to the **Windows Measurement**, **Switch Control** and **Monitoring Control** subpages.

The Windows Measurement subpage displays the **Windows Measurement table**, which contains the following columns:

- **Windows Measurement 1**: Allows you to set the window measurement for the table repetition.
  NOTE: Each step is 1 ms, so the maximum range is 100,000 ms = 100 s.
- **Windows Measurement 2**: Allows you to set the window measurement to measure PCRs.
  NOTE: Each step is 1 ms, so the maximum range is 100,000 ms = 100 s.
- **Windows Measurement 3**: Allows you to set the window measurement to measure bitrate.
  NOTE: Each step is 1 s, so the maximum range is 100,000 s.

The Switch Control subpage displays the **Template Switch Control table**, which contains the following columns:

- **TS BR Below Min Thresh Switch Enable**: Allows you to specify whether to switch and how to switch when the TS bitrate is below the minimum threshold.
- **TS BR Above Max Thresh Switch Enable**: Allows you to specify whether to switch and how to switch when the TS bitrate is above the maximum threshold.
- **Any PID BR Below Min Thresh Switch Enable**: Allows you to specify whether to switch and how to switch when the bitrate for any PID is below the minimum threshold.
- **Any PID BR Above Max Thresh Switch Enable**: Allows you to specify whether to switch and how to switch when the bitrate for any PID is above the maximum threshold.
- **TSID Switch Enable**: Allows you to specify whether to switch and how to switch when the TSID read from the transport stream does not match the expected TSID.
- **Number PID Switch Enable**: Allows you to specify whether to switch and how to switch when numPIDs in the TS do not match the expected TSID.

The Monitoring Control subpage displays the following tables:

- The **CCA Monitoring Control table**, which contains the following columns:

- **Start Monitoring**: Responsible for restarting the monitoring of the input. In contrast to "Enable Monitoring", this actually enables the monitoring of the source on the hardware, whereas "Enable Monitoring" simply re-enables the fault reporting mechanism on the hardware. Opposite of "Stop Monitoring".
  - **Stop Monitoring**: Responsible for stopping the monitoring of the input. In contrast to "Disable Monitoring", this actually disables the monitoring of the source on the hardware, whereas "Disable Monitoring" simply disables the fault reporting mechanism on the hardware. Opposite of "Start Monitoring".
  - **Reset Monitoring**: Responsible for resetting the internal monitoring state of the hardware. If this is activated, all monitoring parameters should be reset to the default state and all trapEnable flags for all traps should be set to disabled. This ensures that no traps are sent from the card once monitoring of the card is re-enabled, even if there are faults.
  - **Enable Monitoring**: Re-enables all trap notifications from the hardware.
  - **Disable Monitoring**: Disables all trap notifications from the hardware.
  - **Reset And Enable Monitoring**: Both resets and enables monitoring, as described above.
  - **Trap Tag**: Allows you to set an alphanumeric tag to a given input, which will be assigned to the traps. This is encoded as an octet string using the UTF-8 character encoding scheme. The maximum length of the octet string is 256 characters.
  - **Traps Notify**: Displays the current state of the traps Notify. Possible values are *Enabled* (when traps are sent) or *Disabled* (when traps are blocked from being sent). Its state is set through the Enable Monitoring (to enable) and Disable Monitoring (to disable) functionality.

- The **DPI Monitoring Control table**, which contains the following columns:

- **Enable DPI Monitoring**: Allows you to enable or disable DPI monitoring on the input.
  - **DPI Inactivity Timeout**: The inactivity timeout for DPI monitoring, in minutes. The high bound is 24 hours (1440 minutes).

### Error Monitor

This page contains tables that monitor the three types of priority errors: the **Priority 1 Error Monitor Table**, **Priority 2 Error Monitor Table** and **Priority 3 Error Monitor Table**, with the following parameters:

- **Fault Name**: The index that is used to index different tables in this MIB.

> NOTE:
>
> - The following indexes are for priority 1 errors: tsSyncLoss, sycByteError, patError, continuityCountError, pmtError and pidError. These are valid in all modes (DVB, ATSC, MPEG2).
> - The following indexes are for priority 2 errors: transportError, crcError, pcrRepetitionError, pcrAccuracyError, ptsError and catError. These are valid in all modes (DVB, ATSC, MPEG2).
> - unreferencedPID is a priority 3 error and is valid for DVB and ATSC, MPEG2 mode.
> - The following indexes are for priority 3 errors in DVB mode: nitRepetionError, nitError, dvbEITRepetitionError, dvbEITError, rstRepetitionError, rstError, tdtRepetitionError and tdtError.
> - The following indexes are for priority 3 errors in ATSC mode: mgtRepetitionError, tvctRepetitionError, cvctRepetitionError, atscEITRepetitionError, rrtRepetitionError and sttRepetitionError.

- **Monitor Enable**: Allows you to enable or disable the error test for each variable.
- **Average Repetition**: Displays the average repetition of each error over a window.
- **Switch Enable**: Allows you to specify how the switch should be performed when an error condition is true. If set to *Off*, there will be no switching when there is an error. If set to *Splice card*, a clean splice will be attempted; however, if no switch point is found, the card will not switch. If set to *forcedSwitch*, a clean splice will be attempted, and if no switch point is available, the card will try to do a packet splice.
- **Error Persistence**: Displays the number of errors that have occurred so far in this transport stream.
- **Max Rate**: Sets the maximum time interval between the packets. The card will send a trap when a table exceeds the limit.

> NOTE:
>
> - This parameter is not valid for faultNameIndex tsSyncError, syncByte, continuityCount and transporError. For these errors, crcError Card will return a fixed value of 1.
> - The unit for tsSyncError, patError, pmtError, pidError, pcrRepetition, ptsError, catError, nitRepetition, unreferencedPID, sdtRepetition, eitRepetition, rstRepetition and tdtRepetition is ms.
> - The unit for pcrAccuracy is ns.

- **Error Severity**: Allows you to set the severity for each error (*Warning*, *Minor*, *Major* or *Critical*).
- **Max Read Time**: Displays the maximum read time for each error.
- **Switch Threshold**: Sets the maximum time/errors after which the card will switch the input that is routed to output.

> NOTE:
>
> - The unit for syncByte, continuityCount, transportError, crcError, nitError, sdtError, dvbEITError, rstError and tdtError is errors/sec
> - The unit for tsSyncError, patError, pmtError, pidError, pcrRepetition, ptsError, catError, nitRepetition, unreferencedPID, sdtRepetition, eitRepetition, rstRepetition and tdtRepetition is ms.
> - The unit for pcrAccuracy is ns.

The page also contains the **Misc Control Table**, which can be used to clear the priority errors, both by priority and by input stream.

### PIDs

This page contains the **PID Monitor table**, with the following parameters:

- **PID**: Index for PIDs, ranging from 1 to 250.
- **Program Number**: Displays the actual program number that the PID is associated with.
- **Program Name**: Displays the program name that the PID is associated with.
- **Actual PID Number**: Displays the actual PID number.
  NOTE: Even though this parameter is indexed by PID number, the index should be limited to the value returned by the **numOfKnownPIDs** parameter.
- **PID Type**: Displays the type of the PID (PAT, PMT, NIT, EIT, etc.).
  NOTE: Even though this parameter is indexed by PID number, the index should be limited to the value returned by the **numOfKnownPIDs** parameter.
- **PID Table Version**: Displays the version number of the table. Will only return the version for appropriate PIDs, e.g. PMT, PAT or CAT.
- **PID Info**: Displays the specific information about the PID, e.g. video resolution, frame rate, etc.
- **Bit Rate**: Displays the bitrate for this PID.
  NOTE: Even though this parameter is indexed by PID number, the index should be limited to the value returned by **numOfKnownPIDs** parameter.
- **Min Bit Rate**: Displays the minimum detected bitrate for this PID.
- **Max Bit Rate**: Displays the maximum detected bitrate for this PID.
- **Min Bit Rate Threshold**: Allows you to set the minimum bitrate for a PID. If the bitrate for a PID is below this threshold, the card will send a trap.
- **Max Bit Rate Threshold**: Allows you to set the maximum bitrate for a PID. If the bitrate for a PID is below this threshold, the card will send a trap.
- **Bit Rate Limit Exceeded**: The limit status (*In Limit*, *Limit Over* or *Limit Under*).

Via the **Template Control** page button, you can access the following tables:

- The **PID Template Control table**, which contains the following columns:

- **Template PID**: Index for template PIDs, ranging from 1 to 100.
  - **Expected PID Number**: Allows you to specify the PID number for the PID template check.
    NOTE: When the card returns a value of "8192", this means that the PID is currently not set and will not be used for the template check.
  - **Windows Measurement Select**: Allows you to set the type of timeout to be used for the PID template check (*Disabled*, *Window Measurement 1*, *Window Measurement 2* or *Window Measurement 3*). The window measurements specify the amount of time to wait before triggering the pidTemplate fault.
  - **PID Present**: Shows whether the selected PID (in the PID template) is present (*Disabled*, *Not Present* or *Present*).
    NOTE: The card will return a value of "disabled" when Expected PID Number is set to *8192*, the Window Measurement Select is set to *Disabled*, or PID Template Enable is *Disabled*.
  - **Switch Enable**: Allows you to set how the switch will be performed when a PID template error condition is true. If set to *Disabled*, there will be no switching when there is an error. If set to *Splice*, the card will try to perform a clean splice, but if no switch point is found, the card will not switch. If set to *Forced Switch*, the card will try to do a clean splice, and if no switch point is available, the card will try to do a packet splice.

- The **Misc PID Template Control table**, which contains the following columns:

- **Take Snapshot** button: Allows you to capture the PIDs that are present on the input. The card will only take a snapshot if there is an input present.
    NOTE: This control will always return "cancel" when a get is performed on this parameter.
  - **PID Template Enable**: Allows you to disable or enable the PID template check on the card.
  - **Reset** button: Allows you to reset all the controls of the PID template to default values.

### Outputs

This page contains the **Output Control Table**, with the following parameters:

- **Output Index**: The SNMP instance of the table. It only has one output.
- **Destination IP Address**: Allows you to set the destination IP address where the selected stream will be sent.
- **Destination Port Number**: Allows you to set the destination port number where the selected stream will be sent.
- **Input Select**: Allows you to select which input will be sent to the output (*Disabled*, *Input 1*, *Input 2*, *Input 3* or *Input 4*).

### Redundancy Switch

This page contains the **Clean Switches table**, with the following parameters:

- **Clean Switch Index**: The SNMP instance of the table. This parameter is the index that is used to index Clean Switch Controls in the MIB.
  NOTE: 7X80R2x1-ASI-CS-2 has two clean switches.

- **Switch Mode**: Allows you to specify how the switch should behave when switching between the streams. The following settings are possible:

- *fullAuto*: The switch operates fully automatically. It will switch on detecting faults whenever there is a clean switch point, and in case of packet switch faults, it may switch on packet boundaries. The switch knows the input 1 as its main input, and will go back to input 1 when the faults on input 1 are equal to or better than the faults on input 2. No user switching is permitted in this mode.
  - *autoManualReturn*: The switch operates semi-automatically. It knows the input 1 as the main input, and switches to input 2 whenever input 1 is in a worse state than input 2 in terms of the switch parameters defined by the user. After switching to input 2, it does not switch back unless the user manually switches it back to input 1. Switching back will be clean, and will be done on clean switch points, unless the user set the control to manual.
  - *manual*: No automatic switching will be performed, although the switching will be performed on switch points and whenever possible, unless the user selected the method to be packet switching, in which case it will switch on packet boundaries.

- **Switch Output**: Allows you to select which input will be routed to the output. This control is only available in Manual mode and in Auto-Manual return mode.
  NOTE: This parameter may not take effect immediately.

- **Stream Delay Info**: Displays the exact delay between the two streams. Used in conjunction with stream delay. This parameter is only available when the switch method is *packetMatching*.

- **Delayed Stream Info**: Displays which stream is delayed. Used in conjunction with stream delay. This parameter is only available when the switch Method is *packetMatching*.
  NOTE: When the Stream Delay Info is 0, this has no meaning.

- **Switch Method**: Sets the mode of the switching depending on the type of the input streams. The following settings are possible:

- *packetMatching*: The switch looks for similar packets in both streams and performs the switching on those packets. This way the switch will always be totally clean and seamless. If input streams are identical, this setting should be used
  - *gopBoundary*: The switch will be performed on the start of the GOP packets. The switch will be clean visually and MPEG-wise. The selection of which GOP to switch to is based on the nearest GOP. If input streams are similar, this setting should be used.
  - *packetSwitch*: In this mode, there is no matching to find any specific switch points. The switch happens whenever switching is needed. If there is no similarity between the input streams, this setting should be used.

> NOTE: Changing this parameter while the switch is operating may result in the switch being reset. If the parameter is switched to *packetSwitch* and then back to *gopBoundary* or *packetMatching*, the switch will be reset.

- **GOP Repeat Mode**: Allows you to enable or disable the GOP repeat mode. The GOP repeat mode will be sent out during the input loss, or when the switch needs to switch on packet switch to allow the output to be visually clean.
- **Reset Switch**: Allows you to reset the switch state.

> NOTE:
>
> - The card will always return "cancel".
> - You should use this parameter to reset the switch whenever the **Switch Method** or **Switch Mode** parameters are changed.
> - CAUTION: When the switch is reset, the output will temporarily drop due to the switch resynchronizing process.

- **Switch Status**: Displays the current status of the switch. This can be useful to identify any problems or warnings that the switch may have.
- **Output Status**: Displays what is going out on the output. The string contains a descriptive statement about the source of the stream that is currently on the outputs.
- **PCR Tolerance**: Allows you to set the PCR tolerance in packet matching mode. This parameter is used to switch between identical streams, in case one or both of the streams ran through a PCR restamper device, such as a multiplexer. The PCR tolerance is the allowable tolerance between two identical PCRs in the stream. If these restamping devices are synchronized so that the identical PCRs are less than 20,000 PCR ticks away, this parameter is useful, otherwise the streams cannot be treated as identical and placed in packet matching mode.
- **Stream Type**: Allows you to set the type of stream to *Multi-Program Transport* *Stream* or *Single Program Transport Stream*. It is necessary to set this parameter on startup.
- **Switch Back Wait**: Allows you to set the time (in seconds) that the switch should wait before it automatically switches back to the main feed. The main feed should be valid during this wait time. If 0 is selected, the switch will not go back to the main feed until the backup feed becomes invalid.
- **Switch Minimum Delay**: Allows you to set the minimum delay (in milliseconds) between the input and output. The delay determines the size of buffers of the switch to store the packets.
- **Switch Current Delay**: Displays the current approximate delay of the packets (in milliseconds).
- **Output ASI Mode**: Allows you to set the type of ASI output (*ASI Packet Mode* or *ASI Byte Mode*).
- **Switch Low Delay**: Allows you to run the switch in zero-delay mode, not clean switching, In this mode, the switch will only operate in packet switching mode and the GOP repeat mode is disabled.
- **Output On Initialization**: Allows you to set the output when initializing control. This parameter will control the output of the clean switch when it is initializing. During the initialization, the output will be set to Ultra Low Delay Mode output.

> NOTE: This control should be disabled if the Switch Method is not in packet matching mode.

- **Seconds Before PM**: Allows you to set the amount of time that switch has to wait to make sure that the incoming streams are identical in order to switch to packet matching mode. This control only works when the switch is in packet matching mode and the Output On Initialization is enabled.

> NOTE:
>
> - This control should be disabled if the **Switch Method** is not in packet matching mode.
> - This control should be disabled if the **Output On Initialization** is disabled.

- **Switch Delay Trap Lower Limit**: Allows you to set the lower bound on the switch delay trap. When the delay through the switch falls below this limit, a trap is sent.
- **Switch Delay Trap Upper Limit**: Allows you to set the upper bound on the switch delay trap. When the delay through the switch goes above this limit, a trap is sent.
- **Output Smoothing**: Allows you to specify whether the output of the switch should smooth out the transmission on output packets. Helps avoid PCR jitter errors for certain equipment before the switch.

Via the **Auto Reset** page button, you can access the **Auto Reset Criteria Table**, with the following parameters

- **Auto Reset PMT Version**: Enables or disables the automatic resetting of the clean switch based on PMT version change.
- **Auto Reset TSID**: Enables or disables the automatic resetting of the clean switch based on TSID change.
- **Auto Reset Bit Rate**: Enables or disables the automatic resetting of the clean switch based on bitrate changes in the input.

### Traps

This page contains the tables **Mgmt Fault Table**, **Trigger Fault Table**, **Switch Fault Table**, **DPI Fault Table** and **Delay** **Fault Table**. All these tables show the **Status** (*OK* or *Fail*) of each fault and allow you to determine whether a trap should be sent (by setting **Send Trap** to *Enabled* or *Disabled*).

It also contains the **Trap Destination Table**, which allows up to five destinations. You can add, edit or clear an address by means of the context menu. Right-click in any row of the table to add a new address, or right-click a selected row to edit or clear an address.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS
20/08/2018 1.0.0.1 RBL, Skyline Initial version
