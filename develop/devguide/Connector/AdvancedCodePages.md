---
uid: AdvancedCodePages
---

# Code pages

A code page is used to convert a text character to a unique number, called a code point, and vice versa. It is this number that is kept in memory and is saved to elementdata in the database.

## Windows code page

When the unicode [option](xref:Protocol.Type-options) is not explicitly defined in a connector, string-type parameters default to using the *system-default ANSI code page* configured on the server OS hosting DataMiner e.g., Windows-1252 (Latin 1). As the terminology *system-default ANSI code page* can be confusing with the formal ANSI standard, it will be further referred to as the *Windows code page*. Windows-1252 (Latin 1) contains 256 characters, being assigned to 256 numbers, and fit into a single-byte (0x00 - 0xFF).

String values that enter, e.g., through a protocol.SetParameter from a QAction, are always in UTF-16 encoding format. Before being stored in the parameter, the incoming (Unicode) character is looked up into the Windows code page to know what the code point is and store this number. If a character present in the Unicode code page cannot be represented in the Windows code page (e.g., an emoji), it is replaced with a default character. For Windows-1252 (Latin 1), this defaults to the question mark '?'.

Because the Windows code page depends on the OS configuration, parameter values may differ across DMAs with different settings.
For example:

- If the OS uses Windows-1252 (Latin 1) and a Unicode character Â (0x00C2 UTF-16 encoding) is set on a parameter. This character is also known in Windows-1252 and translates into byte 0xC2, which is the correct expected character.
- If the Windows code page is changed to Windows-1251 (Cyrillic), the previously stored byte 0xC2 will now be loaded from the database and translated with this Windows code page as the Cyrillic capital letter VE (0x0412 UTF-16 encoding), resulting in a different (unexpected) character being displayed by the parameter.
- Setting again the same character Â under Windows-1251 (Cyrillic) on the parameter will fail to map correctly and will be saved and displayed as the default '?' character.

Another example is the '€' character which is supported by multiple Windows code pages but maps to different byte value:

- Under Windows-1252 (Latin 1), it maps to byte 0x80.
- Under Windows-1251 (Cyrillic), it maps to byte 0x88.

The different mapping affects how the inserted character is stored and is sent in a serial command towards a device.

Due to these inconsistencies, it is recommended to only use characters inside of the ASCII subset range (0x00-0x7F).
Characters beyond ASCII range (0x80-0xFF) may behave unpredictably depending on the Windows code page.
Elements should use Unicode to avoid such issues.

Improvements introduced in RN43929, available since DataMiner version 10.6.1, help make transitions between the Windows code page and Unicode smoother for elements with stored values:

- Table primary key values are always stored in Unicode. This ensures consistent row loading, regardless of the code page.
- The Unicode characters are also saved in the database when a string value enters on a saved string-type parameter, e.g. via protocol.SetParameter call in a QAction, or a write parameter with the setter="true" attribute. This enables an element that switches to a Unicode version to load and display the text as it was originally set on the parameter.

> [!NOTE]
> Saving Unicode data of elements that use the Windows code page is not supported with a local MySQL database.
>
> Exporting an element that uses the Windows code page to a DELT package will not include the Unicode data.

## Unicode

Unicode itself is also a code page like the Windows code pages, but contains all possible characters, including emojis.

### Encoding

How the unique code point values are stored is defined by the encoding. There is for example UTF-8, UTF-16, and UTF-32 encoding. UTF-8 is typically used for web pages, while UTF-16 is more used in programming languages on Windows or Java. The encodings are capable to store all characters of the Unicode code page, but store the code points in a different way. UTF-8 only uses one byte to store the range 0x00-0x7F, which contains the standard ASCII characters. When the most significant bit is one, more bytes follow to represent the character. UTF-16 uses two or more bytes to store a code point. The range of the standard ASCII characters will be 0x0000 - 0x007F. When the string content only consists of ASCII characters, UTF-8 will use half number of bytes needed compared to UTF-16 (1 byte per character versus 2 bytes). There are also a number of common used characters that are stored in a region called Basic Multilingual Plane (BMP). UTF-8 takes 3 bytes to store such character, while UTF-16 takes 2 bytes. When the string content only consists of characters of the BMP region then UTF-8 encoding uses 1.5 times more memory compared to UTF-16 (3 bytes per character versus 2). An example is the '€' character. This one takes two bytes in UTF-16 encoding: 0x20AC, and three bytes in UTF-8 encoding: 0xE282AC. UTF-32 always uses fixed four bytes per code point and results for the '€' character in 0x000020AC. UTF-32 encoding takes most memory but performs faster as there is a one-to-one mapping between the code point number and the stored byte value.
Receiving raw bytes without knowing the used code page and encoding when communicating with a device means that a connector is not able to translate this into the correct characters.

