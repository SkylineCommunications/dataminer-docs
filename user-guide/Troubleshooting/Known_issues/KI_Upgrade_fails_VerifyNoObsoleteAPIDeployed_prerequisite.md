---
uid: KI_Upgrade_fails_VerifyNoObsoleteApiDeployed_prerequisite
---

# Upgrade fails because of VerifyNoObsoleteApiDeployed.dll prerequisite

## Affected versions

DataMiner 10.4.0 or newer.

## Cause

From DataMiner 10.4.0 onwards, the obsolete *API Deployment* feature will be completely removed from DataMiner and replaced by [User-Defined APIs](xref:UD_APIs). The *VerifyNoObsoleteApiDeployed* upgrade prerequisite check verifies that no obsolete APIs are deployed before upgrading, as these will no longer work after the upgrade.

## Fix

If you do not want to lose your APIs, you will have to migrate them to the *User-Defined APIs* feature. For more information, see [Defining a new API](xref:UD_APIs_Define_New_API) and [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

If you want to remove obsolete APIs from your system, follow the steps below. Note that you will also have to follow these steps after you have migrated your APIs to the *User-Defined APIs* feature.

1. Open DataMiner Cube, and log into your DataMiner System.

1. Go to *System Center* > *API deployment (Deprecated)*.

   Your APIs will be displayed in a tree view.

   ![Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/user-guide/images/UDAPIS_Migration_1.jpg)

1. To undeploy the API, click the button in the *Undeploy* column, and then click *Yes*.

When finished, you should only have *Unused Tokens* left in your tree view. This process only needs to be done on one DataMiner Agent in the cluster. The changes will be be synchronized to the rest of the cluster.

![No more Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/user-guide/images/UDAPIS_Migration_2.jpg)

> [!NOTE]
> It can occur that APIs are still considered deployed using API Deployment, but they are not shown in DataMiner Cube because the configuration was incorrectly loaded on the server. In this case, the prerequisite check will fail, but you will not see any deployed APIs in DataMiner Cube.
>
> To work around this issue, on every DataMiner Agent for which the prerequisite check fails, remove the *APIDeployment* soft-launch option from the [SoftLaunchOptions.xml](xref:Overview_of_Soft_Launch_Options) file.
>
> Keep in mind that when you **upgrade** to DataMiner 10.4.0 or higher, any **APIs you deployed using API Deployment will be removed**.

## Issue description

Upgrading to 10.4.0 or newer will remove *API Deployment* and all configuration/data related to it. If you still have APIs deployed with this feature, they would be removed by the upgrade. This prerequisite check prevents this by forcing you to remove the deployments.
