---
uid: AdvancedDataMinerMediationLayerLinkingTableParameters
---

# Linking table parameters

Special care should be taken when linking to table parameters:

- In the base protocol, you have to define the table definition as well as the column definitions.
- The table in the base protocol must have both a primary key column and a display key column.
- The primary key column and the display key column of the base protocol must be linked to their respective counterparts in the device protocol. If the base protocol has separate primary key and display key columns but the device protocol only has a single key column, both columns in the base protocol can link to the same key column in the device protocol.
- Defining other columns is optional.
