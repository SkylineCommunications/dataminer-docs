---
uid: Tutorial_DH_UDAPI
description: Learn how to use the DocumentHub user-defined APIs to manage buckets and files, so you can integrate DocumentHub into your own solutions.
---

# Interacting with DocumentHub through user-defined APIs

This tutorial shows you how to use the DocumentHub [user-defined APIs](xref:UD_APIs) (UDAPIs) to manage buckets and files. You can use these APIs to integrate DocumentHub into your own applications, scripts, or automated workflows.

DocumentHub ships with the following user-defined APIs:

- **SLC-DH-UDAPI-ManageBuckets**: Allows you to list, create, update, and delete document buckets.
- **SLC-DH-UDAPI-ManageFiles**: Allows you to list, upload, and delete files inside a bucket.
- **SLC-DH-UDAPI-ManageDomSources**: Allows you to list, create, update, and delete DOM sources.
- **SLC-DH-UDAPI-ManageSharepointSources**: Allows you to list, create, update, and delete SharePoint configurations.
- **SLC-DH-UDAPI-Read-DomModules**: Allows you to list the DOM modules that are available on the DataMiner System.
- **SLC-DH-UDAPI-ReadDomDefinitions**: Allows you to list the DOM definitions of a given DOM source.
- **SLC-DH-UDAPI-DownloadFile**: Allows you to download a file from a bucket.
<!-- - **SLC-DH-UDAPI-GetAgentVersion**: Allows you to retrieve the DataMiner Agent version. -->

