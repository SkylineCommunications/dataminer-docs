---
uid: DataMiner_Health_Check_Tool
---

# DataMiner Health Check Tool

The DataMiner Health Check Tool provides several mechanisms to observe and get informed about the performance of a DataMiner System and its elements.

The tool includes the Health Check Manager connector, which allows various test cases to be configured and executed. Each time the tests are executed, the resulting data is compared against configured thresholds that determine if a test case passes or fails. The pass/fail results are logged and made available via automated emailed reports or via dashboards.

The primary use case for this tool is the configuration of tests that proactively inform users of issues related to DataMiner Agents and the connected database nodes. This usually involves the configuration of script-based tests that retrieve DMA metrics via DMS calls as well as the configuration of subscription-based tests that retrieve parameter data directly from elements running the Microsoft Platform, Linux Platform, Apache Cassandra Cluster Monitor, and ElasticSearch Cluster Monitor connectors.

While the system comes with several DMA-related tests out of the box, you also have the flexibility to build your own custom script-based tests. Additionally, custom subscriptions can be defined for any standalone or table-based parameters beyond the connectors that are mentioned above.

![Health Check Email Report](~/solutions/images/Health_Check_Email_Report.png)
