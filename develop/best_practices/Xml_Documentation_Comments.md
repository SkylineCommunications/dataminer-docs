---
uid: Xml_Documentation_Comments
---

# XML documentation comments

Below, you can find a number of best practices for writing XML documentation comments.

XML documentation comments are structured comments used to provide API documentation. See the following example:

```csharp
/// <summary>
/// Retrieves the value of the parameter with the specified ID.
/// </summary>
/// <param name="iID">The ID of the parameter.</param>
/// <returns>The value of the parameter. If no parameter with the specified ID exists in the protocol, <see langword="null"/> is returned.</returns>
/// <remarks>
///     <list type = "bullet" >
///         <item>
///             <description>This is a wrapper method for the Notify type 73 (NT_GET_PARAMETER) call.</description>
///         </item>
///         <item>
///             <description>When a GetParameter call is executed for a parameter that does not exist in the protocol, <see langword="null"/> is returned and the following message will be logged “NT_GET_PARAMETER for [parameterID] failed. 0x80040239”.</description>
///         </item>
///         <item>
///             <description>When calling this method on a numeric standalone parameter(i.e.a parameter having RawType set to either numeric text, signed number or unsigned number) that is not initialized, 0 will be returned.To determine whether a standalone parameter is uninitialized, the <see cref="IsEmpty"/> method should be used.</description>
///         </item>
///     </list>
/// </remarks>
/// <example>
///     <code>
///     string myValue = Convert.ToString(protocol.GetParameter(100));
///     </code>
/// </example>
```

## Generating XML documentation

To generate an XML documentation file, you need to provide XML documentation comments for your source files. For more information, see:

- [Insert XML comments for documentation generation](https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-xml-documentation-comments?view=vs-2022)
- [Recommended XML tags for C# documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags)
- [Documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
- [Annex D Documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)

In addition to providing the documentation comments, you also need to configure a setting to instruct the compiler to create an XML documentation file as output. This can be done in the *Build* tab of the *Project Properties* window. In the *Output* section, select the *XML documentation file* option:

![](~/develop/images/BuildConfigurationSetting_1024x668.png)

Enabling this option will result in an XML file being generated in addition to the compiled assembly.

## Using XML Documentation

If you reference a DLL file in your solution for which an XML documentation file exists, Visual Studio will provide additional IntelliSense information that is extracted from this documentation file:

![](~/develop/images/IntelliSenseExample_1024x157.png)

Also, the *Object Browser* window provides information extracted from the XML documentation file:

![](~/develop/images/ObjectBrowserExample_1024x542.png)

XML documentation comments are not only useful for IDEs such as Visual Studio. Documentation tools such as [docfx](https://dotnet.github.io/docfx/) and [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB) also support processing XML documentation comments to automatically generate API documentation.

## Best practices

Whereas the sections above provide more information on how to create and use XML documentation comments, this section provides some best practices related to the style that is typically used when writing XML documentation comments. Where applicable, examples will be provided from documented classes in [Microsoft Learn](https://learn.microsoft.com/).

### General

- All types and their members that are part of the public API should be properly documented.
- Documentation text must start with an uppercase letter and end with a period.
- Summaries for classes, methods, properties, events, etc. should start with a verb in third person singular form. For example: "Represents ...", "Initializes a new instance of ...", "Gets or sets ...", "Retrieves ...", etc.
- Summaries should be kept small. Additional information can be provided in the `<remarks>` tag.
- XML documentation comments must be valid XML. For example, use XML entities to avoid XML parsing issues when providing code examples:

  ![](~/develop/images/XML_entities.png)

### Constructors

The summary of a constructor of a class should always start with the following, where `className` is the name of the class:

```csharp
Initializes a new instance of the <see cref="className"/> class ...
```

For example, the [String(Char[])](https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=net-6.0#System_String__ctor_System_Char___) constructor of the `System.String` class is documented as follows:

> Initializes a new instance of the [String](https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0) class to the Unicode characters indicated in the specified character array.

For structures, the following should be used:

```csharp
Initializes a new instance of the <see cref="structName"/> structure ...
```

### Properties

The summary of a property should always start with:

- `Gets` for read-only properties
- `Sets` for write-only properties (note: use of write-only properties is not recommended)
- `Gets or sets` for read-write properties

For example, the [Length](https://learn.microsoft.com/en-us/dotnet/api/system.string.length?view=net-6.0) property of the `System.String` class is documented as follows:

> Gets the number of characters in the current [String](https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0) object.

For boolean properties, the summary should start with:

```csharp
Gets a value indicating whether
```

For example, the [IsFixedSize](https://learn.microsoft.com/en-us/dotnet/api/system.array.isfixedsize?view=net-6.0) property of the `Array` class:

> Gets a value indicating whether the [Array](https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0) has a fixed size.

In addition to the `<summary>` tag, for properties the `<value>` tag should be used. Here, a description can be provided for the property. For boolean properties, the documentation should have the following format:

```csharp
<c>true</c> if …; otherwise, <c>false</c>
```

For example, the [HasShutdownStarted](https://learn.microsoft.com/en-us/dotnet/api/system.environment.hasshutdownstarted?view=net-6.0) property of the `Environment` class:

> `true` if the current application domain is being unloaded or the CLR is shutting down; otherwise, `false`.

### Methods

For methods, in addition to the `<summary>` tag, a `<param>` tag should be provided for each parameter. The return value must be documented with a `<returns>` tag (a void method should not have a `<returns>` tag).

For example, the [EndsWith(Char)](https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith?view=net-6.0#System_String_EndsWith_System_Char_) method of the `String` class:

```csharp
/// <summary>
/// Determines whether the end of this string instance matches the specified character.
/// </summary>
/// <param name="value">The character to compare to the character at the end of this instance.</param>
/// <returns><c>true</c> if value matches the end of this instance; otherwise, <c>false</c>.</returns>
/// <remarks>This method performs an ordinal (case-sensitive and culture-insensitive) comparison.</remarks>
```

### Exceptions

Members such as a constructor, method, properties, etc. that throw an exception should be documented with an `<exception>` tag for each type of exception that can be thrown. The `cref` attribute must be provided, specifying the exception class, and the documentation text must specify the reason for the exception:

```csharp
<exception cref="ArgumentNullException"><paramref name="destination"/> is <see langword="null"/>.</exception>
```

For example, the [CopyTo(Int32, Char[], Int32, Int32)](https://learn.microsoft.com/en-us/dotnet/api/system.string.copyto?view=net-6.0#System_String_CopyTo_System_Int32_System_Char___System_Int32_System_Int32_) method of the `String` class:

> [ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-6.0)
> destination is null.

Note the use of the `<paramref>` tag to refer to a parameter. The `<see>` tag with the `langword` attribute can be used to denote a language keyword such as "null".

> [!TIP]
>
> - [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers) (an implementation of the StyleCop rules using the .NET Compiler Platform API) can be of great help when creating XML documentation comments. See the [documentation rules](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/DocumentationRules.md) for an overview of all the rules related to XML documentation that are implemented.
> - The following Visual Studio extension can be used to easily detect spelling mistakes: [Visual Studio Spell Checker](https://marketplace.visualstudio.com/items?itemName=EWoodruff.VisualStudioSpellCheckerVS2022andLater)
