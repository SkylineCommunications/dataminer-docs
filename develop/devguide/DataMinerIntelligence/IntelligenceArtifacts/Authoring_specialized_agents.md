---
uid: Authoring_Intelligence_specialized_agents
description: "Author custom DataMiner Intelligence agents as files, including metadata, references, instructions, and deployment validation."
---

# Authoring specialized agents

You can author a specialized agent as an `agent.md` file when you need source control, deployment automation, or configuration that is not managed through the Assistant app.

If you only want to create and manage specialized agents through the native DataMiner Assistant app, see [Specialized agents](xref:Intelligence_Specialized_Agents).

## Agent file location

Each specialized agent file must be named `agent.md` and placed in a folder identified by the agent's GUID under:

```text
C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\Agents
```

For example:

```text
Agents/
|-- 5ac4633a-2ebc-40bb-81c5-ee50d8d2259e/
|   `-- agent.md
`-- b7f1a9c0-3d4e-4f8a-9c2b-1a2b3c4d5e6f/
    `-- agent.md
```

These files are automatically discovered and synchronized across the cluster.

## Agent file format

The file must contain YAML frontmatter followed by the agent instructions in Markdown. Declare the schema explicitly.

```markdown
---
name: Roadmap Expert
description: Answer roadmap questions using approved roadmap data sources and workflows.
version: 1.0.0
schema-version: '2.0'
tools:
  - roadmap-items
skills:
  - roadmap-inquiry
---

# Roadmap intake agent

Answer roadmap questions using the assigned tools and skills.
Do not guess when the required roadmap information is unavailable.
```

The following fields are available:

- `name`: Required. A unique agent name with a maximum of 128 characters. Agent names cannot contain control characters.
- `description`: An optional description with a maximum of 1,024 characters.
- `tools`: An optional list of data and script tool identifiers.
- `skills`: An optional list of skill identifiers.
- `agents`: An optional list of non-empty GUIDs identifying delegation targets.
- `user-facing`: An optional Boolean that controls whether clients show the agent in agent selectors. It defaults to `true`.

The agent body can contain behavioral guidelines, workflows, rules, field definitions, querying logic, tool usage instructions, and output requirements. It has a maximum length of 32,768 characters.

Tool and skill references must resolve to the intended artifacts. The Assistant service performs additional checks for target availability, reserved agents, self-delegation, and active delegation cycles.

Validate the project before deployment. For all supported fields and schema versions, see the [Intelligence artifact schema reference](xref:Intelligence_artifact_schemas).
