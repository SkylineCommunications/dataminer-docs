---
uid: Intelligence_InsightsAgent
description: "Learn about the DataMiner Insights native agent, which investigates questions about your DataMiner System and surfaces insights without modifying data."
---

# DataMiner Insights agent

DataMiner Insights is a read-only native DataMiner Intelligence agent. You can chat with it in the [DataMiner Assistant app](xref:Intelligence_Assistant_app) to ask questions about your system data without making changes to your DataMiner System.

![DataMiner Insights agent in the Assistant app, showing the knowledge tab, with only native references](~/dataminer/images/Assistant_Native_Agent_Insights.png)<br>*DataMiner Insights knowledge tab showing only native references in DataMiner Web 10.7.1.*

## Customization

The Insights agent's name, description, prompt, and built-in skills are immutable. Only non-native tools and skills can be modified.

By default, the Insights agent has access to [native data tools](xref:Intelligence_native_data_tools), along with the DataMiner-specific context and skills that come with them under the hood. This gives the AI extensive built-in knowledge of how a DataMiner System works and how its data should be interpreted, and allows it to consult DataMiner documentation and run custom Python scripts to analyze data and create visualizations.

You can extend this default toolset by adding custom [skills](xref:Intelligence_Skills) and non-native [data tools](xref:Intelligence_DataTools) through the Assistant app UI. These are not included by default and must be added manually.
