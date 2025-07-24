---
uid: GQI_Extension_Libraries
---

# Extension Libraries

An extension library hosts one or more GQI extensions, such as ad hoc data sources or custom operators. Grouping multiple extensions in a single library enables close integration and allows them to share data internally, something not possible if they are separated into different libraries.

Extension libraries operate in isolation. To share logic or information between a data source and an operator, both must reside in the same library. Cross-library interaction is not supported.

## How Extension Libraries Work

Each extension library is compiled as an independent DLL and loaded by GQI. This uses the automation module’s [library compilation feature](xref:Compiling_a_CSharp_code_block_as_a_library). To include multiple extensions in one library, add several classes to your automation script or DIS ad hoc data source project.

## Managing Dependencies for GQI Extensions

When building GQI extensions, ensure all required DLLs are available. From DataMiner 10.5.0 [CU2]/10.5.5 onwards and when using [GQI DxM](xref:GQI_DxM)<!--RN 42468-->, GQI automatically searches for missing dependencies in the `C:\Skyline DataMiner\Scripts\Libraries` folder. This allows extension scripts to find necessary Automation script libraries at runtime.

> [!NOTE]
> If an Automation script library has its own dependencies, include those dependencies in your GQI extension scripts as well.
