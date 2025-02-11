---
uid: AdvancedLoggerTablesExtending
---

# Extending logger tables

It is possible to make changes to the logger table structure:<!-- RN 14383 -->

- Add columns
- Broaden a column’s datatype (not supported in Cassandra): e.g. change the datatype of a column from VARCHAR(10) to VARCHAR(20)

Deleting columns or narrowing the datatype of a column (e.g. from VARCHAR(20) to VARCHAR(10)) is not supported. Renaming columns is also not supported.
