---
uid: SiteManagerGettingStarted
---

# Getting started with Site Manager

## Site Manager DxM installation

The Site Manager DxM must run on the same machine as the DataMiner Agent from which you want to connect to remote data sources. It can be used with any DataMiner System that uses version 10.5.10/10.6.0 or higher. You can [deploy it from the Admin app](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

The Site Manager DxM is **by default included in the DaaS image of DataMiner 10.5.10**. If your DaaS system is using an older DataMiner version, you will need to [upgrade DataMiner](xref:Upgrading_a_DataMiner_Agent) and [deploy the Site Manager DxM](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

When the Site Manager DxM has been installed, in the Windows services overview, you should see two services:

- *DataMiner SiteManager*: This is the Site Manager DxM that interacts with DataMiner and the zrok-agent process
- *zrok-agent*: This is the zrok Agent service with which the Site Manager DxM communicates for creating the communication tunnels

## On-premises setup

To allow DataMiner to access an on-premises data source via the Site Manager, the following steps are needed:

### [Windows](#tab/windows)

1. On a machine in your on-premises network, run the [DataMiner SiteManager setup](https://github.com/SkylineCommunications/dataminer-sitemanager-setup/blob/main/Setup-DataMinerSiteManager.ps1) script by using the following command, where you replace the placeholders with the **account token** and a **site name**.

   ```powershell
   iex "& { $(iwr https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.ps1) } -Command install -AccountToken '<AccountToken>' -SiteName '<SiteName>'"
   ```

   - You can find the **account token** in the Site Manager logging in DataMiner Cube, via *Apps* > *System Center* > *Logging* > *Site Manager (DxM)*. This log file should contain a line mentioning a token as follows: `Your account token is aWsTbeKpwARK. You can now get started configuring your site(s). Learn more at https://aka.dataminer.services/SiteManagerGettingStarted."`. Copy this token.

   - The **site name** should be a concise description of the site from which you are exposing data sources. When a connection is configured during the creation or editing of an element in DataMiner Cube, this description will be shown in the *Site* dropdown.

   > [!NOTE]
   >
   > - The minimum OS version required by the script is Windows 10 or Windows Server 2019 build 17134.
   > - You must run the script as administrator.
   > - The machine where you install this script must be able to access the data sources you want to expose. It does not have to be the machine where the data sources are running.
   > - In case PowerShell's execution policy prevents the execution, specify an execution policy (e.g. `-ExecutionPolicy Bypass`). For more information regarding PowerShell's execution policy, refer to [About execution policies](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.5).
   > - Updating a site name is not straightforward. To update a site name, you will need to uninstall (as mentioned below) and then run the script again. Also, if data sources have been configured to set up a connection with this site, the configuration of these data sources will also need to be updated.

   To uninstall, you can use the following command:

   ```powershell
   iex "& { $(iwr https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.ps1) } -Command uninstall"
   ```

1. After a successful installation, you can start exposing your data sources so Site Manager can set up a tunnel for each data source it needs to communicate with.

   1. If you are using a new **PowerShell** shell, execute the following command first: `$env:USERPROFILE = "C:\Windows\System32\config\systemprofile"`.

      Alternatively, if you are using a new **command prompt**, make sure to first execute the following command: `set USERPROFILE=c:\Windows\System32\config\systemprofile`.

   1. For each data source you wish to expose, execute the following commands in the order below:

      ```powershell
      zrok reserve private --backend-mode <backendMode> <endpoint>
      ```

      In the command above, `<backendMode>` is either *tcpTunnel* or *udpTunnel*, and `<endpoint>` specifies the endpoint you want to expose. For example: `zrok reserve private --backend-mode tcpTunnel 127.0.0.1:4208`. When executing this command, you should see the following output: `your reserved share token is '2dxzh484zn3'`. Copy the token and execute the next command.

      ```powershell
      zrok share reserved <token>
      ```

      In the command above, `<token>` is the token value shown in the output of the previous command.

### [Linux](#tab/linux)

1. On a machine in your on-premises network, run the [DataMiner SiteManager setup](https://github.com/SkylineCommunications/dataminer-sitemanager-setup/blob/main/Setup-DataMinerSiteManager.sh) script by using the following command, where you replace the placeholders with the **account token** and a **site name**.

   ```bash
   wget -qO- "https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.sh" | bash -s -- install '<AccountToken>' '<SiteName>'
   ```

   - You can find the **account token** in the Site Manager logging in DataMiner Cube, via *Apps* > *System Center* > *Logging* > *Site Manager (DxM)*. This log file should contain a line mentioning a token as follows: `Your account token is aWsTbeKpwARK. You can now get started configuring your site(s). Learn more at https://aka.dataminer.services/SiteManagerGettingStarted."`. Copy this token.

   - The **site name** should be a concise description of the site from which you are exposing data sources. When a connection is configured during the creation or editing of an element in DataMiner Cube, this description will be shown in the *Site* dropdown.

   > [!NOTE]
   >
   > - The Linux distribution must be using `systemd` as the service manager.
   > - The script must be run via sudo.
   > - The machine where you run the script does not have to be the same as the one where the data sources are running.
   > - Updating a site name is not straightforward. To update a site name, a reinstallation needs to be performed. Also, if data sources have been configured to set up a connection with this site, the configuration of these data sources will also need to be updated.

   To uninstall, you can use the following command:

   ```bash
   wget -qO- "https://raw.githubusercontent.com/SkylineCommunications/dataminer-sitemanager-setup/main/Setup-DataMinerSiteManager.sh" | bash -s -- uninstall
   ```

1. After a successful installation, you can start exposing your data sources so Site Manager can set up a tunnel for each data source it needs to communicate with.

   For each data source you wish to expose, perform the following steps:

   1. Perform the following command:

      ```bash
      zrok reserve private --backend-mode <backendMode> <endpoint>
      ```

      In the command above, `<backendMode>` is either *tcpTunnel* or *udpTunnel*, and `<endpoint>` specifies the endpoint you want to expose. For example: `zrok reserve private --backend-mode tcpTunnel 127.0.0.1:4208`. When executing this command, you should see the following output: `your reserved share token is '2dxzh484zn3'`. Copy the token and execute the next command.

   1. Perform the following command:

      ```bash
      zrok share reserved <token>
      ```

      In the command above, `<token>` is the token value shown in the output of the previous command.

***

### Getting an overview of shared resources

To get an overview of the endpoints that have been shared, type the following command:

```powershell
zrok agent status
```

This will result in an overview similar to the following example:

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

### Stopping the sharing of an endpoint

In case you no longer want to expose a specific endpoint:

1. Execute the following command, replacing `<shareToken>` with the share token for this specific endpoint (e.g. `02x31uu2yacbh`):

   ```powershell
   zrok release <shareToken>
   ```

   This will release the share from the zrok controller.

1. Execute the following command:

   ```powershell
   zrok agent release share <shareToken>
   ```

   This will release the share from the zrok Agent.

## Creating an element that communicates with a data source through a tunnel

Once a data source has been shared, you are ready to connect to it from a DaaS system.

1. In DataMiner Cube, [add a new element](xref:Adding_elements).

1. When you configure an element connection for the element that should communicate with a data source on a remote site (through a secure tunnel), select the site in *Site* dropdown.

   The site name that appears in the *Site* dropdown corresponds with the description given during execution of the on-premises installation script.

1. Fill in the IP or hostname of the exposed data source.

   > [!IMPORTANT]
   > If, during [on-premises setup](#on-premises-setup), you specified the endpoint to be shared (in the zrok reserve command) using the IP address, then to access the data source in DataMiner you will also need to specify the IP address. Similarly, if you used the hostname, you will also need to specify the hostname in DataMiner Cube.

A tunnel will only be created as long as at least one element is actively connecting to this endpoint. For example, if you have an element that sets up a connection to a data source on a remote site, the tunnel will only be created when the element is started. As soon as the element is stopped or deleted, the tunnel will be torn down.

In case multiple elements on the same DataMiner Agent connect to the same remote endpoint, only a single tunnel will be set up and this tunnel will be shared by the elements on that DataMiner Agent. The tunnel will only be torn down when all elements that connect to this remote endpoint are either stopped or deleted.
