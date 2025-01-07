---
uid: Troubleshooting_Visual_Overview
---

# Troubleshooting: Visual Overview

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

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
    Mobile([Mobile])
    Regression([Worked in previous version?])
    ReportIssue([Report Issue])
    %% Connect blocks %%
    START --- Cube
    START --- Mobile
    Mobile --- Regression
    Regression ---- |Yes| ReportIssue
    %% Define hyperlinks %%
    click ReportIssue "https://community.dataminer.services/dataminer-devops-support/"
    %% Apply styles to blocks %%
    class START classTerminal;
    class ReportIssue classExternalRef;
    class Regression classDecision;
    class Cube,Mobile classAction;
```

| **Flow item** | **Meaning** |
|--|--|
| Cube | Issues you are encountering in DataMiner Cube or issues you found in mobile applications that also occur in DataMiner Cube. |
| Mobile | Issues that **only** occur in mobile applications. |
| Configuration Issue? | Try to verify if your configuration is correct. Try to isolate the problem by changing placeholders to static values, removing added complexity like shape grouping... For more tips, refer to visio course or dojo. |

## Plan Of Attack
| **Issue** | **Plan of attack** |
|--|--|
| Configuration | Refer to [SLElement Flowchart](xref:Troubleshooting_SLElement_exe) |
