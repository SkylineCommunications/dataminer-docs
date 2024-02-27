---
uid: Verify_Elastic_Storage_Type
---

# Verify Elastic Storage Type

In DataMiner 10.4.0/10.4.1<!--RN 37763-->, the *VerifyElasticStorageType* prerequisite check is added to upgrade packages. This check verifies whether the system has successfully switched to an [indexing database](xref:Indexing_Database). If profiles and/or resources are still stored in XML files, this prerequisite will cause the upgrade to fail.

From DataMiner 10.4.0 onwards, XML storage for profiles and resources is no longer supported, and migrating to an indexing database is required.

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

If the *VerifyNoLegacyReportsDashboards* check fails, refer to [Upgrade fails because of VerifyElasticStorageType.dll prerequisite](xref:KI_Upgrade_fails_VerifyElasticStorageType_prerequisite).
