---
uid: Cube_Main_Release_10.3.0
---

# DataMiner Cube Main Release 10.3.0

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

## Other new features

#### Automation app: Casing of a script name can now be changed [ID_33988]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In the Automation app, it is now possible to change the casing of a script name.

Also, if you change the casing of a script name that was selected, it will remain selected. 

#### Visual Overview - Conditional shape manipulation: Using statistics in the condition when the shape is linked to an EPM object [ID_34026]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When applying conditional shape manipulation actions to a shape, up to now, it was only possible to use statistics in the condition if the shape was linked to an element, a service or a view. From now on, you can also use statistics in the condition when the shape is linked to an EPM object.

Example in which both the SystemName and the SystemType are linked:

```txt
<A>-A|SystemType= Cable;SystemName=SF Cable1|#TotalAlarms|>0
```

Supported statistics:

- #TotalAlarms
- #CriticalAlarms
- #MajorAlarms
- #MinorAlarms
- #WarningAlarms
- #NormalAlarms
- #TimeoutAlarms
- #NoticeAlarms
- #ErrorAlarms

Supported operators:

- =
- !=
- \>
- \>=
- \<
- \<=

## Changes

### Enhancements

#### Start window enhancements [ID_34033]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the DataMiner Cube start window:

- When you hover over a cluster tile, a tooltip will now appear, showing the cluster name, the cluster alias, the hostname of the agent and the last-known server version (if any). The latter will be updated when you connect to the cluster in question and when an update occurs in the background.

    > [!NOTE]
    > Cluster tiles will no longer display the hostname of the agent if it is identical to the cluster alias.

- When using the search box to filter the tiles, the last-known server version will now also be checked. This will allow users to search for clusters with a specific server version.

- When you check for updates (by clicking the cogwheel icon in the bottom-right corner and selecting *Check for updates*), the last-known server version will now be taken into account to avoid having to contact every configured cluster. If a DataMiner Agent has been upgraded since the last background update, the new client version will be downloaded from the agent the first time you connect to it or from the cloud during the next background update (if that version is newer that the current version).

    > [!NOTE]
    > - If you hold the SHIFT key when clicking *Check for updates*, a full update will start. Depending on the number of clusters in your configuration, this can take some time.
    > - An update triggered by the *Update DataMiner Cube_ [userID]* task in Windows Task Scheduler will always be a full update.

- When the start window application is downloaded from a DataMiner Agent, the cluster is automatically configured. Up to now, if it was possible to reach the agent via HTTPS within 2 seconds, the cluster was configured as "HTTPS only". However, in some cases, 2 seconds was too short, resulting in HTTPS agents being configured as "HTTP or HTTPS". From now on, the start window application will wait up to 5 seconds.

- When you add a new cluster, it will now always be added to the group containing the currently selected cluster.

- The maximum size of the daily log file has been increased from 1 MB to 100 MB.

### Fixes


