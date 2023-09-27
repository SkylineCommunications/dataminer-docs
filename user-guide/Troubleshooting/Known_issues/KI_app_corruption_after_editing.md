---
uid: KI_app_corruption_after_editing
---

# Corrupted low-code app after concurrent editing actions

## Affected versions

From DataMiner 10.2.5/10.3.0 onwards.

## Cause

When two users edit the same low-code app at the same time, it can occur that the App.info.json file refers to object IDs that do not exist. This makes it impossible to still edit the app.

## Workaround

Avoid concurrent editing actions. If these have occurred and the App.info.json file is corrupted, manually remove the unknown object IDs from the file.

## Fix

No fix is available yet.

## Description

After a low-code app is edited by two different people at the same time, the edit page no longer loads when users try to edit the app again.
