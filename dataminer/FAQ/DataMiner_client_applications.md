---
uid: DataMiner_client_applications
---

# Frequently asked questions about DataMiner client applications

- [How do I send info about my DataMiner client to Technical Support?](#how-do-i-send-info-about-my-dataminer-client-to-technical-support)

- [How do I reinstall the DataMiner Cube browser app?](#how-do-i-reinstall-the-dataminer-cube-browser-app)

- [What should I do if I cannot connect to a DMA using the DataMiner Cube browser app?](#what-should-i-do-if-i-cannot-connect-to-a-dma-using-the-dataminer-cube-browser-app)

- [Can I still use the DataMiner Cube browser app in Internet Explorer?](#can-i-still-use-the-dataminer-cube-browser-app-in-internet-explorer)

## How do I send info about my DataMiner client to Technical Support?

In case of problems, Technical Support may ask you to provide version information and/or debug information. Below, you can find how you can gather the requested information.

> [!TIP]
> See also: [Collecting data to report an issue to Technical Support](xref:Collecting_data_to_report_an_issue_to_TechSupport)

### Sending version information to Technical Support

1. In DataMiner Cube, go to *Apps* > *About*.

1. In the *About* box, click the *Versions* tab.

1. At the bottom of the dialog box, click *Copy Versions Information*.

1. Paste the text in a new email message, and send the information to [support@dataminer.services](mailto:support@dataminer.services).

### Sending debug information to Technical Support

1. In DataMiner Cube, go to *Apps* > *About* (in the *General* section).

1. At the bottom of the *About* box, click *Email Debug Information*.

   A new email message containing the debug information will open.

   > [!NOTE]
   > You may get a warning, saying that an application (DataMiner Cube) is trying to send an email message from your computer.

1. Send the information to [support@dataminer.services](mailto:support@dataminer.services).

> [!TIP]
> See also: [Collecting data to report an issue to Technical Support](xref:Collecting_data_to_report_an_issue_to_TechSupport)

## How do I reinstall the DataMiner Cube browser app?

> [!IMPORTANT]
> As of DataMiner 10.3.x, the DataMiner Cube browser app is *End of Life*. Up to DataMiner 10.4.0 [CU11]/10.5.2, the application's existing features will continue to function, but no new features will be added. From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41873-->, the browser app is completely deprecated and can no longer be installed.

If the security policy of your company or computer allows it, the DataMiner Cube browser app is automatically downloaded and installed onto your computer the first time you try to open the user interface in Microsoft Edge in IE compatibility mode.

To reinstall the browser app, you need to clean the XBAP cache:

1. Browse to one of the following addresses:

   ```txt
   https://[DMA]/Tools
   http://[DMA]/Tools
   ```

1. Click *Clean DataMiner Cube XBAP Cache* and then click *Run*.

1. Open Microsoft Edge in IE compatibility mode and, depending on your setup, go to one of the following addresses:

   ```txt
   https://[DMA]/dataminercube
   http://[DMA]/dataminercube
   ```

> [!NOTE]
> In the above-mentioned addresses, replace “\[DMA\]” by the IP address or the hostname of the DataMiner Agent you want to connect to.

## What should I do if I cannot connect to a DMA using the DataMiner Cube browser app?

> [!IMPORTANT]
> As of DataMiner 10.3.x, the DataMiner Cube browser app is *End of Life*. Up to DataMiner 10.4.0 [CU11]/10.5.2, the application's existing features will continue to function, but no new features will be added. From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41873-->, the browser app is completely deprecated and can no longer be installed.

1. Check if Microsoft Edge has been correctly configured to run Cube for this DMA.

   See [Configuring Microsoft Edge to run DataMiner Cube](xref:Configuring_Microsoft_edge_to_run_Cube).

1. If Edge has been configured correctly, clear the XBAP cache:

   1. Go to *http(s)://**\[DMA IP or name\]**/tools*.

   1. Click *Clean Skyline DataMiner XBAP Cache*.

   1. Click *Run*.

1. If the problem persists, contact DataMiner Technical Support.

## Can I still use the DataMiner Cube browser app in Internet Explorer?

Support for the DataMiner Cube browser app has ended as of DataMiner 10.3 (see [Third-party software support lifecycle](xref:Software_support_life_cycles#third-party-software-support-lifecycle)).

For earlier DataMiner versions, we also recommend using the desktop application. See [Installing the DataMiner Cube desktop application](xref:Installing_the_DataMiner_Cube_desktop_application).

Though the browser app is still supported in older DataMiner versions, it should no longer be used in Internet Explorer, as Microsoft support for Internet Explorer ended in 2022 (see [Lifecycle FAQ - Internet Explorer and Microsoft Edge](https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge)). You can instead open the DataMiner Cube browser app in Microsoft Edge. See [Configuring Microsoft Edge to run DataMiner Cube](xref:Configuring_Microsoft_edge_to_run_Cube).
