---
uid: Verify_ASP_Net_Version
---

# Verify .NET Version

From DataMiner 10.3.0 [CU12]/10.4.0/10.4.3 onwards<!--RN 37969-->, the *VerifyDotNetVersion* prerequisite check is included in upgrade packages. This check verifies whether the required .NET versions are installed, necessary for guaranteeing DataMiner's access to all requisite security updates.

It checks whether the following versions are installed:

- **Microsoft ASP.NET 8.0**: If this check fails, install the [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) before continuing the upgrade.

- **Microsoft ASP.NET 10.0**: Checked from DataMiner 10.6.1/10.6.0 [CU0]/10.5.0 [CU10] onwards<!--RN 44121-->. If this check fails, install the [Microsoft ASP.NET 10.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) before continuing the upgrade.

You may have to **reboot the server** after installation to be able to pass this prerequisite check.

> [!TIP]
> See also: [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)
