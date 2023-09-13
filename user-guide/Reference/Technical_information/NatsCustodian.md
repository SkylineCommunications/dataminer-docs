---
uid: NatsCustodian
---

# NatsCustodian

## Automated NATS Configuration Monitoring with NatsCustodian

NatsCustodian is a dedicated manager in SLNet designed to monitor and manage NATS configuration in real-time. Performing checks every minute, NatsCustodian automates the process of identifying and addressing configuration anomalies. This ongoing oversight is critical to maintain uninterrupted messaging, system stability, and performance in cluster environments where configuration changes are frequent. As such, NatsCustodian plays an essential role in ensuring the efficient operation of the NATS server clusters.

## NatsCustodian workflow: Up to DataMiner 10.2.0-CU18 / 10.3.0-CU6 / 10.3.9

NatsCustodian operates by gathering the IP addresses of DataMiner agents that are active and connected to the local DataMiner. Using these IPs, it dynamically assembles a NATS configuration for comparison with the currently active NATS setup. This involves several checks: identification of new nodes, detection of deleted nodes, validation of configuration correctness, and ensuring the NATS process is operational. If any irregularities are detected during these checks, NatsCustodian initiates a reconfiguration of NATS. Please note that the functionality of this version is contingent upon the connection status of the DataMiner agents within the cluster which is maintained and verified by the SLNet process. See flowchart below for a more detailed explanation.

```mermaid
flowchart TD
    Start((Start)) --> S1
    S1[/Active SLNet connections in running state/] --> S2
    S2[Collect nodes] --> S3
    S3[Build Nats configuration] --> S4A
    S4A[/New Nats configuration/] --> S5
    S4B[/Current Nats configuration/] --> S5
    S5[Check for configuration changes] --> S6
    S6[Identify new nodes] --> S7
    S7[Detect deleted nodes] --> S8
    S8[Validate config differences] --> S9
    S9[Ensure Nats operational] --> Q1
    Q1{Detected changes?} -->|Yes|A1A
    Q1 -->|No|End
    A1A[Reconfigure Nats configuration] --> S10
    S10[Restart Nats] --> End
```

## NatsCustodian workflow: Starting from DataMiner 10.2.0-CU18 / 10.3.0-CU6 / 10.3.9

NatsCustodian acquires the IP addresses of DataMiner agents in the DataMiner system/cluster. It then creates a NATS configuration using these addresses and cross-verifies this against the existing NATS setup. Additionally, the NATS Monitoring API, which provides various endpoints for assessing the NATS server's status, is employed to check the current status of NATS nodes. This functionality is particularly advantageous as the NATS server and its Monitoring API operate independently of the DataMiner server, thus enhancing cluster stability and reducing potential downtime.

The system incorporates several checks, including identification of new nodes, detection of deleted nodes, tracking of unreachable nodes, validation of configuration correctness, and ensuring the running status of the NATS process.

Should NatsCustodian identify any inconsistency, except for unreachable nodes, an automatic NATS reconfiguration is initiated.

```mermaid
flowchart TD
Start((Start)) --> S1
S1[/DataMiner system agents/] --> S2
S2[Collect Nodes] --> S3
S3[Build Nats configuration] --> S4
S4[/New Nats configuration/] --> S5
S4A[/Current Nats configuration/] --> S5
S4B[/Nats Monitoring API/] --> S5
S5[Check for configuration changes] --> S6
S6[Identify new nodes] --> S7
S7[Detect deleted nodes] --> S8
S8[Validate config differences] --> S9
S9[Ensure Nats operational] --> S10
S10[Identify unreachable nodes] --> Q1
Q1{Detected changes for
automatic Nats reconfiguration?} -->|Yes| A1
Q1 -->|No| End
A1[Reconfigure Nats configuration] --> A1S2
A1S2[Restart Nats] --> End
```

### Triggering Nats Reconfiguration

See: [Nats Reset](xref:Investigating_NATS_Issues#try-a-nats-reset)