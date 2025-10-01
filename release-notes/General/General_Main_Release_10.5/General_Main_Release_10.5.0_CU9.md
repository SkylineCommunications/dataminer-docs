---
uid: General_Main_Release_10.5.0_CU9
---

# General Main Release 10.5.0 CU9 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU9](xref:Cube_Main_Release_10.5.0_CU9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU9](xref:Web_apps_Main_Release_10.5.0_CU9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### NATSMigration tool will now also check for outdated DLL files in the ProtocolScripts folder [ID 43778]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, the *NATSMigration* tool will also check for outdated DLL files in the `C:\Skyline DataMiner\ProtocolScripts` folder.

When an outdated DLL file is found, the migration will be aborted. For the migration to succeed, the user will have to remove the outdated DLL file and update the protocol in question.

### Fixes

*No fixes have been added yet.*
