---
uid: KI_QActions_fail_after_upload_protocol_version
---

# QActions fail for element after uploading new protocol version

## Affected versions

- Main Release versions from DataMiner 10.4.0 [CU18]/10.5.0 [CU6] onwards.
- Feature Release versions from DataMiner 10.5.9 onwards.<!-- RN 42877 -->

## Cause

When a protocol is uploaded, a notify is sent to SLScripting to forget about the QAction assemblies for that protocol. This involves removing the CodeBuilder object that holds a reference to the loaded QAction assembly. The relevant CodeBuilder objects are found using `String.StartsWith("ProtocolName.ProtocolVersion")` on the assembly file name. This faulty implementation can match other protocol versions if the version string starts with the same text. This will typically only affect elements with non-standard version formats such as the ones used during development (for example, 1.0.0.1_DEV). Although this is not recommended,  such versions are occasionally used on production elements.

## Workaround

Restart the affected element.

## Fix

Install DataMiner 10.5.0 [CU11]/10.6.2<!--RN 44172-->.

## Description

If a protocol is uploaded with a suffix appended to the version number (for example, 1.0.0.1_DEV), then an element is created using that version, and then a new version of the protocol is uploaded without the suffix (for example, 1.0.0.1), the element is no longer able to execute QActions.

The element will log an error starting with `No CodeBuilder found`. In addition, the SLManagedScripting logging will contain `Removing CodeBuilder cookies for ProtocolName.ProtocolVersion`.

This issue does not occur when standard version numbers are used (for example, publishing 1.0.0.2 will not cause issues for elements running 1.0.0.1), and it does not occur when a version of a different protocol is uploaded. It also does not happen if first the version without suffix is uploaded and then the version with suffix (for example, uploading version 1.0.0.2 will break elements running 1.0.0.2_test and 1.0.0.2_fix, but not the other way around).
