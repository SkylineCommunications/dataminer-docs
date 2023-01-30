---
uid: Sync_Check
---

# Sync Check

## About this tool

To verify the synchronization of element and service files across a DataMiner System, you can use the "Sync Check" Automation script.

This is especially intended for troubleshooting in large clusters (which can include Failover Agents) in case there are errors related to duplicate service or element IDs, errors when new services are created that reuse the name of old services, or synchronization errors related to services or elements;

You can download this script from [DataMiner Dojo](https://community.dataminer.services/download/script_synccheck/).

## Running the Sync Check script

To use this script:

1. Extract the zip file you downloaded.

1. Import the script *Script_SyncCheck.xml* on a DMA in the DataMiner System you are troubleshooting. The script will become available in the *Skyline-TechSupport* folder in the Automation module.

1. Run the script in the Automation module and specify a username and password. These credentials will be used to access the different Agents in the DMS via file shares

1. When the script has run, check its output in the file *SyncInfo.txt*, which you can find in the following folder on the DMA: *C:\Skyline_Data\SyncInfo*.

Note that to be able to run the script, file share access to all IP addresses in the cluster is required.

## What is included in the sync check?

The script checks the following things:

- Elements:

  - Missing between main and backup DMA (Failover)

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

  - Not in sync: compared based on DMA ID, element ID, name, protocol, version and properties

  - Duplicate element IDs

- Services

  - Missing between main and backup DMA (Failover)

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

  - Not in sync: compared based on DMA ID, service ID, name and properties

  - Duplicate service IDs

- Remote services:

  - Missing DMA folder

  - Missing services

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

> [!TIP]
> You can download an example of the output from [DataMiner Dojo](https://community.dataminer.services/download/syncinfo3/).
