---
uid: KI_Reuploaded_DVE_protocol_version_incorrectly_set_as_production_version
---

# Reuploaded DVE protocol version is incorrectly set as production version

## Affected versions

From DataMiner 10.2.0 [CU16]/10.3.0 [CU4]/10.3.7 to DataMiner 10.4.0 [CU11]/10.5.2.

## Cause

When you upload the same version of a DVE protocol twice, and that version is different from the one currently set as the production version, DataMiner incorrectly updates the DVE protocol's production version.

## Fix

Install DataMiner 10.4.0 [CU12]/10.5.3<!--RN 41798-->.

## Workaround

To avoid this issue, delete the existing version of the DVE protocol before reuploading it.

## Description

When you reupload a DVE protocol version, it is unexpectedly set as the production version. This may result in a mismatch between the parent protocol and the DVE protocol production versions.

For example:

![Mismatch](~/dataminer/images/KI-Mismatch_Version.png)