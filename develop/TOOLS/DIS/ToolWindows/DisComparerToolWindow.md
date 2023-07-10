---
uid: DisComparerToolWindow
---

# DIS Comparer

If you click *Tool Windows > DIS Comparer*, the *DIS Comparer* window will appear.

This tool window allows you to compare two *protocol.xml* files.

By default, the *DIS Comparer* window will open undocked. Dock it just as you would dock any other tool window in Visual Studio.

![DIS Comparer tool window](~/develop/images/DisComparerToolWindow.png)

If you want to compare two protocols, do the following:

1. At the top of an XML editor tab containing a *protocol.xml* file, click *Compare*.

1. In the *DIS Comparer* tool window, select the two protocols to be compared.

   To select a protocol (either on the left or on the right), do the following:

   1. Click *Select protocol...*

   1. In the Select Protocol... window, select an option:

      - Select *Opened protocol*, and select one of the protocols currently opened in the XML editor.

      - Select *File*, click *Select protocol...*, and select a *protocol.xml* file located in a file folder.

      - Select *Previous release*, and select one of the previous versions of a protocol currently opened in the XML editor.

      > [!NOTE]
      >
      > - If you select *File* or *Previous release* when working inside a solution, the protocol you select will not be added to the solution.
      > - For the *Previous release* option to work, the DataMiner Integration Studio has to be able to connect to `https://api.skyline.be/*`.

   1. Click *OK*.

   After selecting the two protocols, the comparison will start automatically.

1. If necessary, click *Compare* to redo the comparison or click *Export* to have the result of the comparison exported to a CSV file.

When you compare two protocols, DIS will also automatically validate both these protocols. When comparison and validation have finished, you will see two tabs:

- *Major Change* - The result of the protocol comparison.

- *Validator* - The differences between the two protocol validations.

When you right-click an error in the list, a shortcut menu offers you the following options:

| Command | Function |
|---------|----------|
| Navigate | Go to the line in the protocol that triggered the error. |
| Copy | Copy the error to the Windows Clipboard. |
| Show Details... | Show all details of the error in a separate window. |
| Suppress... | Suppress the error.<br> Note: Click the *Show/hide suppressed results* button to include/exclude the suppressed errors in/from the list. |

> [!NOTE]
>
> - In the DIS Comparer pane, you can select multiple items. To select more than one item, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive items, click the first one in the list and then click the last one while holding down the SHIFT key. Use this feature to e.g. copy or suppress a number of results in one go. However, note that suppressing a number of results will only work when all selected items have the same error code.
> - Use the filter box in the top-right corner to filter the comparison results.
