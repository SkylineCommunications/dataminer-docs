---
metadata_version: 1
uid: AdvancedLoggerTablesExtending
description: "Understand which logger table schema changes are supported, including adding columns and broadening data types, and which changes are not supported."
---

# Extending logger tables

It is possible to make changes to the logger table structure:<!-- RN 14383 -->

- Add columns
- Broaden a column’s data type (not supported in Cassandra): e.g., change the data type of a column from VARCHAR(10) to VARCHAR(20)

Deleting columns or narrowing the data type of a column (e.g., from VARCHAR(20) to VARCHAR(10)) is not supported. Renaming columns is also not supported.
