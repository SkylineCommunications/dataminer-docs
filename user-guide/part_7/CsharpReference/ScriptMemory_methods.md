## ScriptMemory methods

#### Clear

Removes all values from the memory file.

```txt
void Clear()
```

Example:

```txt
ScriptMemory memory = engine.GetMemory("memory");
if(memory != null)                               
{                                                
    memory.Clear();                              
}                                                
```

#### Get

Gets one of the values from the memory file. The memory position can be specified by name or by ID.

```txt
object Get(int position)       
object Get(string positionDesc)
```

Examples:

```txt
ScriptMemory memory = engine.GetMemory("myMemory");
object myValue = memory.Get(1);                    
```

```txt
ScriptMemory memory = engine.GetMemory("myMemory");
object myValue = memory.Get("myEntryDescription"); 
```

#### Set

Sets the given value in the memory file. The memory position can be specified by name or by ID.

```txt
void Set(int position, object val)       
void Set(string positionDesc, object val)
```

Examples:

```txt
ScriptMemory memory = engine.GetMemory("myMemory");
object myValue = memory.Set(10, "myValue");        
```

```txt
ScriptMemory memory = engine.GetMemory("myMemory");          
object myValue = memory.Set("myEntryDescription", "myValue");
```
