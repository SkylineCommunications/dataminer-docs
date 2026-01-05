---
uid: Verify_No_Amazon_Keyspaces
---

# Verify No Amazon Keyspaces

From DataMiner 10.5.0/10.5.3 onwards<!--RN 41914-->, the *VerifyNoAmazonKeyspaces* prerequisite check is included in upgrade packages. This check verifies that the DataMiner Agent does not rely on the Amazon Keyspaces Service on AWS for data storage.

From DataMiner 10.3.0 [CU8]/10.3.11 onwards, support for the Amazon Keyspaces Service is *End of Life*. We recommend switching to [Storage as a Service](xref:STaaS) instead.

> [!TIP]
> See also: [Third-party software support lifecycle](xref:Software_support_life_cycles#third-party-software-support-lifecycle)

## Fixing a failing prerequisite check

If the *VerifyNoAmazonKeyspaces* check fails, your DMA is still using the Amazon Keyspaces Service on AWS as a Cassandra-compatible database service.

To resolve this:

- Switch to [Storage as a Service (STaaS)](xref:STaaS) (recommended).

- If you want to use self-managed storage, switch to a Cassandra Cluster setup. However, note that this setup is not recommended. For more information, see [Storage options overview](xref:Supported_system_data_storage_architectures).
