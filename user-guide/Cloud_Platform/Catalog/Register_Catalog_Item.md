---
uid: Register_Catalog_Item
---

# Registering a Catalog item

Below you can find detailed information on how you can register a private Catalog item, either [using the Catalog UI](#using-the-catalog-ui), or [using the Catalog API](#using-the-catalog-api).

## Using the Catalog UI

If you use the UI, you can only register a new Catalog item, but not a new version. To register a new version for an existing item, [use the API](#using-the-catalog-api).

To register a new Catalog item:

1. Go to the [Catalog](https://catalog.dataminer.services).

1. Open the user menu by clicking the user icon in the top-right corner.

1. Click the *Register item* button.

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

The API call is authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). The key needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### API call signature

The call to register a Catalog item can be found at the following URL: <https://api.dataminer.services/api/key-catalog/v1-0/catalog/register>. To call the API you will need to use the **POST** HTTP method.

The body of the request should be of type "multipart/form-data". A key of type **File** needs to be added called "file". The value of this key should be a zip file containing a ["manifest.yml"](xref:Register_Catalog_Item#manifest-file) and the item you want to upload.

### Manifest file

This file will contain all necessary information to register a Catalog item or version. This manifest file should be a valid .yml file and will contain "required" and "optional" attributes to add extra information to the Catalog item. Note that limitations may apply to certain attributes based on length or formatting.

> [!IMPORTANT]
> If the *id* field is not filled in, a new Catalog item registration will be created. If you want to register a new version for an existing Catalog item, make sure to fill in the ID of that item.

```yml
# [Required]
# Possible values: 
#   - automationscript: If the catalog item is an Automation Script that can be deployed on a DataMiner System.
#   - package: If the catalog item is a Solution Package that can be deployed on a DataMiner System.
#   - connector: If the catalog item is a Protocol that can be deployed on a DataMiner System.
#   - visio: If the catalog item is a Visio file that can be deployed on a DataMiner System.
type: 'automationscript'

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
