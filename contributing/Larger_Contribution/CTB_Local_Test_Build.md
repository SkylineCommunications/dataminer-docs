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

   - `.\scripts\validate-documentation-dependency-map.ps1 -RepositoryRoot . -ReportPath .\_artifacts\documentation-dependency-map.json`

   - `.\scripts\resolve-documentation-coupling.ps1 -RepositoryRoot . -OutputPath .\_artifacts\documentation-coupling.json`

   - `dotnet restore "src/NuGetPackages"`

   - `dotnet build "src/NuGetPackages" --configuration Release`

   - `docfx metadata`

   - `.\scripts\generate-generated-metadata-provenance.ps1 -RepositoryRoot . -OutputPath .\_artifacts\generated-metadata-provenance.json -RequireGeneratedOutputs`

   - `.\scripts\validate-generated-metadata-provenance.ps1 -RepositoryRoot . -Path .\_artifacts\generated-metadata-provenance.json`

   - `.\scripts\generate-ai-content-manifest.ps1 -RepositoryRoot . -OutputPath .\_artifacts\ai-content-manifest.json`

   - `.\scripts\validate-ai-content-manifest.ps1 -RepositoryRoot . -Path .\_artifacts\ai-content-manifest.json`

   - `.\scripts\generate-internal-topic-packs.ps1 -RepositoryRoot . -ManifestPath .\_artifacts\ai-content-manifest.json -OutputPath .\_artifacts\internal-only-topic-packs`

   - `.\scripts\validate-internal-topic-packs.ps1 -RepositoryRoot . -Path .\_artifacts\internal-only-topic-packs\internal-only-topic-pack-manifest.json`
   - `.\scripts\generate-html-source-metadata.ps1 -RepositoryRoot . -DocFxConfigPath .\docfx.json -OutputPath .\_artifacts\html-source-metadata.json -EditBranch main`

   - `.\scripts\validate-html-source-metadata.ps1 -RepositoryRoot . -Path .\_artifacts\html-source-metadata.json`

   - `docfx build --warningsAsErrors`

   - `.\scripts\generate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -GeneratedProvenancePath .\_artifacts\generated-metadata-provenance.json -OutputPath .\_artifacts\segmented-sitemap-report.json`

   - `.\scripts\validate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -ReportPath .\_artifacts\segmented-sitemap-report.json`

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

For pages that contain `metadata_version: 1`, validate the complete front matter object against `contributing/metadata/documentation-metadata-v1.schema.json` before running the DocFX build. The repository validator reads that schema as its sole source of allowed fields and values. It rejects missing fields, values outside the controlled lists, undocumented metadata keys, invalid dates, and ambiguous `unknown` or `not_applicable` values. Pages without `metadata_version: 1` remain on the legacy migration path and are skipped by the default repository-wide check.

Use the following deterministic sequence:

1. Validate all opted-in pages from the repository root:

   ```powershell
   .\scripts\validate-documentation-metadata.ps1 -RepositoryRoot .
   ```

   For a new page, require version 1 metadata explicitly:

   ```powershell
   .\scripts\validate-documentation-metadata.ps1 -RepositoryRoot . -Path .\path\to\new-page.md -RequireVersion1
   ```

   For the completed D2.2 Connector and Automation guide/schema scopes, verify the deterministic migration and identity report:

   ```powershell
   .\scripts\migrate-documentation-metadata.ps1 -RepositoryRoot . -CheckOnly -ReportPath .\d2-2-metadata-migration-report.json
   .\scripts\audit-documentation-metadata-migration.ps1 -RepositoryRoot . -ReportPath .\d2-2-metadata-migration-report.json
   ```

1. Validate D6.1 ownership, authority, review cadence, stale-content thresholds, and governance evidence:

   ```powershell
   .\scripts\validate-documentation-governance.ps1 -RepositoryRoot . -ReportPath .\_artifacts\documentation-governance.json
   ```

   The governance report records metadata-only findings. It reports unresolved owner or authority values as follow-up gaps and does not invent handles or fail the documented migration path.

1. Validate the D6.2 dependency map and resolve the repository change coupling report:

   ```powershell
   .\scripts\test-documentation-dependency-map.ps1
   .\scripts\validate-documentation-dependency-map.ps1 -RepositoryRoot . -ReportPath .\_artifacts\documentation-dependency-map.json
   .\scripts\resolve-documentation-coupling.ps1 -RepositoryRoot . -OutputPath .\_artifacts\documentation-coupling.json
   ```

   For a product change, pass `-ChangePath` and use `-FailOnUnmapped -FailOnGate`. The report lists the affected UIDs and areas and the targeted checks. It keeps unresolved release, package, dispatch, and ownership values explicit.

