---
uid: DIS_2.8
---

# DIS 2.8

## New features

### IDE

#### MIB browser: ‘Remove All’ button \[ID_17225\]

Up to now, when you wanted to remove a number of MIB files from the MIB browser’s *Files* tab, you had to remove one file at a time by clicking the *Remove* button next to every file.

From now on, when you want to remove multiple MIB files at once, you can select all of them and click *Remove* in the *Files* tab menu bar.

> [!NOTE]
> To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.

#### Table editor: Default column option separator will now be enforced \[ID_17314\]

The table editor will now enforce the use of a semicolon as default column option separator.

- If the first character in a column option string is a separator other than a semicolon, that character will be replaced by a semicolon.
- If a column option string does not start with a separator character, then a semicolon will be added in front of the option string.

#### Protocol tree: Parameters of type 'group', 'read bit' and 'write bit' are now indicated in parameter list \[ID_17332\]

Up to now, when you opened the *Params* node in the *Protocol Tree* window, table parameters and write parameters were indicated by "\[Table\]" and "\[W\]" respectively.

Now, the following types of parameters will also have a special indication:

| Content of \<Type> tag | Indication |
|------------------------|------------|
| group                  | \[Group\]  |
| read bit               | \[RB\]     |
| write bit              | \[WB\]     |

In a protocol editing window, "jump to linked item" buttons (also known as paper clip buttons) will now also indicate relationships between group parameters and bit parameters.

### Validator

#### Validation of DefaultValue tags \[ID_17440\]

The Validator will now issue

- a warning when DefaultValue is defined on a column parameter of type "read", and
- an error when DefaultValue is defined on a parameter that is not of type "read" (e.g. write, fixed, etc.).

| Result code | Class       | Description                                                                                   |
|-------------|-------------|-----------------------------------------------------------------------------------------------|
| 5100        | Information | Default Value tags OK.                                                                        |
| 5101        | Error       | Parameter with Type \[Type\] should not contain a Default Value tag.                          |
| 5102        | Warning     | Column Parameter should not contain a Default Value tag. This is currently not yet supported. |

#### Error in case a button or page button was defined on a parameter of which the type is not 'write' \[ID_17445\]

The Validator will now issue an error when a button or page button was defined on a parameter of which the type is not "write".

| Result code | Class       | Description                                 |
|-------------|-------------|---------------------------------------------|
| 5200        | Information | Buttons OK.                                 |
| 5201        | Error       | Measurement has no Type tag.                |
| 5202        | Error       | Button is only allowed on write parameters. |

## Changes

### Enhancements

#### IDE - Protocol editor: Improved Edit table and Edit C# buttons \[ID_17241\]

In the protocol editor, the Edit table and Edit C# buttons have been improved.

- Click the *Edit table* button in front of the \<Param> tag of a table parameter to immediately open that table in the table editor.
- Click the *Edit C#* button in front of a \<QAction> tag to immediately open that QAction in a new file tab.

#### C# code snippets now all comply with the coding guidelines \[ID_17335\]

All C# code snippets now fully comply with the coding guidelines.

### Fixes

#### IDE - Protocol editor: ‘Generate write parameters for Read parameters’ command would not remove the \<DefaultValue> tag \[ID_17224\]

When a new write parameter was generated using the ‘Generate write parameters for read parameters’ command, in some cases, the parameter’s \<Interprete>\<DefaultValue> tag would not be removed. This could potentially lead to situations in which a change made to the write parameter was not detected because the new value was equal to the default value. This problem has now been fixed.

#### IDE - Display editor: Default page would be reset when it did not contain any parameters \[ID_17258\]

In some cases, the display editor would reset the default page when that page did not contain any parameters. This problem has now been fixed.

#### IDE - Table editor: Column options no longer converted to lowercase \[ID_17313\]

In some cases, dynamic items defined in \<ColumnOption> tags would incorrectly be converted to lower case when you applied changes made in the table editor. An options attribute like `;save;SelectionSetVar:VariableName` would, for example, get converted to `;save;SelectionSetVar:variablename`. This problem has now been fixed.

#### Validator: Problem when a column parameter could not be found \[ID_17394\]

Up to now, the Validator would throw an exception when a \<ColumnOption> tag referred to a non-existing parameter. From now on, it will generated an error instead.

| Result code | Class | Description                                                    |
|-------------|-------|----------------------------------------------------------------|
| 1702        | Error | Table column parameter \[Column parameter ID\] does not exist. |
