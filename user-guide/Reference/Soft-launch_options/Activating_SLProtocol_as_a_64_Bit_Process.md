---
uid: Activating_SLProtocol_as_a_64_Bit_Process
---

# Activating SLProtocol as a 64-bit process

There are **two ways** to activate this soft-launch feature, depending on whether you want to combine this with an upgrade action, or without.

> [!NOTE]
> This requires DataMiner version 10.1.8 or higher.

> [!TIP]
> This can be activated on any or all agents in a cluster, though, we encourage you to select all agents in the cluster.

- **Using an upgrade**:

  1. Create an empty text file named *SoftLaunchX64_SLProtocol.txt* in the folder `C:\Skyline DataMiner\Tools` on each DMA. The agents can still be active for this step.
  1. Install the upgrade package.

- **Without performing an upgrade**:

  1. Stop all DMAs where you want to enable this feature.
  1. Launch a command line prompt as administrator on these agents.
  1. Navigate to `C:\Skyline DataMiner\Tools\` in the prompts.
  1. Execute `RegisterSLProtocolAsX64.bat` from the prompts.
  1. Restart the agents.

  Command Line Example
  ```bash
  C:\> cd "C:\Skyline DataMiner\Tools\"
  C:\Skyline DataMiner\Tools> RegisterSLProtocolAsX64.bat
  ```

  PowerShell Example
  ```pwsh
  PS C:\> cd "C:\Skyline DataMiner\Tools\"
  PS C:\Skyline DataMiner\Tools> .\RegisterSLProtocolAsX64.bat
  ```
    
