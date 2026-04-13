---
uid: Integrity_constraints
---

# Integrity constraints

- Integrity constraints defined on tables (e.g., use of foreign keys) should be respected. For example, suppose table B contains a foreign key to table A. When removing a row from table A, make sure that rows in table B that link to this row are removed first.
