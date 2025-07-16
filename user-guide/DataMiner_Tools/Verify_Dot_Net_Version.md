---
uid: Verify_ASP_Net_Version
---

# Verify .NET Version

From DataMiner 10.3.0 [CU12]/10.4.0/10.4.3 onwards<!--RN 37969-->, the *VerifyDotNetVersion* prerequisite check is included in upgrade packages. This check verifies whether Microsoft ASP.NET 8.0 is installed, necessary for guaranteeing DataMiner's access to all requisite security updates.

If this check fails, please install the [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.6-windows-hosting-bundle-installer) before continuing the upgrade. You may have to reboot the server after installation to be able to pass this prerequisite check.

> [!TIP]
> See also: [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)
