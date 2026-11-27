---
uid: VerifyCrowdEndOfSupport
description: "Learn about the VerifyCrowdEndOfSupport prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify Crowd End of Support

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyCrowdEndOfSupport* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses Atlassian Crowd as external authentication or for user and group management, which has reached [End of Support](xref:Software_support_life_cycles).

If Atlassian Crowd is in use and the [EndOfSupport.Crowd soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportcrowd) is not set to *true*, the upgrade is blocked.

## Fixing a failing prerequisite check

To resolve this, do one of the following:

- Migrate to another authentication method. This is the recommended solution.

- Temporarily continue using Atlassian Crowd by setting the [EndOfSupport.Crowd soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportcrowd) to *true* in `C:\Skyline DataMiner\SoftLaunchOptions.xml`. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

  > [!CAUTION]
  > Atlassian Crowd has reached End of Support. Only use this option temporarily.

> [!TIP]
> See also: [Configuring Atlassian Crowd settings](xref:Configuring_Atlassian_Crowd_settings)
