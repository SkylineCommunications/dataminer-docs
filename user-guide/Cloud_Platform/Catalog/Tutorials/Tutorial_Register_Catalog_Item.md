---
uid: Tutorial_Register_Catalog_Item
---

# Registering a new catalog item

This tutorial demonstrates how to add a new catalog item using the [Catalog API](xref:Catalog_Registration).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom).  

For ease of use we will be using [Postman](https://www.postman.com/) to execute the register API calls. Feel free to integrate them afterwards in your workflow, e.g by using them in a github action.

## Prerequisites

- Organization key with permission "Register catalog items".

## Overview

- [Step1: Register catalog item URL](#step1-register-catalog-item-url)
- [Step2: Authentication header](#step2-authentication-header)
- [Step3: Register catalog item body](#step3-register-catalog-item-body)
- [Step4: Register](#step-4-register)

## Step1: Register catalog item URL
Add a new request with http method **PUT** and following url <https://api.dataminer.services/api/key-catalog/v1-0/catalog/register>

![Register item http url](~/user-guide/images/tutorial_catatalog_registration_item_url.png)

## Step2: Authentication header
The catalog item register api call uses Organization key authentication, we can obtain one in the [Admin App](https://admin.dataminer.services/) on the Keys page. 
This key identifies your organization and will make sure the registration will register your catalog item under the organization of the key you use.

> [!Important]  
You need to have the "Owner" role in order to access/create Organization keys. 

Go ahead and create a new key with permission "Register catalog items".

![Organization Key](~/user-guide/images/tutorial_catatalog_registration_create_org_key.png)

After creation of the key, you can copy the key and use it as value in the **Ocp-Apim-Subscription-Key** header  

![Register item http header](~/user-guide/images/tutorial_catalog_registration_catalog_urlandheader.png)

## Step3: Register catalog item body

The body of the request expects form-data with key of type *File* and name *file*, the value is a zip containing

* a readme.md file with any required image in an images folder which will be shown in the description tab in the Catalog.  
Copy the below snippet and change the content as you see fit using your favorite editor.

```md
# Example_Rates_Custom

This is a connector that serves as example on how to integrate bit rates.

## About


This catalog item has been made available as part of the Catalog Registration [Tutorial](https://docs.dataminer.services/tutorials/Tutorials.html)
```

* a manifest.yml file describing the properties of the catalog item.  
Copy the below snippet and change the fields as you see fit using your favorite editor.

> [!Note]  
Make sure to obtain a new Guid to uniquely store and identify the catalog item.  
Navigate to [guidgenerator](https://guidgenerator.com/) and create a new one using format *hyphens* or use your prefered method.

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

type: 'connector'

# [Required] 
# The id of the catalog item.
# All registered versions for the same id are shown together in the catalog.
# This id can not be changed. 
# If the id is not filled in, the registration will fail with http status code 500. 
# If the id is filled in but does not exist yet, a new catalog item will be registered with this id.
# If the id is filled in but does exist, properties of the item will be overwritten
#   Must be a valid GUID.
id: '1742495c-9231-4eeb-a56e-1fec8189246e'

# [Required] 
# The human-friendly name of the catalog item. 
# Can be changed at any time.
#   Max length: 100 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
title: 'My Catalog Registration Example'

# [Optional]
# General information about the catalog item.
#   Max length: 100.000 characters
# Currently not shown in the Catalog UI but will be supported in the near future.
short_description: 'Example connector showing how to calculate bitrates and other rates on any changing numeric data.'

# [Optional]
# A valid URL that points to the source code.
#   A valid URL
#   Max length: 2048 characters
source_code_url: 'https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom'

# [Optional]
# A valid URL that points to documentation.
#   A valid URL
#   Max length: 2048 characters
# Currently not shown in the Catalog UI but will be supported in the near future.
# documentation_url: ''

# [Optional]
# People that are responsible for this catalog item. Might be developers but is not required.
# Format: 'name <email> (url)'
#   The name is required, max 256 characters.
#   The email and url are optional, and should be in valid email/URL formats.
owners:
  - name: 'john doe'
    email: 'john.doe@skyline.be'

# [Optional]
# Tags that allow you to categorize your catalog items.
#   Max length: 50 characters.
#   Can not contain newlines.
#   Can not contain leading or trailing whitespace characters.
tags:
  - 'example'
```

create a zip file containing the manifest and the readme and add it to the body of the request as shown below

![Register item http body](~/user-guide/images/tutorial_catatalog_registration_item_body.png)

## Step 4: Register
Send the call and upon correct registration you will receive HTTP Status 200 OK and the catalog id in the body of the response.

You can now search for you catalog item in the [Catalog](https://catalog.dataminer.services/browse) or navigate immediately to https://catalog.dataminer.services/details/{YourCatalogId}

![Registered catalog item](~/user-guide/images/tutorial_catatalog_registration_registered_item.png)

>[!note]  
After the first registration, you are able to make changes to the manifest or readme.md and execute the PUT request again, it will update the registered data as long as you use the same catalog id.
