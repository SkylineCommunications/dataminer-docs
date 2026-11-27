---
uid: Intelligence_ScriptTools
description: "Configure script tools that let specialized DataMiner Intelligence agents run approved automation scripts with defined inputs and confirmation rules."
---

# Script tools

Script tools let [specialized DataMiner Intelligence agents](xref:Intelligence_Specialized_Agents) run automation scripts as part of a conversation. They can perform actions in a DataMiner System rather than only retrieving data.

For example, a specialized agent can use a script tool to start maintenance, apply a configuration, trigger a provisioning workflow, or perform another controlled automation action. The script itself remains an automation script; the script tool provides the description, inputs, usage rules, and execution behavior that make the script available to the agent.

## Basic principles

Script tools are only available to an agent if both of the following conditions are met:

- They have been correctly configured with an automation script, along with its usage and execution behavior.
- They have been added as a reference to a specialized agent.

During a conversation, the agent initially uses only the script tool name and description to determine whether the tool may be relevant. If it is relevant, the agent retrieves the remaining tool information, including the parameters and context. The agent then collects or confirms the required inputs, executes the script, and uses the result or error to continue the conversation.

## Execution flow

### 1. The AI agent selects the tool

The agent compares your request with the script tool name and description. It does not use the parameters or context at this stage. If the tool appears relevant, it retrieves that additional information to evaluate whether the requested action matches the script's purpose.

If the request does not provide a required value, or a value is ambiguous, the agent asks for clarification before invoking the script.

### 2. The Assistant requests user confirmation

If user confirmation is required, DataMiner Assistant asks you to confirm the action in chat before the script starts. This is recommended for scripts that make changes, restart services, delete data, or perform other irreversible operations.

The chat confirmation shows the script name and the values that will be passed to the script. This allows you to review exactly what you are allowing before selecting *Allow*. Selecting *Skip* prevents that invocation from running.

### 3. The script runs

The execution mode determines whether the current conversation waits for the result:

- **Synchronous execution**: This is the default mode. The agent waits for the script to finish and can use its output or error in the current response. The wait is limited to 30 minutes, and you cannot continue the chat in the meantime.
- **Asynchronous execution**: The Assistant returns immediately with a queued message while the script continues in the background. The current response does not wait for or use the script output.

The script runs in the user's DataMiner context through an impersonated connection. The connection can be reused for subsequent script executions and remains open for at least 15 minutes after it is created. After a script finishes, it remains open for at least 15 minutes after the last script execution.

### 4. The agent reports the outcome

When a synchronous script finishes within the wait period, its output or execution error is returned to the agent. The agent can then explain the result, ask for a follow-up action, or report the error to you.

Key/value output added by the script through [Engine.AddOrUpdateScriptOutput](xref:Skyline.DataMiner.Automation.Engine.AddOrUpdateScriptOutput*) is added to the agent's context window after the script finishes. The agent can use this output to summarize the result or report values returned by the script.

If a synchronous script does not finish within 30 minutes, it continues running in the background. The Assistant reports that no response was received within the wait period. The output, errors, and completion events from that execution are not available in the current response.

## Interaction and resource limits

- A maximum of 50 scripts can run in parallel for the same user.
- Canceling a chat or closing the DataMiner Assistant app stops the wait for an in-progress script. The automation script itself can continue running on the DataMiner System.
- A timeout or cancellation does not roll back changes already made by the automation script, so if you design scripts that perform important changes, make sure these handle partial completion safely.

## Designing reliable script tools

- Give each tool one clear operational purpose. Use separate tools when actions have different side effects or require different approvals.
- Use synchronous execution when the agent must inspect the result before responding or taking another action.
- Use asynchronous execution for operations where you only need the action to be started and the current conversation does not depend on the result.
- Require user confirmation for destructive or high-impact operations.

## Creating or editing script tools in the Assistant app

You can create script tools on the *Tools* page of the Assistant app with the *+ New tool* button or edit them using the pencil button next to a tool (see [Creating and managing tools](xref:Intelligence_Tools)).

When you create or edit a script tool, configure the following fields:

- **Name**: A unique identifier using lowercase letters, digits, and single hyphens, with a maximum of 128 characters.
- **Type**: *Script*.
- **Description**: A description of when to use the script. The maximum length is 1,024 characters.
- **Script**: The automation script to execute.
- **Parameters**: Input arguments whose names match script parameters. Each parameter can have an example and description, each with a maximum length of 1,024 characters.
- **Context**: Instructions about the script's purpose, prerequisites, side effects, expected result, and likely errors. The maximum length is 8,192 characters.
- **User confirmation**: Whether the user must confirm before the script runs.

## Authoring script tools as files

For script tools managed in source control or deployed through an Intelligence project, see [Authoring tools](xref:Adding_tools_to_an_intelligence_agent).
