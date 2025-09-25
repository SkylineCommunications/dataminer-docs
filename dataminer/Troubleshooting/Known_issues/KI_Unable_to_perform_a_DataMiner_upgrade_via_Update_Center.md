---
uid: KI_Unable_to_perform_a_DataMiner_upgrade_via_Update_Center
---

# Unable to perform a DataMiner upgrade via Update Center

## Affected versions

DataMiner 10.4.0 and higher

## Cause

Update Center downloads a version of an upgrade package that only contains the changes since the base version. The package incorrectly does not include the BPA Executor.

> [!TIP]
> To check whether the package contains the BPA Executor, open the package as if it were a zip file, and check whether the *update.zip* file contains the StandaloneBpaExecutor in the *update.zip/prerequisites/executor* folder.

## Workaround

Download the full upgrade package for the required DataMiner version from [DataMiner Dojo](https://community.dataminer.services/dataminer-server-upgrade-packages/), and perform the upgrade using that package.

## Fix

No fix is available yet. <!--Task ID: 245546-->

## Description

Trying to [upgrade a DataMiner System using a CU package downloaded via DataMiner Cube's Update Center](xref:Upgrading_a_DataMiner_Agent_in_the_Update_Center) fails with the following exception:

`Failed to verify prerequisites: the BPA executor could not be found`
