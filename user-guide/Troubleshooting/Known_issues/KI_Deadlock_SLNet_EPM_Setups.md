---
uid: KI_SLNet_Deadlock_EPM_Setups
---

# SLNet deadlock in EPM setups

## Affected versions

DataMiner 10.3.9 and 10.3.10

## Cause

DataMiner 10.3.9 introduced some security enhancements on the deserialization of messages that may cause SLNet issues in EPM setups.

## Fix

Install DataMiner 10.3.11/10.4.0<!--RN 37462-->.

## Description

In EPM setups running DataMiner 10.3.9 or higher, forwarding *GetLinkedDMAObjectRefTreesThroughTopologyBulkRequestMessage* requests to other DataMiner Agents in the cluster can trigger a deadlock in SLNet, leading to various SLNet issues.
