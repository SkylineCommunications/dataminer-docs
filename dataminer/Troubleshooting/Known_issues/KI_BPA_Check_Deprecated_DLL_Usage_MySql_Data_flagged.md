---
uid: KI_BPA_Check_Deprecated_DLL_Usage_MySql_Data_flagged
---

# Check Deprecated DLL Usage BPA incorrectly flags MySql.Data NuGet as deprecated

## Affected versions

- DataMiner Main Release version 10.6.0.

- DataMiner Feature Release version 10.5.12 up to 10.6.3<!--RN 43779-->.

## Cause

In DataMiner 10.5.12/10.6.0, the code of the *Check Deprecated DLL Usage* BPA was modified. As part of this change, the check was expanded from only scanning `C:\Skyline Dataminer\ProtocolScripts\` to also scanning its subfolders.

As a result, the BPA now also evaluates DLLs located in `C:\Skyline Dataminer\ProtocolScripts\DllImport\` and its subfolders, and incorrectly flags the *MySql.Data* NuGet (*MySql.Data.dll*) as deprecated when it is located there.

## Fix

Install DataMiner 10.6.0 [CU1]/10.6.4<!-- RN 44758 -->.

## Workaround

No workaround is required.

If the BPA reports *MySql.Data.dll* as deprecated and the DLL is located in `C:\Skyline Dataminer\ProtocolScripts\DllImport\` or one of its subfolders, the result can be ignored.

## Description

When running the [*Check Deprecated DLL Usage* BPA](xref:BPA_Check_Deprecated_DLL_Usage), `MySql.Data.dll` may be incorrectly reported as deprecated. This occurs when the DLL is located in:

- `C:\Skyline Dataminer\ProtocolScripts\DllImport\`.

- Any subfolder of `C:\Skyline Dataminer\ProtocolScripts\DllImport\`.

The reported result is a false positive and has no further impact.
