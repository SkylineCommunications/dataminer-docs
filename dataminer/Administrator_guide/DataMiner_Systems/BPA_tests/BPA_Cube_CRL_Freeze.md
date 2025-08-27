---
uid: BPA_Cube_CRL_Freeze
---

# Cube CRL Freeze

This BPA test identifies client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

This BPA test is by default available in System Center from DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10 onwards.<!-- RN 43539 -->

## Metadata

- Name: Cube CRL Freeze
- Description: Detects a startup freeze in the DataMiner Cube application on client machines and DataMiner Agents without an internet connection.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

No problems are found.

- Result message: `No CRL Freezes are detected.`

### Error

The test detects one or more client machines and DataMiner Agents that are affected by the startup freeze.

- Result message: `CRL Freezes are detected.`

The detailed result section lists the specific client machines that are affected. The full list of affected client machines is included in the `DetailedJsonResult` as `the following client machines are affected.`

### Warning

The test detects one or more DataMiner Agents that are affected by the startup freeze.

- Result message: `CRL Freezes are detected on DataMiner Agents only.`

The detailed result section lists the specific DataMiner Agents that are affected. The full list of affected DataMiner Agents is included in the `DetailedJsonResult` as `the following DataMiner Agents are affected.`

### Not Executed

Messages can appear when the test fails to execute for unexpected reasons:

- Result message: `Could not execute test ([message])."` (on unexpected exceptions).

The test result details will contain the full exception text, if available.

## Impact when issues detected

- **Impact**: When an internet connection is not available on the client machine, the DataMiner Cube application freezes for about 20 seconds during the session. This happens because Windows and .NET try to verify the application's digital signatures by checking an online Certificate Revocation List (CRL). The system times out during this process, causing the delay and impacting user productivity.

- **Corrective action**: To prevent these freezes, please consult your IT administrator. For detailed solutions and workarounds, refer to [DataMiner Cube freeze on startup](xref:KI_DataMiner_Cube_freeze_on_startup).

## Limitations

This test is specifically designed for environments where client machines and DataMiner Agents lack an internet connection. The configuration problem and its detection are not relevant in online environments.
