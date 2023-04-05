---
uid: UIComponentsTableForeignKeys
---

# Foreign keys

In DataMiner protocols, tables often need to be linked (for example when implementing tree controls, DVEs, etc.).

Consider for example two tables where table 1 lists different modulators (e.g. modulator 1 and modulator 2) and table 2 contains information about these modulators. You can link table 2 to table 1 by specifying a foreign key and a relation.

One column of table 2 has to contain references (keys) to information stored in table 1. In the following example, column 2010 contains key values from table 1000. The link between the two tables is established using the foreignKey option.

```xml
<ColumnOption idx="9" pid="2010" type="custom" value="" options=";foreignKey=1000"/>
```

Since DataMiner version 8, it is possible to implement recursive linking. The table will have a column with a foreign key to itself. This can be required for specific aggregate actions in EPM (formerly known as CPE) environments. For example, there is a list of amplifiers in a table but all amplifiers are connected to each other and a count needs to be done for the number of amplifiers connected from a certain starting point.

```xml
<Param id="300" trending="false">
  <Name>Recursive List</Name>
  <Description>Recursive List</Description>
  <Type>array</Type>
  <ArrayOptions index="0" options="">
     <ColumnOption idx="0" pid="301" type="retrieved" value="" options=""/>
     <ColumnOption idx="1" pid="303" type="retrieved" value="" options=";foreignKey=300"/>
     <ColumnOption idx="2" pid="304" type="retrieved" value=""/>
```

Please keep the following guidelines in mind for foreign keys:

- Do not add multiple foreign keys on one column. A column needs to be created for each link. Also, do not put a foreign key on the index of a table, or use foreign keys in a table that contains a column of type "index", because the foreign key will not work then.
- A foreign key must not have leading or trailing whitespace.
- Semicolons (“;”), question marks (“?”) and asterisks (“*”) must be avoided in foreign keys as these characters have a special meaning in the dynamic table filter syntax and could therefore cause table filter queries to be interpreted incorrectly. (Refer to [Dynamic Table Filter Syntax](xref:Dynamic_table_filter_syntax).)
