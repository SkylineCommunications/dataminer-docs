---
uid: Connecting_to_a_DMA_with_the_SLNetClientTest_tool
---

# Connecting to a DMA with the SLNetClientTest tool

Before you can use any of the SLNetClientTest tool functions, you must first connect to a DMA:

## [From DataMiner 10.3.1/10.4.0 onwards](#tab/tabid-1)

1. In the *Connection* menu, click *Connect*.

1. In the *Connect* window, select the host DMA.

1. Indicate how the connection has to be established, in the *Connection Type* section:

   | Select...              | in order to... |
   |------------------------|----------------|
   | Autodetect             | connect to the local machine or a remote machine using the method that will be detected automatically. |
   | gRPC                   | connect to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol.<br>When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
   | .NET Remoting (legacy) | connect to the local machine or a remote machine using .NET Remoting.<br> When you choose this option, you can specify a custom port (default: `8004`) |
   | IPC (only local)       | connect to the local machine using IPC. |

1. In the *Authentication* section, specify any of the following options if necessary, and then click *Connect*:

   - Single sign-on

     > [!NOTE]
     > External authentication not yet supported.

   - Explicit credentials (with *Force Authenticate Local User* option)

   - Ticket

## [Prior to DataMiner 10.3.1/10.4.0](#tab/tabid-2)

1. In the *Connection* menu, click *Connect*.

1. In the *Connect* window, select the host DMA.

1. Specify any of the following options if necessary, and then click *Connect*:

    - To use a different logon, select *Disable Windows Logon* and enter your credentials.

    - To connect via Web Services, select *Web Services* instead of the default *Remoting*.

    - To specify a different port for the connection, select *Disable Auto-Discover* and *Specify Port*, and enter the port.

    - To disable any client-side caching, select *Disable Client Cache*.

***

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.