---
uid: Protocol.Threads
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
