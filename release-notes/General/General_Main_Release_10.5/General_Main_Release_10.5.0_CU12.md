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

#### Security Advisory BPA test: Enhancements [ID 44444] [ID 44477]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

Also, the following issues have now been fixed:

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

- On systems where the `enableLegacyV0Interface` flag is not set in the *web.config* file, the test that verifies whether the v0 web API is disabled would incorrectly assume that the v0 web API was enabled. From now on, when the `enableLegacyV0Interface` flag is not set in the *web.config* file, the v0 web API will be considered disabled.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 44479]

<!-- RN 44479: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

### Fixes

#### Delay of DataMiner startup routine caused by SLDataMiner starting up faster than SLNet [ID 44438]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

During DataMiner startup, in some rare cases, SLDataMiner would start up faster than SLNet. This would cause a delay of about 2 minutes in the entire startup routine.

#### Calls that check whether the connection between client and DMA is still alive would incorrectly be blocked when 10 simultaneous calls were being processed [ID 44456]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent were being processed, up to now, any additional call would be blocked, including calls that check whether the connection between client and DMA was still alive. As a result, the client application would disconnect.

From now on, even when 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent are being processed, calls that check whether the connection between client and DMA is still alive will never be blocked.
