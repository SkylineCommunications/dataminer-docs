---
uid: General_Main_Release_10.0.0_CU8
---

# General Main Release 10.0.0 CU8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube will now always connect to a DataMiner Agent via .NET Remoting \[ID_27354\] \[ID_27904\]

Up to now, DataMiner Cube could use either .NET Remoting or Web Services to connect to a DataMiner Agent. However, as Web Services Enhancements (WSE) for Microsoft .NET is now deprecated, from now on the only way for DataMiner Cube to connect to a DataMiner Agent is by using .NET Remoting.

As a result, in the *Settings* window, it is no longer possible to set the *Computer \> Connection \> Connection type* setting to “Web services”.

#### StandAloneBpaExecutor now supports asynchronous execution of BPA tests across a DMS \[ID_27652\]

The StandAloneBpaExecutor tool now supports asynchronous execution of one or more BPA tests across a DataMiner System.

#### BPA test metadata now indicates whether a test contains corrective actions \[ID_27704\]

The metadata of a BPA test now includes a HasCorrectiveActions property.

If a BPA test contains corrective actions, this property will be set to true.

#### Enhanced performance when processing alarm template actions \[ID_27706\]

Due to a number of enhancements, overall performance has increased when processing alarm template actions.

#### BPA test framework: New flag to indicate whether a test can be run against an offline agent in a Failover setup \[ID_27762\]

When you create a BPA test, you can now use the BpaFlags.CanRunOnOfflineAgents flag to indicate whether the test can be run against an offline agent in a Failover setup.

Default: False

#### Long running actions will now be canceled when a DataMiner upgrade finishes \[ID_27765\]

When a DataMiner upgrade finishes (successful or not), from now on, all remaining long running actions will be canceled.

#### DataMiner Cube: Enhanced performance when logging in and logging out \[ID_27851\]

Due to a number of enhancements, overall performance has increased when logging in and logging out, especially on large systems.

#### DataMiner Cube - Data Display: Background color of tree control table tabs has been adapted in order to enhance readability \[ID_27881\]

In the Skyline Black theme, the background color of tree control table tabs has been adapted in order to enhance readability.

#### Service & Resource Management: Deleting resources only allowed when all DMAs in the DMS are reachable \[ID_27921\]

From now on, you will only be allowed to delete resources when all agents in the DMS are reachable. This will prevent deleted resources from re-appearing when a DMA is started up again.

When you try to delete a resource, an error will now be returned in the following circumstances:

- When at least one agent is disconnected from the agent that hosts the resource you are trying to delete.
- When at least one agent is not in a running state.
- When there is at least one agent on which the ResourceManager module is not initialized.

#### BPA test framework: Abstraction layer added to allow backward compatibility of BPA tests \[ID_27988\]

An abstraction layer has now been added to the BPA test framework. This will prevent older tests from being rendered incompatible when changes are made to the framework.

#### SLNet.exe.config: TcpWebServicePort key will now be ignored \[ID_27990\]

As Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, in the appSettings section of the SLNet.exe.config file, the TcpWebServicePort key will now be ignored.

#### BPA tests can now be assigned a maximum DataMiner version \[ID_27997\]

When creating a BPA test, it is now possible to indicate the most recent DataMiner version on which the test will work.

When a DataMiner Agent is upgraded to a version equal to or above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version equal to or above the one specified in the MaxVersion setting.

### Fixes

#### DataMiner Cube - Visual Overview: Unnecessary subscription on property when highlight condition was configured based on name \[ID_27409\]

When a highlight condition was configured on a Visual Overview shape based on the name of an element, service or view, an unnecessary property subscription was also made. This will no longer occur.

#### Failover: Problem with SLSNMPManager \[ID_27599\]

During a Failover switch, in some cases, an error could occur in SLSNMPManager.

#### DataMiner Cube: When one client forcefully disconnected another client, the latter would incorrectly reconnect \[ID_27638\]\[ID_27671\]

When two different Cube clients were connected to the same DataMiner Agent, and one forcefully disconnected the other, up to now, that forceful disconnection would incorrectly be considered as abnormal, causing the disconnected client to immediately reconnect.

From now on, when one client forcefully disconnects another client, the disconnection will be treated as a forceful logout instead.

#### Problem with excessive memory usage of SLDataGateway and SLNet during DataMiner startup \[ID_27658\]

When a DataMiner Agent with a Cassandra database had experienced two days of high alarm activity, in some cases, SLDataGateway and SLNet would start to use excessive amounts of memory after DataMiner startup.

A number of enhancements have now been made to the way in which the alarm history is retrieved during a DataMiner startup.

#### DataMiner Cube - Visual Overview: Problem when clicking a connection line drawn based on table data \[ID_27692\]

In some cases, an exception could be thrown when you clicked a connection line that was drawn based on table data.

#### When users logged in with domain administrator credentials, they would incorrectly log in with the local administrator account instead \[ID_27713\]

In some cases, when users logged in with domain administrator credentials, they would incorrectly log in with the local, built-in administrator account instead.

#### Problem with SLDataMiner when importing a CSV file created with a previous DataMiner version \[ID_27722\]

When you imported a CSV file that was created with a previous DataMiner version, in some cases, an error could occur in SLDataMiner.

#### DataMiner Cube - Data Display: Trend icons would not be displayed until after a few minutes \[ID_27740\]

When you opened an element card, in some cases, trend icons in tables would not be displayed until after a few minutes.

#### DataMiner Cube - Protocols & Templates: An alarm template group would incorrectly not take into account the scheduling configured in the alarm templates in that group \[ID_27749\]

