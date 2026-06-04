---
uid: Tutorial_DH_SharePoint
---

# Configuring SharePoint as a storage backend

This tutorial shows you how to configure SharePoint as a storage backend for DocumentHub.

The tutorial uses SharePoint with **Azure AD** (Microsoft Entra ID) authentication. You will need administrative access to the Azure Portal to complete the setup.

Expected duration: 15 minutes

## Prerequisites

- Access to the DocumentHub app on a DataMiner Agent.
- Access to Azure Portal with permissions to register applications.
- SharePoint site with appropriate permissions.

## Overview

- [Step 1: Register your app in Azure AD](#step-1-register-your-app-in-azure-ad)
- [Step 2: Generate a client secret](#step-2-generate-a-client-secret)
- [Step 3: Configure API permissions](#step-3-configure-api-permissions)
- [Step 4: Configure SharePoint in DocumentHub](#step-4-configure-sharepoint-in-documenthub)
- [Next steps](#next-steps)

## Step 1: Register your app in Azure AD

1. Navigate to [Azure Portal](https://portal.azure.com) and sign in.

1. Go to **Microsoft Entra ID** > **App registrations**.

1. Click **New registration** and provide a descriptive name (e.g., "DataMiner DocumentHub").

1. Set the redirect URI to your DataMiner application domain.

1. Click **Register**.

1. Note down the following values (you will need them later):

   - The **Application (client) ID**.
   - The **Directory (tenant) ID**.

## Step 2: Generate a client secret

1. In your app registration, navigate to **Certificates & secrets** in the pane on the let.

1. Under *Client secrets*, click **New client secret**.

1. Provide a description and select an expiration period.

1. Click **Add**.

1. Copy the client secret value.

   It is important that you do this immediately, as the secret **will not be shown again**.

   > [!IMPORTANT]
   > Store the client secret securely. You will need it when configuring DocumentHub.

## Step 3: Configure API permissions

1. In your app registration, go to **API permissions**.

1. Click **Add a permission**.

1. Select **Microsoft Graph**.

1. Select **Application permissions**.

1. Add the following permissions:

   - **Sites.ReadWrite.All**: Allows the app to read and write items in all site collections.
   - **Files.ReadWrite.All**: Allows the app to read and write files in all site collections.

1. Click **Add permissions**.

1. Click **Grant admin consent** for your organization.

   > [!NOTE]
   > You must have administrator privileges to grant consent.

1. Confirm that the permissions show "Granted" status.

## Step 4: Configure SharePoint in DocumentHub

Now that you have completed the Azure AD setup, configure SharePoint in the DocumentHub app:

1. Open the **DocumentHub** app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. Navigate to the **Settings** > **SharePoint** page.

   > [!NOTE]
   > This page is only available for users with administrator permissions.

1. Click **Add Source**.

1. Fill in the configuration details:

   - **SharePoint Source Name**: A friendly name for this backend (e.g., "Corporate SharePoint").
   - **Document Library Name**: The name of the document library to use (e.g., "Documents").
   - **Tenant ID**: The Directory (tenant) ID from [step 1](#step-1-register-your-app-in-azure-ad).
   - **Client ID**: The Application (client) ID from [step 1](#step-1-register-your-app-in-azure-ad).
   - **Client Secret**: The client secret value from [step 2](#step-2-generate-a-client-secret).
   - **Site URL**: Your SharePoint site URL (e.g., `https://yourtenant.sharepoint.com/sites/yoursite`).

1. Click **Test Connection** to verify the configuration.

   > [!NOTE]
   > If the test fails, verify the following things:
   >
   > - The credentials are correct.
   > - API permissions have been granted.
   > - The SharePoint site URL is accessible.
   > - The document library exists.

1. When the test succeeds, click **Save** to store the configuration.

The SharePoint backend is now available for use in document buckets.

## Next steps

After configuring SharePoint, you can:

- [Create document buckets](xref:DH_Application#organizing-with-buckets) that use this SharePoint backend.
- [Upload documents](xref:DH_Application#uploading-documents) to SharePoint through the DocumentHub app.
- Configure metadata templates for SharePoint-stored documents.
- Integrate SharePoint storage with other DataMiner applications via DocumentHub.
