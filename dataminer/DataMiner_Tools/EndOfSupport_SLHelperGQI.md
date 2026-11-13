---
uid: EndOfSupport_SLHelperGQI
description: "Find out how the GQI in SLHelper upgrade prerequisite verifies whether a DataMiner Agent still uses GQI via SLHelper, and how to fix a failing check."
---

# GQI in SLHelper upgrade prerequisite

From DataMiner 10.7.0/10.7.1 onwards, GQI via SLHelper is disabled by default.<!-- RN 46927 --> Upgrade packages from that version onwards include the *EndOfSupport.SLHelperGQI* prerequisite check, which verifies whether a DataMiner Agent running a version older than 10.7.0 is ready for this change.<!-- RN 46957 -->

## Fixing a failing prerequisite check

The check can report one or more of the issues below. After you have resolved them, try upgrading again.

### WebAPI still uses GQI via SLHelper

The WebAPI is explicitly configured with `gqi:useDxM` set to `false`. To resolve this, [enable the GQI DxM](xref:GQI_DxM#enabling-or-disabling-the-use-of-the-gqi-dxm).

### Recent SLHelper GQI activity was detected

Files in `C:\Skyline DataMiner\Logging\GQI` or its subfolders were modified in the last 30 days, which indicates that GQI via SLHelper is still in use.

To resolve this, make sure all GQI clients use the GQI DxM, including [Data Aggregator](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries). If you still need GQI via SLHelper, or if you recently used it, enable the [EndOfSupport.SLHelperGQI soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportslhelpergqi) instead.

> [!WARNING]
> GQI via SLHelper has reached [End of Support](xref:Software_support_life_cycles) and is no longer actively supported. It will reach End of Life in an upcoming DataMiner version, which will require you to remove the soft-launch option before you can upgrade.

### Failed to check configuration

The check could not read the configuration it needs, for example because *SoftLaunchOptions.xml* is not valid XML. Correct the reported problem. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).
