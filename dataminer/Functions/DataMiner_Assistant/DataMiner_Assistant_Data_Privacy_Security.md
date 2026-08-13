---
uid: Assistant_DataPrivacySecurity
---

# Data privacy and security

The DataMiner Assistant handles your data with privacy and security as top priorities. This page outlines how data is protected, retained, and managed within the agents of the DataMiner Assistant, including details on the underlying AI infrastructure and the controls in place to keep your data isolated and secure.

## AI infrastructure and data residency

The DataMiner Assistant is powered by models hosted on **Microsoft Azure** and is currently limited to Azure OpenAI Services, though other models will also be supported in later releases. The models are hosted and consumed in Azure and not directly from OpenAI or other model providers, which is an important distinction in terms of data privacy. All the services used give the following data privacy guarantees:

- Azure OpenAI and other model services used operate under Microsoft's enterprise security and compliance framework, separate from OpenAI's or other model providers' consumer service compliance frameworks.
- Models are deployed in specific Azure regions to ensure data **remains within a defined geographical zone**. Data does not leave the region in which it is processed.

  > [!NOTE]
  > Currently, all AI traffic is processed in the **West Europe** Azure region (Amsterdam) and will not leave that region. For EU/EEA customers, this means data never leaves the European Economic Area, helping to reduce the need for cross-border data transfer safeguards under GDPR Chapter V (e.g., Standard Contractual Clauses or adequacy decisions). Support for additional Azure regions is planned, allowing users in other parts of the world to benefit from equivalent data residency guarantees within their own region.

- All processing happens within Skyline's Azure tenant, meaning your data never leaves the Skyline Communications tenant boundary. This provides an additional layer of isolation from other customers and services of Microsoft.

## Data encryption

All data transmitted to and from the DataMiner Assistant is encrypted using industry-standard TLS (Transport Layer Security) protocols. This ensures that:

- Data in transit between your DataMiner System and the Assistant infrastructure is protected from unauthorized access.
- Encryption is applied at the network level, regardless of the type of data being transmitted.

