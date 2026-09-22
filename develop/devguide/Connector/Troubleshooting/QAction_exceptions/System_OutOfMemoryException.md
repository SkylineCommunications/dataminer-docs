---
metadata_version: 1
uid: System_OutOfMemoryException
description: "Use this connector troubleshooting entry point when SLScripting reports System.OutOfMemoryException while executing QAction code."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# System.OutOfMemoryException

Use this entry point when the SLScripting process runs out of memory while executing connector QAction code or when a memory leak is suspected.

## Audience and prerequisites

This page is for connector developers and support engineers investigating a process crash or sustained memory growth. Collect the SLScripting logs and, when possible, a full-memory process dump.

## Scope and expected result

The linked procedure explains how to confirm the exception and analyze the dump for the allocation or connector code responsible. This page does not diagnose a specific connector.

## Failure and edge cases

An apparent memory problem can also come from another process or from a dump that does not contain full memory. Confirm that the exception is reported by SLScripting before following this path.

## Authoritative procedure

Refer to [Investigating OutOfMemoryException occurrences](xref:TroubleshootingSLScriptingOutOfMemoryException).

## Related concepts

- [QActions](xref:LogicQActions)
- [SLScripting troubleshooting](xref:Troubleshooting_SLScripting)
