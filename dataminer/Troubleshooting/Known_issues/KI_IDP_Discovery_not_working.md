---
uid: KI_IDP_Discovery_not_working
---

# IDP Discovery no longer working after upgrade

## Affected versions

From DataMiner 10.4.0/10.4.3 onwards.

## Cause

DataMiner 10.4.0/10.4.3 introduced the *DataMinerSolutions.dll* file [(RN 38530)](xref:General_Main_Release_10.4.0_changes#dataminersolutionsdll-now-included-in-core-dataminer-software-id-38530), which is included in the core DataMiner software and ensures a DataMiner restart is no longer required after installing IDP. The *DataMinerSolutions.dll* file is only compatible with IDP 1.5.0 or higher.

## Fix

Deploy and install IDP 1.5.0 (or higher) from the [Catalog](https://catalog.dataminer.services/details/fdaa2902-cbb7-4d83-831d-91428ac5e88d).

> [!TIP]
> For more information on how to proceed with the installation/upgrade procedure, refer to [Installing DataMiner IDP](xref:Installing_DataMiner_IDP).

## Description

After the DataMiner System is upgraded to DataMiner 10.4.0/10.4.3 or higher, IDP Discovery is no longer working.
