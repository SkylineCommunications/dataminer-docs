---
uid: Assistant_AddingContextFiles
---

# Adding context files

> [!IMPORTANT]
> The DataMiner Assistant app is an upcoming feature that is not yet available in current DataMiner versions. The information below provides a preview of what will be available in a future release.

Context files provide background information, rules, and logic about specific DataMiner concepts. These files help the Assistant reason about the system and provide accurate answers. **Only Skyline Communications employees can add or edit context files at this stage.** The instructions below are for internal use only.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    If you are looking for information about adding context specific to your organization, which will be possible once the Assistant becomes available, you might be looking for <a href="xref:Assistant_UserContext" style="color: #657AB7;">custom user context</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## How to contribute a context file

There are two ways to add a new context file:

- **Via GitHub**:

  1. Fork the private [*DataMinerAssistant* repository](https://github.com/SkylineCommunications/DataMinerAssistant) containing the context files.

  1. Add your new markdown file to the `Context` folder, following the template below.

     > [!TIP]
     > See [Contributing guide: Adding a new page](xref:CTB_Adding_New_Page).

  1. Create a pull request to submit your changes.

- **Via Team Documentation**: Send a markdown file directly to [Team Documentation](mailto:documentation@skyline.be), following the template below. They will review your file for language, structure, and clarity before merging it into the repository.

## Best practices

- Follow the structure of the [template](#context-file-template) and maintain consistent formatting.

- Avoid complex language and unnecessary information.

- Be clear. If the content is confusing, the Assistant may misinterpret it.

- Avoid duplicate information.

- Keep sections short and structured. Lists and tables help.

- Avoid including too many examples. This may limit the Assistant's flexibility in reasoning.

- Avoid including speculative or incomplete information.

## Context file template

Below is a template you can use to write a new context file. Replace the placeholders with information relevant to your DataMiner topic. Examples are included in comments to illustrate the expected structure. Make sure to remove these examples before submitting your context file.

```md
# <Concept name>

<!-- Example: # Alarms -->

## Background information

<Provide an overview of the concept.>

<!-- Example: In DataMiner, an alarm is a notification indicating a condition or event requiring attention. Alarms are triggered by predefined thresholds, user-defined conditions, or background processes.-->

### <Subtopic 1>

<!-- Example: ### Clearable alarms-->

<Describe key details for the subtopic.>

<!-- Example:
- When an alarm is clearable, the issue has been resolved but the alarm record still remains open.
- `Status = Clearable`
-->

### <Subtopic 2>

<!-- Example: ### Masked alarms-->

<Describe key details for the subtopic.>

<!-- Example:
- A masked alarm is an alarm that a user has deliberately suppressed for a period of time or until it is unmasked or cleared.
- `Comments` field: Provides more information about the masked alarm, e.g. who masked it, when was it masked, and how long will it remain masked. For example: `Element masked by <name> @ 2025-08-28 08:43:38 until unmasking`
-->

### <Subtopic 3>

<!-- Example: ### Interpretation guidelines-->

<Describe key details for the subtopic.>

<!-- Example:
- The age of an active alarm (how long it has been active) does not reflect its seriousness.
- Severity levels `Normal` and `Suggestion` are not considered alarms.
- An alarm is resolved when `Status = Cleared`.
- (...)
-->

## Rules

### General rules

<Provide general rules for interpreting, using, or reporting this concept.>

<!-- Example:
- Always use values from the provided dataset; NEVER invent names, parameters, severities, or numbers.
- Validate whether all element, parameter, time, and service names exist in the dataset before including them.
- (...)
-->

### (Optional) Counting rules

<Provide rules for counting, filtering, or interpreting items.>

<!-- Example:
- Active alarms:
  - `Is active = 1`.
  - `Status ∈ {Open, Clearable, Mask}`.
  - `Severity ∈ {Warning, Minor, Major, Critical, Notice, Error, Timeout}`.
- Masked alarms:
  - `Is active = 1`
  - `Status = Mask`.
  - `Severity ∈ {Warning, Minor, Major, Critical, Notice, Error, Timeout}`
- (...)
-->

### (Optional) Formatting rules

<Include formatting rules.>

<!-- Example:
- When generating a table of alarms, always include these columns, if available:
  - `#`
  - `Element name`
  - `Parameter description`
  - `Value`
  - `Severity`
  - `Root time`
  - `Status`
- (...)
-->

## (Optional) Situations and response rules

Each situation is **mutually exclusive**. Only follow the one that matches the user request most closely.

### Situation: <Situation name>

<!-- Example: ### Situation: Active alarms needing attention -->

**Trigger**: <Describe when this situation applies.>

<!-- Example: **Trigger**: When the user asks what active alarms need attention. -->

**Instructions**:

- <Step 1 of the response instructions.>
- <Step 2 of the response instructions.>
- <Include formatting rules, charts, or tables if relevant.>

<!-- Example:
- Respond with a to-do list of active alarms that should be addressed first.
- Ask whether the user would like specific resolution steps for these alarms.
- Use **bold** for element and parameter names.
-->
```

> [!NOTE]
> The *Situations and response rules* section is optional. Only include it if you want the Assistant to handle certain questions in a specific way. If no situations are defined, the Assistant will respond to user questions as it deems appropriate based on the available context.
