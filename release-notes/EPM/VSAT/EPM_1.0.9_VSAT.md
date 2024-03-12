---
uid: EPM_1.0.9_VSAT
---

# EPM 1.0.9 VSAT

## New features

#### Skyline Universal Weather: New Windy API endpoint [ID_38610]

A new API endpoint, Windy API, is now included in the Skyline Universal Weather connector.

#### Verizon iDirect Evolution Platform Collector: Export functionality added for file with removed entities [ID_38918]

A new file path configuration has been added to the collector setup page, which exports a JSON file. The file contains entities that no longer exist in the network. It is meant to be used with an Automation script to query Cassandra in order to gather historical data.

## Changes

### Enhancements

#### Skyline Universal Weather: New debug parameters to clear buffer [ID_38747]

On the *Debug* page of the Skyline Universal Weather connector, a *Clear Buffer Timer* toggle button and *Clear All Buffer* button are now available. You can use these to clear the buffer when the maximum number of API requests has been reached and requests are accumulating in the buffer.

#### Verizon iDirect Evolution Platform Collector: Event Suppression column renamed to HETs Breach [ID_38918]

The *Event Suppression* column in the Circuits Overview table has been renamed to *HETs Breach*.

#### Topology now reflects relation between linecards and hub return [ID_39062] [ID_39063]

To support an upcoming feature, the topology file of the Verizon VSAT Platform Manager has been updated to reflect the relation between linecards and hub return, if available. Files that are exported by the Verizon iDirect Evolution Platform Collector to build the topology file will now also reflect this relation.

### Fixes

#### Generic Trap Processor: Trap count incorrectly doubled [ID_38609]

It could occur that the Generic Trap Processor doubled the trap count, counting a single incoming trap twice, which resulted in inaccurate totals.

#### Verizon iDirect Evolution Platform Collector: Missing values in Spacecraft column of the Circuits Overview table [ID_38918]

In the *Spacecraft* column of the Circuits Overview table, it could occur that after some time cells were set to N/A. This issue has been resolved, so that this column will now retain its values over time.
