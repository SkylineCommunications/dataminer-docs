---
uid: BPA_Validate_Connectors
---

# Validate Connectors

This BPA test scans the DataMiner System for any connectors that are known to be incompatible with the DataMiner version to which the DataMiner Agent is being upgraded. If such connectors are found, they will have to be removed before you can continue with the upgrade.

This BPA test is available from DataMiner 10.3.4/10.4.0 onwards. It is available by default and runs automatically when you upgrade. <!-- RN 35605 -->

## Metadata

- Name: ValidateConnectors

- Description: Blocks upgrades when known incompatible connectors are installed on the system

- Author: Skyline Communications

## Results

### Success

`No known non-supported connectors detected.`

### Error

`Please remove these non-supported connectors from the system before upgrading: _Driver1_ (_version1_, _version2_), _Driver2_ (_version_)`

## Impact when issues detected

- Impact: The DataMiner Agent can only be upgraded when there are no non-supported connectors left on the system.

- Corrective action: Remove non-supported connectors before upgrading DataMiner.
