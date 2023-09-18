---
uid: Connector_help_Supermicro_SMCIPMI
---

# Supermicro SMCIPMI

The Supermicro IPMI (Intelligent Platform Management Interface) standard is used to manage computer hardware in a vendor-independent way. The IPMI standard allows remote interrogation of a system, sometimes even when the target is not powered on. This can be used to identify FRUs (Field Replaceable Units), view the event log and get sensor values such as ambient temperature, CPU temperatures, fan speeds, etc.

## About

This connector integrates the Intel IPMI connector and Supermicro. It is developed to manage and retrieve the data from both types of hard disk with a single connector. The connector can be used to display all available sensor values, to monitor fan speeds, temperatures, power, voltage and current sensors, and to view the event log, the user list, the list of FRUs of Intel and the Supermicro hard disk information.

To do this, the connector uses a third-party tool (i.e. IPMItool, which can be found at <http://sourceforge.net/projects/ipmitool/>). As a consequence, no communication will be visible in Stream Viewer.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

This connector uses the IPMItool to connect with the device and requires the following input during element creation:

**CUSTOM CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (required). By default *623.*

### Configuration

For the configuration of this connector, you first need to install the IPMItool and SMCIPMI tool.
For this, 6 DLLs have to be made available in your system:

- cygcrypto-1.0.0.dll
- cyggcc_s-1.dll
- cygwin1.dll
- cygz.dll
- ipmitool.exe
- smcipmitool.exe

When you have made sure these are available, the path for both device executables ("ipmitool.exe" and "smcipmitool.exe") has to be configured in the connector:

1. Open the element and go to the **General** page.

1. In the second column, in the section **Internal Driver Parameters**, below **Configuration**, click the button **More Settings**.

   The **Settings** window will open.

1. In the **General** section of this window, set the full path for both executables, including the file name, in the parameter **Intel File path** and **SMC** **IPMI File Path** respectively.

   Example: *C:\IPMI\ipmitool.exe,C:\SMCIPMI\SMCIPMITool.exe*

Finally, also configure the user name and password:

1. Open the element and go to the **General** page.

1. In the second column, in the section **Internal Driver Parameters**, below **Configuration**, click the button **More Settings**.

   The **Settings** window will open.

1. In the **Credentials** section of this window, set the **Intel** **User Name**, **Intel Password**, **SMC Username** and **SMC Password** for both devices.

   Note: The **Intel** **IPMI Password and SMC IPMI Password** have no associated "read" control, so it is not possible to see if the password has already been configured.

At this point, the connector should be able to connect with the target device and start retrieving data.

For Intel communication only, if the connector is not able to connect yet, continue with the following steps:

1. Restart the connector.

1. Go to the **General** page, click the **More Settings** button, and go to the section **Connection**.

1. Depending on the current interface type, change the interface type either from *Lan* to *Lan+* or from *Lan+* to *Lan for Intel*, and restart the connector.

1. In the same section of the **Settings** window, disable **Use Caching** if this is enabled for the Intel device.

1. If the problem persists, open the element log file and verify if any errors have been logged.

   This will typically be at the end of the file, so we advise you to start looking there.

1. Contact Skyline Communications (your TAM or <techsupport@skyline.be>).

## Usage

### General

On this overview page, you can turn the device *On* or *Off* using the buttons next to **System**. A confirmation box will be displayed if you do so.

On the left side of the page, there are some general status indicators such as **System Power**, **Power on Hours** and **Last Restart Cause**.

There are also four page buttons: **Users**, **SEL Info**, **BMC Info**, and **SDR Info**. These provide access to pages with a mix of polled data and "static" data.
Trending and alarm monitoring are not possible on the "static" data. This data will only be retrieved from the device after one of these buttons are clicked, at which point all the data on these pages will be updated. However, note that it could take some time before the update is complete, so do not close the pages too quickly.

This page also contains a section **Internal Driver Parameters**. This contains parameters that do not come from the device but instead display settings, configuration info and status info about the connector and its behavior.

The first section, **Statistics**, contains data related to the internal command stacks. This information is updated every 10 seconds.

- **Manager - Waiting Commands**: Indicates how many commands are waiting to be executed (at the time of the update).

- **Manager - Executing Commands**: Indicates how many commands are currently being executed (at the time of the update).

  The maximum value of this parameter is defined by **Manager - Max Processes**, but will often be less because of the **Manager - Max Background** **Processes** limitation.

- **Manager - Finished Commands**: Indicates how many commands have finished since the previous update.

  Note that this could be more than the number of commands that was shown in the **Executing Commands** parameter. This is because if several commands take only 2 seconds, they will be started and finished without any indication in the **Waiting** and **Executing** parameters.

Below this, you can find parameters that configure how many commands can be executed at the same time. The first parameter, **Sessions - Slot Count**, is retrieved from the device after startup and defines the maximum number of concurrent requests that the device supports. As such, the **Max Processes** may never exceed this value. However, it is recommended to take a smaller number of actual **Max Processes**, because these sessions are also shared with other users (for example on the command line) or other elements (for example when double polling.) It is best to take a **Slot Count** of *4* for a production element*.* This allows for a second (duplicate) element on a staging server using 2 or 3 connections, and for users using the command line or any other tool.

The last parameter, **Manager - Max Background Processes**, indicates how many connections are reserved for normal polling purposes. It is advisable to take at least one less than the **Max Processes**, and it is not possible to have more than the **Max Processes**. If you use less than the maximum number, the element will seem more responsive, for example when you click one of the page buttons. This is because at that time, a "foreground" command will be sent to the device to update some parameters that will (normally) not need to wait for all background processes. However, note that more background processes allow for faster startup of elements (before all data is available) and during startup it is also possible that the extra "free" foreground processes are not used by the system, even after you click one of the page buttons (because of complex processing rules where some commands can require "serial" behavior or require that no other commands are executed at the same time).

Note: Keep in mind that these are actual processes. If there are for instance just 10 background processes, this will not be a problem. But if there are a large number of elements managed by one server, it could be necessary to lower the number of processes to 1 or 2 per element, in order to ensure that the general performance of the DMA does not suffer.

### Sensors

On this page, you can see the current value, type, units and status of all sensors in the system. However, trending and alarm monitoring are not possible on these values, because the type of sensor reading is not known and not the same for all sensors (e.g. string, number, discrete).

Reading the sensor values happens in two stages. In the first stage, all sensor IDs and values are retrieved and set in the table. In a second stage, the extra information is retrieved sensor by sensor. This step takes considerably more time than the first step, and it is the last step in the standard polling cycle.

You can refresh the values by clicking the **Values** button, or refresh the values and the extra information using the **Full** button, next to **Refresh Sensors**.

Polling parameters stage 1:

- **SEN ID**
- **SEN Name**
- **SEN Value**
- **SEN Units**
- **SEN Status**
- **SEN Entity** (The entity to which the sensor belongs)

Polling parameters stage 2:

- **SEN Type**
- **SEN Accuracy**
- **SEN LNR** (Lower Non Recoverable threshold)
- **SEN LCR** (Lower Critical threshold)
- **SEN LNC** (Lower Non Critical threshold)
- **SEN UNC** (Upper Non Critical threshold)
- **SEN UCR** (Upper Critical threshold)
- **SEN UNR** (Upper Non Recoverable threshold)
- **SEN Asserted** (Sensor assertion enabled states)
- **SEN Deassertions** (Sensor deassertion states)

Note: Parameters of type **Temperature**, **Fan**, **Power Unit**, **Voltage** and **Current** are forwarded to separate tables, allowing for trending and alarm monitoring. Note that in these tables, units are preconfigured and not compared to the actual units reported by the device. As such, it can occur that a temperature measured as *85 degrees* *Fahrenheit* is displayed as *85 øC*.

### System Event Log

This page contains a table with all logged system events.

There is also a page button, **SEL Info**, which displays more detailed information about the log, such as the **Version**, **Entries** and **Free Space**. These details will be updated (front channel) whenever you click the page button, though the update can take a few seconds.

Finally, there is also a button, **Refresh SEL**, that will schedule an update of the event log table.

### Field Replaceable Units

At the top of this page, the **FRU** table displays all available units and some columns with the more generic fields of such records, such as **Manufacturer**, **Name**, **Version** and **Serial** **Number**. The last column contains a button that, when clicked, will copy the details of this FRU to the parameter **FRU Detailed Info** below the table. As the available fields and details in the table are very vendor- and even device- or FRU-specific, this separate FRU Detailed Info parameter provides a more quick and easy way to view the detailed info.

### Cooling

This page contains the **Fan** and **Temperatures** tables, each displaying a subset of the sensor values on the **Sensors** page (using the units *RPM* and *degrees Celsius*, respectively). For more information, refer to the **Sensors** section above.

### Power

This page contains the **Power**, **Voltages** and **Current** tables, each displaying a subset of the sensor values on the **Sensors** page (using the units *Watt*, *Volts* and *Ampere* respectively). For more information, refer to the **Sensors** section above.

### HDD

This page contains the hard disk information of the Super micro device. This includes the **HDD Map** table, **HDD Information** table, **HDD Logical Map** table and **HDD Logical Information** table.

### Web Access

This page provides access to the web interface of the device by navigating to *http://\[pollingip\]/*. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
