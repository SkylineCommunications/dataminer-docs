---
uid: Assistant_UserContext
---

# Adding custom user context

> [!IMPORTANT]
> The DataMiner Assistant app is an upcoming feature that is not yet available in current DataMiner versions. The information below provides a preview of what will be available in a future release and may be subject to change.

To help the DataMiner Assistant interpret information accurately within your organization's environment, you will be able to provide a dedicated user context file. This file will contain organization-specific information such as system structure, naming conventions, and operational rules. The Assistant will use this information to adapt its reasoning and responses accordingly.

Your custom user context will complement [Skyline's default context](xref:Assistant_Context), which includes system instructions, general data descriptions, and other baseline information. It will add insights that are specific to your environment.

This context may include, for example:

- A description of your organization and services.

- Custom naming schemes for elements, services, or parameters.

- Information about your DMA structure.

- A glossary with terms and acronyms specific to your organization.

Once added, this custom user context will become part of the Assistant's session context. This means the Assistant will automatically take it into account when interpreting your questions, alongside the general Skyline-provided context files.

## Best practices

- Avoid complex language and unnecessary information.

- Be clear. If the content is confusing, the Assistant may misinterpret it.

- Avoid redundant explanations. The Assistant already understands general DataMiner concepts.

- Focus on what is specific to your environment (names, systems, structures, priorities).

- Keep sections short and structured. Lists and tables help.

- Avoid including too many examples. This may limit the Assistant's flexibility in reasoning.
