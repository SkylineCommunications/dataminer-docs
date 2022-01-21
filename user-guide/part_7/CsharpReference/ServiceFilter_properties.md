---
uid: ServiceFilter_properties
---

## ServiceFilter properties

- [CriticalOnly](#criticalonly)

- [DataMinerID](#dataminerid)

- [ExcludeSubViews](#excludesubviews)

- [MajorOnly](#majoronly)

- [MinorOnly](#minoronly)

- [NameFilter](#namefilter)

- [NormalOnly](#normalonly)

- [ServiceID](#serviceid)

- [TimeoutOnly](#timeoutonly)

- [View](#view)

- [ViewID](#viewid)

- [WarningOnly](#warningonly)

#### CriticalOnly

Gets or sets a value indicating whether to only include services with severity state "Critical".

```txt
bool CriticalOnly
```

#### DataMinerID

Gets or set a value limiting the search to the specified DataMiner Agent.

```txt
int DataMinerID
```

#### ExcludeSubViews

Gets or sets a value indicating whether to only exclude subviews from the search.

```txt
bool ExcludeSubViews
```

> [!NOTE]
> If you specify ExcludeSubViews, also specify View or ViewId.

#### MajorOnly

Gets or sets a value indicating whether to only include services with severity state "Major".

```txt
bool MajorOnly
```

#### MinorOnly

Gets or sets a value indicating whether to only include services with severity state "Minor".

```txt
bool MinorOnly
```

#### NameFilter

Gets or sets a filter for the service name, which can contain \* and ? as wildcards.

```txt
string NameFilter
```

#### NormalOnly

Gets or sets a value indicating whether to only include services with severity state "Normal".

```txt
bool NormalOnly
```

#### ServiceID

Gets or sets a value limiting the search to the service with the specified service ID.

```txt
int ServiceID
```

> [!NOTE]
> If you specify *ServiceID*, also specify *DataMinerID*.

#### TimeoutOnly

Gets or sets a value indicating whether to only include services with severity state "Timeout".

```txt
bool TimeoutOnly
```

#### View

Gets or sets the name of the view to search for.

```txt
string View
```

#### ViewID

Gets or sets the ID of the view to search for.

```txt
int ViewID
```

#### WarningOnly

Gets or sets a value indicating whether to only include services with severity state "Warning".

```txt
bool WarningOnly
```
