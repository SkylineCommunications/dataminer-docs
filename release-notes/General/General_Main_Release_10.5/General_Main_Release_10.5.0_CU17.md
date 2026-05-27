---
uid: General_Main_Release_10.5.0_CU17
---

# General Main Release 10.5.0 CU17 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> Before you upgrade to this DataMiner version:
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Main_Release_10.5.0_CU10#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU17](xref:Cube_Main_Release_10.5.0_CU17).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU17](xref:Web_apps_Main_Release_10.5.0_CU17).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Automation: File locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation [ID 45520]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, a file locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation while, on another thread, an attempt was being made to start another script using memory files.
