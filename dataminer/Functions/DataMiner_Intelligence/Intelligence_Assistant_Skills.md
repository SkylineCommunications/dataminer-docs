---
uid: Intelligence_Skills
description: "Create and manage custom skills that give DataMiner Intelligence agents domain-specific workflows, instructions, and companion resources."
---

# Skills

Skills extend what DataMiner Intelligence agents can do. Each skill provides instructions and optional supporting resources such as scripts, templates, and reference material. Skills let agents reuse domain-specific workflows and best practices across conversations instead of relying only on one-off prompts.

## Why use skills

Skills are typically used for the following purposes:

- Adapt agents to domain-specific tasks and internal processes.
- Reduce repetition by authoring guidance once and reusing it automatically.
- Compose multiple skills to support more complex end-to-end workflows.

## How skills work

The agent receives the information provided by a skill progressively:

1. The skill description is used to determine when it may be relevant.
1. The instructions are loaded when the skill is triggered.
1. Supporting resources are only read and passed to the agent when needed.

This progressive loading model keeps context usage efficient because only relevant content is brought into the active context window.

## Skill components

A skill consists of the following components:

- **Name**: A unique, human-readable name that identifies the skill.
- **Description**: A short summary of what the skill does and when it should be used.
- **Instructions**: The guidance and procedures the agent follows when the skill is relevant.
- **Additional resources**: Optional supporting material, such as templates or playbooks.

> [!TIP]
> The *Description* field is critical for skill discovery. Write it as a clear trigger condition that tells the agent when to activate the skill.

## Creating and managing skills in the Assistant app

You can create and manage skills on the *Skills* page of the DataMiner Assistant app. This page displays all available skills in a searchable list.

![Skills page in the DataMiner Assistant app showing available skills in a searchable list](~/dataminer/images/AssistantDxM_SkillsOverview.png)<br>*Searchable skills list in the DataMiner Assistant app in DataMiner Web 10.7.1*

From this page, you can:

- **Search** for existing skills by name using the search bar.
- **Create a new skill** by clicking the *+ New skill* button.
- **Edit a skill** by clicking the pencil button next to the skill in the list.
- **Duplicate or delete a skill** by clicking the ellipsis button (...) next to a skill in the list. Selecting *Duplicate* creates a copy of the skill, pre-filled with the original data and an automatically generated unique name. Selecting *Delete* removes the skill.

> [!NOTE]
> The [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is not required to view existing skills, but it is required to create or edit skills.

## Authoring skills as files

For skills managed in source control or deployed through an Intelligence project, see [Authoring skills](xref:Authoring_Intelligence_skills).