Additionally, data at rest is encrypted using Azure-managed encryption keys, ensuring protection even when data is stored (see [data retention](#data-retention)).

## Data retention

The Azure models used by the DataMiner Assistant are **stateless**: no prompts or completions are stored within the model itself during inferencing. They are also not used to train, retrain, or improve base models in any case.

Conversation history is stored in memory by the Assistant DxM running on the DataMiner server. This history is retained so that users can have a chat conversation experience. Later, the conversation details will also be stored in the DataMiner database so that users can continue previous conversations and read earlier chat history. In this case, it will be possible to delete conversations at any time by using the Assistant user interface.

In the cloud, Microsoft Azure applies the following data handling practices:

- **Inferencing (prompts and responses)**: Prompts and generated responses are processed by the models in real time and are not stored in the model. They are not used to train, retrain, or improve base models.
- **Abuse monitoring**: By default, Azure retains a sample of prompts and completions temporarily for abuse monitoring purposes, to detect use that may violate Microsoft's terms of service. The data is retained only for the duration necessary to complete the abuse monitoring process; Microsoft does not publicly specify an exact retention period. This data is stored within the same Azure geography as the deployed resource (West Europe at this time for DataMiner Assistant). It is logically isolated per customer resource and can only be accessed by authorized Microsoft personnel in the event of a flagged violation. For deployments within certain Azure regions, those authorized reviewers are also located within the same region.

On the DataMiner side, some data is retained for logging purposes. At this time, logging exists both on the DataMiner server (on-premises or in the cloud depending on the deployment) and in the dataminer.services cloud (Azure). The following data handling practices apply:

- Server-side logs use a loop configuration (last in, first out) with a fixed number of lines and include detailed data such as the question, the answer, and intermediate processing steps. The effective on-premises retention period therefore depends on usage.
- Cloud-side logs contain both temporary and long-term logs. The temporary logs contain the question and answer for a limited time, while long-term logs only contain the question asked. These logs will only be consulted by Skyline employees with permission of the customer and when strictly necessary for supporting the customer in case of questions or issues, or with enhancements of the product.

Currently, no setting is available to prevent these server- and cloud-side logs from being stored.

No data is used for training foundation models or shared outside the Skyline Communications Azure tenant. Microsoft is very strict about this and ensures this to the entire community and especially to Skyline Communications as a Certified Software Partner. For more details, see [Microsoft's data, privacy, and security documentation for Azure OpenAI](https://learn.microsoft.com/en-us/azure/foundry/responsible-ai/openai/data-privacy).

## User permissions

Access to the DataMiner Assistant and the actions you can perform are controlled through your existing DataMiner user permissions:

- Only users with appropriate DataMiner credentials can access the Assistant. The DataMiner Assistant web application, when enabled, is currently available for all users with permissions to use the web apps. This broad access is temporary during the current rollout phase. At this point in time, no additional Assistant-specific permissions are required.
- The Assistant respects your role-based access control (RBAC) configuration, meaning you can only view and interact with data that your DataMiner permissions allow you to access.
- Access to the Documentation tab in the DataMiner Assistant app for retrieving information from the DataMiner documentation is typically available to all authenticated users.

For more information on managing DataMiner user permissions, see [User management](xref:User_management).

## Data usage and AI model training

**Your data is never used to train or improve AI models.** The Azure AI Services used provide enterprise data isolation controls that guarantee this:

- Azure guarantees that the prompts (inputs) and the model's outputs are **not used to train or improve foundation models** unless explicitly authorized, which is not the case for the DataMiner Assistant.
- No data you send to the Assistant, including your questions, system data, or configuration information is retained for model training purposes.
- All user interactions remain confidential and are used exclusively to serve your requests within your session.

This approach ensures that your proprietary system information, business logic, and operational data remain completely isolated from any model training processes, by either Skyline or Microsoft.

## Compliance and standards

The DataMiner Assistant adheres to industry-leading security and privacy standards through its use of the Azure OpenAI Service:

- Data handling follows GDPR compliance principles where applicable.
- Azure infrastructure is certified to ISO 27001, SOC 2, and other major compliance frameworks.
- Data residency controls ensure data stays within the designated geographical zone (West Europe only for now).
- Microsoft enterprise security standards apply to all data processing within the Skyline tenant.
- Regular security audits and penetration testing validate the security posture. For broader platform-level details, see [DataMiner compliance offering](xref:DataMiner_compliance_offering#annual-security-assessment) and [Skyline Communications and DataMiner security](xref:Skyline_and_DataMiner_security).

For specific compliance requirements in your organization, contact your Skyline Communications representative.

## FAQ

### How does the DataMiner Assistant reduce hallucinations?

Hallucinations are incorrect or misleading model outputs presented as if they were factual. The DataMiner Assistant addresses this with a multilayered approach.

1. Out-of-the-box agent measures:

   - The Assistant includes context and instructions that encourage evidence-based reasoning before conclusions are presented.
   - The Assistant is guided to answer only when confidence is sufficiently high.
   - Structured response formats are used to enforce more disciplined and transparent outputs.

1. Grounding in trusted context and data:

   - The most important mitigation is to ground the Assistant in as much trusted data and context as possible.
   - A large portion of the DataMiner-specific context is provided out of the box such that the agent does not hallucinate about standard DataMiner concepts such as alarms, masking alarms etc.
   - The user of the platform should focus on extending the coverage of their DataMiner digital twin and enriching the Assistant with user-specific and system-specific context and skills such that the agent does not hallucinate about things that are specific to their environment.

At this time, the DataMiner Assistant does not include more advanced out-of-the-box protections such as dedicated verification agents, strict tool-usage constraints, or workflow-based guardrails. Because of this, organizations should remain critical when interpreting results and when using the Assistant to execute autonomous actions. If autonomous actions are enabled, perform proper scenario-based testing first and continuously monitor outcomes in production.

### What is prompt injection, and how is it mitigated?

Prompt injection is an attempt to manipulate AI behavior through crafted instructions in user input or retrieved content, for example by trying to override higher-priority instructions.

Basic mitigation measures are already in place:

- Dedicated instructions enforce separation between instructions and data or other external content.
- Fine-tuned context based on best practices restricts the model as much as possible to execute only against the actual instructions.

In addition, the Assistant allows configuration of which tools can be executed. Depending on the action risk within the tool, tools can be configured with or without a human in the loop. This allows specific tool calls to always require dedicated validation and approval by a person.

At this point, the agent is limited to data from within the DataMiner digital twin. Because of this scope limitation, external internet content does not enter the agent context window, which reduces the risk of internet-borne malicious prompt content.

Future improvements, such as dedicated prompt injection detectors, can further increase the integrity of the context fed to the agent but are not yet included in the current version of the Assistant.

### What is context leakage, and how can it be prevented?

In this context, context leakage primarily means unintended exposure of one user or session context to another user or session.

The DataMiner Assistant uses separate sessions, and the Azure model services used by the Assistant isolate context between those sessions. This means context from one session is not available in another session.

As a result, there is no risk of context being leaked because of shared model context between users or between different organizations using the DataMiner Assistant.

## Questions and concerns

If you have additional questions about data privacy, security practices, or compliance, please reach out to Skyline Communications support or your account representative. They can provide detailed information tailored to your organization's specific requirements.
