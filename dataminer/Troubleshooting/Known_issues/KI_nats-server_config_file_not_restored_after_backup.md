---
uid: KI_nats-server_config_file_not_included_in_backups
---

# nats-server.config file not included in DataMiner backups

## Affected versions

From DataMiner 10.2.0 [CU6]/10.2.8 onwards.

## Cause

When automatic NATS configuration is disabled via the *NATSForceManualConfig* option, manual changes can be made to the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder. However, this file is not included in DataMiner backup packages, which means any manual changes will be lost after a backup is restored.

> [!CAUTION]
> We strongly recommend against disabling automatic NATS configuration unless absolutely necessary. For more information, see [Disabling automatic NATS configuration](xref:Disabling_automatic_NATS_config).

## Fix

Install DataMiner 10.4.11/10.5.0 to ensure the *nats-server.config* file is automatically restored after a backup<!--RN 40812-->.

## Issue description

In versions prior to DataMiner 10.4.11/10.5.0, when a DataMiner backup is restored, any manual changes made to the *nats-server.config* file are lost.

## Workaround

To avoid losing changes, manually back up the *nats-server.config* file from the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder when performing a DataMiner backup.
