---
uid: Tutorial_Register_Catalog_Version
---

# Registering a new version of a connector in the Catalog

This tutorial demonstrates how to add a new version to a Catalog item using the [Catalog API](xref:Register_Catalog_Item).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom), so go ahead and download the solution.

## Prerequisites

- Organization key with permission "Register catalog items".
- A registered Catalog item, see [register a catalog item tutorial](xref:Tutorial_Register_Catalog_Item)
- [Skyline.DataMiner.CICD.Tools.Packager Nuget](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab).

## Overview

- [Step 1: Register Catalog version URL](#step-1-register-catalog-version-url)
- [Step 2: Authentication header](#step-2-authentication-header)
- [Step 3: Register Catalog version body](#step-3-register-catalog-version-body)
- [Step 4: Register](#step-4-register)

## Step 1: Register Catalog version URL

In order to register our first version, we will use the Catalog API Register version call.
Create a new Http request using the POST http method and url  <https://api.dataminer.services/api/key-catalog/v1-0/catalog/{catalogid}/version/register>

![Register version http url](~/user-guide/images/tutorial_catalog_registration_version_url.png)

> [!NOTE]  
> Make sure you use the same id as you used for the [Catalog item registration](xref:Tutorial_Register_Catalog_Item).

## Step 2: Authentication Header

Add the previously obtained organization key in the **Ocp-Apim-Subscription-Key** header.

![Register version http header](~/user-guide/images/tutorial_catalog_registration_version_headers.png)

## Step 3: Register Catalog version Body

The body of the version registration request requires a file containing our connector, for this we will be using the 
[Skyline.DataMiner.CICD.Tools.Packager NuGet](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab) to create a .dmprotocol package from our solution.

Navigate to [Example Rates connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom) and download the solution.

Open a terminal window and run below command to install the packager.

```powershell
dotnet tool install --global Skyline.DataMiner.CICD.Tools.Packager --version 2.0.3
```

Run the following command to create a .dmprotocol package, adapt the directory paths as needed.

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
