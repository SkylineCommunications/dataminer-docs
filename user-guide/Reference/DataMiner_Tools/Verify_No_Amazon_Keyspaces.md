---
uid: Verify_No_Amazon_Keyspaces
---

# Verify No Amazon Keyspaces

In DataMiner 10.5.0/10.5.3<!--RN 41914-->, the *VerifyNoAmazonKeyspaces* prerequisite check is added to upgrade packages. This check verifies that the DataMiner Agent does not rely on the Amazon Keyspaces Service on AWS as an alternative to a Cassandra Cluster setup.

From DataMiner 10.3.0 [CU8]/10.3.11 onwards, Amazon Keyspaces Service is *End of Life*. To configure a functional dedicated clustered storage setup, you can [deploy a Cassandra Cluster setup](xref:Installing_Cassandra). However, we strongly recommend moving to [Storage as a Service](xref:STaaS).

> [!TIP]
> See also: [Third-party software support life cycle](xref:Software_support_life_cycles#third-party-software-support-life-cycle)

## Fixing a failing prerequisite check

If the *VerifyNoAmazonKeyspaces* check fails, your DMA is still using Amazon Keyspaces Service on AWS as a Cassandra-compatible database service.

To resolve this:

- Switch to [Storage as a Service (STaaS)](xref:STaaS) (recommended).

- If you want to use self-managed storage, install a [Cassandra Cluster](xref:Cassandra_database) database.