1. Run `docfx metadata`.

1. Generate and validate the machine-readable provenance for the generated schema and API outputs:

   ```powershell
   .\scripts\generate-generated-metadata-provenance.ps1 -RepositoryRoot . -OutputPath .\_artifacts\generated-metadata-provenance.json -RequireGeneratedOutputs
   .\scripts\validate-generated-metadata-provenance.ps1 -RepositoryRoot . -Path .\_artifacts\generated-metadata-provenance.json
   ```

   The provenance generator records source project, assembly, XML documentation, package, overwrite, and generated-output hashes. It records schema documentation identities and versions only when the repository can prove them. Missing external schema packages and unavailable build outputs are reported as gaps; no package version or lifecycle date is inferred.

1. Generate and validate the metadata-only AI content manifest:

   ```powershell
   .\scripts\generate-ai-content-manifest.ps1 -RepositoryRoot . -OutputPath .\_artifacts\ai-content-manifest.json
   .\scripts\validate-ai-content-manifest.ps1 -RepositoryRoot . -Path .\_artifacts\ai-content-manifest.json
   .\scripts\test-llms-discovery.ps1
   Copy-Item .\_artifacts\ai-content-manifest.json .\ai-content-manifest.json -Force
   ```

   The D3.1 manifest records stable UIDs, URLs, immutable source pointers, normalized source hashes, documentation metadata, and dependency identifiers. It does not contain page text, chunks, summaries, or embeddings. Pass `-PriorManifestPath` when comparing a new revision with a previous D3.1 manifest so moves and removals are emitted explicitly.

1. Generate and validate the internal-only D3.2 Connector and Automation Markdown topic packs:

   ```powershell
   .\scripts\generate-internal-topic-packs.ps1 -RepositoryRoot . -ManifestPath .\_artifacts\ai-content-manifest.json -OutputPath .\_artifacts\internal-only-topic-packs
   .\scripts\validate-internal-topic-packs.ps1 -RepositoryRoot . -Path .\_artifacts\internal-only-topic-packs\internal-only-topic-pack-manifest.json
   ```

   These packs contain normalized/transformed prose and are permitted only for internal use under D0.3. They must not be redistributed publicly or used for model training or fine-tuning. The generator writes them outside the DocFX content tree with explicit `internal-only` filenames and 14-day operational retention metadata.

1. Generate and validate the metadata-only deployment delta:

   ```powershell
   .\scripts\generate-deployment-delta.ps1 -RepositoryRoot . -CurrentManifestPath .\_artifacts\ai-content-manifest.json -OutputPath .\_artifacts\deployment-delta.json
   .\scripts\validate-deployment-delta.ps1 -RepositoryRoot . -Path .\_artifacts\deployment-delta.json
   ```

   The D5.2 delta compares two commit-addressed D3.1 manifests when `-PreviousManifestPath` is supplied. It reports additions, content changes, moves, deprecations, removals, immutable redirect mappings, and removed UID/URL tombstones. When no previous manifest is available, it records first-run semantics instead of failing. A no-change comparison produces an empty delta. Ambiguous identity matches are reported without guessing a move or redirect.
1. Generate and validate the rendered HTML source metadata:

   ```powershell
   .\scripts\generate-html-source-metadata.ps1 -RepositoryRoot . -DocFxConfigPath .\docfx.json -OutputPath .\_artifacts\html-source-metadata.json -EditBranch main
   .\scripts\validate-html-source-metadata.ps1 -RepositoryRoot . -Path .\_artifacts\html-source-metadata.json
   ```

   The generator derives `dateModified` from source Git history and emits commit-pinned source links only when the source file is unchanged and the commit can be resolved. It does not use deployment time or invent D2 metadata values.

1. Run `docfx build --warningsAsErrors`.

1. Sanitize the generated public DocFX manifest before serving or packaging the site:

   ```powershell
   .\scripts\sanitize-public-manifest.ps1 -Path .\_site\manifest.json
   ```

   This removes checkout-root paths, runner details, and ambiguous empty `version` fields while preserving source-relative paths, output paths, and xref compatibility data.

