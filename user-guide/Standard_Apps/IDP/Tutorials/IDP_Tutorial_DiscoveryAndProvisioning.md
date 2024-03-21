---
uid: IDP_Tutorial_DiscoveryAndProvisioning
keywords: idp tutorial, idp kata
---

# Getting started with IDP and onboarding new equipment

This tutorial will show you how to install IDP and onboard new equiment.

Expected duration: 20 minutes.

<!-- TODO: Uncomment and fill in with correct info when Kata is released.
> [!TIP]
> See also: [Kata #xx: IDP Introduction](https://community.dataminer.services/courses/kata-xx/)
-->

## Prerequisites

- A DataMiner System using DataMiner 10.3.0-CU0 or higher that is

  - [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
  - running on a Microsoft Windows server.

> [!IMPORTANT]
> If you are using a DataMiner version lower than 10.4.0 or 10.4.3, install the [IDP Migration](https://community.dataminer.services/download/idp-migration/) package first.

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy IDP from the Catalog](#step-1-deploy-idp-from-the-catalog)
- [Step 2: Configure discovery profile](#step-2-configure-discovery-profile)
- [Step 3: Configure scan range](#step-3-configure-scan-range)
- [Step 4: Run the discovery](#step-4-run-the-discovery)
- [Step 5: Provision the discovered element(s)](#step-5-provision-the-discovered-elements)

## Step 1: Deploy IDP from the Catalog

1. Go to [catalog.dataminer.services](https://catalog.dataminer.services).
1. Search for the [IDP package](https://catalog.dataminer.services/details/package/3163).
1. Deploy the package on your DataMiner system.
1. Go to your DataMiner system, you'll notice that IDP will be automatically installed and set up for you.

## Step 2: Configure discovery profile

Discovery profiles define which information and how it should be retrieved from the device. Some devices require authentication, which needs to be filled in upfront.

1. Go to the *DataMiner IDP* element.
1. Go to *Admin* > *Discovery*.
1. On the right, in the *Dicovery Profiles* table, select the row with the name `Default - Microsoft Platform`.
1. Click the *Edit* button.
1. Fill in the *Credentials* settings.

    - As this tutorial is done with a DaaS system, the default Admin user will be used.
    - **Username**: `Admin`
    - **Password**: `*****`

   ![Discovery Profile Wizard - Filled in credentials](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_DiscoveryProfile_0.png)

1. Click the *Save* button.

When selecting the row in the table, you see the following result:

![Discovery Profiles Table - Filled in credentials](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_DiscoveryProfile_1.png)

## Step 3: Configure scan range

1. On the left, select *Scan Ranges*.
1. On the right, click the *New* button.

    You now see the following screen:

   ![Scan Range Wizard - Start](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_0.png)

    Fill in the fields:

      - **Name**: `Local`
      - **IP Ranges**: `127.0.0.1` for both fields.

        - The IP Range will be the range that IDP will use to discover devices in.

   ![Scan Range Wizard - Filled in first screen](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_1.png)

1. Click the *Next* button.

    1. Select `CI Type` in the dropdown
    1. Select `Default - Microsoft Platform` as the selected CI Type.

   ![Scan Range Wizard - Filled in second screen](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_2.png)

1. Click the *Save* button.

When selecting the row in the table, you see the following result:

![Scan Ranges table - Row in table](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_3.png)

## Step 4: Run the discovery

1. Go to *Inventory* > *Discovered*.
1. At the top you'll find the *Actions* section.
1. Select the `Local` scan range in the dropdown.
1. Click on *Discover*.

The discovery will now run over the scan range and try to find devices that match with the CI Type that is configured in the scan range.

After a couple of seconds, you see a row appear in the *Discovered Elements* table at the bottom.

![Inventory > Discovered - Row in table](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_Discovery_0.png)

## Step 5: Provision the discovered element(s)

1. Select the row in the *Discovered Elements* table.
1. Click the *Provision* button.

Depending on which connectors are already on the system or if they have been set to production or not, different results will be shown.

- [Microsoft Platform connector is not available or is not set as production](#microsoft-platform-connector-is-not-available-or-is-not-set-as-production)
- [Microsoft Platform connector is available and set as production](#microsoft-platform-connector-is-available-and-set-as-production)

### Microsoft Platform connector is not available or is not set as production

![Provisioning popup - Missing version](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_Provisioning_MissingVersion.png)

#### Microsoft Platform connector is not available

1. Click the *Open Catalog* button.

   - If a popup appears that requires permission to open the link, click *Yes*.

1. On the Catalog page, go to *Versions*
1. Search for the latest version in the 1.1.3.x range (e.g.: 1.1.3.20)
1. Deploy that version to your DataMiner system.
1. Proceed with [Microsoft Plaform connector is not set as production](#microsoft-plaform-connector-is-not-set-as-production)

#### Microsoft Plaform connector is not set as production

1. On DataMiner, go to the [Protocols & Templates](xref:protocols) module.
1. [Set the version to production](xref:Promoting_a_protocol_version_to_production_version).
1. Go back to the popup and click *Refresh*.

    - In case the script timed out, you can click the *Provision* button again.

1. Proceed with [Microsoft Platform connector is available and set as production](#microsoft-platform-connector-is-available-and-set-as-production)

### Microsoft Platform connector is available and set as production

![Provisioning popup - Success](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_Provisioning_Success.png)

1. Click *Provision*.
1. Click *Finish*.
1. After a few seconds, you'll see a new element being created in the surveyor.
1. Go to *Inventory* > *Managed*.

In the *Managed Elements* table you can see that a new row has been added with the information of the newly created element. If you go to the element, you'll see the parameters being filled in as the data is being polled from your local system.

Congratulations, you have provisioned your first element with IDP!

> [!NOTE]
> To be granted DevOps points, take a screenshot of the newly created element and the *Managed Elements* table and either send it to [thunder@skyline.be](mailto:thunder@skyline.be) or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).
