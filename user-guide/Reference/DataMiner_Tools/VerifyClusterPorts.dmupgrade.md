---
uid: VerifyClusterPortsdmupgrade
---

# VerifyClusterPorts.dmupgrade

In DataMiner 10.2.0 CU2 and 10.2.5, a prerequisite check is added to upgrade packages. It verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. This prevents situations where a DataMiner System becomes non-functional after an upgrade that uses more or different ports. If this check fails, you will need to execute the *VerifyClusterPorts.dmupgrade* package, which can be downloaded from [DataMiner Dojo](https://community.dataminer.services/download/verifyclusterports-dmupgrade/).

*VerifyClusterPorts.dmupgrade* will run the same tests as the DataMiner upgrade package, but it will make sure that temporary listening ports are open for the required ports and a temporary local firewall rule is configured. This way, if a firewall or other configuration issue is causing the problem, this will become clear. If no failing ports are reported when you run this package, the regular upgrade package will use this stored result to continue with the upgrade.

Note:

- When you run *VerifyClusterPorts.dmupgrade*, always select to **upgrade the entire cluster at once** (see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)).

- When you run *VerifyClusterPorts.dmupgrade*, a warning may be displayed about the upgrade restarting the DMA. However, no DMA restart will be caused by this package.

- Running this package usually takes about 5 minutes.

- When you run the package, information will be displayed in the upgrade progress window. If you want to consult this information after the window is closed, it is available in the progress.log file in the folder *C:\Skyline DataMiner\Upgrades\Packages\VerifyClusterPorts.dmupgrade-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*.

- While this is not recommended, it is possible to force a DMA to upgrade even if not all ports are reachable. To do so, create a custom *VerifyClusterPorts.LastRun.xml* file in the folder *C:\Skyline Dataminer\Upgrades\Helper\VerifyClusterPorts*, containing Success = true and a recent timestamp, as illustrated below. Note that the *LastRun.xml* file is only valid for 10 days.

```xml
<VerifyResult>
  <Timestamp>2022-03-31T12:05:04.751573Z</Timestamp>
  <Success>true</Success>
</VerifyResult>
```
