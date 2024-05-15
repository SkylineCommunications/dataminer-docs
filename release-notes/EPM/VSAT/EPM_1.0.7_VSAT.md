---
uid: EPM_1.0.7_VSAT
---

# EPM 1.0.7 VSAT

## New features

#### Generic Trap Processor: New Event State parameter [ID_37569]

A new *Event State* parameter has been added to the Generic Trap Processor connector, which can be used to track the state of a trap message. The state is *Active* if the message has entered the Alarmed state and *Cleared* if it has left this state.

#### Verizon iDirect Evolution Platform Collector: ATDMA Carrier parameters updated and new IP Throughput parameter [ID_37694]

Several changes have been implemented in the Verizon iDirect Evolution Platform Collector connector:

- A new *IP Throughput* parameter has been added to the Hub Return Carriers and Hub Return Overview tables.

- The calculations for Hub Return Overview table parameters have been updated:

  - Available Bandwidth: IP Throughput - Actual Data Rate

  - Utilization: Actual Data Rate/IP Throughput * 100

  - IP Throughput: Sum of Carrier IP Throughput from same inroute group.

- The calculations for the Hub Return Carriers table parameters have been updated:

  - Available Bandwidth: IP Throughput - Actual Data Rate

  - Utilization: Actual Data Rate/IP Throughput * 100

  - IP Throughput: (.75 or .80 or .85 based on Payload) * Information Rate

  - Actual Symbol Rate: Actual Data Rate * (1.25, 1.2, 1.15 based on Payload) / (Modulation * Code Rate)

#### New Verizon DCATGQI AddSubscription Automation script [ID_37747]

A new interactive Automation script, *Verizon DCATGQI AddSubscription*, has been created, allowing users to add entries to the following tables for the Verizon Reports and Dashboards Solution connector:

- Entity Subscription
- KPI Entry Subscription
- Profile DCAT Metric
- Profile DCAT Metric Status
- Profile DCAT Listing
- Profile DCAT FUW

#### New Verizon DCATGQIExecutionTable Automation script [ID_37748]

A new Automation script, *Verizon DCATGQIExecutionTable*, has been added. It functions as an ad hoc data source for the DCAT low-code app, in order to display Live and Live History data.

#### Generic Trap Processor: New Heartbeat Table [ID_37760]

In the Generic Trap Processor connector, a new Heartbeat Table is now available, in which information about heartbeats is displayed.

In the existing Rules Table, two new parameters have been added for this:

- *Rule Type*: Can be set to *Regular* for traps that should be included in the Processed Messages Table, or *Heartbeat* for trap that should be included in the Heartbeat Table.
- *Heartbeat Interval*: If *Rule Type* is set to *Heartbeat*, you can configure this parameter with an interval of time. This interval will be compared with the *Time Since Last Heartbeat* parameter. If the time since the last heartbeat is greater than the configured interval, *Heartbeat Status* will be displayed as *FAIL* in the Heartbeat Table.

#### Skyline EPM Platform PLM: Default alarm template [ID_37789]

A default alarm template is now available for the Skyline EPM Platform PLM connector.

#### Intelsat Flex Platform VSAT: REST API integration [ID_37916]

In the Intelsat Flex Platform VSAT connector, the following changes were implemented to integrate the REST API:

- The *REST API Authentication* and *REST API Endpoints Configuration* tables have been implemented on the *REST API Endpoints Configuration* page for advanced management.
- The *Terminals* and *SSPCs* tables have been moved to the *Remote Stats* page.
- The *Remotes Overview* table has been added to the *Remotes* page.
- The *Circuits Overview* table has been added to the *Circuits* page.

#### Generic Trap Processor: New 'Auto Clear' configuration page [ID_37938]

A new *Auto Clear* configuration page has been added to the Generic Trap Processor connector, which allows you to configure when events are automatically cleaned up. You can configure the following parameters on this page:

- *Event Cleanup Timer*: The interval at which the cleanup operation takes place.
- *Maximum Age of Events*: Any events older than the time configured here are cleaned up automatically.
- *Keep Active*: If this option is selected, events will only be cleaned up when they gave been cleared.
- *Max Processed Messages*: If there are more processed messages than this number, the oldest messages are cleaned up automatically.
- *Max Received Traps*: If there are more received traps than this number, the oldest traps are cleaned up automatically.

