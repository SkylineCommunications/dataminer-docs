---
uid: Assistant_ScriptTools
description: "Script tools let specialized agents run approved DataMiner Automation scripts with defined inputs, controlled execution, and user-visible results."
---

# Assistant script tools

Script tools allow [specialized agents](xref:Assistant_Specialized_Agents) to execute automation scripts as part of a conversation. They are designed to actively operate or make changes in a DataMiner System instead of retrieving data only.

For example, a specialized agent can use a script tool to start maintenance, apply a configuration, trigger a provisioning workflow, or perform another controlled automation action. The script itself remains an automation script; the script tool provides the description, inputs, usage rules, and execution behavior that make the script available to the agent.

## Basic principles

Script tools are only available to an agent if both of the following conditions are met:

- They have been correctly configured with an automation script, along with its usage and execution behavior.
- They have been added as a reference to specialized agent.

During a conversation, the Assistant initially uses only the script tool name and description to determine whether the tool may be relevant. If it is relevant, the Assistant retrieves the remaining tool information, including the parameters and context. The agent then collects or confirms the required inputs, executes the script, and uses the result or error to continue the conversation.

## Execution flow

### 1. The agent selects the tool

The Assistant initially compares the user's request with the script tool name and description. It does not use the parameters or context at this stage. If the tool appears relevant, the Assistant retrieves that additional information, and the agent evaluates whether the requested action matches the script's purpose.

If the request does not provide a required value, or a value is ambiguous, the Assistant asks the user for clarification before invoking the script.

### 2. The Assistant requests user confirmation

If user confirmation is required, the Assistant asks the user to confirm the action before the script starts. This is recommended for scripts that make changes, restart services, delete data, or perform other irreversible operations.

The chat confirmation shows the script name and the values that will be passed to the script. This allows the user to review exactly what they are allowing before selecting **Allow**. Selecting **Skip** prevents that invocation from running.

The script runs in the user's DataMiner context through an impersonated connection. The connection can be reused for subsequent script executions and remains open for at least 15 minutes after it is created. After a script finishes, it remains open for at least 15 minutes after the last script execution.

### 3. The script runs

The execution mode determines whether the current conversation waits for the result:

- **Synchronous execution**: This is the default mode. The Assistant will wait for the script to finish and can use its output or error in the current response. The wait is limited to 30 minutes, and no further interaction is possible while the Assistant is waiting.

- **Asynchronous execution**: The Assistant returns immediately with a queued message while the script continues in the background. The current response does not wait for or use the script output. Execution errors are detected and reported instead of being treated as a successful start.

### 4. The agent reports the outcome

When a synchronous script finishes within the wait period, its output or execution error is returned to the agent. The agent can then explain the result, ask for a follow-up action, or report the error to the user.

Key/value output added by the script through [`Engine.AddOrUpdateScriptOutput`](xref:Skyline.DataMiner.Automation.Engine.AddOrUpdateScriptOutput*) is added to the context window after the script finishes. The Assistant can use this output to formulate the response, for example by summarizing the result or reporting values returned by the script.

If a synchronous script does not finish within 30 minutes, it continues running in the background. The Assistant reports that no response was received within the wait period. The output, errors, and completion events from that execution are not available in the current response.

## Interaction and resource limits

- A maximum of 50 scripts can run in parallel for the same user.
- Cancelling a chat or closing the Assistant stops the Assistant from waiting for an in-progress script. The automation script itself can continue running on the DataMiner System.
- A timeout or cancellation does not roll back changes already made by the automation script, so if you design scripts that perform important changes, make sure these handle partial completion safely.

## Designing reliable script tools

- Give each tool one clear operational purpose. Use separate tools when actions have different side effects or require different approvals.
- Use synchronous execution when the agent must inspect the result before responding or taking another action.
- Use asynchronous execution for operations where the user only needs the action to be started and the current conversation does not depend on the result.
- Require user confirmation for destructive or high-impact operations.

