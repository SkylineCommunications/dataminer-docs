---
uid: Installing_Asset_Management
---

# Installing the Asset Management application

## Prerequisites

- DataMiner version 10.3.11 or higher.

  > [!IMPORTANT]
  > The DataMiner Asset Management application was tested to be compatible with DataMiner versions 10.3.11 and higher. We do not recommend using an older version as this may lead to unexpected issues.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the Asset Management app

1. Look up the [*Asset Management Application* package](https://catalog.dataminer.services/details/package/5159) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

1. Go to `http(s)://[DMA name]/root` and select *Asset Management* to start using the application.

   ![Asset Management](~/user-guide/images/Asset_Management_Icon.png)

## Setting up the application

### Modifying the asset URLs

To gain access to the [asset detail reports](xref:Working_with_Asset_Management#asset-detail-reports), you first need to modify the asset URLs to use your personal system instead of the `slc-h79-g04.skyline.local` system.

To adapt the URL to your personal system:

1. Click the hamburger button in the top-left corner to fully expand the sidebar.

1. Select *QR code*.

   A page with a table component listing all asset URLs is displayed.

   ![Asset Management](~/user-guide/images/Asset_Management_url_Overview.png)<br/>*DataMiner Low-Code Apps in DataMiner 10.4.3*

1. In edit mode, navigate to *Data > Queries > Assets all* in the configuration pane to the right.

1. Click the pencil icon next to *Assets all* to edit the query.

1. Scroll down until you reach the *Concatenate* method used to specify the URL in the query.

   ![Asset Management](~/user-guide/images/Asset_Management_url.png)<br/>*DataMiner Low-Code Apps in DataMiner 10.4.3*

1. Select the information specified below *Concatenate*, and replace `slc-h79-g04.skyline.local` with your own DMA in the *Format* field.

   ![Asset Management](~/user-guide/images/Asset_Management_Change_url.png)

1. Click the pencil icon again to stop editing the query.

The table component now displays the updated URLs.

### Configuring the 'import new assets' button

Before the *Import new assets from Excel* button on the [*Complete assets overview* page](xref:Working_with_Asset_Management#the-complete-assets-overview-page) button is functional, you need to configure an on-click action.

1. Click the hamburger button in the top-left corner to fully expand the sidebar.

1. Select *Complete assets overview*.

1. In edit mode, select the button component and navigate to the *Settings* tab in the configuration pane to the right.

1. In the *General* section, click the *Configure actions* button next to *On click (1 action*).

1. In the pop-up window, click the sideward arrow to expand the *Launch 'Automation script'* configuration.

1. Select *IngestInstances* from the dropdown list in the *Filter* box.

1. Select *Ok* in the lower right corner.
