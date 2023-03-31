---
uid: Activating_SLProtocol_as_a_64_Bit_Process
---

# Activating SLProtocol as a 64-bit process

There are **two ways** to activate this soft-launch feature, depending on whether you want to do so before you upgrade to a version supporting the feature, or after you upgrade.

- **Before the upgrade**:

  1. Create an empty text file named *SoftLaunchX64_SLProtocol.txt* in the folder `C:\Skyline DataMiner\Tools` on each DMA.
  1. Install the upgrade package.

- **After the upgrade**:

  1. Stop all DMAs in the cluster.
  1. On each DMA, execute `C:\Skyline DataMiner\Tools\RegisterSLProtocolAsX64.bat` from a command line prompt as administrator.
  1. Restart DataMiner.
