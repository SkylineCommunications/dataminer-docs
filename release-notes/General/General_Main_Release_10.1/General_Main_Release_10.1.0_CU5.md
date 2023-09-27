---
uid: General_Main_Release_10.1.0_CU5
---

# General Main Release 10.1.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_29980\] \[ID_30012\] \[ID_30195\]

A number of security enhancements have been made.

#### Enhanced performance when executing offloaded database operations against a Cassandra or Elasticsearch database \[ID_29451\] \[ID_29857\]

Due to a number of enhancements, overall performance has increased when executing Cassandra and Elasticsearch database operations that were offloaded to a file when the database was unavailable.

> [!NOTE]
> While executing database operations that were offloaded to a file when the database was unavailable, an information event and a log entry will be created every 30 seconds to indicate the execution progress.

#### Limiting disk space occupied by offload files \[ID_29563\]

In the C:\\Skyline DataMiner\\Database\\DBConfiguration.xml file, you can now specify the maximum amount of disk space that can be occupied by database offload files.

Example:

```xml
<DatabaseConfiguration>
  <FileOffloadConfiguration>
    <MaxSizeMB>10</MaxSizeMB>
  </FileOffloadConfiguration>
</DatabaseConfiguration>
```

> [!NOTE]
>
> - If no DBConfiguration.xml file exists in C:\\Skyline DataMiner\\Database, then create one with the content of the example above.
> - If no limit is set in DBConfiguration.xml or if the file offload configuration is invalid, the size of the database offload files will by default be limited to 10 GB.
> - When the specified limit has been reached, an alarm with the following text will be generated: “Max file offload disk usage for certain storages has been reached, new data for these storages will be dropped.” Also, the following entry will be added to the SLDBConnection log file: “\|INF\|0\|112\|2021-04-14T13:34:19.559\|DEBUG\|DataGateway.FileOffload\|Max disk usage reached: True for storage Cassandra.TimeTrace (timetrace)”.

#### Enhanced handling of stack overflow exceptions \[ID_29796\]

A number of enhancements have been made to better handle stack overflow exceptions.

#### Smart-serial client connections: Logging incoming data \[ID_29874\]

When a smart-serial client connection receives incoming data, it will forward that data to SLProtocol and display it in Stream Viewer. However, when the incoming data does not match the configured response, the connection will forward TIMEOUT to SLProtocol, making it hard to find out what data was received by SLPort.

From now on, if you enable a specific connection in PortLog.txt (see DataMiner Help) and set SLPort debug logging to level 4 or higher, log entries like the one below will be added to SLPort.txt. These entries contain the IP address and port of the server, the size of the incoming data and the data itself.

```txt
2021/05/14 15:30:57.452|SLPort.exe 8.5.1519.6|39680|39544|CSmartIP::ProcessIncomming|DBG|4|Incoming data from 127.0.0.2:4598 (total length: 5 bytes) -    000000  576F72642E                                   Word.
```

#### SLUpgrade can now run BPA tests before starting the upgrade process \[ID_29903\]

When a DataMiner upgrade package contains a set of BPA tests in its Prerequisites folder, SLUpgrade will now run those tests before starting the upgrade process. Upon failure of one or more of these tests, the upgrade process will be aborted and a message will be displayed.

The BPA tests run before the start of an upgrade process will generally be tests designed to check whether the system meets the requirements necessary to upgrade to the new DataMiner version.

BPA tests added to the Prerequisites folder of a DataMiner upgrade package must comply to the following rules:

- They must have their CanRunOnOfflineAgents flag enabled. This will make sure that, in a Failover setup, the offline agent will also be checked.

- They must have their RequireSLNet flag disabled.

#### Enhanced performance when exporting function protocols \[ID_29929\]

When you uploaded a new version of a protocol that had an active functions file, up to now, all active function elements would be re-evaluated after the function protocols were exported. From now on, the function elements will only be re-evaluated when the function file is set to active.

#### Enhanced logging of parameter update stack notices \[ID_29996\]

Up to now, when the number of items on the parameter update stack was divisible by 1000 after an item had been added to it, a log entry would be added to the log file of the element for which that last item had been added. As a result, parameter update stack notices would be scattered among different log files.

From now on, when the parameter update stack exceeds 5000 items, log entries will be added to the log files of all elements for which there are items on the stack. Also, similar log entries will be added to the same log files each time the number of items on the stack is divisible by 1000 until the number of items on the stack drops below 1000.

#### DataMiner backup packages will now also include the SoftLaunchOptions.xml file \[ID_30076\]

From now on, DataMiner backup packages will also include the SoftLaunchOptions.xml file.

#### Enhanced performance when updating user information \[ID_30102\]

Due to a number of enhancements, overall performance has increased when updating user information, especially on systems with a large number of users.

#### DataMiner Cube: 'DataMiner Cube mobile' changed to 'DataMiner web apps' \[ID_30201\]

