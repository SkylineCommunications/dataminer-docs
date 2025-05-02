---
uid: General_Feature_Release_10.5.7
---

# General Feature Release 10.5.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.7](xref:Cube_Feature_Release_10.5.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.7](xref:Web_apps_Feature_Release_10.5.7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### DataMiner upgrade: ModuleInstaller upgrade action timeout has been increased to 30 minutes [ID 42659]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, the ModuleInstaller upgrade action would time out after 15 minutes. As this action typically runs for more than 15 minutes, this would ofter cause a notice to be logged.

From now on, the ModuleInstaller upgrade action will only time out after 30 minutes.

### Fixes

#### Not all DCF interfaces would be listed in the Connectivity tab of an element's Properties window [ID 42591]

<!-- MR 10.6.0 - FR 10.5.7 -->

When, in e.g. DataMiner Cube, you opened the *Connectivity* tab in the *Properties* window of an element, in some rare cases, not all DCF interfaces would be listed.

#### LDAP users added as part of an LDAP user group would incorrectly appear as local users instead of domain users [ID 42743]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, LDAP users who had been added to DataMiner as part of an LDAP user group would incorrectly appear as local users instead of domain users.

#### Problem with SLNet caused by 'DefaultUpgradeOptions' element in MaintenanceSettings.xml file [ID 42746]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in the *MaintenanceSettings.xml* file, the `<SLNet>` element contained a `<DefaultUpgradeOptions>` sub-element, up to now, SLNet would fail to start up correctly.

> [!NOTE]
> The above-mentioned `<DefaultUpgradeOptions>` element will be added to the *MaintenanceSettings.xml* file the first time you make any changes to the default upgrade options. To change these options in DataMiner Cube, go to *System Center > System Settings > Upgrade*.

#### Problem when upgrading a DMA using BrokerGateway [ID 42853]

<!-- MR 10.6.0 - FR 10.5.7 -->

While a DataMiner Agent using BrokerGateway was being upgraded, in some cases, a `nats-server could not be started` error could get thrown.
