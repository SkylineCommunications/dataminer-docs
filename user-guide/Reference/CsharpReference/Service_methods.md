---
uid: Service_methods
---

# Service methods

### GetPropertyValue

Gets the value of the specified service property.

Returns null if the property was not found.

```txt
string GetPropertyValue(string propertyName)
```

Example:

```txt
var myService = engine.FindService(179, 15629);
if(myService.HasProperty("myProperty"))
{
 string myPropertyValue = myService.GetPropertyValue("myProperty");
}
```

### HasProperty

Determines whether this service has a property with the specified property name.

Returns true if the service has a property with the specified name.

```txt
bool HasProperty(string propertyName)
```

Example:

```txt
var myService = engine.FindService(179, 15629);
if(myService.HasProperty("myProperty"))
{
 string myPropertyValue = myService.GetPropertyValue("myProperty");
}
```

### SetPropertyValue

Sets the value of the specified service property.

```txt
void SetPropertyValue(string propertyName, string propertyValue)
```

Example:

```txt
var myService = engine.FindService(179, 15629);
if(myService.HasProperty("myProperty"))
{
 myService.SetPropertyValue("myProperty", "myPropertyValue");
}
```