Throughout the Cube UI, the term “DataMiner Cube mobile” has been replaced by the term “DataMiner web apps”.

#### DataMiner Cube - Data Display: Service cards now also support conditional page visibility \[ID_30217\]

In a protocol.xml file, it is possible to specify that a Data Display page should either be shown or hidden based on a parameter value. Service cards now also support this feature.

#### BPA test 'Report Active RTE' will now run more frequently \[ID_30250\]

The BPA test “Report Active RTE” will now run once every 8 minutes instead of once every hour.

#### Updated BPA tests: 'Minimum Requirements Check' & 'View Recursion' \[ID_30259\]

The following default BPA tests were updated:

- Minimum Requirement Checker: Name changed to “Minimum Requirements Check”

- View Recursion: Description updated

### Fixes

#### DMS Alerter: Problem when closing Alerter while balloons are popping up \[ID_29725\]

In some cases, an exception could be thrown when you closed Alerter while balloons were popping up.

#### SLDataMiner: High-level log entries would incorrectly not get added to the log after increasing the log level \[ID_29781\]

When you increased the log level of SLDataMiner, high-level log entries would incorrectly not get added to the log.

#### DataMiner Cube - Visual Overview: Problem with SelectionSetVar option \[ID_29797\]

When, in Visual Overview, a table control had the SelectionSetVar option specified, in some cases, it would not be possible to select a row.

#### Cassandra: 'tried to execute null statement' errors incorrectly added to SLDBConnection.txt log file \[ID_29947\]

On systems with a Cassandra database, errors similar to the one below would incorrectly be added to the SLDBConnection.txt log file:

```txt
[timestamp]|SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|335|Cassandra: tried to execute null statement.
```

#### DataMiner Cube - Visual Overview: Problem when using the FollowPathColor option \[ID_29959\]

In some cases, using the FollowPathColor option would cause Cube to become unresponsive.

#### Dashboards app - Group component: Visualizations would incorrectly be removed when opening the Layout tab \[ID_29962\]

When you opened the Layout tab of a Group component, in some cases, the visualizations will incorrectly be removed.

#### Data offloading would incorrectly be disabled when saving the settings of the offload database \[ID_29985\]

When, in DataMiner Cube, you saved the settings of the offload database, the settings for offloading the real-time trend data would not be applied correctly. As a result, offloading would be disabled until the DataMiner Agent was restarted.

#### Part of SLNet initialization could be skipped when a client disconnected while the DMA was starting up \[ID_29986\]

When a client disconnected while the DMA was starting up, in some rare cases, part of the initialization of the SLNet process could get skipped, which would lead to issues later on. Up to now, the error would only be added to the logs. From now on, in cases like this, the following will happen:

- When a client cannot be re-registered during the SLNet initialization, an entry will be added to the logs, but the initialization will no longer fail.

- Any exception thrown during the SLNet initialization will now also show up in the Alarm Console as “Unexpected Exception \[Initialize DMA\]: xxxxxx”

#### Interactive Automation scripts: Only the value added in the last text box would be saved \[ID_29995\]

When, in interactive Automation scripts, you rapidly entered values in multiple text boxes, in some rare cases, only the value entered in the last text box would be saved.

#### Stopping an SLA would cause a 'window change' event that would lead to outages being closed when history set alarms were received \[ID_29998\]

When an SLA is stopped while it has an open outage, the open outage will be closed with a timestamp containing the time at which the SLA was stopped. This ensures that all outages are closed in case the SLA starts again when no impacting alarms are present to open and later close the outage.

However, this event would be logged as a “window change”, causing the SLA to close and reevaluate the current alarms at the time the SLA was stopped whenever a history set alarm was received with a timestamp earlier than the time at which the SLA was stopped. This would then cause extra non-intended outages.

#### Interactive Automation scripts: Values shown in datetime controls would be out of sync with the values sent to the server \[ID_30015\]

In interactive Automation scripts, in some rare cases, the value shown in a datetime control would be out of sync with the value sent to the server. Also, in some cases, datetime controls could trigger updates even when their WantsOnChange property was set to false.

#### Synchronization of a cleared DMS.xml file would incorrectly cause all agents to remove themselves from the DataMiner System \[ID_30023\] \[ID_30163\]

When a DataMiner Agent is starting up, it checks whether the DMS.xml file was changed while it was down. If changes are found, these are then synchronized among the other agents in the DataMiner System. However, up to now, when the DMS.xml file had been cleared and only contained either the IP address of the DataMiner Agent that was starting up or the name of the DataMiner System, this would incorrectly cause a cascade of delete operations throughout the DataMiner System, resulting in all the agents slowly removing themselves from the DataMiner System.

Also, when an outdated cluster configuration was left on a standalone DataMiner Agent after manually removing the DMS.xml file or after restoring a DataMiner backup, other agents in the DataMiner System could be triggered to leave the DataMiner System once the standalone agent was re-added to the cluster.

