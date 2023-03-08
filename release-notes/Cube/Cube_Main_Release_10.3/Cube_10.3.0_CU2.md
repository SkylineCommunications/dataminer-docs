---
uid: Cube_Main_Release_10.3.0_CU2
---

# DataMiner Cube Main Release 10.3.0 CU2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU1](xref:General_Main_Release_10.3.0_CU2).

### Enhancements

### Fixes

#### Cube could start to consume excessive CPU cycles whenever an operation took a long time or a deadlock occurred [ID_35614]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Whenever an operation took a long time or a deadlock occurred, up to now, Cube could start to consume excessive CPU cycles.

#### Problems when Cube was configured to connect using gRPC [ID_35615]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you had configured DataMiner Cube to connect using gRPC (by specifying `type=GRPCConnection` in the *ConnectionSettings.txt* file), the following issues could occur:

- The *About* and *Logging* windows would not be available on the login screen if .NET Remoting had been disabled on the DataMiner Agent.

- In some cases, Cube would become unresponsive when retrieving the user thumbnail pictures. These will now be retrieved in the background.
