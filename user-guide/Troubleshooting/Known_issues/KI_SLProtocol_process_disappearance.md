---
uid: KI_SLProtocol_process_disappearance
---

# SLProtocol process could disappear when a protocol version was modified while an element was starting up

## Affected versions

All currently supported versions.

## Cause

When, in DIS, you clicked *Publish* several times in rapid succession, the SLProtocol process could disappear.

## Fix

Install DataMiner 10.4.0 [CU15], 10.5.0 [CU3], or 10.5.6. <!-- RN 42344 -->

## Workaround

Only publish a protocol version when all elements have restarted.

## Description

When a protocol version was overwritten while an element using that protocol version was starting up, in some cases, the SLProtocol process could stop working. Also, this could result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`
