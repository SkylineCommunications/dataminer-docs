---
uid: General_Main_Release_10.4.0_CU4
---

# General Main Release 10.4.0 CU4 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Service & Resource Management: Enhanced performance when creating multiple bookings simultaneously [ID_39390]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when creating multiple bookings simultaneously.

### Fixes

#### SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString' [ID_39425]

<!-- MR 10.3.0 [CU16]/10.4.0 [CU4] - FR 10.4.7 -->

Up to now, SLSNMPAgent would incorrectly interpret variable trap bindings of type 'IpAddress' as bindings of type 'OctetString'.

