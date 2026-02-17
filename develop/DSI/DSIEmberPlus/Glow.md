---
uid: Glow
---

# Glow

The Glow DTD (Design Type Document) specification defines object types required for a device to represent its structure.

The number of types defined in Glow is limited and the most used ones are "Node" and "Parameter". A node represents a device and its elements (e.g., modules, cards, etc.). A parameter contains the properties of a control (e.g., name, read-write access, range, etc.).

#### Data types

To indicate the meaning and the type of the encoded data that follows next, tags are used. A tag consists of two components: a class (consisting of 1 byte) and a number (consisting of 4 bytes).

The following table provides an overview of the different classes:

| Class       | Value | Description                                                                       |
|-------------|-------|-----------------------------------------------------------------------------------|
| Universal   | 0x00  | Predefined types. Should never be used.                                           |
| Application | 0x40  | Application-specific tags have the same meaning wherever they are seen and used.  |
| Context     | 0x80  | The meaning of context-specific tags depends on the location where they are seen. |
| Private     | 0xD0  | A special version of the context-specific tag.                                    |

#### Universal data types

| Number     | Type                     |
|------------|--------------------------|
| 1          | Boolean                  |
| 2          | Integer                  |
| 3          | Bitstring                |
| 4          | Octet String             |
| 5          | Null                     |
| 6          | Object Identifier        |
| 7          | Object Descriptor        |
| 8          | External                 |
| 9          | Real                     |
| 10         | Enumerated               |
| 11         | Embedded Pdv             |
| 12         | UTF8 String              |
| 13         | Relative Object          |
| 16         | Sequence                 |
| 17         | Set                      |
| 18         | Numeric String           |
| 19         | Printable String         |
| 20         | Teletex String           |
| 21         | Videotex String          |
| 22         | IA5 String               |
| 23         | UTC Time                 |
| 24         | Generalized Time         |
| 25         | Graphic String           |
| 26         | Visible String           |
| 27         | General String           |
| 28         | Universal String         |
| 29         | Unspecified String       |
| 30         | BMP String               |
| 31         | Last Universal           |
| 0x80000000 | Application defined type |

#### Application data types

| Number | Type                    |
|--------|-------------------------|
| 0      | Root                    |
| 1      | Parameter               |
| 2      | Command                 |
| 3      | Node                    |
| 4      | ElementCollection       |
| 5      | StreamCollection        |
| 6      | StreamEntry             |
| 7      | StringIntegerPair       |
| 8      | StringIntegerCollection |
| 9      | QualifiedParameter      |
| 10     | QualifiedNode           |
| 11     | RootElementCollection   |

The Glow specification uses a set of attributes that are used to describe a node or parameter. Refer to the Ember+ specification for more information.

#### Commands

| Number | Command      |
|--------|--------------|
| 30     | Subscribe    |
| 31     | Unsubscribe  |
| 32     | GetDirectory |
