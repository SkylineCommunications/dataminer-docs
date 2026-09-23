---
metadata_version: 1
uid: Protocol.Threads
description: "Reference the DataMiner connector protocol schema entry for Threads element, including its documented structure, attributes, values, and constraints."
---

# Threads element

Specifies additional threads that will be used by the protocol.<!-- RN 5359 -->

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Thread](xref:Protocol.Threads.Thread)|[0, *]|Defines an additional thread.|

## Remarks

This allows you to separate time-critical actions from device-polling actions.
