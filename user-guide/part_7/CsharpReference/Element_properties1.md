## Element properties

- [DmaId](#dmaid)

- [Dummy](#dummy)

- [ElementId](#elementid)

- [ElementName](#elementname)

- [Id](#id)

- [IsActive](#isactive)

- [Name](#name)

- [PollingIP](#pollingip)

- [ProtocolName](#protocolname)

- [ProtocolVersion](#protocolversion)

#### DmaId

Gets the ID of the DataMiner Agent on which the element was created.

```txt
int DmaId
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
int agentId = element.DmaId;                    
```

#### Dummy

Gets the script dummy that is linked to the element.

```txt
ScriptDummy Dummy
```

#### ElementId

Gets the ID of the element that is linked to the dummy.

```txt
int ElementId
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
int elementId = element.ElementId;              
```

#### ElementName

Gets the name of the element that is linked to the dummy.

```txt
string ElementName
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string elementName = element.ElementName;       
```

#### Id

Gets the ID of the element that is linked to the dummy.

```txt
int Id
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
int id = element.Id;                            
```

#### IsActive

Gets a value indicating whether the element is active (i.e. not stopped or paused).

```txt
bool IsActive
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
bool isActive = element.IsActive;               
```

#### Name

Gets the name of the element.

```txt
string Name
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string elementName = element.Name;              
```

> [!NOTE]
> This property returns the following string: "\_\<agentID>\_\<elementID>" (e.g. "\_100_5612"). To retrieve the element name, use the *ElementName* property.

#### PollingIP

Gets the polling IP address of the element.

```txt
string PollingIP
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string pollingIP = element.PollingIP;           
```

#### ProtocolName

Gets the name of the protocol of the element.

```txt
string ProtocolName
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string protocolName = element.ProtocolName;     
```

#### ProtocolVersion

Gets the protocol version used by the element.

```txt
string ProtocolVersion
```

Example:

```txt
Element element = engine.FindElement(400, 2000); 
string protocolVersion = element.ProtocolVersion;
```
