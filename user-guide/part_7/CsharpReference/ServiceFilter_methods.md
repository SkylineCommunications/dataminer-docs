---
uid: ServiceFilter_methods
---

# ServiceFilter methods

### ByID

Creates a new *ServiceFilter* object with *DataMinerID* and *ServiceID* set to the specified DataMiner Agent ID and service ID, respectively.

```txt
ServiceFilter ByID(int dataMinerID,int serviceID)
```

Example:

```txt
var filter = ServiceFilter.ByID(200, 4000);
```

### ByName

Creates a new *ServiceFilter* object with *NameFilter* set to the specified name filter.

```txt
ServiceFilter ByName(string name)
```

Example:

```txt
var filter = ServiceFilter.ByName("Test*");
```

### ByView

Creates a new *ServiceFilter* object with *ViewID* set to the specified view ID or *View* set to the specified view name.

```txt
ServiceFilter ByView(int id)
ServiceFilter ByView(string name)
```

Examples:

```txt
var filter = ServiceFilter.ByView(202);
```

```txt
var filter = ServiceFilter.ByView("MyView");
```
