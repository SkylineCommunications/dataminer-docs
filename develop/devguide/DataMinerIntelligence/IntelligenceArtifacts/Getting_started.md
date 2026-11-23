---
uid: Creating_Intelligence_artifacts
description: "Get started with DataMiner Intelligence artifacts by creating an agent and reusable skill, validating their metadata, and testing their behavior."
---

# Getting started with Intelligence artifacts

Create an Intelligence project, then add your first intelligence agent and reusable reporting skill. This example summarizes evidence supplied by the requester; it does not require live data sources or automation scripts. You can also use an existing Intelligence project.

## Prerequisites

- Compatible versions of `Skyline.DataMiner.Sdk` and `Skyline.DataMiner.Sdk.Intelligence`. The Intelligence templates require SDK 2.7.1 or later.
- An Intelligence SDK validator and target DataMiner Assistant that support schema 1.1, used by the examples below.
- The .NET SDK and official Intelligence project and item templates from `Skyline.DataMiner.VisualStudioTemplates`, available through your configured NuGet sources.

If your installed templates generate schema 1.0, update `schema-version` to `'1.1'` when editing the artifacts below. This does not change the artifact's own `version`.

Check template availability with `dotnet new list dataminer-intelligence`. If needed, install the template package:

```powershell
dotnet new install Skyline.DataMiner.VisualStudioTemplates
```

> [!NOTE]
> This guide uses .NET CLI commands to keep the steps concise and reproducible; the CLI is not required. You can also use the Visual Studio UI: select the Intelligence project template when adding a project, or right-click an artifact's destination folder and select *Add* > *New Item* > the appropriate DataMiner Intelligence template. To run the same artifact validation, right-click the project and select *Build*.

## Create an Intelligence project

If you already have a project using `Skyline.DataMiner.Sdk.Intelligence` and `<DataMinerType>Intelligence</DataMinerType>`, skip to [Create an agent and skill](#create-an-agent-and-skill).

1. From the directory where you want to add the project, generate it in a new folder.

   ```powershell
   dotnet new dataminer-intelligence-project --name IncidentIntelligence --ProjectName IncidentIntelligence --output IncidentIntelligence --IncludeGitHubWorkflow None
   ```

   This example does not add a GitHub Actions workflow. In Visual Studio, you can instead add a project using the DataMiner Intelligence project template.

   The template also generates `global.json` in the parent directory to pin SDK versions. When adding to an existing solution, preview the changes with `--dry-run` and preserve existing SDK configuration; do not use `--force` to overwrite it.

2. Open the generated project directory.

   ```powershell
   cd IncidentIntelligence
   ```

## Create an agent and skill

1. Open a terminal in the directory containing the Intelligence project's `.csproj` file.

2. Generate the agent in its destination folder.

   ```powershell
   dotnet new dataminer-intelligence-agent-file --name incident-summary --output Agents
   ```

3. Generate the skill in its destination folder.

   ```powershell
   dotnet new dataminer-intelligence-skill-file --name incident-reporting --output Skills
   ```

4. Replace the skill's generated content with the following example.

   ```markdown
   ---
   name: incident-reporting
   description: Produce an incident summary from verified evidence and identify missing information.
   version: 1.0.0
   schema-version: '1.1'
   ---

   # Incident reporting

   Include the incident identity, observed impact, evidence, and unresolved questions.
   Distinguish observations from assumptions. Do not invent causes or recovery results.
   ```

5. Update the agent's metadata and Markdown body using the following example, keeping its generated `id` field and GUID unchanged.

   The `id` below is illustrative. Retain the GUID already in your generated file instead of copying this example value. Do not generate a new ID when editing the same agent.

   ```markdown
   ---
   id: 182bf397-78fa-415b-bfe9-47886727f16b
   name: incident-summary
   description: Summarize incident evidence without changing the DataMiner System.
   version: 1.0.0
   schema-version: '1.1'
   skills:
     - incident-reporting
   ---

   # Incident summary

   Use incident-reporting to summarize evidence supplied by the requester.
   Ask for missing incident identifiers or evidence. Do not claim access to live data.
   Do not execute changes or report recovery without supporting evidence.
   ```

6. Build the project to validate the artifacts.

   ```powershell
   dotnet build
   ```

   Resolve validation diagnostics before using the artifacts. The example uses schema 1.1 but does not require delegation. For supported fields and delegation metadata, see [Schema 1.1](xref:Intelligence_artifact_schema_1_1).

## Test the agent

In an authorized target environment, test that the agent summarizes supplied evidence, identifies missing information, and does not invent causes or recovery results. A successful build validates metadata but does not prove the agent follows its instructions at runtime.

## Next steps

Follow [Adding tools to an intelligence agent](xref:Adding_tools_to_an_intelligence_agent) to connect the agent to existing automation scripts, GQI sources, or DOM data. Consult the [schema reference](xref:Intelligence_artifact_schemas) for version rules and supported metadata.
