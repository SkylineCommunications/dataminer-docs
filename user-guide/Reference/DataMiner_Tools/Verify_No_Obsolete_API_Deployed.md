---
uid: Verify_No_Obsolete_API_Deployed
---

# Verify No Obsolete API Deployed

In DataMiner 10.4.0/10.4.1<!--RN 37825-->, the *VerifyNoObsoleteApiDeployed* prerequisite check is added to upgrade packages. This check ensures that no obsolete APIs are deployed on the DataMiner System and verifies whether the *APIDeployment* soft-launch option is enabled.

From DataMiner 10.4.0 onwards, the obsolete *API Deployment* feature is completely phased out and replaced with [User-Defined APIs](xref:UD_APIs). Upgrading to DataMiner 10.4.0 or higher will remove API Deployment along with its associated configurations and data. If you still have APIs deployed with this feature, they will be removed by the upgrade. This prerequisite check prevents this by prompting you to remove these deployments.

If the *VerifyNoObsoleteApiDeployed* check fails, refer to [Upgrade fails because of VerifyNoObsoleteApiDeployed.dll prerequisite](xref:KI_Upgrade_fails_VerifyNoObsoleteApiDeployed_prerequisite).
