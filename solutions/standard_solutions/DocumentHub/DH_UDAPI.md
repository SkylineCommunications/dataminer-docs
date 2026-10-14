---
uid: DH_UDAPI
description: "Learn how to use DocumentHub user-defined APIs to manage buckets, files, DOM sources, SharePoint configurations, and more."
---

# DocumentHub user-defined APIs

DocumentHub ships with several [user-defined APIs](xref:UD_APIs), which you can use to integrate DocumentHub into your own applications, scripts, or automated workflows:

- **SLC-DH-UDAPI-ManageBuckets**: Allows you to [list, create, update, and delete document buckets](xref:Tutorial_DH_UDAPI).
- **SLC-DH-UDAPI-ManageFiles**: Allows you to [list, upload, and delete files inside a bucket](#managing-files).
- **SLC-DH-UDAPI-ManageDomSources**: Allows you to [list, create, update, and delete DOM sources](#managing-dom-sources).
- **SLC-DH-UDAPI-ManageSharepointSources**: Allows you to [list, create, update, and delete SharePoint configurations](#managing-sharepoint-sources).
- **SLC-DH-UDAPI-Read-DomModules**: Allows you to [list the DOM modules that are available on the DataMiner System](#listing-dom-modules).
- **SLC-DH-UDAPI-ReadDomDefinitions**: Allows you to [list the DOM definitions of a given DOM source](#reading-dom-definitions).
- **SLC-DH-UDAPI-DownloadFile**: Allows you to [download a file from a bucket](#downloading-a-file).
- **SLC-DH-UDAPI-GetAgentVersion**: Allows you to [retrieve the installed version of the DocumentHub Assistant](#retrieving-version-information). Note that this feature is currently still in preview.

For an example of how you can authenticate requests to these APIs, refer to the tutorial [Managing buckets with the DocumentHub user-defined APIs](xref:Tutorial_DH_UDAPI). To find the route used as the public URL segment of each API, check the value defined in the *User-Defined APIs* module in DataMiner Cube.

> [!TIP]
> For the full source code of these scripts, go to the [DocumentHub Solution repository](https://github.com/SkylineCommunications/SLC-S-DocumentHub) on GitHub (look for projects starting with `SLC-DH-UDAPI-*`).

## Handling of unsupported methods

Each DocumentHub UDAPI script only supports a specific set of HTTP methods. If you send a request using a method that is not supported (for example, `PATCH` on `SLC-DH-UDAPI-ManageBuckets`), the script's default branch returns an HTTP `400` status code with a message listing the supported methods.

Depending on how the user-defined API is configured in Cube, DataMiner Cube may reject the method before the script runs, in which case an HTTP `405` status code is returned instead. Both response codes indicate the same thing: the method you used is not supported.

## Managing buckets

Bucket management is done using the **SLC-DH-UDAPI-ManageBuckets** API. For details, refer to the tutorial [Managing buckets with the DocumentHub user-defined APIs](xref:Tutorial_DH_UDAPI).

## Managing files

Use the **SLC-DH-UDAPI-ManageFiles** API to list, upload, and delete files inside a bucket. It supports the `GET`, `POST`, and `DELETE` methods.

- To **list files**, send a `GET` request. Optionally, provide a filter in the request body, for example:

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

- To **upload a file**, send a `POST` request with the following body:

  ```json
  {
    "bucketId": "",
    "filePath": "C:\\Temp\\example.pdf",
    "name": ""
  }
  ```

  > [!NOTE]
  > `filePath` is a path on the DataMiner Agent that executes the script, not a path on your local machine. Make sure the file is present there before calling the API. `name` is optional; if omitted, the file name is derived from `filePath`. File names must be unique within a bucket.

- To **delete a file**, send a `DELETE` request with the following body:

  ```json
  {
    "bucketId": "",
    "fileId": ""
  }
  ```

  `fileId` can be the file's raw reference, its file name, or its display name. Deleting files is currently only supported for buckets with storage type `Local`.

## Managing DOM sources

Use the **SLC-DH-UDAPI-ManageDomSources** API to list, create, update, and delete the DOM sources that DocumentHub uses to store DOM attachments on a network share. It supports the `GET`, `POST`, `PUT`, and `DELETE` methods.

- To **list DOM sources**, send a `GET` request. Optionally, pass a text filter (matched against the name or module) in the request body, or `*` to return all DOM sources.

- To **create a DOM source**, send a `POST` request with a body similar to the following:

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

- To **update a DOM source**, send a `PUT` request with the same body as for creation, including the `Identifier` of the DOM source you want to update. `username` and `password` are optional; if omitted, the existing credential is kept.

- To **delete a DOM source**, send a `DELETE` request with the DOM source name as the raw request body (as a JSON string, e.g., `"My DOM source"`).

  > [!NOTE]
  > A DOM source cannot be deleted while it is still linked to a bucket. Unlink it from any buckets first.

## Managing SharePoint sources

Use the **SLC-DH-UDAPI-ManageSharepointSources** API to list, create, update, and delete SharePoint configurations. It supports the `GET`, `POST`, `PUT`, and `DELETE` methods, following the same pattern as [Managing DOM sources](#managing-dom-sources).

- To **list SharePoint configurations**, send a `GET` request. Optionally, pass a text filter (matched against the name, site URL, document library name, or status) in the request body, or `*` to return all configurations.

- To create a SharePoint configuration, send a `POST` request with a body similar to:

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

- To **update a SharePoint configuration**, send a `PUT` request with the same body as for creation, including the `Identifier` of the configuration you want to update.

- To **delete a SharePoint configuration**, send a `DELETE` request with the configuration name as the raw request body.

  > [!NOTE]
  > A SharePoint configuration cannot be deleted while it is still linked to a bucket. Unlink it from any buckets first.

## Listing DOM modules

Use the **SLC-DH-UDAPI-Read-DomModules** API to **list the DOM modules** that are available on the DataMiner System. It only supports the `GET` method.

When you send the `GET` request, optionally, you can pass a text filter (matched against the module ID) in the request body, or `*` to return all modules.

The response will contain a JSON array of modules, each indicating whether it is already in use by an existing DOM source (`InUse`). To [create a DOM source](#managing-dom-sources), an unused module is needed, as each module can only be linked to one DOM source.

## Reading DOM definitions

Use the **SLC-DH-UDAPI-ReadDomDefinitions** API to list the DOM definitions of a given DOM source. It only supports the `GET` method.

1. Retrieve the identifier of the DOM source by first [listing DOM sources](#managing-dom-sources).

1. Send a `GET` request with the identifier (GUID) of the DOM source as the raw request body.

   The response will contain a JSON array of DOM definitions, each with an `ID` and a `Name`.

## Downloading a file

Use the **SLC-DH-UDAPI-DownloadFile** API to download a file from a bucket to the DataMiner Agent that executes the script. It only supports the `POST` method.

To download a file, send a `POST` request with the following body:

```json
{
  "BucketId": "",
  "FileName": ""
}
```

`FileName` is the storage-specific file name or path, as returned by [listing files](#managing-files).

The response should contain an HTTP `200` status code and a JSON body similar to the following:

```json
{
  "Success": true,
  "TempFilePath": "C:\\Skyline DataMiner\\Documents\\DocumentHub\\Temp\\{guid}_example.pdf"
}
```

> [!NOTE]
> `TempFilePath` is a path on the DataMiner Agent, not on your local machine. The file is written to a fixed temporary folder (`C:\Skyline DataMiner\Documents\DocumentHub\Temp`) using a unique, generated file name.

## Retrieving version information

> [!NOTE]
> The Assistant feature is currently still in preview.

Use the **SLC-DH-UDAPI-GetAgentVersion** API to retrieve the installed version of the DocumentHub Assistant, as recorded in the Solution Registration DOM. It only supports the `GET` method and requires no request body.

The response should contain an HTTP `200` status code and a JSON body similar to the following:

```json
{
  "Success": true,
  "Solution": "DocumentHub.Assistant",
  "Version": "1.1.2"
}
```

If no Solution Registration entry is found, the API returns an HTTP `404` status code instead.
