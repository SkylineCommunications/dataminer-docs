---
uid: General_Main_Release_10.3.0_CU19
---

# General Main Release 10.3.0 CU19 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*There are no enhancements in this release yet.*

### Fixes

#### Progress information updates no longer available during DataMiner upgrade [ID_40348]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU6] - FR 10.4.9 -->

In some cases, it could occur that progress information updates during a DataMiner upgrade were no longer available. This was caused by long timeouts in gRPC connections. These could also trigger a race condition, causing the logic checking for progress updates on the client side to override a successful upgrade event. The timeouts will now occur more quickly, so that a reconnection occurs faster and updates become available again.
