---
uid: DashboardAssistantChat
description: Learn how to use the assistant chat visualization in dashboards and low-code apps, including its configuration options and component action.
keywords: AI assistant, chat component, AI component, DataMiner Assistant, Copilot
---

# Assistant chat

The assistant chat component lets you use **DataMiner Assistant to chat with [DataMiner Intelligence agents](xref:Intelligence_Agents) directly from a dashboard or low-code app**. You can submit questions using text or voice input and, depending on the available configuration, choose a response mode and AI model before sending your request.

![Assistant chat component displayed in a DataMiner low-code app](~/dataminer/images/AssistantChat.png)<br>*Assistant chat component in DataMiner Web 10.6.9.*

> [!NOTE]
> To use the assistant chat component, you need to have the necessary user permissions and your system must meet the requirements for DataMiner Intelligence. See [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started#requirements).

## Interacting with the assistant chat component

![Assistant chat component UI showing question input, response mode selector, AI model selector, microphone, and send button](~/dataminer/images/Assistant_Chat_UI.png)<br>*Assistant chat component in DataMiner Web 10.6.9.*

To interact with the DataMiner Assistant, use the following areas of the assistant chat component:

- (1): Enter a question or request for the Assistant.

- (2): Choose whether the Assistant should prioritize response speed or more in-depth answers.

- (3): Choose the AI model that will process your request.

- (4): Select the microphone icon to dictate a question instead of typing it.

- (5): Submit your question to the Assistant.

## Configuration options

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the *Settings* pane provides the following options:

| Section | Option | Description |
|--|--|--|
| General | Agent | Select the DataMiner Intelligence agent that will handle chat conversations. For example, select *DataMiner Docs* to get answers based on the official documentation. |
| General | Title | Specify the text displayed at the top of the component. |
| General | Subtitle | Specify the text displayed below the title. |

## Assistant chat component actions

Component actions are operations that can be executed on a component when an event is triggered.

When you select the [*Execute component action* option](xref:LowCodeApps_event_config#executing-a-component-action), you can choose from a list of components in the app and the specific actions available for each of them.

For the assistant chat component, the following component action is available:

- *Start new conversation*: Starts a new conversation with the DataMiner Assistant without requiring you to interact directly with the assistant chat component itself.

  When configuring this action, you can specify either:

  - A fixed value to send as a query to the Assistant.

  - A dynamic value, such as the value of another component (for example, a text input component) or a URL parameter.

  When the action is triggered, the value is sent to the Assistant as a query.

  ![Assistant chat starting a new conversation from a button using text input value](~/dataminer/images/AssistantChat.gif)<br>*Assistant chat component started through a "Start new conversation" component action using the value entered in a text input (DataMiner Web 10.6.9).*
