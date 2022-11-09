---
uid: General_Main_Release_10.4.0_new_features
---

# General Main Release 10.4.0 – Other new features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

### DMS Tools

#### SLNetClientTest tool - 'Connect' window: Enhanced 'Connection Type' and 'Authentication' sections [ID_34712]

<!-- MR 10.4.0 - FR 10.3.1 -->

In the *SLNetClientTest* tool, to connect to a DataMiner Agent, you select *Connection* > *Connect*, and specify the necessary information in the *Connect* window. That window has now been updated.

In the *Connection Type* section, you now have to indicate how the connection has to be established:

| Select...              | in order to... |
|------------------------|----------------|
| Autodetect             | connect to the local machine or a remote machine using the method that will be detected automatically. |
| gRPC                   | connect to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol.<br>When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
| .NET Remoting (legacy) | connect to the local machine or a remote machine using .NET Remoting.<br>When you choose this option, you can specify a custom port (default: `8004`) |
| IPC (only local)       | connect to the local machine using IPC. |

In the *Authentication* section (formerly known as *User Info* section), you now have the following authentication options:

- Single sign-on
- Explicit credentials (with *Force Authenticate Local User* option)
- Ticket

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
