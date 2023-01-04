---
uid: KI_SLNet_thread_leak
---

# Memory leak in SLNet threads

## Affected versions

DataMiner Feature Release version 10.2.12 [CU0] and [CU1].

## Cause

DataMiner 10.2.12 switched the SLNet-SLHelper connection from SLMessagebroker to the Dataminer.messagebroker NuGet implementation. However, when the connection mechanism was switched, it could occur that SLNet threads were not cleaned up correctly, so that these could leak memory. While this was a relatively small memory leak, at some point thread starvation in other parts of SLNet could occur.

## Fix

Upgrade to DataMiner 10.2.12 [CU2] or DataMiner 10.3.1.

## Issue description

SLNet threads use a continually increasing amount of memory without a clear reason.
