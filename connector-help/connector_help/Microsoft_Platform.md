---
uid: Connector_help_Microsoft_Platform
---

# Microsoft Platform

With the Microsoft Platform connector, it is possible to monitor a Microsoft server.

## About

The Microsoft Platform connector retrieves basic information from a Microsoft server. Extra information can be enabled or disabled, e.g. Task Manager, Service List, etc.
On the Task Manager page, a button allows you to normalize alarms in order to set the current values as normal.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x \[obsolete\] | Microsoft WMI interface implementation. | Yes | Yes |
| 1.1.0.x | Microsoft WMI interface implementation. | Yes | No |
| 1.1.1.x \[move to 1.1.2.x\] | Branched from 1.1.0.89: Microsoft WMI interface + interface for DELL- and HP-specific SNMP parameters. | Yes | Yes |
| 1.1.2.x \[obsolete\] | Branched from 1.1.1.x: Microsoft WMI interface + interface for DELL- and HP-specific SNMP parameters. | Yes | Yes |
| 1.1.3.x \[SLC Main - Virtual Machine Environment\] | Branched from 1.1.0.97: Contains partitionedTrending database option. Difference between 1.1.3.x and 1.1.0.x branch will not be noticeable with Cassandra general database, only with MySQL general database. Version 1.1.3.5 merged with 1.1.0.106. | Yes | Yes |
| 1.2.0.x | Multiple tables now use naming instead of displayColumn to make the database for these tables Cassandra-compliant. | Yes | Yes |
| 2.1.0.x | Branched from 1.1.0.41: Network Interface table adjustments. | Yes | Yes |
| 3.0.0.x | Branched from 1.1.0.71: Implemented a workaround for a WMI bug in the network adapter table. | Yes | Yes |
| 4.0.0.x | Branched from 1.1.0.78: Customer-specific branch including functionality to see if the element is running on the active DMA (Failover) with specific security configuration settings in the elements. | Yes | Yes |
| 5.0.0.x | Branched from 1.1.1.5: Temporary branch to be used as workaround for a problem with retrieving the service table via WMI calls. | Yes | Yes |
| 6.0.0.x \[SLC Main - Physical Hardware Environment\] | Branched from 1.1.2.31: Microsoft WMI interface + interface for DELL-, HP- and Supermicro-specific SNMP parameters. | Yes | Yes |

## Configuration

The polling IP of the Microsoft server must be defined when the element is created.

### WMI configuration

1. To go to WMI Control Properties, go to **Start** \> **Run** and enter *wmimgmt.msc*.
1. Right-click **WMI Control (Local)** and select **Properties**.
1. On the **Security** tab page, go to \\Root\CIMV2 and click the **Security** button.
1. Add your local user to the list and give the user all rights.
1. Apply all.

### DCOM configuration

1. Go to **Start** \> **Run** and enter *dcomcnfg*.
1. Select **My Computer** and click the **Properties** button.
1. Go to the tab **COM Security**.
1. Under **Launch and Activation Permissions**, choose **Edit Limits**.
1. Add your local user and give the user the Local Launch, Remote Launch, and Remote Activation permissions.
1. Apply all.

**Note:**

- After DCOM settings have been changed, the WMI services sometimes need to be restarted.
- This method works fine for a Windows XP system but cannot be used on a Windows Server 2003 SP1.
- On a Win2K3, the local user must be added to the administrators group.
- On a Win2K8, the local user must be added to the administrators group, Distributed COM Users, and Performance Monitor Users.

## Usage

### Performance

- **Security**: Opens the **Security Settings** window, where the **Domain name**, **User Name** and **Password** can be configured. The status shows if the DMA is connected to the server you want to monitor.

- **Port monitoring:** Opens a window where port monitoring can be enabled and configured. To enable port monitoring:

  1. On the **Performance** page, click the **Port monitoring** button.
  1. Define a **Polling Period.**
  1. Use the **Add Port** box to add one or more ports that need to be monitored in the **Port List**.
  1. Enable polling by clicking the toggle button next to **Port Monitoring Status**.

- **Ping monitoring:** Opens a window where ping monitoring can be enabled and configured. To enable ping monitoring:

  1. On the **Performance** page, click the **Ping monitoring**... button.
  1. Click the toggle button next to **Ping Query** to execute the ping.
  1. Configure the **Ping Cycle**, i.e. the interval between each ping. The default value is *60 s*.
  1. Configure the **Ping Timeout** and **Ping Number**. The default values are *1500 ms* and *4* respectively.

