---
uid: KI_missing_NATS_services
---

# NATS services missing after reboot

## Affected versions

Any version of DataMiner

## Cause

This is most likely caused by antivirus software quarantining NATS binaries.

## Fix

Exclude the DataMiner folders from the antivirus software as detailed under [Regarding antivirus software](xref:Regarding_antivirus_software), and then manually reinstall NATS on the DMA.

## Description

After a DataMiner Agent rebooted because of Windows updates, NATS services are gone, making it impossible to start DataMiner.
