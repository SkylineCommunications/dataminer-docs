---
uid: BPA_Check_Cluster_SLNet_Connections
---

# Check Cluster SLNet Connections

This BPA test is executed across the cluster. It will trigger a local test on each DMA that can be reached from the DMA initiating the BPA test, to check the connections between the DMAs. It is important to know if there are issues with these connections, as they are used for communication between DMAs. The BPA will indicate if there are potential problems.

This BPA test is available from DataMiner 10.3.0 [CU11]<!-- RN 38201 -->/10.4.1<!-- RN 37110 --> onwards. You can [run it in System Center](xref:Running_BPA_tests) on the *Agents > BPA* tab.

## Metadata

- Name: Check Cluster SLNet Connections
- Description: Will run a test on each DMA to make each DMA check its own SLNet connections. Will also check if the DMA is part of a Failover pair.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

Test succeeded: From this point of view, all SLNet connections and connections between Failover pairs (if applicable) look good.

### Error

One or more potential problems were detected.

The detailed JSON output of the BPA test may contain the following possible messages, depending on which potential issues are detected:

- The DataMiner Agent where the BPA was triggered got no results back from these DataMiner Agents: X (where X is a summary of the relevant Agents).

- Does not know these DataMiner Agents: X (specified DMA does not have an SLNet connection to X Agents, where X is a summary of the relevant Agents).

- Does not have other SLNet connections (specified DMA does not have SLNet connections to other Agents).

- SLNet connections to these DataMiner Agents are not healthy: X (where X is a summary of the relevant Agents).

- Did not receive a heartbeat message from the Failover buddy. (Agent is part of a Failover setup but something went wrong when sending the heartbeat message to the Failover buddy.)

- Failover buddy has no Failover configuration.

- Failover configuration on buddy is invalid.

- Failover buddy detected syncing problems.

- Could not determine which type of connection is used with the Failover buddy. (Agent is part of a Failover pair but cannot determine which connection is used between the Failover buddies.)

- Connection port [Y] of Failover buddy is not open. (Agent is part of a Failover setup but the connection port of the buddy looks closed. Y represents the port.)

- Unable to communicate with gRPC ports on these Agents: X (where X is the summary of the relevant Agents and the port).

- Unable to communicate with legacy remoting connection ports on these Agents: X (where X is the summary of the relevant Agents and the port).

- Unable to communicate with port X from Failover buddy.
  
- Could not determine which connection is used to these Agents: X (where X is the summary of the relevant Agents).

- Did not check the ports of other Agents because no other Agents were known.

- Did not ICMP ping other Agents because no other Agents were known.

### Warning

The detailed JSON output of the BPA may contain the following messages, depending on which potential issues are detected:

- ICMP ping to these Agents failed: X (where X is is the summary of relevant Agents).

- ICMP ping round-trip time was bigger than 50 ms: X (where X is the summary of relevant Agents and the round-trip time).

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

- Context was null. Cannot continue with the test.

- The BPA did not receive results from other Agents and thus cannot analyze them.

> [!NOTE]
> If you get the exception "BPA doesn't have valid signature", this means the BPA test is unsigned. To resolve this issue, contact Skyline to ask for the signed version of the BPA or upgrade DataMiner.

## Possible solutions

If potential issues are detected, these checks might save you some time:

- Verify that the correct ports are opened. For gRPC this is typically 443. For the legacy remoting connection this is 8004 by default, but another port can be configured. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

- Verify that the connection strings are correct. See [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

- Verify that DMS.xml is correct on each Agent. See [DMS.xml](xref:DMS_xml).

If you are unable to resolve the issues, please contact Skyline Technical Support.

> [!TIP]
> See also: [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)

## Limitations

- When hostnames are used in DMS.xml, this BPA test can potentially falsely indicate problems.

- Results may vary depending on the Agent you start the BPA test from. It can be interesting to also start the BPA test from another Agent.

- This BPA can detect possible issues, but this does not necessarily mean that nothing can be improved in case the BPA succeeds.
