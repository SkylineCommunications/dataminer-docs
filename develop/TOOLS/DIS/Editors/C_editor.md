---
uid: C_editor
---

# C# editor

If, in a file tab containing a protocol XML file or an Automation script XML file, you click an *Edit C#* button in front of a QAction or an Exe code block, a temporary C# project will be created, containing the code of that QAction or Exe code block. Also, the code of the QAction or Exe code block will appear in a new, customized file tab.

![C# editor](~/develop/images/DIS_CSharpEditor.png)

> [!NOTE]
> DIS defines a default set of analysis rules for QAction projects. These rules can then be used by Visual Studio extensions like e.g. SonarLint or StyleCop to analyze the code.
>
> - When, in Visual Studio, your solution is in release mode, analysis is disabled for performance reasons.
> - Analysis is always disabled for the QAction_Helper and QAction_ClassLibrary projects.

## File tab header

In the header of a file tab containing the C# code of a QAction or Exe code block, you can find two links:

- A link to return to the file tab containing the associated protocol XML file or Automation script XML file at the location where the cursor was positioned when you last viewed the file.
- A link to return to the associated protocol XML file or Automation script XML file at the location where the QAction or Exe code block is found.

## Inside the file tab

### IntelliSense

When you edit the C# code of a QAction or Exe code block, all regular C# editing features (including IntelliSense) are at your disposal.

### Copying the entire protocol to the Windows Clipboard

If you right-click anywhere in the editor and select the *Copy Protocol to Clipboard* command, the entire content of the protocol XML file will be copied to the Windows Clipboard.

### Copying the entire content of the file to the Windows Clipboard

If you right-click anywhere in the editor and select the *Copy Code to Clipboard* command, the entire content of the file will be copied to the Windows Clipboard.

When you use this menu option while working with a protocol solution or an Automation script solution, you will not only copy the current file to the Windows clipboard, but all files of the entire project combined in a way that is similar to the way in which they are combined when the solution is compiled.

### Repeating selected text

The right-click menu option *Repeat Selected Text* allows you to select a particular piece of text and have it copied a number of times. Moreover, by inserting variables and formulas in the text to be copied, you can have parts of the text change automatically from copy to copy.

1. Select the text that has to be repeated, right-click, and select *Repeat Selected Text.*
1. In the *DIS Repeater* window, if necessary, go to the *Template* box, and edit the text you want to have repeated.
1. If you want to insert a variable (or a formula including a variable) in the text to be repeated, then do the following:
    - Place your cursor where you want the variable or formula to be inserted, and click *Insert placeholder*.
    - If necessary, change the default placeholder that appeared at the location where you placed your cursor: a single value "x" delimited by "$" characters. You could change it to e.g. "$x+5$".
1. At the bottom of the window, select *Overwrite Selection*, if you want the text you selected to be overwritten by the text that is currently displayed in the *Preview* box.
1. Click *OK* to have the text in the *Preview* box pasted in the editor.

#### Using "$" characters inside a formula

When you insert a variable or a formula into the text to be copied, that variable or formula is delimited by "$" characters. If you want to use a "$" character inside a formula, you have to put an escape character in front of it. Example: $(x\*10)+"\\$"$.

#### Defining the range of value "x"

The range of value "x" can be defined using the range definition boxes at the top of the window.

There are two ways to define the range:

- Specify a starting "x" value in *Start* and a number of iterations in *Count*.
- Specify a starting "x" value in *Start* and an ending "x" value in *End*.

In both cases, you can also specify a step size in *Step*.

### Inserting snippets

DataMiner Integration Studio comes with a number of custom C# snippets.

To insert a snippet while working in the C# editor:

1. Press CTRL+K, followed by CTRL+X.
1. Open the *DIS* folder, and select a snippet.

### #If DEBUG

In a QAction, you can insert special code blocks that will only be taken into account when the *QAction.dll* has been compiled in Debug mode.

The following code block will be disregarded in *QAction.dll* files compiled in Release mode.

```txt
#if DEBUG
    ...
#endif
```
