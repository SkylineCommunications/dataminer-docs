---
uid: General_Main_Release_10.3.0_CU18
---

# General Main Release 10.3.0 CU18 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### NATS configuration can now be reset by calling an endpoint of SLEndpointTool.dll [ID_39871]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.8 -->

From now on, the NATS configuration can be reset by calling the following endpoint in e.g. an Automation script:

`SLEndpointTool.Config.NATSConfigManager.ResetNATSConfiguration()`

#### DataMiner upgrade: ResetConfig.txt will no longer be added to FilesToDelete.txt [ID_39994]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Every DataMiner upgrade package includes a *FilesToDelete.txt* file, which lists all files in the *C:\\Skyline DataMiner\\* folder that should be deleted during the upgrade procedure. From now on, the *ResetConfig.txt* file will no longer be added to that list of files to be deleted.

The *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* file is a file used by the factory reset tool *SLReset.exe* as a whitelist to determine which files to keep. The first time *SLReset.exe* is executed, the default whitelist is added to *ResetConfig.txt*. Afterwards, you can add files you want to keep to this whitelist, so that these are not removed when the tool is executed again. If you delete *ResetConfig.txt*, the default whitelist will be used again.

### Fixes

#### SLNet - CloudEndpointManager: Problem at startup when NATS and NAS services were not installed [ID_39980]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

At startup, in some cases, the CloudEndpointManager in SLNet could throw an exception when the NATS and NAS services were not installed.
