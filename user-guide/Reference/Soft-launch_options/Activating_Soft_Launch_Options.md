---
uid: Activating_Soft_Launch_Options
---

# Activating soft-launch options

For most soft-launch options, you will need the following file on your DataMiner server: `C:\Skyline DataMiner\SoftLaunchOptions.xml`. In this file, for each feature you want to activate, you can add a specific tag and set it to the value "true".

For example, this *SoftLaunchOptions.xml* configuration activates the "AlarmSquashing" and "CloudConnectedAgents" features:

```xml
<SLNet>
   <CloudConnectedAgents>true</CloudConnectedAgents>
   <AlarmSquashing>true</AlarmSquashing>
</SLNet>
```

> [!NOTE]
> All XML tags in *SoftLaunchOptions.xml* are case-sensitive.

After you have modified this configuration file, you must **restart your DataMiner Agent** to activate the changes. If you have a cluster of DataMiner Agents, every DataMiner Agent in the cluster will need to be restarted. Many of the soft-launch options also require an **IIS restart** when they are activated.

For some **Cube-only** features, it is not necessary to configure a tag in *SoftLaunchOptions.xml*. For these features, it is sufficient to access DataMiner Cube using a specific **argument**. In the Cube desktop app, you can specify this argument in the start window by clicking the “…” button in the tile representing the DMS you want to connect to, and then specifying the argument in the *Advanced* section. For more information, see [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).

For some features, a different configuration may be required. For more information, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).
