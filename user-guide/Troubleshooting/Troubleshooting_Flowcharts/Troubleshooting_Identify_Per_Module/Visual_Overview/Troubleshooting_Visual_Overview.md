---
uid: Troubleshooting_Visual_Overview
---

# Troubleshooting: Visual Overview

## Overview

```mermaid
flowchart TD
    %% Define styles %%
    linkStyle default stroke:#cccccc
    classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
    classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
    classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
    classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
    classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
    classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
    %% Define blocks %%
    START([Visual Overview])
    Cube([Cube])
    Mobile([Web apps only])
    Regression([Worked in previous version?])
    Supported([Functionality supported in web apps?])
    ReportIssue([Report issue])
    FeatureSuggestion([Feature suggestion])
    ConfigIssue([Configuration issue?])
    Dojo([Ask on Dojo])
    Solved([Solved?])
    Nice([Nice!])
    %% Connect blocks %%
    START --- Cube
    START --- Mobile
    Mobile --- Regression
    Regression ---- |Yes| ReportIssue
    Regression ---- |No| Supported
    Supported ---- |No| FeatureSuggestion
    Supported ---- |Yes| ConfigIssue
    Supported ---- |Unsure| Dojo
    ConfigIssue ---- |Yes| Solved
    ConfigIssue ---- |No| ReportIssue
    ConfigIssue ---- |Unsure| Dojo
    Solved ---- |No| Dojo
    Solved ---- |Yes| Nice
    Cube --- ConfigIssue
    %% Define hyperlinks %%
    click ReportIssue "https://community.dataminer.services/dataminer-devops-support/"
    click FeatureSuggestion "https://community.dataminer.services/feature-suggestions"
    click Dojo "https://community.dataminer.services/questions"
    %% Apply styles to blocks %%
    class START classTerminal;
    class ReportIssue,FeatureSuggestion,Dojo classExternalRef;
    class Regression,Supported,ConfigIssue,Solved classDecision;
    class Cube,Mobile classAction;
    class Nice classSolution;
```

| Flow item | Description |
|--|--|
| Cube | Issues you have encountered in DataMiner Cube or the web apps that also occur in DataMiner Cube. |
| Web apps only | Issues that **only** occur in DataMiner web apps. |
| Configuration issue? | Verify if your configuration is correct. Try to isolate the problem by changing placeholders to static values, removing added complexity like shape grouping, etc. For more tips, refer to the [Visual Overview Learning Course](https://community.dataminer.services/courses/visio/) or [DataMiner Dojo Questions](https://community.dataminer.services/questions/). |
| Functionality supported in web apps? | For more information on which Visual Overview capabilities are supported in web apps, see [Unsupported capabilities](xref:DashboardVisualOverview#unsupported-capabilities). |
| Feature suggestion | Visual Overview is still fully supported, but limited innovations are introduced for this functionality at the moment. However, [posting a feature suggestion or upvoting an existing one](https://community.dataminer.services/feature-suggestions) can still be useful to indicate your wishes as a user and possibly shift the priorities of the DataMiner development team. |
