---
uid: BPA_Check_Agent_Presence
---

# NATS cluster verification

Prior to DataMiner 10.5.0 [CU6]/10.5.9<!--RN 43359-->, this BPA test is called "NATS connections between the DataMiner Agents". Prior to DataMiner 10.4.12/10.5.0<!--RN 40751-->, it is called "Check Agent Presence Test In NATS".

NATS serves as an inter-DMA message broker. This means that every DataMiner Agent must be able to reach every other DataMiner Agent in the cluster over NATS.

This BPA test will scan the NATS info as seen by this Agent. It will verify if it finds a route to every Agent it is aware of, and it will perform a NATS client connection test to each Agent.

Depending on the configuration of the system, the NATS info is gathered from SLNet (via SLCloud.xml) or via BrokerGateway. An extra check is performed for cluster consistency if DataMiner uses BrokerGateway. Note that BrokerGateway may only be available in preview, depending on your DataMiner version (see [soft-launch options](xref:Overview_of_Soft_Launch_Options#brokergateway)).

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab). From DataMiner 10.3.12 onwards, it is available by default.

## Metadata

- Name: NATS connections between the DataMiner Agents
- Description: Polls the NATS routes, checks if every Agent is represented, and performs a NATS client connection test
- Author: Skyline Communications
- Default Schedule: Every day

## Results

### Success

- No issues detected.

Every Agent's IP was found as a route in the NATS server, and the NATS client connection to every Agent succeeded. No inconsistencies were found when using BrokerGateway.

### Error

- Possible issues with NATS nodes or NATS client communication between DataMiner Agents in the cluster. See Details.

### Warning

- Possible issues with NATS nodes or NATS client communication between DataMiner Agents in the cluster. See Details.

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

- "Could not execute test (*[message]*)" (on unexpected exceptions).

In the message above, the exception message is included (e.g., "Access Denied"). The test result details contain the full exception text, if available.

## Impact when issues detected

- Impact: RTEs and errors might occur.
- Corrective action: Check the NATS config on all Agents. See [Troubleshooting – NATS](xref:Investigating_NATS_Issues).

## Limitations

- NATS info is collected, and the connection tests for the NATS client are performed using the address *localhost:8222*. If the local NATS node is not part of the setup, the BPA test will not be able to verify the results.
- This BPA test does not work for setups that have the *NATSForceManualConfig* option enabled.
