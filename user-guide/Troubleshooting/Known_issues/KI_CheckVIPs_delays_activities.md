---
uid: KI_CheckVIPs_delays_activities
---

# Activities and scripts delayed because of CheckVIPs thread

## Affected versions

- Main Release versions from DataMiner 10.2.0 onwards.
- Feature Release versions from DataMiner 10.1.12 onwards.

## Cause

The CheckVIPs thread, which is responsible for checking whether a DMA holds the correct IP addresses every minute, claims multiple locks to verify the current state of the IPs. This can cause a delay for other calls in the system. This is specifically the case for Automation scripts and other activities that require the generation of an information event, as the information event cannot be generated as long as the locks of the CheckVIPs thread are in place.

## Fix

No fix is available yet.

## Issue description

At specific intervals, Automation scripts and other activities that occur in DataMiner seem to experience a delay.
