---
uid: Cube_Feature_Release_10.6.10
---

# DataMiner Cube Feature Release 10.6.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.10](xref:General_Feature_Release_10.6.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.10](xref:Web_apps_Feature_Release_10.6.10).

## Highlights

*No highlights have been selected yet.*

## New features

#### Automation: Credentials can now be added to automation scripts [ID 44282]

<!-- MR 10.7.0 - FR 10.6.10 -->

When adding or updating an automation script in DataMiner Cube, you can now add credentials just like you add dummies, parameters, or memory files.

If you open a script that contains credentials you are not allowed to use, the names of those credential will be replaced by `<Not Allowed>`. If you have permission to edit scripts, you will not be able to save the script until you replace those credentials with credentials you are allowed to use.

> [!NOTE]
>
> - Even if you are not allowed to use a certain credential added to a script, you will be allowed to execute that script if you have permission to execute scripts.
> - If you user permissions change while you are working in the Automation app, the changes will only take effect after you have re-opened the Automation app.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.10 or newer. See [Automation: Credentials can now be added within the XML code of an automation script [ID 44282]](xref:General_Feature_Release_10.6.10#automation-credentials-can-now-be-added-within-the-xml-code-of-an-automation-script-id-44282)

#### System Center: Backup password can now be set for restoring credentials [ID 45704]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->
<!-- Was reverted and later re-added to 10.6.10 -->

In the *Backup* section of *System Center*, you can now set a password for restoring credentials from a backup.

When you restore a backup on another DataMiner System, you will have to provide this password to be able to restore the credentials stored in that backup. All other data in the backup will be restored as usual.

When you restore a backup on the same DataMiner System, no password will be needed to restore the credentials.

> [!NOTE]
> When you open the Credentials Library, a warning message will appear when this password has not yet been set.

#### Credentials Library: Warning indicator will now displayed next to a credential that could not be decrypted [ID 45997]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->
<!-- Was reverted and later re-added to 10.6.10 -->

When DataMiner Cube detects that a credential in the Credentials Library can no longer be decrypted, a warning icon will now be displayed next to the credential name, which is also shown in a warning color.

When you hover over the warning icon, a tooltip will explain that the credential's secret values can no longer be decrypted and that you need to re-enter and save the values to resolve the issue.

## Changes

### Enhancements

#### Spectrum Analysis: Shared last preset is now available in shared session mode [ID 46113]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

If a spectrum analyzer is configured to work in shared session mode, a shared last session preset is now automatically kept. This means that when a user configures the spectrum analyzer and closes the card, the configuration is saved in a shared preset. When another user opens that spectrum analyzer, the same preset is loaded and all users will see the same configuration.

### Fixes

#### Alarm templates: Absolute proactive thresholds showed percentages instead of delta values [ID 46049]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In alarm templates, proactive thresholds of type *Absolute* were displayed with a percentage sign in the *Thresholds to take into account* setting (e.g., *Critical High (5000000 %)*).

This has now been corrected. Absolute thresholds are now shown with a delta prefix and no percentage sign (e.g., *Critical High (Δ 5000000)*), consistent with the regular alarm template editor.

#### Upgrades: End time was not always set correctly in the Overview tab [ID 46100]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you performed a DataMiner upgrade, it could occur that the end time in the *Overview* tab was not always set correctly. This issue has been resolved.

#### Spectrum Analysis: Measurement point cycle could be reset when the same spectrum element was opened in another component [ID 46111]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you opened a spectrum element in one spectrum analysis component and then opened the same element in another component with measurement points selected, the measurement point cycle in the first component could be reset. This issue has been resolved.

#### Credentials Library: Credential limit warning would be partially hidden behind the Add and Delete buttons [ID 46198]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The credentials library can contain a maximum of 1000 sets of credentials. When this limit is reached, users who want to add a new set of credentials will receive a warning. However, up to now, that warning would be partially hidden behind the *Add* and *Delete* buttons.
