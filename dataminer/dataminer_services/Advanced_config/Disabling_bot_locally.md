---
uid: Disabling_bot_locally
reviewer: Alexander Verkest
---

# Disabling the bot feature locally

From version 2.10.6 of the [FieldControl](xref:DataMinerExtensionModules#fieldcontrol) DxM onwards<!-- RN 39113 -->, it is possible to disable the [bot feature](xref:DataMiner_Teams_bot) for a particular server through the app settings of the DxM:

1. On each server where you want to disable this feature, go to the folder `C:\Program Files\Skyline Communications\DataMiner FieldControl`.

1. In this folder, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "Bot": {
      "IsDisabled": true
   }
}
```

1. Restart *DataMiner FieldControl* on each server for the changes to take effect.
