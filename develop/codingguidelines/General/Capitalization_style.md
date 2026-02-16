---
uid: Capitalization_style
---

# Capitalization style

Throughout this chapter, two capitalization styles are mentioned: Pascal case and Camel case.

- Pascal case (hereafter referred to as PascalCasing) refers to the capitalization style where the first letter of the identifier and the first letter of each subsequent concatenated word are capitalized.

- Camel case (hereafter referred to as camelCasing) refers to the capitalization style where the first letter of an identifier is lowercase and the first letter of each subsequent concatenated word is capitalized.

| Casing                                                                                                                                                 | Identifier type                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| **PascalCasing** ([SA1300](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1300)) | Namespace, Type (Class, Interface, Struct, Enumeration), Method, Property, Event |
| **camelCasing**                                                                                                               | Parameter<br> Local variable                                                     |

### Compound words

- Words that are part of a closed-form compound word (i.e., compound words written as a single word, e.g., endpoint) should not be capitalized, but should be treated as a single word.

### Acronyms and Initialisms

- Acronyms or initialisms consisting of only two characters should be capitalized (e.g., "PollingIP"). PascalCasing or camelCasing should be used for acronyms that consist of more than two characters (e.g., "SnmpResponse" or "snmpResponse" instead of "SNMPResponse").
