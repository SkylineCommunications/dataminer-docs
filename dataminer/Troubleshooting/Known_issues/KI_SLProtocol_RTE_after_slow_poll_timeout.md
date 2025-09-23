---
uid: KI_SLProtocol_RTE_after_slow_poll_timeout
---

# SLProtocol RTE because of element stuck in slow poll mode

## Affected versions

This issue was discovered in DataMiner 10.4.0 CU11 and can occur from that DataMiner version onwards. However, there is a possibility that it may also occur in earlier DataMiner versions. This is currently still being investigated.

## Cause

When a DataMiner element enters slow poll mode after a timeout, DataMiner uses the first parameter from the first protocol group of the element as a "ping" parameter. It can then happen that SLProtocol keeps waiting indefinitely for a response from SLSNMPManager during slow polling, even though there is no longer anything in the SLSNMPManager queue for the affected element, causing a run-time error (RTE).

## Fix

Install DataMiner 10.5.9/10.4.0 [CU18]/10.5.0 [CU6]<!--RN 43216-->.

## Workaround

Disable slow poll mode on all elements where it is currently active.

## Description

After a timeout on a DataMiner element that has slow poll mode enabled, a run-time error occurs in the SLProtocol process.
