---
uid: General_Feature_Release_10.4.5
---

# General Feature Release 10.4.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.5](xref:Cube_Feature_Release_10.4.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.5](xref:Web_apps_Feature_Release_10.4.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID_38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

## Changes

### Enhancements

#### Service & Resource Management: Enhanced performance of volume license check [ID_38705]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when performing volume license checks.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID_38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### Enhanced performance when starting up a DataMiner Agent with a large number of virtual elements [ID_38780]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent with a large number of virtual elements.

#### Security enhancements [ID_38904]

<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

### Fixes

#### Problem with user accounts [ID_38182]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

In some cases, user accounts could become corrupted.

Also, in some cases, SLDataMiner could stop working when an alarm template or trend template was uploaded, removed, assigned or unassigned.

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### GQI: Problem when loading extensions [ID_38998]

<!-- MR 10.5.0 - FR 10.4.5 -->

When GQI extensions (i.e. ad hoc data sources or custom operators) were being loaded, in some cases, an exception could be thrown when inspecting the assembly of an extension that prevented subsequent extensions from being loaded.

This type of exceptions will be now be properly caught and logged as warnings so that other extensions will no longer be prevented from being loaded.

> [!TIP]
> See also: [GQI: Full logging [ID_38870]](xref:General_Feature_Release_10.4.4#gqi-full-logging-id_38870)

#### Problem while checking whether the DataMiner System was licensed to use the ModelHost DxM [ID_39001]

<!-- MR 10.5.0 - FR 10.4.5 -->

A *ModelHostException* could be thrown while checking whether the DataMiner System was licensed to use the ModelHost DxM.
