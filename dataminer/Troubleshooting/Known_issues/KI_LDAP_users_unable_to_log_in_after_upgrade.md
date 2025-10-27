---
uid: KI_LDAP_users_unable_to_log_in_after_upgrade
---

# LDAP/ActiveDirectory domain users no longer able to log in after upgrade

## Affected versions

- Main Release versions from DataMiner 10.4.0 [CU4] to 10.4.0 [CU11]

- Feature Release versions from DataMiner 10.4.7 to 10.5.1

## Cause

This issue occurs on LDAP servers where `CN=CONTOSA,CN=Partitions,CN=Configuration,DC=contosa,DC=com` does not have a `nETBIOSName` attribute, e.g. when accessing the GlobalCatalog of a forest.

## Fix

1. Install DataMiner 10.4.0 [CU12], 10.5.0, or 10.5.2.<!--RN 41339-->

1. Wait up to an hour for LDAP synchronization to occur, or manually trigger the `Skyline DataMiner LDAP Resync` task in Windows Task Scheduler.

1. Remove any duplicate users:

   1. Stop all DMAs simultaneously.

   1. Identify users that appear without their domain prefix in the `name` attribute (i.e. `username` instead of `CONTOSA\username`) in the following files:

      - `C:\Skyline DataMiner\Security.xml`

      - `C:\Skyline DataMiner\Files\SyncInfo\{DO_NOT_REMOVE_68EE4388-7EF6-4cb4-B38F-5E0045175340}.xml`

   1. Set the `deleted` attribute to `true`. For example:

      ```xml
      <User name="Luke" fullName="Luke Daniels" level="" expired="false" tel="" email="luke.daniels95@gmail.com" deleted="true" pagerNr="" twitter="" dcpUserName="" automaticallyAdded="true" isCca="false" domain="CONTOSA">
         <Member notificationSchedule="">1</Member>
      </User>
      ```

   1. Restart the DMAs.

## Issue description

- Detecting the issue **before an upgrade**:

  The following log line can be found in `C:\Skyline DataMiner\Logging\ActiveDirectory.txt`:

  ```txt
  2024/10/04 11:00:03.273|ActiveDirectory|18064|136|CActiveDirectoryInfo::ADQuery|DBG|0|Query:    (&(nCName=DC=us,DC=NFL,DC=NET)(nETBIOSName=*))
  2024/10/04 11:00:03.273|ActiveDirectory|18064|136|CActiveDirectoryInfo::ADQuery|DBG|0|Columns:  cn
  2024/10/04 11:00:03.275|ActiveDirectory|18064|136|CActiveDirectoryInfo::ADQuery|DBG|0|Duration: 0 ms, Total rows: 0, hr: 0x80072030
  ```

  If the number of `Total rows` is 0, the issue is present.

  In some cases, it can occur that the LDAP server returns `0x00005012` (S_ADS_NOMORE_ROWS) instead of `0x80072030` (ERROR_DS_NO_SUCH_OBJECT). The error is also present in such cases.

- **After an upgrade**:

  - All domain users are unable to log in. When trying to log in, the following entry is added to the *SLNet.txt* log file: `Authentication Step Failure: Not a DataMiner user: CONTOSA\user`.

  - In `C:\Skyline DataMiner\Security.xml`, users appear without their domain prefix in the `name` attribute. For example:

    - Before upgrade: `CONTOSA\username`.

    - After upgrade: `username` (with no domain prefix).

  - Duplicate users are found in the updated *Security.xml* file.
