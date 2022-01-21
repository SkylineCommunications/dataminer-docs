---
uid: ScriptMemory_properties
---

## ScriptMemory properties

#### Id

Gets the ID of this script memory.

```txt
int Id
```

#### IsVolatile

Gets a value indicating whether the memory file only exists during script execution.

```txt
bool IsVolatile
```

#### LinkedFile

Gets the name of the persistent script memory.

```txt
string LinkedFile
```

> [!NOTE]
> For a volatile script memory, this property returns an empty string ("").

#### Name

Gets the name of the this script memory.

```txt
string Name
```
