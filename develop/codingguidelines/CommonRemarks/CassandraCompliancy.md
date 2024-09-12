---
uid: Cassandra_Compliancy
---

# Cassandra Compliancy

Make sure the DriverHelp is correctly noting the driver to be Cassandra compliant or not:
A driver is Cassandra compliant when:

- No DB Queries on the DataMiner Database (note: other databases is fine)
- No DisplayColumn tags
- No Logger tables without the CQL Tags

Note:

- Unicode is supported on Cassandra. This was previously incorrectly indicated here.
- When the above criteria are met, but the word database is used in the driver: DMA will block migration to Cassandra. Use the Compliancies.CassandraReady XML tag with the value true to avoid this. Example where this occurred: Astro U148 where a qaction has an overview of possible xml config files and one of them has the string value: "SAT Database"
