---
uid: Finding_a_Root_Cause
---

# Finding a root cause

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
    START([Find the root cause])
    Investigate([Where to start?])
    CheckStartup{{Does the DMA start up?}}
    CHECK1{{Any critical issues? }}
    identify{{Identify issue per... }}
    AlarmsServicesTrending{{Is it an issue related to alarms, services, or trending?}}
    DMAStartupIssues([To DMA Startup Issues flowchart])
    critical([To Critical Issues flowchart])
    ProcessFlowcharts([Process])
    Module([Module])
    Which{{What is your issue related to?}}
    Alarms([Alarms])
    Services([Services])
    Trending([Trending])
    WebApps([Web apps])
    %% Connect blocks %%
    START --- CheckStartup
    CheckStartup ---|Yes| CHECK1
    CheckStartup --- |No| DMAStartupIssues
    CHECK1 --- |Yes| critical
    CHECK1 ---- |No| AlarmsServicesTrending
    AlarmsServicesTrending ---|Yes|Which
    AlarmsServicesTrending ----|No|identify
    identify --- ProcessFlowcharts
    identify --- Module
    Which --- Alarms
    Which --- Services
    Which --- Trending
    Which --- WebApps
    %% Apply styles to blocks %%
    class START classTerminal;
    class Which,AlarmsServicesTrending,CheckStartup,CHECK1,identify classDecision;
    class Investigate,Cassandra,Elasticsearch,DMAStartupIssues,critical,ProcessFlowcharts,Module,Alarms,Trending,WebApps,Services classExternalRef;
```

## Examples of critical issues

| Critical issues | Why are these critical? |
|--|--|
| RTEs/Runtime Errors | RTEs may inhibit the flow of information in your DMS. |
| Process crashes | Process crashes may cause interaction of DataMiner internal processes to fail and cause a DataMiner restart. |
| Process disappearances | Process disappearances may cause interaction of DataMiner internal processes to fail and cause a DataMiner restart. |
