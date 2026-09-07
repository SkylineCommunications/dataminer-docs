---
uid: KI_Microsoft_Platform_elements_in_timeout
description: Learn why Microsoft Platform 6.0.0.x elements remain in timeout while polling data and how to work around this WMI issue.
---

# Microsoft Platform 6.0.0.x elements remain in timeout

## Affected versions

- Main Release versions from DataMiner 10.5.0 [CU18]/10.6.0 [CU6] onwards.
- Feature Release versions from DataMiner 10.6.9 onwards.<!-- RN 45851 -->

## Cause

WMI actions configured as `<Action><Type>wmi</Type></Action>` in *Protocol.xml* fail when they are executed directly by a trigger instead of through a group. The Microsoft Platform connector uses such an action to query `Win32_PingStatus`, which causes the element time out. Other WMI connectors are affected under the same conditions.

## Fix

No fix is available yet.<!-- RN 46396 -->

## Workaround

Edit the Microsoft element, and clear the *Include timeout* checkbox for the WMI connection.

To continue monitoring availability, you can use the [Generic Ping connector](https://catalog.dataminer.services/details/253977dd-efa6-4095-b22e-de9adb9cc23d).

## Description

Microsoft Platform elements using connector range 6.0.0.x remain in timeout even though they continue to poll data successfully and can still be used in operations.

Microsoft Platform connector ranges 1.1.3.x (virtual machine) and 7.0.0.x (prerelease) are not affected.
