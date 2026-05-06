---
uid: DH_Development
---

# Document Hub DevPack

## About

NuGet Class Library API to interact with DocumentHub functionality. It provides repositories and helpers for managing document categories, SharePoint configurations, and DOM sources, as well as a high-level API for file upload and read operations across multiple storage backends.

## Solution Structure

| Project             | Description                                                                                                 |
|---------------------|-------------------------------------------------------------------------------------------------------------|
| `DevPack`           | Core library containing models, repositories, exposers, `DocumentHubApiHelper`, and the `DocHubClient` API. |
| `DevPack.Installer` | DOM installer that provisions module settings, section definitions, and DOM definitions.                    |
| `DevPack.Tests`     | Unit tests covering CRUD operations, filter queries, and API validation for all components.                 |

## Installation

Install via NuGet:

```bash
dotnet add package Skyline.DataMiner.Dev.Utils.Solutions.DocumentHub
```

Or search for `Skyline.DataMiner.Dev.Utils.Solutions.DocumentHub` in the Visual Studio NuGet Package Manager.

## Getting Started

### Using the DocHubClient API

The `DocHubClient` provides a simplified interface for file operations:

```csharp
using Skyline.DataMiner.Solutions.DocumentHub.API.DocHubClient;

var client = new DocHubClient(connection);

// Upload a file to a document category
client.Files.UploadFile(category, @"C:\Documents\report.pdf");

// Upload with custom name
client.Files.UploadFile(category, filePath, name: "CustomName");

// Upload to DOM instance
client.Files.UploadFile(category, filePath, domInstanceId);

// Read files from a category
var files = client.Files.ReadFiles(category);

// Read files with filter
var filtered = client.Files.ReadFiles(category, filter: "invoice");
```

### Using the DocumentHubApiHelper

For direct repository access and DOM operations:

```csharp
var helper = new DocumentHubApiHelper(connection);

// Create a SharePoint configuration
helper.SharePointConfigurations.Create(new SharePointConfiguration
{
    TenantID = "your-tenant-id",
    ClientID = "your-client-id",
    ClientSecret = "your-client-secret",
    SiteURL = "https://contoso.sharepoint.com/sites/MySite",
    DocumentLibraryName = "Shared Documents",
});

// Read with filters
var results = helper.DocumentCategories.Read(
    DocumentCategoryExposers.Name.Equal("Technical Documentation"));
```

## Features

| Area                    | Description                                                                                          |
|-----------------------  |------------------------------------------------------------------------------------------------------|
| **File Operations**     | Upload and read files across configured storage backends                                             |
| **Storage Backends**    | Supports local DataMiner storage and SharePoint integration                                          |
| **Document Categories** | Organize documents by category with configurable storage types                                       |
| **DOM Repositories**    | Typed CRUD and filter operations for SharePoint configurations, DOM sources, and document categories |

## Requirements

- DataMiner System with DOM module enabled
- .NET Framework 4.8