---
uid: Verify_Cluster_Events_Tool
---

# Verify Cluster Events Tool

The Verify Cluster Events tool is a debugging tool that can be used to verify the state of the in-memory SLNet EventCache across DMAs in a cluster. It can also be used to redistribute missing information or to clear excess information.

The tool can be of use in cases where, when you connect to a specific DMA using Cube, different alarms and/or elements are displayed than when you connect to a different DMA in the cluster.

You can download the tool from [DataMiner Dojo](https://community.dataminer.services/download/verifyclusterevents-1-0-0-9/).

Its usage has the following limitations:

- It is **not** intended for investigating synchronization issues between DMAs (e.g. files, configuration, etc.).

- It should **not** be used while one or more DMAs are disconnected.

- It should **not** be used if there are no specific symptoms to focus on.

> [!NOTE]
> The tool uses snapshots of the cache and inter-Agent subscriptions. Since snapshots are not taken simultaneously, there might be differences because of in-transit events. The tool can also only accurately report missing events or events that are stuck when there is a full inter-Agent subscription on a type.

## Usage

### Retrieving information with this tool

1. Download the tool from [DataMiner Dojo](https://community.dataminer.services/download/verifyclusterevents-1-0-0-9/).

1. Extract the file and double-click *VerifyClusterEvents.exe*.

1. In the *Host* box, specify the name or IP of the DMA you want to connect to.

1. In the *User* and *Password* boxes, specify the credentials to connect to the DMA.

1. If you only want to retrieve alarm events, select the *Alarm Events Only* checkbox. This will allow faster data retrieval.

1. Click *Fetch*.

1. Select the type of information you want to check in the *Type* drop-down box.

   The retrieved information will then be displayed in the tabs below the settings.

### Working with the Agent Grid tab

When information has been retrieved as detailed above, the Agent Grid tab displays what each DMA has stored for every other DMA in the cluster.

The number in each table cell indicates the number of events in the cache for that DMA. When the count does not match with the expected count, the cell is displayed in red and there is an indication of how many events are missing/stuck.

“[no subs]” indicates that the client DMA does not subscribe to this type of event (the tool only checks for full subscription).

Double-clicking a cell opens a window with detailed information about missing events or events that are stuck for a combination of two Agents. The Pending Count at the top indicates how much this Agent is behind. If the number is high, cache differences between the Agents might be normal and are a consequence of load. The right-click menu in this window provides access to options and fixes. On the *Actions* page, you can find tools to fix issues (e.g. dropping connections between DMAs to recreate these, or clearing or re-forwarding events).

### Working with the Tools tab

In the Tools tab, two buttons are available:

- *Clear all excess*: Clears all events that are stuck.

- *Redistribute All Missing*: Forwards missing events again. This option requires at least DataMiner 9.5.0 CU3 or 9.5.6.

### Importing/exporting results

It is possible to export the information you have retrieved into a .bin file. To do so, go to the *File* menu at the top of the window and select *Export*. Such a file can then imported into the tool at a different time for evaluation, via *File* > *Import*.

If you are using this tool to report an issue, always include an export file.

### Command line usage

The tool can be used from command line as well. This can for example be used from  Automation scripts to get warned as soon as caches go out of sync.

Options:

- `-ui`

  Show the user interface (default when no host to connect to or no types to verify/fix).

- `-h host`

  Specifies a hostname/IP address to connect to.

- `-u username`

  Specifies a username.

- `-p password`

  Specifies a password.

- `-o outfile`

  Specifies a file where logging/output will be written.

- `-verify TypeName`

  Verifies for the given type. Multiple types can be specified through multiple -verify arguments. For example: -verify AlarmEventMessage

  Only applies when -ui is not present.

- `-fix TypeName`

  Automatically fixes the cache contents for the given type. Multiple types can be specified through multiple -fix arguments. Automatically adds -verify for these types. For example: -fix AlarmEventMessage

  Only applies when -ui is not present.

- `-help`

  Shows the different options.

When executed without UI, the tool returns error code `4402` when it has detected inconsistencies, and `0` otherwise.

Example command line:

```txt
VerifyClusterEvents.exe -h xxxxxxx -u xxxxxx -p xxxxxxx -fix AlarmEventMessage -o out.txt
```

### Example output

```txt
[1] [2018-04-09 14:11:18] VerifyClusterEvents Version 1.0.0.8
[1] [2018-04-09 14:11:18] Setting up connection to localhost as Administrator
[1] [2018-04-09 14:11:19] Setting up connection to localhost as Administrator DONE
[1] [2018-04-09 14:11:19] Getting agent list
[1] [2018-04-09 14:11:19] Initializing for Wouter (10.2.1.14/7)…
[15] [2018-04-09 14:11:19] Initializing for MSEDGEWIN10 (10.2.1.45/1)…
[1] [2018-04-09 14:11:19] Initializing for Wouter (10.2.1.14/7) DONE
[15] [2018-04-09 14:11:19] Initializing for MSEDGEWIN10 (10.2.1.45/1) DONE
[1] [2018-04-09 14:11:19] Verifying…
[1] [2018-04-09 14:11:19] Verifying AlarmEventMessage…
[1] [2018-04-09 14:11:19] Initializing for Wouter (10.2.1.14/7)… (AlarmEventMessage)
[1] [2018-04-09 14:11:19] Initializing for Wouter (10.2.1.14/7)… (AlarmEventMessage) DONE
[1] [2018-04-09 14:11:19] Initializing for MSEDGEWIN10 (10.2.1.45/1)… (AlarmEventMessage)
[1] [2018-04-09 14:11:19] Initializing for MSEDGEWIN10 (10.2.1.45/1)… (AlarmEventMessage) DONE
[1] [2018-04-09 14:11:19] INCONSISTENCY: Wouter (10.2.1.14/7) for MSEDGEWIN10 (10.2.1.45/1): 1 (-1)
[1] [2018-04-09 14:11:19] INCONSISTENCY: MSEDGEWIN10 (10.2.1.45/1) for Wouter (10.2.1.14/7): 1 (+1)
[1] [2018-04-09 14:11:19] All done
[1] [2018-04-09 14:11:19] Inconsistencies were detected (see above)
```

### Example screenshot

![Screenshot Verify Cluster Events Tool](~/user-guide/images/Verify_Cluster_Events_Tool.jpg)<br>
*Example of the Verify Cluster Events tool*
