---
uid: BPA_DataMiner_Agent_Versions
description: "Learn about the DataMiner Agent Versions BPA test, which checks whether all DataMiner Agents in a cluster run the same server version and build."
---

# DataMiner Agent Versions

This BPA test checks whether all DataMiner Agents in a cluster report the same DataMiner server version and build. It identifies a mixed-version state whenever Agents report different versions or builds.

The BPA test is executed across the cluster rather than on an individual DataMiner Agent and uses the cached cluster version information. It checks the complete version, including the build number.

This test is included by default from DataMiner 10.6.12/10.7.0 onwards<!-- RN 46808 -->. You can [run it in System Center](xref:Running_BPA_tests) on the *Agents > BPA* tab.

## Metadata

- Name: DataMiner Agent Versions
- Description: Checks whether all DataMiner Agents in the cluster run the same server version and build.
- Author: Skyline Communications
- Default schedule: Every day

## Results

### Success

The BPA test reports a successful result when all DataMiner Agents report the same known DataMiner server version and build.

- The outcome is `NoIssues`.
- The test was executed successfully.
- No mixed-version state was detected.

### Mixed version state

The BPA test reports an issue when DataMiner Agents report different server versions or builds.

- The outcome is `IssuesDetected`.
- The test was executed successfully.
- The result message is `The cluster is currently in a mixed version state.`
- The details include the latest reported version, every distinct reported version, and every Agent below the latest version.
- For each affected Agent, the details can include its name, node ID, and complete version and build.

A mixed-version state indicates that Agents are running different server versions or builds. Some newer features may not be available on all Agents.

### Not executed

The BPA test cannot provide a conclusive result when the cached cluster version data is missing, incomplete, or invalid, or when the required Agent information cannot be resolved. The result then has the following characteristics:

- The outcome is `IssuesDetected`.
- `TestExecuted` is `false`.
- The details include the failure reason and can include unresolved Agent node IDs, the exception type, and the exception message.

This can occur in the following situations:

- The cache query does not return exactly one valid `ClusterVersionEvent`.
- The event does not contain any Agent version data. Unknown `0.0.0.0-0` version data is marked as unknown in the details and does not produce a successful uniform result.
- The BPA cannot resolve the names of Agents affected by the mixed-version state.
- The BPA receives duplicate node IDs or cannot communicate with SLNet.

When a Failover partner name is not available from the regular Agent information, the BPA can use `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` to resolve it. The file is only required when this fallback is needed. If the file is missing, invalid, ambiguous, or unreadable, and the affected Agent name cannot otherwise be resolved, the test will be reported as not executed.

## Impact when issues are detected

- **Impact:** Different DataMiner server versions or builds are running in the cluster. Some newer features may not be available on all Agents.
- **Corrective action:** Investigate why the versions or builds differ. Upgrade all DataMiner Agents to the same latest server version and build, then run the BPA test again.

## Remarks

- Agents with the same major, minor, and patch version but different build numbers are reported as having different versions.
- The BPA requires reliable cached version data and Agent name information to report a mixed-version result as executed. Otherwise, it reports an inconclusive result with the available diagnostic details.
