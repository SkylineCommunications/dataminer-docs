---
uid: BPA_Check_Cluster_SLNet_Connections
---

# Check Cluster SLNet Connections BPA

The Check Cluster SLNet Connections BPA is a cluster BPA that will triggger a local BPA on each agent that is reachable from the one initiating the cluster BPA, to check the connections between agents. It is important to know if there are issues with these connections as they are used for inter DMS communication. Running this BPA might indicate if there are potential problems.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab, available from DataMiner 10.3.11), this BPA test is available by default.

## Metadata

- Name: Check Cluster SLNet Connections BPA
- Description: Will run a test on each agent to let each agent check its own SLNet connections. Will also check if the agent has a failover.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

- Test succeeded: From this point of view, all SLNet connections and connections between failover pairs (if applicable) look good.

### Error

One or more potential problems where detected.

The detailed JSON output of the BPA may contain the following possible messages, depending on which potential issues are detected:

- The DataMiner Agent where the BPA was triggered on got no results back from these DataMiner Agents: X (where X is a summary of the regarding agents).

- Does not know these DataMiner Agents: X (specified DMA does not have a SLNet connection to X agents, where X is a summary of the regarding agents).

- Does not have other SLNet connections. (specified DMA does not have SLNet connections to other agents)

- SLNet connections to these DataMiner Agents are not healthy: X (where X is a summary of the regarding agents).

- Did not receive a HeartBeatMessage from the failover buddy. (agent is part of a failover setup but something went wrong when sending the HeartBeatMessage to the failover buddy)

- Failover buddy has not a failover configuration.

- Failover configuration on buddy is invalid.

- Failover buddy detected syncing problems.

- Could not determine which type of connection is used with the failover buddy. (agent is part of a failover but cannot determine which connection is used between the failover buddies)

- Connection port [Y] of failover buddy is not open. (agent is part of a failover setup but the connection port of the buddy looks closed. Y represents the port)

- The gRPC ports are closed on these agents: X (where X is the summary of the regarding agents and the port).

- The LegacyRemotingConnection ports are closed on these agents: X (where X is the summary of the regarding agents and the port).

- Could not determine which connection is used to these agents: X (where X is the summary of the regarding agents).

- The ports are closed on these agents: X (where X is the summary of the regarding agents and the port).

- Did not check the ports of other agents because it did not knew other agents.

- Did not ICMP ping other agents because it did not knew others.

### Warning

The detailed JSON output of the BPA may contain the following messages, depending on which potential issues are detected:

- ICMP Ping to these agents failed: X (where X is is the summary of regarding agents).

- ICMP Ping round-trip time was bigger than 50ms: X (where X is the summary of regarding agents and the round-trip time).

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

- Context was null. Cannot continue with the test.

- The BPA did not receive results from other agents and thus cannot analyze them.

## Possible solutions

If potential issues are detected, these checks might save you some time:

- Verify that the correct ports are opened. For gRPC this is typically 443, for LegacyRemotingConnection 8004 by default but this could be configured to another port.

- Verify that the connection strings are correct.

- Verify that DMS.xml is correct on each agent. 

### Useful links

- [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)
  
- [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string)
  
- [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)

If you are unable to resolve the issues, please contact Skyline Technical Support.

## Limitations

- Results may vary from the agent you start the BPA from. It might be interesting to also start the BPA from another agent.

- This BPA could detect possible issues. There is no guarantee nothing can be improved when the BPA succeeds.

- Needs to run on an agent that is part of a cluster.