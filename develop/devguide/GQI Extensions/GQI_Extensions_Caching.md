---
uid: GQI_Extensions_Caching
---

# Caching Within GQI Extensions

When working with **ad hoc data sources** and/or **custom operators**, each query creates a new instance of the data source and for each row the HandleRow method gets called. If constructing the data or handling the data is resource-intensive (e.g., multiple API calls, heavy calculations), scalability becomes critical. Multiple users may query the same data concurrently, so optimizing performance is key.


## When To Use Caching

Caching is recommended when:
- The data source/operator is expensive to build or query (e.g., multiple API calls, heavy computation).
- The data does not need real-time freshness (e.g. acceptable to be seconds or minutes old).
- The same data is requested repeatedly by multiple users or queries.

Avoid caching when:
- Accuracy must always be real-time (e.g. live status, alarms).
- The dataset is very small and fast to compute (caching adds unnecessary complexity).

## Key Considerations When Caching

Understanding these considerations helps you avoid common mistakes such as assuming that static caches are shared across all scripts or neglecting how quickly memory usage can grow. By carefully planning aspects like cache scope, memory limits, invalidation strategies, and concurrency handling, you ensure that your caching approach improves performance without introducing data leaks, stale results, or race conditions. Ultimately, the right caching strategy balances performance, freshness, and security to meet your system’s specific needs.

### Caching Per Security Group

Caching per security group ensures that access control is respected, as each group only sees the data they are permitted to view. It also prevents accidental data leaks that could occur if a single shared cache were used for all users. Additionally, this approach improves performance by allowing users in the same group to share cached results rather than recomputing them individually.

In summary, caching per security group:
- enforces access control (no cross-group data leaks).
- improvides performance and reduces memory consumption by sharing results within a group.

### Memory consumption

Caching per security group can quickly increase memory usage, especially in environments with many unique security groups or large datasets per group. Each cache entry holds a copy of the results for that group, so memory usage scales with the number of groups and the size of each dataset.  

To prevent excessive memory growth:
- **Set limits** on the maximum number of groups cached at once.  
- **Implement eviction policies** (e.g., least recently used) to remove inactive groups.  
- **Use smaller data representations** (e.g., compress data or store only essential fields).  
- **Monitor memory usage** and adjust cache size or timeout values accordingly.  

### Cache Invalidation

Cache invalidation ensures that users do not see outdated or incorrect data. In ad hoc data sources, stale data can occur when the underlying data changes frequently or when security group memberships are updated. Without proper invalidation, cached results may remain inaccurate indefinitely.

There are several strategies you can use:  

- **Time-based expiration:** Automatically refresh data after a fixed interval (e.g., 30 seconds). This is simple to implement and works well when data updates are predictable.  
- **Manual reset (cache breaker):** Use a file, flag, or external signal to clear or refresh the cache on demand. This is useful for administrative control when data changes are event-driven.  
- **Hybrid approach:** Combine timeouts with manual reset to balance predictable refresh with flexibility.  
- **Invalidate per security group:** If only certain groups are affected, clear cache entries selectively rather than globally.  

Carefully plan invalidation frequency. Too frequent invalidation negates the benefits of caching, while infrequent invalidation risks serving stale or incorrect data.

### Concurrency

In multi-user or multi-threaded environments, cache methods may be called concurrently by different threads. Without proper synchronization, this can cause race conditions, redundant data fetching, or inconsistent cache state.

To handle concurrency safely:

- Use thread-safe collections such as `ConcurrentDictionary` for shared caches.
- Protect critical sections (e.g., cache initialization or updates) with locks (`lock` statement or other synchronization primitives).
- Double-check locking patterns help ensure initialization/update occurs only once per cache cycle, minimizing duplicate work.
- Be mindful to keep locks as short as possible to reduce contention and avoid deadlocks.

Proper concurrency management ensures reliable, consistent caching behavior without wasting resources or causing data corruption.

## Static Cache Scope

Each compiled script containing GQI extensions runs in its own process. This means that a static `ConcurrentDictionary` will only share data between the data sources and operators within that process. If you have multiple precompiled scripts that need to share a cache, they must be placed into the same project or precompiled library. Otherwise, each script will maintain its own independent cache instance.

This has significant implications for your caching strategy:

- You cannot rely on a static cache to be shared globally across all scripts or processes.
- If cache sharing is required between different precompiled scripts, consider combining the 2 scripts into 1 precompiled script.


## Example

For a full, detailed example implementation of an ad hoc data source with caching, concurrency handling, and security group support, please see the [Scaling Ad hoc Data Source](./Scaling_Ad_hoc_Data_Source_Full_Example.md) page.
