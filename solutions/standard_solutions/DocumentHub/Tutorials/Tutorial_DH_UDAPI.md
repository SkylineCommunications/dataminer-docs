---
uid: Tutorial_DH_UDAPI
description: "Learn how to use the DocumentHub user-defined APIs to manage buckets, so you can integrate DocumentHub into your own solutions."
---

# Managing buckets with the DocumentHub user-defined APIs

This tutorial shows you how to use the [DocumentHub user-defined APIs](xref:DH_UDAPI) to retrieve existing DocumentHub buckets, create a bucket, and delete a bucket.

Expected duration: 10 minutes

## Prerequisites

- A DataMiner System with the DocumentHub Solution installed.
- The DocumentHub user-defined APIs you want to use, configured and enabled in DataMiner Cube.
- A valid API token for authentication. For more information, go to [Triggering a user-defined API](xref:UD_APIs_Triggering_an_API).
- A tool to send HTTP requests, such as Postman.

## Overview

- [Step 1: Retrieve the buckets route and API token](#step-1-retrieve-the-buckets-route-and-api-token)
- [Step 2: List the existing buckets](#step-2-list-the-existing-buckets)
- [Step 3: Create a bucket](#step-3-create-a-bucket)
- [Step 4: Verify that the bucket was created](#step-4-verify-that-the-bucket-was-created)
- [Step 5: Delete the bucket](#step-5-delete-the-bucket)

## Step 1: Retrieve the buckets route and API token

1. In DataMiner Cube, go to the *User-Defined APIs* module.

1. Locate the **SLC-DH-UDAPI-ManageBuckets** API and note its configured route.

   This tutorial assumes the default route `dhmanagebuckets`.

   > [!NOTE]
   > The public URL segment of each API (referred to as *route* in this tutorial) is defined by an operator in the *User-Defined APIs* module of DataMiner Cube. The route used in this tutorial is only an example; the actual value may differ per DataMiner System.

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
     "Name": "TUTORIAL-EXAMPLE-BUCKET",
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
