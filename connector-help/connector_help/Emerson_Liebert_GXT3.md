---
uid: Connector_help_Emerson_Liebert_GXT3
---

# Emerson Liebert GXT3

This connector can be used to monitor UPS platforms by Emerson Liebert in the GXT3 range.

## About

The connector displays information about the battery, the input, and the output of the UPS (Uninterruptable Power Supply). A condition and alarms table are also available, amongst others, as well as the possibility to start tests and see the last test result.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device and receiving traps, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Device Configuration

It is possible that some settings need to be configured on the device before the element will be able to set up the connection and start polling the data. The steps below briefly explain how to proceed if polling does not start automatically:

1. Open the web interface and select the tab *Configuration.*

1. Select the folder **SNMP** in the left section of the web interface.

1. Enable all check boxes on this page and set the *Heartbeat Trap Interval* to 1 minute.

   Note: you may need to click an *Edit* button first, before you will be able to change any settings.

   Note: you may be prompted to enter administrator credentials to proceed.

   Click *Save* when finished. The device may notify you that a restart is required to apply the changes, however, ignore the restart for now.

1. In the left section of the web interface, select the folder **V1 Access** below the **SNMP** folder.

1. Add 2 entries in the table: one with read access, the other with write access. Use *0.0.0.0* as the network name for both entries.

   Click *Save* when finished. The device may notify you that a restart is required to apply the changes, however, ignore the restart for now.

1. In the left section of the web interface, just below **V1 Access**, select the folder **V1 Traps**. Click *Save* when finished.

1. Add a trap entry, and specify the IP of the DMA hosting the element. To be safe, you can also add one entry for each DMA in the cluster.

   Note: use the same *Community* as specified in the V1 Access table.

   Note: also enable the *Heartbeat* for this entry.

   Note: the default port *162* should be correct.

   Click *Save* when finished. The device may notify you that a restart is required to apply the changes.

1. If the device displayed a pop-up message to notify you that a restart is required for the changes to take effect:

   1. Click the **Restart** folder in the left section of the web interface.
   1. Click the *Restart* button on this new page.

      Note: this should only restart the SNMP module and not the full device.

## Usage

Below, you can find more information about all the pages in the connector, followed by information about the pop-up pages.

### General

This page contains a quick overview of the device status. Several parameters can also be found on another page in the connector, sometimes accompanied by an extra write control. The latter are not mentioned here for the sake of conciseness.

The main groups of parameters are:

- **Device Info** parameters, such as:

  - **Manufacturer**
  - **Model**
  - **Software Version** and **Agent Version**
  - **System Up Time**
  - ...

- **Module Status** parameters, such as:

  - **Inverter Ready**
  - **Battery Charger**
  - **Automatic Battery Test**
  - ...

- **Battery** parameters, such as:

  - **Estimated Minutes Remaining**
  - **Estimated Charge Remaining**
  - **Battery Status**
  - ...

- **Input** and **Output** parameters, such as:

  - **Voltage**
  - **Current**
  - **Frequency**
  - **Source**
  - ...

There are also a few buttons to open pop-up pages such as:

- **Reboot**, which displays the reboot status.
- **Shutdown Cause**, which displays the parameters used to set the **Last Shutdown Cause**.
- **Tests**, which allows you to start a new test or to see the last battery test results.

Finally, there is also a button to reset the statistics. These statistics include max/min voltage, brown-out counters, bad input counters, etc.

Note:

- **System Up Time** is not polled, instead it is set by the heartbeat trap. This can be used to verify if traps are configured correctly.

- The **Last Shutdown Cause** parameter is calculated by the connector, based on the values of the parameters behind the **Shutdown Cause** page button.

  In short, the last shutdown cause will be the last parameter set to *Yes*. These parameters are also saved, but as long as all parameters are *No*, the cause will be *Unknown*.

  Note that it is possible that this cause is not correct. If for instance the device was rebooted when it was not monitored, and the shutdown parameters were reset again by the time the element was started, then the device will not be aware of this shutdown. Also, if for some reason multiple parameters are set to *Yes*, the summary could be wrong, because it will take the last received parameter, which is defined by polling order.

### Alarms

This page contains an **Alarm** **Table** and an **Alarms Present** parameter displaying the number of currently active alarms.

After the first startup, the alarm table is populated with all "well-known" alarms. This is a list of general alarms which should be implemented on all GXT3 devices.
Some devices could generate some extra alarms depending on the installed configuration and firmware.

The available columns in the connector are:

- **Alarm ID:** This is a 'hidden' column. It is the first column in the table and can be made visible by positioning the mouse pointer in the top left corner of the table and, when the cursor changes, dragging the columns to the right. The content of this column is a unique ID for the alarm. In fact it is the OID (Object IDentifier) of a node in the MIB of the device. The description of that node is the description of the alarm.

- **Alarm Description:** This column should contain a unique and user-friendly description of the alarm. For well-known alarms, this will be set after startup (though it can be overridden), but for custom alarms, this will be the OID of the node in the MIB. Because this OID is very difficult to understand, it is possible to change the alarm description to make it more user-friendly.

  Note that the row (and therefore the alarm description) will not be removed when the alarm is cleared. Instead the **Alarm Status** column will just change to *OK*.

