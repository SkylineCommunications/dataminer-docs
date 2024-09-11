---
uid: Register_Catalog_Item
---

# Registering a Catalog item

In order to make a new Catalog item or a new version of a Catalog item available in the [DataMiner Catalog](https://catalog.dataminer.services/), you need to register it.

When you register a new Catalog item, it will only become available for the registered organization, and it will be marked as *private* on the Catalog to indicate this.

Registration can be done using the [Catalog API](#using-the-catalog-api).

> [!TIP]
> For a practical example, refer to the tutorials [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item), [Registering a new version of a connector in the Catalog](xref:Tutorial_Register_Catalog_Version) and [Registering a new version of a connector in the Catalog using GitHub Actions](xref:Tutorial_Register_Catalog_Version_GitHub_Actions).

## Using the Catalog API

With the Catalog API, you can both [register a Catalog item](#registering-a-catalog-item-with-the-api) and [register a new version of a Catalog item](#registering-a-new-version-with-the-api).

> [!IMPORTANT]  
> The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). The key must have the *Register catalog items permission* and needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.  
You need to have the "Owner" role in order to access/create organization keys.

A Catalog item is identified by a unique id (GUID) which you should provide yourself.

### Registering a Catalog item with the API

The register API call allows you to create or update a Catalog item, see [Registering a new version with the API](#registering-a-new-version-with-the-api) on how to add a version after successfully registering an item.

#### URL

`https://api.dataminer.services/api/key-catalog/v1-0/catalog/register`

#### HTTP method

PUT

#### Body

The body of the request should be of type **multipart/form-data** and must contain:  

A key of type **File** and name **file**.
The value of this key should be a  `.zip` file containing 

- [Required] a ["manifest.yml"](xref:Register_Catalog_Item#manifest-file) file.

- [Optional] a 'README.md' file that contains the description of the Catalog item.
- [Optional] an 'images' folder containing any image being referenced by the readme file.  
Supported image extensions are `.jpg`, `.jpeg`, `.png`, `.gif`, `.bmp`, `.tif`, `.tiff` and `.webp`

```json
file: <the zip file containing manifest, README and optional images>
```

##### Manifest file

This file will contain all necessary information to register a Catalog item with a version. This manifest file should be a valid `.yml` file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.

```yml
# [Required]
# Possible values for the Catalog item that can be deployed on a DataMiner System:
#   - automationscript: If the Catalog item is a general-purpose DataMiner Automation script.
#   - lifecycleserviceorchestration: If the Catalog item is a DataMiner Automation script designed to manage the life cycle of a service.
#   - profileloadscript: If the Catalog item is a DataMiner Automation script designed to load a standard DataMiner profile.
#   - userdefinedapi: If the Catalog item is a DataMiner Automation script designed as a user-defined API.
#   - adhocdatasource: If the Catalog item is a DataMiner Automation script designed for a ad hoc data source integration.
#   - chatopsextension: If the Catalog item is a DataMiner Automation script designed as ChatOps Extension.
#   - connector: If the Catalog item is a DataMiner XML connector.
#   - slamodel: If the Catalog item is a DataMiner XML connector designed as DataMiner Service Level Agreement model.
#   - enhancedservicemodel: If the Catalog item is a DataMiner XML connector designed as DataMiner enhanced service model.
#   - visio: If the Catalog item is a Microsoft Visio design.
#   - solution: If the Catalog item is a DataMiner Solution.
#   - testingsolution: If the Catalog item is a DataMiner Solution designed for automated testing and validation.
#   - samplesolution: If the Catalog item is a DataMiner Solution used for training and education.
#   - standardsolution: If the Catalog item is a DataMiner Solution which is a out-of-the-box solution for specific use case or application.
#   - dashboard: If the Catalog item is a DataMiner Dashboard.
#   - lowcodeapp: If the Catalog item is a DataMiner low-code app.
#   - datatransformer: If the Catalog item is a Data Transformer.
#   - dataquery: If the Catalog item is a GQI data query.
#   - functiondefinition: If the Catalog item is a DataMiner function definition.
#   - scriptedconnector: If the Catalog item is a DataMiner scripted connector.
#   - bestpracticesanalyzer: If the Catalog item is a DataMiner Best practices Analysis file.

type: '<fill in type here>'

# [Required] 
# The ID of the Catalog item.
# All registered versions for the same ID are shown together in the Catalog.
# This ID can not be changed. 
# If the ID is not filled in, the registration will fail with http status code 500. 
# If the ID is filled in but does not exist yet, a new Catalog item will be registered with this id.
# If the ID is filled in but does exist, properties of the item will be overwritten
#   Must be a valid GUID.
id: '<fill in GUID here>'

# [Required] 
# The human-friendly name of the Catalog item. 
# Can be changed at any time.
#   Max length: 100 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
title: '<fill in title here>'

# [Optional]
# General information about the Catalog item.
#   Max length: 100.000 characters
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

### Registering a new version with the API

The register version API call allows you to create a new version for a Catalog item

#### URL
`https://api.dataminer.services/api/key-catalog/v1-0/catalog/{catalogId:GUID}/register/version`

Route parameter "catalogId" is the ID of the Catalog item of which a new version is registered. Must be a valid GUID.
This is the ID you used to register the [catalog item](#registering-a-catalog-item-with-the-api).  
You can always obtain it from an existing Catalog item by navigating to the details page of it in the [Catalog](https://catalog.dataminer.services/), the ID is the last part of the URL.  

`https://catalog.dataminer.services/details/{CatalogId}`

#### HTTP method

POST

#### Body

The body of the request should be of type **multipart/form-data** and must contain the below fields.  

```json
file: <the Catalog item installation file>
versionNumber: <the version number you want to register>
versionDescription: <the description of the version you want to register>
```
> [!NOTE]  
> Supported types are a DataMiner Protocol package (`.dmprotocol`) or a DataMiner Application package (`.dmapplication`)