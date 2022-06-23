---
uid: Configuring_Microsoft_edge_to_run_Cube
---

# Configuring Microsoft Edge to run DataMiner Cube

Before you can run the DataMiner Cube browser application in Microsoft Edge, a number of settings must be configured.

1. Activate IE compatibility mode for the DataMiner Cube page:

   1. In Microsoft Edge, click the ... button in the top-right corner and select *Settings*.

   1. In the pane on the left, select *Default browser*.

   1. Set *Allow sites to be reloaded in Internet Explorer mode* to *Allow*.

   1. Next to *Internet Explorer mode pages*, click *Add*.

   1. In the dialog, specify the URL to open DataMiner Cube for your DMA, e.g. `https://MyDMA/`.

1. Add the DataMiner Cube URL to the "Local intranet" zone:

   1. In the Windows Control Panel, select *Network and Internet*.

   1. Click *Internet Options*.

   1. In the *Security* tab, select *Trusted sites* and click the *Sites* button.

   1. Enter the URL in the *Add this website to the zone* box, click *Add* and then click *Close*.

1. Configure the XBAP settings:

   1. In the Windows Control Panel, select *Network and Internet*.

   1. Click *Internet Options*.

   1. In the *Security* tab, select *Trusted sites*.

   1. Click the *Custom level* button.

   1. In the *Security Settings* dialog box, go to *.NET Framework*.

   1. Set *XAML browser applications* to *Enable*.

> [!NOTE]
>
> - To open DataMiner Cube, browse directly to the DMA IP or URL (e.g. `https://MyDMA/` instead of `https://MyDMA/DataMinerCube`). This way Edge can reload the page correctly in Internet Explorer. Note that this does mean that `C:\Skyline DataMiner\WebPages\config.manual.asp` must be configured with *defaultApp* set to *Cube* or an empty value. See [Configuring the landing page of a DMA](xref:Configuring_the_landing_page).
> - It is possible that your Edge policies are in fact managed by your company. In that case, you may not be able to configure this yourself, and you will need to contact your IT administrator for this. You can verify if this is the case by browsing to <edge://policy/> in Microsoft Edge. If this page contains an item "InternetExplorerIntegrationSiteList", IE compatibility is configured at company level.

> [!TIP]
> See also: [Internet Explorer Support](https://community.dataminer.services/documentation/internet-explorer-support/)
