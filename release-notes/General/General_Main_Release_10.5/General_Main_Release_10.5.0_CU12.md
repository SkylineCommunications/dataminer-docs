---
uid: General_Main_Release_10.5.0_CU12
---

# General Main Release 10.5.0 CU12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU12](xref:Cube_Main_Release_10.5.0_CU12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU12](xref:Web_apps_Main_Release_10.5.0_CU12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### An error will now be logged if the response to an SNMP Get request cannot be mapped [ID 44329]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If the response to an *SNMP Get* request cannot be mapped, from now on, an error will be logged in the log file of the element in question and in the *SLErrorsInProtocol.txt* file.

##### Security Advisory BPA test: Enhancements [ID 44444]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

A number of enhancements have been made to the Security Advisory BPA test:

- Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

### Fixes

#### Delay of DataMiner startup routine caused by SLDataMiner starting up faster than SLNet [ID 44438]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

During DataMiner startup, in some rare cases, SLDataMiner would start up faster than SLNet. This would cause a delay of about 2 minutes in the entire startup routine.
