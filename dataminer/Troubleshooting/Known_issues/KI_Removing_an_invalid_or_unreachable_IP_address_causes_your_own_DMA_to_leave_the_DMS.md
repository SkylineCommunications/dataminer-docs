---
uid: KI_Removing_an_invalid_or_unreachable_IP_address_causes_your_own_DMA_to_leave_the_DMS
---

# Removing an invalid or unreachable IP address causes your own DMA to leave the DMS

## Affected versions

Feature Release versions from DataMiner 10.5.7 onwards<!--RN 42494-->.

## Cause

Because of missing validation when removing a cluster name, cleaning up an unreachable or invalid IP address in System Center can inadvertently cause the active DataMiner Agent to leave the cluster.

## Workaround

When the status of your DataMiner Agent changes to *Leaving cluster*, you can still re-add it to the cluster:

1. On the *Agents* page in System Center, select the affected DataMiner Agent.

1. Under *Agent Cluster*, enter the name of the cluster.

1. Select *Join cluster*.

   The state of the Agent will change to *Joining cluster*, and eventually return to *Running*.

## Fix

Install DataMiner 10.6.0/10.6.1.<!-- RN 44253 -->

## Description

When you remove a rogue or unreachable IP address on the *Agents* page in System Center, the DataMiner Agent you are connected to may unexpectedly switch to the *Leaving cluster* state and leave the cluster.
