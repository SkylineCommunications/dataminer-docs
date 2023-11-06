---
uid: EPM_1.0.7_VSAT
---

# EPM 1.0.7 VSAT - preview

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

### Fixes

#### Verizon iDirect Evolution Platform Collector: Linecard event types not collected [ID_37691]

Because of a change to the remote event logic, it could occur that some linecard event types were not collected. The way linecards are handled has been updated to resolve this issue.
