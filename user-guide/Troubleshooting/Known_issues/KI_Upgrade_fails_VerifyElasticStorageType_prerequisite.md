---
uid: KI_Upgrade_fails_VerifyElasticStorageType_prerequisite
---

# Upgrade fails because of VerifyElasticStorageType.dll prerequisite

## Affected versions

DataMiner 10.4.0 or newer.

## Cause

Starting from DataMiner version 10.4.0, XML storage for profiles and resources is no longer supported. The _VerifyElasticStorageType_ prerequisite ensures that the system has successfully switched to an indexing database. This verification process includes the following checks to confirm that XML storage is no longer in use:

1. The prerequisite automatically passes if both the Profile Manager and Resource Manager configurations indicate that the indexing database is configured. Following the documented migration procedures should ensure that these configuration files have the correct values. See also the respective docs pages [Migrating SRM profiles to the indexing database](xref:Profile_migration_to_elastic) and [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic).

1. If the configuration file is either missing or indicates the use of XML storage, the prerequisite still passes if the XML storage file is absent or contains no objects. The XML storage files for the Resource Manager and Profile Manager are located at _Skyline Dataminer\ResourceManager\Resources.xml_ and _Skyline Dataminer\ProfileManager\Profiles.xml_ respectively. After the upgrade, both managers will automatically start using the indexing database for storage. If the XML storage file cannot be verified (due to being in use by another process or being corrupt), the prerequisite will fail.

More detailed information about the result of the prerequisite can be found in _Skyline DataMiner\Upgrades\Packages\\\<upgrade-package-name>\PreRequisite-Result-VerifyElasticStorageType.dll.json_ after the upgrade.

## Fix

To fix a failing prerequisite, the data must be migrated to an indexing database and the configuration must be changed. See also the respective docs pages on [migrating profiles data](xref:Profile_migration_to_elastic) and [migrating resource data](xref:Resources_migration_to_elastic).
In case the system does not have an indexing database configured, no migration will be possible. In this case the Profile Manager and Resource Manager features are no longer usable. The data files will need to be removed while the system is offline in order to upgrade the system. After the upgrade the Resource Manager and Profile Manager will no longer initialize.

## Issue description

Upgrading to 10.4.0 or newer will remove support for storing profiles and resources in XML. If the system was not migrated to use an indexing database as storage yet, this needs to be done before upgrading.