When an alarm template using scheduling was added to an alarm template group, in some cases, the alarm template group would not take into account the scheduling configured in that alarm template.

#### DataMiner - Router Control app: Newly selected input would be highlighted but not selected when the selected output was updated \[ID_27752\]

When, in the Router Control app, you had enabled the *Output first workflow* option, in some cases, when the selected output was updated by an external change, the newly selected input would be highlighted but incorrectly not selected.

Also, it will now be indicated more clearly that a highlighted IO button is selected.

#### Service & Resource Management: When a ReservationInstance was updated, the timeout scripts would incorrectly be executed instead of the expected event script \[ID_27757\]

When you updated an ongoing ReservationInstance, in some cases, all ongoing and future events (i.e. scripts) of that instance would incorrectly be canceled and the timeout scripts would be run on all DataMiner Agents instead.

#### DataMiner Cube: Element and parameter heat lines would incorrectly stay gray \[ID_27767\]

In the Alarm Console and in Reports pages of card, in some cases, element and parameter heat lines would incorrectly stay gray.

#### Problem when updating a DVE table while data exported via a virtual function was being retrieved \[ID_27768\]

In some cases, an error could occur when a DVE table was updated while data exported via a virtual function was being retrieved.

#### Alarms with a virtual function impact would not be regenerated when a virtual function was linked or unlinked via the generic linked table \[ID_27775\]

When a virtual function was linked or unlinked via the generic linker table, in some cases, alarms with a virtual function impact would not be regenerated.

#### Memory leak when using the Chromium browser engine in a browser version of DataMiner Cube \[ID_27789\]

When running a browser version of DataMiner Cube in Microsoft Internet Explorer, in some cases, a memory leak could occur when using the Chromium browser engine to e.g. visualize web pages in Visual Overview.

#### Alarm missing from service alarm table after enhanced service was renamed \[ID_27800\]

When an enhanced service was renamed while there was an alarm on multiple services, it could occur that this alarm was cleared from the alarm table of the enhanced service element.

#### DataMiner Cube - Service & Resource Management: Certain text boxes would not allow you to enter a zero character \[ID_27809\]

In certain text boxes, in some cases, it would not be possible to enter a zero character.

#### DataMiner Cube - Alarm Console: Problem when performing actions in rapid succession \[ID_27814\]

In the Alarm Console, in some cases, an exception could be thrown when certain actions were performed in rapid succession.

#### Problem with Protocol.Groups.Group.Content.Session@Next attribute \[ID_27820\]

In a Protocol.Groups.Group.Content.Session@Next attribute, you can specify the number of milliseconds DataMiner has to wait to execute the next session after receiving the response of the last executed session. In some cases, this setting would incorrectly be disregarded.

#### Alarm masked for a limited period of time would not be unmasked if the alarm template was updated while the alarm was masked \[ID_27838\]

When an alarm associated with a column parameter was masked for a limited period of time, in some cases, it would not be unmasked when that period of time elapsed if an alarm template update affecting the column parameter had occurred while it was masked.

#### Problem with automatic URI detection \[ID_27884\]

In some cases, an exception could be thrown during automatic URI detection.

#### DataMiner Cube: Problem when viewing a discrete profile parameter in the Profiles app \[ID_27888\]

In DataMiner Cube, in some cases, an error could occur when you viewed a discrete profile parameter in the Profiles app.

#### Problem when editing a protocol while a cluster synchronization was in progress \[ID_27890\]

In some rare cases, an error could occur when a protocol was edited while a cluster synchronization was in progress.

#### DataMiner Cube - Trending: Problem with trend groups containing invalid data \[ID_27892\]

In some cases, an exception could be thrown when a trend group contained invalid data.

#### DataMiner Cube - Bookings app: Memory leak when opening the Signal Path tab \[ID_27952\]

In some cases, DataMiner Cube could leak memory each time you opened the Signal Path tab when configuring a booking in the Bookings app.

#### DataMiner Cube - Visual Overview: Problem with SurveyorSearchText variable \[ID_27996\]

In some cases, making a shape display or set the Surveyor search text using the Surveyor-SearchText session variable would no longer work.

#### Service & Resource Management: Capacities property and Capabilities property of a Resource could incorrectly be set to null \[ID_28005\]

In some rare cases, the Capabilities property and the Capacities property of a Resource could incorrectly be set to null.

#### DataMiner Cube - Profiles app: Incorrect error message when Name text box is empty \[ID_28007\]

When the name of a profile definition or a profile instance was empty, in some cases, an incorrect error message would appear.

#### DataMiner Cube: Problem when the single, dynamically included element in a service was briefly excluded \[ID_28013\]

When a service contained a single, dynamically included element, in some cases, an exception could be thrown when the element was briefly excluded from the service.

#### Display values of rate alarms would have an unnecessary level of precision after an element restart on systems with a MySQL database \[ID_28028\]

On a system with a MySQL database, in some cases, display values of rate alarms would have an unnecessary level of precision after an element restart.

#### Value rate alarm not displayed correctly \[ID_28039\]

In some cases, it could occur that the value of a rate alarm was not displayed correctly. this could for instance occur after an element restart, after an element was masked, etc.

#### DataMiner Cube - Alarm Console: Error alarms could get stuck when a process had multiple threads with run-time errors \[ID_28113\]

In some cases, error alarms could get stuck in the Alarm Console when a process had multiple threads with run-time errors.

#### Problem in SLLog after stopping and reopening log file \[ID_28122\]

If a log file was stopped and then reopened shortly afterwards, a problem could occur in the SLLog process.
