---
uid: Verify_No_Obsolete_API_Deployed
---

# Verify No Obsolete API Deployed

From DataMiner 10.4.0/10.4.1 onwards<!--RN 37825-->, the *VerifyNoObsoleteApiDeployed* prerequisite check is included in upgrade packages. This check ensures that no obsolete APIs are deployed on the DataMiner System and verifies whether the obsolete *APIDeployment* soft-launch option is enabled.

From DataMiner 10.4.0 onwards, the obsolete *API Deployment* feature is completely phased out and replaced with [User-Defined APIs](xref:UD_APIs). Upgrading to DataMiner 10.4.0 or higher will remove API Deployment along with its associated configurations and data. If you still have APIs deployed with this feature, they will be removed by the upgrade. This prerequisite check prevents this by prompting you to remove these deployments.

## Fixing a failing prerequisite check

If the *VerifyNoObsoleteApiDeployed* check fails and you **do not want to lose your APIs**, you will have to migrate them to the *User-Defined APIs* feature. For more information, see [Defining a new API](xref:UD_APIs_Define_New_API) and [Using existing scripts](xref:UD_APIs_Using_existing_scripts).

If you want to **remove obsolete APIs from your system**, follow the steps below. Note that you will also have to follow these steps after you have migrated your APIs to the *User-Defined APIs* feature.

1. Open DataMiner Cube, and log into your DataMiner System.

1. Go to *System Center* > *API deployment (Deprecated)*.

   Your APIs will be displayed in a tree view.

   ![Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/dataminer/images/UDAPIS_Migration_1.jpg)

1. To undeploy the API, click the button in the *Undeploy* column, and then click *Yes*.

When finished, you should only have *Unused Tokens* left in your tree view. This process only needs to be done on one DataMiner Agent in the cluster. The changes will be be synchronized to the rest of the cluster.

![No more Obsolete APIs in System Center in Cube on a 10.3.9 DataMiner](~/dataminer/images/UDAPIS_Migration_2.jpg)

> [!NOTE]
> It can occur that APIs are still considered deployed using API Deployment, but they are not shown in DataMiner Cube because the configuration was incorrectly loaded on the server. In this case, the prerequisite check will fail, but you will not see any deployed APIs in DataMiner Cube.
>
> To work around this issue, on every DataMiner Agent for which the prerequisite check fails, remove the *APIDeployment* soft-launch option from the [SoftLaunchOptions.xml](xref:Overview_of_Soft_Launch_Options) file.
>
> Keep in mind that when you **upgrade** to DataMiner 10.4.0 or higher, any **APIs you deployed using API Deployment will be removed**.