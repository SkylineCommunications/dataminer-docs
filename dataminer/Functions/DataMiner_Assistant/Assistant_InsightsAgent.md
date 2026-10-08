---
uid: Assistant_InsightsAgent
description: "Learn about the DataMiner Insights native agent, which investigates questions about your DataMiner System and surfaces insights without modifying data."
---

# DataMiner Insights agent

DataMiner Insights is a read-only, insight-focused native agent in the [Assistant app](xref:DataMinerAssistant). It answers questions and surfaces insights from system data without performing any actions on the DataMiner System.

![DataMiner Insights agent in the Assistant app, showing native references and an empty custom references panel](~/dataminer/images/Assistant_Native_Agent_Insights.png)

## Customization

The Insights agent's name, description, prompt, and built-in skills are immutable. Only non-native tools and skills can be modified.

By default, the Insights agent has access to [native data tools](xref:Assistant_native_data_tools), along with the DataMiner-specific context and skills that come with them under the hood. This gives the AI extensive built-in knowledge of how a DataMiner System works and how its data should be interpreted, and allows it to consult DataMiner documentation and run custom Python scripts to analyze data and create visualizations.

You can extend this default toolset by adding custom [skills](xref:Assistant_Skills) and non-native [data tools](xref:Assistant_DataTools) through the Assistant app UI. These are not included by default and must be added manually.
