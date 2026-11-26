---
uid: Adding_tools_to_an_intelligence_agent
description: "Author tool artifacts that connect Intelligence agents to existing automation scripts, GQI data sources, and DOM data."
---

# Authoring tools

Tools describe access to existing capabilities. This guide extends the agent from [Getting started with Intelligence artifacts](xref:Creating_Intelligence_artifacts) with script, ad hoc data source, and DOM tools.

> [!NOTE]
> The backing script, GQI data source, and DOM model in this guide are hypothetical. Their implementations are not supplied or created by this tutorial. The examples demonstrate tool metadata; they cannot be invoked as written unless you provide matching capabilities or adapt the metadata to your own solution.

## Prerequisites

- DataMiner 10.7.1 or later.
- The official Intelligence templates from `Skyline.DataMiner.VisualStudioTemplates` installed.

## Create tool artifacts

> [!NOTE]
> The CLI commands below keep the examples concise and reproducible. You can also create tools in Visual Studio: right-click the appropriate `Scripts`, `AdHoc`, or `Dom` folder and select *Add* > *New Item* > the matching DataMiner Intelligence template. To run the same artifact validation, right-click the project and select *Build*.

From the directory containing the Intelligence project's `.csproj`, run only the commands for the tool types you need:

```powershell
dotnet new dataminer-intelligence-script-file --name export-incident --output Scripts
dotnet new dataminer-intelligence-data-source-file --name query-incidents --output AdHoc
dotnet new dataminer-intelligence-dom-file --name incident-records --output Dom
```

The examples use schema 1.1; update the generated `schema-version` if needed. Replace illustrative identities and bindings with values from your solution. Tool artifacts do not create backing scripts, sources, or DOM models. For field details, see [Schema 1.1](xref:Intelligence_artifact_schema_1_1).

### Script tool

The following example describes a hypothetical `ExportIncident` automation script. Adapt its identity and inputs to your actual script:

```markdown
---
name: export-incident
description: Run the existing incident export script for a supplied incident identifier.
version: 1.0.0
schema-version: '1.1'
scriptName: ExportIncident
sync: true
requiresUserValidation: true
inputArguments:
  - name: Incident ID
    description: The identifier of the incident to export.
    example: INC-123
---

Export only the incident requested by the operator. Explain errors without claiming success.
```

Verify the script definition and reachable code before exposing it. Script input entries do not have a `type` field. An operator-interactive script is not a suitable non-interactive tool.

### Ad hoc data source tool

The following example describes a hypothetical `Incidents` GQI data source. Adapt its identity, arguments, and columns to your actual source:

```markdown
---
name: query-incidents
description: Query incident records from the existing incident data source.
version: 1.0.0
schema-version: '1.1'
dataSource: '{"DataSourceInterface":"Skyline.DataMiner.Analytics.GenericInterface.IGQIDataSource","ScriptName":"IncidentDataSources","LibraryName":"IncidentDataSources","TypeFullName":"IncidentDataSources.Incidents","TypeName":"Incidents"}'
inputArguments:
  - name: Scope
    type: string
    description: The scope to query.
    example: production
columns:
  - name: Incident ID
    type: string
    description: The identifier of the incident record.
  - name: Summary
    type: string
    description: A short description of the incident.
---

Use the requested scope and report the returned records. An empty result is not proof of recovery.
```

The `dataSource` field is a YAML string containing the serialized GQI source reference, not a display name or a YAML mapping. Single quotes around the JSON preserve its double-quoted property names and values. The hypothetical reference above expands to:

```json
{
  "DataSourceInterface": "Skyline.DataMiner.Analytics.GenericInterface.IGQIDataSource",
  "ScriptName": "IncidentDataSources",
  "LibraryName": "IncidentDataSources",
  "TypeFullName": "IncidentDataSources.Incidents",
  "TypeName": "Incidents"
}
```

| JSON property | Meaning |
|--|--|
| `DataSourceInterface` | Normally `Skyline.DataMiner.Analytics.GenericInterface.IGQIDataSource`. |
| `ScriptName` | The deployed automation script's name, as specified by `<Name>` in its script XML. |
| `LibraryName` | The value of `<Param type="libraryName">` in the script XML's precompiled C# `<Exe>` block. |
| `TypeFullName` | The data source class name including its namespace, for example `IncidentDataSources.Incidents`. |
| `TypeName` | The data source class name without its namespace, for example `Incidents`. |

For example, these parameters in the script XML's C# `<Exe>` block specify the library used above:

```xml
<Param type="preCompile">true</Param>
<Param type="libraryName">IncidentDataSources</Param>
```

Use the exact property names, casing, and values from the deployed source's GQI selection value. Do not infer the reference from a display name or assume that the script, library, and namespace always match. This JSON selects the implementation; it is not a complete GQI query and does not contain invocation argument values. Describe inputs separately in `inputArguments`.

Reconcile every declared input, including optional inputs, and every documented column with the GQI implementation. Each column can have an optional `description` explaining its meaning; this metadata does not change the source's returned values.

### DOM tool

The following example describes a hypothetical `incident-management` DOM module and definition. Replace their identities with those from your actual model:

```markdown
---
name: incident-records
description: Retrieve records from the existing incident DOM definition.
version: 1.0.0
schema-version: '1.1'
module: incident-management
definition: '11111111-1111-4111-8111-111111111111'
columns:
  - name: Incident ID
    type: string
    description: The identifier of the incident record.
  - name: Summary
    type: string
    description: A short description of the incident.
---

Retrieve incident records relevant to the request. Do not infer missing status or ownership.
```

Replace the example module and definition with identities from your target model, and match both column names and types to the data exposed by that model. The two columns above are hypothetical, not built-in DOM fields.

## Attach and verify tools

1. Add verified tool identifiers to the agent frontmatter, preserving its other metadata.

   ```yaml
   tools:
     - export-incident
     - query-incidents
     - incident-records
   ```

   Include only tools you created and verified. Use tool artifact identifiers, not backing script or source names.

2. Check that each reference resolves exactly once to its intended tool artifact.

3. Update the agent's instructions to state when to use each tool and which actions require confirmation.

4. Build the project and resolve validation diagnostics.

   ```powershell
   dotnet build
   ```

5. Test tool invocation, permissions, and failure cases in an authorized target environment.

  A successful build does not prove that a backing capability exists or that its arguments bind correctly at runtime.
