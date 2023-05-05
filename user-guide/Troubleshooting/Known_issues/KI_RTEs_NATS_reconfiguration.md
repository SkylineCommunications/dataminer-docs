---
uid: KI_RTEs_NATS_reconfiguration
---

# RTEs caused by problem during automatic NATS reconfiguration

## Affected versions

Feature release versions from DataMiner 10.3.4 onwards.

## Cause

DataMiner 10.3.4 introduces several calls that run on NATS between DataMiner Agents and that therefore require a fully functional NATS cluster. In case the NATS cluster encounters a problem during automatic reconfiguration, when the DataMiner Storage Module requests element data between DMAs through NATS, this can cause run-time errors (RTEs) in the SLASPConnection process. These may in turn result in other RTEs, for example if DataMiner Automation requests a report. This same situation may also cause RTEs in the SLDMS notification thread, specifically in case a deprecated DMS.GetInfo call is used that tries to retrieve all elements through NATS.

These errors occur when the NATS cluster does not have the required connections. This typically occurs in Failover setups and geographically distributed DataMiner Systems. It can for instance be caused by an external program or the operating system blocking the NSSM service manager so that automatic reconfiguration of the NATS cluster does not take place. It can also happen when the copying of public keys for authentication between the DMAs goes wrong because of an exception in the zip library.

## Fix

No fix is available yet. For geographically distributed setups, contact Skyline Communications to set up a static working NATS cluster.

## Description

In Failover setups and geographically distributed DataMiner Systems, run-time errors occur. These specifically occur in the SLASPConnection process and/or the SLDMS notification thread, but other processes may also be affected as a result.
