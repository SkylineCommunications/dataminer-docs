---
uid: DMASTString
---

# DMASTString

DMASTString is an object used within a service template configuration to dynamically create aspects of the generated services, for example "*Child element - \[data:Data Item Name\] - \[element:1:title\]*"

This is parsed into:

- A template string, e.g., "*Child element - {0} - {1}*"

- An array of ordered placeholders (*DMASTPlaceholder*).

The following kinds of placeholders can be used:

- *DMASTDataPlaceholder*: Placeholder referring to input data. Consists of:

  - *Name* (string): The name of the placeholder.

  - *Type* (*DMASTType*): The type of input data: *Input*, *ServiceProperty*, *SLAProperty* or *Special*.

- *DMASTElementPlaceholder*: Placeholder referring to an element in the generated service that uses *DMASTElementData*:

  - *DMASTChildElement*: The placeholder refers to a child element. Consists of:

    - *ChildID* (integer): The ID of the child element.

    - *Data* (DMASTChildData):

      - *DMASTChildInfo*: The placeholder refers to the info of the child element. Contains a field key (*DMASTChildInfoKey*), which can be *Name*, *Key* or *Title*.

      - *DMASTChildField*: The placeholder refers to a field of the child element. Contains a *Name* (string) field.

      - *DMASTElementInfo*: The placeholder refers to the element info of the child element. This can be a property or a parameter, and is defined in the same way as *DMASTCustomElement* (see below).

    - *DMASTCustomElement*: The placeholder refers to a property or a parameter of a custom element. Consists of:

      - *DataMinerID*

      - *ElementID*

      - *Data* (*DMASTElementProperty*), consisting of a *Name* (string) or a *Parameter* (*DMASTElementParameter*).

        - *DMASTElementParameter* in turn consists of a *ParameterID* (int) and *Index* (*DMASTString*, without placeholders filled in).
