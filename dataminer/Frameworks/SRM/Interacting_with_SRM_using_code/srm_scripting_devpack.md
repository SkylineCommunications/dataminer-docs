---
uid: srm_scripting_devpack
---

# SRM scripting using the SRM Dev Pack

Since [feature release 2.0.1](xref:SRM_2.0.1) of the SRM framework, a [DataMiner Dev Pack](xref:TOODataMinerDevPackages) is available that makes it easy to add the required dependencies to develop custom [SRM Automation scripts](xref:srm_scripting).

This `Skyline.DataMiner.Core.SRM` NuGet package is available on [nuget.org](https://www.nuget.org/packages/Skyline.DataMiner.Core.SRM). To start development using this package, make sure the [requirements for using NuGet packages](xref:TOODataMinerDevPackages#requirements) are met.

## Installing the SRM Dev Pack

1. Using [DataMiner Integration Studio](xref:Overall_concept_of_the_DataMiner_Integration_Studio), create a new Automation script or import a duplicate of one of the SRM example or template scripts.

1. Select the project of the Automation script action in the *Solution Explorer*, right-click it, and then select *Manage NuGet Packages*.

1. Click *Browse* and enter `Skyline.DataMiner.Core.SRM`.

   ![Browse for `Skyline.DataMiner.Core.SRM`](~/dataminer/images/SRM_BrowseForSkylineDataMinerCoreSRM.png)

1. Select the package and the matching version of the SRM framework that is used.

1. Click *Install*.

## Updating the SRM namespaces

When you start using the `Skyline.DataMiner.Core.SRM` Dev Pack for existing custom [SRM Automation scripts](xref:srm_scripting), some namespaces will need to be updated.

In earlier versions, the SRM framework library uses the `Skyline.DataMiner.Library.Solutions.SRM` namespace, but with the Dev Pack this changes to `Skyline.DataMiner.Core.SRM`.

For a recent overview of the namespaces that are initially required in a custom script, check the example or template scripts that come with the SRM framework:

- LSO: `SRM_DefaultEmptyLSO`
- Profile Load Script: `SRM_ProfileLoadScriptTemplate`
- Data Transfer Rules (DTR): `SRM_DataTransferRulesTemplate`
- Profile Load Script Tester: `SRM_ProfileLoadScriptTesterScriptExample`
- Booking Start Failure script: `SRM_BookingStartFailureTemplate`
