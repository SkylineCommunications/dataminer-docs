---
uid: InterAppCalls_KnownTypes
keywords: known types
---

# InterApp: known types

As the InterApp framework allows for a lot of freedom in the creation of the message classes, it is necessary to deserialize the message with the correct classes. That is why a list of types needs to be passed along in several locations.

```csharp
List<Type> knownTypes = new List<Type>
{
    // Messages
    typeof(MyMessage),
    typeof(MyResponse),

    // Subclasses
    typeof(MySubClass),
    typeof(List<MyOtherSubClass>)    
};
```

For ease of use, we recommend adding all the classes for each message in your API to a single list of known types. This will make it easier for the receiving side as the receiver does not know which message it will parse.

> [!IMPORTANT]
>
> - The list must be the same at the sender and the receiver side, and it should contain every single class in your API. It is for example not supported to have connector A with (Type1, Type2, Type3) as *knownTypes* members while automation script B only has the members (Type1, Type2). If you break this rule, this can lead to situations where the serialization will define "ChildClass" as the type, whereas the deserialization expects "NameSpace.ChildClass".
> - The known types need to contain all the custom classes. When a collection with the < and > signs is used, add them as well as shown in the example above.

> [!NOTE]
> We recommend that you add the knownTypes as a public static list in a custom solution where all your messages are written. This way you avoid having to copy/paste and maintain them from several locations.
