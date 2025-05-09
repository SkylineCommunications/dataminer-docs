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

#### Visual Overview in the web apps: Enhanced behavior in case of a failing visual overview request [ID 42677]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a request for a visual overview in a web app failed, up to now, that request would incorrectly not be removed, causing it to block all subsequent requests for a visual overview in a web app. From now on, when a request for a visual overview in a web app fails, it will be removed from the list of pending requests.

#### Enhanced processing of service deletions [ID 42754]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a service was migrated from one DMA to another within the same DMS, in some cases, the service would be deleted by the DMA that hosted the service originally instead of the DMA that was hosting the service when it was migrated. This could potentially lead to issues within the cluster.

From now on, the message ordering the deletion of a service will always be sent to the DMA that is hosting the service. That DMA will then forward the message to the other DMAs within the cluster.

#### Failover: Enhanced performance when executing a Failover switch [ID 42842]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Because of a number of enhancements, overall performance has increased when executing a Failover switch.

### Fixes

#### Not all DCF interfaces would be listed in the Connectivity tab of an element's Properties window [ID 42591]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in e.g. DataMiner Cube, you opened the *Connectivity* tab in the *Properties* window of an element, in some rare cases, not all DCF interfaces would be listed.

#### LDAP users added as part of an LDAP user group would incorrectly appear as local users instead of domain users [ID 42743]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, LDAP users who had been added to DataMiner as part of an LDAP user group would incorrectly appear as local users instead of domain users.

#### Problem with SLNet caused by 'DefaultUpgradeOptions' element in MaintenanceSettings.xml file [ID 42746]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in the *MaintenanceSettings.xml* file, the `<SLNet>` element contained a `<DefaultUpgradeOptions>` sub-element, up to now, SLNet would fail to start up correctly.

> [!NOTE]
> The above-mentioned `<DefaultUpgradeOptions>` element will be added to the *MaintenanceSettings.xml* file the first time you make any changes to the default upgrade options. To change these options in DataMiner Cube, go to *System Center > System Settings > Upgrade*.

#### Problem with SLNet and/or SLHelper when the NATS connection between them was unavailable [ID 42755]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When the NATS connection between SLNet and SLHelper was unavailable, in some cases, either of those processes could stop working.

#### Problem when deleting a newly created service that had failed to load [ID 42775]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a service was created, in some cases, loading that new service would fail, even though a *service.xml* file had correctly been added on disk.Moreover, deleting that service would also fail, making it impossible to create a new service with an identical name.

From now on, when a new service fails to load, additional logging will be added, and a backup *service.xml* file will be created in the `C:\Skyline DataMiner\Recycle Bin\` folder for debugging purposes.

Also, when the service that failed to load is deleted, an attempt will be made to delete the files and folders associated with that service in order to prevent any subsequent issues when creating a new service with an identical name.