E.g., 0xE282AC is in:

- UTF-8 one character: '€'
- UTF-16 two characters: one PUA character (may render as a black box), followed by one 'not sign' character.
- Windows-1252 three characters: 'â´', followed by one 'not sign' character.

### Composed characters

Some Latin characters could be represented by two code points.
This can be considered like typing with a French AZERTY keyboard where a character 'é' can be typed either by pressing the key 'é' directly (one code point), or by first pressing the accent key '´' (one code point) and then pressing the 'e' key (second code point).
With Unicode it is the same principle: either there is one code point (=precomposed character), or there are two code points (=decomposed character): one code point for the base char 'e' and one code point for the non-spacing char '´'.
When a device sends data as a decomposed character then this could be wrongly displayed as two separate characters when assuming that precomposed characters are used: displaying 'e´' instead of 'é'.

## Unicode in connectors

When the unicode [option](xref:Protocol.Type-options) is explicitly defined in a connector, string-type parameters data is stored with UTF-16 encoding with precomposed characters.

Special cases when a parameter has Interprete RawType set to 'numeric text' in combination with the Interprete Type:

- 'double' is always handled as ASCII encoding with one byte per character, regardless of the Unicode setting.
- 'string' is handled as UTF-16 encoding when the Unicode option is defined.

### Fixed parameters

Avoid combining Interprete Value together with Interprete Length for fixed parameters.
If an Interprete Length is specfied then the parameter value must adhere to this Interprete Length:

- The parameter value is prefixed with spaces if the Interprete Value is smaller than the Interprete Length.
- If the Interprete Value is larger than the Interprete Length, the Interprete Value is ignored and the parameter value is filled with spaces up to the specified length. This could lead to unexpected results in Unicode when an odd Interprete Length is defined, as the UTF-16 encoding of a space char is two bytes.

The parameter value will be different when in Unicode or Windows code page, as the length is defined in bytes.
Examples:

- Interprete Value 'Hello1' with Interprete Length 12:
  - Windows code page: Parameter value '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hello1' (6 prefix spaces + 6 characters)
  - Unicode: Parameter value 'Hello1' (two bytes per character, 12 bytes total, no prefix spaces needed)
- Interprete Value 'Hello1' with Interprete Length 6
  - Windows code page: Parameter value 'Hello1' (6 characters)
  - Unicode: Parameter value '&nbsp;&nbsp;&nbsp;' (two bytes per character, would require 12 bytes in total, replaced with default three prefix spaces)

To simplify connector development, for a fixed string-type parameter only define Interprete Value without the Interprete Length. This ensures consistent loading of the Interprete Value in both Windows code page and Unicode.

If a fixed series of byte values that should remain the same in Windows code page and Unicode (e.g., to send a serial command or match a serial response), use Interprete Value in '0x' format (e.g., 0x02).
This preserves the byte values without converting them to Windows code page or Unicode.

### Serial commands

The byte value sent to a device depends on the Interprete definition of the parameter. Unicode applies only to parameters that have Interprete Type 'string' in combination with an Interprete RawType 'other', or something else related to text. Unicode string parameters are sent as UTF-16 encoding in little endian format. E.g., the '€' character 0x20AC is sent as AC20 with the least significant byte first.

By specifying the ascii="true" option on a command, all string-type parameters of that command will be sent as Windows code page byte values. Numeric parameters will not be converted, nor parameters with Interprete Value defined with the hardcoded '0x' format.
Specifying a parameter ID in the ascii attribute of a command forces the conversion of the value from Unicode to Windows code page, regardless of the Interprete definition.

### Serial responses

Response data enters as raw bytes and is directly inserted in parameters.
Parameters with Interprete Type 'double' and Interprete RawType 'numeric text' are decoded as ASCII with one byte per character. E.g. 0x31 becomes '1' displayed.

