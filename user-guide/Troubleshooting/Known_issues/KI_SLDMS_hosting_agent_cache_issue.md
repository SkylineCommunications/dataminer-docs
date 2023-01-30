---
uid: KI_SLDMS_hosting_agent_cache_issue
---

# SLDMS Hosting Agent cache issue

## Affected versions

10.2 Main and Feature Release versions.

## Cause

The SLDMS process could lose in-memory information about the Hosting Agents of elements at runtime. This could cause certain types of actions on these elements to fail.

## Fix

Upgrade to DataMiner 10.2.0 CU7 or 10.2.10.

## Issue description

Some requests or actions related to elements fail.

Possible additional symptoms of this issue:

- Errors of the type "Unable to find Hosting Agent for element: xxxx/xxxx" are thrown.
- The SLDMS logging contains entries of the type "CSystem::UpdateHostAgentCache|CRU|-1|Updating LocalAgentHostCache with key xxxxxx/yyy removed", where xxxx is the local DataMiner ID.
- `C:\Skyline Dataminer\Files\SyncInfo\{DO_NOT_REMOVE_DC5A2A6C-4583-493C-A9CD-7AEBBF905D1E}.xml` contains type="delete" entries for the local DataMiner name.
