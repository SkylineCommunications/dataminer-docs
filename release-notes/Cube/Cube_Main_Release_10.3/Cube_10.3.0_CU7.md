---
uid: Cube_Main_Release_10.3.0_CU7
---

# DataMiner Cube Main Release 10.3.0 CU7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU6](xref:General_Main_Release_10.3.0_CU6).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Visual Overview: Viewport variable also set in code when set by user [ID_37011]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a user set the *Viewport* variable on a Resource Manager timeline component in Visual Overview, DataMiner set the variable again in the code, which caused the value to change to serialized format. While this did not cause functional changes, it could potentially cause unpredictable behavior, for example in case a condition was configured based on the value of the variable. This will now be prevented.
