## ScriptDummy methods

#### GetExternalInterfaces

Available from DataMiner 10.1.5/10.2.0 onwards. Retrieves all external DataMiner Connectivity Framework interfaces for this dummy.

```txt
Interface[] GetExternalInterfaces()
```

Example:

```txt
var dummy = engine.GetDummy(1);
var externalInterfaces = dummy.GetExternalInterfaces();
```

#### GetInternalInterfaces

Available from DataMiner 10.1.5/10.2.0 onwards.Retrieves all internal DataMiner Connectivity Framework interfaces for this dummy.

```txt
Interface[] GetInternalInterfaces()
```

Example:

```txt
var dummy = engine.GetDummy(1);
var internalInterfaces = dummy.GetInternalInterfaces();
```
