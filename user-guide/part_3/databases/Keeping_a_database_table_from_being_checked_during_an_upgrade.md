# Keeping a database table from being checked during an upgrade

When you perform an upgrade of the DataMiner Agent software, by default, all database tables are automatically checked and, if necessary, optimized and/or repaired.

There are two ways to keep a particular database table from being checked:

- Add a *\<SkipTableUpdate>* instruction to the file *DB.xml* for the table in question (from DMS 8.0.0 onwards). See [Adding a SkipTableUpdate instruction to the db.xml file](Adding_a_SkipTableUpdate_instruction_to_the_db_xml_file.md#adding-a-skiptableupdate-instruction-to-the-dbxml-file).

- Add a “DataMiner Customized” comment to the table in question. See [Adding a DataMiner Customized comment](Adding_a_DataMiner_Customized_comment.md).
