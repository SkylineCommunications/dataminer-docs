---
uid: KI_GQI_DxM_unavailable_missing_Newtonsoft_Json
---

# GQI DxM unavailable because of missing Newtonsoft.Json assembly

## Affected versions

DataMiner web 10.5.0 [CU1]/10.5.4 or higher.

This issue only occurs after direct upgrades from DataMiner web 10.5.0 [CU0]/10.5.3 to higher versions. If you for example upgrade from 10.5.0 [CU1]/10.5.4 to 10.5.0 [CU2]/10.5.5, this will resolve the issue.

## Cause

The Newtonsoft NuGet dependency was downgraded in GQI version 1.0.18 (included in DataMiner web 10.5.0 [CU1]/10.5.4) in order to go from a direct reference to a transitive dependency when SLNetTypes was added as a NuGet in that GQI version. However, during MSI installation, the newer assembly will be removed while the older assembly will not be placed in the install location. As a result, after an upgrade to the affected versions, the assembly will not be present, and the GQI service will be unavailable.

## Fix

No fix is available yet.

## Workaround

Repair the DataMiner GQI service by running the DataMiner GQI MSI located in the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web`, or run a recent DataMiner upgrade that contains a GQI version that is different from the currently installed version.

## Description

In the DataMiner web apps, the GQI DxM is unavailable. The GQI logging contains a message stating `Could not load file or 'Newtonsoft.Json'`.
