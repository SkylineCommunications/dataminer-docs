---
uid: EPM_1.0.8_VSAT
---

# EPM 1.0.8 VSAT - preview

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Verizon iDirect Evolution Platform Collector: Improved descriptions for Hub Return Overview and Carriers tables KPIs [ID_38074]

The descriptions for the Hub Return Overview and Carriers tables KPIs have been improved, so that these now include the correct calculations and sources.

### Fixes

#### Verizon iDirect Evolution Platform Collector: Actual Data Rate for Hub Return Carriers Table averaged incorrectly [ID_38074]

Because of a problem with the way the Actual Data Rate for Hub Return Carriers Table was averaged, it could occur that the aggregated value in the Hub Return Overview Table was not correct.

#### Verizon WM Ticketing: Ticket not assigned to ticket handler [ID_38075]

In some cases, it could occur that a ticket was not assigned to a ticket handler. This happened in case it was previously shown as a "-1" exception value, and this was changed to a grayed out "N/A" value.

#### Kafka Consumer RTE [ID_38076]

In case there were issues with the Kafka calls, the Kafka consumer could generate RTEs. To prevent this, the logic for the consume loop has been adjusted so that it now runs until the token expires. This means that there are now two ways the consume loop can terminate: when a token expires or when the loop naturally exits.
