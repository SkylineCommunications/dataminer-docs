---
uid: KI_Upgrade_fails_VerifyNoObsoleteApiDeployed_prerequisite
---

# Upgrade fails because of VerifyNoObsoleteApiDeployed.dll prerequisite

## Affected versions

From DataMiner 10.4.0 onwards

## Cause

From DataMiner 10.4.0 onwards, the obsolete *API Deployment* feature will be completely removed from DataMiner and replaced by [User-Defined APIs](xref:UD_APIs). The VerifyNoObsoleteApiDeployed upgrade prerequisite verifies no obsolete APIs are deployed before upgrading as these will not work anymore after the upgrade.

## Fix

If you don't want to lose your APIs, you will have to migrate them to use the new User-Defined APIs feature. There is documentation on how to [define a new API](xref:UD_APIs_Define_New_API) and how to [create an API from an existing automation script](xref:UD_APIs_Using_existing_scripts).

If you just want to remove your obsolete APIs from your system, follow below steps. Note that you will also have to follow these steps after you migrated your APIs to the *User-Defined APIs* feature.

1. Open DataMiner Cube, and log into your DataMiner System.

1. Go to *System Center* > *API deployment (Deprecated)*

     Your APIs will be displayed in a tree view

      ![Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/user-guide/images/UDAPIS_Migration_1.jpg)

1. To undeploy the API, click the button in the *Undeploy* column, then *Yes*.

When finished, you should only have *Unused Tokens* left in your treeview. This process only needs to be done on one system in the cluster, changes will be synced to the entire cluster.

![No more Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/user-guide/images/UDAPIS_Migration_2.jpg)

## Issue description

Upgrading to 10.4.0+ will remove API Deployment and all configuration/data related to it. If you still have APIs deployed with this feature, they would be removed by the upgrade. This prerequisite prevents this by forcing you to remove the deployments.

> [!TIP]
> If you cannot see the UI in *System Center*, you could be missing the *APIDeployment* soft-launch flag. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options) for more info.
