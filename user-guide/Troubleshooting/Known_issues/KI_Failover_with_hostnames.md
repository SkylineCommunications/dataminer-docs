---
uid: KI_Failover_with_hostnames
---

# Multiple issues when Failover based on hostnames is used

## Affected versions

From DataMiner 10.2.0/10.1.8 onwards.

## Cause

Systems are unable to keep track of which IP and hostname is linked to which DMA, causing DMAs to be listed multiple times in *DMS.xml*. This in turn causes problems with the communication between the DMAs.

## Fix

Install DataMiner 10.3.0 [CU11]/10.4.2<!-- RN 32951 -->.

## Issue description

In systems using Failover based on hostnames, issues occur with the communication between DMAs. It can occur that DMAs temporarily no longer seem to be in the cluster or that they toggle between connected and not connected. The Failover Agents themselves may be unable to make the switch between the online and offline Agent.
