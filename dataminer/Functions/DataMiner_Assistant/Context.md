---
uid: Assistant_Context
---

# Context structure

> [!IMPORTANT]
> The DataMiner Assistant is an upcoming feature that is not yet available in current DataMiner versions. The information below provides a preview of how this functionality will work once released.

The DataMiner Assistant relies on context to interpret questions and provide accurate answers. This context is not limited to what you type in a chat message. It also includes background instructions, descriptive files, and data definitions that shape how the Assistant understands and analyzes your DataMiner System.

The context consists of several layers:

| Type | Description |
|--|--|
| System instructions | Define how the Assistant should behave, write, and respond. These are loaded at the start of every chat session. |
| [Context files](xref:Assistant_AddingContextFiles) | Contain background information, rules, and logic about DataMiner concepts. These files help the Assistant reason about the system. |
| Data source descriptions | Describe the structure of the data the Assistant can access. |
| User prompt | The message you type in the chat, e.g. "Which alarms require immediate attention?" |
| [User context](xref:Assistant_UserContext) | Optional organization-specific information that customizes the Assistant’s understanding of your environment. |

When you start a new chat session, the DataMiner Assistant will first load the general system instructions to understand its purpose, tone, and behavioral rules. It will then access the relevant context files and data source descriptions depending on your question.

The system instructions, context files, and data source descriptions are maintained by Skyline Communications. In the future, this context will be available as a public GitHub repository, where anyone can propose changes. All contributions will be reviewed by Skyline's Context Engineering team.

While the system context will be managed by Skyline Communications, you will still be able to influence how effectively the Assistant responds.

- **Write clear and specific user prompts** to help the Assistant understand exactly what you need.

- **Provide custom user context** to give the Assistant information about your environment, naming conventions, and workflows. See [Adding custom user context](xref:Assistant_UserContext).
