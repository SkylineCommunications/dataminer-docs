---  
uid: Validator_3_36_1  
---

# CSharpCheckUnrecommendedConstructor

## UnrecommendedXmlSerializerConstructor

### Description

Constructor '{typeUnrecommendedConstructor}' ('{constructorNamespace}') is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.36.1      |
| Severity     | Critical    |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Use one of the following constructors:  
\- XmlSerializer.XmlSerializer(Type)  
\- XmlSerializer.XmlSerializer(Type, String)

### Details

As mentioned on Microsoft docs (https:\/\/learn.microsoft.com\/en\-us\/dotnet\/api\/system.xml.serialization.xmlserializer):  
To increase performance, the XML serialization infrastructure dynamically generates assemblies to serialize and deserialize specified types. The infrastructure finds and reuses those assemblies. This behavior occurs only when using the following constructors:  
\- XmlSerializer.XmlSerializer(Type)  
\- XmlSerializer.XmlSerializer(Type, String)  
If you use any of the other constructors, multiple versions of the same assembly are generated and never unloaded, which results in a memory leak and poor performance. The easiest solution is to use one of the previously mentioned two constructors.
