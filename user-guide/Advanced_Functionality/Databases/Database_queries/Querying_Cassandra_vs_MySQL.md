---
uid: Querying_Cassandra_vs_MySQL
---

# Querying a Cassandra database compared to MySQL

## Introduction

When it comes to querying, Cassandra is very different from MySQL. While Cassandra's CQL language syntax often closely resembles that of SQL queries, the differences will cause issues if you do not understand them. Specifically, copy-pasting a MySQL query to Cassandra will more often than not result in issues. This guide will help you understand what is going on under the hood.

## How data is stored in Cassandra

Cassandra works by storing data in huge rows called "partitions". To understand what exactly these are, take a look at the example below.

### MySQL ice cream table

| **Ice cream identifier (primary key)** | **Flavor** | **Type** | **Price** |
|--|--|--|--|
| 0 | Vanilla | Cone | 3 |
| 1 | Chocolate | Cone | 2 |
| 2 | Strawberry | Waffle | 2 |
| 3 | Banana split | Cup | 5 |
| 4 | Dame Blanche | Cup | 5 |
| 5 | Cookie Dough | Cup | 2 |

The above is your standard, run-of-the-mill MySQL table. It has a primary key, which is just a number here, some ice cream flavors, as well as a *Type* and *Price* column.

### Cassandra ice cream table - partitioning key

| **Type (partitioning key)** | **Record** |
|--|--|
| Cone | Vanilla,3;Chocolate,2 |
| Waffle | Strawberry,2 |
| Cup | Banana split,5;Dame Blanche,5;Cookie dough,2 |

This is what a Cassandra table looks like under the hood.

The *partitioning* key divides the data into logical units called *partitions*. Cassandra stores these as a row, and these partitions contain all of the data that correspond to this *partitioning key*.

> [!NOTE]
> MySQL's *primary key* is completely different from Cassandra's *partitioning key*. It is not the same type of identifier.

To make Cassandra more flexible, a clustering column exists. The clustering column allows easier querying of parts of a partition. With a clustering column, the table starts to look more like an ordinary SQL table with the partitioning key as a primary key. However, keep in mind that it is not. It is still stored per partition on the nodes.

### Cassandra ice cream table - partitioning key and clustering column

| **Type (partitioning key)** | **Flavor (clustering column)** | **Price** |
|--|--|--|
| Cone | Vanilla | 3 |
| Cone | Chocolate | 2 |
| Waffle | Strawberry | 2 |
| Cup | Banana Split | 5 |
| Cup | Dame Blanche | 5 |
| Cup | Cookie Dough | 2 |

This is the final form of the Cassandra table. Not only is it logically divided per partition, but you can also further filter on the clustering column to identify a unique record.

Once again the architecture does not resemble that of MySQL. You cannot get records with "primary key" 1, 2, etc. There is not even such a record in the database.

## How you should query in the Cassandra Query Language (CQL)

### Querying all data

```txt
select * from ice_cream;
```

Getting all data in a table is just like in MySQL. However, remember to use the semicolon (;).

### Querying for a type (partition)

```txt
select * from ice_cream where type = 'Cup';
```

With this query, Cassandra will fetch all records linked to the type "Cup".

### Querying for a specific flavor (clustering column and other cells)

#### Normal to large datasets

If you want to query for a specific flavor, you cannot do it like this:

<strike>

```txt
select * from ice_cream where flavor = 'vanilla';
```

</strike>

Instead, if you want to query on any cell in the database, you need to restrict both the **partitioning key** and the **clustering column**. In this case, you want to query on the **clustering column**. This requires the partitioning key to be restricted first.

This means you already need to know in which **partition** you have to look.

```txt
select * from ice_cream where type = 'Cone' and flavor = 'vanilla';
```

This is a working query.

#### Smaller datasets and ALLOW FILTERING

In smaller datasets, you can use ALLOW FILTERING in order to not have to restrict the **keys**.

This is **very inefficient**. It takes all data from the table and loops over it one by one (or from the partition if you restricted per partitioning key before that). Therefore, we do not recommend using this in datasets of bigger or even normal sizes.

The rule of thumb is to **avoid** this if possible.

```txt
select * from ice cream where flavor = 'vanilla' ALLOW FILTERING;
```

This will bring the same result as the above query, but much more slowly.

## Conclusion

Remember you always need to restrict the **partitioning** key first, and the **clustering column** second.
