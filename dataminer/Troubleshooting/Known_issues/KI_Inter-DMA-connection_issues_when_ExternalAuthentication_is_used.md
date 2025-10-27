---
uid: KI_Inter-DMA-connection_issues_when_ExternAuthentication_is_used
---

# Inter-DMA connection issues when ExternalAuthentication is used

## Affected versions

From DataMiner 10.1.0 [CU17]/10.2.0 [CU5]/10.2.8 onwards.

## Cause

A race condition during the startup of DataMiner Agents could cause Agents to incorrectly set the `ConnectionAuthMethod` for inter-DMA connections to `ExternalAuth`. This falls back to *SSPI.dll*, which is no longer supported, leading to connection failures between Agents.

## Workaround

To resolve the issue without restarting the DMA, update the `ConnectionAuthMethod` setting on the affected Agent:

1. Open the [SLNetClientTest tool](xref:SLNetClientTest_tool) and [connect to the DMA](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool) that displays the error log.

1. Navigate to *Advanced* > *Options* > *SLNet Options*.

1. In the dropdown list next to *Option values for*, select *ConnectionAuthMethod*.

   ![ConnectionAuthMethod](~/dataminer/images/ConnectionAuthMethod.png)

1. On the Agent that is marked as disconnected, double-click the value field.

1. Enter `Sspi` as the new value.

1. Click OK.

## Fix

Install DataMiner 10.4.12/10.5.0<!--RN 40635-->.

## Description

When using ExternalAuthentication, some Agents may display other Agents as disconnected. The following error can be found in the SLNet logging: `Connect to <ID> (<remoteAddress>) failed [...x]: Login via SSPI.dll is no longer supported.`
