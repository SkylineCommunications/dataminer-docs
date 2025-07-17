---
uid: KI_Param_next_not_working
---

# Param next attribute not working correctly

## Affected versions

- DataMiner Main Release versions from 10.1.0 [CU15] to 10.3.0 [CU15] and 10.2.0 [CU3] to 10.4.0 [CU3].

- DataMiner Feature Release versions from 10.2.3 to 10.4.6.

## Cause

Because of an internal lock, if the "[next](xref:Protocol.Groups.Group.Content.Param-next)" attribute is used in a *Param* element in a protocol, all items are added to the polling queue with the needed delay, but they are then all processed at once. The delay is only added after the last parameter of the group, before the group that is polled next.

## Fix

Install DataMiner 10.3.0 [CU16], 10.4.0 [CU4], or 10.4.7<!--RN 39430-->.

## Issue description

When the "[next](xref:Protocol.Groups.Group.Content.Param-next)" attribute is used in a *Param* element in a protocol to delay the polling of the next parameter in a group, this delay is not applied correctly.
