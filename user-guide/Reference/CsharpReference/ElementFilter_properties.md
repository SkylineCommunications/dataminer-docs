---
uid: ElementFilter_properties
---

# ElementFilter properties

- [CriticalOnly](#criticalonly)

- [DataMinerID](#dataminerid)

- [ElementID](#elementid)

- [ExcludeSubViews](#excludesubviews)

- [IncludeHidden](#includehidden)

- [IncludePaused](#includepaused)

- [IncludeServiceElements](#includeserviceelements)

- [IncludeStopped](#includestopped)

- [MajorOnly](#majoronly)

- [MaskedOnly](#maskedonly)

- [MinorOnly](#minoronly)

- [NameFilter](#namefilter)

- [NormalOnly](#normalonly)

- [ProtocolName](#protocolname)

- [ProtocolVersion](#protocolversion)

- [TimeoutOnly](#timeoutonly)

- [View](#view)

- [ViewID](#viewid)

- [WarningOnly](#warningonly)

### CriticalOnly

Gets or sets a value indicating whether only elements with severity state “Critical” should be included.

Default: false.

```txt
bool CriticalOnly
```

### DataMinerID

Gets or sets a value limiting the search to the specified DataMiner Agent ID.

```txt
int DataMinerID
```

### ElementID

Gets or sets a value limiting the search to the specified element ID.

```txt
int ElementID
```

> [!NOTE]
> If you specify *ElementID*, *also specify DataMinerID*.

### ExcludeSubViews

Gets or sets a value indicating whether subviews should be searched.

Default: false.

```txt
bool ExcludeSubViews
```

> [!NOTE]
> If you specify *ExcludeSubViews*, also specify *View* or *ViewId*.

### IncludeHidden

Gets or sets a value indicating whether hidden elements should be included.

Default: true

```txt
bool IncludeHidden
```

### IncludePaused

Gets or sets a value indicating whether paused elements should be included.

Default: true

```txt
bool IncludePaused
```

### IncludeServiceElements

Gets or sets a value indicating whether service elements should be included. Available from DataMiner 9.6.11 onwards.

Default: false.

```txt
bool IncludeServiceElements
```

### IncludeStopped

Gets or sets a value indicating whether stopped elements should be included.

Default: true

```txt
bool IncludeStopped
```

### MajorOnly

Gets or sets a value indicating whether only elements with severity state "Major" should be included.

Default: false.

```txt
bool MajorOnly
```

### MaskedOnly

Gets or sets a value indicating whether only masked elements should be included.

Default: false.

```txt
bool MaskedOnly
```

### MinorOnly

Gets or sets a value indicating whether only elements with severity state "Minor" should be included.

Default: false.

```txt
bool MinorOnly
```

### NameFilter

Gets or sets a filter for the element name, which can contain \* and ? wildcards.

```txt
string NameFilter
```

### NormalOnly

Gets or sets a value indicating whether only elements with severity state "Normal" should be included.

Default: false.

```txt
bool NormalOnly
```

### ProtocolName

Gets or sets a filter for the protocol name. No wildcards are allowed.

```txt
string ProtocolName
```

### ProtocolVersion

Gets or sets a filter for the protocol version. No wildcards are allowed.

```txt
string ProtocolVersion
```

### TimeoutOnly

Gets or sets a value indicating whether only elements with severity state "Timeout" should be included.

Default: false.

```txt
bool TimeoutOnly
```

### View

Gets or sets the name of the view to be searched.

```txt
string View
```

### ViewID

Gets or sets the ID of the view to be searched.

```txt
int ViewID
```

### WarningOnly

Gets or sets a value indicating whether only elements with severity state "Warning" should be included.

Default: false.

```txt
bool WarningOnly
```
