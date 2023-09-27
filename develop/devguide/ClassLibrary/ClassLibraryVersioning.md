---
uid: ClassLibraryVersioning
---

# Class library versioning

## Versioning scheme

A class library version consists of four components. Each component is a number, separated from the other components by a period ("."), e.g. 1.2.0.1.

The different components of a version A.B.C.D represent the following:

- A: Major version, 1 for the first official release. An increment of this number indicates a major rewrite that is not backwards compatible.
- B: An increment of this number indicates that the minimum required DataMiner version has increased. E.g. 1 = DataMiner 9.6.3, 2 = DataMiner 10.0.3.
- C: An increment of this number indicates a major change (e.g. an API change).
- D: An increment of this number indicates a non-breaking change (e.g. an addition to the API).

## Released versions

Refer to the [class library release notes](xref:ClassLibrary_Range_1.2) for an overview of the released versions.
