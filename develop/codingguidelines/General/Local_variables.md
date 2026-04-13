---
uid: Local_variables
---

# Local variables

Local variables must have a meaningful name and camelCasing must be applied.

### Hungarian notation

Names of local variables may start with a prefix denoting their type (so-called Hungarian notation), but this is not required.

Hungarian notation allows related variables to have the same name, except for the type prefix. For example, suppose there is a string variable "sStartTime", representing a time. The corresponding variable of type DateTime can then be named "dtStartTime" or "startTime". Without the prefix, it is more difficult to have a unique name for both variables.

In general, using Hungarian notation for all variable names is *not encouraged*. However, when you do use Hungarian notation, you must use the following prefixes:

- **Built-in Types**

  | C# type                            | .NET Framework Type | Prefix | Example           |
  |--------------------------------------|---------------------|--------|-------------------|
  | **bool**    | System.Boolean      | b      | bIsBusy           |
  | **byte**    | System.Byte         | by     | byCommand         |
  | **sbyte**   | System.SByte        | sby    | sbyCommand        |
  | **char**    | System.Char         | c      | cProtocolType     |
  | **decimal** | System.Decimal      | dec    | decSignalStrength |
  | **double**  | System.Double       | d      | dSignalStrength   |
  | **float**   | System.Single       | f      | fSignalStrength   |
  | **int**     | System.Int32        | i      | iRowCount         |
  | **uint**    | System.UInt32       | ui     | uiRowCount        |
  | **long**    | System.Int64        | l      | lErrorCount       |
  | **ulong**   | System.UInt64       | ul     | ulErrorCount      |
  | **object**  | System.Object       | o      | oResponse         |
  | **short**   | System.Int16        | sh     | shStatusCode      |
  | **ushort**  | System.UInt16       | ush    | ushStatusCode     |
  | **string**  | System.String       | s      | sResponse         |

- **Other**

  | Class  | Prefix | Example    |
  |--------|--------|------------|
  | **System.DateTime** | dt     | dtNow      |
  | **System.TimeSpan** | ts     | tsHour     |
  | **System.Text.StringBuilder** | sb     | sbResponse |
  | **System.Xml.Linq.XDocument**<br> **System.Xml.Linq.XElement**<br> **System.Xml.Linq.XAttribute** | x      | xDocument  |

- **Arrays**

  For array variables, the type prefix must be preceded by an additional "a" to indicate an array (e.g., string\[\] *asServiceNames*).

- **Strongly Typed Collections (System.Collections.Generic)**

  The following table gives an overview of the different prefixes that should be used for collections. In case a collection has only one type (e.g., HashSet\<*T*\>), the identifier should include the type prefix (e.g., HashSet\<*string*\> *hssDevices*).

  Plural nouns should be used for lists and sets.

  | Class                         | Prefix | Example                                 |
  |-------------------------------|--------|-----------------------------------------|
  | **Dictionary\<TKey, TValue>** | dict   | Dictionary\<string,string> dictMappings |
  | **HashSet\<T>**               | hs     | HashSet\<string> hssDeviceTypes         |
  | **LinkedList\<T>**            | ll     | LinkedList\<string> llsNames            |
  | **List\<T>**                  | l      | List\<string> lsNames                   |
  | **Stack\<T>**                 | s      | Stack\<string> ssCalls                  |
  | **Queue\<T>**                 | q      | Queue\<string> qsMessages               |

- **Private fields**

  Private fields may start with an underscore ("\_"), followed by the prefix defined above if applicable. However, the use of "this." is favored over the use of underscores to denote a local class field.

- **Booleans**

  The name of a local variable of type Boolean should start with a verb (e.g., foundCarrier, isPresent).

- **Enumerations**

  For enum variables, the prefix "e" may be used.
