---
uid: Connecting_to_a_DMA_with_the_SLNetClientTest_tool
---

# Connecting to a DMA with the SLNetClientTest tool

Before you can use any of the SLNetClientTest tool functions, you must first connect to a DMA:

## [From DataMiner 10.3.1/10.4.0 onwards](#tab/tabid-1)

1. In the *Connection* menu, click *Connect*.

1. In the *Connect* window, select the host DMA.

1. Indicate how the connection has to be established, in the *Connection Type* section:

   | Option                 | Description    |
   |------------------------|----------------|
   | Autodetect             | Connects to the local machine or a remote machine using a method that will be detected automatically. |
   | gRPC                   | Supported from DataMiner 10.3.0/10.3.2 onwards. Connects to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol. When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
   | .NET Remoting (legacy) | Connects to the local machine or a remote machine using .NET Remoting. When you choose this option, you can specify a custom port (default: `8004`). |
   | IPC (only local)       | Connects to the local machine using IPC. |

1. In the *Authentication* section, specify the necessary options, and then click *Connect*:

   - Single sign-on

     > [!NOTE]
     >
     > - You will be logged on with your current Windows user account.
     > - External authentication is not yet supported.

   - Explicit credentials (with *Force Authenticate Local User* option)

   - Ticket

   - Debug SAML (not yet fully supported)<!--RN 37370-->

     > [!NOTE]
     > The *Debug SAML* option is currently still being developed, so we recommend using the procedure mentioned under [Collecting the SAML response](xref:Troubleshooting_SAML_Issues#collecting-the-saml-response) for this instead. You should only use the *Debug SAML* option in the SLNetClientTest tool if this is recommended by a contact from e.g., DataMiner Support, and this contact has provided you with the necessary means to ensure that the tool functions as expected. After that, when you select this option before connecting to a DMA that uses external authentication via SAML, two pop-up windows will appear, displaying the SAML requests and SAML responses respectively.

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
