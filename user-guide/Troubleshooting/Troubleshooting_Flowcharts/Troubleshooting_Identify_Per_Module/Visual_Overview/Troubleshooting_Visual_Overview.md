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
    Mobile([Mobile Only])
    Regression([Worked in previous version?])
    Supported([Functionality supported in Mobile?])
    ReportIssue([Report Issue])
    FeatureSuggestion([Feature Suggestion])
    ConfigIssue([Configuration Issue?])
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

| **Flow item** | **Meaning** |
|--|--|
| Cube | Issues you are encountering in DataMiner Cube or issues you found in mobile applications that also occur in DataMiner Cube. |
| Mobile Only | Issues that **only** occur in mobile applications. |
| Configuration Issue? | Try to verify if your configuration is correct. Try to isolate the problem by changing placeholders to static values, removing added complexity like shape grouping... For more tips, refer to the [Visual Overview Learning Course](https://community.dataminer.services/courses/visio/) or [DataMiner Dojo Questions](https://community.dataminer.services/questions/). |
| Functionality supported in Mobile? | For more information on what capabilities are supported in mobile Visual Overviews, please refer to the [Visual Overview Component](https://docs.dataminer.services/user-guide/Advanced_Modules/Dashboards_and_Low_Code_Apps/Visualizations/Available_visualizations/Other/Visual_Overview_component.html) documentation. |
| [Feature Suggestion](https://community.dataminer.services/feature-suggestions) | Visual Overview is still fully supported, but innovation on this functionality is limited. Posting a feature suggestion or upvoting an existing one can still be useful however to indicate your wishes as a user and maybe shift the priorities of our development.