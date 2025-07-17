---
uid: Message_syntax
---

# Message syntax

Every message in a communication stream is constructed according to the following syntax:

```txt
[Direction] [PackageName]
[Package content - HEX] [Package content - ASCII]
```

- **Direction**: The transmission direction of the package:

    | Symbol | Description         |
    |----------|---------------------|
    | \<\<     | From DMA to element |
    | \>\>     | From element to DMA |

- **PackageName**: The name that the protocol developer assigned to the package.

- **Package content - HEX**: The actual content of the package in hexadecimal format.

    - All data is arranged in blocks of 5 bytes, so one row contains 20 bytes in total.

    - The first block is a header added by the DMA to conveniently number the rows of 20 bytes.

- **Package content - ASCII**: The actual content of the package in ASCII format.

    - Non-printable characters are replace by a dot (”.”).

    - Note that not all protocols use ASCII characters. Therefore, this ASCII representation only makes sense if the protocol uses ASCII characters.

> [!NOTE]
> - If a timeout occurs, e.g. when the element did not send a valid response, the keyword “TIMEOUT” is added to the stream.
> - If you connect to SNMP elements using telnet, Get and Set commands will only be shown in ASCII format.
> - Depending on the logging level of an element, additional information may be displayed in the communication stream (e.g. calculations performed by the protocol using values retrieved from the element).
>
