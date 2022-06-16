---
uid: Configuring_Internet_Explorer_to_run_DataMiner_Cube
---

<!-- To be replaced with Configuring_Microsoft_edge_to_run_Cube -->

# ConfiguringInternet Explorer  to run DataMiner Cube

Before you can run the DataMiner Cube browser application in Microsoft Internet Explorer, a number of settings must be configured.

## Adding the DataMiner Cube URL to the “Local intranet” zone

1. In Microsoft Internet Explorer, select *Tools \> Internet Options*.

1. In the *Security* tab, select the *Local intranet* zone and click *Sites*.

1. In the *Local intranet* dialog box, click *Advanced*.

1. Enter the URL in the *Add this website to the zone* box, click *Add* and then click *Close*.

## Configuring the XBAP settings in Microsoft Internet Explorer

If you want to run the DataMiner Cube client application in Microsoft Internet Explorer, the latter should be allowed to run XAML browser applications.

1. In Microsoft Internet Explorer, select *Tools \> Internet Options*.

1. In the *Security* tab, select the appropriate zone and click *Custom level...*

1. In the *Security Settings* dialog box, go to *.NET Framework*.

1. Set *XAML browser applications* to “Enable”.

## If you plan to use Microsoft Internet Explorer 64-bit edition

If you intend to run DataMiner Cube in the 64-bit version of Microsoft Internet Explorer, do the following.

1. Open the 64-bit version of Microsoft Internet Explorer.

1. Go to the following address: ``http://\[DMA\]/DataminerCubeStandAlone/Publish.htm``, replacing “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.
