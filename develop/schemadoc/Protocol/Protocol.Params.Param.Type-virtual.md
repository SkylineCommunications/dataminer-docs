---
uid: Protocol.Params.Param.Type-virtual
---

# virtual attribute

Configures which virtual element connections are allowed to and from elements based on the protocol you are creating.

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Remarks

A connection restraint can be made up of the following sections, separated by a colon (“:”).

|Section|Type|Description|
|--- |--- |--- |
|Source/destination|Mandatory|Indicates whether the element or parameter is allowed to be either the source or the destination of a virtual element connection. Example: "source"|
|Protocol|Optional|Narrows down the elements with which a connection is allowed based on the protocol. Example: If you specify "Protocol=Motorola SEM", then connections will only be allowed to or from elements based on the protocol named “Motorola SEM”.|
|Parameter description|Optional|Narrows down the elements with which a connection is allowed based on the existence of a specific parameter. Example: If you specify "Parameterdescription=Summary Alarm Other Device", then connections will only be allowed to or from elements that have a parameter with the description “Summary Alarm Other Device”.|

You can specify multiple connection restraints, separated by a pipe character (“|”).

## Examples

```xml
<Type virtual="source:Protocol=Motorola SEM:Parameterdescription=Summary Alarm Other Device">read</Type>
```
