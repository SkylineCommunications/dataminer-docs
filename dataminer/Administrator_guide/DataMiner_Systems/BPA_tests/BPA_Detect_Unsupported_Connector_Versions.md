---
uid: BPA_Detect_Unsupported_Connector_Versions
---

# Detect unsupported connector versions

## Best Practice

When a connector version is unlisted on the Catalog, it means that it is no longer supported by Skyline Communications.
Using unlisted connectors can lead to compatibility issues, lack of support, and potential security vulnerabilities.
It is important to regularly check for unlisted connectors and update them to supported versions to ensure optimal performance and security of the system.

This test detects elements that are using connector versions that have been unlisted on the Catalog.

## Metadata

* Name: Detect Unsupported Connector Versions
* Description: Detects connector versions that are in use and that are no longer supported.
* Author: Skyline Communications
* Default schedule: Every day

## Results

### Success

* The outcome is 'NoIssues'.
* The ResultMessage is "No issues detected."

### Error

The BPA detected used connector versions that are no longer supported.

* The outcome is 'IssuesDetected'.
* The ResultMessage is "Detected usage of unsupported connector versions."
* The impact is 'Using a connector version that is no longer supported could cause issues.'
* The CorrectiveAction is 'Update the elements running unsupported connector versions to use supported connector versions instead.'

An unexpected exception occurred while executing the test:

* The outcome is 'IssuesDetected'.
* The ResultMessage is "An exception occurred during execution."
* Detailed results: "Info about the exception."

### Not Executed

The BPA could not run because the Catalog API could not be reached:

* The outcome is "Undefined"
* The ResultMessage is "Could not reach the Catalog API."

## Impact when issues detected

* Impact: "Using a connector version that has been unlisted from the catalog could cause issues."
* Corrective Action: "Update the elements running the unlisted connector version to execute a version that is not unlisted on the catalog."
