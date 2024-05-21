---
uid: Register_Catalog_Item
---

# Register your catalog item

## What is a catalog item?

The content available in the catalog module has always been provided by Skyline Communications. We have been using this module initially to share our connectors with all of our users. In a later stage we have been adding App Packages, Automation Scripts and Visual Overviews. All of these items are called "catalog items".

As we see more and more users create their own customized solutions on top of the DataMiner software, we want to allow them to register their solutions to the catalog as well. This will enable our users to easily manage the solutions and packages they have created, distribute them within their organization between different teams and even share them with different organizations.

## Private catalog items

All of the items that have been provided by Skyline Communications are considered to be public items. They are available for all our users. Note that for some of these items (eg Connectors) the user might need to buy a license to be able to use them on their system.

Private catalog items are items that are only available to one or more organizations. This gives users the possibility to develop App Packages, Automation Scripts or any type of catalog item and redeploy them within their organization on various systems or share them with other organizations.

## Versioning of catalog items

Catalog items can hold multiple versions. To make sure that the versioning of items is easy to understand for everyone [Semver](https://semver.org/) versioning is promoted for catalog item versions. Users can assign extra labels to versions if they want to indicate a certain version is not an official release (eg 1.2.3-alpha).

## How to register a private catalog item

### Register using the Catalog UI

If you use the UI, you can only register a catalog item. There is no UI yet to register a new version, this can only be done by using the API.

Registering a new catalog item can be done by executing the following steps.

1. Go to the [Catalog](https://catalog.dataminer.services). There you will find a button next to the organization selector called         "Register Catalog". Clicking this button will open a popup with a few fields.

1. First you must indicate to which organization you want to register the catalog item. This can be done by using the dropdown selector that will automatically be populated with all the organizations on the dataminer.services platform that you have access to.

1. Next you need to select the type of the catalog item. The type will define how the catalog item will be shown to the users. We also allow filtering on type so users can quickly find what they are looking for when browsing the Catalog Module.

1. Finally, you will need to provide a name for the item. This will be the name that will be used to display the item in the catalog and needs to be human readable. Make sure you pick a name that makes sense for your item.

Once all of this information has been filled in you will be able to click on the "Register" button. This will fulfill the registration process for the catalog item and return the unique identifier for that catalog item. This identifier allows you to register versions for the catalog item with the [API](xref:Register_catalog_item#register_new_versions_using_the_catalog_api).

### Register using the Catalog API

#### Authentication

Authentication for this call is done with [organization keys](xref:Managing_DCP_keys#organization_keys). This key needs to be added to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

#### API call signature

The call to register a catalog item can be found at the following URL: <https://api.dataminer.serivces/api/key-catalog/v1-0/catalog/register>. To call the API you will need to use the **POST** HTTP method.

The call accepts a binary file as input. This file should be a zip file containing a ["manifest.yml"](xref:#manifest_file) and the item you want to upload.

#### Manifest file

This file will contain all of the necessary information to register a catalog item or version. This manifest file should be a valid yml file and will contain "required" and "optional" attributes to add extra information to the catalog item. Note that limitations may apply to certain attributes based on length or formatting.

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
# The version in format X.X.X
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
#   Max lenth: 2048 characters
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

> [!WARNING]
> If the id field is not filled in, a new catalog item registration will be created.
> If you want to register a new version for an existing catalog item, make sure to fill in the id of that item.
