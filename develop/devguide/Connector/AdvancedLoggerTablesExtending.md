---
metadata_version: 1
uid: AdvancedLoggerTablesExtending
description: "Describe the DataMiner connector development topic Extending logger tables, including its purpose, behavior, implementation guidance, and relevant constra."
content_type: conceptual
applies_to:
  - DataMiner
---

# Extending logger tables

It is possible to make changes to the logger table structure:<!-- RN 14383 -->

- Add columns
- Broaden a column’s data type (not supported in Cassandra): e.g., change the data type of a column from VARCHAR(10) to VARCHAR(20)

Deleting columns or narrowing the data type of a column (e.g., from VARCHAR(20) to VARCHAR(10)) is not supported. Renaming columns is also not supported.
