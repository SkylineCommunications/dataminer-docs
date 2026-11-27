---
uid: VerifyMySQLEndOfSupport
description: "Learn about the VerifyMySQLEndOfSupport prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify MySQL End of Support

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyMySQLEndOfSupport* prerequisite check is included in upgrade packages. It verifies whether the DataMiner Agent uses MySQL as its main database, which has reached [End of Support](xref:Software_support_life_cycles#third-party-software-support-lifecycle).

If MySQL is in use and the [EndOfSupport.MySQL soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportmysql) is not set to *true*, the upgrade is blocked.

## Fixing a failing prerequisite check

To resolve this, do one of the following:

- Migrate to a [Cassandra cluster](xref:Migrating_the_general_database_to_Cassandra) or to [Storage as a Service (STaaS)](xref:STaaS) (recommended).

- Temporarily continue using MySQL by setting the [EndOfSupport.MySQL soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportmysql) to *true* in `C:\Skyline DataMiner\SoftLaunchOptions.xml`. See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

  > [!CAUTION]
  > MySQL has reached End of Support. Only use this option temporarily.

> [!TIP]
> See also: [Legacy setup with MySQL or MSSQL database](xref:Legacy_setup_with_MySQL_or_MSSQL_database)
