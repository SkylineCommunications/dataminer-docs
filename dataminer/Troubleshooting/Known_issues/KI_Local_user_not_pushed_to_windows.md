---
uid: KI_Local_user_not_pushed_to_windows
---

# Local user not pushed to Windows

## Affected versions

From DataMiner 10.4.0 [CU4]/10.4.7 onwards.<!-- RN 39234 -->

## Cause

Changes introduced in DataMiner 10.4.0 [CU4]/10.4.7 could cause the code to push an empty password to Windows for a user that was created prior to these DataMiner versions. This is not accepted by Windows, causing the user to not be created in Windows.

## Fix

No fix is available yet.<!-- RN 42819 - reverted by 43488 -->

## Workaround

Update the user's password in the DataMiner Cube System Center.

## Description

If a local user was created on a DataMiner version prior to 10.4.0 [CU4]/10.4.7, it can occur that DataMiner fails to push this user to Windows. This can for instance happen in the following situations:

- During a hardware migration, the user will fail to be created during startup. In *SLDataMiner.txt*, you will find a log entry `Failed to create user <name> , windows returned with error code: <...>`.
- When a new Agent is added to the DMS, during the initial sync or during a midnight sync, the user will not be created on the new Agent, and the Agent will generate a notice `Unable to add user: ...`.
