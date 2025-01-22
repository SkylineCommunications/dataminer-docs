---
uid: Cassandra_TWCS
---

# Cassandra TWCS

**Time Window Compaction Strategy (TWCS)** is a compaction mechanism specifically designed for time-series data. The data is organized and compacted into time-based buckets, referred to as **time windows**.

When choosing the [TTL](xref:Specifying_TTL_overrides) on Cassandra for trending, there are some recommended boundaries.

## Time Window Compaction Strategy

In the TWCS mechanism, data is grouped into defined time intervals (e.g. 3 hours, 1 day, etc.). Each time, a window contains all data written within that interval.

While data is being actively written to the current time window, it is compacted into SSTables for that specific window. Compaction occurs incrementally, merging data within the same time window.

SSTables are immutable and compacting SSTables leads to a new SSTable. When a window ends, a final SSTable will be constructed. A full SSTable for a specific window will exist until the TTL is passed. After the TTL passed, the SSTable can safely be deleted.

## Importance of Limiting SSTables

For efficient operation, it is recommended to maintain **fewer than 50 SSTables on disk per node**. Exceeding this threshold can lead to performance degradation due to:

- Increased storage overhead.
- Higher read latencies as queries need to scan more SSTables.
- Inefficient compaction processes.

## Recommended maximum TTL

The relationship between the **time window size** and the recommended **maximum TTL** is governed by the number of allowable SSTables. The recommended maximum TTL can be calculated as $50 \times \text{time window size}$. This ensures that no more than 50 *old* SSTables are retained.

The following recommended limitations apply:

| Type of data       | Time window size | Recommended maximum TTL |
|--------------------|------------------|-------------------------|
| Real-time trending | 3 hours          | 6 days 6 hours          |
| Minute trending    | 4 days           | 200 days                |
| Hour trending      | 14 days          | 700 days                |
| Day trending       | 30 days          | 1500 days               |

> [!NOTE]
> Regardless of how the Cassandra database is configured, the recommended maximum TTL values cannot be changed.