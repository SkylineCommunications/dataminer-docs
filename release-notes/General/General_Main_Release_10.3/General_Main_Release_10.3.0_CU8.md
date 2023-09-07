---
uid: General_Main_Release_10.3.0_CU8
---

# General Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### NATS connection could fail due to payloads being too large [ID_36427]

<!-- MR 10.3.0 [CU8] - FR 10.3.8 -->

In some cases, the NATS connection could fail due to payloads being too large. As a result, parameter updates and alarms would no longer be saved to the database.

#### Not all Protocol.Params.Param.Interprete.Others tags would not be read out [ID_36797]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would not be read out, which could lead to unexpected behavior.
