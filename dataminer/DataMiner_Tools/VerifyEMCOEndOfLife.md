---
uid: VerifyEMCOEndOfLife
description: "Learn about the VerifyEMCOEndOfLife prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify EMCO End of Life

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyEMCOEndOfLife* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses a two-site redundant indexing cluster (EMCO), which has reached [End of Life](xref:Software_support_life_cycles).

If a two-site redundant indexing cluster is configured, the upgrade is blocked.

## Fixing a failing prerequisite check

Migrate to [Storage as a Service (STaaS)](xref:STaaS), which offers optimal redundancy, and try upgrading again.

> [!TIP]
> See also: [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters)
