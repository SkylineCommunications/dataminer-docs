---
uid: ElementFilter_methods
---

# ElementFilter methods

- [ByID](#byid)

- [ByName](#byname)

- [ByProtocol](#byprotocol)

- [ByView](#byview)

### ByID

Retrieves a new *ElementFilter* object that has *DataMinerID* and *ElementID* set to the specified DataMiner Agent ID and element ID, respectively.

```txt
ElementFilter ByID(int dataMinerID, int elementID)
```

Example:

```txt
var filter = ElementFilter.ByID(200, 4000);
```

### ByName

Retrieves a new *ElementFilter* object that has *NameFilter* set to the specified element name filter.

```txt
ElementFilter ByName(string name)
```

Example:

```txt
var filter = ElementFilter.ByName("Test*");
```

### ByProtocol

Retrieves a new *ElementFilter* object that has *ProtocolName* set to the specified protocol name filter, or *ProtocolName* and *ProtocolVersion* set to the specified protocol name and version filter.

```txt
ElementFilter ByProtocol(string name)
ElementFilter ByProtocol(string name, string version)
```

Examples:

```txt
var filter = ElementFilter.ByProtocol("Microsoft Platform");
```

```txt
var filter = ElementFilter.ByProtocol("Microsoft Platform", "1.0.0.1");
```

### ByView

Retrieves a new *ElementFilter* object that, depending on the parameters specified, has

- *ViewID* set to the specified view ID,

- *View* set to the specified view name,

- *ViewID*, *ProtocolName* and *ProtocolVersion* set to the specified view ID, protocol name and protocol version, or

- *View*, *ProtocolName* and *ProtocolVersion* set to the specified view name, protocol name and protocol version.

```txt
ElementFilter ByView(int id)
ElementFilter ByView(string name)
ElementFilter ByView(int id, string protocolName, string protocolVersion)
ElementFilter ByView(string name, string protocolName, string protocolVersion)
```

Examples:

```txt
var filter = ElementFilter.ByView(202);
```

```txt
var filter = ElementFilter.ByView("MyView");
```

```txt
var filter = ElementFilter.ByView(202, "Microsoft Platform", "1.0.0.1");
```

```txt
var filter = ElementFilter.ByView("MyView", "Microsoft Platform", "1.0.0.1");
```
