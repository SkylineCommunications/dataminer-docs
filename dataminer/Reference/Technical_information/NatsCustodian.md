---
uid: NatsCustodian
---

# NatsCustodian

NatsCustodian is a dedicated manager in SLNet designed to monitor and manage NATS configuration in real time. Performing checks every minute, NatsCustodian automates the process of identifying and addressing configuration anomalies. This ongoing monitoring is critical to maintain uninterrupted messaging, system stability, and performance in cluster environments where configuration changes are frequent. As such, NatsCustodian plays an essential role in ensuring the efficient operation of NATS server clusters.

This manager is removed from DataMiner starting from version 10.6.0 onwards, as the NATS management is fully migrated to BrokerGateway.<!-- RN 44035 -->

## NatsCustodian workflow starting from DataMiner 10.2.0 [CU18], 10.3.0 [CU6], and 10.3.9

NatsCustodian acquires the IP addresses of DataMiner Agents in the DataMiner System (i.e. the cluster). It then creates a NATS configuration using these addresses and cross-verifies this against the existing NATS setup. Additionally, the NATS Monitoring API, which provides various endpoints for assessing the NATS server's status, is employed to check the current status of NATS nodes. This functionality is particularly advantageous as the NATS server and its Monitoring API operate independently of the DataMiner server, thus enhancing cluster stability and reducing potential downtime.

The system incorporates several checks, including identification of new nodes, detection of deleted nodes, tracking of unreachable nodes, validation of configuration correctness, and ensuring the running status of the NATS process.

From DataMiner 10.2.0 [CU20]/10.3.0 [CU8]/10.3.11 onwards<!--RN 37271-->, when NatsCustodian detects that a NATS node has been added or deleted, that NATS is in an incorrect state, or that the NATS process is not running, an automatic NATS reconfiguration is initiated. Unreachable nodes do not generate any alarms or trigger a NATS reconfiguration. Instead, an entry is added to the *NATSCustodian.txt* log file for diagnostic purposes.

Prior to DataMiner 10.2.0 [CU20]/10.3.0 [CU8]/10.3.11, should NatsCustodian identify any inconsistency other than unreachable nodes, an automatic NATS reconfiguration is initiated.

```mermaid
flowchart TD
    %% Define styles %%
    linkStyle default stroke:#cccccc
    classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
    classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
    classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
    classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
    classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
    classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
    %% Define blocks %%
    Start((Start))
    S1[/DataMiner System Agents/]
    S2[Collect Nodes]
    S3[Build NATS configuration]
    S4A[/Current NATS configuration/]
    S4[/New NATS configuration/]
    S4B[/NATS Monitoring API/]
    S5[Check for configuration changes]
    S6[Identify new nodes]
    S7[Detect deleted nodes]
    S8[Validate config differences]
    S9[Ensure NATS is operational]
    S10[Identify unreachable nodes]
    Q1{Detected <br/>changes <br/>for automatic <br/>NATS <br/>reconfiguration?}
    A1[Reconfigure NATS configuration]
    A1S2[Restart NATS]
    %% Connect blocks %%
    Start --- S1
    S1 --- S2
    S2 --- S3
    S3 --- S4
    S4A --- S5
    S4 --- S5
    S4B --- S5
    S5 --- S6
    S6 --- S7
    S7 --- S8
    S8 --- S9
    S9 --- S10
    S10 --- Q1
    Q1 ---|Yes| A1
    Q1 ---|No| End
    A1 --- A1S2
    A1S2 --- End
    %% Apply styles to blocks %%
    class Start,End classTerminal;
    class S1,S4,S4A,S4B,Q1 classDecision;
    class S2,S3,S5,S6,S7,S8,S9,S10,A1,A1S2 classExternalRef;
```

## NatsCustodian workflow up to DataMiner 10.2.0 [CU18], 10.3.0 [CU6], and 10.3.9

NatsCustodian operates by gathering the IP addresses of DataMiner Agents that are active and connected to the local DataMiner Agent. Using these IPs, it dynamically assembles a NATS configuration for comparison with the currently active NATS setup. This involves several checks: identification of new nodes, detection of deleted nodes, validation of configuration correctness, and ensuring the NATS process is operational. If any irregularities are detected during these checks, NatsCustodian initiates a reconfiguration of NATS.

> [!NOTE]
> The functionality of this version of NatsCustodian is contingent upon the connection status of the DataMiner Agents within the cluster, which is maintained and verified by the SLNet process. See flowchart below for a more detailed explanation.

```mermaid
flowchart TD
    %% Define styles %%
    linkStyle default stroke:#cccccc
    classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
    classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
    classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
    classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
    classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
    classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
    %% Define blocks %%
    Start((Start))
    S1[/Active SLNet connections in running state/]
    S2[Collect nodes]
    S3[Build NATS configuration]
    S4A[/New NATS configuration/]
    S4B[/Current NATS configuration/]
    S5[Check for configuration changes]
    S6[Identify new nodes]
    S7[Detect deleted nodes]
    S8[Validate config differences]
    S9[Ensure NATS is operational]
    Q1{Detected <br/>changes?}
    A1A[Reconfigure NATS configuration]
    S10[Restart NATS]
    %% Connect blocks %%
    Start --- S1
    S1 --- S2
    S2 --- S3
    S3 --- S4A
    S4A --- S5
    S4B --- S5
    S5 --- S6
    S6 --- S7
    S7 --- S8
    S8 --- S9
    S9 --- Q1
    Q1 ---|Yes| A1A
    Q1 ---|No| End
    A1A --- S10
    S10 --- End
    %% Apply styles to blocks %%
    class Start,End classTerminal;
    class S4A,S1,S4B,Q1 classDecision;
    class S2,S3,S5,S6,S7,S8,S9,A1A,S10 classExternalRef;
```

### Triggering NATS reconfiguration

See [NATS reset](xref:Investigating_Legacy_NATS_Issues#try-a-nats-reset).
