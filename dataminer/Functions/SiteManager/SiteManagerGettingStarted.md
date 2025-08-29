---
uid: SiteManagerGettingStarted
---

# Getting Started

## Site Manager DxM installation

The Site Manager DxM runs next to a DataMiner Agent. The Site Manager DxM is included by default with the 10.5.10 DaaS image.
In the Windows services overview, you should see two services:

- DataMiner SiteManager: This is the Site Manager DxM that interacts with DataMiner and the zrok-agent process
- zrok-agent: This is the zrok Agent service with which the Site Manager DxM communicates for creating the communication tunnels

## On-premises setup

To allow DataMiner to access an on-premises data source via the Site Manager, the following steps are needed:

1. On a machine on your on-premises network, run the [DataMiner SiteManager setup](https://github.com/SkylineCommunications/dataminer-sitemanager-setup) script specifying the **token** and a provide a **description**. 

  The token you need to specify can be found in the Site Manager log: In Cube, open the log file of the Site Manager DxM. (*Apps* > *System Center* > *Logging* > *Site Manager (DxM)*). The log file should contain a line mentioning a token as follows `Your account token is aWsTbeKpwARK. You can now get started configuring your site(s). Learn more at https://aka.dataminer.services/SiteManagerGettingStarted."`. Copy this token. 

  The description you need to provide should be a concise description of the site from which you are exposing data sources. This description will be shown in the Site dropdown for configuring a connection in the element edit wizard in Cube.

  > [!NOTE]
  >
  > - This script needs to be executed on a Windows operating system
  > - The script must run as administrator
  > - The machine on which you install this script must be able to access the data source(s) you wish to expose

  E.g.: `.\Setup-DataMinerSiteManager.ps1 install aWsTbeKpwARK MySiteDescription`.
  To uninstall, execute the following command: `.\Setup-DataMinerSiteManager.ps1 uninstall`.

1. After successful installation, you can start exposing your data source(s) so the DataMiner Site Manager can set up a tunnel for each data source it needs to communicate with.

Open a command window and execute the following commmand: `set USERPROFILE=c:\Windows\System32\config\systemprofile`.
For each data source you wish to expose, perform the following steps:

  1. `zrok reserve private --backend-mode <backendMode> <endpoint>`, where `<backendMode` is either *tcpTunnel* or *udpTunnel* and `<endpoint>` specifies the endpoint you want to expose. E.g.: `zrok reserve private --backend-mode tcpTunnel 127.0.0.1:4208`. When executing this command, you should see the following output: `your reserved share token is '2dxzh484zn3'`. Copy the token and execute the next command.
  1. `zrok share reserved <token>`, where `<token>` is the token value shown in the output of the previous command.

  > [!NOTE]
  > If you specify the endpoint to be shared using the IP address, then to access the data source in DataMiner you will also need to specify the IP address.
  > Similarly, if you use the host name, you will also need to specify the host name in DataMiner Cube.

### Getting an overview of shared resources

To get an overview of the endpoints that have been shared, type the following command: `zrok agent status`. This will give an overview as follows:

```bash
TOKEN         RESERVED  SHARE MODE  BACKEND MODE  TARGET
02x31uu2yacbh  true      private     tcpTunnel     127.0.0.1:8080
1 shares in agent
```

Alternatively, you can also obtain an overview in the browser by navigating to the web frontend of the zrok Agent.
To know on which port the web frontend is running, perform the following command: `zrok agent version`. In addition to the version, the output will also show the endpoint of the web frontend, e.g. `127.0.0.1:8888`.
Navigating to this endpoint in the browser should show a similar overview as the status command.

### Stop sharing an endpoint

In case you no longer want to expose a specific endpoint, execute the following command:

`zrok agent release share <shareToken>`, where `<shareToken>` is the share token for this specific endpoint (e.g. `02x31uu2yacbh`).

## Creating an element that cummunicates with a data source through a tunnel

Once a data source has been exposed, you are ready to connect to it from a DaaS system.

In Cube, create a new element as explained in [Adding elements](xref:Adding_elements).
For a connection that should communicate with a data source on a remote site (through a secure tunnel), specify the site in Site dropdown.
The site name that appears in the Site dropdown corresponds with the description given during execution of the on-premises installation script.

Fill in the IP or host name of the exposed data source.

> [!IMPORTANT]
>
> - If you specified the endpoint to be shared using the IP address, then to access the data source in DataMiner you will also need to specify the IP address.
>   Similarly, if you used the host name, you will also need to specify the host name in DataMiner Cube.

A tunnel will only be created as long that at least one element is actively connecting to this endpoint.
For example, if you have an element that sets up a connection to a data source on a remote site, the tunnel will be created when the element is started.
As soon as the element is stopped or deleted, the tunnel will be tore down.

Note also that in case multiple elements connect to the same remote endpoint, only a single tunnel will be set up and this tunnel will be shared by the elements. The tunnel will only be tore down when all elements that connect to this remote endpoint are either stopped or deleted.
