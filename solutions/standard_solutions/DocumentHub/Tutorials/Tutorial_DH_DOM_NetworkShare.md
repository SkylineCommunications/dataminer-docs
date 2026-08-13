---
uid: Tutorial_DH_DOM_NetworkShare
---

# Configuring DOM attachments on a network share

This tutorial shows you how to configure a network share as a storage backend for DOM attachments in DocumentHub.

Expected duration: 15 minutes

## Prerequisites

- Access to the DocumentHub app on a DataMiner Agent.
- A network share accessible from all DataMiner Agents in the cluster.
- Network credentials with read/write permissions to the share.
- IIS Web Server role installed on DMAs for browser-based file access (optional).

> [!NOTE]
> DOM attachments can be stored on a network share without any IIS configuration. The only mandatory requirement is that the network share is reachable by the DataMiner System. The [IIS-related steps](#step-3-configure-browser-based-access-optional) are optional and only required if you want to visualize or download attachments via a web browser.

## Overview

- [Step 1: Prepare the network share](#step-1-prepare-the-network-share)
- [Step 2: Configure the network share in DocumentHub](#step-2-configure-the-network-share-in-documenthub)
- [Step 3: Configure browser-based access (optional)](#step-3-configure-browser-based-access-optional)
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

## Step 2: Configure the network share in DocumentHub

Configure the network share directly in the DocumentHub app:

1. Open the **DocumentHub** app in DataMiner.

1. Navigate to the **Settings** > **DOM** page.

   > [!NOTE]
   > This page is only available for users with administrator permissions.

1. Click **Add Source**.

1. Fill in the configuration details:

   - **Name**: A friendly name for this backend (e.g., "DOM Attachments Share").
   - **Module**: The DOM module for which attachments will be stored on the network share.
   - **Network Share Path**: The UNC path of the network share (e.g., `\\server\share`).
   - **Username**: The user account with access to the share (e.g., `domain\user1` or `user1`).
   - **Password**: The password for the user account.

1. Click **Test** to verify that DataMiner can access the network share.

   > [!NOTE]
   > If the test fails, verify the following things:
   >
   > - The UNC path is correct.
   > - The credentials have read/write permissions.
   > - The share is accessible from all DMAs.
   > - There are no firewall rules blocking access.

1. When the test succeeds, click **Save** to store the configuration.

The network share backend is now available for use with DOM attachments and document buckets.

> [!NOTE]
> DataMiner will store and retrieve attachments directly from this network location. No IIS configuration is required for basic file storage and retrieval through the DocumentHub app.

## Step 3: Configure browser-based access (optional)

If you want users to be able to visualize or download attachments via a web browser, follow these additional steps:

1. Create a local DataMiner user:

   1. In DataMiner Cube, go to **System Center** > **Users / Groups**.

   1. Create a local user with credentials matching the network share credentials:

      - **Username**: `user1` (matching the share account)
      - **Password**: Use the same password as the network share account

      > [!NOTE]
      > This user is required for IIS to impersonate when accessing the network share.

1. Configure IIS permissions on each DMA in the cluster:

   1. On each DMA, open **Computer Management** (compmgmt.msc).

   1. Navigate to **Local Users and Groups** > **Groups**.

   1. Open the **IIS_IUSRS** group.

   1. Click **Add** and add the DataMiner user created in the previous step (e.g., `user1`).

   1. Click **OK** to save.

      > [!NOTE]
      > This allows IIS to impersonate the user when accessing the network share.

1. Create an IIS virtual directory on each DMA:

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

1. Use the following URL format to access attachments via a web browser:

   `https://<dma-hostname>/shareRedirect/<filename>`

   Example: `https://dma.example.com/shareRedirect/document.pdf`

   > [!TIP]
   > The DocumentHub app can automatically generate these URLs for DOM attachments when the IIS virtual directory is configured.

## Next steps

After configuring the network share backend, you can:

- [Create document buckets](xref:DH_Application#organizing-with-buckets) that use this network share.
- [Upload documents](xref:DH_Application#uploading-documents) to the network share through the DocumentHub app.
- Configure DOM definitions to store attachments on this share.
- Link DOM attachments to jobs, assets, and other business entities.

> [!TIP]
> For more information on how to work with DataMiner Object Models (DOM), refer to [DataMiner Object Models (DOM)](xref:DOM).