At the bottom of the page, you can also see the current status of the cleanup operation and the time when the cleanup operation last took place.

#### Newtec Dialog Platform VSAT: Cleanup logic implemented for Remotes Overview and Circuits Overview tables [ID_37942]

In the Remotes Overview and Circuits Overview tables of the Newtec Dialog Platform VSAT connector, an *Entity State* and *Entity State Time* column have been added. Based on these columns, cleanup logic has now also been implemented. For this, you can configure the following new parameters:

- *Automatic Entity Removal*: Determines whether entries are automatically removed or not.
- *Entity Removal Period*: Determines after how long entries are removed if automatic removal is enabled.

## Changes

### Enhancements

#### Generic Sun Outage: Improvements to avoid invalid values [ID_37385]

The Generic Sun Outage connector has been updated so that values like NaN, Infinity or, -Infinity will no longer be displayed for the Outage Angle, Angular Difference, Azimuth, and Current Angle parameters. In addition, a new *Default Dish Size* parameter has been added to allow user input on dish size values of *Not Available* or *0*.

#### Generic Trap Processor: Wildcard support for binding filtering [ID_37460] [ID_37656]

The Generic Trap Processor connector now allows users to specify a filter with wildcard for all 20 bindings for the Rules Table and Source Name Table, so that only traps matching the filter are processed.

#### Verizon iDirect Evolution Platform Collector: Circuit Availability now 0% when circuit is not in network [ID_37467]

When a circuit is present but not in the network, the Circuit Availability will now be displayed as 0%.

#### Generic Trap Processor: Data persistence implemented [ID_37499]

To allow more consistent monitoring, the Generic Trap Processor connector has been updated so that no parameter details are lost in the Processed Messages Table and Received Traps Table when the element restarts.

#### Generic Sun Outage: Support for empty strings and null values in earth stations import file [ID_37570]

Empty strings and null values are now supported in the file that is used to import earth stations.

#### Verizon iDirect Evolution Platform Collector: Circuit Availability now 0% when Remotes State is in alarm state other than Warning [ID_37657]

When the Remotes State is in an alarm state other than Warning (yellow), the Circuit Availability KPI will now be 0%. If its alarm state is Warning, the Circuit Availability logic based on the Fwd C/N levels is used instead.

#### Verizon ETMS Platform: Logging logic updated [ID_37742]

The logging logic of the Verizon ETMS Platform connector has been updated to that all requests and responses to update a ticket (for an alarm or clear event) will now be logged into a file. The logging will include the time, the entity name, and the type of request made. In addition, to prevent excessive growth of the log files, cleanup logic for the files can be configured.

#### Verizon WM DCAT: Update to handle low-code app changes [ID_37743]

The Verizon WM DCAT connector has been updated to handle changes made to Automation scripts for the updated low-code app for DCAT.

#### Verizon WM RDS: Update to handle cell changes for Verizon Reports and Dashboards Solution connector tables [ID_37744]

The Verizon WM RD connector has been updated to handle changes to the  Verizon Reports and Dashboards Solution connector. It now allows cell changes of tables.

#### Verizon DCAT OnExecute script now interactive [ID_37745]

The Verizon DCAT OnExecute script has been changed into an interactive Automation script, so it can be used as part of the new Verizon DCAT low-code app.

#### Verizon DCAT OnResult script now interactive [ID_37746]

The Verizon DCAT OnResult script has been changed into an interactive Automation script, so it can be used as part of the new Verizon DCAT low-code app.

#### Verizon iDirect Evolution Platform Collector: Hub Return Slots per Frame now rounded to the nearest integer [ID_37759]

In the Hub Return Overview and Hub Return Carriers tables of the Verizon iDirect Evolution Platform Collector connector, the value of the Slots per Frame parameters will now be rounded to the nearest integer, so that these are displayed as whole numbers.

#### Verizon Reports and Dashboards Solution: Tables updated to allow cell changes [ID_37766]

