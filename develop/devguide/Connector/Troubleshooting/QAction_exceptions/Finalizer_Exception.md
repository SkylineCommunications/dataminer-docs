---
metadata_version: 1
uid: Finalizer_Exception
description: "Use this connector troubleshooting entry point when an exception on a QAction finalizer thread causes SLScripting to crash."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Exception in Finalizer

Use this entry point when a connector QAction throws an exception on the .NET Finalizer thread and the SLScripting process crashes.

## Audience and prerequisites

This page is for connector developers investigating a process crash. Collect the relevant SLScripting logs and crash dump before starting the linked investigation procedure.

## Scope and expected result

The linked procedure explains how to inspect the dump, identify the finalizer that failed, and trace it back to the connector code. This page does not replace that procedure.

## Failure and edge cases

An exception on the Finalizer thread can terminate the SLScripting process. If the dump does not show a finalizer exception, use the broader [SLScripting troubleshooting procedures](xref:Troubleshooting_SLScripting) to select a different investigation path.

## Authoritative procedure

Refer to [Investigating exception occurrence on Finalizer thread](xref:TroubleshootingSLScriptingFinalizerException).

## Related concepts

- [QActions](xref:LogicQActions)
- [SLScripting troubleshooting](xref:Troubleshooting_SLScripting)
