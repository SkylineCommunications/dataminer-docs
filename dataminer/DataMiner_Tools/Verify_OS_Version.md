---
uid: Verify_OS_Version
---

# Verify OS Version

From DataMiner 10.5.12/10.6.0 onwards<!--RN 43356-->, the *VerifyOSVersion* prerequisite check is included in upgrade packages. This check verifies whether the DataMiner version in the upgrade package supports the version of the operating system that is installed on the DataMiner Agent. If the operating system version is not supported, you will need to upgrade your operating system before you can install the DataMiner upgrade.

As Microsoft no longer supports OS versions older than Windows Server 2016 or Windows 10, these versions will always cause this prerequisite check to fail.

> [!TIP]
> See also: [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)
