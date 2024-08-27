---
uid: KI_missing_NATS_services
---

# NATS services missing after reboot

## Affected versions

Any version of DataMiner

## Cause

This is most likely caused by antivirus software quarantining NATS binaries.

## Workaround

Manually reinstall NATS on the DMA.

## Fix

Exclude DataMiner folders from the AntiVirus as described [here](xref:Regarding_antivirus_software)

## Description

After a DataMiner Agent rebooted because of Windows updates, NATS services are gone, making it impossible to start DataMiner.
