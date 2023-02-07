---
uid: BPA_Verify_Cloud_DxM_Version
---

# Verify Cloud DxM Version

This BPA test checks if the minimum required version is installed for all DxMs in the system.

This BPA test is available from DataMiner 10.2.8 and 10.2.0 [CU6] onwards. It runs automatically when you upgrade to 10.2.0 [CU6]/10.2.8 or higher.

## Metadata

- Name: Verify Cloud DxM Version
- Description: Verifies if the minimum required version is installed for all DxMs in the system.
- Author: Skyline Communications

## Results

### Success

`System has the minimum required DxM version(s).`

### Error

`One or more DxMs in the system require an upgrade. Please perform the upgrade manually or via admin.dataminer.services as soon as possible.`

Note that an error message will only be returned if a function DVE resource is enabled but is not actually available.

### Warning

`No warning detected`

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

## Impact when issues are detected

- Impact: Operation of the dataminer.services connection features is affected by this problem.
- Corrective Action: Perform the upgrade or contact Skyline for support.

## Limitations

No limitations detected.
