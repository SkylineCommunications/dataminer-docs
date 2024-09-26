---
uid: Register_Catalog_Item
---

# Registering a Catalog item

In order to make a [new Catalog item](#registering-a-catalog-item-with-the-api) or a [new version of a Catalog item](#registering-a-new-version-with-the-api) available in the [DataMiner Catalog](https://catalog.dataminer.services/), you need to register it using the Catalog API.

When you register a new Catalog item, it will only become available for the registered organization, and it will be marked as *private* in the Catalog to indicate this.

A Catalog item is identified by a unique ID (GUID), which you will need to provide yourself.

> [!IMPORTANT]
> The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). Make sure you use a key that has the *Register Catalog items* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**. Also, note that you need to have the *Owner* role in order to access or create organization keys.

> [!TIP]
> For practical examples, refer to the tutorials [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item), [Registering a new version of a connector in the Catalog](xref:Tutorial_Register_Catalog_Version), and [Registering a new version of a connector in the Catalog using GitHub Actions](xref:Tutorial_Register_Catalog_Version_GitHub_Actions).

## Registering a Catalog item with the API

The register API call allows you to create or update a Catalog item. To add a version after you have successfully registered an item, see [Registering a new version with the API](#registering-a-new-version-with-the-api).

### API Definition

A complete definition of the API can be found at
[Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v1.0), which also provides an easy way to try out the call.  
Click on "catalog/register" item to expand it > press "Try it out" button.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_1.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

> [!IMPORTANT]
Be aware the "Try it out" allows you to execute the register call on the production Catalog.

### HTTP method

PUT

### Body

The body of the request should be of type **multipart/form-data** and must contain a key of type **File** with the name **file**.

The value of this key should be a .zip file containing the following items:

- A [manifest.yml](xref:Register_Catalog_Item#manifest-file) file (required).

- A *README.md* file containing the description of the Catalog item (optional).

- An *images* folder containing any image referenced in the readme file (optional). Supported image extensions are .jpg, .jpeg, .png, .gif, .bmp, .tif, .tiff, and .webp.

```json
file: <the zip file containing manifest, README and optional images>
```

> [!NOTE]
> To reference images in the README.md file, you can use the home directory (~/images) or relative path syntax (./images).

#### Manifest file

This file will contain all the necessary information to register a Catalog item with a version. This manifest file should be a valid .yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.

```yml
# [Required]
# Possible values for the Catalog item that can be deployed on a DataMiner System:
#   - automationscript: If the Catalog item is a general-purpose DataMiner Automation script.
#   - lifecycleserviceorchestration: If the Catalog item is a DataMiner Automation script designed to manage the life cycle of a service.
#   - profileloadscript: If the Catalog item is a DataMiner Automation script designed to load a standard DataMiner profile.
#   - userdefinedapi: If the Catalog item is a DataMiner Automation script designed as a user-defined API.
#   - adhocdatasource: If the Catalog item is a DataMiner Automation script designed for an ad hoc data source integration.
#   - chatopsextension: If the Catalog item is a DataMiner Automation script designed as a ChatOps extension.
#   - connector: If the Catalog item is a DataMiner XML connector.
#   - slamodel: If the Catalog item is a DataMiner XML connector designed as DataMiner Service Level Agreement model.
#   - enhancedservicemodel: If the Catalog item is a DataMiner XML connector designed as DataMiner enhanced service model.
#   - visio: If the Catalog item is a Microsoft Visio design.
#   - solution: If the Catalog item is a DataMiner Solution.
#   - testingsolution: If the Catalog item is a DataMiner Solution designed for automated testing and validation.
#   - samplesolution: If the Catalog item is a DataMiner Solution used for training and education.
#   - standardsolution: If the Catalog item is a DataMiner Solution that is an out-of-the-box solution for a specific use case or application.
#   - dashboard: If the Catalog item is a DataMiner dashboard.
#   - lowcodeapp: If the Catalog item is a DataMiner low-code app.
#   - datatransformer: If the Catalog item is a Data Transformer.
#   - dataquery: If the Catalog item is a GQI data query.
#   - functiondefinition: If the Catalog item is a DataMiner function definition.
#   - scriptedconnector: If the Catalog item is a DataMiner scripted connector.
#   - bestpracticesanalyzer: If the Catalog item is a DataMiner Best Practices Analysis file.

type: '<fill in type here>'

# [Required] 
# The ID of the Catalog item.
# All registered versions for the same ID are shown together in the Catalog.
# This ID can not be changed. 
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
# Format: 'name <email> (url)'
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
  - '<fill in tag here>'
```

## Registering a new version with the API

The register version API call allows you to create a new version for a Catalog item.

> [!NOTE]
> A version can only be registered once. Registration will fail if you try to register an existing version number of a Catalog item.

Route parameter "catalogId" is the ID of the Catalog item of which a new version is registered, which is the same as the ID used to [register the Catalog item](#registering-a-catalog-item-with-the-api). This must be a valid GUID.

To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.

### API Definition

A complete definition of the API can be found at
[Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v1.0), which also provides an easy way to try out the call.  
Click on "catalog/{catalogId}/register/version" item to expand it > press "Try it out" button.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_1.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

> [!IMPORTANT]
Be aware the "Try it out" allows you to execute the register call on the production Catalog.

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
> Supported types are a DataMiner protocol package (.dmprotocol) and a DataMiner application package (.dmapplication).
