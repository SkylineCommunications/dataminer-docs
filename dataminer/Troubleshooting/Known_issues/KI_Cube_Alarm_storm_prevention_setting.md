---
uid: KI_Cube_Alarm_storm_prevention
---

# Alarm storm prevention user settings not visualized correctly

## Affected versions

DataMiner Cube versions 10.5.0 [CU13], 10.6.0 [CU1], and 10.6.4.

## Cause

The Cube theme changes made in versions 10.5.0 [CU13], 10.6.0 [CU1], and 10.6.4 caused the *Enable alarm storm prevention* user settings to no longer get loaded into the UI.

## Fix

Install DataMiner Cube version 10.5.0 [CU14], 10.6.0 [CU2], or 10.6.5. <!-- RN 45293 -->

## Description

On the [*Alarm Console* page of the user settings](xref:User_settings#alarm-console-settings), the *Enable alarm storm protection* settings are not visualized correctly. The values of the following settings are incorrectly set to 0:

- *Enable alarm storm protection by grouping alarms with the same parameter name*
- *Enable alarm storm protection by applying a delay on the alarms*

However, the values are still applied correctly in the Alarm Console and remain untouched in the JSON files.