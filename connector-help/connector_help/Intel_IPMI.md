---
uid: Connector_help_Intel_IPMI
---

# Intel IPMI

The IPMI (Intelligent Platform Management Interface) standard is used to manage computer hardware in a vendor-independent way. The standard allows remote interrogation of a system, sometimes even when the target is not powered on. This can be used to identify FRUs (Field Replaceable Units), see the event log, and get sensor values like ambient temperature, CPU temperatures, fan speeds, etc.

## About

The connector can be used to display all available sensor values, to monitor fan speeds, temperatures, power, voltage and current sensors, and to view the event log, user list and list of FRUs.
To do this, the protocol uses a third party tool (IPMItool, which can be found on <http://sourceforge.net/projects/ipmitool/>). As a consequence, no communication will be visible in Stream Viewer.

## Installation and configuration

### Creation

This connector uses the IPMItool to connect with the device and requires the following input during element creation:

**CUSTOM CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (required). By default *623.*

### Configuration

For the configuration of this connector, you first need to install the IPMItool.
For this, 5 DLLs have to be made available on your system:

- cygcrypto-1.0.0.dll
- cyggcc_s-1.dll
- cygwin1.dll
- cygz.dll
- ipmitool.exe

When you have made sure these are available, the path to the executable ("ipmitool.exe") has to be configured in the connector:

1. Open the element and go to the **General** page.

1. In the second column, in the section **Internal Driver Parameters**, below **Configuration**, click the button **More Settings ...**

   A new popup window, **Settings**, will appear.

1. In the **General** section, set the full path, including the file name, in the parameter **IPMI Path**.

   Example: *C:\IPMI\ipmitool.exe*

Finally, also configure the user name and password:

1. Open the element and go to the **General** page.

1. In the second column, in the section **Internal Driver Parameters**, below **Configuration**, click the button **More Settings ...**

   A new popup window, **Settings**, will appear.

1. In the **Credentials** section, set the **User Name** and **IPMI Password**

   Note: the **IPMI Password** has no associated 'read' control, so it is not possible to see if the password has already been configured.

At this point, the connector should be able to connect with the target device and start retrieving data.
If this is not the case, continue with the following steps:

1. Restart the connector.

1. Go to the **General** page, click the **More Settings ...** button, and go to the section **Connection**.

1. Depending on the current interface type, change the interface type either from *Lan* to *Lan+* or from *Lan+* to *Lan*, and restart the connector.

1. In the same section of the **Settings** window, disable **Use Caching** if this is enabled.

1. Open the element log file and verify if any errors have been logged.

   This will typically be at the end of the file, so it is advised to start looking there.

1. Contact Skyline Communications (your TAM or <techsupport@skyline.be>).

## Usage

### General

On this overview page, you can turn the device *On* or *Off* using the buttons next to **System**. They will always ask for confirmation.

On the left side, there are some general status indicators such as: **System Power**, **Power on Hours** and **Last Restart Cause**.

There are also four page buttons: **Users**, **SEL Info**, **BMC Info**, and **SDR Info**. These provide access to pages with a mix of polled data and 'static' data.
Trending and alarm monitoring are not possible on the 'static' data. This data will only be retrieved from the device after one of these buttons are clicked, at which point all the data on these pages will be updated. However, note that it could take some time before the update is complete, so do not close the pages too quickly.

This page also contains a section **Internal Driver Parameters**. This contains parameters that do not come from the device, but instead display settings, configuration and status info about the connector and its behavior.

The first part, **Statistics**, contains regularly updated data about the internal command stacks. These are updated every 10 seconds.

- **Manager - Waiting Commands**: Indicates how many commands are waiting to be executed (at the time of the update).

- **Manager - Executing Commands**: Indicates how many commands are currently being executed (at the time of the update).

  The maximum value of this parameter is defined by **Manager - Max Processes**, but will often be less due to limitations by **Manager - Max Background Processes**.

- **Manager - Finished Commands**: Indicates how many commands have finished since the previous update.

  Note that this could be more than the number of commands that was shown in the **Executing Commands** parameter. This is because if several commands take only 2 seconds, they will be started and finished without any indication in the **Waiting** and **Executing** parameters.

The second part contains parameters that configure how many commands can be executed at the same time. The first parameter, **Sessions - Slot Count**, is retrieved from the device after startup and defines the maximum number of concurrent requests that the device supports. As such, the **Max Processes** may never exceed this value. However, it is recommended to take a smaller number of actual **Max Processes**, because these sessions are also shared with other users (for example on the command line) or other elements (for example when double polling.) It is best to take **Slot Count** - *4* as value for a production element*.* This allows for a second (duplicate) element on a staging server using 2 or 3 connections, and for users using the command line or any other tool.

The last parameter, **Manager - Max Background Processes**, indicates how many connections are reserved for normal polling purposes. It is advisable to take at least one less than the **Max Processes**, and it is not possible to have more than the **Max Processes**. If you use less than the maximum number, the element will seem more responsive, for example when you click one of the page buttons. This is because at that time a 'foreground' command will be sent to the device to update some parameters which will (normally) not need to wait for all background processes. However, note that more background processes allow for faster startup of elements (before all data is available) and during startup it is also possible that the extra 'free' foreground processes are not used by the system, even after you click one of the page buttons (because of complex processing rules where some commands can require 'serial' behavior or that no other commands be executed at the same time).

Final note: Keep in mind that these are actual processes. If there are for instance just 10 background processes, this won't be a problem. But if there's a large number of elements managed by one server, it could be necessary to lower the number of processes to 1 or 2 per element, in order to ensure the general performance of the DMA does not suffer.

### Sensors

On this page you can see the current value, type, units and status of all sensors in the system. However, trending and alarm monitoring are not possible on these values, because the type of sensor reading is not known and not the same for all sensors (E.g.: string, number, discreet).

Reading the sensor values happens in two stages. In the first stage, all sensor IDs and values are retrieved and set in the table. In a second stage, the extra information is retrieved sensor by sensor. This step is considerable slower than the first step, and it is the last step in the standard poll cycle.

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

Note: Parameters of type **Temperature, Fan, Power Unit, Voltage & Current** are forwarded to separate tables, allowing for trending and alarm monitoring. Note that in these tables, units are hard configured and not compared to the actual units reported by the device. So it may be possible that a temperature measured as *85 degrees* *Fahrenheit* is displayed as *85 øC*.

### System Event Log

This page contains one table with all logged system events. There is also a page button, **SEL Info**, containing more detailed information about the log, such as the **Version**, **Entries** and **Free Space**. These details will be updated (front channel) whenever you click the page button, though the update can take a few seconds. There is also a button, **Refresh SEL**, that will schedule an update of the event log table.

### Field Replaceable Units

This page contains two major parts. At the top, the **FRU** table displays all available units and some columns containing the more generic fields of such records, such as **Manufacturer**, **Name**, **Version** and **Serial Nr**. The last column contains a button that, when clicked, will copy the details of this FRU to the parameter **FRU Detailed Info** below the table.

The parameter **FRU Detailed Info** is the second major part of the page. As the available fields and details in the table above are very vendor- and even device- or FRU-specific, this way of displaying the detailed info was deemed more practical than to create columns for each possible info field.

### Cooling

This page contains several tables, each displaying a subset of the sensor values on the **Sensors** page. For more information, refer to the **Sensors** section above.
(Tables: **Fan** and **Temperatures**. units are fixed to respectively *RPM* and *degrees Celsius* )

### Power

This page contains several tables, each displaying a subset of the sensor values on the **Sensors** page. For more information, refer to the **Sensors** section above.
(Tables: **Power**, **Voltages** and **Current**, units are fixed to respectively *Watt*, *Volts*, and *Ampere* )

### Web Access

Not all devices will provide web access. This page will try to navigate to *http://\[pollingip\]/* .

Note: The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
