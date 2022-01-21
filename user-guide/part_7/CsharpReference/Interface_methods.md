---
uid: Interface_methods
---

## Interface methods

- [GetNext](#getnext)

- [GetNexts](#getnexts)

- [GetPropertyValue](#getpropertyvalue)

- [HasProperty](#hasproperty)

- [SetPropertyValue](#setpropertyvalue)

#### GetNext

Returns the interface to which the specified interface is connected.

If there is no connected interface, a null reference is returned.

```txt
Interface GetNext(String connectionNameFilter);
```

Using the following overload, you can make sure that you do not get the same interface twice, especially when performing a sequence of multiple GetNext calls.

```txt
Interface GetNext(String connectionNameFilter, Interface previousInterface);
```

Example:

```txt
Interface newInterface = nextInterface.GetNext("*",lastInterface);
```

#### GetNexts

Returns all interfaces connected to the current interface. This is especially useful in cases where a connection splits up into multiple internal connections.

You can filter by connection name in order to limit the number of connections that will be returned.

```txt
Interface[] GetNexts(string connectionNameFilter);
```

Like for the *GetNext* method, you can use the following overload to pass along the previous interface. This can be useful in case of star topology setups where all interfaces are connected to one interface defined from source to destination, or vice versa.

```txt
Interface[] GetNexts(string connectionNameFilter, Interface previousInterface);
```

Example:

```txt
Interface[] nextInterfaces = interface.GetNexts("MyConnection",previousInterface);
```

#### GetPropertyValue

Gets the value of a property by providing the property name.

If there is no property with the specified name, a null reference is returned.

```txt
virtual String GetPropertyValue(String propertyName);
```

Example:

```txt
Element element = engine.FindElement("MyElement");

if(element != null)
{
 Interface myInterface = element.GetInterface("MyInterface");

 if(myInterface != null)
 {
 if(myInterface.HasProperty("MyProperty"))
 {
 string propertyValue = myInterface.GetPropertyValue("MyProperty");
 ...
 }
 }
}
```

#### HasProperty

Determines whether a property with the specified name exists.

```txt
virtual bool HasProperty(String propertyName);
```

Example:

```txt
Element element = engine.FindElement("MyElement");

if(element != null)
{
 Interface myInterface = element.GetInterface("MyInterface");

 if(myInterface != null)
 {
 if(myInterface.HasProperty("MyProperty"))
 {
 string propertyValue = myInterface.GetPropertyValue("MyProperty");
 ...
 }
 }
}
```

#### SetPropertyValue

Sets the value of a property.

```txt
virtual void SetPropertyValue(string propertyName, string propertyValue);
```

Example:

```txt
Element element = engine.FindElement("MyElement");

if(element != null)
{
 Interface myInterface = element.GetInterface("MyInterface");

 if(myInterface != null)
 {
 if(myInterface.HasProperty("MyProperty"))
 {
 myInterface.SetPropertyValue("MyProperty", "MyPropertyValue");
 }
 }
}
```
