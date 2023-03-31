---
uid: General_Feature_Release_10.2.11_CU1
---

# General Feature Release 10.2.11 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.11](xref:Cube_Feature_Release_10.2.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### SLProtocol could leak memory when a protocol with HTTP connections sent an HTTP request with a header [ID_34775]

<!-- MR 10.1.0 [CU20] / 10.2.0 [CU8] - FR 10.2.11 [CU1] -->

When a protocol with HTTP connections sent an HTTP request with a header, SLProtocol could leak memory.