### Task Manager

To clear all processes that are no longer running from the table, click the button **Clear Task Manager** at the bottom of the page. You can also enable automatic removal of processes that are not running by setting the parameter **Auto Clear Task Manager** to **On**.

To set the current values in the table as the normal reference for alarms, click the button **Normalize Alarms**. You can then view these references via the **Nominal** **Values** button at the bottom of the page.

It is also possible to add a filter to calculate the sum of the memory usage of all processes that match this filter. To do so:

1. Click the button **Cumulated Memory** at the bottom of the page.

1. Enter a filter in the box **Add Filter Param**. An asterisk ("\*") wildcard is supported in this filter. You can also use an exclamation mark ("!") to return the opposite cumulated memory of the filter parameter. (cf. examples below)

   | Examples | Description |
   |--|--|
   | `SLDatam*` | Searches for processes that begin with "SLDatam". |
   | `*Dataminer*` | Searches for processes that contain the word "DataMiner". |
   | `miner:0*` | Searches for processes that end with "miner:0". |
   | `SLDataminer:0` | Searches for the process "SLDataminer:0". |
   | `!SLDatam*` | Searches for processes that do not begin with "SLDatam". |
   | `!*Dataminer*` | Searches for processes that do not contain the word "DataMiner". |
   | `!miner:0*` | Searches for processes that do not end with "miner:0". |
   | `!SLDataminer:0` | Searches for processes that are not equal to "SLDataminer:0". |

1. If necessary, add more filters or delete filters using the **Delete** button next to the filtered parameter.

On the **Task Manager Measurement** page, you can disable processes to remove them from the **Task Manager** Table. The **Task Manager Default Measurement State** will enable/disable the measurement of new processes. The **Clear** button will remove all deleted processes from the **Task Manager Measurement Config** table. The **Refresh** button can be used to manually refresh the list of processes when Auto Refresh is disabled.

### Network Interface

This page displays a table with the different measured network adapters on the server. Note that the bandwidth of an adapter can be very high (*e.g. 10 GB/s*). Therefore, as the utilization gets calculated as the total speed divided by the bandwidth, the utilization value can be extremely low. It can even be rounded down to 0.00 % if *Total Speed \< 0.005 \* Bandwidth*.

For most interfaces, the **Mac Address** and **Status** are available. For a server of the type Microsoft Server 2000 or Microsoft 2000 Professional, the **Mac Address** is not available.

If you set the **Adapter Description** to the correct name (from Win32_PerfRawData_Tcpip_NetworkInterface), additional info will be retrieved. The connector intelligently tries to match the adapters to the correct default description on initializing, but in some cases, you will still need to set this description manually, using the dropdown box. Once this has been set manually, the connector will not overrule the setting with an automatic set. The options displayed in the dropdown box are the names of the network interfaces that were found in the WMI. You can also choose a custom name that is not from this list, but then no match will be found, no additional info will be shown, and the description can be overruled by the connector. You can only assign a network interface to one network adapter. If you set a network adapter to a description that is already used by another adapter, the description of the other adapter will be set to an empty string.

On the **Network Adapter Measurement** page, you can disable processes to remove them from the **Network Adapter** table. The **Network Adapter Default Measurement State** will enable/disable the measurement of new adapters. The **Clear** button removes all deleted processes from the **Network Adapter Measurement** and **Network Adapter** table. This is by default followed by a refresh. The **Refresh** button can be used to manually refresh the list of network adapters and the additional information. It is possible to entirely disable the polling of the network adapters with the toggle button **Poll Network Adapters**. Once an adapter is disconnected and not found by the connector in the WMI, its status will be set to *Disconnected*. You can choose to either autoclear such adapters with the button **Autoclear Disconnected Adapters** or to manually delete them with the dropdown box **Manually Clear Disconnected Adapters**. If no adapter has the status *Disconnected*, this dropdown box will be empty.

### Disk Info

