---
uid: Intelligence_Data_Privacy_Security
description: "Learn how DataMiner Intelligence controls access and how its agent framework handles encryption, data residency, retention, and logging."
---

# Data privacy and security

This page explains how access to DataMiner Intelligence is controlled and how its agent framework handles data, including conversations through DataMiner Assistant. For information about document processing, see [Document Intelligence data security and privacy](xref:docintel#data-security-and-privacy).

## AI infrastructure and data residency

The DataMiner Intelligence agent framework uses models hosted on **Microsoft Azure** and is currently limited to Azure OpenAI Services, though other models will also be supported in later releases. The models are hosted and consumed in Azure and not directly from OpenAI or other model providers. The services used by the agent framework provide the following data privacy guarantees:

- Azure OpenAI and other model services used operate under Microsoft's enterprise security and compliance framework, separate from OpenAI's or other model providers' consumer service compliance frameworks.
- Models are deployed in specific Azure regions to ensure data **remains within a defined geographical zone**. Data does not leave the region in which it is processed.

  > [!NOTE]
  > Currently, AI traffic for the agent framework is processed in the **West Europe** Azure region (Amsterdam) and does not leave that region. For EU/EEA customers, this means data never leaves the European Economic Area, helping to reduce the need for cross-border data transfer safeguards under GDPR Chapter V (e.g., Standard Contractual Clauses or adequacy decisions). Support for additional Azure regions is planned, allowing users in other parts of the world to benefit from equivalent data residency guarantees within their own region.

- All processing happens within Skyline's Azure tenant, meaning your data never leaves the Skyline Communications tenant boundary. This provides an additional layer of isolation from other customers and services of Microsoft.

## Data encryption

Data sent to and from the DataMiner Intelligence agent framework is encrypted using industry-standard TLS (Transport Layer Security) protocols. This ensures that:

- Data in transit between your DataMiner System and the agent framework infrastructure is protected from unauthorized access.
- Encryption is applied at the network level, regardless of the type of data being transmitted.

Additionally, data at rest is encrypted using Azure-managed encryption keys, ensuring protection even when data is stored (see [data retention](#data-retention)).

## Data retention

The Azure models used by the agent framework are **stateless**: the models do not store prompts or completions during inference. Prompts and completions are not used to train, retrain, or improve base models.

The DataMiner Assistant module running on the DataMiner server stores conversation history in memory so you can continue the current chat. Later, the conversation details will also be stored in the DataMiner database so you can resume previous conversations and read earlier chat history. When this is available, you will be able to delete conversations in DataMiner Assistant.

In the cloud, Microsoft Azure applies the following data handling practices:

- **Inferencing (prompts and responses)**: Prompts and generated responses are processed by the models in real time and are not stored in the model. They are not used to train, retrain, or improve base models.
- **Abuse monitoring**: By default, Azure retains a sample of prompts and completions temporarily for abuse monitoring purposes, to detect use that may violate Microsoft's terms of service. The data is retained only for the duration necessary to complete the abuse monitoring process; Microsoft does not publicly specify an exact retention period. This data is stored within the same Azure geography as the deployed resource (currently West Europe for the agent framework). It is logically isolated per customer resource and can only be accessed by authorized Microsoft personnel in the event of a flagged violation. For deployments within certain Azure regions, those authorized reviewers are also located within the same region.

On the DataMiner side, some data is retained for logging purposes. At this time, logging exists both on the DataMiner server (on-premises or in the cloud depending on the deployment) and in the dataminer.services cloud (Azure). The following data handling practices apply:

- Server-side logs use a loop configuration (last in, first out) with a fixed number of lines and include detailed data such as the question, the answer, and intermediate processing steps. The effective on-premises retention period therefore depends on usage.
- Cloud-side logs contain both temporary and long-term logs. The temporary logs contain the question and answer for a limited time, while long-term logs only contain the question asked. These logs will only be consulted by Skyline employees with permission of the customer and when strictly necessary for supporting the customer in case of questions or issues, or with enhancements of the product.

Currently, no setting is available to prevent these server- and cloud-side logs from being stored.

No data is used for training foundation models or shared outside the Skyline Communications Azure tenant. Microsoft is very strict about this and ensures this to the entire community and especially to Skyline Communications as a Certified Software Partner. For more details, see [Microsoft's data, privacy, and security documentation for Azure OpenAI](https://learn.microsoft.com/en-us/azure/foundry/responsible-ai/openai/data-privacy).

## User permissions

Starting from its initial release in DataMiner 10.7.0/10.7.1, access to DataMiner Intelligence is controlled through DataMiner user permissions and a system-wide setting:

- The [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access) user permission is required to use DataMiner Intelligence capabilities.

  On DataMiner versions prior to 10.7.0/10.7.1 that already support Document Intelligence, this permission is not yet required to use Document Intelligence.

- The [General > DataMiner Intelligence > Assistant app](xref:DataMiner_user_permissions#general--dataminer-intelligence--assistant-app) user permission is required to access the Assistant app from the landing page.

- The system-wide *DataMiner Intelligence* web apps setting (see [Enabling DataMiner Intelligence](xref:Intelligence_Getting_Started#enabling-dataminer-intelligence)) controls whether DataMiner Intelligence is available throughout the DataMiner System.

  Changing this setting requires both the [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access) and the [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission. Users who do not have these permissions see the setting as read-only.

- DataMiner Intelligence agents respect your role-based access control (RBAC) configuration, so you can only view and interact with data that your DataMiner permissions allow you to access. Documentation lookup with the DataMiner Docs agent is typically available to all users who have access to the DataMiner Assistant app.

For more information on managing DataMiner user permissions, see [User management](xref:User_management).

## Data usage and AI model training

**The agent framework does not use your data to train or improve AI models.** The Azure AI Services it uses provide enterprise data isolation controls:

- Azure guarantees that the prompts (inputs) and the model's outputs are **not used to train or improve foundation models** without explicit authorization. The agent framework does not authorize this use.
- Azure does not retain your questions, system data, or configuration information for model training.
- All user interactions remain confidential and are used exclusively to serve your requests within your session.

This approach ensures that your proprietary system information, business logic, and operational data remain completely isolated from any model training processes, by either Skyline or Microsoft.

## Compliance and standards

The DataMiner Intelligence agent framework uses the Azure OpenAI Service with the following security and privacy controls:

- Data handling follows GDPR compliance principles where applicable.
- Azure infrastructure is certified to ISO 27001, SOC 2, and other major compliance frameworks.
- Data residency controls ensure data stays within the designated geographical zone (West Europe only for now).
- Microsoft enterprise security standards apply to all data processing within the Skyline tenant.
- Regular security audits and penetration testing validate the security posture. For broader platform-level details, see [DataMiner compliance offering](xref:DataMiner_compliance_offering#annual-security-assessment) and [Skyline Communications and DataMiner security](xref:Skyline_and_DataMiner_security).

For specific compliance requirements in your organization, contact your Skyline Communications representative.

## FAQ

### How does the DataMiner Assistant reduce hallucinations?

Hallucinations are incorrect or misleading model outputs presented as if they were factual. The DataMiner Intelligence agent framework uses the following measures to reduce hallucinations in DataMiner Assistant responses.

1. Out-of-the-box agent measures:

   - Agents receive context and instructions that encourage evidence-based reasoning before they present conclusions.
   - Agents receive guidance to answer only when confidence is sufficiently high.
   - Structured response formats are used to enforce more disciplined and transparent outputs.

1. Grounding in trusted context and data:

   - Ground agents in trusted data and context.
   - A large portion of the DataMiner-specific context is provided out of the box such that the agent does not hallucinate about standard DataMiner concepts such as alarms, masking alarms etc.
   - Extend the coverage of your DataMiner digital twin and give agents context and skills specific to your environment to reduce incorrect answers about it.

The agent framework does not currently include out-of-the-box protections such as dedicated verification agents, strict tool-usage constraints, or workflow-based guardrails. Review results critically, especially when using agents to execute autonomous actions. If you enable autonomous actions, test relevant scenarios first and continuously monitor outcomes in production.

### What is prompt injection, and how is it mitigated?

Prompt injection is an attempt to manipulate AI behavior through crafted instructions in user input or retrieved content, for example by trying to override higher-priority instructions.

Basic mitigation measures are already in place:

- Dedicated instructions enforce separation between instructions and data or other external content.
- Fine-tuned context based on best practices restricts the model as much as possible to execute only against the actual instructions.

You can also configure which tools agents can execute. Depending on the risk of an action, you can require a person to review and approve specific tool calls before they run.

At this point, the agent is limited to data from within the DataMiner digital twin. Because of this scope limitation, external internet content does not enter the agent context window, which reduces the risk of internet-borne malicious prompt content.

The agent framework does not currently include dedicated prompt injection detectors.

### What is context leakage, and how can it be prevented?

In this context, context leakage primarily means unintended exposure of one user or session context to another user or session.

The DataMiner Assistant uses separate sessions, and the Azure model services used by the Assistant isolate context between those sessions. This means context from one session is not available in another session.

As a result, there is no risk of context being leaked because of shared model context between users or between different organizations using the DataMiner Assistant.

## Questions and concerns

If you have additional questions about data privacy, security practices, or compliance, please reach out to Skyline Communications support or your account representative. They can provide detailed information tailored to your organization's specific requirements.
