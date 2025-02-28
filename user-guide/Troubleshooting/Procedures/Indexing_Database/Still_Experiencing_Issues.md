---
uid: ID_Still_Experiencing_Issues
---

# Are you still experiencing issues?

If you are still experiencing issues, please report them to [techsupport@skyline.be](mailto:techsupport@skyline.be).

When reporting an issue that may be related to the indexing database, please include the following information:

- **A clear description of the issue**: If possible, provide screenshots to illustrate the problem and its impact.

- **A [Log Package](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages)**: Include a memory dump of SLDataGateway from the DataMiner Agent where the issue occurs.

- **Indexing database configuration and logs files**: On Linux systems, provide the following files based on your database type:

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
