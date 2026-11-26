---
uid: DataMinerIntelligence
description: "Develop DataMiner Intelligence artifacts and integrate Document Intelligence to provide reusable instructions, tools, and document context."
---

# DataMiner Intelligence

With DataMiner Intelligence, you can create agents that use your domain knowledge and DataMiner tools, and analyze documents programmatically from your applications.

> [!NOTE]
> This guide is for developers who author Intelligence artifacts as files or integrate Document Intelligence through Automation. If you want to use or configure DataMiner Intelligence through the native DataMiner web apps, see [About DataMiner Intelligence](xref:DataMiner_Intelligence).

## Intelligence artifacts

Intelligence artifacts are Markdown files containing YAML frontmatter and a Markdown body. Agents define behavior, skills provide reusable knowledge or procedures, and tools describe access to existing automation scripts, GQI ad hoc data sources, or DOM data. These artifacts are not GitHub Copilot or Visual Studio Code custom agents.

Use an Intelligence SDK project to author and validate artifacts before packaging them for deployment. The metadata contract depends on the artifact type and declared schema version; a successful build does not establish that a referenced tool is available or authorized on a target system.

- [Getting started with Intelligence artifacts](xref:Creating_Intelligence_artifacts): Create and validate your first agent and reusable skill.
- [Authoring tools](xref:Adding_tools_to_an_intelligence_agent): Connect an agent to existing scripts, GQI sources, and DOM data.
- [Intelligence artifact schemas](xref:Intelligence_artifact_schemas): Metadata fields, version semantics, and validation constraints for each artifact type.

## Document Intelligence

[Document Intelligence](xref:DocumentIntelligence) provides an API for analyzing documents with custom instructions through the DataMiner Assistant DxM. Its existing API reference remains available under this section.
