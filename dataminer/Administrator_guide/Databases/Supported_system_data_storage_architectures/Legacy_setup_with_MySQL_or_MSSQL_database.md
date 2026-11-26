---
uid: Legacy_setup_with_MySQL_or_MSSQL_database
description: "Learn why the legacy setup with MySQL or MSSQL database limits your DataMiner System and why we recommend using Storage as a Service instead."
---

# Legacy setup with MySQL or MSSQL database

In legacy DataMiner Systems using DataMiner 9.0 or older, the data storage setup involved a MySQL or MSSQL database. However, such a setup does not have access to many recent DataMiner features. We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead.

MySQL reached *End of Engineering* as of DataMiner 10.3.0 and full support ended as of DataMiner 10.6.0. While existing features are expected to continue working in DataMiner 10.6.x, using MySQL is not recommended. MSSQL is no longer supported as of DataMiner 10.3.0. For more information, see [Third-party software support lifecycle](xref:Software_support_life_cycles#third-party-software-support-lifecycle).

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 47000 -->, a DataMiner Agent that uses MySQL as its main database will no longer start unless the [EndOfSupport.MySQL soft-launch option](xref:Overview_of_Soft_Launch_Options#endofsupportmysql) is set to *true*.
