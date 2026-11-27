---
uid: Activating_Soft_Launch_Options
description: DataMiner soft-launch options activate features that are not yet available to the general public. They can be enabled in SoftLaunchOptions.xml.
---

# Activating soft-launch options

Most soft-launch options can either be [configured manually in SoftLaunchOptions.xml](#manual-configuration-in-softlaunchoptionsxml) or [configured via the SLC-AS-SoftlaunchOptions interactive editor](#configuration-using-the-interactive-editor).

For some features, a [Cube-only configuration](#cube-only-options) is sufficient, or additional configuration may be required. For more information, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

> [!NOTE]
> When you create a [DaaS system](xref:Creating_a_DMS_in_the_cloud), some soft-launch options will be enabled by default. To change which soft-launch options are enabled, contact <daas@dataminer.services>. To know which options are enabled by default, see [Which soft-launch options are enabled on a DaaS system?](xref:Creating_a_DaaS_system_FAQ#which-soft-launch-options-are-enabled-on-a-daas-system)

## Manual configuration in SoftLaunchOptions.xml

For most soft-launch options, you can configure `C:\Skyline DataMiner\SoftLaunchOptions.xml` manually on each DataMiner Agent in the cluster. If this file is not present yet, you will need to create it. In this file, for each feature you want to activate, you can add a specific tag and set it to the value "true".

For example, this *SoftLaunchOptions.xml* configuration activates the "BookingSwarming" and "DataAPI" features:

```xml
<SLNet>
   <BookingSwarming>true</BookingSwarming>
   <DataAPI>true</DataAPI>
</SLNet>
```

> [!NOTE]
>
> - All XML tags in *SoftLaunchOptions.xml* are case-sensitive.
> - All soft-launch flags (e.g., `<BookingSwarming>`) must be placed within the `<SLNet>` parent tag.

After you have modified this configuration file, you must **restart your DataMiner Agent** to activate the changes. If you have a cluster of DataMiner Agents, every DataMiner Agent in the cluster will need to be restarted. Many of the soft-launch options also require an **IIS restart** when they are activated.

## Configuration using the interactive editor

On DataMiner Systems that are [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), you can use an interactive editor instead of configuring soft-launch options manually on each Agent in the cluster. To follow this procedure, you need to have [permission to execute automation scripts](xref:DataMiner_user_permissions#modules--automation--execute) and you must be able to [deploy Catalog items](xref:Deploying_a_catalog_item).

1. Deploy the [SLC-AS-SoftlaunchOptions package](https://catalog.dataminer.services/details/2ec1f7c0-25d8-4aeb-8e9f-8956904f9320) to your DataMiner System.

   This will add the interactive editor to your system but will not change any soft-launch settings.

1. In DataMiner Cube, run the *SLC-AS-SoftlaunchOptionsInteractive* automation script without specifying any parameters.

1. In the interactive editor, compare the settings across your cluster and set or remove options as needed.

   The editor will show whether the update succeeded on each target Agent.

1. Restart each affected Agent.

   Changes will typically only take effect after a DataMiner restart. The interactive editor does not restart Agents. Some options also require an IIS restart. For details, refer to [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

## Cube-only options

For some **Cube-only** features, it is not necessary to configure a tag in *SoftLaunchOptions.xml*. For these features, it is sufficient to access DataMiner Cube using a specific argument.

In DataMiner Cube, you can specify this argument in the start window by clicking the "..." button in the tile representing the DMS you want to connect to, and then specifying the argument in the *Advanced* section. For more information, see [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).
