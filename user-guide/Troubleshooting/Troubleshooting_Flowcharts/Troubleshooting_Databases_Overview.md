---
uid: Troubleshooting_Databases_Overview
---

# Troubleshooting - databases - overview

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start[What database is the problem?]
Cassandra([Cassandra])
Elasticsearch([Elasticsearch])
Investigation([How to investigate])
HOME([Start page])
%% Connect blocks %%
Start --- Cassandra
Start --- Elasticsearch
%% Define hyperlinks %%
click HOME "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click Investigation "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click Cassandra "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra.html"
click Elasticsearch "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Elasticsearch/Troubleshooting_Elasticsearch.html"
%% Apply styles to blocks %%
class Start DarkBlue;
class HOME,Investigation,Cassandra,Elasticsearch LightBlue;
</div>