## Creating or editing script tools in the Assistant app

You can create script tools on the *Tools* page of the Assistant app with the *+ New tool* button or edit them using the pencil button next to the tool on that page (see [Creating and managing tools](xref:Assistant_Tools)).

When you create or edit a script tool, you will need to configure the following fields:

- **Name**: A unique identifier for the tool, which must meet the following restrictions:

  - Must be lowercase and may only contain letters, digits, and hyphens.
  - Cannot start or end with a hyphen.
  - Cannot contain consecutive hyphens (`--`).
  - Maximum 128 characters.

- **Type**: *Script*. For information about the *Data* type, refer to [Data tools](xref:Assistant_DataTools).

- **Description**: A brief description of when the script should be used. This helps the Assistant decide when to pick this tool. Maximum 1024 characters.

- **Script**: The automation script to execute. Select the appropriate script from the dropdown.

- **Parameters**: Input arguments for the script. For each parameter, the following fields are available:

  - **Name**: The parameter name. Must match a script parameter.
  - **Example**: An example value that helps the Assistant determine the appropriate input. Maximum 1024 characters.
  - **Description**: A description that helps the Assistant determine the appropriate input value. Maximum 1024 characters.

- **Context**: Additional instructions or context about the script, such as the script's purpose, prerequisites, side effects, expected result, and likely errors. This will help the Assistant understand the usage, expected behavior, and any important details. Maximum 8192 characters.

- **User confirmation**: Determines whether the user must confirm before the script runs. Select *Confirm* to require confirmation, or *None* to run without an additional confirmation.

## Configuring script tool files

Instead of using the Assistant app, you can also add or edit script tools directly as Markdown files in the following folder: `C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\Scripts`

These files are automatically discovered and synced across the cluster.

The files must be markdown (`.md`) files that are configured as follows:

- The files must have a [YAML front matter, configured as detailed below](#script-tool-file-yaml-front-matter).
- The body of the files (maximum 8192 characters) must contain specific context about the script to help the Assistant understand its usage, expected behavior, and any important details. This includes when the script should and should not be used, its prerequisites and side effects, the expected result, and likely errors. Keep the instructions focused on one operational purpose.
- Each file must define one script tool.

### Script tool file YAML front matter

The front matter must include the following fields:

- `name`: Required. A unique identifier for the tool. Must be lowercase and may only contain letters, digits, and hyphens. Cannot start or end with a hyphen, and cannot contain consecutive hyphens (`--`). Maximum 128 characters.

- `description`: Required. A brief description of the script. This helps the Assistant decide when to pick this tool. Maximum 1,024 characters.

- `scriptName`: Required. The Automation script to execute.

- `sync`: Optional. Controls execution behavior. Defaults to `true` when omitted.

  - `true`: The Assistant waits for the script result. The wait is limited to 30 minutes. If the script does not finish in time, it continues in the background.
  - `false`: Trigger-and-forget execution. The Assistant returns a queued message while the script runs in the background. Execution errors are still detected and reported.

- `requiresUserValidation`: Optional. When `true`, the Assistant must ask the user to confirm before executing the script. Defaults to `true` when omitted. Set this to `false` only for scripts that do not need user confirmation.

- `inputArguments`: Optional. A list of input arguments. Each argument should be described by the following fields:

  - `name`: The parameter name. Must match a script parameter.
  - `example`: An example value that helps the Assistant determine the appropriate input. Maximum 1024 characters.
  - `description`: A description that helps the Assistant determine the appropriate input value. Maximum 1024 characters.

## Example: script tool

```markdown
---
name: maintenance
description: Script to perform Maintenance on a certain device
scriptName: Maintenance.AS
sync: true
requiresUserValidation: false
inputArguments:
  - name: "elementName"
    example: "MyComputer"
---

## Usage Example

**User**: "I want to start maintenance on MyComputer"

## Error Handling

**Missing elementName**: Ask user to provide valid value
```