#### Failover: Network interface would not properly release the virtual IP address when being re-attached after being disconnected during a Failover switch \[ID_30033\]

When a network interface was disconnected or disabled during a Failover switch, in some cases, it would not properly release the virtual IP address when it was re-attached.

#### InstanceAlarmLevel would not fall back to CellActualAlarmLevel when there was bubble-up information but no instance information \[ID_30044\]

In case of a view table with bubble-up information and view columns with alarm information, up to now, the InstanceAlarmLevel property on the primary key cell would incorrectly be set to “Undefined” instead of the highest severity of those columns.

#### DataMiner Cube - Alarm Console: Problem when reconnecting after adding the 'Severity Duration' column \[ID_30099\]

When, in the Alarm Console, you added the Severity Duration column and then reconnected, on a large DataMiner System, Cube could become unresponsive.

#### Problem with SLNet during upgrade \[ID_30103\]

During a DataMiner upgrade, in some rare cases, a problem could occur in the cleanup connection thread of SLNet.

#### BPA tests could fail with a 'BPA has an invalid signature' error \[ID_30118\]

On DataMiner Agents on which the latest Windows updates had not been installed, in some cases, BPA tests would fail with the following error:

```txt
BPA has an invalid signature
```

Also, the following entry would be added to the SLBpaManager.txt log file at DataMiner startup:

```txt
Ignoring certificate SkylineCodeSigning.cer: Certificate is not trusted by the machine
```

From now on, BPA tests that are signed with the Skyline code signing certificate will be forcefully loaded, and the following entry will be added to the SLBpaManager.txt log file:

```txt
Force loaded certificate: SkylineCodeSigning.cer (Skyline Certificate). WARNING! Machine might not have latest Windows Updates.
```

#### SNMPv1/SNMPv2 element could remain in a timeout state after its IP address had been first set to a non-existing address and then to its original address \[ID_30123\]

When you change the IP address of an SNMPv1 or SNMPv2 element that is polled using a “dynamic IP” parameter to a non-existing address, the element will go into timeout as it tries to poll that non-existing IP address. However, up to now, when you then changed the IP address back to the one the element had before, it would incorrectly remain in timeout until it was restarted.

Also, from now on, when an SNMP-related failure occurs, the log entry will include the error code. Where previously a log entry like “Unable to set destination port” would be added, DataMiner will now add a log entry like “Unable to set destination port (error code: 3)”.

#### DataMiner Cube - Backup: Users without 'Backup \> Configure' permission would incorrectly be allowed to update the 'Indexing Engine location' backup path \[ID_30131\]

In the *Backup* section of *System Center*, users without *Modules \> System configuration \> Backup \> Configure* permission would incorrectly be allowed to update the *Indexing Engine location* backup path.

#### DataMiner Cube - Scheduler: Users with permission to add tasks but not to edit them would not be able to save a newly created task \[ID_30132\]

When, in the Scheduler app, users created a new scheduled task, they were not able to save that task when they had permission to add tasks but not to edit them.

#### NATS logfile_size_limit setting would not automatically be added after a DataMiner upgrade \[ID_30146\]

When a DataMiner Agent using NATS was upgraded to a version containing the logfile_size_limit setting, that setting would not automatically be added to the nats-server.config file in the C:\\Skyline DataMiner\\NATS\\nats-streaming-server folder. It would only be added the first time you manually sent a NatsCustodianRestartNatsRequest message.

From now on, when a DataMiner Agent starts up after being upgraded and the nats-server.config does not contain the logfile_size_limit setting, it will be added at SLNet startup. Its value will by default be set to 10 MB.

#### DataMiner Cube - Users/Groups: Duplicate activity log entries \[ID_30162\]

When, in the *Users/groups* section of *System Center*, you opened a user card and selected the *Activity* tab, in some cases, the list would contain duplicate activity log entries.

#### DataMiner Cube - Visual Overview: Button to navigate to another card would no longer work after clicking the Back button \[ID_30167\]

When, on a visual overview, you clicked a button to navigate to another card and then clicked the Back button, in some cases, clicking the button to navigate to another card a second time would no longer open that other card.

#### SLLogCollector: Problem when process list update took longer than 1 second \[ID_30203\]

When SLLogCollector updated its list of processes, it would incorrectly try to update it again when the update took longer than 1 second.

#### DataMiner Cube: Not possible to unmask a masked EPM object \[ID_30208\]

In some cases, it would not be possible to unmask a masked EPM object. When you right-clicked, the shortcut menu’s *Unmask* command would incorrectly be disabled.

#### Service & Resource Management: Problem due to ReservationInstance locks not getting released \[ID_30281\]

When executing the start actions of a ReservationInstance, DataMiner locks that instance. In some cases, that lock would not get released, causing other operations involving that same instance or even the SLAutomation process to get blocked.
