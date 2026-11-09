---
name: "Update documentation"
description: "Update DataMiner documentation. Use for Add RN, Review, Update docs with an RN, Add KI, Add desc, Detect dead links, and Make new release files."
argument-hint: "Add RN <ID> | Review | Update docs with <ID> | Add KI <draft> | Add desc | Detect dead links [folder] | Make new release files <versions>"
---

# Update documentation

Use the skills below to carry out documentation tasks. Load the selected skill's `SKILL.md` before acting, using the skill-loading tool when available or reading the linked file otherwise. Follow its complete procedure, constraints, and output format. Do not merely describe how the user could do the task.

## Command routing

Match commands case-insensitively and accept equivalent natural-language requests.

| Request | Skill | Input |
|---------|-------|-------|
| `Add RN <ID>` | [add-RN](../skills/add-rn/SKILL.md) | Any valid release note ID |
| `Review` | [review-house-style](../skills/review-house-style/SKILL.md) | Current page, selected section, supplied paths, or pasted text |
| `Update docs with <ID>` | [update-docs-with-RN](../skills/update-docs-with-rn/SKILL.md) | Any valid release note ID |
| `Add KI` followed by a draft | [publish-known-issue](../skills/publish-known-issue/SKILL.md) | Draft known issue and supplied version details |
| `Add desc` | [add-description](../skills/add-description/SKILL.md) | Current page or supplied path |
| `Detect dead links` | [detect-dead-links](../skills/detect-dead-links/SKILL.md) | Optional folder; otherwise the whole repository, including Mermaid diagrams |
| `Make new release files` | [new-files-for-release](../skills/new-files-for-release/SKILL.md) | Main Release/CU and Feature Release versions |

Skill identifiers and folder names use lowercase, so the RN skills are named `add-rn` and `update-docs-with-rn`.

## Input handling

1. Extract supplied IDs, paths, draft text, versions, and review mode from the request and current editor context. Do not ask again for information already supplied.
1. If a page-scoped command has no explicit target, use the active page or selected section when available. Ask for the target if that context is missing or ambiguous.
1. Ask only for missing required inputs, using the available question tool. For a bare `Review`, ask whether to apply changes or list issues, as required by the review skill.
1. For multiple requested tasks, load and run each relevant skill, respecting prerequisites. Do not execute unrelated workflows.

## Execution

- Execute the selected skill directly in the current conversation. Do not delegate routine documentation work or tool discovery to subagents.
- Use only the tools needed by the selected skill, and preserve its approval requirements and fallback behavior.

### SkylineApi retrieval for RN requests only

These rules apply only to `Add RN` and `Update docs with` requests, including equivalent natural-language requests. Other commands do not require SkylineApi discovery or retrieval.

- At the selected skill's retrieval step, use the SkylineApi release-note retrieval tool directly. If its definition is not already available in the current conversation, discover it using the tool-search tool first.
- Use the returned release-note data to continue the selected skill. Do not repeatedly rediscover the same tool or retrieve the same RN again unless the data is incomplete or a refresh is needed.
- If discovery or retrieval fails, report the concrete failure and follow the selected skill's fallback. Do not launch subagents to expose tools or repeat discovery attempts without new information.

## Boundaries

- `Add RN` publishes a release note under `release-notes`; it does not automatically update the user or developer guide.
- `Update docs with` analyzes an RN's impact on the user and developer guides; it does not automatically publish a release note.
- Dead-link detection is read-only.
- House-style review edits only when the user selects that mode.
- Follow repository instructions and the selected skill. Never invent release versions, product facts, or missing source content.
- Preserve unrelated changes. Do not commit, push, or update Collaboration data unless explicitly requested.