In the Verizon Reports and Dashboards Solution connector, the following tables have been updated to allow changes for each cell:

- Entity Subscription
- KPI Entry Subscription
- Profile DCAT Metric
- Profile DCAT Fault
- Profile DCAT Listing
- Profile DCAT FUW

These tables now also have a button that allows users to delete a row without opening the context menu.

In addition, the logic in the connector has been updated to allow the addition of entries from an interactive Automation script.

#### Newtec Dialog Platform VSAT: New Debug Logging parameter [ID_37801]

In the Newtec Dialog Platform VSAT connector, a new *Debug Logging* parameter was added. This parameter allows you to enable or disable the generating of information events when the connector starts the *EPM Message Handler* script.

#### Verizon iDirect Evolution Platform Collector: New Debug Logging parameter [ID_37802]

In the Verizon iDirect Evolution Platform Collector connector, a new *Debug Logging* parameter was added. This parameter allows you to enable or disable the generating of information events when the connector starts the *EPM Message Handler* script.

#### Verizon VSAT Platform Manager: New Debug Logging parameter [ID_37804]

In the Verizon VSAT Platform Manager connector, a new *Debug Logging* parameter was added. This parameter allows you to enable or disable the generating of information events when the connector starts the *EPM Message Handler* script.

#### Carrier Performance and Information Events dashboard improvements [ID_37809]

The Carrier Performance dashboard has been updated so that the IP Throughput and Slots Per Frame KPIs are now included in both the calculated stats table and the carrier summary table.

In addition, the Information Events dashboards have been updated with improved default values and new names, and parameter feeds in these dashboards are now set to display up to 30,000 indices.

#### Generic Kafka Consumer: Improved logging [ID_37810]

Logging of the Generic Kafka Consumer connector has been improved to make important log entries stand out more and to make debugging easier.

#### Generic Trap Processor: Memory caching improved [ID_37811]

The memory caching logic for the Rules Table, Source Name Table, and Source IP Name Table of the Generic Trap Processor connector has been improved so that it is no longer necessary to restart the element to make sure changes in those tables take effect for upcoming traps.

#### Verizon ETMS Platform: Line card performance events priority adjusted [ID_37917]

In the Verizon ETMS Platform connector, the priority level for line card performance events during ticket creation has been changed from 1 to 2.

#### Generic Trap Processor: Information added in table descriptions on required rules configuration [ID_37936]

The descriptions of the Processed Messages Table and Heartbeat Table have been updated to include that there needs to be an entry in the Rules Table of type "Regular" or "Heartbeat" in order for the respective tables to be populated with upcoming traps.

#### Verizon WM DCAT improvements [ID_37939]

The following improvements have been implemented in the Verizon WM DCAT connector:

- Element data is now stored in memory referenced in loops in order to reduce the number of DMS calls.
- The read file logic has been updated to prevent conflicts.

#### Generic Trap Processor: Sorting Processed Messages Table adjusted [ID_37940]

In the Generic Trap Processor connector, the Processed Messages Table is now by default first sorted on event state, and then on timestamp. this way the most recent active events will be displayed at the top.

### Fixes

#### Verizon iDirect Evolution Platform Collector: Linecard event types not collected [ID_37691]

Because of a change to the remote event logic, it could occur that some linecard event types were not collected. The way linecards are handled has been updated to resolve this issue.

#### Skyline EPM Platform PLM: Auto-delete logic adjusted [ID_37790]

In some cases, it could occur that the auto-delete logic failed to function as intended, leading to inconsistent data retention in the PLM Overview and PLM Records tables. The auto-delete logic has now been adjusted to ensure that the tables are consistently cleaned up according to the configured auto-delete delay parameter.

#### Verizon Computer Associates Interface: VCAI Sun Outage Next Execution Time incorrect at end of month [ID_37937]

A problem with the way the VCAI Sun Outage Next Execution Time KPI was calculated could cause this data to be incorrect at the end of the month.

#### Generic KAFKA Consumer stuck in while loop [ID_37941]

In some cases, the Generic KAFKA Consumer connector could cause run-time errors, which could only be resolved by restarting the element. This happened when a server-side issue caused the connector to be stuck in a "while" loop.
