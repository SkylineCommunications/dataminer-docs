---
uid: VerifyDotNetRemotingEndOfLife
description: "Learn about the VerifyDotNetRemotingEndOfLife prerequisite check and how to resolve it before upgrading DataMiner to version 10.7.x."
---

# Verify .NET Remoting End of Life

From DataMiner 10.7.0/10.7.1 onwards<!-- RN 46984 -->, the *VerifyDotNetRemotingEndOfLife* prerequisite check is included in upgrade packages. It verifies whether .NET Remoting is explicitly enabled for communication between DataMiner Agents or between DataMiner Cube and SLNet. .NET Remoting has reached [End of Life](xref:Software_support_life_cycles) and is no longer supported in DataMiner 10.7.0/10.7.1 and higher<!-- RN 47004 -->.

If .NET Remoting is explicitly enabled, the upgrade is blocked.

## Fixing a failing prerequisite check

Make sure gRPC is used instead of .NET Remoting, as explained in [Disabling .NET Remoting](xref:Configuration_of_DataMiner_processes#disabling-net-remoting). Then try upgrading again.

> [!TIP]
> See also: [DataMiner Agent hardening](xref:DataMiner_hardening_guide#dataminer-agent-hardening)