1. Generate and validate the segmented sitemap output:

   ```powershell
   .\scripts\generate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -GeneratedProvenancePath .\_artifacts\generated-metadata-provenance.json -OutputPath .\_artifacts\segmented-sitemap-report.json
   .\scripts\validate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -ReportPath .\_artifacts\segmented-sitemap-report.json
   ```

   The root `sitemap.xml` remains the discovery URL listed in `robots.txt` and now indexes deterministic area/content-type segments. Page `lastmod` values come from the last Git commit that changed the source page. Generated API pages use the D2.3 provenance mapping when a repository source is available; external or unmapped generated outputs are recorded as gaps instead of receiving the deployment time.

The DocFX build validates UIDs, TOC entries, cross-references, and Markdown integration. It does not replace metadata validation. For fields that cannot yet be confirmed, use the exact `unknown` or `not_applicable` sentinel required by the schema. Do not use an empty value or invent an owner.

Treat warnings introduced by your change as failures. If the build reports a warning that predates your change, record it separately in the pull request and do not suppress it or describe it as fixed by the metadata check.

### Making a test build in the Visual Studio Code terminal

If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can also run these commands manually in the Visual Studio Code terminal. This has the advantage that you do not need to run all of the commands every time, so your test builds can be generated more quickly.

1. If no Terminal pane is open in Visual Studio Code, go to *Terminal > New Terminal*.

1. In the Terminal pane, do the following:

   1. Enter `clear` to clear the terminal.

   1. Enter the following commands:

      - `dotnet restore "src/NuGetPackages"`

      - `dotnet build "src/NuGetPackages" --configuration Release`

      - `docfx metadata`

      - `.\scripts\generate-generated-metadata-provenance.ps1 -RepositoryRoot . -OutputPath .\_artifacts\generated-metadata-provenance.json -RequireGeneratedOutputs`

      - `.\scripts\validate-generated-metadata-provenance.ps1 -RepositoryRoot . -Path .\_artifacts\generated-metadata-provenance.json`

      - `.\scripts\generate-ai-content-manifest.ps1 -RepositoryRoot . -OutputPath .\_artifacts\ai-content-manifest.json`

      - `.\scripts\validate-ai-content-manifest.ps1 -RepositoryRoot . -Path .\_artifacts\ai-content-manifest.json`
      - `.\scripts\generate-html-source-metadata.ps1 -RepositoryRoot . -DocFxConfigPath .\docfx.json -OutputPath .\_artifacts\html-source-metadata.json -EditBranch main`

      - `.\scripts\validate-html-source-metadata.ps1 -RepositoryRoot . -Path .\_artifacts\html-source-metadata.json`

      - `.\scripts\test-llms-discovery.ps1`

      - `Copy-Item .\_artifacts\ai-content-manifest.json .\ai-content-manifest.json -Force`

      - `docfx build --warningsAsErrors`

      - `.\scripts\sanitize-public-manifest.ps1 -Path .\_site\manifest.json`

      - `.\scripts\generate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -GeneratedProvenancePath .\_artifacts\generated-metadata-provenance.json -OutputPath .\_artifacts\segmented-sitemap-report.json`

      - `.\scripts\validate-segmented-sitemaps.ps1 -RepositoryRoot . -SitePath .\_site -ReportPath .\_artifacts\segmented-sitemap-report.json`

      - `docfx serve _site`

      > [!NOTE]
      >
      > - The first five commands are needed to generate and fingerprint the API docs. If you make repeated test builds to check changes you have made, and you are only making changes to markdown files, you can skip these five commands after your first build.
      > - This step requires that **.NET 6.0 SDK or higher** is installed on your machine. If this is not installed yet, you will get a build error. You can download the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

   1. In a browser, go to <http://localhost:8080/> to preview the website.

      > [!TIP]
      > If you are not able to access localhost:8080, you can specify a different port by entering e.g., `docfx serve _site -p 8090`.

      When you have finished previewing the website, in the Terminal pane, press Ctrl+C to exit the preview mode.

      > [!NOTE]
      > Using the search box when viewing the test website on <http://localhost:8080/> will not return any pages from the test website. The search engine only indexes the published content on <https://docs.dataminer.services/> and will, as such, only return pages from that website.

> [!IMPORTANT]
> If you make test builds often, you may need to occasionally clear the files in the `\dataminer-docs\obj\.cache\build\` folder of your local version of the documentation. Depending on your DocFX version, these can pile up and take up a large amount of memory in the long run.
