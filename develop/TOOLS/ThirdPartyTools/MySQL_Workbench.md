---
uid: MySQL_Workbench
---

# MySQL Workbench

> [!NOTE]
> From DataMiner 10.4.0 onwards, MySQL is no longer supported as the general database. For the currently supported DataMiner versions, we highly recommend switching to Cassandra.

MySQL Workbench is a tool for exploring [MySQL databases](xref:MySQL_database) and performing administrative actions.

![MySQL Workbench](~/develop/images/MySQL_Workbench.png)<br>*MySQL Workbench SQL Editor*

> [!TIP]
>
> - You can download this tool from [the MySQL website](https://www.mysql.com/products/workbench/).
> - For more information about how to use this tool, see [MySQL Workbench](https://dev.mysql.com/doc/workbench/en/).

## Logging queries

To log all queries, perform the following action:

```txt
SET global general_log = 1;
SET global log_output = 'table'; // enable logging through table
select * from MySQL.general_log; // view the log
```

To disable the logging:

`SET global general_log = 0;`
