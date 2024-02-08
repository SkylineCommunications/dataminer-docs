---
uid: General_Main_Release_10.3.0_CU13
---

# General Main Release 10.3.0 CU13 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: New prerequisite will check whether ASP.NET 8.0 Hosting Bundle is installed [ID_37969]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you upgrade a DataMiner System, a new prerequisite will now block the upgrade when the server does not have [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer) installed.

### Fixes

#### SLAnalytics - Automatic incident tracking: Problem when updating alarm groups [ID_38629]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Each time the focus score of an alarm is updated, incident tracking has to update its alarm groups. In some cases, incident tracking would incorrectly update its groups twice, causing the groups to be set to an undefined state.
