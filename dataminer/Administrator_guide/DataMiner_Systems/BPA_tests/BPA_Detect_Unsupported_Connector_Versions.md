---
uid: BPA_Detect_Unsupported_Connector_Versions
---

# Detect unsupported connector versions

When a connector version is removed from the Catalog, this means that it is no longer supported by Skyline Communications. Using such connector versions can lead to compatibility issues, lack of support, and potential security vulnerabilities. It is important to regularly check for unsupported connector versions and update them to supported versions to ensure optimal performance and security of the system.

This BPA test detects elements that are using connector versions that have been removed from the Catalog. It is by default available in System Center from DataMiner 10.6.4/10.7.0 onwards.<!-- RN 44607 -->

## Metadata

- Name: Detect Unsupported Connector Versions
- Description: Detects connector versions that are in use and that are no longer supported.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

- The outcome is "NoIssues".
- The result message is "No issues detected."

### Error

The BPA test detected used connector versions that are no longer supported.

- The outcome is "IssuesDetected".
- The result message is "Detected usage of unsupported connector versions."
- The impact is "Using a connector version that is no longer supported could cause issues."
- The corrective action is "Update the elements running unsupported connector versions to use supported connector versions instead."

An unexpected exception occurred while executing the test:

- The outcome is "IssuesDetected".
- The result message is "An exception occurred during execution."
- Detailed results: "Info about the exception."

### Not Executed

The BPA test could not run because the Catalog API could not be reached:

- The outcome is "Undefined"
- The result message is "Could not reach the Catalog API."

## Impact when issues detected

- Impact: Using a connector version that has been unlisted from the Catalog could cause issues.
- Corrective action: Update the elements running the unlisted connector version to execute a version that is not unlisted in the Catalog.
