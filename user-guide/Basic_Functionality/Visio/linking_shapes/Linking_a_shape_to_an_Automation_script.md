---
uid: Linking_a_shape_to_an_Automation_script
---

# Linking a shape to an Automation script

When a shape is linked to an Automation script, by default this script will be executed each time a user clicks that shape.

> [!NOTE]
>
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Operations* > *Other* > *Visual Overview Design Examples* view > *[linking > EXE]* page.
> - Aside from the default **Execute** shape data, you can also use **OnClose** shape data to link to a script. See [Specifying a script to be executed when the page is closed](#specifying-a-script-to-be-executed-when-the-page-is-closed).

To link a shape to an Automation script:

- Add a shape data field of type **Execute** to the shape, and set its value to:

  ```txt
  Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...|ParameterName1=SingleValue;ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|Tooltip|Options
  ```

  - In the example above, two parameters are included. The first parameter is assigned a single value, and the second parameter is assigned a so-called permanent memory file (i.e. an array of values). Notice that, in the latter case, a hash character ("#") has to be placed in front of the name of the array. See also: [Creating a memory file](xref:Script_variables#creating-a-memory-file)

  - If you use the syntax above, make sure to always include 5 pipe characters ("\|"). If you do not need some parts of the syntax, e.g. because no memory files are used, just add nothing between those pipe characters.

  - For an overview of the options, see [Options](#options).

  - Examples:

    - To execute the script "MyScript" with a particular dummy and parameter, the following value can be specified. In this case, no confirmation box will appear and SET commands will be executed without waiting for a return value. Also, when users hover over the shape, they will see a custom tooltip.

      | Shape data field | Value                                                                                       |
      | ---------------- | ------------------------------------------------------------------------------------------- |
      | Execute          | Script:MyScript\|Dummy 1=MyElement\|MyParameter=12\|\|My tooltip\|NoConfirmation,NoSetCheck |

    - To simply execute the script without any particular options, the following value can be specified. In that case, if the script uses dummies, parameters or memory files, during the execution of the script the user will be prompted to specify them.

      | Shape data field | Value           |
      | ---------------- | --------------- |
      | Execute          | Script:MyScript |

      > [!NOTE]
      >
      > - If a script uses a parameter that has a memory file assigned to it, users can right-click the shape and select a value from the memory file. This way, the parameter can be set immediately, without confirmation.
      > - Up to DataMiner 9.0.4, it is not possible to execute an Automation script from Visual Overview if some values for the parameters still have to be entered by the operator.

- From DataMiner 10.2.0/10.1.1 onwards, an alternative syntax can be used where each component is marked by a prefix. The advantage of this alternative syntax is that you do not have to define empty components in case there are no dummies, no memory files, etc.

  - The following prefixes can be used:

    - "Parameters:"
    - "Dummies:"
    - "MemoryFiles:"
    - "Options:"
    - "Tooltip:"

  - If you use these prefixes, you must use them for every component. The components can be specified in any order.

  - Example:

    | Shape data field | Value                                                                                          |
    | ---------------- | ---------------------------------------------------------------------------------------------- |
    | Execute          | Script:\<myScript>\|Tooltip:\<myTooltip>\|Parameters:paramA=\<myParam>\|Options:NoConfirmation |

- From DataMiner 9.5.7 onwards, the **Execute** shape data field can be combined with other shape data that make the shape perform an action when clicked. In that case, the Automation script specified in the **Execute** field will be executed before the main action is performed.

  For example, if the following shape data are specified, the Automation script in the Execute field will be used to set parameters before the main action shows these in a pop-up window.

  | Shape data field | Value                                     |
  | ---------------- | ----------------------------------------- |
  | View             | MyView                                    |
  | VdxPage          | MyPage\|Popup                             |
  | Execute          | Script:MyScript\|Dummy01=\[this service\] |

## Specifying a script to be executed when the page is closed

From DataMiner 9.5.7 onwards, you can link a page to a script, which is then executed when the card, pop-up window or tooltip showing the page is closed.

To do so, add an **OnClose** shape data field to the page, and set it to the script that is to be executed. To specify more than one script, use a dash ("-") as the separator character.

For example:

| Shape data field | Value                                                                                   |
| ---------------- | --------------------------------------------------------------------------------------- |
| OnClose          | Script:MyScript01\|Dummy01=\[this service\]-Script:MyScript02\|Dummy01=\[this service\] |

## Using an alternative separator character

From DataMiner 9.0.5 onwards, it is possible to specify an alternative separator character with a \[sep:XY\] tag.

For example, in the configuration below, the first-level separator "\|" is replaced by "\*" and the "=" separator is replaced by "?".

```txt
[sep:|$]Script:MyAutomationScript$[sep:=?]MyDummy?221/65$[sep:=?]Parameter?101$$$NoWait
```

> [!TIP]
> See also: [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters)

## Passing Automation script output to session variables

From DataMiner 10.0.13 onwards, when an Automation script executed in Visual Overview finishes successfully, the output values of that script can be passed to session variables in Visual Overview. From DataMiner 10.2.6/10.3.0 onwards, this is also supported for interactive Automation scripts.

To configure this in the script, use the *CreateKey(string variablename)* method (namespace: *Skyline.DataMiner.Automation*, class name: *UIVariables.VisualOverview*).

In the following example, a session variable named "MyOutput" will be created, and it will receive the value "MyValue".

```txt
engine.AddScriptOutput(UIVariables.VisualOverview.CreateKey("MyOutput"), "MyValue");
```

- If you execute the same Automation script on different pages, you can use the *SessionVariablePrefix* option to make sure the output is saved in separate session variables. For example, if you use prefix "One\_" on one page and prefix "Two\_" on another page, and the Automation scripts pass their output to a session variable named "MyPage", then the output will end up in two separate session variables named "One_MyPage" and "Two_MyPage" respectively.

- When you set the *SetVarOnFail* option to true (either on page level or shape level), the session variables will always be created, regardless of whether the script finishes successfully or not.

- In case the session variable (in this case "MyOutput") already exists, it will be updated; otherwise it will be created as a new session variable.

- By default, the scope of the session variable will be global. If a different scope should be used, configure this using the **Options** shape data field on the Execute shape, with one of the following values

  - "CardVariable" (for a card variable)
  - "PageVariable" (for a page variable)
  - "WorkspaceVariable" (for a workspace variable)

  For example:

  | Shape data field | Value                                                                  |
  | ---------------- | ---------------------------------------------------------------------- |
  | Execute          | Script:Test_SessionsVariable\|\|\|\|\|NoConfirmation,CloseWhenFinished |
  | Options          | CardVariable                                                           |

## Options

In the **Execute** shape data value, you can use the following options (separated by commas).

- **Asynchronous**: The script will be executed asynchronously.

- **CloseWhenFinished**: Forces the script to close automatically when finished.

- **ForceLock**: If elements used in the script are locked by another script being executed simultaneously, they will be unlocked and then locked again by this script.

- **FullScreen**: Forces the dialog boxes of the interactive script to be displayed in fullscreen mode.

- **Lock**: All elements used in the script will be locked during the execution of the script.

- **NoConfirmation**: No confirmation box will appear when users click the shape. However, this option is only applied when all necessary dummies and parameters have been specified in the Visio file.

- **NoSetCheck**: If SET commands are executed within the script, the script will not check to see whether those commands were processed properly or not. Normally, if you do not specify this option, each time a script executes a SET command, before it continues it will check whether the value of the parameter in question was indeed changed or not.

- **NoWait**: If an element used in the script is locked by another script being executed simultaneously, it will not wait until that element is unlocked. Instead, it will stop.

> [!NOTE]
> On page level, you can add an *Execute* shape data field with options to automatically trigger a script based on an event or value change. See [Configuring a page to execute a script automatically](xref:Configuring_a_page_to_execute_a_script_automatically)
