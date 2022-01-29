---
uid: Adding_a_DataMiner_Customized_comment
---

# Adding a DataMiner Customized comment

Instead of adding a *\<SkipTableUpdate>* instruction to the file *DB.xml*, you can also add a comment to a database table in order to keep that table from being checked during a DataMiner software upgrade.

To add a 'DataMiner Customized' comment to a database table, run the following SQL command (in which you replace “xxx” by the actual table name):

```txt
ALTER TABLE xxx COMMENT = 'DataMiner Customized'
```

> [!NOTE]
> Adding a 'DataMiner Customized' comment to a database table causes that entire table to be copied to a temporary table, which has a negative impact on query duration. Therefore, from DataMiner version 8.0.0 onwards, it is advisable to use the *\<SkipTableUpdate>* method instead.
