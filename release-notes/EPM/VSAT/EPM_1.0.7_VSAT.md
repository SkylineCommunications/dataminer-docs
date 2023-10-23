---
uid: EPM_1.0.7_VSAT
---

# EPM 1.0.7 VSAT - preview

## New features

#### Generic Trap Processor: New Event State parameter [ID_37569]

A new *Event State* parameter has been added to the Generic Trap Processor connector, which can be used to track the state of a trap message. The state is *Active* if the message has entered the Alarmed state and *Cleared* if it has left this state.

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

### Fixes

*No fixes have been added to this release yet.*
