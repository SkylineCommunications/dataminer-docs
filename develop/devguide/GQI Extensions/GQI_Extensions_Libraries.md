---
uid: GQI_Extension_Libraries
---

# Extension libraries

An extension library is a collection of one or more [GQI extensions](xref:GQI_Extensions). Every extension is part of such a library. Extensions within the same library are always **shipped together**, use the **same dependencies** and can **share data**.

Extension libraries operate in isolation: extensions that reside in different libraries cannot directly interact which each other.

> [!TIP]
> When creating multiple GQI extensions that logically belong together, it is good practice to include them in the same extension library.

## Working with extension libraries

Each extension library is a standalone DLL file that can be loaded by GQI. The DLL is created by the [library compilation feature](xref:Compiling_a_CSharp_code_block_as_a_library) of the Automation module.

To include multiple extensions in the same library, create them in the same Automation script code block or in the same DIS ad hoc data source project.

See also:

- [Creating an ad hoc data source](xref:Ad_hoc_Creation)
- [Creating a custom operator](xref:CO_Creation)

## Managing dependencies for GQI extensions

All GQI extensions defined within the same extension library will use the same dependencies.

Similar to Automation scripts, extension libraries may use DLL dependencies that are defined in the *DLL references* section in the associated Automation script.

From DataMiner 10.5.0 [CU2]/10.5.5 onwards and when using the [GQI DxM](xref:GQI_DxM)<!--RN 42468-->, GQI also automatically searches for missing dependencies in the `C:\Skyline DataMiner\Scripts\Libraries` folder. This allows extension scripts to find the necessary Automation script libraries at runtime.

> [!NOTE]
> If an Automation script library has its own dependencies, include those dependencies in your GQI extension scripts as well.
