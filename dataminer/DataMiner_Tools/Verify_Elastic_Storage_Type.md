---
uid: Verify_Elastic_Storage_Type
---

# Verify Elastic Storage Type

From DataMiner 10.4.0/10.4.1 onwards<!--RN 37763-->, the *VerifyElasticStorageType* prerequisite check is included in upgrade packages. This check verifies whether the system has successfully switched to an [indexing database](xref:Indexing_Database). If profiles and/or resources are still stored in XML files, this prerequisite will cause the upgrade to fail.

From DataMiner 10.4.0 onwards, XML storage for profiles and resources is no longer supported, and migrating to an indexing database is required.

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

The *VerifyElasticStorageType* check will be **successful** if:

- Both the Profile Manager and Resource Manager configurations indicate that the indexing database is configured.

- The configuration file is either missing or indicates the use of XML storage, but the XML storage file is absent or contains no objects.

  The XML storage files for Resource Manager and Profile Manager are located in the folders `C:\Skyline Dataminer\ResourceManager\Resources.xml` and `C:\Skyline Dataminer\ProfileManager\Profiles.xml`, respectively. After the upgrade, both managers will automatically start using the indexing database for storage.

The *VerifyElasticStorageType* check will **fail** if:

- The configuration file indicates the use of XML storage, but the XML storage file cannot be verified (because it is in use by another process or it is corrupt).

- The configuration file indicates the use of XML storage, and the XML storage file contains objects.

> [!NOTE]
> More detailed information about the result of the prerequisite can be found in `Skyline DataMiner\Upgrades\Packages\<upgrade-package-name>\PreRequisite-Result-VerifyElasticStorageType.dll.json` after the upgrade.

## Fixing a failing prerequisite check

To fix a failing prerequisite check, you need to migrate the profiles and/or resources data to an indexing database and update the configuration. See [migrating profiles data](xref:Profile_migration_to_elastic) and [migrating resource data](xref:Resources_migration_to_elastic).

In case the system does not have an indexing database configured, no migration will be possible. In this case, the Profile Manager and Resource Manager features are no longer usable. The data files `C:\Skyline Dataminer\ResourceManager\Resources.xml` and `C:\Skyline Dataminer\ProfileManager\Profiles.xml` will need to be removed while the system is offline in order to upgrade the system. After the upgrade, the Resource Manager and Profile Manager will no longer initialize.
