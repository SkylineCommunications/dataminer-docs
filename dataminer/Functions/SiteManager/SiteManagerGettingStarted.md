---
uid: SiteManagerGettingStarted
---

# Getting started with Site Manager

## Site Manager DxM installation

The Site Manager DxM must run on the same machine the DataMiner Agent runs from which you want to connect to remote data sources. The Site Manager DxM is by default included in the DaaS image of DataMiner 10.5.10. In case you are running an older DataMiner version, an upgrade is required and the Site Manager DxM will need to be installed. For more information on how to upgrade DataMiner, refer to [Upgrading a DataMiner Agent](xef:Upgrading_a_DataMiner_Agent). For information on how to install a DxM, see [Deploying a DxM on a DMS node](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

When you have installed the Site Manager DxM, in the Windows services overview, you should see two services:

- *DataMiner SiteManager*: This is the Site Manager DxM that interacts with DataMiner and the zrok-agent process
- *zrok-agent*: This is the zrok Agent service with which the Site Manager DxM communicates for creating the communication tunnels

## On-premises setup

To allow DataMiner to access an on-premises data source via the Site Manager, the following steps are needed:

### [Windows](#tab/windows)

1. On a machine on your on-premises network (this does not need to be on the same server where the data source is running), run the [DataMiner SiteManager setup](https://github.com/SkylineCommunications/dataminer-sitemanager-setup/blob/main/Setup-DataMinerSiteManager.ps1) script specifying the **account token** and a **site name**.

    The account token you need to specify can be found in the Site Manager log: In Cube, open the log file of the Site Manager DxM. (*Apps* > *System Center* > *Logging* > *Site Manager (DxM)*). The log file should contain a line mentioning a token as follows `Your account token is aWsTbeKpwARK. You can now get started configuring your site(s). Learn more at https://aka.dataminer.services/SiteManagerGettingStarted."`. Copy this token.

    The site name you need to provide should be a concise description of the site from which you are exposing data sources. This description will be shown in the Site dropdown for configuring a connection in the element edit wizard in Cube.

    > [!NOTE]
    >
    > - The script must be executed on Windows 10 / Windows Server 2019 build 17134 or later
    > - The script must run as administrator
    > - In case PowerShell's execution policy prevents the execution, specify an execution policy (e.g. `-ExecutionPolicy Bypass`). For more information regarding PowerShell's execution policy, refer to [About execution policies](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.5).
    > - The machine on which you install this script must be able to access the data source(s) you wish to expose
    > - Updating a site name is not straightforward. To update a site name, a reinstallation needs to be performed. Also, once data sources have been configured to set up a connection with this site, the configuration of these data sources will also need to be updated.

    You can use the following command to execute the install script. Replace the placeholders with your account token and site name.

    ```powershell
    iex "& { $(iwr https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.ps1) } -Command install -AccountToken '<AccountToken>' -SiteName '<SiteName>'"
    ```

    To uninstall, the following command can be executed:

    ```powershell
    iex "& { $(iwr https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.ps1) } -Command uninstall"
    ```

1. After successful installation, you can start exposing your data source(s) so the DataMiner Site Manager can set up a tunnel for each data source it needs to communicate with.

    > [!NOTE]
    > If you are in a new PowerShell shell, execute the following command first: `$env:USERPROFILE = "C:\Windows\System32\config\systemprofile"`.
    > If you are in a new command prompt, make sure to first execute the following command `set USERPROFILE=c:\Windows\System32\config\systemprofile`.

    For each data source you wish to expose, perform the following steps:

    1. Perform the following command:

        ```powershell
        zrok reserve private --backend-mode <backendMode> <endpoint>
        ```

       , where `<backendMode>` is either *tcpTunnel* or *udpTunnel* and `<endpoint>` specifies the endpoint you want to expose. E.g.: `zrok reserve private --backend-mode tcpTunnel 127.0.0.1:4208`. When executing this command, you should see the following output: `your reserved share token is '2dxzh484zn3'`. Copy the token and execute the next command.
    1. Then, perform the following command:

        ```powershell
        zrok share reserved <token>
        ```

       , where `<token>` is the token value shown in the output of the previous command.

### [Linux](#tab/linux)

1. On a machine on your on-premises network (this does not need to be on the same server where the data source is running), run the [DataMiner SiteManager setup](https://github.com/SkylineCommunications/dataminer-sitemanager-setup/blob/main/Setup-DataMinerSiteManager.sh) script specifying the **account token** and a **site name**.

    The account token you need to specify can be found in the Site Manager log: In Cube, open the log file of the Site Manager DxM. (*Apps* > *System Center* > *Logging* > *Site Manager (DxM)*). The log file should contain a line mentioning a token as follows `Your account token is aWsTbeKpwARK. You can now get started configuring your site(s). Learn more at https://aka.dataminer.services/SiteManagerGettingStarted."`. Copy this token.

    The site name you need to provide should be a concise description of the site from which you are exposing data sources. This description will be shown in the Site dropdown for configuring a connection in the element edit wizard in Cube.

    > [!NOTE]
    >
    > - The Linux distribution must be using `systemd` as the service manager
    > - The script must be run via sudo
    > - Updating a site name is not straightforward. To update a site name, a reinstallation needs to be performed. Also, once data sources have been configured to set up a connection with this site, the configuration of these data sources will also need to be updated.

    You can use the following command to execute the install script. Replace the placeholders with your account token and site name.

    ```bash
    wget -qO- "https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.sh" | bash -s -- install '<AccountToken>' '<SiteName>'
    ```

    To uninstall, the following command can be executed:

    ```bash
    wget -qO- "https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.sh" | bash -s -- uninstall
    ```

1. After successful installation, you can start exposing your data source(s) so the DataMiner Site Manager can set up a tunnel for each data source it needs to communicate with.

    For each data source you wish to expose, perform the following steps:

    1. Perform the following command:

        ```bash
        zrok reserve private --backend-mode <backendMode> <endpoint>
        ```

       , where `<backendMode>` is either *tcpTunnel* or *udpTunnel* and `<endpoint>` specifies the endpoint you want to expose. E.g.: `zrok reserve private --backend-mode tcpTunnel 127.0.0.1:4208`. When executing this command, you should see the following output: `your reserved share token is '2dxzh484zn3'`. Copy the token and execute the next command.
    1. Then, perform the following command:

        ```bash
        zrok share reserved <token>
        ```

       , where `<token>` is the token value shown in the output of the previous command.

***

### Getting an overview of shared resources

To get an overview of the endpoints that have been shared, type the following command:

```powershell
zrok agent status
```

This will give an overview as follows:

```bash
TOKEN         RESERVED  SHARE MODE  BACKEND MODE  TARGET
02x31uu2yacbh  true      private     tcpTunnel     127.0.0.1:8080
1 shares in agent
```

Alternatively, you can also obtain an overview in the browser by navigating to the web frontend of the zrok Agent. To know on which port the web frontend is running, perform the following command:

```powershell
zrok agent version
```

In addition to the version, the output will also show the endpoint of the web frontend, e.g. `127.0.0.1:8888`.
Navigating to this endpoint in the browser should show a similar overview as the status command.

![Overview](~/dataminer/images/zrok_agent_webui.png)<br>*zrok Agent web UI*

### Stop sharing an endpoint

In case you no longer want to expose a specific endpoint, execute the following commands:

```powershell
zrok release <shareToken>
```

, where `<shareToken>` is the share token for this specific endpoint (e.g. `02x31uu2yacbh`). This will release the share from the zrok controller.

Then execute the following command:

```powershell
zrok agent release share <shareToken>
```

This will release the share from the zrok Agent.

## Creating an element that communicates with a data source through a tunnel

Once a data source has been shared, you are ready to connect to it from a DaaS system.

In Cube, create a new element as explained in [Adding elements](xref:Adding_elements).
For a connection that should communicate with a data source on a remote site (through a secure tunnel), specify the site in Site dropdown.
The site name that appears in the Site dropdown corresponds with the description given during execution of the on-premises installation script.

Fill in the IP or host name of the exposed data source.

> [!IMPORTANT]
>
> If you specified the endpoint to be shared (in the zrok reserve command) using the IP address, then to access the data source in DataMiner you will also need to specify the IP address. Similarly, if you used the host name, you will also need to specify the host name in DataMiner Cube.

A tunnel will only be created as long as at least one element is actively connecting to this endpoint.
For example, if you have an element that sets up a connection to a data source on a remote site, the tunnel will only be created when the element is started. As soon as the element is stopped or deleted, the tunnel will be torn down.

Note also that in case multiple elements on the same DataMiner Agent connect to the same remote endpoint, only a single tunnel will be set up and this tunnel will be shared by the elements on that DataMiner Agent. The tunnel will only be torn down when all elements that connect to this remote endpoint are either stopped or deleted.
