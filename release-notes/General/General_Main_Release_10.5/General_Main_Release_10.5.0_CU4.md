---
uid: General_Main_Release_10.5.0_CU4
---

# General Main Release 10.5.0 CU4 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU4](xref:Cube_Main_Release_10.5.0_CU4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU4](xref:Web_apps_Main_Release_10.5.0_CU4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: ModuleInstaller upgrade action timeout has been increased to 30 minutes [ID 42659]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, the ModuleInstaller upgrade action would time out after 15 minutes. As this action typically runs for more than 15 minutes, this would ofter cause a notice to be logged.

From now on, the ModuleInstaller upgrade action will only time out after 30 minutes.

### Fixes

#### LDAP users added as part of an LDAP user group would incorrectly appear as local users instead of domain users [ID 42743]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, LDAP users who had been added to DataMiner as part of an LDAP user group would incorrectly appear as local users instead of domain users.

#### Problem with SLNet caused by 'DefaultUpgradeOptions' element in MaintenanceSettings.xml file [ID 42746]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in the *MaintenanceSettings.xml* file, the `<SLNet>` element contained a `<DefaultUpgradeOptions>` sub-element, up to now, SLNet would fail to start up correctly.

> [!NOTE]
> The above-mentioned `<DefaultUpgradeOptions>` element will be added to the *MaintenanceSettings.xml* file the first time you make any changes to the default upgrade options. To change these options in DataMiner Cube, go to *System Center > System Settings > Upgrade*.

#### Problem when upgrading a DMA using BrokerGateway [ID 42853]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

While a DataMiner Agent using BrokerGateway was being upgraded, in some cases, a `nats-server could not be started` error could get thrown.
