---
uid: KI_SLProtocol_process_disappearance
---

# SLProtocol process disappearance after protocol changes

## Affected versions

DataMiner versions prior to DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6.

## Cause

When a protocol version is overwritten while an element using that protocol version is starting up, it can occur that the SLProtocol process stops working. This happens specifically when a protocol is published several times in rapid succession via DIS. It could also happen if a protocol is modified in a different way, such as directly in Cube or when a .dmprotocol package is installed, but this is much less likely.

## Fix

Install DataMiner 10.4.0 [CU15], 10.5.0 [CU3], or 10.5.6. <!-- RN 42344 -->

## Workaround

Only publish a protocol version via DIS when all elements have restarted.

## Description

When a protocol is published via DIS, and the *Publish* button is clicked several times in rapid succession, this can cause the SLProtocol process to disappear. This can also result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`
