---
uid: Register_Catalog_Item
keywords: catalog, registration, manifest, upload, publish
reviewer: Alexander Verkest
---

# Registering a Catalog item

In order to make a [new Catalog item](#registering-a-catalog-item-with-the-api) or a [new version of a Catalog item](#registering-a-new-version-with-the-api) available in the [Catalog](https://catalog.dataminer.services/), you need to register it using the Catalog API.

When you register a new Catalog item, it will only become available for the registered organization, and it will be marked as *private* in the Catalog to indicate this.

A Catalog item is identified by a unique ID (GUID), which you will need to provide yourself.

> [!TIP]
> Before you register a new Catalog item, make sure to check the **best practices** for [creating Catalog items](xref:Best_Practices_When_Creating_Catalog_Items) and for [documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

> [!IMPORTANT]
> The API calls are authenticated using [organization keys](xref:Managing_dataminer_services_keys#organization-keys). Make sure you use a key that has the *Register Catalog items* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**. Also, note that you need to have the *Owner* role in order to access or create organization keys. The API calls use the following rate limiting policy:
>
> - Partition key: IP address or host name of connection
> - Burst limit: 100 requests
> - Long-term sustained request rate: 1 request every 36 seconds (100 request per hour)
> - No queueing for extra requests beyond the token bucket

> [!NOTE]
> For practical examples of how to register a Catalog item, refer to the tutorials [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item), [Registering a new version of a connector in the Catalog](xref:Tutorial_Register_Catalog_Version), and [Registering a new version of a connector in the Catalog using GitHub Actions](xref:Tutorial_Register_Catalog_Version_GitHub_Actions).

## Registering a Catalog item with workflows and tooling

If you would prefer not to use Postman and HTTPS directly, try out our [platform-independent](xref:Platform_independent_CICD) tool support or check out our IaC (Infrastructure as Code) solutions using the [Skyline DataMiner Software Development Kit](xref:skyline_dataminer_sdk), which has publication to the Catalog directly integrated.

If you are interested in setting up CI/CD to handle registration automatically, take a look at the [CI/CD tutorials](xref:CICD_Tutorials).

## Registering a Catalog item with the API

The register API call allows you to create or update a Catalog item. To add a version after you have successfully registered an item, see [Registering a new version with the API](#registering-a-new-version-with-the-api).

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "catalog/register" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the register call directly on the Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

PUT

### Body

The body of the request should be of type **multipart/form-data** and must contain a key of type **File** with the name **file**.

The value of this key should be a .zip file containing the following items:

- A [manifest.yml](#manifest-file) file (required).

- A *README.md* file containing the description of the Catalog item (optional).

  > [!TIP]
  > See also: [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

- An *images* folder containing any image referenced in the readme file (optional). Supported image extensions are .jpg, .jpeg, .png, .gif, .bmp, .tif, .tiff, and .webp.

```json
file: <the zip file containing manifest, README and optional images>
```

> [!NOTE]
> To reference images in the README.md file, you can use the home directory (~/images) or relative path syntax (./images).

> [!IMPORTANT]
>
> - Limitations apply for the maximum file size of packages and vendor/icon images. See [Best practices when creating Catalog items](xref:Best_Practices_When_Creating_Catalog_Items#keep-the-limitations-in-mind)
> - Only the following formats are supported for vendor/icon images: .jpg, .jpeg, .png, .bmp, .webp, .svg

#### Manifest file

This file will contain all the necessary information to register a Catalog item with a version. This manifest file should be a valid .yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.

```yml
# [Required]
# Possible values for the Catalog item that can be deployed on a DataMiner System:
#   - Automation: If the Catalog item is a general-purpose DataMiner automation script.
#   - Ad Hoc Data Source: If the Catalog item is a DataMiner automation script designed for an ad hoc data source integration.
#   - ChatOps Extension: If the Catalog item is a DataMiner automation script designed as a ChatOps extension.
#   - Connector: If the Catalog item is a DataMiner XML connector.
#   - Custom Solution: If the Catalog item is a DataMiner Solution.
#   - Data Transformer: Includes a data transformer that enables you to modify data using a GQI data query before making it available to users in low-code apps or dashboards.
#   - Dashboard: If the Catalog item is a DataMiner dashboard.
#   - DevTool: If the Catalog item is a DevTool.
#   - Learning & Sample: If the Catalog item is a sample.
#   - Product Solution: If the Catalog item is a DataMiner Solution that is an out-of-the-box solution for a specific product.
#   - Scripted Connector: If the Catalog item is a DataMiner scripted connector.
#   - Standard Solution: If the Catalog item is a DataMiner Solution that is an out-of-the-box solution for a specific use case or application.
#   - System Health: If the Catalog item is intended to monitor the health of a system.
#   - User-Defined API: If the Catalog item is a DataMiner automation script designed as a user-defined API.
#   - Visual Overview: If the Catalog item is a Microsoft Visio design.
type: '<fill in type here>'

# [Required] 
# The ID of the Catalog item.
# All registered versions for the same ID are shown together in the Catalog.
# This ID cannot be changed. 
# If the ID is not filled in, the registration will fail with HTTP status code 500. 
# If the ID is filled in but does not exist yet, a new Catalog item will be registered with this ID.
# If the ID is filled in but does exist, properties of the item will be overwritten.
#   Must be a valid GUID.
id: '<fill in GUID here>'

# [Required] 
# The human-friendly name of the Catalog item. 
# Can be changed at any time.
#   Max length: 100 characters.
#   Cannot contain newlines.
#   Cannot contain leading or trailing whitespace characters.
title: '<fill in title here>'

# [Optional]
# General information about the Catalog item.
#   Max length: 100,000 characters
# Currently not shown in the Catalog UI but will be supported in the near future.
short_description: '<fill in description here>'

# [Optional]
# A valid URL that points to the source code.
#   A valid URL
#   Max length: 2048 characters
source_code_url: '<fill in source code url here>'

# [Optional]
# A valid URL that points to documentation.
#   A valid URL
#   Max length: 2048 characters
# Currently not shown in the Catalog UI but will be supported in the near future.
documentation_url: '<fill in documentation url here>'

# [Optional]
# People who are responsible for this Catalog item. Might be developers, but this is not required.
#   The name is required; max 256 characters.
#   The email and url are optional, and should be in valid email/URL formats.
owners:
  - name: '<fill in name here>'
    email: '<fill in email here>'
    url: '<fill in url here>'

# [Optional]
# Tags that allow you to categorize your Catalog items.
#   Max number of tags: 5
#   Max length: 50 characters.
#   Cannot contain newlines.
#   Cannot contain leading or trailing whitespace characters.
tags:
  - '<fill in tag 1 here>'
  - '<fill in tag 2 here>'

# [Optional]
# The ID of the vendor.
# This vendor ID can be retrieved using the public Catalog API.
# If the vendor ID does not exist, the registration or update will fail with HTTP status code 400. 
# If the vendor ID is '00000000-0000-0000-0000-000000000000', the vendor will be unset. 
# If the vendor ID is not provided during the initial registration, the vendor will be unset.
# If the vendor ID is not provided during an update, the vendor will be unchanged and keep the previously set value.
#   Must be a valid GUID.
vendor_id: '<fill in GUID here>'

# [Optional]
# The name of the market the Catalog item belongs to.
market_name: '<fill in name here>'

# [Optional]
# The type of the element.
# This can only be applied to Catalog items with the type Connector.
element_type: '<fill in element type here>'
```

## Registering a new version with the API

The register version API call allows you to create a new version for a Catalog item.

> [!NOTE]
> A version can only be registered once. Registration will fail if you try to register an existing version number of a Catalog item.

Route parameter "catalogId" is the ID of the Catalog item of which a new version is registered, which is the same as the ID used to [register the Catalog item](#registering-a-catalog-item-with-the-api). This must be a valid GUID.

To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "catalog/{catalogId}/register/version" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the register call on the production Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

POST

### Body

The body of the request should be of type **multipart/form-data** and must contain the fields below.

```json
file: <The Catalog item installation file>
versionNumber: <The version number you want to register>
versionDescription: <The description of the version you want to register>
```

> [!NOTE]
>
> - Supported types are a DataMiner protocol package (.dmprotocol) and a DataMiner application package (.dmapplication), with a maximum file size of **250 MB**.
> - The version description must not exceed 1500 characters. The call will fail with a `Bad Request` error if the length exceeds the maximum allowed limit.<!-- RN 40956 -->
> - Versions following semantic version A.B.C.D will be displayed in an A.B.C range, versions following semantic version A.B.C will be displayed in an A range, and all other version formats will be displayed in the "Other" range.<!-- RN 41225 -->
