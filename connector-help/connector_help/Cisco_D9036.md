---
uid: Connector_help_Cisco_D9036
---

# Cisco D9036

This connector can be used to monitor devices in the CISCO D9036 device.

## About

This connector polls basic information such as available boards, ports and transport streams. If this is enabled by the user, some other parameters can also be polled.

Before using this protocol, make sure you have read and understand the section "Installation and configuration".

Please note the following:

- This connector was developed for DataMiner Cube, so if you use Element Display instead, not everything may function properly.
- The last major update of the connector was tested using firmware version V01.08.90.
  However, using older firmware versions should not cause any major issues. If data is missing, verify if the problem is solved by upgrading to this version (or newer).
- Consecutive firmware upgrades have always been backward compatible, so upgrading to a more recent version should be no problem.

## Installation & Configuration

### Prerequisites

The connector requires that Visual C++ 2008 (or 2010) Redistributional is installed. To verify this, go to: Control Panel \> Programs and Features.
If this program has not been installed yet, you can download and install it from the following website: <http://www.microsoft.com/en-us/download/details.aspx?id=29>.

### Installing the protocol

Fom version 1.0.0.10 onwards, you can install the connector along with the necessary DLLs by using a "**.dmprotocol**" package, which can be downloaded from the Update Center.

For older versions, however, the installation requires two steps:

1. Install the protocol (.xml file) as usual.
1. Run a "**.dmupgrade**" package containing the extra DLLs by copying it to one of your DMAs and double-clicking it.

   Settings for the upgrade can be ignored: whatever you choose, the DMA will not be restarted and Internet Explorer will not be closed.

### Element Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**

- **IP Address/host:** The polling IP address of the device you wish to poll.
- The other settings, such as Get/Set community string, retries and port number, are ignored by the connector.

### Troubleshooting New Elements

If communication does not work once an element has been created, follow the steps below to get the connection running. For any of the steps after the initial connection test, before you move on to the next step, always perform this first test again to see if the connection works.

Note that the first time an element is created using a protocol on a DMA, it can take a few minutes before all the QActions are compiled. As such, it is advisable to wait at least one minute before you conclude that no data is available.

#### Connection test

To test the connection:

1. Restart the element

1. Open the element card

1. Check on the **Overview** page if there are icons in the tree view.

   - If yes -\> Test succeeded.
   - If no -\> Test failed.

If the test failed, continue with the next step.

#### Verify IP address

To verify the IP address:

1. Go to the **Communication** page and check if the **Management IP Address 1** is correct. Verify if the Port parameters are set to 5003.
1. Optionally, supply the IP address of the second management port. A DCM usually has two management ports, located next to the power supply.

Note: The first IP address is not configurable from data display. To change it, edit the element itself and define a new IP address.

*Test the connection again before you continue.*

#### Verify IIOP Credentials

To verify the IIOP credentials:

1. Go to the webpage of the DCM device and log on as Administrator.
1. Open the page Security and select the tab OS Accounts. A list should appear with available OS accounts.
1. Make a new user account or edit an existing one. It is advisable to use the username *guest* and password *guest* and to make sure the option IIOP is enabled.
1. Go to the element card and click the **IIOP Login ...** button on the **Communication** page.
1. If you have an OS account with the username and password *guest*, you can set the **IIOP Use Credentials** to *No

   Otherwise, set this parameter to *Yes* and fill in the correct username and password.

Notes:

- Not all firmware versions allow the user to change these settings. The default settings are: user name "guest" and password "guest".
- Keep in mind that the password is sent to the DCM in plain text, so a simple wireshark capture can easily reveal the password (by filtering on IP and port 5003 and searching for logon).
- Important: The username and password must be the same for all elements on the same DMA.

*Test the connection again before you continue.*

#### Verify DLLs

The connector requires several DLLs in order to function properly. Check if all files mentioned below are in the correct location in the system.

In the folder "*C:\Skyline DataMiner\Files*":

