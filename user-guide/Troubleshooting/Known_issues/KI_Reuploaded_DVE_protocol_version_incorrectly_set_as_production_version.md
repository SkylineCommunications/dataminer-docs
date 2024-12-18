---
uid: KI_Reuploaded_DVE_protocol_version_incorrectly_set_as_production_version
---

# Reuploaded DVE protocol version is incorrectly set as production version

## Affected versions

- Main Release versions from DataMiner 10.2.0 [CU16]/10.3.0 [CU4].

- Feature Release versions from DataMiner 10.3.7.

## Cause

When you upload the same version of a DVE protocol twice, and that version is different from the one currently set as the production version, DataMiner incorrectly updates the DVE protocol's production version.

## Fix

No fix is available yet.

## Workaround

To avoid this issue, delete the existing version of the DVE protocol before reuploading it.

## Description

When you reupload a DVE protocol version, it is unexpectedly set as the production version. This may result in a mismatch between the parent protocol and the DVE protocol production versions.

For example:

![Mismatch](~/user-guide/images/KI-Mismatch_Version.png)