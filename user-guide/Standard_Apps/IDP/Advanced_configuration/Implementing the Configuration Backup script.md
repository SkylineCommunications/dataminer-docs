---
uid: ConfigurationBackupScript
---

# Implementing the Configuration Backup script

## Setting up the DataMiner Configuration Archive

DataMiner IDP can be used to create configuration backups from [elements](xref:About_elements) in the managed inventory. However, before backups can be taken the DataMiner Configuration Archive needs to be setup.

If you use exchange files (see below) the file transfer credentials also need to be configured.

## About Configuration Backup scripts

A [CI Type](xref:CI_Types1) can be configured with a script that will be used to take the configuration backup of the element of this CI Type. This script will typically read element data and pass this on to DataMiner IDP.

The script integrates with the connector and the element, and it will be executed for a specific element. 

> [!TIP]
> An example script *IDP_Example_Custom_ConfigurationBackup* is available in the Automation module after IDP has been installed. You can duplicate this script to use it as a starting point.

## Configuration types (running, startup, golden)

The Configuration Backup needs to call certain C# methods to inform IDP of the configuration backup.  

## Change Detection

Core versus Full configuration backup

## Methods to pass the configuration backup to IDP
