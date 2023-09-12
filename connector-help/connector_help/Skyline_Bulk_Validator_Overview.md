---
uid: Connector_help_Skyline_Bulk_Validator_Overview
---

# Skyline Bulk Validator Overview

This driver is used to show the results of an execution of the validator on all selected protocols. It counts the number of detected validator check errors per check for all the validated protocols.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Set the following parameters on the Configuration page: - General Results File Path: specify the path to the file that contains the general results of the bulk validator. - Bulk Validator Results File Path: specify the path to the file that contains the bulk validator results. - Error messages File Path: Specify the path to the file that defines the new validator messages (ErrorMessages.xml). - Old Validator Messages File Path: Specify the path to the file that lists the old validator messages.

## How to use

After configuring the parameters on the Configuration page, you can press the Read Results button. This will process the specified files and generate the results.

## Notes

This connector is only meant to be used internally.
