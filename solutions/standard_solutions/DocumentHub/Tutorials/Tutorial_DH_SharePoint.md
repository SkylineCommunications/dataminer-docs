---
uid: Tutorial_DH_SharePoint
---

# Configuring SharePoint as a storage backend

This tutorial shows you how to configure SharePoint as a storage backend for DocumentHub. The configuration is performed directly in the DocumentHub app's **Storage Backends** section.

> [!NOTE]
> This tutorial uses SharePoint with Azure AD (Microsoft Entra ID) authentication. You will need administrative access to Azure Portal to complete the setup.

Expected duration: 15 minutes

## Prerequisites

- DocumentHub app installed and accessible
- Access to Azure Portal with permissions to register applications
- SharePoint site with appropriate permissions

## Overview

- [Step 1: Register your app in Azure AD](#step-1-register-your-app-in-azure-ad)
- [Step 2: Generate a client secret](#step-2-generate-a-client-secret)
- [Step 3: Configure API permissions](#step-3-configure-api-permissions)
- [Step 4: Configure SharePoint in DocumentHub](#step-4-configure-sharepoint-in-documenthub)
- [Next steps](#next-steps)

## Step 1: Register your app in Azure AD

1. Navigate to [Azure Portal](https://portal.azure.com) and sign in.

1. Go to **Microsoft Entra ID** > **App Registrations**.

1. Click **New Registration** and provide a descriptive name (e.g., "DataMiner DocumentHub").

1. Set the redirect URI to your DataMiner application domain.

1. Click **Register**.

1. Note down the following values (you will need them later):
   - **Application (client) ID**
   - **Directory (tenant) ID**

## Step 2: Generate a client secret

1. In your app registration, navigate to **Certificates & Secrets** in the left menu.

1. Click **New client secret**.

1. Provide a description and select an expiration period.

1. Click **Add**.

1. **Important**: Copy the client secret value immediately. It will not be shown again.

   > [!WARNING]
   > Store the client secret securely. You will need it when configuring DocumentHub.

## Step 3: Configure API permissions

1. In your app registration, go to **API permissions**.

1. Click **Add a permission**.

1. Select **Microsoft Graph**.

1. Choose **Application permissions**.

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

1. Open the **DocumentHub** app in DataMiner.

1. Navigate to the **Storage Backends** section.

   > [!TIP]
   > The Storage Backends section is only visible to users with administrator permissions.

1. Click **Add Storage Backend** or **New Backend**.

1. Select **SharePoint** as the backend type.

1. Fill in the configuration details:
   - **Name**: A friendly name for this backend (e.g., "Corporate SharePoint")
   - **Tenant ID**: The Directory (tenant) ID from Step 1
   - **Client ID**: The Application (client) ID from Step 1
   - **Client Secret**: The client secret value from Step 2
   - **Site URL**: Your SharePoint site URL (e.g., `https://yourtenant.sharepoint.com/sites/yoursite`)
   - **Document Library**: The name of the document library to use (e.g., "Documents")

1. Click **Test Connection** to verify the configuration.

   > [!NOTE]
   > If the test fails, verify that:
   > - The credentials are correct
   > - API permissions have been granted
   > - The SharePoint site URL is accessible
   > - The document library exists

1. Click **Save** to store the configuration.

1. The SharePoint backend is now available for use in document buckets.

## Next steps

After configuring SharePoint, you can:

- Create document buckets that use this SharePoint backend
- Configure metadata templates for SharePoint-stored documents
- Upload documents to SharePoint through the DocumentHub app
- Integrate SharePoint storage with other DataMiner applications

> [!TIP]
> For more information on creating and managing document buckets, see [DocumentHub app](xref:DH_Application).
