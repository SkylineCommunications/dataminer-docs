---
uid: Tutorial_Register_Catalog_Version
---

# Registering a new version of a connector in the Catalog

This tutorial demonstrates how to add a new version to a Catalog item using the [Catalog API](xref:Register_Catalog_Item).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom), so go ahead and download the solution.

## Prerequisites

- An [organization key](xref:Managing_DCP_keys#organization-keys) or "Owner" role in order to access/create organization keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_DCP_user)
- A registered Catalog item, see [register a catalog item tutorial](xref:Tutorial_Register_Catalog_Item) for an example on how to register an item.
- [Skyline.DataMiner.CICD.Tools.Packager Nuget](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab).

## Overview

- [Step 1: Register Catalog version URL](#step-1-register-catalog-version-url)
- [Step 2: Authentication header](#step-2-authentication-header)
- [Step 3: Register Catalog version body](#step-3-register-catalog-version-body)
- [Step 4: Register](#step-4-register)

## Step 1: Register Catalog version URL

In order to register our first version, we will use the register version call from the Catalog API.
Create a new HTTP request using the POST http method and URL
`https://api.dataminer.services/api/key-catalog/v1-0/catalog/{catalogId}/version/register`

![Register version http url](~/user-guide/images/tutorial_catalog_registration_version_url.png)

> [!IMPORTANT]  
> Make sure to change the catalogId route parameter to the Catalog ID you want to register the version to.
> This is the ID you used to register the [catalog item](xref:Register_Catalog_Item#registering-a-catalog-item-with-the-api).  
> You can always obtain it from an existing Catalog item by navigating to the details page of it in the [Catalog](https://catalog.dataminer.services/), the ID is the last part of the URL.

## Step 2: Authentication Header

The Catalog Version register API call is authenticated using an [organization key](xref:Managing_DCP_keys#organization-keys), we can obtain one in the [Admin App](https://admin.dataminer.services/) on the `Keys` page.
This key identifies your organization and will make sure the registration will register your Catalog item under the correct organization.

> [!IMPORTANT]
> You need to have the "Owner" role in order to access/create organization keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_DCP_user) for information on how to change a role for a user.

Go ahead and create a new key with permission "Register catalog items".

![Organization Key](~/user-guide/images/tutorial_catalog_registration_create_org_key.png)

After creation of the key, you can copy the key and use it as value in the **Ocp-Apim-Subscription-Key** header.

![Register version http header](~/user-guide/images/tutorial_catalog_registration_version_headers.png)

## Step 3: Register Catalog version Body

The body of the version registration request requires a file containing our connector, for this we will be using the 
[Skyline.DataMiner.CICD.Tools.Packager NuGet](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab) to create a `.dmprotocol` package from our solution.

Navigate to [Example Rates connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom) and download the solution.

Open a terminal window and run below command to install the packager.

```powershell
dotnet tool install --global Skyline.DataMiner.CICD.Tools.Packager --version 2.0.3
```

Run the following command to create a `.dmprotocol` package, adapting the directory paths as needed.

```powershell
dataminer-package-create dmprotocol "C:\Tutorials\Catalog Registration\SLC-C-Example_Rates-Custom-1.0.1.X" --name catalog_registration_tutorial --output "C:\Tutorials\Catalog Registration\Packages"
```

Add the following to the **multipart/form-data** body of the request

- The earlier created *dmprotocol* file in key of type **File** with name **file**.
- The **version number** in key of type **Text** with name **versionNumber**.
- The **version description** in key of type **Text** with name **versionDescription**.

![Register version http body](~/user-guide/images/tutorial_catalog_registration_version_body.png)

## Step 4: Register

Execute the call and upon correct registration you will receive HTTP Status 200 OK and the Catalog ID, artifact ID in the body of the response.
You will be able to see the registered version on the Catalog in the **versions** tab.

![Registered version](~/user-guide/images/tutorial_catalog_registration_registered_version.png)
