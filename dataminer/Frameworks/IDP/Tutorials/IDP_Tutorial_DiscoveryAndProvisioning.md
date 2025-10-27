---
uid: IDP_Tutorial_DiscoveryAndProvisioning
keywords: idp tutorial, idp kata
---

# Getting started with IDP and onboarding new equipment

This tutorial will show you how to install IDP and onboard new equipment. By way of example, the Microsoft server running DataMiner will be onboarded, as this is easily accessible equipment.

Expected duration: 15 minutes.

> [!NOTE]
> The content and screenshots for this tutorial were created using IDP version 1.5.0.

> [!TIP]
> See also: [Kata #25: Getting started with IDP and onboarding new equipment](https://community.dataminer.services/courses/kata-25/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

The DataMiner System used for this tutorial has to meet the following requirements:

- DataMiner is installed on a machine running a Windows Server version (e.g. Windows Server 2022).
- The DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- The DataMiner version is 10.3.0 [CU0] or higher.

> [!IMPORTANT]
> If you are using a DataMiner version lower than 10.4.0 or 10.4.3, install the [IDP Migration](https://community.dataminer.services/download/idp-migration/) package before you start the tutorial.

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy IDP from the Catalog](#step-1-deploy-idp-from-the-catalog)
- [Step 2: Configure the scan range](#step-2-configure-the-scan-range)
- [Step 3: Run the discovery](#step-3-run-the-discovery)
- [Step 4: Provision the discovered element(s)](#step-4-provision-the-discovered-elements)

## Step 1: Deploy IDP from the Catalog

1. [Deploy the IDP package from the Catalog](xref:Installing_DataMiner_IDP#deploying-the-idp-package).

1. Connect to your DataMiner System in DataMiner Cube.

You will notice that IDP will be automatically installed and set up for you.

## Step 2: Configure the scan range

1. Open the IDP app.

1. Go to *Admin* > *Discovery*.

1. Select *Scan Ranges* on the left.

1. Click the *New* button.

   This will open the following window:

   ![Scan Range wizard - Start](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_0.png)

1. In the *Name* field, specify `Local`.

1. In both *IP Ranges* fields, fill in `127.0.0.1`.

   ![Scan Range wizard - First step](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_1.png)

   The range you have specified is the IP range IDP will use to discover devices in.

1. Click *Next*.

1. In the *Discover Devices by* box, select *CI Type*.

1. Under *Selected CI Types*, select *Default - Microsoft Platform*.

   ![Scan Range wizard - Second step](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_2.png)

1. Click *Save*.

When you select the row in the table now, you will see the following result:

![Scan range configuration result](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_3.png)

## Step 3: Run the discovery

1. Go to *Inventory* > *Discovered*.

1. In the *Actions* section at the top, select the *Local* scan range in the dropdown box.

1. Click the *Discover* button.

IDP will now check the scan range to try to discover devices that match the CI Type configured for this scan range.

After a couple of seconds, a row will be added in the *Discovered Elements* table at the bottom of the page:

![Discovery result](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_Discovery_0.png)

## Step 4: Provision the discovered element(s)

1. Select the row in the *Discovered Elements* table.

1. Click the *Provision* button.

Depending on whether the Microsoft Platform connector is already in the system and whether it already has a version set to production, different results can be shown:

- [Microsoft Platform connector is not available or is not set as production](#microsoft-platform-connector-is-not-available-or-is-not-set-as-production)
- [Microsoft Platform connector is available and set as production](#microsoft-platform-connector-is-available-and-set-as-production)

### Microsoft Platform connector is not available or is not set as production

If the Microsoft Platform connector is not available in the system yet, or if no production version has been set, you will see this window:

![Pop-up window when version is missing](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_Provisioning_MissingVersion.png)

Proceed as follows:

1. In the Cube apps pane in the sidebar, select *Protocols & Templates*.

1. In the *Protocols & service protocols* column of the Protocols & Templates module, check whether *Microsoft Platform* is listed.

1. If it is **not** listed:

   1. In the IDP pop-up window displayed above, click *Open Catalog*.

   1. If you are asked for permission to open the link, click *Yes*.

   1. On the Catalog page, go to *Versions*.

   1. Look up the latest version in the 1.1.3.x range (e.g. 1.1.3.20).

   1. Click *Deploy* to deploy that version to your DataMiner System.

1. If *Microsoft Platform* is listed, or if you have just added it as detailed above:

   1. In the Protocols & Templates module, look up the above-mentioned version in the *Versions* column.

   1. Right-click the version and select *Set as production*.

   1. Go back to the IDP pop-up window and click *Refresh*.

      > [!NOTE]
      > In case the script has timed out, you can click the *Provision* button again.

1. Continue in the same way as detailed below for [Microsoft Platform connector is available and set as production](#microsoft-platform-connector-is-available-and-set-as-production).

### Microsoft Platform connector is available and set as production

If the Microsoft Platform is available and a production version has been set, you will see this window:

![Pop-up window when version is found](~/dataminer/images/IDP_Tutorial_DiscoveryAndProvisioning_Provisioning_Success.png)

Proceed as follows:

1. Click *Provision*.

1. Click *Finish*.

   After a few seconds, you will see that a new element is being added in the Surveyor.

1. To check the result in the IDP app, go to *Inventory* > *Managed*.

   In the *Managed Elements* table, you will see that a new row has been added with the information of the newly created element.

1. Select the new element in the Surveyor.

   You will see the parameter values getting filled in as data is being polled from your system.

Congratulations, you have provisioned your first element with IDP!

> [!NOTE]
> To be granted DevOps Points for taking this tutorial, take a screenshot of the newly created element and the *Managed Elements* table and either send it to [thunder@skyline.be](mailto:thunder@skyline.be) or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).