The **Percent Disk Busy Time** can go above 100% (more info: <http://demandtech.pmhclients.com/index.php?pg=kb.page&id=47>, <http://support.microsoft.com/kb/310067>).

Another indication of when the disk is very busy is the "Latency" of the disk, i.e. how long it takes before it can process something. On this page, this is indicated by the **Avg Disk sec/Transfer Rate**.

### Event Viewer

This page displays information regarding selected or created events.

When you enable the Event Viewer, you can monitor the events displayed in the Event Viewer table. If you want to add events, click the **Add event** page button. A subpage will open. If you click **Load**, all the event messages from a specific time interval will be retrieved and displayed on the page. You can then select the events you want to monitor by clicking the **Monitor Event** button. The time interval can be changed using the slider.

To delete a monitored event, click the **Delete button** in the Event Viewer table.

The event details can be configured. For each type of event (information, warning, or error), the severity of the created alarm can be selected from the dropdown list. For example: "Disk Crash" event with a **Severity Error Type** equal to *Critical*.

When the configured **Alarm Type** equals ***Normal*** and an event occurs that matches one of the added filters in the **Event Viewer Messages** table, the new event will automatically trigger an alarm or an information event. **Alarm Type** ***Grouped*** will add the row to the **Grouped Event Alarms** with the most recent severity of the event. When the **Grouped Event Active Time** expires, the event is removed from the table. Grouped events will not create alarms automatically, but you can configure alarm monitoring on the **Grouped Event Type** column.

From version 1.1.0.100 onwards, it is possible to get all events except those with a specific **Event ID**. In each row of the table, a toggle button **Exclude Event ID** has been added:

- If it is set to the default setting ***Include***, you can insert a **single event ID** or the value **"\*"** to **get all event IDs** for the relevant source/category (= **equal to all previous versions**).
- If it is set to ***Exclude***, you can select a **single event ID**, which will be omitted from the results. All other event IDs will be selected.

### Performance Monitor

This page monitors performance counters added by the user.

On the **Config Performance Counters** page, you can search for performance counters and add them to the **Performance Monitor** table. To do so, first click **Refresh Categories** to create a dropdown list with the **Categories**. Select the category and then choose a **Counter**. If the counter has multiple instances, you can either select the **Instance** you want, or select *\<All Instances\>.* Finally, click the **Add Counter** button to add the selected counter to the table.

With the **Performance Monitor Sample Time**, you can configure the sample time for all created performance counters.

### Dell

This page is intended for Dell hardware.

It monitors certain high-level parameters, such as the name, version, model and so on. It also includes several subpages with more information on specific subcategories. The **Temperature Probe Table** provides information about the temperature of the device. The **power supply**, **fans**, **CPU** and **memory** of the device are monitored in a similar way. The **Disk** page provides an overview of all of the disks included in the system.

Note that in order for these parameters to be polled, you have to **enable polling on the Dell page**.

### HP

This page is intended for HP hardware.

It monitors the same set of parameters as the Dell page described above.

Note that in order for these parameters to be polled, you have to **enable polling on the HP page**.

### Software Info

This page contains the **Software Info Table**, which displays a list of all installed programs.
**Note: USERNAME and PASSWORD have to be set! (Under Performance \> Security Settings).**

Above the table, it is possible to select the polling method. (Alternative methods were introduced after problems were encountered with the used WMI Query.)

- *No Polling*: Nothing will be retrieved, and the table will remain empty.
- *Win32_Product*: WMI Query used to retrieve a list of all installed programs. We strongly advise **not to use this method**, as this can perform a Windows Installer "reconfiguration" on every MSI package as it is performing the query.
- *Win32reg_AddRemoveProgram*: WMI Query used to retrieve a list of all installed programs if Microsoft CSSM software is installed. This is a better alternative to the Win32_Product method.
- *Registry Keys*: **Recommended method.** This method will use WMI to read the registry keys to display a list of all installed programs in the system.

## Notes

### General

From Windows 2000 onwards, WMI is installed by default.

Except in Windows Vista, WMI uses random ports.
To configure a fixed port in Windows Vista:

1. In the command prompt window, type *winmgmt -standalonehost.*
1. Stop the WMI service by typing the command *net stop "Windows Management Instrumentation"*.
1. Restart the WMI service in a new service host by typing *net start "Windows Management Instrumentation"*.
1. Establish a new port number for the WMI service by typing *netsh firewall add portopening port=24158 name=WMIFixedPort*.

If you want to have access to the WMI interface of a Windows XP computer, you can work with a local user (a group user, not an administrator) that has the necessary Windows security rights, so extra configuration is necessary on the client computers.

As this is a Microsoft configuration, nothing has to be configured within DataMiner for this.

### Global configuration

1. Create a user and add the user in the user group.
1. If the firewall is enabled, open a command prompt and execute "*netsh firewall set service RemoteAdmin enable*".

### Troubleshooting

**Problem:**

- Remote WMI queries for non-admin users:

  - Access is denied with error code 0x80070005 -\> **Solution**: DCOM configuration (see installation and configuration).

  - Access is denied with error code 0x80041003 -\> **Solution**: WMI configuration (see installation and configuration).

  - To check whether access is denied, the following two procedures are possible:

    - The first procedure:

      1. Click **Start** \> **Run** and enter *wmimgmt.msc*.
      1. Right-click **WMI Control (Local)** and select **Connect to another computer**.
      1. Select **Actions** \> **More Actions** \> **Properties**.

         At this point, you will receive the following error: Failed to connect to [\\%RemoteIP%](file:///) because "Win32 Access is denied".

    - The second procedure:

      - Run "wmimgmt.msc" directly on server.

        You will receive the following error: Microsoft Management Console "An attempt was made to reference a token that does not exist".

**Problem:**

- Access is denied, even when the username and the password are correct.

  **Solution**:

  - Try to open Windows Explorer on that machine, using the login that you want to use in the Microsoft element. If it is not possible to connect to the server because you have to log on with the account "guest", execute the following steps:

    1. Go to **Control Panel** \> **Administrative Tools** \> **Local Security Policy**.
    1. Go to **Local Policies** \> **Security Options**.
    1. Double-click **Network access: Sharing and security model for local accounts**.
    1. Select **Classic- local users authenticate as themselves**.

**Problem:**

- A Microsoft element displays only some of the data. Data like Local Time, Total Physical Memory, etc. are filled in, while other data, like Total Processor Load, Total Handles, etc. remain empty. In the stream, you see that no answer is received on some queries.

  **Solution:**

  - Execute the following command prompt: *c:\\winmgmt.exe /resyncperf PID_OF_WINMGMT_AS_SERVICE*

**Problem:**

- Possible memory leak on remote machines that are running 2008/Vista:
  <http://support.microsoft.com/kb/970520/en-us>

  **Solution:**

  - When the remote server is running Vista, UAC must be disabled.

**Re-registering the WMI components on the monitored server:**

- The .DLL and .EXE files used by WMI are located in %windir%\system32\wbem. You may need to re-register all the .DLL and .EXE files in this directory.

  If you are running a 64-bit system you may also need to check for DLLs and EXE files in %windir%\sysWOW64\wbem.

- To re-register the WMI components, run the following commands with the command prompt:

  ```
  cd /d %windir%\system32\wbem*
  for %i in (*.dll) do RegSvr32 -s %i
  for %i in (*.exe) do %i /RegServer
  ```

**Problem:**

- Task Manager data through WMI cannot be retrieved. This can be related to missing "Process Performance Counters".
  Refer to this technet post for more info: <http://blogs.technet.com/b/mscom/archive/2008/12/18/the-mystery-of-the-missing-process-performance-counter-in-perfmon.aspx>

  **Solution**:

  - Disable a specific flag on the Windows Register. Set the "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PerfProc\Performance\Disable Performance Counters" to *0*.

**Problem:**

- StreamViewer mentions the following: Query failed : Retrieving the data failed. (hr = 0x80041010) for numerous WQL SELECT queries.

  When wbemtest is used and these queries are performed or the classes are listed, this results in similar errors mentioning "Invalid class".

  **Solution**:

  - Most likely some or all related Disable Performance Counters in regedit for PerfDisk, PerfNet, PerfOS, PerfProc, Tcpip or W3SVC are set to 1 (see Problem/Solution above for information on regedit).
  - Set all these to 0, and after a couple of minutes the query errors should disappear and the related data should get filled in.

**Problem:**

- The following error occurs: *Contacting server failed: Connection to \[//tns1216.inet.telenet.be/root/cimv2\] failed. The RPC server is unavailable. (hr = 0x800706BA).*

  **Solution**:

  - Make sure tcp/135 and tcp/49000-65535 (WMI) are open.
  - Make sure the user is created on server and host.

**Problem:**

- WMI is working and everything gets filled in, but Performance Monitor does not work. Pressing Refresh Categories provides the following error in element logging:

  Exception Perf Counters The network path was not found.

  **Solution:**

  - Check if the destination computer has the "Remote Registry" service running. If not, start this service. (Note that you may need to adjust the Startup Type from *Disabled* to *Manual/automatic* first.)

### Information Resources

- [How to Enable Remote WMI Access for a Domain User Account](https://martellotech.com/blog/enable-remote-wmi-access-for-a-domain-user-account/)
