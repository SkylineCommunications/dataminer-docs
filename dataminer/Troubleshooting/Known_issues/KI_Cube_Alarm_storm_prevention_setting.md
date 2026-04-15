---
uid: KI_Cube_Alarm_storm_prevention
---

# Values of Cube alarm storm prevention user settings would not be visualized correctly in the UI

## Affected versions

DataMiner Cube versions 10.5.0 CU13, 10.6.0 CU1, and 10.6.4.

## Cause

The Cube theme changes made in versions 10.5.0 CU13, 10.6.0 CU1, and 10.6.4 caused the *Enable alarm storm prevention* user settings to no longer get loaded into the UI. In the *Settings* window, the values of the following settings would incorrectly be set to 0:

- *Enable alarm storm protection by grouping alarms with the same parameter name*
- *Enable alarm storm protection by applying a delay on the alarms*

However, the values were still applied correctly in the Alarm Console, and remained untouched in the JSON files.

## Fix

Install DataMiner Cube version 10.5.0 CU14, 10.6.0 CU2, or 10.6.5. <!-- RN 45293 -->

## Description

In the *Settings* window, since DataMiner versions 10.5.0 CU13/10.6.0 CU1/10.6.4, the *Enable alarm storm protection* settings would not be visualized correctly.
