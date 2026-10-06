---
uid: Assistant_Specialized_Agents
---

# Specialized agents

> [!IMPORTANT]
> This is an experimental feature. You can already try it out and experiment with it, but keep in mind that it is currently still further being developed.

A specialized agent is a user-configured agent that bundles a name, description, instructions, and a curated set of references into a reusable entity. When invoked, the agent operates according to its instructions and has access only to the references assigned to it, making it focused and predictable.

Unlike [native agents](xref:Assistant_Agents#native-agents), which are built-in, specialized agents are fully user-defined and tailored to specific use cases or workflows.

## Why use specialized agents

Specialized agents are typically used for the following purposes:

- Create purpose-built agents for specific operational workflows or domains.
- Control exactly which tools and knowledge an agent can access.
- Provide tailored instructions so the agent behaves consistently for its intended task.
- Enable team members to interact with complex processes through a simple conversational interface.

For example, you could use them for the following use cases:

- **Incident triage agent**: An agent with instructions to guide users through incident classification, referencing data tools for alarm data and a skill with escalation procedures.
- **Capacity planning agent**: An agent that queries resource and booking data through data tools, applies planning logic from a skill, and generates reports using a script tool.
- **Customer health agent**: An agent designed for call center operators that pulls account data, recent alarms, and service-level metrics through data tools, cross-references known issues using a skill, and summarizes overall account health so the operator can quickly assist the customer.

## Creating specialized agents

<!-- TBD -->

### Validation constraints

The following validation rules are applied when you create or update a specialized agent:

| Field | Constraint |
| --- | --- |
| Name | Required. Maximum 128 characters. Control characters such as tabs and new lines are not allowed. |
| Description | Maximum 1024 characters. |
| Instructions | Maximum 32,768 characters. |

If a field exceeds its limit, a descriptive error is returned indicating which field is too long and by how much. These limits keep agent definitions well-formed and protect response quality by preventing oversized content from being pulled into the AI context.

## Interacting with specialized agents

To interact with specialized agents in the Assistant app, use the agent selector at the bottom of the chat window. All available specialized agents are listed there alongside the native agents.

Selecting a specialized agent directs your conversation to that agent, which will respond according to its configured instructions and references.
