---
uid: General_configuration
---

# Frequently asked questions about general configuration

- [Which limitations should I keep in mind for the specifications of a DMA?](#which-limitations-should-i-keep-in-mind-for-the-specifications-of-a-dma)

- [When must a DataMiner Agent be restarted?](#when-must-a-dataminer-agent-be-restarted)

- [How do I synchronize time settings within a DMS?](#how-do-i-synchronize-time-settings-within-a-dms)

- [How do I keep DataMiner Cube from disconnecting automatically?](#how-do-i-keep-dataminer-cube-from-disconnecting-automatically)

- [How do I delete all alarms on a DMA?](#how-do-i-delete-all-alarms-on-a-dma)

- [What do I do if two DMAs cannot communicate?](#what-do-i-do-if-two-dmas-cannot-communicate)

- [What do I do if there is an SLNet process disappearance?](#what-do-i-do-if-there-is-an-slnet-process-disappearance)

## Which limitations should I keep in mind for the specifications of a DMA?

You can find these on the [DataMiner Metrics](xref:dataminer_metrics) page.

## When must a DataMiner Agent be restarted?

A DataMiner Agent must be restarted in the following cases:

- After a manual change has been made to a DataMiner XML file.

  E.g. when you have added a custom command to the Alarm Console shortcut menu in *Hyperlinks.xml*.

- After the IP address of the server hosting the DataMiner Agent has been changed.

- After the time zone on the DataMiner Agent has been changed.

> [!NOTE]
> After an upgrade, the DMA will automatically be restarted.

> [!TIP]
> See also: [Starting or stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_a_DMA_in_DataMiner_Cube)

## How do I synchronize time settings within a DMS?

Within a DMS, it is essential that the time settings on the different DMAs are synchronized. Without proper time synchronization among the different DMAs, it is impossible to correlate events or even to have a correct overview of what is happening on the DMS.

### Time synchronization options

The most common way to make sure that time is synchronized among all DMAs is to make them all members of the same domain.

However, if this is not possible, you can set up a time synchronization mechanism among the DMAs that is based on SNTP (Simple Network Time Protocol). This mechanism involves turning one computer into a time server, and all other computers into time clients.

More information about SNTP can be found in RFC 4330:

- [Simple Network Time Protocol (SNTP) Version 4 for IPv4, IPv6 and OSI](http://www.ietf.org/rfc/rfc4330.txt)

### Time server

The time server will provide the correct time settings for all DMAs.

To turn any computer using Windows Server 2008 R2, Windows 7 or later into a time server, whether it serves as a DMA or not, do the following:

1. Log on locally to the machine that will act as time server, or establish a remote desktop session with it.

1. Stop the Windows Time service via *Start \> Control Panel \> System and Security \> Administrative Tools \> Services*.

1. Open the registry editor via *Start \> Run... \> regedit*.

1. Search for the *HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\W32Time\TimeProviders\NtpServer*.

1. Set the *Enabled* value to 1.

1. Search for *HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\W32Time\Config*.

1. Set the *AnnounceFlags* value to 5.

1. Start the Windows Time service again and set the start type to *Automatic*.

> [!NOTE]
>
> - If you are using Windows Server 2012 R2 (64-bit), set the start type to "Automatic (Delayed Start)" for the service to start automatically.
> - If you are using Windows 7 or Windows Server 2008 R2, and the Windows Time service always stops, follow the instructions from this [Microsoft support page](https://support.microsoft.com/en-us/help/2385818).

### Time client

All DMAs in the DMS have to be turned into time clients that will synchronize their time settings with those of the time server.

To turn a DMA into a time client, do the following.

1. Log on locally to the DMA, or establish a remote desktop session with it.

1. Open the *Services* dialog box via *Start \> Settings \> Control Panel \> Administrative Tools \> Services*, and select the *Windows Time* service.

1. Right-click the service, and select *Properties*.

1. Change *Startup type* to *Automatic*, and click OK.

   This will make Windows Time service start automatically when the DMA is started.

1. Right-click the *Windows Time* service, and select *Start*.

1. Check whether the service is actually running, and then close the *Properties* dialog box.

1. Open a command prompt window via *Start \> Run... \> cmd*.

1. Enter *net time /set*, followed by the IP address of the time server, and press *Enter*.

### Other time-related commands

The following table contains a few other commands that may be useful when synchronizing time settings among DMAs.

To retrieve the time server that is being used by a particular DMA, execute the following command on that DMA:

```txt
net time /querysntp
```

To get the current time from a specific time server, execute the following command, replacing the “192.9.200.1” placeholder with the actual IP address of the time server:

```txt
net time \\192.9.200.1
```

To get the current time from the time server, together with a detailed report, execute the following command (which will also adjust the clock of the time client on which you execute the command):

```txt
w32tm -once -v
```

## How do I keep DataMiner Cube from disconnecting automatically?

By default, a DataMiner Cube session will disconnect after a certain period without user activity. This way, users cannot leave sessions open on unattended workstations.

However, under certain circumstances, it may be necessary to keep a session open for an indefinite period of time. To do so:

1. Go to the DataMiner Cube user settings. See [User settings](xref:User_settings).

1. Go to the *Connection* tab.

1. Clear the option *Time before automatic disconnect*.

## How do I delete all alarms on a DMA?

To delete all alarms on a DMA from the history database, you have to drop a number of tables in the MySQL database.

> [!WARNING]
> Performing the following procedure has a severe impact on a DataMiner system.

All history alarms will be deleted indiscriminately, and the Alarm Console, reports, and dashboards will no longer contain any history alarm data.

1. Connect to the DMA using Remote Desktop.

1. Stop the DataMiner software. See [Starting or stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_a_DMA_in_DataMiner_Cube).

1. Open [MySQL Workbench](xref:MySQL_Workbench). In the logon window, click *OK* to connect to the database using the default settings.

1. Open the SLDMADB tree.

1. Right-click and select *Drop Table* for the following tables:

   - Alarm

   - Alarm_property

   - Brainlink

   - Latch_state

   - Rep_pd_info

   - Rep_pd_newalarms

   - Rep_pd_states

   - Service_alarm

   If you also want to clear all information events, then also select *Drop Table* for the following table:

   - Info

1. Close MySQL Workbench.

1. Restart the DataMiner. See [Starting or stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_a_DMA_in_DataMiner_Cube).

    On startup, DataMiner will recreate the tables you have dropped, and the new tables will all be empty.

## What do I do if two DMAs cannot communicate?

In some cases, a DMA may not be able to communicate with another DMA because of a change in setup. This could for instance be because one Agent is a domain member, while the other Agent is not in a domain but in a workgroup.

To solve this problem, you can specify a custom user account for inter-DMA authentication purposes.

To configure a custom user account:

1. Open the SLNetClient test tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

1. Connect to the DMA. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Edit the connection strings between the DMAs. See [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

## What do I do if there is an SLNet process disappearance?

A process disappearance of SLNet can be caused by an issue in the Microsoft .NET Framework 4.6.

You can resolve this by installing the appropriate Microsoft hotfix:

- KB3139551 Hotfix Rollup HR-1602 - NPD 4.6/4.6.1 RTM - Win7SP1/Win2K8R2RTM/Win2K8R2SP1/VistaSP2 - KB3139551

- KB3139550 Hotfix Rollup HR-1602 - NPD 4.6/4.6.1 RTM - Win8.1RTM/Win2K12R2RTM- KB3139550

- KB3139549 Hotfix Rollup HR-1602 - NPD 4.6/4.6.1 RTM - Win2K12RTM - KB3139549
