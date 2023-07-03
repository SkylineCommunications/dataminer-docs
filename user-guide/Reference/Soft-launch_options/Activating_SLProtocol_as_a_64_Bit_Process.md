---
uid: Activating_SLProtocol_as_a_64_Bit_Process
---

# Activating SLProtocol as a 64-bit process

This is a soft-launch feature that can be activated from **DataMiner 10.1.8/10.2.0 onwards**<!-- RN 30063 -->. It is activated by default from **DataMiner 10.3.9/10.4.0 onwards**.<!-- RN 36725 -->

There are **two ways** to activate this soft-launch feature, depending on whether you want to combine this with an upgrade action or not.

> [!NOTE]
> While this can be activated on only some of the DMAs in a cluster, we strongly recommend that you use the same configuration on all DMAs.

## Activation with upgrade

1. Create an empty text file named *SoftLaunchX64_SLProtocol.txt* in the folder `C:\Skyline DataMiner\Tools` on each DMA. There is no need to stop the DMAs for this.

1. Install the DataMiner upgrade package.

## Activation without upgrade

1. Stop all DMAs where you want to enable this feature.

1. Launch a command line prompt as administrator on each of the DMAs.

1. Navigate to `C:\Skyline DataMiner\Tools\` in the prompts.

1. Execute `RegisterSLProtocolAsX64.bat` from the prompts.

1. Restart the DMAs.

### Examples

- Command line example:

  ```bash
  C:\> cd "C:\Skyline DataMiner\Tools\"
  C:\Skyline DataMiner\Tools> RegisterSLProtocolAsX64.bat
  ```

- PowerShell example:

  ```pwsh
  PS C:\> cd "C:\Skyline DataMiner\Tools\"
  PS C:\Skyline DataMiner\Tools> .\RegisterSLProtocolAsX64.bat
  ```

## Rollback

See [Activating SLProtocol as a 32-bit process](xref:Activating_SLProtocol_as_a_32_Bit_Process).
