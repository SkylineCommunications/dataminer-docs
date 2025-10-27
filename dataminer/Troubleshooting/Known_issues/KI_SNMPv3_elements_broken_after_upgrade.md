---
uid: KI_SNMPv3_elements_broken_after_upgrade
---

# SNMPv3 elements not loaded correctly after upgrade

## Affected versions

Feature Release versions 10.4.9 to 10.4.12, after an upgrade from a 10.4.0 Main Release version starting from 10.4.0 [CU6].

## Cause

When upgrading from a 10.4.0 Main Release version starting from 10.4.0 [CU6] to Feature Release version 10.4.9 to 10.4.12, DataMiner does not run a required upgrade action, causing SNMPv3 passwords not to be migrated correctly. This causes SNMPv3 connections to lose access to their credentials.

## Fix

Install DataMiner 10.5.0 or 10.5.1.<!-- RN 41630 -->

## Workaround

After the upgrade, manually force the upgrade action to run by specifying an older DataMiner version than the one currently in use:

1. Stop the DataMiner Agent.

1. On the DMA server, run the following command as administrator:

   ```txt
   "C:\Skyline DataMiner\Upgrades\UpgradeActions\MigrateSNMPv3PasswordsToElementConfig\MigrateSNMPv3PasswordsToElementConfig.exe" /oldversion:10.3.0 /newversion:10.5.0
   ```

   This upgrade action will cause errors to be logged on Agents where Swarming is not enabled, but you can safely ignored these.

1. Restart the DataMiner Agent.

## Description

After a DataMiner upgrade from a 10.4.0 Main Release Version (starting from 10.4.0 [CU6]) to a 10.4.x Feature Release version (10.4.9 to 10.4.12), SNMPv3 elements no longer work. In the Alarm Console, an error is displayed with the parameter description "Load Element Failed" and the value "Error parsing SNMPv3 password ...".
