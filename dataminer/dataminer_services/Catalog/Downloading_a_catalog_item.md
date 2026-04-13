---
uid: Downloading_a_catalog_item
reviewer: Alexander Verkest
---

# Downloading a Catalog item with the API

The *download* API call allows you to download a Catalog item.

> [!NOTE]
> The API calls are authenticated using [organization keys](xref:Managing_dataminer_services_keys#organization-keys). Make sure you use a key that has the *Download Catalog versions* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**. The API calls use the following rate limiting policy:
>
> - Partition key: IP address or host name of connection
> - Burst limit: 100 requests
> - Long-term sustained request rate: 1 request every 36 seconds (100 request per hour)
> - No queueing for extra requests beyond the token bucket

## API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "/api/key-catalog/v2-0/{catalogId}/versions/{versionId}/download" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the download call on the production Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g., [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

## HTTP method

GET

## Route parameters

- Route parameter "catalogId" is the ID of the Catalog item that will be downloaded, which is the same as the ID used to [register the Catalog item](xref:Register_Catalog_Item#registering-a-catalog-item-with-the-api). This must be a valid GUID.

  To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.

- Route parameter "versionId" is the version number of the Catalog item that will be downloaded.
