---
uid: ConnectorBestPracticesTables
---

# Tables

## Column names

The names of column parameters of a table must all start with the name of the table. This makes it possible to quickly see which parameters belong to a table in the protocol tree.

## Column descriptions

In case a table has a column that has the same description as a column defined in another table, add the table description (or an abbreviation of the table description) at the end of the column description, in parentheses. For example, for tables with the names "Services" and "Streams", the following column descriptions can be used: "State (Services)" and "State (Streams)".

## Column header options

Columns of type "number" that support alarming will by default show the sum of all values in the column. In case this default behavior is irrelevant, it must be either disabled (e.g., disableHeaderSum) or replaced by a more suitable header (e.g., enableHeaderMax). Also, note that histograms and heat maps should be disabled in case these are not relevant.
