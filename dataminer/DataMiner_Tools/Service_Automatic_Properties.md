---
uid: Service_Automatic_Properties
---

# Service Automatic Properties

This prerequisite check verifies whether the installed SRM framework version is compatible with the changes to automatic service properties.

When you upgrade to DataMiner 10.2.6/10.3.0 or higher, the upgrade will be blocked if the installed SRM version is not compatible. <!-- RN 33363 -->

## Metadata

- Name: ServiceAutomaticProperties

- Description: Checks if the system has the up-to-date SRM application package

- Author: Skyline Communications

## Results

### Success

- `No issues detected, no SRM Framework found.`

- `No issues detected, SRM Framework version is OK.`

### Error

`Issues detected, detected incompatible SRM version (SLSRMLibrary version {installedVersion} is installed). Please contact your System Administrator.`

If you encounter this error, upgrade the installed SRM framework by installing a more recent version of the SRM package.
