---
uid: EPM_1.0.6_VSAT
---

# EPM 1.0.6 VSAT

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Generic Sun Outage: Improvements to avoid invalid values [ID_37385]

The Generic Sun Outage connector has been updated so that values like NaN, Infinity or, -Infinity will no longer be displayed for the Outage Angle, Angular Difference, Azimuth, and Current Angle parameters. In addition, a new *Default Dish Size* parameter has been added to allow user input on dish size values of *Not Available* or *0*.

#### Generic Trap Processor: Wildcard support for binding filtering [ID_37460]

The Generic Trap Processor connector now allows users to specify a filter with wildcard for binding 1, so that only traps matching the filter are processed.

#### Verizon iDirect Evolution Platform Collector: Circuit Availability now 0% when circuit is not in network [ID_37467]

When a circuit is present but not in the network, the Circuit Availability will now be displayed as 0%.

### Fixes

*No fixes have been added to this release yet.*