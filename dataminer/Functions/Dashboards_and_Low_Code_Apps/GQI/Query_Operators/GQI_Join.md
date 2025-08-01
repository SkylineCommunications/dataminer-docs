---
uid: GQI_Join
---

# Join

The *Join* query operator joins two tables together. When you select this option, in the *Type* dropdown box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

From DataMiner 10.3.3/10.4.0 onwards, the *Row by row* option allows you to first execute the query for the first table, and then execute the query for the other table for each row that matches the join condition. This option is only available if you add the `showAdvancedSettings=true` option to the dashboard URL. If the *Row by row* option is not enabled, the join will execute both tables once and directly combine their results. <!-- RN 35565 + 35057 -->

> [!NOTE]
> The *Row by row* option is only supported for *Inner* and *Left* type of joins.
