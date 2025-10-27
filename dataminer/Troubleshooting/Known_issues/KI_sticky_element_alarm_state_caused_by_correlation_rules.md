---
uid: KI_sticky_element_alarm_state_caused_by_correlation_rules
---

# Sticky element alarm state caused by correlation rules

## Affected versions

From DataMiner 10.2.0 onwards.

## Cause

Correlation rules may prevent an element's alarm state from updating correctly. When a notice, such as `Alarm history exceeded 100 alarms. It is advised to revise your alarm threshold definitions`, is stored for an element, it can interfere with how the alarm state is handled after alarms clear.

This can happen when correlation rules with conditions like `count(*) > 0` are in place.

## Fix

No fix is available yet. <!--Task ID: 251767-->

## Workaround

- Exclude notices through the alarm filter of the correlation rule.

- Restart the element.

## Description

An element's alarm state remains at a higher severity level even after the alarms have cleared. For example:

- The element shows no active alarms, but its state is not marked as normal.

- The element has only minor alarms but still displays a major alarm state.
