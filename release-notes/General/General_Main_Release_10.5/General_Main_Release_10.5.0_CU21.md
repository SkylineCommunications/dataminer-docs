---
uid: General_Main_Release_10.5.0_CU21
description: "Release notes for General Main Release 10.5.0 CU21, including prerequisites, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.5.0 CU21 - Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU21](xref:Cube_Main_Release_10.5.0_CU21).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU21](xref:Web_apps_Main_Release_10.5.0_CU21).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Element severity could be incorrect after a restart when unmasked alarms were present [ID 46501]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When an element had unmasked alarms, its severity could be incorrect after it was restarted.

#### SNMP GET results could be matched to the wrong polling group [ID 46507]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When multiple polling groups were executed concurrently, results from SNMP GET requests could be matched to the wrong group, potentially causing runtime errors.

The group ID is now passed along with each SNMP GET request so that the result is matched to the correct group.

#### DataMiner memory usage could keep increasing during frequent GQI queries [ID 46560]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, every time a connection to the DataMiner storage layer was opened, SLNet would register handlers for logging configuration changes and incoming messages. These handlers were not removed when the connection closed, leaving their associated objects in memory for the lifetime of the process.

On systems where GQI queries repeatedly opened connections, for example through dashboards or low-code apps that refresh automatically, memory usage could keep increasing, potentially degrading performance or causing out-of-memory errors.

From now on, the handlers will be removed when the connection closes.

#### STaaS: Feedback registrations could cause a memory leak [ID 46617]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On STaaS systems, waiting for feedback or queues to be flushed for certain data types could leave event registrations uncleared and retain memory.

From now on, these registrations will be cleared when they are no longer needed.

#### STaaS: Certain exceptions were incorrectly wrapped [ID 46637]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In certain cases, exceptions were wrapped in another exception even though they should have been handled or left unwrapped.

#### SLAnalytics - Alarm Focus: Swarming notifications could be missed during startup [ID 46717]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, SLAnalytics subscribed to swarming notifications after startup prefetch, which could cause it to miss notifications while the cache was being initialized. From now on, it will subscribe before startup prefetch. History reads triggered during prefetch will wait for the cache lock; normal prefetched-cache lookup behavior will remain unchanged.

If an alarm for a migrating element is processed before its history loads, a fresh model could still have an incorrect likelihood, for example 0 instead of 0.2. The later history load could then skip that existing model, leaving the learned history unrestored.
