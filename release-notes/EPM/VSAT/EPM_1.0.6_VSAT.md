---
uid: EPM_1.0.6_VSAT
---

# EPM 1.0.6 VSAT

## New features

#### Generic Trap Processor: New Event State parameter [ID_37569]

A new *Event State* parameter has been added to the Generic Trap Processor connector, which can be used to track the state of a trap message. The state is *Active* if the message has entered the Alarmed state and *Cleared* if it has left this state.

#### Carrier performance and information event dashboards additions [ID_37584]

The existing carrier performance dashboard has been updated to include new parameters in the Stats Summary table and Carrier Summary table, including *Target C/No*, *Modulation Name*, *Fecrate*, and *Symbol Rate*.

In addition, two new dashboards are now included in the solution:

- Information Events - Textbox Feed
- Information Events - Parameter feed

Both of these dashboards can be used to query historical information events for a user-defined selection of circuits and for a selected time period.

## Changes

### Enhancements

#### Generic Sun Outage: Improvements to avoid invalid values [ID_37385]

The Generic Sun Outage connector has been updated so that values like NaN, Infinity or, -Infinity will no longer be displayed for the Outage Angle, Angular Difference, Azimuth, and Current Angle parameters. In addition, a new *Default Dish Size* parameter has been added to allow user input on dish size values of *Not Available* or *0*.

#### Generic Trap Processor: Wildcard support for binding filtering [ID_37460]

The Generic Trap Processor connector now allows users to specify a filter with wildcard for binding 1, so that only traps matching the filter are processed.

#### Verizon iDirect Evolution Platform Collector: Circuit Availability now 0% when circuit is not in network [ID_37467]

When a circuit is present but not in the network, the Circuit Availability will now be displayed as 0%.

#### Generic Trap Processor: Data persistence implemented [ID_37499]

To allow more consistent monitoring, the Generic Trap Processor connector has been updated so that no parameter details are lost in the Processed Messages Table and Received Traps Table when the element restarts.

#### Generic Sun Outage: Support for empty strings and null values in earth stations import file [ID_37570]

Empty strings and null values are now supported in the file that is used to import earth stations.

### Fixes

#### Verizon iDirect Evolution Platform Collector: RTEs when database table cleanup logic was running [ID_37555]

When database table cleanup logic was running, the Verizon iDirect Evolution Platform Collector connector could cause RTEs or half-open RTEs.

#### Missing information events in dashboards [ID_37581]

Up to now, the *InformationEventsGQI* script could result in missing information events within the selected time range in a dashboard. This has been adjusted so that the dashboards are now completely accurate based on the time range selected by the user.

#### Generic KAFKA Consumer: Exceptions related to files marked for deletion [ID_37583]

When a KAFKA topic file was deleted, it could occur that it was erroneously marked for deletion twice, resulting in exceptions in the KAFKA Consumer element.
