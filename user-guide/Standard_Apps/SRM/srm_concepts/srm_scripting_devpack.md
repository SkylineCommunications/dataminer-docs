---
uid: srm_scripting_devpack
---

# SRM scripting using the SRM Dev Pack

Since [version 2.0.1](xref:SRM_2.0.1) of the SRM Framework a [DataMiner Dev Pack](xref:TOODataMinerDevPackages) is available to easily add the required dependencies to develop [custom SRM Automation scripts](xref:srm_scripting).

The `Skyline.DataMiner.Core.SRM` NuGet package is available on [nuget.org](https://www.nuget.org/packages/Skyline.DataMiner.Core.SRM). To start development using this package make sure these [requirements](xref:TOODataMinerDevPackages#requirements) are available.

## How to install

Using the [DataMiner Integration Studio (DIS) extension](xref:Overall_concept_of_the_DataMiner_Integration_Studio) create a new automation script or import a duplicate of one the SRM example or template scripts.

To start using the Dev Pack, select the project of the Automation script action in the *Solution Explorer*, right-click it, and then select *Manage NuGet Packages*. Click *Browse* and type "Skyline.DataMiner.Core.SRM". Select the package and the matching version of the SRM Framework that is used, and click the *Install* button.

![Browse for `Skyline.DataMiner.Core.SRM`](../../../images/SRM_BrowseForSkylineDataMinerCoreSRM.png)

## How to update

When starting to use the `Skyline.DataMiner.Core.SRM` Dev Pack for existing [custom SRM Automation scripts](xref:srm_scripting) some namespaces will need to be updated.

Previously the SRM Framework library used the the `Skyline.DataMiner.Library.Solutions.SRM` namespace. This is now changed to `Skyline.DataMiner.Core.SRM`.

For a recent overview of the namespaces that are initially required in a custom script, check the example of template script available in the SRM Framework:

- LSO: `SRM_DefaultEmptyLSO`
- Profile Load Script: `SRM_ProfileLoadScriptTemplate`
- Data Transfer Rules (DTR): `SRM_DataTransferRulesTemplate`
- Profile Load Script Tester: `SRM_ProfileLoadScriptTesterScriptExample`
- Booking Start Failure script: `SRM_BookingStartFailureTemplate`
