---
uid: Linking_a_shape_to_a_program_or_a_file
---

# Linking a shape to a program or a file

Using a shape data field of type **Link** you can link a shape to a program or a file.

When you link a shape to a program or a file, the program will be started or the file will be opened when a user clicks the shape.

> [!NOTE]
>
> - This is a client-side function. The program or file must reside on the user's client machine.
> - If you specify a file to be opened, but not the program in which it has to be opened (see the PDF example below), make sure the file type is associated with the correct program. Otherwise, DataMiner will not know which program to use.
> - You can also use Windows environment variables in the shape data field, for instance to link to virtual paths. However, for custom variables that have only just been created, a reboot will be required before they can be used.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > EXE]* page.

## Configuring the shape data field

Add a shape data field of type **Link** to the shape, and set its value to:

```txt
FileName|Parameters|Tooltip
ProgramName|Parameters|Tooltip
```

Default tooltips:

- Link to 'FileName'
- Link to 'ProgramName'

## Examples

- Clicking the shape will cause the specified file to be opened in Notepad.

  ```txt
  C:\Windows\Notepad.exe|C:\MyTxtFiles\OneOfMyTxtFiles.txt|Click to open in Notepad
  ```

- Clicking the shape will cause the specified file to be opened in its associated program (in this case: Adobe Acrobat Reader). As no tooltip has been specified, the default tooltip will appear when users hover over the shape: *Link to 'C:\\Documentation\\MyLargeManual.pdf'*.

  ```txt
  C:\Documentation\MyLargeManual.pdf
  ```

- Clicking the shape will cause the file of which the name is specified in parameter 15 of element 256 to be opened in the associated program. When users hover over the shape, they will see a tooltip showing the name of the file as it is stored in the specified parameter.

  ```txt
  C:\Documentation\[param:256,15]|[param:256,15]
  ```
