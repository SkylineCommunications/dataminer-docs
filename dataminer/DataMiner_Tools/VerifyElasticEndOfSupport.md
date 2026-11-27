---
uid: VerifyElasticEndOfSupport
description: "Learn about the VerifyElasticEndOfSupport prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify Elastic End of Support

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyElasticEndOfSupport* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses Elasticsearch as its indexing database, which has reached [End of Support](xref:Software_support_life_cycles).

If Elasticsearch is in use and the [EndOfSupport.Elastic soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportelastic) is not set to *true*, the upgrade is blocked.

## Fixing a failing prerequisite check

### Elasticsearch is in use

To resolve this, do one of the following:

- Migrate to [OpenSearch](xref:Migrating_from_Elasticsearch_to_OpenSearch) or [Storage as a Service (STaaS)](xref:STaaS) (recommended).

- Temporarily continue using Elasticsearch by setting the [EndOfSupport.Elastic soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportelastic) to *true* in `C:\Skyline DataMiner\SoftLaunchOptions.xml`. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

  > [!CAUTION]
  > Elasticsearch has reached End of Support. Only use this option temporarily.

### Failed to retrieve database information

If the check reports that it could not retrieve search database information, make sure the database is running and reachable from the DataMiner Agent, correct the reported problem, and try upgrading again.

> [!TIP]
> See also: [Elasticsearch database](xref:Elasticsearch_database)
