---
uid: Adding_a_SkipTableUpdate_instruction_to_the_db_xml_file
---

## Adding a SkipTableUpdate instruction to the db.xml file

From DataMiner version 8.0.0 onwards, a *\<SkipTableUpdate>* instruction can be added in the file *DB.xml* to keep a database table from being checked during a DataMiner software upgrade.

In the example below, two tables will be kept from being checked:

```xml
<DataBases>
  <DataBase active="true" local="true" type="MySQL">
    ...
    <Maintenance monthsToKeep="12">
      <SkipTableUpdates>
        <SkipTableUpdate table="data_3012"/>
        <SkipTableUpdate table="dataavg_3012"/>
      </SkipTableUpdates>
    </Maintenance>
    ...
  </DataBase>
</DataBases>
```
