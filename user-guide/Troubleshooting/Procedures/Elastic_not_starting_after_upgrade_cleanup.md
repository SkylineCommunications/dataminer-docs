---
uid: Elastic_not_starting_after_upgrade_cleanup
---

# Elasticsearch/OpenSearch does not start up after an upgrade or disk cleanup (on Windows)

If Elasticsearch or OpenSearch are installed on a Windows system, after an operating system upgrade (e.g. upgrade from Windows Server 2019 to 2022), it can occur that the Elasticsearch or OpenSearch service no longer starts up. This same problem can also occur after automated disk cleanup.

This issue occurs because the Elasticsearch and OpenSearch service by default depend on a **temporary folder** that typically gets cleaned up during an upgrade or disk cleanup, i.e. the *appdata/local/temp* folder of the user who installed the service.

To solve this issue, manually **recreate this folder** after the OS upgrade or disk cleanup.
