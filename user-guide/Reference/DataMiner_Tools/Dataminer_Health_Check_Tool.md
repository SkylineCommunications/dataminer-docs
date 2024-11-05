---
uid: DataMiner_Health_Check_Tool
---

# DataMiner Health Check Tool

The DataMiner Health Check Tool provides several mechanisms to observe and to be informed about the performance of a DataMiner system and its elements. 
Once installed, the tool includes the Health Check Manager connector that allows various test cases to be configured and executed. Each time the tests are executed, the resulting data is compared against configured thresholds which determine if a test case passes or fails. The pass/fail results are logged and made available via automated emailed reports or via dashboards.
The primary use-case for the tool is to configure tests that proactively inform of issues related to the DataMiner agents and the connected database nodes. This usually involves the configuration of script-based tests that retrieve DMA metrics via DMS calls as well as the configuration of subscription-based tests that retrieve parameter data directly from Elements running the Microsoft Platform, Linux Platform, Apache Cassandra Cluster Monitor, and ElasticSearch Cluster Monitor protocols. However, the flexibility of the tool allows custom script-based tests to be built beyond the DMA-related scripts that are provided out-of-the-box. Additionally, custom subscriptions can be defined for any standalone or table-based parameters beyond the protocols that are mentioned above.

![Health Check Email Report](~/user-guide/images/Health_Check_Email_Report.png)
