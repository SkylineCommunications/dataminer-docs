---
uid: Register_Catalog_Item
---

# Catalog Registration

 In order to make a catalog item (version) available on the [Catalog](https://catalog.dataminer.services/), you need to register it.
 Registration can be done using the Catalog UI or using the Catalog API.

 Using the [Catalog UI](#using-the-catalog-ui), it is possible to register a catalog item with limited properties and without a version.  

 Using the [Catalog API](#using-the-catalog-api), it is possible to 
  - register a catalog item with a version.
  - register a new catalog item version of an existing catalog item.
  - register a new description of a catalog item.


Below you can find detailed steps on how you can register a private Catalog item (version), using either the [Catalog UI](#using-the-catalog-ui), or the [Catalog API](#using-the-catalog-api).

## Using the Catalog UI

If you use the UI, you can only register a new Catalog item, but not a new version. To register a new version for an existing item, use the [Register new catalog item version](#register-a-new-catalog-item-version) API call.

To register a new Catalog item:

1. Go to the [Catalog](https://catalog.dataminer.services).

1. Open the user menu by clicking the user icon in the top-right corner.

1. Click the *Register new catalog item* menu item.

1. Select the organization for which you want to register the Catalog item.

   The selection box is automatically populated with all the organizations you have access to on the dataminer.services platform.

1. Select the type of the Catalog item.

   The selected [Catalog item type](xref:About_the_Catalog_module#supported-catalog-item-types) defines how the Catalog item will be shown to the users. Users can also filter on type to quickly find what they are looking for when browsing the Catalog.

1. Enter the name of the item.

   This name will be used to display the item in the Catalog. Make sure you pick a human-readable name that makes sense.

1. Once all information has been filled in, click *Register*.

   This will conclude the registration process for the Catalog item and return the unique identifier for the item in question. This identifier will allow you to register versions for the Catalog item using the [API](#using-the-catalog-api).

## Using the Catalog API

### Authentication

The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). The key must have the *Register catalog items permission* and needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### Register a catalog item with a version

#### URL
<https://api.dataminer.services/api/key-catalog/v1-0/catalog/register>

#### HTTP method

PUT

#### Body

The body of the request should be of type **multipart/form-data** and must contain:  

A key of type **File** and name **file**.  
The value of this key should be a **zip** file containing 

- [required] a ["manifest.yml"](xref:Register_Catalog_Item#manifest-file) file.
- [required] the catalog item installation file you want to upload. Supported types are DataMiner Protocol packages (.dmprotocol) and DataMiner Application packages (.dmapplication).
- [optional] a readme.md file that contains the description of the catalog item.
- [optional] an "images" folder containing any image being referenced by the readme file.  
Supported image extensions are *.jpg*, *.jpeg*, *.png*, *.gif*, *.bmp*, *.tif*, *.tiff* and *.webp*

##### Manifest file

This file will contain all necessary information to register a catalog item with a version. This manifest file should be a valid .yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.


```yml
# [Required]
# Possible values for the catalog item that can be deployed on a DataMiner System:
#   - automationscript: If the catalog item is a general-purpose DataMiner Automation script.
#   - lifecycleserviceorchestration: If the catalog item is a DataMiner Automation script designed to manage the life cycle of a service.
#   - profileloadscript: If the catalog item is a DataMiner Automation script designed to load a standard DataMiner profile.
#   - userdefinedapi: If the catalog item is a DataMiner Automation script designed as a user-defined API.
#   - adhocdatasource: If the catalog item is a DataMiner Automation script designed for a ad hoc data source integration.
#   - chatopsextension: If the catalog item is a DataMiner Automation script designed as ChatOps Extension.
#   - connector: If the catalog item is a DataMiner XML connector.
#   - slamodel: If the catalog item is a DataMiner XML connector designed as DataMiner Service Level Agreement model.
#   - enhancedservicemodel: If the catalog item is a DataMiner XML connector designed as DataMiner enhanced service model.
#   - visio: If the catalog item is a Microsoft Visio design.
#   - solution: If the catalog item is a DataMiner Solution.
#   - testingsolution: If the catalog item is a DataMiner Solution designed for automated testing and validation.
#   - samplesolution: If the catalog item is a DataMiner Solution used for training and education.
#   - standardsolution: If the catalog item is a DataMiner Solution which is a out-of-the-box solution for specific use case or application.
#   - dashboard: If the catalog item is a DataMiner Dashboard.
#   - lowcodeapp: If the catalog item is a DataMiner low-code app.
#   - datatransformer: If the catalog item is a Data Transformer.
#   - dataquery: If the catalog item is a GQI data query.
#   - functiondefinition: If the catalog item is a DataMiner function definition.
#   - scriptedconnector: If the catalog item is a DataMiner scripted connector.
#   - bestpracticesanalyzer: If the catalog item is a DataMiner Best practices Analysis file.

type: 'automationscript'

# [Required] 
# The id of the catalog item.
# All registered versions for the same id are shown together in the catalog.
# This id can not be changed. 
# If the id is not filled in, the registration will fail with http status code 500. 
# If the id is filled in but does not exist yet, a new catalog item will be registered with this id.
# If the id is filled in but does exist, properties of the item will be overwritten, the version will be created or overwritten if it already existed.
# (!!!!!!!!!!!!!todo bug fix?? check PR)
#   Must be a valid GUID.
id: '<fill in guid here>'

# [Required] 
# The human-friendly name of the catalog item. 
# Can be changed at any time.
#   Max length: 100 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
title: 'add-new-switch'

# [Required] 
# The version in format X.X.X (see https://semver.org/)
# Items of type "Connector" should use the X.X.X.X format
# Once a version has been published it can no longer be changed.
# The version should be incremented to do any changes.
# If you want to create a package that is not final, you can provide a label at the end: X.X.X-label
# If a catalog item has a label in the version, then the version is considered to be a pre-release version, and not an official one.
#   Valid versions range from 0.0.0 to 2147483647.2147483647.2147483647
#   The label can contain characters a-z0-9 with a max length of 30 characters.
version: '1.0.0'

# [Optional]
# General information about the catalog item.
#   Max length: 100.000 characters
description: |
  This script allows you to easily add a new leaf switch element.

# [Optional]
# A short description for this specific version.
# This message is shown along side each version in the version overviews in the catalog. 
#   Max length: 500 characters.
version-message: 'Initial version. Does not contain anything useful yet.'

# [Optional]
# A valid URL that points to the home page.
# Usually, this home page is also the location of the source code.
#   A valid URL
#   Max length: 2048 characters
homepage: 'https://github.com/randomrepo'

# [Optional]
# People that are responsible for this catalog item. Might be developers but is not required.
# Format: 'name <email> (url)'
#   The name is required, max 256 characters.
#   The email and url are optional, and should be in valid email/URL formats.
owners:
  - name: 'David Smith'
  - name: 'Someone'
    email: 'someone@skyline.be'
  - name: 'John Smith'
    email: 'john@skyline.be'
    url: 'https://github.com/JohnSmith'

# [Optional]
# Tags that allow you to categorize your catalog items.
#   Max length: 50 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
tags:
  - 'Information Platform'
  - 'Azure'
```

### Register a new catalog item version

#### URL
<https://api.dataminer.services/api/key-catalog/v1-0/catalog/register{catalogId:guid}/version>

Route parameter "catalogId" is the id of the catalog item of which a new version is registered. Must be a valid Guid

#### HTTP method

POST

#### Body


The body of the request should be of type **multipart/form-data** and must contain  

- a key of type **File** with name **file**.  
The value is the catalog item installation file, supported types are a DataMiner Protocol package (.dmprotocol) or a DataMiner Application package (.dmapplication)

- a key of type **Text** with name **versionNumber**.  
The value is the version number you want to register.
- a key of type **Text** with name **description**.  
The value is the description of the version you want to register.

### Register a catalog description

#### URL
<https://api.dataminer.services/api/key-catalog/v1-0/catalog/{catalogId:guid}/description>
#### HTTP method

POST

#### Body

The body of the request should be of type **multipart/form-data** and must contain  

- a key of type **File** with name **file**.  
The value is a zip file containing the readme.md file and optionally a folder with name "images" containing all referenced images.  
Supported image extensions are *.jpg*, *.jpeg*, *.png*, *.gif*, *.bmp*, *.tif*, *.tiff* and *.webp*



