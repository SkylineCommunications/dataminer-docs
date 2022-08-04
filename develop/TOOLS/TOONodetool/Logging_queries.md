---
uid: Logging_queries
---

# Logging queries

To log queries, the trace probability can be configured:

```txt
nodetool settraceprobability -- 1.0
```

Traces can be retrieved from the sessions table in the "system_traces" keyspace. By exporting the table content in DevCenter, the incoming queries can be investigated.

> [!CAUTION]
> This should only be used for local debugging purposes (not for production environments). Disable the tracing (nodetool settraceprobability -- 0.0) after debugging.
