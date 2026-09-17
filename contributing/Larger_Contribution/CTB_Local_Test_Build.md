---
metadata_version: 1
uid: CTB_Local_Test_Build
description: Build the DataMiner documentation locally with DocFX and validate metadata, UIDs, tables of contents, cross-references, and Markdown warnings.
area: contributing
content_type: conceptual
authority: reference
authority_source: CTB_Documentation_Metadata
lifecycle: active
applies_to:
  - DataMiner documentation
version: unversioned
owner: unknown
review_status: approved
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Making a local test build before pushing changes

Before you push your changes to the repository, it is often a good idea to make a test build on your local machine. This is especially the case if your changes involve adding or removing files, adding cross-references, changing headers, and/or updating a toc.yml file.

To be able to make a local test build, you need to have DocFX installed. DocFX is the static website generator that is used under the hood to create the <https://docs.dataminer.services/> website.

## Installing and configuring DocFX

1. Install .NET 6.0 SDK or higher from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

1. Open a command prompt and enter the command `dotnet tool update -g docfx`

1. Test whether DocFX was installed correctly by entering `docfx --version`.

    If information similar to the following text is returned, DocFX was installed correctly:

    ```txt
    2.75.1+6aa697f56975e85e82c5a6b81b71157c77302270
    ...
    ```

> [!TIP]
> Alternative ways to install DocFX can be found on the [DocFX website](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool).

> [!NOTE]
> If you use this "dotnet" command, it is no longer necessary to add the DocFX folder to the Windows Path variable as was the case in the past. If you configured this earlier, we recommend that you remove this folder from the Path variable again and reboot.

### Making a test build

### Making a test build using buildDocs.cmd

1. Make sure **.NET 6.0 SDK or higher** is installed on your machine. You can download the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

1. Go to the root folder of the repository on your local machine, e.g., `C:\GitHub\dataminer-docs\dataminer-docs`.

1. Double-click the file *buildDocs.cmd*.

   This will open a command window where the following commands will run:

   - `dotnet restore "src/NuGetPackages"`

   - `dotnet build "src/NuGetPackages" --configuration Release`

   - `docfx metadata`

   - `docfx build`

   - `docfx serve _site`

1. In a browser, go to <http://localhost:8080/> to preview the website.

   > [!NOTE]
   > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

1. When you have finished previewing the website, close the command window.

> [!NOTE]
> If port 8080 is not available, you will need to run *buildDocs.cmd* from a command prompt with the correct port as an argument, e.g., `buildDocs 8081`.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. Depending on your DocFX version, these can pile up and take up a large amount of memory in the long run.

## Checking documentation metadata

For pages that contain `metadata_version: 1`, validate the complete front matter object against `contributing/metadata/documentation-metadata-v1.schema.json` with a JSON Schema Draft 2020-12 validator before running the DocFX build. The schema rejects missing fields, values outside the controlled lists, undocumented metadata keys, invalid dates, and ambiguous unknown values.

Use the following deterministic sequence:

1. Validate the front matter against the version 1 schema.

1. Run `docfx metadata`.

1. Run `docfx build --warningsAsErrors`.

The DocFX build validates UIDs, TOC entries, cross-references, and Markdown integration. It does not replace JSON Schema validation. For fields that cannot yet be confirmed, use the exact `unknown` or `not_applicable` sentinel required by the schema. Do not use an empty value or invent an owner.

### Making a test build in the Visual Studio Code terminal

If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can also run these commands manually in the Visual Studio Code terminal. This has the advantage that you do not need to run all of the commands every time, so your test builds can be generated more quickly.

1. If no Terminal pane is open in Visual Studio Code, go to *Terminal > New Terminal*.

1. In the Terminal pane, do the following:

   1. Enter `clear` to clear the terminal.

   1. Enter the following commands:

      - `dotnet restore "src/NuGetPackages"`

      - `dotnet build "src/NuGetPackages" --configuration Release`

      - `docfx metadata`

      - `docfx build`

      - `docfx serve _site`

      > [!NOTE]
      >
      > - The first three commands are needed to generate the API docs. If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can skip these three commands after your first build.
      > - This step requires that **.NET 6.0 SDK or higher** is installed on your machine. If this is not installed yet, you will get a build error. You can download the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

   1. In a browser, go to <http://localhost:8080/> to preview the website.

      > [!TIP]
      > If you are not able to access localhost:8080, you can specify a different port by entering e.g., `docfx serve _site -p 8090`.

      When you have finished previewing the website, in the Terminal pane, press Ctrl+C to exit the preview mode.

      > [!NOTE]
      > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. Depending on your DocFX version, these can pile up and take up a large amount of memory in the long run.
