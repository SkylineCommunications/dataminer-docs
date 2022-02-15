---
uid: DataMiner_client_applications
---

# DataMiner client applications

This section contains the following topics:

- [How do I send info about my DataMiner client to Technical Support?](#how-do-i-send-info-about-my-dataminer-client-to-technical-support)

- [How do I reinstall DataMiner Cube?](#how-do-i-reinstall-dataminer-cube)

- [What should I do if I cannot connect to a DMA using Cube?](#what-should-i-do-if-i-cannot-connect-to-a-dma-using-cube)

- [How can I open the legacy System Display and Element Display applications?](#how-can-i-open-the-legacy-system-display-and-element-display-applications)

### How do I send info about my DataMiner client to Technical Support?

In case of problems, Skyline Technical Support may ask you to provide version information and/or debug information. Below, you can find how you can gather the requested information.

#### Sending version information to Technical Support

1. In DataMiner Cube, go to *Apps* > *About*.

2. In the *About* box, click the *Versions* tab.

3. At the bottom of the dialog box, click *Copy Versions Information*.

4. Paste the text in a new email message, and send the information to [techsupport@skyline.be](mailto:techsupport%40skyline.be).

#### Sending debug information to Technical Support

1. In DataMiner Cube, go to *Apps* > *About*.

2. At the bottom of the *About* box, click *Email Debug Information*.

    A new email message containing the debug information will open.

    > [!NOTE]
    > You may get a warning, saying that an application (DataMiner Cube) is trying to send an email message from your computer.

3. Send the information to [techsupport@skyline.be](mailto:techsupport%40skyline.be).

### How do I reinstall DataMiner Cube?

If the security policy of your company or computer allows it, DataMiner Cube is automatically downloaded and installed onto your computer the first time you try to open their user interface in a web browser.

If, for any reason, you want to reinstall Cube, you need to clean the XBAP cache:

1. Open Microsoft Internet Explorer and, depending on your setup, go to one of the following addresses:

    ```txt
    https://[DMA]/Tools
    http://[DMA]/Tools
    ```

2. Click *Clean DataMiner Cube XBAP Cache* and then click *Run*.

3. Open Microsoft Internet Explorer and, depending on your setup, go to one of the following addresses:

    ```txt
    https://[DMA]/dataminercube
    http://[DMA]/dataminercube
    ```

> [!NOTE]
> - In the above-mentioned addresses, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
> - This procedure does not apply if DataMiner Cube was installed via an MSI file.

### What should I do if I cannot connect to a DMA using Cube?

1. Check if Internet Explorer has been correctly configured to run Cube for this DMA.

    See [Configuring Internet Explorer to run DataMiner Cube](xref:Installing_configuring_the_DataMiner_Cube_software#configuring-internet-explorer-to-run-dataminer-cube).

2. If Internet Explorer has been configured correctly, clear the XBAP cache:

    1. Go to *http(s)://**\[DMA IP or name\]**/tools*.

    2. Click *Clean Skyline DataMiner XBAP Cache*.

    3. Click *Run*.

3. If the problem persists, contact DataMiner Technical Support.

### How can I open the legacy System Display and Element Display applications?

> [!NOTE]
> The System Display and Element Display client applications are no longer available from DataMiner 9.6.0 onwards.

Both *System Display* and *Element Display* are ActiveX controls. They are automatically downloaded and installed onto your computer the first time you try to open their user interface in a Microsoft Internet Explorer session.

To open their interface go to one of the following addresses:

```txt
https://[DMA]/SystemDisplay.htm
http://[DMA]/SystemDisplay.htm
https://[Element]/ElementDisplay.htm
http://[Element]/ElementDisplay.htm
```

> [!NOTE]
> - In the above-mentioned address, replace “\[DMA\]” or by the IP address or the hostname of the DataMiner Agent you want to connect to. Replace “\[Element\]” by the virtual IP address or the DataMiner Element you want to connect to.
> - System Display and Element Display will automatically disconnect when the DMA to which you are connected goes offline.

> [!CAUTION]
> We strongly advise to use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information - including logon credentials - is sent as plain, unencrypted text over the internet.<br> See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

> [!NOTE]
> If required, the ActiveX controls can also be installed by means of an MSI installation package.

Once installed, each time you reopen their user interface and connect to a DataMiner Agent, their version will be checked. If newer versions of the ActiveX controls are available, they will automatically be downloaded and installed.

More information on installing and configuring System Display and Element Display is included in the following topics:

- [Prerequisites for running ActiveX controls](#prerequisites-for-running-activex-controls)

- [Configuring Microsoft Internet Explorer to run System Display and Element Display](#configuring-microsoft-internet-explorer-to-run-system-display-and-element-display)

- [Uninstalling the ActiveX controls](#uninstalling-the-activex-controls)

#### Prerequisites for running ActiveX controls

- Microsoft Internet Explorer must be allowed to run ActiveX controls.

    If you have problems running either System Display or Element Display, check the ActiveX settings in your Microsoft Internet Explorer. See [Configuring the ActiveX settings in Microsoft Internet Explorer](#configuring-the-activex-settings-in-microsoft-internet-explorer).

- The following third-party software must be installed:

    - Microsoft .NET Framework 3.5 SP1

    - Microsoft .NET Framework 4.0 (incl. fixes)

    - Microsoft Web Services Enhancements 2.0 SP3 (only when using Web Services)

- To work with spectrum elements in Element Display, active scripting must be enabled. See [Enabling active scripting in Microsoft Internet Explorer](#enabling-active-scripting-in-microsoft-internet-explorer).

#### Configuring Microsoft Internet Explorer to run System Display and Element Display

Before you can run the System Display and Element Display client applications in Microsoft Internet Explorer, you have to configure a number of settings.

##### Adding the System Display and Element Display URLs to the “Local intranet” zone

1. In Microsoft Internet Explorer, choose *Tools \> Internet Options*.

2. In the *Security* tab, select the *Local intranet* zone and click *Sites*.

3. In the *Local intranet* dialog box, click *Advanced*.

4. Enter the URL in the *Add this website to the zone* box, click *Add* and then click *Close*.

##### Configuring the ActiveX settings in Microsoft Internet Explorer

If you want to run the System Display and Element Display client applications in your Microsoft Internet Explorer, the latter should be allowed to run ActiveX controls.

1. In Microsoft Internet Explorer, choose *Tools \> Internet Options*.

2. In the *Security* tab, select the appropriate zone and click *Custom level...*

3. In the *Security Settings* dialog box, go to *ActiveX controls and plug-ins*.

4. Set *Download unsigned ActiveX controls* to “Prompt” and *Run ActiveX controls* to “Enable”.

> [!NOTE]
> You can also choose to install the Skyline certificates from http://\[DMA\]/tools and use the *Download signed ActiveX controls* setting instead.

##### Enabling active scripting in Microsoft Internet Explorer

In order to use spectrum elements in Element Display, you need to make sure active scripting is enabled:

1. In Microsoft Internet Explorer, choose *Tools \> Internet Options*.

2. In the *Security* tab, select the appropriate zone and click *Custom level...*

3. In the *Security Settings* dialog box, go to *Scripting*.

4. Set *Active scripting* to “Enable”.

##### Configuring the proxy settings in Microsoft Internet Explorer

If, by default, your Microsoft Internet Explorer uses a proxy server, you might be unable to connect to the DataMiner Agents in your DMS. In that case, add the IP addresses of the DataMiner Agents to the Exceptions list of your proxy server. This will force Microsoft Internet Explorer to bypass the proxy server when connecting to a DataMiner Agent.

1. In Microsoft Internet Explorer, choose *Tools \> Internet Options*.

2. In the *Connections* tab, click *LAN settings*.

3. In the *Local Area Network (LAN) Settings* dialog box, go to the *Proxy server* section and click *Advanced*.

4. In the *Proxy Settings* dialog box, go to the *Exceptions* section and add the IP addresses of your DataMiner Agents to the list. Separate the addresses by means of semicolons (”;”).

#### Uninstalling the ActiveX controls

Both System Display and Element Display are ActiveX controls, so they are installed as Microsoft Internet Explorer add-ons.

You can either uninstall them in the Internet Explorer *Manage Add-ons* window, or with a dedicated Skyline tool.

##### Uninstalling an ActiveX control

1. In Microsoft Internet Explorer, choose *Tools \> Manage add-ons*.

2. In the left-hand pane of the *Manage Add-ons* window, set the *Show* selection box to “All add-ons”.

3. In the list of add-ons, go to the *Skyline Communications* section and select either “SLSystemDisplay Control” or “SLElementDisplay Control”.

4. In the bottom pane, click *More information*.

5. In the *More information* dialog box, click *Remove*.

> [!NOTE]
> If you fail to remove an ActiveX control, do the following:
> - Close all Microsoft Internet Explorer windows. Also check Task Manager to make sure all Microsoft Internet Explorer processes have been stopped.
> - Open a new Microsoft Internet Explorer window, but do not open System Display or Element Display.
> - Try again to remove the ActiveX control.

##### Uninstalling System Display and Element Display using a dedicated Skyline tool

1. Open Microsoft Internet Explorer and go to the following address: *http://\[DMA\]/Tools*

2. In the *DataMiner Tools* section, click *Clean CAB Files* and then click *Run*.

3. In the *Clean CAB Files* window, click *Go*.

> [!NOTE]
> In the above-mentioned address, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
>
