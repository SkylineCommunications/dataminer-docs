---
uid: Disabling_artifact_deployments
reviewer: Alexander Verkest
---

# Disabling artifact deployments locally

From version 1.6.9 of the [ArtifactDeployer](xref:DataMinerExtensionModules#artifactdeployer) DxM onwards<!-- RN 39113 -->, it is possible to disable artifact deployments to a particular server through the app settings of the DxM:

1. On each server where you want to disable artifact deployments, go to the folder `C:\Program Files\Skyline Communications\DataMiner ArtifactDeployer`.

1. In this folder, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "DeployArtifactOptions": {
      "IsDisabled": true
   }
}
```

1. Restart *DataMiner ArtifactDeployer* on each server for the changes to take effect.
