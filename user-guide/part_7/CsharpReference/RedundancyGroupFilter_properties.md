## RedundancyGroupFilter properties

- [DataMinerID](#dataminerid)

- [ExcludeSubViews](#excludesubviews)

- [GroupID](#groupid)

- [NameFilter](#namefilter)

- [View](#view)

- [ViewID](#viewid)

#### DataMinerID

Gets or sets a value limiting the search to the specified DataMiner Agent ID.

```txt
int DataMinerID
```

#### ExcludeSubViews

Gets or sets a value indicating whether subviews should be searched.

```txt
bool ExcludeSubViews
```

> [!NOTE]
> If you specify *ExcludeSubViews*, also specify *View* or *ViewId*.

#### GroupID

Gets or sets a value limiting the search to the specified redundancy group ID.

```txt
int GroupID
```

> [!NOTE]
> If you specify *GroupID*, also specify *DataMinerID*.

#### NameFilter

Gets or sets a filter for the redundancy group name, which can contain \* and ? wildcards.

```txt
string NameFilter
```

#### View

Gets or sets the name of the view to be searched.

```txt
string View
```

#### ViewID

Gets or sets the ID of the view to be searched.

```txt
int ViewID
```
