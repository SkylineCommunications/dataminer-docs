---
uid: General_Feature_Release_10.2.12
---

# General Feature Release 10.2.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.12](xref:Cube_Feature_Release_10.2.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Failover: SLDataMiner will no longer be able to reclaim the virtual IP address when the agent goes offline [ID_34458]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the *DMS.xml* file, the *bruteForceToOffline* option is specified in the `<Failover>` element, SLDataMiner will not be notified when the agent's state goes from online to offline. Up to now, this could lead to SLDataMiner reclaiming the virtual IP address as it was not aware of any state change. Both agents would then incorrectly have the same virtual IP address.

From now on, when the *bruteForceToOffline* option is specified in the *DMS.xml* file, SLDataMiner will be asked to set the agent's state to offline and to not reclaim the virtual IP address before it has been released.

### Fixes

#### Problem with SLDataMiner when editing an element [ID_34329]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLDataMiner when you edited an element.

#### Standalone DVE parameter partially included in an service would incorrectly not affect service state severity [ID_34493]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a parameter of a DVE element exported as a standalone parameter was partially included in a service, in some cases, the service state could be incorrect.

#### Web apps - Visual Overview: New values would incorrectly be added to listboxes each time those listboxes got updated [ID_34515]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In Visio pages displayed in web apps, new values would incorrectly be added to listboxes each time those listboxes got updated.

#### Enabling conditional monitoring for a parameter would incorrectly cause iStatus -17 data points to be offloaded even when the trend data of that parameter had been excluded from offloads [ID_34540]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in an alarm template, you enabled conditional monitoring for a parameter, the iStatus -17 data points would incorrectly also be offloaded to the offload database when, in the trend template linked to that parameter, its trend data had been excluded from offloads.

#### Offload limit would not be taken into account when offloading files to a file cache [ID_34564]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

To have files offloaded to a file cache instead of to a database, in the *DB.xml* file, you can add a `<FileCache>` tag like the following.

However, up to now, the file cache offload limit (default: 10 GB) would incorrectly not be taken into account.

```xml
<DataBase active="true" local = "false">
    <FileCache enabled="true">
        <MaxSizeKB>10000</MaxSizeKB>
    </FileCache>
</DataBase>
```
