---
uid: General_Feature_Release_10.5.2
---

# General Feature Release 10.5.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.2](xref:Web_apps_Feature_Release_10.5.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [Web visual overviews: Load balancing [ID 41434] [ID 41728]](#web-visual-overviews-load-balancing-id-41434-id-41728)
- [DataMiner Object Models: An exception will now be thrown when an issue occurs for any of the DomInstances that are created, updated, or deleted in bulk [ID 41546]](#dataminer-object-models-an-exception-will-now-be-thrown-when-an-issue-occurs-for-any-of-the-dominstances-that-are-created-updated-or-deleted-in-bulk-id-41546)

## New features

#### Unhandled exceptions in automation scripts that cause SLAutomation to stop working will now be logged and will lead to an alarm being generated [ID 41375] [ID 41781]

<!-- MR 10.5.0 - FR 10.5.2 -->

From now on, when SLAutomation stops working due to an unhandled exception that occurred in an Automation script, the stack trace of the unhandled exception will be logged in *SLAutomation.txt* and the following alarm of type "error" will be generated:

```txt
The automation script 'Script name' caused the hosting process SLAutomation.exe to crash. Please correct the script to prevent further system instability and check Automation log file for more details.
```

These alarms will be generated per DataMiner Agent for every Automation script that causes SLAutomation to stop working. In other words, when SLAutomation repeatedly stops working on a DataMiner Agent due to multiple unhandled exceptions thrown while running a particular Automation script, only one alarm will be generated on the DataMiner Agent in question.

This type of alarms will automatically be cleared after a DataMiner restart. They can also be cleared manually.

#### Web visual overviews: Load balancing [ID 41434] [ID 41728]

<!-- MR 10.5.0 [CU1]/10.6.0 [CU0] - FR 10.5.2 -->

It is now possible to implement load balancing among DataMiner Agents in a DMS for visual overviews shown in web apps.

Up to now, the DataMiner Agent to which you were connected would handle all requests and updates with regard to web visual overviews.

##### Configuration

In the `C:\Skyline DataMiner\Webpages\API\Web.config` file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

- `<add key="visualOverviewLoadBalancer" value="true" />`

  Enables or disables load balancing on the DataMiner Agent in question.

  - When this key is set to **true**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will by default be handled in a balanced manner by all the DataMiner Agents in the cluster.

    However, if you also add the `dmasForLoadBalancer` key (see below), these requests and updates will only be handled by the DataMiner Agents specified in that `dmasForLoadBalancer` key.

  - When this key is set to **false**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will be handled by the local SLHelper process.

- `<add key="dmasForLoadBalancer" value="1;2;15" />`

  If you enabled load balancing by setting the `visualOverviewLoadBalancer` key to true, you can use this key to restrict the number of DataMiner Agents that will be used for visual overview load balancing.

  The key's value must be set to a semicolon-separated list of DMA IDs. For example, if the value is set to "1;2;15", the DataMiner Agents with ID 1, 2, and 15 will be used to handle all requests and updates with regard to web visual overviews.

  If you only specify one ID (without trailing semicolon), only that specific DataMiner Agent will be used to handle all requests and updates with regard to web visual overviews.

> [!NOTE]
> These settings are not synchronized among the Agents in the cluster.

##### New server messages

The following new messages can now be used to  which you can target to be sent to other DMAs in the cluster:

- `TargetedGetVisualOverviewDataMessage` allows you to retrieve a Visual Overview data message containing the image and the content of a visual overview.

- `TargetedSetVisualOverviewDataMessage` allows you to execute actions on a visual overview that is rendered on a specific DataMiner Agent.

> [!NOTE]
> DataMiner Agents will now automatically detect that a visual overview they are rendering has been updated. This means that other agents in the cluster will now be able to correctly process update events and request new images for their clients.

##### Logging

Additional logging with regard to visual overview load balancing will be available in the web logs located in the `C:\Skyline DataMiner\Logging\Web` folder.

#### Information events of type 'script started' will no longer be generated when an Automation script is triggered by the Correlation engine [ID 41653]

<!-- MR 10.6.0 - FR 10.5.2 -->

From now on, by default, information events of type "script started" will no longer be generated when an Automation script is triggered by the Correlation engine.

In other words, when an Automation script is triggered by the Correlation engine, the SKIP_STARTED_INFO_EVENT:TRUE option will automatically be added to the `ExecuteScriptMessage`. See also [Release note 33666](xref:General_Feature_Release_10.2.8#added-the-option-to-skip-the-script-started-information-event-id-33666).

If you do want such information events to be generated, you can add the `SkipInformationEvents` option to the *MaintenanceSettings.xml* file and set it to false:

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
    ...
    <SLNet>
        ...
        <SkipInformationEvents>false</SkipInformationEvents>
        ...
    </SLNet>
    ...
</MaintenanceSettings>
```

#### DataMiner upgrade: New upgrade action 'UpdateSrmContributingProtocolsForSwarming' [ID 41706]

<!-- MR 10.6.0 - FR 10.5.2 -->

On systems on which Swarming has been enabled, contributing bookings are not working because protocols of enhanced services do not have a parameter with ID 7.

During a DataMiner upgrade, a new upgrade action named *UpdateSrmcontributingProtocolsForSwarming* will now check for generated service protocols that do not have a parameter with ID 7. If such protocols exist, the parameter in question will be added to them.

When the above-mentioned upgrade action is executed, it will log the name and the version of every protocol to which it has added a parameter with ID 7. It will also log a warning for every corrupt protocol it has found.

> [!NOTE]
> From now on, newly generated service protocols will by default have a parameter with ID 7.

## Changes

### Breaking changes

#### DataMiner Object Models: An exception will now be thrown when an issue occurs for any of the DomInstances that are created, updated, or deleted in bulk [ID 41546]

<!-- MR 10.5.0 - FR 10.5.2 -->

From now on, if an issue occurs for any of the `DomInstances` that are getting created, updated, or deleted in bulk (e.g. validation), a `BulkCrudFailedException<DomInstanceId>` will be thrown. The `Result` property in the exception can be used to check for which `DomInstances` the call succeeded or failed. For information on how to implement this flow, refer to the [Checking issues example](xref:DOM_BulkProcessing_Examples#checking-issues).

As an alternative, the `TryCreateOrUpdate` or `TryDelete` methods can be used. When the operation fails for one of the `DomInstances`, those calls will return false. The `result` output parameter will contain:

- The list of successfully processed items, as is the case for `CreateOrUpdate` and `Delete`.

- A list of `DomInstance` IDs that failed to be created, updated, or deleted.

- The trace data per `DomInstance` ID.

For each of these methods, the trace data of that call is still available and will contain the trace data for all processed `DomInstances`.

> [!IMPORTANT]
> In DataMiner versions prior to DataMiner Feature Release 10.5.0/10.5.2, when any validation issue occurs, no exception is thrown (even when `ThrowExceptionsOnErrorData` is true) when calling the `CreateOrUpdate` or `Delete` methods. Instead, the result of the call should be used to check for which `DomInstances` the call succeeded or failed.

> [!NOTE]
> When creating, updating or deleting a single `DomInstance`, you can now also use the `TryCreate`, `TryUpdate` and `TryDelete` methods as an alternative in order to avoid having to check for exceptions. These methods are also available for other objects that make use of the CRUD helper component.

### Enhancements

#### Failover - Virtual IP address check: Logging of the arp command will now also include the MAC address that claimed the IP address [ID 40703]

<!-- MR 10.5.0 - FR 10.5.2 -->

Since Main Release 10.3.0 [CU20]/10.4.0 [CU8] and Feature Release 10.4.11, the virtual IP address check uses both a ping and an arp command to check whether an IP address is free.

The logging of the arp command will now also include the MAC address that claimed the IP address.

#### DataMiner upgrade packages now include the latest Visual C++ Redistributable [ID 41173]

<!-- MR 10.5.0 - FR 10.5.2 -->

All DataMiner upgrade packages now include the latest Visual C++ Redistributable.

> [!NOTE]
> From now on, after having upgraded a DataMiner Agent, the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\Files\x64` folders will no longer contain any individual Visual C++ Redistributable DLL files.

#### DataMiner Taskbar Utility: 'Launch > Download DataMiner Cube' command will now download the DataMiner Cube desktop app [ID 41308]

<!-- MR 10.6.0 - FR 10.5.2 -->

When you right-clicked the *DataMiner Taskbar Utility* icon in the system tray, and then clicked *Launch > DataMiner Cube*, up to now, the DataMiner Taskbar Utility would incorrectly still try to launch the deprecated XBAP version of DataMiner Cube.

From now on, when you click *Launch > Download DataMiner Cube*, the DataMiner Cube desktop app will be downloaded. When you then double-click the downloaded file, the following will happen:

- When the DataMiner Cube desktop app is installed, the DataMiner Cube desktop app will open and a tile representing the local DMA will be added to it (if no such tile already exists).

  If you then want to open a Cube session connected to the local DMA, click the tile representing the local DMA.

- When the DataMiner Cube desktop app has not yet been installed, you will be asked whether it should be installed or not. If you choose to install it, it will be installed and immediately opened to host a Cube session connected to the local DMA.

#### Security Advisory BPA test: Enhancements [ID 41385]

<!-- MR 10.5.0 / 10.4.0 [CU11] - FR 10.5.2 -->

A number of minor enhancements have been made to the *Security Advisory* BPA test.

#### Service & Resource Management: More detailed trace data will now be returned when a quarantine conflict occurs [ID 41399]

<!-- MR 10.6.0 - FR 10.5.2 -->

The trace data that is returned when a booking is moved to quarantine will now include more detailed information.

The `QuarantineTrigger` object will now contain a `ReservationConflictType` property, which will contain one of the following reasons why bookings were moved to quarantine following a booking update:

- ConcurrencyOverflow: A resource does not have enough concurrency to support all bookings.
- CapacityOverflow: A resource does not have enough capacity to support all bookings.
- UnavailableCapability: The booking tries to book a capability that is not available on the resource.
- UnavailableTimeDependentCapability: The booking tries to book a time-dependent capability that is not available on the resource because another overlapping booking has already booked a different value.

The string representation of the trace data has also been adjusted to provide more details. This string is logged in *SLResourceManager.txt* when a request has trace data in the response as well as in the booking log file of the SRM solution.

#### DataMiner upgrade: '.dmapp' and '.dmprotocol' will now by default be added to the list of MIME types in 'C:\\Skyline DataMiner\\Webpages\\web.config' [ID 41469]

<!-- MR 10.6.0 - FR 10.5.2 -->

During a DataMiner upgrade, the ".dmapp" and ".dmprotocol" file extensions will now by default be added to the list of MIME types in the `C:\Skyline DataMiner\Webpages\web.config` file.

#### Security enhancements [ID 41475]

<!-- 41475: MR 10.6.0 - FR 10.5.2 -->

A number of security enhancements have been made.

#### History Manager: A clearer exception will now be thrown when the History Manager API is used after the History Manager has been stopped [ID 41500]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When the History Manager API was used to perform create, update or delete operations after the History Manager had been stopped, up to now, a `NullReferenceException` would be thrown.

From now on, when the History Manager API is used after the History Manager has been stopped, the following `DataMinerException` will be thrown and logged:

`There is no known manager that can process objects for Manager X. Check if the manager has been initialized, the agent is licensed and is using the required database.`

#### SLLogCollector packages now also contain information about the NATS connections that were closed [ID 41504]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

SLLogCollector packages now also include the *ClosedConnections.json* file, which contains information about the NATS connections that were closed.

#### DataMiner Object Models: An information event will no longer be generated when a DOM CRUD or DOM Action script is started [ID 41536]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, a "Script started" information event would be generated each time a DOM CRUD script or DOM Action script was started. From now on, these information events will no longer be generated.

#### Protocols: Enhanced protection of table data [ID 41539]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, when a protocol performed multiple actions on a table, SLProtocol would not properly lock the array in which the data was stored. This could then lead to concurrent access to the array, causing the entries to get corrupted and SLProtocol to stop working when those corrupted entries were accessed.

The above-mentioned array will now be locked to prevent the data from getting corrupted.

#### Service & Resource Management: Property updates and swarming requests sent to the old master agent will now be resent to the new master agent [ID 41549]

<!-- MR 10.5.0 - FR 10.5.2 -->

Since DataMiner feature release 10.4.11, it is possible to switch to another master agent.

Up to now, if the current master agent had been marked "not eligible to be promoted to master", it would continue to process property updates and swarming requests as if it were still master agent. This behavior has now changed. From now on, all property updates and swarming requests sent to the current master agent that has been marked "not eligible to be promoted to master" will fail with a `NotAMasterAgentException`, and the agents that sent those messages will resend them to the new master agent.

#### DataMiner Object Models: Number of DomInstanceIds in SectionDefinitionErrors now limited to 100 [ID 41572]

<!-- MR 10.6.0 - FR 10.5.2 -->

When, in a `SectionDefinition`, an enum entry is removed from a `FieldDescriptor`, a check is performed to make sure that entry is not being used by a `DomInstance`. This check reads all DomInstances that use that entry and places the IDs in the error data. However, as this check verifies all existing DomInstances, this could cause memory issues in SLNet when a large number of DomInstances were using the removed enum entry.

From now on, a maximum of 100 DomInstances will be included in the error data. For example, when an enum entry is removed from a `FieldDescriptor`, and 150 DomInstances are using the entry, the error message will only contain the IDs of the first 100 DomInstances.

#### Storage as a Service: Enhanced performance when updating alarm information [ID 41581]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, overall performance has increased when updating alarm information on STaaS systems.

#### DataMiner Cube server-side search engine: Enhanced performance [ID 41643]

<!-- MR 10.4.0 [CU11]/10.5.0 - FR 10.5.2 -->

Because of a number of enhancements, overall performance of the DataMiner Cube server-side search engine has increased.

#### Clearer error message when generating a PDF report based on a dashboard fails [ID 41661]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In the *Automation*, *Correlation* and *Scheduler* modules, you can generate a PDF report based on a dashboard.

When an error occurred while generating the PDF file, up to now, the following error message would be logged in the log file of *Automation*, *Correlation* or *Scheduler*:

```txt
2024/12/09 08:45:02.635|SLScheduler.exe 10.5.2449.76|27128|26140|CRequest::Request|ERR|5|Remote Request for -SLNet- on -VT_EMPTY- failed.  (hr = 0x8013150C)
Type 126/0/0
MESSAGE: Type 'Skyline.DataMiner.Net.ReportsAndDashboards.ReportsAndDashboardsException' in Assembly 'SLNetTypes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9789b1eac4cb1b12' is not marked as serializable.
```

A clearer error message will now be logged. The `ReportsAndDashboardsException` has been marked as serializable.

#### SLLogCollector packages can now include a memory dump of the w3wp process in case of web API issues [ID 41664]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

From now on, SLLogCollector packages can also include a memory dump of the *w3wp* process in case of web API issues.

#### EPM systems: Enhanced performance when aggregating large datasets [ID 41685]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, on EPM systems, overall performance has increased when aggregating large datasets.

#### Storage as a Service: Timeout for responses to write requests has been reduced to 10 seconds [ID 41717]

<!-- MR 10.5.0 - FR 10.5.2 -->

On STaaS systems, the timeout for responses to write requests has been reduced to 10 seconds.

### Fixes

#### Issue in SLNet could cause errors to be thrown in low-code apps [ID 40978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.2 -->

Because of an issue in SLNet, after a restart of a DataMiner Agent, "not supported by the current server version" errors could get thrown in all low-code apps.

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41339]

<!-- MR 10.4.0 [CU12] - FR 10.5.2 -->

In some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When synchronizing users from an LDAP/ActiveDirectory domain, DataMiner would not correctly process the result.

#### SLNet could stop working due to NATS throwing an exception [ID 41396]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLNet could stop working due to NATS throwing an exception.

#### Parameter values that were never updated would incorrectly not be sent to a client application [ID 41414]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, parameter values would incorrectly not be sent to a client application, especially when those values were never updated.

#### NT_FILL_ARRAY_WITH_COLUMN call would silently fail when providing a string[] instead of an object[] for the keys and values [ID 41511]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When an NT_FILL_ARRAY_WITH_COLUMN call was performed in a QAction, up to now, it would silently fail when providing a string[] (or any other type of object that is allowed in an object[]) instead of an object[] for the keys and values. This would also affect all wrapper methods that accept an object[] argument.

A cast and type check has now been added to the following calls in order to prevent this type mismatch issue from going unnoticed:

- `protocol.FillArrayWithColumn(...)`
- `protocol.FillArray(...)`
- `protocol.FillArrayNoDelete(...)`
- `protocol.NotifyProtocol(220, ...)`

From now on, when an invalid type is passed to one of these methods, the error that is thrown will automatically be logged in the element's log file.

#### Problem with SLDataMiner when deleting a connector [ID 41520]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLDataMiner could stop working when a connector was deleted immediately after an element using that connector had been deleted.

#### DataMiner would use an incorrect IP address when connecting to BrokerGateway during startup [ID 41530]

<!-- MR 10.5.0 - FR 10.5.2 -->

During startup, in some cases, DataMiner would use an incorrect IP address when connecting to BrokerGateway.

#### Cassandra compaction settings would incorrectly be overwritten at DataMiner startup [ID 41551]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Up to now, all Cassandra compaction settings would incorrectly be overwritten at DataMiner startup.

For example, if you had manually configured a compaction setting (e.g. *unsafe_aggressive_sstable_expiration*), this change would get overwritten by the default setting.

#### DataMiner Maps: Markers that did not match the alarm level filter would become visible for a split second [ID 41555]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you zoomed to a different layer while an alarm level filter was active, in some cases, markers that did not match the filter would become visible for a split second before disappearing again.

#### Service & Resource Management: Debug lines would incorrect get logged multiple times in SLResourceManagerScheduler.txt [ID 41568]

<!-- MR 10.5.0 - FR 10.5.2 -->

While the booking scheduler task queue was being processed, in some cases, debug lines would incorrectly get logged multiple times in the *SLResourceManagerScheduler.txt* log file.

#### SLDataMiner will now check BrokerGateway soft-launch option in order to decide which NATS services to start [ID 41570]

<!-- MR 10.5.0 - FR 10.5.2 -->

At DataMiner startup, SLDataMiner will now check the `C:\Skyline DataMiner\SoftLaunchOptions.xml` file to determine whether the *BrokerGateway* soft-launch option is enabled or not.

- If the *BrokerGateway* soft-launch option is **enabled**, it will start the **nats-server service**.
- If the *BrokerGateway* soft-launch option is **disabled**, it will start the **NAS and NATS services**.

#### DataMiner installer: Problem when upgrading a Hotfix or Cumulative Update version to Feature Version 10.5.1 [ID 41579]

<!-- MR 10.5.0 - FR 10.5.2 -->
<!-- Not added MR 10.5.0. CloudFeed added to DataMiner upgrade packages in 10.5.0/10.5.1 (RN 41357)  -->

When DataMiner was upgraded from an older Hotfix or Cumulative Update version to Feature Version 10.5.1, the following would happen:

- An error would occur when trying to parse the version number of the Hotfix or Cumulative Update.

- When checking the DataMiner version, the CloudFeed DxM installer would incorrectly check the current DataMiner version instead of the new DataMiner version.

#### Problems with SLNet call GetProtocolQActionsStateRequestMessage [ID 41591]

<!-- MR 10.6.0 - FR 10.5.2 -->
<!-- Not added to MR 10.6.0 - Introduced by RN 41218 -->

In DataMiner Feature Release 10.5.1, a new SLNet call `GetProtocolQActionsStateRequestMessage` was introduced to retrieve the compilation warnings and errors of a given protocol and version.

Up to now, the following issues could occur when using this SLNet call:

- SLDataMiner could stop working when the DataMiner Agent did not have any elements.
- QActions containing code other than CSharp would incorrectly also be validated, resulting in errors to be thrown.

From now on, no QAction validation will be performed when the DataMiner Agent does not contain any elements, and the validation of any QAction containing code other than CSharp will return "OK".

> [!NOTE]
> The above-mentioned SLNet message is subject to change without notice.

#### NATS: A large number of "duplicate route" and "created route" entries would get added to the NATS server logging [ID 41616]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When a large DataMiner System included agents in a Failover setup, the more agents were present in this DMS, the more "duplicate route" and "created route" entries would get added to the NATS server logging.

#### Invalidated property configuration objects in the SLNet cache would incorrectly not be set to null [ID 41687]

<!-- MR 10.6.0 - FR 10.5.2 -->
<!-- Not added to MR 10.6.0 - Introduced by RN 41169 -->

When Class Library retrieves property configurations of type element, service or view, these get cached in SLNet, and when a configuration is added or updated, the cached object associated with that configuration is invalidated.

Up to now, when a cached view, element or service property configuration object was invalidated, it would incorrectly not be set to null.

#### Swarming: Problem with alarm events associated with DVE elements [ID 41741]

<!-- MR 10.6.0 - FR 10.5.2 -->
<!-- Not added to MR 10.6.0 - Introduced by RN 41392 -->

On systems on which the *Swarming* feature had been enabled, in some cases, alarm events associated with DVE elements would not show up in the connected clients or would not end up in the database.
