---
uid: BPA_Service_Automatic_Properties
---

# Service Automatic Properties

This BPA test verifies whether the installed SRM framework version is compatible with the changes to automatic service properties.

This BPA test is available from DataMiner 10.2.6/10.3.0 onwards. It is available by default and runs automatically when you upgrade. <!-- RN 33363 -->

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

## Impact when issues detected

- Impact: Bookings created by the SRM framework will not work correctly.

- Corrective action: Upgrade the installed SRM framework by installing the patched version of the SRM package.
