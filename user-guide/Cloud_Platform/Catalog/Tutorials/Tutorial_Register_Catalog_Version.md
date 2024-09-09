---
uid: Tutorial_Register_Catalog_Version
---

# Registering a catalog version

This tutorial demonstrates how to add a new version to a catalog item using the [Catalog API](xref:Catalog_Registration).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom), so go ahead and download the solution.

## Prerequisites

- Organization key with permission "Register catalog items".
- A registered catalog item, see [register a catalog item tutorial](xref:Tutorial_Register_Catalog_Item)

## Overview

- [Step 1: Register catalog version URL](#step1-register-catalog-version-url)
- [Step 2: Authentication header](#step2-authentication-header)
- [Step 3: Register catalog version body](#step-3-register-catalog-version-body)
- [Step 4: Register](#step-4-register)

## Step 1: Register Catalog version URL
In order to register our first version, we will use the catalog API Register version call.
Create a new Http request using the POST http method and url  <https://api.dataminer.services/api/key-catalog/v1-0/catalog/{catalogid}/version/register>

![Register version http url](~/user-guide/images/tutorial_catatalog_registration_version_url.png)

>[!note]
Make sure you use the same id as you used for the [catalog item registration](xref:#Register_Catalog_Item).

## Step 2: Authentication Header
Add the previously obtained organization key in the **Ocp-Apim-Subscription-Key** header.

![Register version http header](~/user-guide/images/tutorial_catatalog_registration_version_headers.png)

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

Add the file to the body as seen below and define versionNumber and versionDescription as well in the form-data

![Register version http body](~/user-guide/images/tutorial_catatalog_registration_version_body.png)

## Step 4: Register

Upon succesful registration, you will be able to see the registered version on the catalog in the versions tab.

![Registered version](~/user-guide/images/tutorial_catatalog_registered_version.png)