- **Alarm Status:** This column indicates whether the alarm is currently active. (Active = *Alarm*, not active = *Ok*). The benefit of not removing the alarms is that, when using trending, it becomes easy to check when a certain alarm has occurred in the past.

- **Alarm Time:** This column contains the value of the **System Up Time** parameter when the alarm occurred.

### Conditions

This page contains the **Conditions** table and a page button displaying a list of known conditions and their associated description.

Conditions are in a way very similar to alarms. They can be active or not. There are however a lot more predefined conditions (equivalent to "well-known").
Because of this, instead of listing all possible conditions, the table only displays currently active conditions.

Because it is possible that "unknown" conditions occur, depending on the firmware of the device, an extra table is added to map the alarm IDs (OIDs) to alarm descriptions. You can find this mapping by clicking the **Descriptions** button above the table. The pop-up page will show a **Condition Name Dictionary**, containing all well-known conditions and all OIDs of unknown conditions that have occurred since the element was created. The naming of the alarms in the Alarm Console should be the description next to the OID in the **Condition Name Dictionary**. (By default, for not well-known conditions, this will be the OID of the condition.)

Available columns are:

- **Condition Description:** Contains the well-known condition. This is not editable. In case of a not well-known condition, this column will contain the OID of the condition.
- **Condition Time:** Contains the value of the **System Up Time** parameter when the condition was met.
- **Condition Type:** *Warning*, *Alarm*, *Fault*, or *Not Specified.*
- **Condition Current State:** *Active* or *Inactive*.

  Note: Some conditions need to be acknowledged first before they are removed from the table. So even though normally rows are automatically removed and therefore never have the value *Inactive*, some entries could remain and have this value if they still need to be acknowledged. Note also that acknowledging a condition will not remove the condition if the current state is still active.

- **Condition Severity:** *Not Applicable*, *Minor*, *Major*, or *Critical.*
- **Condition Acknowledged:** Indicates whether the condition was acknowledged by an operator.
- **Condition Ack Req.:** Indicates if acknowledgement is required before the entry will be removed.

### Battery

This page contains all battery-related status parameters, except some test-related parameters.

Available parameters are: all battery-related parameters from the general page, as well as:

- **Nominal Capacity**
- **Battery Charge Status**
- **Battery Voltage** and **Expected Battery Voltage**
- ...

### Configuration

This page contains parameters related to the configuration of the device.
Note that not all devices support sets on these parameters. (Some have hard-coded values.)

Available parameters are:

- **Expected Input Voltage**
- **Expected Input Frequency**
- **Configured Output Voltage**
- **Configured Output Frequency**
- **Output VA** \[Read Only\]
- **Configured Output Low Battery Time**
- **Audible Alarm**

Note: Muting the **Audible Alarm** will temporarily silence the alarm. At the point where the alarm would normally stop sounding, it will revert to *Enabled*.

### Monitor

Contains measurement and status parameters related to input, output and bypass.
Several of these parameters are also available on the **General** page.

Some additional parameters include:

- **Bypass Frequency**, **Voltage** and **Current**
- **Output Max** and **Min Volts**
- **Input Max** and **Min Volts**
- **...**

### Web Interface

This page will display the web interface of the device.

Note: The client machine has to be able to access the device. If not, it will not be possible to open the web interface.

### Pop-up: Reboot

Accessible from the **General** page.

This page contains parameters to (re)boot the UPS, and makes it possible to define how a shutdown should be done (**Shutdown Type** *Output* or *System*.) It is also possible to start/stop the device after a specified time, to reboot the system with a specified delay and to cancel countdown timers.

### Pop-up: Shutdown Cause

Accessible from the **General** page.

This page contains parameters indicating what the cause was of the last shutdown. There is one parameter, **Last Shutdown Cause**, which is calculated by the connector using a best-effort mechanism. For more information, see the section about the General page above.

### Pop-up: Tests

Accessible from the **General** page.

This page contains parameters related to the battery test. To start a test, simply select one in the parameter **Test**. (Note: not all devices support all the tests listed in the drop-down choices.)

Other available parameters are:

- **Automatic Battery Test**
- **Test Spin Lock**
- **Test Results Summary**
- **Test Results Detail**
- **Test Start Time** (This is the value of **System Up Time** at the time when the test began.)
- **Test Elapsed Time**

### Pop-up: Descriptions

Accessible from the **Conditions** page.

This page contains a single table, mapping all known condition IDs (OIDs) to a user-editable name.

After startup, all well-known conditions are listed with a default name. It is possible to override this name.

When other conditions are met that are not "well-known", extra records will be added. The descriptions linked to these OIDs will be used as the alarm name in the Alarm Console.

You can filter on the alarm names in alarm templates.

The default description for not "well-known" conditions is the OID. The meaning of that OID can be found in the MIB of the device being monitored.
