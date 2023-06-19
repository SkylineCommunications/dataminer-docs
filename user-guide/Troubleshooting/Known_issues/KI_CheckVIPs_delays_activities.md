---
uid: KI_CheckVIPs_delays_activities
---

# Activities and scripts delayed because of CheckVIPs thread

## Affected versions

- DataMiner 10.2.0 up to 10.2.0 [CU15]/10.3.0 [CU4].
- DataMiner 10.1.12 up to 10.3.6.

## Cause

The CheckVIPs thread, which is responsible for checking whether a DMA holds the correct IP addresses every minute, claims multiple locks to verify the current state of the IPs. This can cause a delay for other calls in the system. This is specifically the case for Automation scripts and other activities that require the generation of an information event, as the information event cannot be generated as long as the locks of the CheckVIPs thread are in place.

## Fix

Install DataMiner 10.2.0 [CU16], 10.3.0 [CU4], or 10.3.7

## Issue description

At specific intervals, Automation scripts and other activities that occur in DataMiner seem to experience a delay.
