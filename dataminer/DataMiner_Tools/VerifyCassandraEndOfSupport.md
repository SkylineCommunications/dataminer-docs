---
uid: VerifyCassandraEndOfSupport
description: "Learn about the VerifyCassandraEndOfSupport prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify Cassandra End of Support

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyCassandraEndOfSupport* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses a database running Cassandra 3.x or earlier, which has reached [End of Support](xref:Software_support_life_cycles#third-party-software-support-lifecycle).

If Cassandra 3.x or earlier is in use and the [EndOfSupport.Cassandra3 soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportcassandra3) is not set to *true*, the upgrade is blocked.

## Fixing a failing prerequisite check

### Cassandra 3.x or earlier is in use

To resolve this, do one of the following:

- Upgrade to a supported Cassandra version, or migrate to [Storage as a Service (STaaS)](xref:STaaS) (recommended).

  > [!NOTE]
  > Cassandra versions newer than 3.x are not supported on Windows. To upgrade a Cassandra database hosted on Windows, migrate it to a Linux environment.

- Temporarily continue using Cassandra 3.x or earlier by setting the [EndOfSupport.Cassandra3 soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportcassandra3) to *true* in `C:\Skyline DataMiner\SoftLaunchOptions.xml`. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

  > [!CAUTION]
  > Cassandra 3.x has reached End of Support. Only use this option temporarily.

### Failed to connect to the database

If the check reports that it could not connect to the Cassandra database, verify that the database is running and reachable, check the configured credentials and TLS settings, and try upgrading again.

> [!TIP]
> See also: [Cassandra database](xref:Cassandra_database)
