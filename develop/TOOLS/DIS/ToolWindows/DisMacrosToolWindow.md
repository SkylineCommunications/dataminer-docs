---
uid: DisMacrosToolWindow
---

# DIS Macros

If you click *Tool Windows > DIS Macros*, the *DIS Macros* window will appear.

By default, the *DIS Macros* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

This tool window allows you to create C# scripts that can be used to make changes to e.g. a protocol file (for example, update OIDs based on conditions, update table definitions, increment/decrement parameters, etc.).

In the tool window, you can set up a folder structure into which you can then store the macros you create. It is also possible to export a macro folder to a zip file and to import a zip file containing macros as a child folder of an existing folder.

At the top of the tool window, you find two buttons: *Run* and *Open*.

- Click *Run* to run the selected macro.

- Click *Open* to edit the selected macro.

![DIS Macros tool window](~/develop/images/DisMacrosToolWindow.png)

> [!NOTE]
>
> - When you run a macro, it will always affect the last XML or C# document that was active.
> - When you try to open a DIS macro while working inside a protocol or Automation script solution, a message will appear, asking whether you want to open the DIS macro in a new Visual Studio instance.

## Structure of a macro file

In essence, a DIS macro consists of a Script class containing a Run() method that passes an Engine object. That object provides access to input data and allows you to modify the document, write log entries, etc.

The following input data is available in the "engine.Input" object:

- File name

- File content

- Cursor position

- Selected text blocks (start, length and contents)

- If the macro is run on a *protocol.xml* file:

  - Parsed XML object structure

  - Parsed protocol model

The following methods are available in the "engine" object:

| Method              | Function                                                                   |
|---------------------|----------------------------------------------------------------------------|
| LogToOutputWindow() | Log a message to Visual Studio's Output pane.                              |
| ShowInputBox()      | Request user input.                                                        |
| ReplaceAllText()    | Replace all text in the document.                                          |
| ReplaceText()       | Replace a specified block of text in the document.                         |
| InsertText()        | Insert new text at a specified position.                                   |
| DeleteText()        | Delete a specified block of text.                                          |
| XmlEdit             | Group a series of changes that will afterwards be applied to the document. |
| ProtocolEdit        | Group a series of changes that will afterwards be applied to the document. |