The interpretation of the raw bytes of a parameter back to string text depends on the Unicode option:

- When Unicode is active, these raw bytes are considered to represent UTF-16 encoded characters and are interpreted like this, which could lead to unexpected results when the device is not sending in UTF-16 encoded format.
- When Windows code page is active, these raw bytes are considered to represent the current Windows code page, which could also lead to unexpected results when the device is sending in a different format.

As there is no ascii attribute on a response when Unicode is active, correctly interpreting the raw bytes as ASCII or Windows code page string text requires manual handling.
Read the raw bytes with a QAction and use the applicable encoding (e.g., Encoding.ASCII.GetString) to convert the bytes into a string. Then set that string on a displayed parameter.

### Trap binding OctetString

A parameter that is used to receive traps with the setBindings="allBindingInfo", results in the received value that needs to be processed with a QAction. In case of a binding of type OctetString, the returned value will either be a readable string when all characters are printable, or a string in HEX format. In case a readable string is returned, but the raw bytes would be needed, it will need to be converted back from text to bytes. For example, when a binding contains a MAC address in the OctetString has byte values 0x313233343536, the returned value in the QAction will be '123456'.

Converting the readable string value back to a string in HEX format can be done with below code example. Every byte value of the OctetString is directly inserted into one Unicode character, without performing any mapping with the used code page. The Unicode.GetBytes needs to be used to get the exact byte value of the OctetString back, even when the connector is not using the Unicode option. As only one byte is inserted per Unicode character, only the bytes on the even positions are needed back from the decoded Unicode bytes. Do not use a different encoding like System.Text.Encoding.Default.GetBytes. At first sight it looks correct when the server uses Windows-1252 and the content is limited to characters in the ASCII range. The same number of bytes are returned as in the OctetString. However, it could be that the inserted byte was e.g. 0x8C, pushed into Unicode UTF-16 as 0x008C, which is in Unicode a control character. This control character does not exist in Windows-1252, defaulting back to the question mark '?' = 0x3F. Instead of getting back the inserted byte 0x8C, the returned byte will be 0x3F.

```csharp
// Expected size of the MAC address is in this example 6 bytes.
// When the returned value has a length of 12, e.g. '313233343536', then this is in HEX format and 'mac' can be used as is.
// When the returned value has a length of 6, e.g. '123456', then this is a readable text and needs to be converted back to the HEX format.
if (mac.Length == 6)
{
    byte[] rawBytes = System.Text.Encoding.Unicode.GetBytes(mac); // Converting the Unicode text back to bytes. Size of rawBytes will be zero.
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    for (int i = 0; i < rawBytes.Length; i+=2 /*Only take byte values on even positions into account*/)
    {
        sb.AppendFormat("{0:x2}", rawBytes[i]); // Format byte as HEX in lower case.
    }

    mac = sb.ToString();
}
```

## Converting an existing connector into Unicode

The following steps need to be taken to account when implementing Unicode in an existing connector that was using Windows code page.

- First thing to be defined is the unicode [option](xref:Protocol.Type-options) .
- When there are fixed length parameters with an Interprete Value and Interprete Length defined, remove the Interprete Length, but do consider when prefixed spaces when the Interprete Length would be larger than the Interprete Value.
- Elements with a serial connection will have to be adapted: the ascii attribute needs to be added to the commands to let the command send the same value as before. String type parameters cannot be displayed directly anymore: define new hidden parameters to be used in the response. A QAction should read out the raw bytes of the response hidden string parameter with a NotifyProtocol NT_GET_DATA. Then convert these bytes back into a string e.g., with Encoding.ASCII.GetString, and set that string value to the displayed parameter that was originally in the response of the previous connector version.

> [!NOTE]
> These steps are assuming that the connector will run on a minimum DataMiner version 10.6.1 that includes RN43929. There are breaking changes before this RN that could result in different behavior. Fixed parameters with a value as text in combination with Unicode was not supported. Specify the value in the 0x format to make it compatible on DataMiner version prior to RN43929. The ascii="true" on a command was applied to all parameters in the command, even on numeric text parameters. Explicitly specify the parameter IDs in the ascii attribute to make it compatible on DataMiner versions prior to RN43929.
