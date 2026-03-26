---
uid: GQI_Extensions_Caching
---

# Caching within GQI extensions

When working with **ad hoc data sources** and/or **custom operators**, each query creates a new instance of the data source, and for each row the HandleRow method gets called. If constructing the data or handling the data is resource-intensive (e.g., multiple API calls, heavy calculations), scalability becomes critical. Multiple users may query the same data concurrently, so optimizing performance is key.

## When to use caching

Caching is recommended when:

- The data source/operator is expensive to build or query (e.g., multiple API calls, heavy computation).
- The data does not need real-time freshness (e.g., acceptable to be seconds or minutes old).
- The same data is requested repeatedly by multiple users or queries.

Avoid caching when:

- Accuracy must always be real-time (e.g., live status, alarms).
- The dataset is very small and fast to compute (caching adds unnecessary complexity).

## Adding caching

Caching for GQI extensions is not natively supported by the framework and must be implemented manually. The most common approach is to use in-memory caching with static variables (for example a `ConcurrentDictionary`) to share data between queries and operators within the same extension library.

Because each extensions library runs in its own process, this static cache is process-local. It will not be shared across multiple extension libraries or across DataMiner Agents. If you need to share cached data beyond a single process, you must use a different approach, for example file-based caching, DOM-based caching, etc.

## Key considerations when caching

When adding caching to GQI extensions, there are several aspects you should evaluate:

- [**Cache lifetime**](#cache-lifetime): Know which objects can safely be cached and which framework dependencies must never be stored statically.
- [**Respect Access Control**](#respect-access-control): Ensure cached data does not leak between users or groups.
- [**Memory consumption**](#memory-consumption): Understand how the size and number of cache entries affects memory usage.
- [**Cache invalidation**](#cache-invalidation): Plan how and when to refresh or clear cached data.
- [**Concurrency**](#concurrency): Handle simultaneous cache access safely to avoid race conditions or duplicate work.

### Cache lifetime

Caching in GQI extensions is **not natively supported** by the framework, meaning you must handle all cache management manually in your extension logic. Understanding the lifetime of your cache and the objects involved is crucial to avoid subtle issues.

#### What can be cached

- Your own data models or query results.
- Serializable data or computed values.

#### What cannot be cached

- Framework-provided dependencies like GQIDMS or IGQILogger: These are tied to the lifetime of a specific extension instance and must not be stored in static variables or reused between instances.
- Any object that holds open connections, handles, or stateful resources provided by the framework.

### Respect access control

When implementing caching, it is essential to ensure that users only see the data they are allowed to access. The caching strategy you choose must align with your access control requirements to prevent data leaks or exposure of sensitive information.

For DataMiner data, caching per security group is the most common and efficient way to respect access control. It allows users within the same group to share cached results while ensuring data is isolated from other groups. However, depending on the use case, you may not need group-level caching at all (e.g., when data is already public) or you might need an even finer-grained approach (e.g., per user).

Benefits of caching per security group:

- enforces access control (no cross-group data leaks).
- improves performance and reduces memory consumption by sharing results within a group.

### Memory consumption

While caching can greatly improve performance, it always comes at the cost of additional memory usage. The total memory footprint grows with both the size of each cached dataset and the number of distinct cache entries being stored.

A common example is caching per security group rather than per individual user. This approach is far more efficient than user-level caching, but it can still consume significant memory if your environment contains many groups or if each group's dataset is large. Even when a single global cache is used (not per group), similar problems can occur if the dataset itself is sizable or if stale entries are left in memory too long.

To prevent excessive memory growth:

- **Set limits** on the maximum number of groups cached at once.
- **Implement eviction policies** (e.g., least recently used) to remove inactive groups.
- **Use smaller data representations** (e.g., compress data or store only essential fields).
- **Monitor memory usage** and adjust cache size or timeout values accordingly.

### Cache invalidation

Cache invalidation ensures that users do not see outdated or incorrect data. In ad hoc data sources, stale data can occur when the underlying data changes frequently or when security group memberships are updated. Without proper invalidation, cached results may remain inaccurate indefinitely.

There are several strategies you can use:

- **Time-based expiration**: Automatically refresh data after a fixed interval (e.g., 30 seconds). This is relatively simple to implement and works well when data updates are predictable.
- **Manual reset (cache breaker)**: Use a file, flag, or external signal to clear or refresh the cache on demand. This is useful for administrative control when data changes are event-driven.
- **Hybrid approach**: Combine timeouts with manual reset to balance predictable refresh with flexibility.
- **Invalidate per security group**: If only certain groups are affected, clear cache entries selectively rather than globally.

Carefully plan invalidation frequency. Excessively frequent invalidation negates the benefits of caching, while infrequent invalidation risks serving stale or incorrect data.

### Concurrency

In multi-user or multithreaded environments, cache methods may be called concurrently by different threads. Without proper synchronization, this can cause race conditions, redundant data fetching, or an inconsistent cache state.

To handle concurrency safely:

- Use thread-safe collections such as `ConcurrentDictionary` for shared caches.
- Protect critical sections (e.g., cache initialization or updates) with locks (`lock` statement or other synchronization primitives).
- Use double-checked locking to ensure that initialization/updating occurs only once per cache cycle, minimizing duplicate work.
- Be mindful to keep locks as short as possible to reduce contention and avoid deadlocks.

Proper concurrency management ensures reliable, consistent caching behavior without wasting resources or causing data corruption.

## Example

For a full, detailed example implementation of an ad hoc data source with caching, concurrency handling, and security group support, refer to [Scaling an ad hoc data source](xref:Scaling_Ad_hoc_Data_Source).
