---
uid: VerifyRadiusEndOfSupport
description: "Learn about the VerifyRadiusEndOfSupport prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify RADIUS End of Support

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyRadiusEndOfSupport* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses RADIUS as external authentication, which has reached [End of Support](xref:Software_support_life_cycles).

If RADIUS authentication is in use and the [EndOfSupport.RADIUS soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportradius) is not set to *true*, the upgrade is blocked.

## Fixing a failing prerequisite check

To resolve this, do one of the following:

- Migrate to another authentication method. This is the recommended solution.

- Temporarily continue using RADIUS by setting the [EndOfSupport.RADIUS soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportradius) to *true* in `C:\Skyline DataMiner\SoftLaunchOptions.xml`. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

  > [!CAUTION]
  > RADIUS authentication has reached End of Support. Only use this option temporarily.

> [!TIP]
> See also: [Configuring RADIUS settings](xref:Configuring_RADIUS_settings)
