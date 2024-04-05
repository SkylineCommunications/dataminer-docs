---
uid: Disabling_bot_locally
---

# Disabling the bot feature locally

From version 2.10.6 of the [FieldControl](xref:DataMinerExtensionModules#fieldcontrol) DxM onwards, it is possible to disable the [bot feature](xref:DataMiner_Teams_bot) for a particular server through the app settings of the DxM:

1. On the server where you want to disable this feature, go to the folder `C:\Program Files\Skyline Communications\DataMiner FieldControl`.

1. In this folder, create or adjust the override *appsettings.custom.json* with the following contents:

```json
{
   "Bot": {
      "IsDisabled": true
   }
}
```
