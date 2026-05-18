---
uid: Tutorial_DH_DOM_NetworkShare
---

# Configuring DOM attachments on a network share

This tutorial shows you how to configure a network share as a storage backend for DOM attachments in Document Hub. The configuration is performed directly in the Document Hub app's **Storage Backends** section.

> [!NOTE]
> DOM attachments can be stored on a network share without any IIS configuration. The only mandatory requirement is that the network share is reachable by the DataMiner System. All IIS-related steps are optional and only required if you want to visualize or download attachments via a web browser.

Expected duration: 15 minutes

## Prerequisites

- Document Hub app installed and accessible
- A network share accessible from all DataMiner Agents in the cluster
- Network credentials with read/write permissions to the share
- (Optional) IIS Web Server role installed on DMAs for browser-based file access

## Overview

The steps in this tutorial include:

- [Configuring DOM attachments on a network share](#configuring-dom-attachments-on-a-network-share)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Prepare the network share](#step-1-prepare-the-network-share)
  - [Step 2: Configure the network share in Document Hub](#step-2-configure-the-network-share-in-document-hub)
  - [Optional: Configure browser-based access](#optional-configure-browser-based-access)
    - [Create a local DataMiner user](#create-a-local-dataminer-user)
    - [Configure IIS permissions](#configure-iis-permissions)
    - [Create an IIS virtual directory](#create-an-iis-virtual-directory)
    - [Access attachments via browser](#access-attachments-via-browser)
  - [Next steps](#next-steps)

## Step 1: Prepare the network share

1. Verify that the network share is accessible from all DataMiner Agents in your cluster.

   Example network share location: `\\server\share`

1. Ensure that the share has appropriate read/write permissions configured.

1. Test connectivity from each DMA by accessing the share via Windows Explorer or command line:

   ```cmd
   dir \\server\share
   ```

   > [!NOTE]
   > If the share is not accessible, verify network connectivity, firewall rules, and share permissions.

## Step 2: Configure the network share in Document Hub

Configure the network share directly in the Document Hub app:

1. Open the **Document Hub** app in DataMiner.

1. Navigate to the **Storage Backends** section.

   > [!TIP]
   > The Storage Backends section is only visible to users with administrator permissions.

1. Click **Add Storage Backend** or **New Backend**.

1. Select **Network Share** or **File Share** as the backend type.

1. Fill in the configuration details:
   - **Name**: A friendly name for this backend (e.g., "DOM Attachments Share")
   - **UNC Path**: The network share path (e.g., `\\server\share`)
   - **Username**: The user account with access to the share (e.g., `domain\user1` or `user1`)
   - **Password**: The password for the user account
   - **Domain** (if applicable): The domain name

1. Click **Test Connection** to verify that DataMiner can access the network share.

   > [!NOTE]
   > If the test fails, verify that:
   > - The UNC path is correct
   > - The credentials have read/write permissions
   > - The share is accessible from all DMAs
   > - There are no firewall rules blocking access

1. Click **Save** to store the configuration.

1. The network share backend is now available for use with DOM attachments and document buckets.

> [!IMPORTANT]
> DataMiner will store and retrieve attachments directly from this network location. No IIS configuration is required for basic file storage and retrieval through the Document Hub app.

## Optional: Configure browser-based access

If you want users to visualize or download attachments via a web browser, follow these additional steps on each DataMiner Agent:

### Create a local DataMiner user

1. In DataMiner Cube, go to **System Center** > **Users / Groups**.

1. Create a local user with credentials matching the network share credentials:
   - **Username**: `user1` (matching the share account)
   - **Password**: Use the same password as the network share account

   > [!NOTE]
   > This user is required for IIS to impersonate when accessing the network share.

### Configure IIS permissions

1. On each DMA, open **Computer Management** (compmgmt.msc).

1. Navigate to **Local Users and Groups** > **Groups**.

1. Open the **IIS_IUSRS** group.

1. Click **Add** and add the DataMiner user created in the previous step (e.g., `user1`).

1. Click **OK** to save.

   > [!NOTE]
   > This allows IIS to impersonate the user when accessing the network share.

### Create an IIS virtual directory

1. Ensure the **IIS Web Server** role is installed on the DMA.

1. Open **IIS Manager** (inetmgr).

1. Expand the server node and navigate to the **Default Web Site**.

1. Right-click **Default Web Site** and select **Add Virtual Directory**.

1. Configure the virtual directory:
   - **Alias**: `shareRedirect` (or another name of your choice)
   - **Physical path**: `\\server\share` (the network share UNC path)

1. Click **OK**.

1. Select the newly created virtual directory in IIS Manager.

1. Double-click **Basic Settings** in the Actions pane.

1. Click **Connect as...** and configure the virtual directory to use the local DataMiner user credentials:
   - **User name**: `user1`
   - **Password**: The user's password

1. Click **OK** to save.

1. Click **Test Settings** to verify the configuration.

### Access attachments via browser

Once IIS is configured, attachments can be accessed via a web browser using the following URL format:

```
https://<dma-hostname>/shareRedirect/<filename>
```

Example: `https://dma.example.com/shareRedirect/document.pdf`

> [!TIP]
> The Document Hub app can automatically generate these URLs for DOM attachments when the IIS virtual directory is configured.

## Next steps

After configuring the network share backend, you can:

- Create document buckets that use this network share
- Configure DOM definitions to store attachments on this share
- Upload documents to the network share through the Document Hub app
- Link DOM attachments to jobs, assets, and other business entities

> [!TIP]
> For more information on creating and managing document buckets, see [Document Hub app](xref:DH_Application).
