---
uid: KI_nats-server_config_file_not_restored_after_backup
---

# nats-server.config file is not automatically restored after DataMiner backup

## Affected versions

From DataMiner 10.2.0 [CU6]/10.2.8 onwards.

## Cause

When automatic NATS configuration is disabled via the *NATSForceManualConfig* option, the *nats-server.config* file is saved in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder as part of a DataMiner backup. However, the file is not automatically restored after the backup, which may give the impression that changes made to the file have been lost.

> [!CAUTION]
> We strongly recommend against disabling automatic NATS configuration unless absolutely necessary. For more information, see [Disabling automatic NATS configuration](xref:SLNetClientTest_disabling_automatic_nats_config).

## Fix

Install DataMiner 10.4.11/10.5.0 to ensure the *nats-server.config* file is automatically restored after a backup<!--RN 40812-->.

## Issue description

When a DataMiner backup is restored in versions prior to DataMiner 10.4.11/10.5.0, the *nats-server.config* file is not automatically restored, leading to the impression that manual changes to the file have been lost.

## Workaround

Manually restore the *nats-server.config* file from the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder.
