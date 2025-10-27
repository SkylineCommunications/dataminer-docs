---
uid: KI_Upgrade_to_1051_stuck
---

# Upgrade to DataMiner 10.5.1 or 10.5.2 is stuck

## Affected versions

DataMiner 10.5.1 and 10.5.2

## Cause

In DataMiner 10.5.1, a change was introduced that could trigger a loop when users in the *Security.xml* file have `expired` set to `"true"`.

## Workaround

1. Stop the DataMiner Agent.
1. In the Windows Local Users and Groups configuration (*lusrmgr.msc*), set the passwords of all users to never expire.
1. In the *Security.xml* file (located in `C:\Skyline DataMiner`), replace all instances of `expired="true"` with `expired="false"`.
1. Save your changes and restart DataMiner.

You will now be able to execute the upgrade. Until a fix is available, we recommend keeping the passwords set to never expire and not adding users with the setting *User must change password at next login* enabled.

## Fix

Install DataMiner 10.5.0/10.5.2 [CU1]<!--RN 42058-->.

## Description

When upgrading a DataMiner Agent in a cluster to DataMiner 10.5.1 or 10.5.2, the upgrade gets stuck.
