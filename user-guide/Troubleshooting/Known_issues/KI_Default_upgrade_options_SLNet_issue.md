---
uid: KI_Default_upgrade_options_SLNet_issue
---

# SLNet not starting correctly after change to default upgrade options

## Affected versions

From DataMiner 10.4.1/10.5.0 [CU0] up to and including DataMiner 10.5.6/10.5.0 [CU3].

## Cause

Because of changes introduced in DataMiner 10.4.1/10.5.0 [CU0], if *MaintenanceSettings.xml* file contains an *SLNet.DefaultUpgradeOptions* element, SLNet fails to start up correctly. This element is added when the default upgrade options for a DataMiner System are modified.

## Fix

Install DataMiner 10.5.0 [CU4] or 10.5.7.<!-- RN 42746 -->

## Workaround

Manually remove the `<DefaultUpgradeOptions>` element from the *MaintenanceSettings.xml* file and restart DataMiner.

## Description

After a change to the default upgrade options of a DataMiner System, DataMiner fails to start up correctly.
