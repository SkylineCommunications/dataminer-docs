---
uid: Disabling_Remote_Access_and_Live_Sharing
---

# Disabling Remote Access and Live Sharing locally

From version 2.13.8 of the [CloudGateway](xref:DataMinerExtensionModules#cloudgateway) DxM onwards<!-- RN 39113 -->, it is possible to disable the Remote Access and Live Sharing features for a particular server through the app settings of the DxM:

1. On each server where you want to disable these features, go to the folder `C:\Program Files\Skyline Communications\DataMiner CloudGateway`.

1. In this folder, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "RemoteAccessAndSharing": {
      "IsDisabled": true
   }
}
```

1. Restart *DataMiner CloudGateway* on each server for the changes to take effect.