- omniORB416_vc10_rt.dll
- omnithread34_vc10_rt.dll
- D9036_1.1.0.X.dll

  (Where X can be found in the [DataMiner Catalog](https://catalog.dataminer.services/)

If a file is missing, run the upgrade package again and check the DLLs. If the problem persists, contact Skyline in order to obtain the required DLLs.

#### Verify Network Traffic

The communication with the device uses port 5003. There is a reasonable chance that this port is blocked on a firewall between the DMA and the actual device. To verify this, open wireshark and filter on traffic from/to the IP address of the DCM and port 5003. There should be traffic in both directions. If packets are sent to the DCM, but none return, this indicates a firewall problem. In that case, contact the network administrator and ask to open that port.

*Test the connection again before you continue.*

#### Verify Prerequisites

Verify if the prerequisites are installed: Visual C++ 2008 (or 2010) Redistributional. If not, install them (see "Prerequisites" section above).

#### Verify the log file

If you have tried all the previous steps and there is still no data in the DCM, check the log file. It is possible that the reason for the problem is clearly indicated in the log file. Usually it can be found somewhere at the end and is repeated several times. If there are no errors or it is not clear how to fix the error messages, contact your Skyline Communications Technical Account Manager and send them the log file.

The log file can be found in "*C:\Skyline DataMiner\Logging\\ElementName\].txt*".

### Advanced Setup

Once an element has been created, it is possible to fine-tune the behavior of the connector. Below, you can find a list of settings that have an impact on your system. Each setting is explained in more detail further in the document. It is important to have at least an idea of what each feature does and what the potential impact is.

*Poll Manager*

With the poll manager, you can enable or disable polling commands, as well as change the poll interval (within certain limits).
By default, most commands are disabled, so you will almost certainly need to enable some commands.

#### Network Error Handling

When the connector fails to communicate with the device, it will flag a network error. This error can be monitored, but, more importantly, it can also be used to stop polling via the IIOP interface until the connection is restored.

By default, the connector will just continue to poll the device. However, this could lead to a high CPU load and network errors are typically not resolved quickly. Therefore it is advisable to change this default behavior and instead start the "Ping Procedure". This means that instead of 'heavy' IIOP calls, only ping messages will be sent. As soon as a ping message returns successful, the normal polling will be resumed.

Note that ping messages are only sent to **Management IP Address 1** and the system will not recover if ping messages are blocked. This is why the default behavior is to continue the normal polling. As a consequence, before you activate the ping procedure, it is important that you verify whether it is possible to ping the device from the DataMiner Agent.

#### Driver Startup

In the past, there have been problems when DCM elements were restarted. In these cases, DataMiner already started the element before it had been fully stopped. This was done to achieve a higher responsiveness, but could potentially cause RTEs.

To counter this, on startup the connector will check if there are indications that another thread is still active, and if so, block the element for a while. The maximum time to wait and the time to wait between two checks can be configured on the Driver Startup page. By default, the connector will wait at most 14 minutes. This setting provides a safe margin, but in many configurations it may be considered excessive. Much depends on the general load of the DMA. If this is not considered 'high', a more reasonable setting may be *1* or *2* minutes*.*

Important: Remember that it could take a while before polling starts after an element restart.

## Usage

The functionality of the various pages of the connector is explained below.

### Overview

This page contains a tree view representing the device. It is a mix of the input/output and processing trees in the web interface under the **Services** tab with the information in the **VSE** tab.
The main structure is:

1. Board
1. Port
1. Input/Output branch
1. Transport Streams
1. Services
1. Programs (/PIDs/Components)

Corner Cases:

The "Chassis" is represented as the "Main Board" and does not have any children.

The data shown in the VSE tab in the web interface is shown below a virtual board named **Virtual Service Encoder**. This 'card' also follows a different structure:

1. Board (= *Virtual Service Encoder*)

1. Transport Stream

    To this level, an extra tab page is added to include 'service' parameters, such as PCR and PMT PID.

    We currently assume that every transport stream holds exactly one service.

1. Component

VSE Cards (= Cards listed in table **VSE Encoder Cards**) may not have any ports attached to them. This will be the case when they are also not visible under the Service tab in the web interface.

### General

This page contains information about the chassis. This includes **System Name**, **Serial Number**, **Current Activation Mode**, **Power Supply Status**, etc. Additionally, **Device Operational Status** will indicate if there's a *Device Operational Failure* when the alarm table is polled.

Below this are buttons to initiate a **Clean**, **Cold** and **Warm Reboot**. The other buttons open a pop-up page displaying a list of installed **Licenses** and a pop-up page displaying the **Driver Startup** behavior (see "Advanced Setup" section for more information).

Finally, there is also a **Module Info** table listing all detected hardware with the version information.

### Alarms

This page contains an **Alarm Overview** table, which shows all alarms present on the device.
Available columns are:

- Type
- Name
- Severity
- Detection Time
- Details
- ...

This overview table is a mix of the data accessible through page buttons below the table.

- **Detection Time**: Displays when the alarm was first detected for every alarm ID in the **Active Alarms** table.
- **Alarm Info:** Contains a list of all possible alarms (ID and Name) that could be linked to each board, with a timestamp indicating when the data was last polled.
- **Active Alarms**: Contains a list of alarms that are currently active with details such as severity, target, etc. as well as a timestamp indicating when the data was last polled.

### Backup / Restore

This page can be used to take or restore a backup.

A backup contains the complete configuration of a device. When you take a backup, it will always contain all settings, but when you restore a backup, it is possible to exclude some of the settings.

Backups are usually stored on the local DataMiner agent. The default folder is the Windows %Temp% folder.

Important note:
While you are taking a backup, all other polling is set on hold. Taking a backup should take at most 30 seconds in most circumstances; however, it is possible that it takes up to several minutes. Keep this in mind if you decide to take regular backups using the Poll Manager or an Automation script. Usually, the time it takes to complete a backup does not change, so you can first take a backup manually and see how long it takes, and then decide if this is acceptable. However, the duration can change if you modify many streams and settings, so it is best to only test this after the DCM is fully (re-)configured.

**Backup Save Path**

Backups are saved in the folder/file defined by combining the **Backup/Restore Directory** and the **BS Backup Save Name**. This means you can leave the Backup/Restore Directory empty and fill in the complete path in the BS Backup Save Name parameter.

Alternatively, you can also:

- set the Backup/Restore Directory to *C:\Skyline DataMiner\Documents\CISCO DCM\Europe Main\\*
- set the BS Backup Save Name to *Backups\Full Backup.tgz*
- set the BS Restore Path to *Backups/Approved/Full Backup.tgz*

**Restore Save Path**

When a backup is restored, the full path of the file to restore is a combination of the **Backup/Restore Directory** and the **BS Restore Save Name**. This makes it possible to select a file without having to alter the filename used to take a backup.

**Taking or restoring a backup**

To take a backup:

1. Click the Take Backup button.
1. Verify the **BS Backup Save Path Validation** parameter and the **BS Backup Status** parameter to follow up the status/progress of the backup, and to get more information in case there is an error.
1. In case of errors, check the element's log file for more information.

To restore a backup:

1. Click the Restore Backup button.
1. Check the **BS Backup File Valid** and **BS Restore Status** parameters.
1. In case of errors, verify the log file for more information.

Note:

- You should always set **BS Backup Scope** and **BS Restore Scope** to *ALL*.
- The maximum backup size is limited to 20MB, and the maximum duration before the backup should be received is 5 minutes. This is hard-coded in the connector. (The typical size of a backup is approx. 3MB.)

### Manager \[From version 1.0.0.12 onwards\]

This page contains a very important table: the **Poll Manager**. Via this table, polling for certain commands can be enabled or disabled and the poll interval can be set (within predefined limits). Most of the commands are directly linked with a table.

Six columns are displayed in the Poll Manager:

- **PM - Description**: Contains the description of the command.
- **PM - Status**: Displays whether the command is enabled or not.
- **PM - Poll Interval**: Contains the interval between two polls.
- **PM - Execution Counter**: Contains a number indicating how many times the command has been executed since startup.
- **PM - Last Executed**: Contains a timestamp indicating when the command was last executed.
- **PM - Actions**: Allows the user to poll the command again outside the normal polling cycle.

The status of a command is either *Enabled* or *Disabled.* However, some commands cannot be disabled by the user. These are displayed as *\[Enabled\]*. This is for instance the case for **Get Boards** and **Get Ports***.*

To enable a command, you can set the **PM - Status** column to *Enabled*. However, note that this does not guarantee that the command will actually be enabled. It is possible that other commands also need to be enabled before a particular command can be activated. To see the required commands, check the hidden column **PM - Required Commands** (see "Hidden Columns" section below). If other commands are required, these should either be enabled in the correct order, or the option *Enable (including parents)* should be used.

The same applies for disabling commands: disabling a command will fail if there is at least one other command which requires that command. However, it is also possible to stop all "child commands" using the option *Disable (Including Children)*.

To change the poll interval, simply specify a new timespan in the **PM - Interval** column. The value should be specified as follows: *\[Days\].\[Hours\]:\[Minutes\]:\[Seconds\]*
However, please note:

- Days and Seconds are optional.
- When a timespan is specified that is less than the minimum or more than the maximum allowed interval, the value will be rounded down or up to respectively the minimum or the maximum interval.
- If the supplied input text could not be parsed, the value will not change.

There are also some buttons to quickly change some settings:

- **Reset To Defaults**: Resets all poll intervals to their default value.
- **Slower**: Increases all poll intervals by 10%, within the limitation of the maximum allowed interval.
- **Faster**: Decreases all poll intervals by 10%, within the limitation of the minimum allowed interval.
- **Refresh All**: Refreshes all data for which the command is enabled.
- **Disable All**: Disables all commands, except those that cannot be disabled.
- **Enable All**: Enables all commands.

### Driver Settings \[Removed in version 1.0.0.12\]

This page contains parameters that are not (directly) related to the device.

For more information related to

- **Network Error**: See section "Advanced Setup" above.
- **IIOP Login**: See section "Verify IIOP Credentials" above.
- **Driver Startup**: See section "Advanced Setup" above.

This page has a page button **SNMP**, which displays a list of trap servers to which the device should send SNMP traps. It is possible to add or delete targets using the two fields and buttons below the table.

In version **1.0.0.12**, the **Poll Manager** was introduced, replacing the toggle buttons found on this page.

### Communication

This page displays the main and optional IP addresses used for polling. You can also change the polling port here, though it is unlikely that this will ever be necessary.

The page also contains a parameter that indicates the currently used IP address, and buttons to force change/select one IP address. However, note that Management IP Address 1 can only be set or changed through the element editor.

Finally, there are buttons to display the **Network Error**, **SNMP** and **IIOP Login** pop-up pages.

### Table Data

This page contains a list of page buttons that lead to pages with the raw tables used to build up the tree view.

For some tasks, viewing the data in table format is more convenient than using the tree view. This can for example be because it is easier to compare values of all records in the system, or because you can compare two tables with each other.

The following tables are related to the **Service** tree on the web interface:

- **Hardware:** *Boards ...* & *Ports ...*
- **Transport Streams:** Input ... & Output ...
- **Services:** *Input ...* & *Output ...*
- **PID Components:** *Output ....*
- **FEC:** *Encoder ...* & *Decoder ...*
- **Backup:** *Service ...* & *Params ...*

The following tables are related to the **Configuration** tab in the web interface:

- **GBE Ports:** *Statistics ...* & *Settings ...*
- **IP Settings:** *IP Params ...* & *Destinations ...*

The following tables are related to the **VSE** tab in the web interface:

- **VSE:** *Boards and Ports ...*, *Services* & *TS ...,* *Svc Components ...*

- *App Objects ...*
  This page contains a list of all application objects and a second table listing a mapping of the keys of the tables in the parameter and the XPath required to select the source of those parameters in an xml file. These tables should be considered background information, although they could be very important for advanced configuration in Automation scripts.

- *All parameter schema tables in the second column:*

- *Audio AAC Stereo*
  - *Audio AAC 32 Multichannel*
  - *...*
  - *Video SD MPEG2 Single Pass*

### Customer Specific Requests

This page contains page buttons to parameters and tables specifically requested by customers to help them integrate this device.
Examples could be:

- extra parameters for Visio files.
- an alternative interface for Automation scripts.
- extra (saved) parameters for management.

There are several reasons why these parameters are tucked away behind page buttons, the most notable being:

- they could confuse customers who did not request the feature, as their purpose may be unclear.
- they could cause a noticeable load on the system (CPU, Network, Memory, ...).
- using the parameters could have side effects (Changes in naming keys, ...).

This is why these features are by default disabled. If a customer requested a particular feature, they must enable it in their system. However, customers are strongly advised not to enable features made for other customers.

Notes:

- Because these features are usually tightly integrated with other components (Visio, alarm filters, Automation scripts) changes to these features can only be requested by the customer who requested them. Other customers should not use them or rely on them. The requesting customer may at any point request additional changes that may not be backwards compatible, and no effort will be done to keep changes backwards compatible or to consider other customers using the feature even though they did not request it.
- These features are not always fully documented in the connector help file. Customers who specifically requested a feature are expected to know what it does.

#### TV2 Norway

**Feature: Alarm Summary** \[added in version 1.0.0.9\]: Extracts alarms from the active alarms table to get a summary of the worst active severity on Video Input Signal status and Embedded audio status. For this feature, it is assumed that there will be no more than 1 SDI board and that it has 8 inputs.

### Web Interface

This page displays the device web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
