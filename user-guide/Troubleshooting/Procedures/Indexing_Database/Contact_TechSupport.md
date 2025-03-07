---
uid: ID_Contact_TechSupport
---

# Contacting TechSupport

If you are still experiencing issues, please report them to [techsupport@skyline.be](mailto:techsupport@skyline.be).

When reporting an issue that may be related to the indexing database, include the following information:

- **A clear description of the issue**: Provide a detailed explanation of the problem, including its impact. If possible, attach screenshots to illustrate the issue.

- **A [Log Package](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages)**: Attach a memory dump of SLDataGateway from the affected DataMiner Agent.

- **Indexing database configuration and logs files** (Only for Linux systems):

  Provide the following files based on your indexing database type:

  - For OpenSearch:

    - Configuration file: `/etc/opensearch/opensearch.yml`

    - JVM options file: `/etc/opensearch/jvm.options`

    - Database log file: `/var/log/opensearch/[ClusterName].log`

    - Output of the command: `systemctl status opensearch.service`

  - For Elasticsearch:

    - Configuration file: `/etc/elasticsearch/elasticsearch.yml`

    - JVM options file: `/etc/elasticsearch/jvm.options`

    - Database log file: `/var/log/elasticsearch/[ClusterName].log`

    - Output of the command: `systemctl status elasticsearch.service`
