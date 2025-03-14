---
uid: Protocol-EnumSNMPType
---

# EnumSNMPType simple type

Specifies the SNMP type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|counter32|Represents a non-negative integer which monotonically increases until it reaches a maximum value of 2^32-1 (4294967295 decimal), when it wraps around and starts increasing again from zero.|
|&nbsp;&nbsp;Enumeration|counter64|Represents a non-negative integer which monotonically increases until it reaches a maximum value of 2^64-1 (18446744073709551615 decimal), when it wraps around and starts increasing again from zero.|
|&nbsp;&nbsp;Enumeration|counter64String|Can be used to receive the SNMP counter64 as a string, where the counter64 uses double and may therefore lose definition.<!-- RN 9284 -->|
|&nbsp;&nbsp;Enumeration|gauge32|Represents a non-negative integer, which may increase or decrease, but shall never exceed a maximum value, nor fall below a minimum value. The maximum value cannot be greater than 2^32-1 (4294967295 decimal), and the minimum value cannot be smaller than 0.|
|&nbsp;&nbsp;Enumeration|integer|Represents integer-valued information between -2^31 and 2^31-1 inclusive.|
|&nbsp;&nbsp;Enumeration|integer32|Represents integer-valued information between -2^31 and 2^31-1 inclusive.|
|&nbsp;&nbsp;Enumeration|ipaddress|Represents an IP address.|
|&nbsp;&nbsp;Enumeration|nsapaddress|Represents an OSI address as a variable-length OCTET STRING.|
|&nbsp;&nbsp;Enumeration|null|Indicates effective absence of a sequence element.|
|&nbsp;&nbsp;Enumeration|objectid|Represents administratively assigned names.|
|&nbsp;&nbsp;Enumeration|octetstring|Represents arbitrary binary or textual data.|
|&nbsp;&nbsp;Enumeration|octetstringhex||
|&nbsp;&nbsp;Enumeration|octetstringascii||
|&nbsp;&nbsp;Enumeration|octetstringutf8||
|&nbsp;&nbsp;Enumeration|octetstringdecimal||
|&nbsp;&nbsp;Enumeration|oid|A globally unique value associated with an object to unambiguously identify it.|
|&nbsp;&nbsp;Enumeration|opaque|Provided solely for backward-compatibility, and shall not be used for newly-defined object types.|
|&nbsp;&nbsp;Enumeration|timeticks|Represents a non-negative integer which represents the time, modulo 2^32 (4294967296 decimal), in hundredths of a second between two epochs.|
|&nbsp;&nbsp;Enumeration|uinteger32|The Unsigned32 type represents integer-valued information between 0 and 2^32-1 inclusive (0 to 4294967295 decimal).|
