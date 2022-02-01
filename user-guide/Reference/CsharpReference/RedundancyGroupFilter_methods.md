---
uid: RedundancyGroupFilter_methods
---

# RedundancyGroupFilter methods

- [ByID](#byid)

- [ByName](#byname)

- [ByView](#byview)

### ByID

Creates a new *RedundancyGroupFilter* object with *DataMinerID* and *GroupID* set to the specified DataMiner Agent ID and redundancy group ID, respectively.

```txt
RedundancyGroupFilter ByID(int dataMinerID, int groupID)
```

Example:

```txt
var filter = RedundancyGroupFilter.ByID(200, 4000);
```

### ByName

Creates a new *RedundancyGroupFilter* object with *NameFilter* set to the specified name filter.

```txt
RedundancyGroupFilter ByName(string name)
```

Example:

```txt
var filter = RedundancyGroupFilter.ByName("Test*");
```

### ByView

Creates a new *RedundancyGroupFilter* object with *ViewID* set to the specified view ID or *View* set to the specified view name.

```txt
RedundancyGroupFilter ByView(int id)
RedundancyGroupFilter ByView(string name)
```

Examples:

```txt
var filter = RedundancyGroupFilter.ByView(202);
```

```txt
var filter = RedundancyGroupFilter.ByView("MyView");
```
