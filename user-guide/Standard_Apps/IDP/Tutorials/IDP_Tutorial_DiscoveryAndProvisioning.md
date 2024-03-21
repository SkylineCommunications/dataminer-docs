---
uid: IDP_Tutorial_DiscoveryAndProvisioning
keywords: idp tutorial, idp kata
---

# Getting started with IDP and onboarding new equipment

This tutorial will show you how to install IDP and onboard new equiment. 

Expected duration: XX minutes.

<!-- TODO: Uncomment and fill in with correct info when Kata is released.
> [!TIP]
> See also: [Kata #xx: IDP Introduction](https://community.dataminer.services/courses/kata-xx/)
-->

## Prerequisites

- A DataMiner System using DataMiner 10.3.0-CU0 or higher that is

  - [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
  - running on a Microsoft server.

> [!IMPORTANT]
> If you are using a DataMiner version lower than 10.4.0 or 10.4.3, install the [IDP Migration](https://community.dataminer.services/download/idp-migration/) package first.

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy IDP from the Catalog](#step-1-deploy-idp-from-the-catalog)
- [Step 2: Configure discovery profile](#step-2-configure-discovery-profile)
- [Step 3: Configure scan range](#step-3-configure-scan-range)

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

![Discovery Profiles Table - Filled in credentials](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_DiscoveryProfile_1.png)

## Step 3: Configure scan range

1. On the left, select *Scan Ranges*.
1. On the right, click the *New* button.

    You should now see the following screen:

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

When selecting the row in the table, you should see the following result:

![Scan Ranges table - Row in table](~/user-guide/images/IDP_Tutorial_DiscoveryAndProvisioning_ScanRange_3.png)

## Step 4: Run the discovery



## Step 5: Provision the discovered element(s)

Oh, popup with missing protocol version
Deploy from catalog if missing on system
and/or set to production

## Step 6: profit! 