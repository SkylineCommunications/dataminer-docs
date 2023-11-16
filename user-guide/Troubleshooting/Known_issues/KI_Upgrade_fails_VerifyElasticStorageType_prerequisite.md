---
uid: KI_Upgrade_fails_VerifyElasticStorageType_prerequisite
---

# Upgrade fails because of VerifyElasticStorageType.dll prerequisite

## Affected versions

DataMiner 10.4.0 or newer.<!-- RN 37763 -->

## Cause

Starting from DataMiner version 10.4.0, XML storage for profiles and resources is no longer supported. The *VerifyElasticStorageType* upgrade prerequisite check verifies whether the system has successfully switched to an indexing database:

- If both the Profile Manager and Resource Manager configurations indicate that the indexing database is configured, the prerequisite check will be successful.

- If the configuration file is either missing or indicates the use of XML storage, but the XML storage file is absent or contains no objects, the prerequisite check will be successful.

  The XML storage files for Resource Manager and Profile Manager are located in the folders `C:\Skyline Dataminer\ResourceManager\Resources.xml` and `C:\Skyline Dataminer\ProfileManager\Profiles.xml`, respectively. After the upgrade, both managers will automatically start using the indexing database for storage.

- If the configuration file indicates the use of XML storage, but the XML storage file cannot be verified (because it is in use by another process or it is corrupt), the prerequisite will fail.

- If the configuration file indicates the use of XML storage, and the XML storage file contains objects, the prerequisite check will fail.

More detailed information about the result of the prerequisite can be found in `Skyline DataMiner\Upgrades\Packages\<upgrade-package-name>\PreRequisite-Result-VerifyElasticStorageType.dll.json` after the upgrade.

## Fix

To fix a failing prerequisite check, you need to migrate the profiles and/or resources data to an indexing database and update the configuration. See [migrating profiles data](xref:Profile_migration_to_elastic) and [migrating resource data](xref:Resources_migration_to_elastic).

In case the system does not have an indexing database configured, no migration will be possible. In this case, the Profile Manager and Resource Manager features are no longer usable. The data files `C:\Skyline Dataminer\ResourceManager\Resources.xml` and `C:\Skyline Dataminer\ProfileManager\Profiles.xml` will need to be removed while the system is offline in order to upgrade the system. After the upgrade, the Resource Manager and Profile Manager will no longer initialize.

## Issue description

Upgrading to 10.4.0 or newer will remove support for storing profiles and resources in XML. If the system has not been migrated to use an indexing database as storage yet, this prerequisite check will force you to do so before upgrading.
