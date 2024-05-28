---
uid: Register_Catalog_Item
---

# Registering a Catalog item

## How to register a private Catalog item

### Using the Catalog UI

If you use the UI, you can only register a Catalog item. There is no UI yet to register a new version. This can only be done by using the [API](#using-the-catalog-api).

To register a new Catalog item, do the following:

1. Go to the [Catalog](https://catalog.dataminer.services).

1. Open the user menu by clicking the user icon on the top right. 

1. Click the "Register item" button.

1. Indicate for which organization you want to register the Catalog item. This can be done by using the selection box that will automatically be populated with all the organizations on the dataminer.services platform you have access to.

1. Select the type of the Catalog item. This can be one of the supported [catalog item types](xref:About_the_Catalog_module#supported-catalog-item-types). The type will define how the Catalog item will be shown to the users. We also allow filtering on type so users can quickly find what they are looking for when browsing the Catalog module.

1. Enter the name of the item. This will be the name that will be used to display the item in the Catalog. It needs to be human readable. Make sure you pick a name that makes sense.

1. Once all information has been filled in, click *Register*. This will conclude the registration process for the Catalog item and return the unique identifier for the item in question. This identifier will allow you to register versions for the catalog item using the [API](#using-the-catalog-api).

### Using the Catalog API

#### Authentication

The API call is authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). The key needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

#### API call signature

The call to register a Catalog item can be found at the following URL: <https://api.dataminer.serivces/api/key-catalog/v1-0/catalog/register>. To call the API you will need to use the **POST** HTTP method.

The call accepts a binary file as input. This file should be a zip file containing a ["manifest.yml"](xref:Register_Catalog_Item#manifest-file) and the item you want to upload.

#### Manifest file

This file will contain all necessary information to register a Catalog item or version. This manifest file should be a valid yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.

> [!IMPORTANT]
> If the *id* field is not filled in, a new Catalog item registration will be created. If you want to register a new version for an existing Catalog item, make sure to fill in the ID of that item.

```yml
# [Required]
# Possible values: 
#   - AutomationScript: If the catalog item is an Automation Script that can be deployed on a DataMiner System.
#   - AppPackage: If the catalog item is a Solution Package that can be deployed on a DataMiner System.
#   - ProtocolPackage: If the catalog item is a Protocol that can be deployed on a DataMiner System.
#   - Visio: If the catalog item is a Visio that can be deployed on a DataMiner System.
type: 'AutomationScript'

# [Required] 
# The id of the catalog item.
# All versions for the same id are shown together in the catalog.
# This id can not be changed. 
# If the id is not filled in, the API will return one and consider this as the registration of a new item.
# If the id is filled in, a new version will be added to the catalog item with the given version number.
#   Must be a valid GUID.
id: '<fill in guid here or leave empty>'

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
