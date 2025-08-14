---
uid: VerifyGRPCConnectiondmupgrade
---

# VerifyGRPCConnection.dmupgrade

From DataMiner 10.5.10/10.6.0 onwards<!-- RN 43506 -->, the *VerifyGRPCConnection* prerequisite check is included in upgrade packages. This check verifies whether all DataMiner Agents in the cluster can communicate via gRPC over HTTPS port 443 and none of the Agents currently have a non-default network configuration. This prevents situations where a DataMiner System becomes non-functional after an upgrade where .NET Remoting is disabled by default.

If this check fails, you will need to [manually verify the root cause and take appropriate action](xref:KI_Upgrade_fails_VerifyGRPCConnection_prerequisite).

*VerifyGRPCConnection.dmupgrade* will run the same tests as the prerequisite in the DataMiner upgrade package, and can be used in preparation of a full upgrade. It can be downloaded from [DataMiner Dojo](https://community.dataminer.services/download/verifygrpcconnection-dmupgrade/).

Note:

- When you run *VerifyGRPCConnection.dmupgrade*, always select to **upgrade the entire cluster at once** (see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)).

- When you run *VerifyGRPCConnection.dmupgrade*, a warning may be displayed about the upgrade restarting the DMA. However, no DMA restart will be caused by this package.

- Running this package usually takes about one minute.

- When you run the package, information will be displayed in the upgrade progress window. If you want to consult this information after the window is closed, it is available in the progress.log file in the folder `C:\Skyline DataMiner\Upgrades\Packages\VerifyGRPCConnection.dmupgrade-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`.

- While this is not recommended, it is possible to force a DMA to upgrade by keeping .NET Remoting enabled. To do so, run the *EnableDotNetRemoting.dmupgrade* package, which can be downloaded from [DataMiner Dojo](https://community.dataminer.services/download/enabledotnetremoting-dmupgrade/).
