---
uid: General_Feature_Release_10.5.2
---

# General Feature Release 10.5.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.2](xref:Web_apps_Feature_Release_10.5.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Unhandled exceptions in Automation scripts that cause SLAutomation to stop working will now be logged and will lead to an alarm being generated [ID 41375]

<!-- MR 10.5.0 - FR 10.5.2 -->

From now on, when SLAutomation stops working due to an unhandled exception that occurred in an Automation script, the stack trace of the unhandled exception will be logged in *SLAutomation.txt* and an alarm of type "error" will be generated.

These alarms will be generated per DataMiner Agent for every Automation script that causes SLAutomation to stop working. In other words, when SLAutomation repeatedly stops working on a DataMiner Agent due to multiple unhandled exceptions thrown while running a particular Automation script, only one alarm will be generated on the DataMiner Agent in question.

This type of alarms will automatically be cleared after a DataMiner restart. They can also be cleared manually.

## Changes

### Enhancements

#### Failover - Virtual IP address check: Logging of the arp command will now also include the MAC address that claimed the IP address [ID 40703]

<!-- MR 10.5.0 - FR 10.5.2 -->

Since Main Release 10.3.0 [CU20]/10.4.0 [CU8] and Feature Release 10.4.11, the virtual IP address check uses both a ping and an arp command to check whether an IP address is free.

The logging of the arp command will now also include the MAC address that claimed the IP address.

#### DataMiner upgrade packages now include the latest Visual C++ Redistributable [ID 41173]

<!-- MR 10.6.0 - FR 10.5.2 -->

All DataMiner upgrade packages now include the latest Visual C++ Redistributable.

> [!NOTE]
> From now on, after having upgraded a DataMiner Agent, the *C:\\Skyline DataMiner\\Files* and *C:\\Skyline DataMiner\\Files\\x64* folders will no longer contain any individual Visual C++ Redistributable DLL files.

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

During a DataMiner upgrade, the ".dmapp" and ".dmprotocol" file extensions will now by default be added to the list of MIME types in the *C:\\Skyline DataMiner\\Webpages\\web.config* file.

#### Security enhancements [ID 41475]

<!-- 41475: MR 10.6.0 - FR 10.5.2 -->

A number of security enhancements have been made.

#### History Manager: A clearer exception will now be thrown when the History Manager API is used after the History Manager has been stopped [ID 41500]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When the History Manager API was used to perform create, update or delete operations after the History Manager had been stopped, up to now, a `NullReferenceException` would be thrown.

From now on, when the History Manager API is used after the History Manager has been stopped, the following `DataMinerException` will be thrown and logged:

`There is no known manager that can process objects for Manager X. Check if the manager has been initialized, the agent is licensed and is using the required database.`

#### DataMiner Object Models: An information event will no longer be generated when a DOM CRUD or DOM Action script is started [ID 41536]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, a "Script started" information event would be generated each time a DOM CRUD script or DOM Action script was started. From now on, these information events will no longer be generated.

#### Protocols: Enhanced protection of table data [ID 41539]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, when a protocol performed multiple actions on a table, SLProtocol would not properly lock the array in which the data was stored. This could then lead to concurrent access to the array, causing the entries to get corrupted and SLProtocol to stop working when those corrupted entries were accessed.

The above-mentioned array will now be locked to prevent the data from getting corrupted.

#### Storage as a Service: Enhanced performance when updating alarm information [ID 41581]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, overall performance has increased when updating alarm information on STaaS systems.

### Fixes

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

#### DataMiner Maps: Markers that did not match the alarm level filter would become visible for a split second [ID 41555]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you zoomed to a different layer while an alarm level filter was active, in some cases, markers that did not match the filter would become visible for a split second before disappearing again.

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
