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

#### Swarming: Clearer error message when file contents cannot be retrieved [ID 43774]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, during a swarming operation, a file cannot be loaded, from now on, a clearer error message will be logged. The message will now include the reason of the failure, and, if the error occurred because the file was locked, the process locking the file will also be mentioned.

Also:

- If SLDataMiner is unable to load a certain file, it will shut down gracefully, and the DataMiner Agent will be stopped.
- If a process other than SLDataMiner is unable to load a certain file, then it will retry loading the file 10 times, and if, after all those retries, it is still not able to load the file, it will stop trying, and retry again when it needs to send a request to the storage module.

#### NATSMigration tool will now also check for outdated DLL files in the ProtocolScripts folder [ID 43778]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the *NATSMigration* tool will also check for outdated DLL files in the `C:\Skyline DataMiner\ProtocolScripts` folder.

When an outdated DLL file is found, the migration will be aborted. For the migration to succeed, the user will have to remove the outdated DLL file and update the protocol in question.

#### Automation: Engine class now exposes the public property ScriptName [ID 43840]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the `Engine` class exposes the public property `ScriptName`.

This means that, in an Automation script, it will now be possible to retrieve the name of that script.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 43854]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

### Fixes

*No fixes have been added yet.*
