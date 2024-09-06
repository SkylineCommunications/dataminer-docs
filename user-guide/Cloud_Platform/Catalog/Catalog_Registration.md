---
uid: Catalog_Registration
---

# Catalog registration

 In order to make a catalog item (version) available on [Catalog](https://catalog.dataminer.services/), you need to register it with an organization.  
 The catalog item will be available for the registered organization only and will be marked *private* in the UI to indicate it as such.   

 Registration can be done using the [Catalog UI](#using-the-catalog-ui) and the [Catalog API](#using-the-catalog-api). 
 Below you can find detailed steps on how to use them.

## Catalog UI

Using the Catalog UI, it is possible to register a catalog item by its *name* and *type* but no version can be registered.  
Registration returns a unique identifier for the catalog item, which can be used by the [Catalog API](#using-the-catalog-api) to update additional properties or register new versions. 

To register a new catalog item:

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

   This will conclude the registration process for the Catalog item and return the unique identifier for the item in question. This identifier will allow you to register versions for the Catalog item or update additional properties using the [Catalog API](#using-the-catalog-api).

## Catalog API

Using the Catalog API, it is possible to  

- [register a catalog item](#register-a-catalog-item).
- [register a new catalog version](#register-a-new-catalog-version).

The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). The key must have the *Register catalog items permission* and needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

A Catalog item is identified by a unique id (Guid) which can be obtained by the [Catalog UI](#using-the-catalog-ui) or created by yourself.

### Register a catalog item

The register API call allows you to create or update a Catalog item, see [register a new catalog version](#register-a-new-catalog-version) on how to add a version after succesfuly registering an item.

#### URL
<https://api.dataminer.services/api/key-catalog/v1-0/catalog/register>

#### HTTP method

PUT

#### Body

The body of the request should be of type **multipart/form-data** and must contain:  

A key of type **File** and name **file**.  
The value of this key should be a **zip** file containing 

- [required] a ["manifest.yml"](xref:Register_Catalog_Item#manifest-file) file.

- [optional] a readme.md file that contains the description of the Catalog item.
- [optional] an "images" folder containing any image being referenced by the readme file.  
Supported image extensions are *.jpg*, *.jpeg*, *.png*, *.gif*, *.bmp*, *.tif*, *.tiff* and *.webp*

##### Manifest file

This file will contain all necessary information to register a Catalog item with a version. This manifest file should be a valid .yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.


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

type: '<fill in type here>'

# [Required] 
# The id of the catalog item.
# All registered versions for the same id are shown together in the catalog.
# This id can not be changed. 
# If the id is not filled in, the registration will fail with http status code 500. 
# If the id is filled in but does not exist yet, a new catalog item will be registered with this id.
# If the id is filled in but does exist, properties of the item will be overwritten
#   Must be a valid GUID.
id: '<fill in guid here>'

# [Required] 
# The human-friendly name of the catalog item. 
# Can be changed at any time.
#   Max length: 100 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
title: '<fill in title here>'

# [Optional]
# General information about the catalog item.
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
# People that are responsible for this catalog item. Might be developers but is not required.
# Format: 'name <email> (url)'
#   The name is required, max 256 characters.
#   The email and url are optional, and should be in valid email/URL formats.
owners:
  - name: '<fill in name here>'
    email: '<fill in email here>'
    url: '<fill in url here>'

# [Optional]
# Tags that allow you to categorize your catalog items.
#   Max length: 50 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
tags:
  - '<fill in tag value here>'
```

### Register a new catalog version

The register version API call allows you to create a new version for a Catalog item

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
- a key of type **Text** with name **versionDescription**.  
The value is the description of the version you want to register.