> [!NOTE]
> The public URL segment of each API (referred to as *route* in this tutorial) is defined by an operator in the *User-Defined APIs* module of DataMiner Cube. The routes used in this tutorial (e.g., `dhmanagebuckets`, `dhmanagefiles`) are only examples; the actual values may differ per DataMiner System. For the full source code of these scripts, go to the [DocumentHub Solution repository](https://github.com/SkylineCommunications/SLC-S-DocumentHub) on GitHub (look for projects starting with `SLC-DH-UDAPI-*`).

Expected duration: 20 minutes

## Prerequisites

- A DataMiner System with the DocumentHub solution installed.
- The DocumentHub user-defined APIs you want to use, configured and enabled in DataMiner Cube.
- A valid API token for authentication. For more information, go to [Triggering a user-defined API](xref:UD_APIs_Triggering_an_API).
- A tool to send HTTP requests, such as Postman.

## Overview

- [Interacting with DocumentHub through user-defined APIs](#interacting-with-documenthub-through-user-defined-apis)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Retrieve the buckets route and API token](#step-1-retrieve-the-buckets-route-and-api-token)
  - [Step 2: List the existing buckets](#step-2-list-the-existing-buckets)
  - [Step 3: Create a bucket](#step-3-create-a-bucket)
  - [Step 4: Verify that the bucket was created](#step-4-verify-that-the-bucket-was-created)
  - [Step 5: Delete the bucket](#step-5-delete-the-bucket)
  - [Handling unsupported methods](#handling-unsupported-methods)
  - [Managing files](#managing-files)
  - [Managing DOM sources](#managing-dom-sources)
  - [Managing SharePoint sources](#managing-sharepoint-sources)
  - [Listing DOM modules](#listing-dom-modules)
  - [Reading DOM definitions](#reading-dom-definitions)
  - [Downloading a file](#downloading-a-file)
  - [Next steps](#next-steps)

## Step 1: Retrieve the buckets route and API token

1. In DataMiner Cube, go to the *User-Defined APIs* module.

1. Locate the `SLC-DH-UDAPI-ManageBuckets` API and note its configured route.

   This tutorial assumes the default route `dhmanagebuckets`.

1. Note the API token that is required to authenticate requests to this API.

   You will pass this token as a `Bearer` value in the `Authorization` header of every request.

## Step 2: List the existing buckets

1. Send a `GET` request to `http(s)://{hostname}/api/custom/{bucketsRoute}`.

   Example: `https://myagent/api/custom/dhmanagebuckets`

1. In the request body, pass `*` as a wildcard filter.

   The wildcard is normalized to an empty filter internally, so the request returns every bucket that is currently configured.

   > [!NOTE]
   > Add an `Authorization: Bearer {token}` header to the request, using the token from [step 1](#step-1-retrieve-the-buckets-route-and-api-token).

1. Verify that the response contains an HTTP `200` status code and a JSON array of buckets.

## Step 3: Create a bucket

1. Send a `POST` request to the same URL as in [step 2](#step-2-list-the-existing-buckets).

1. In the request body, provide the bucket configuration as JSON, for example:

   ```json
   {
     "Identifier": "",
     "Name": "",
     "Description": "Created by UDAPI tutorial",
     "StorageType": "Local",
     "UploadPath": "documenthub/tutorial",
     "Extensions": "pdf,docx,txt",
     "SizeLimit": 10485760
   }
   ```

   This example uses `Local` as the storage type, so the bucket has no dependency on a DOM source or SharePoint configuration.

   > [!NOTE]
   > `SizeLimit` is expressed in bytes. The example value corresponds to 10 MB.

1. Verify that the response contains an HTTP `200` (or `201`) status code, confirming that the bucket was created.

## Step 4: Verify that the bucket was created

1. Send a `GET` request to the URL from [step 2](#step-2-list-the-existing-buckets), passing the bucket name or identifier as a filter in the request body.

1. Verify that the bucket you created in [step 3](#step-3-create-a-bucket) is included in the response.

## Step 5: Delete the bucket

1. Send a `DELETE` request to the URL from [step 2](#step-2-list-the-existing-buckets), passing the identifier of the bucket you want to remove in the request body.

1. Verify that the response contains an HTTP `200` status code.

1. Optionally, repeat [step 2](#step-2-list-the-existing-buckets) to confirm that the bucket is no longer part of the list.

## Handling unsupported methods

Each DocumentHub UDAPI script only supports a specific set of HTTP methods. If you send a request using a method that is not supported (for example, `PATCH` on `SLC-DH-UDAPI-ManageBuckets`), the script's default branch returns an HTTP `400` status code with a message listing the supported methods.

> [!NOTE]
> Depending on how the user-defined API is configured in Cube, DataMiner Cube may reject the method before the script runs, in which case an HTTP `405` status code is returned instead. Both response codes indicate the same thing: the method you used is not supported.

## Managing files

Use the `SLC-DH-UDAPI-ManageFiles` API to list, upload, and delete files inside a bucket. This API follows the same authentication structure as `SLC-DH-UDAPI-ManageBuckets`, but is triggered through its own route (`dhmanagefiles` in this tutorial). It supports the `GET`, `POST`, and `DELETE` methods.

1. To list files, send a `GET` request. Optionally, provide a filter in the request body, for example:

   ```json
   {
     "bucketId": "",
     "filter": "",
     "storageType": "Local"
   }
   ```

   - Omit `bucketId` to search across all buckets.
   - `filter` matches against the file name or path.
   - `storageType` narrows the search to buckets of a given storage type (only applied when `bucketId` is not provided).

   The response contains, per bucket, the total number of matching files and their details (name, path, size, creation date, etc.).

1. To upload a file, send a `POST` request with the following body:

   ```json
   {
     "bucketId": "",
     "filePath": "C:\\Temp\\example.pdf",
     "name": ""
   }
   ```

   > [!NOTE]
   > `filePath` is a path on the DataMiner Agent that executes the script, not a path on your local machine. Make sure the file is present there before calling the API. `name` is optional; if omitted, the file name is derived from `filePath`. File names must be unique within a bucket.

1. To delete a file, send a `DELETE` request with the following body:

   ```json
   {
     "bucketId": "",
     "fileId": ""
   }
   ```

   `fileId` can be the file's raw reference, its file name, or its display name. Deleting files is currently only supported for buckets with storage type `Local`.

## Managing DOM sources

Use the `SLC-DH-UDAPI-ManageDomSources` API to list, create, update, and delete the DOM sources that DocumentHub uses to store DOM attachments on a network share. It supports the `GET`, `POST`, `PUT`, and `DELETE` methods.

1. To list DOM sources, send a `GET` request. Optionally, pass a text filter (matched against the name or module) in the request body, or `*` to return all DOM sources.

1. To create a DOM source, send a `POST` request with a body similar to:

   ```json
   {
     "Name": "",
     "Module": "",
     "NetworkSharePath": "\\\\server\\share",
     "username": "",
     "password": ""
   }
   ```

   `Module` must reference an existing, unused DOM module (see [Listing DOM modules](#listing-dom-modules)). `username` and `password` are the network credentials used to access the share, and are required when creating a DOM source.

1. To update a DOM source, send a `PUT` request with the same body as for creation, including the `Identifier` of the DOM source you want to update. `username` and `password` are optional; if omitted, the existing credential is kept.

1. To delete a DOM source, send a `DELETE` request with the DOM source name as the raw request body (as a JSON string, e.g., `"My DOM source"`).

   > [!NOTE]
   > A DOM source cannot be deleted while it is still linked to a bucket. Unlink it from any buckets first.

## Managing SharePoint sources

Use the `SLC-DH-UDAPI-ManageSharepointSources` API to list, create, update, and delete SharePoint configurations. It supports the `GET`, `POST`, `PUT`, and `DELETE` methods, following the same pattern as [Managing DOM sources](#managing-dom-sources).

1. To list SharePoint configurations, send a `GET` request. Optionally, pass a text filter (matched against the name, site URL, document library name, or status) in the request body, or `*` to return all configurations.

1. To create a SharePoint configuration, send a `POST` request with a body similar to:

   ```json
   {
     "Name": "",
     "SiteURL": "https://yourtenant.sharepoint.com/sites/yoursite",
     "DocumentLibraryName": "Documents",
     "TenantID": "",
     "ClientID": "",
     "ClientSecret": ""
   }
   ```

   `TenantID` and `ClientID` must be valid GUIDs. For more information about these values, go to [Configuring SharePoint as a storage backend](xref:Tutorial_DH_SharePoint).

1. To update a SharePoint configuration, send a `PUT` request with the same body as for creation, including the `Identifier` of the configuration you want to update.

1. To delete a SharePoint configuration, send a `DELETE` request with the configuration name as the raw request body.

   > [!NOTE]
   > A SharePoint configuration cannot be deleted while it is still linked to a bucket. Unlink it from any buckets first.

## Listing DOM modules

Use the `SLC-DH-UDAPI-Read-DomModules` API to list the DOM modules that are available on the DataMiner System. It only supports the `GET` method.

1. Send a `GET` request. Optionally, pass a text filter (matched against the module ID) in the request body, or `*` to return all modules.

1. Verify that the response contains a JSON array of modules, each indicating whether it is already in use by an existing DOM source (`InUse`).

   You need an unused module when [creating a DOM source](#managing-dom-sources), since each module can only be linked to one DOM source.

## Reading DOM definitions

Use the `SLC-DH-UDAPI-ReadDomDefinitions` API to list the DOM definitions of a given DOM source. It only supports the `GET` method.

1. Send a `GET` request with the identifier (GUID) of a DOM source as the raw request body.

   You can retrieve this identifier by [listing DOM sources](#managing-dom-sources).

1. Verify that the response contains a JSON array of DOM definitions, each with an `ID` and a `Name`.

## Downloading a file

Use the `SLC-DH-UDAPI-DownloadFile` API to download a file from a bucket to the DataMiner Agent that executes the script. It only supports the `POST` method.

1. Send a `POST` request with the following body:

   ```json
   {
     "BucketId": "",
     "FileName": ""
   }
   ```

   `FileName` is the storage-specific file name or path, as returned by [listing files](#managing-files).

1. Verify that the response contains an HTTP `200` status code and a JSON body similar to:

   ```json
   {
     "Success": true,
     "TempFilePath": "C:\\Skyline DataMiner\\Documents\\DocumentHub\\Temp\\{guid}_example.pdf"
   }
   ```

   > [!NOTE]
   > `TempFilePath` is a path on the DataMiner Agent, not on your local machine. The file is written to a fixed temporary folder (`C:\Skyline DataMiner\Documents\DocumentHub\Temp`) using a unique, generated file name.

<!--
## Retrieving the DataMiner Agent version

Use the `SLC-DH-UDAPI-GetAgentVersion` API to retrieve the installed version of the DocumentHub Assistant, as recorded in the Solution Registration DOM. It only supports the `GET` method and requires no request body.

1. Send a `GET` request.

1. Verify that the response contains an HTTP `200` status code and a JSON body similar to:

   ```json
   {
     "Success": true,
     "Solution": "DocumentHub.Assistant",
     "Version": "1.1.2"
   }
   ```

   If no Solution Registration entry is found, the API returns an HTTP `404` status code instead.

-->

## Next steps

- [User-defined APIs](xref:UD_APIs)
- [DocumentHub DevPack](xref:DH_Development)
- [DocumentHub app](xref:DH_Application)
