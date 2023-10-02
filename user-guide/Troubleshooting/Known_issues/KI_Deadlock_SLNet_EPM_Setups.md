---
uid: KI_SLNet_Deadlock_EPM_Setups
---

# SLNet deadlock in EPM setups

## Affected versions

From DataMiner 10.3.9 onwards.

## Cause

DataMiner 10.3.9 introduced some security enhancements on the deserialization of messages that may cause SLNet issues in EPM setups.

## Fix

No fix is available yet.

## Description

In EPM setups running DataMiner 10.3.9 or higher, forwarding *GetLinkedDMAObjectRefTreesThroughTopologyBulkRequestMessage* requests to other DataMiner Agents in the cluster can trigger a deadlock in SLNet, leading to various SLNet issues.
