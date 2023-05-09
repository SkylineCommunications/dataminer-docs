---
uid: General_Main_Release_10.3.0_CU4
---

# General Main Release 10.3.0 CU4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when retrieving resources [ID_36129]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when retrieving resources.

#### Failover: Obsolete CheckVIPs thread has been removed [ID_36253]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In Failover setups using virtual IP addresses, once every minute the CheckVIPs thread would check whether the online Agent holds the correct IP addresses. However, due to the many locks it claimed to verify the current state of the IP addresses, it would delay other actions being executed in the system.

This obsolete thread has now been removed.

### Fixes

#### Service & Resource Management: Contributing resources where the contributing booking was ended were never available [ID_35757]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When an ongoing main booking that made use of a contributing resource of which the contributing booking had already ended, the ResourceManager would mark the contributing resource as unavailable even though it is available.




A contributing resource is only available within the time frame of the associated contributing booking.

When updating an ongoing main booking that makes use of a contributing resource that had an unlocked contributing booking that was already ended, the ResourceManager would mark the contributing resource as unavailable even though it is available.

Example use case:

Past                                     now                                future
-----------------------------------------------------------------------------------> time

    Contributing booking
|---------------------------|
                               Main booking using contributing
             |-------------------------------------------------------------|

Updating the main booking would fail and make it go into quarantine with reason 'ContributingResourceNotAvailable'. Calling 'GetEligibleResources' would also not return the contributing resource.






#### Protocols: QAction syntax errors did not refer to the correct lines [ID_36301]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, before a QAction was compiled, three compiler directives were added to its source code. As a result, all compilation errors would refer to incorrect line numbers.

From now on, the compiler directives will no longer be added to the source code. Instead, they will be passed to the compiler directly.
