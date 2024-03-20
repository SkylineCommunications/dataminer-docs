---
uid: IDP_Tutorial_Introduction
keywords: idp tutorial, idp kata
---

# Setting up IDP and run the first discovery

This tutorial will show you how to start with IDP.

Expected duration: XX minutes.

<!-- TODO: Uncomment and fill in with correct info when Kata is released.
> [!TIP]
> See also: [Kata #xx: IDP Introduction](https://community.dataminer.services/courses/kata-xx/)
-->

## Prerequisites

- A DataMiner System using DataMiner 10.3.0-CU0 or higher that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

  - If you are using a DataMiner version lower than 10.4.0 or 10.4.3, install the [IDP Migration](https://community.dataminer.services/download/idp-migration/) package.

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy IDP from the Catalog](#step-1-deploy-idp-from-the-catalog)
- [Step 2: Configure discovery profile](#step-2-configure-discovery-profile)
- [Step 3: Configure scan range](#step-3-configure-scan-range)

## Step 1: Deploy IDP from the Catalog

Go to [catalog.dataminer.services](https://catalog.dataminer.services) and deploy the [IDP package](https://catalog.dataminer.services/details/package/3163).

You'll notice that IDP will be automatically installed for you.

## Step 2: Configure discovery profile

Discovery profiles define which information and how it should be retrieved from the device. Some devices require authentication, which needs to be filled in upfront.

1. Go to the *DataMiner IDP* element.
1. Go to *Admin* > *Discovery*.
1. In the *Dicovery Profiles* table, select the row with the name `Default - Microsoft Platform`.
1. Click the *Edit* button.
1. Fill in the *Credentials* settings and save profile.

## Step 3: Configure scan range

1. Go to the *DataMiner IDP* element.
1. Go to *Admin* > *Discovery*.
1. Select the *Scan Ranges* tab on the left.
1. Click the *New* button above the *Discovery Address Range* table.
1. 

Create scan range for 127.0.0.1 and add CI type of microsoft platform

## Step 4: Run the discovery



## Step 5: Provision the discovered element(s)

Oh, popup with missing protocol version
Deploy from catalog if missing on system
and/or set to production

## Step 6: profit! 