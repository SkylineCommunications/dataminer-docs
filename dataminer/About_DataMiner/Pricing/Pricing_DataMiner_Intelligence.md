---
uid: Pricing_DataMiner_Intelligence
description: "Learn how DataMiner Intelligence usage is metered, which agents are included at no additional cost, and how specialized agents are licensed."
---

# DataMiner Intelligence pricing

This page describes how [DataMiner Intelligence](xref:Intelligence_Overview) is licensed and metered.

## Licensing

| Capability | Licensing |
|------------|-----------|
| [Native agents](xref:Intelligence_Assistant_Agents#native-agents) | Included at no additional cost. |
| [Specialized agents](xref:Intelligence_Assistant_Specialized_Agents) | Licensed separately. This is an experimental feature. |
| [Document Intelligence](xref:docintel) | Charged per page processed. See [Sizing guide: DataMiner Assistant](xref:Pricing_sizing_guide_services_DataMiner_Assistant). |

## Metering

Usage of DataMiner Intelligence is metered using the following metrics:

| Metric | What it measures |
|--------|------------------|
| Token consumption | The tokens processed by the foundational language models. |
| Tool calls | The actions that agents trigger to interact with DataMiner, such as activating a skill or tool, or reading documentation. |

Like other usage-based services, metering is done at the organization level. See [Billing and metering](xref:Pricing_billing_and_metering).

### Usage reporting

Tool calls are aggregated per hour. The following data is included in this aggregation:

- The ID and name of the agent that triggered the tool call.
- The type of tool call: *activate skill*, *activate tool*, or *read docs*.
- The ID of the user associated with the tool call.

The aggregation does not include the specific tool or skill that was activated, the session ID, or the ID of the model that was used. For more information about how your data is handled, see [Data privacy and security](xref:Intelligence_Data_Privacy_Security).

## Current commercial model

During the introduction of DataMiner Intelligence, usage is free of charge up to a predefined limit at the organization level. This allows you to explore the capabilities and try out workflows without worrying about costs.

DataMiner Intelligence is expected to become a standard usage-based service at a later stage. At that point, consumption of tokens and tool calls will be charged in [DataMiner credits](xref:Pricing_billing_and_metering#usage-terms). The mapping of token consumption and tool calls to DataMiner credits has not been finalized yet.

For more information about the commercial model and the usage limits that apply to your organization, contact your Skyline Communications representative.
