---
uid: Script_variables
---

# Script variables

For most script actions, variables are required. There are three kinds of variables:

- Dummies: required for every different element in the script. When the script is run, an actual element will be linked to each dummy.

- Parameters: typically used to get input from the outside world, e.g. from an operator.

- Memory files: containers of values, typically provided by the script itself.

When you add a script action that contains a variable, a line will automatically be added in the section in question. However, depending on the script, it can be more convenient to make the variables first, and then create the script actions.

> [!NOTE]
> - Prior to running a script, operators will first have to link the dummies and parameters to actual elements and values in the DMS. Therefore, it is best to give the variables a meaningful name the operators will be able to work with.
> - To remove a variable, click the x to the right of it.

## Creating a dummy

To create a new line in the *DUMMIES* section:

- Either click *Add* in the *DUMMIES* section:, or

- In a script action that requires a dummy, click the field where the dummy should be filled in and select *Create new dummy*.

You can then further specify the dummy properties in the *DUMMIES* section:

1. To change the name of the dummy, enter a new name next to *Dummy*.

1. To change the protocol for a dummy, click the underlined sections next to *Protocol* and *Versions* respectively, and select a new protocol and protocol version.

1. Optionally, to link a default element to a dummy, select an element in the underlined field next to *Configuration element* for this dummy. This can be particularly useful when a table parameter column is selected, as you will then be able to select an index from the available indices of the table of that default element in a drop-down list.

## Creating a parameter

To create a new line in the *PARAMETERS* section:

- Either click *Add* in the *PARAMETERS* section:, or

- In a script action that requires a parameter, click the field where the parameter should be filled in and select *Create script input*.

You can then further specify the parameter properties in the *PARAMETERS* section:

1. To change the name of the parameter, enter a new name next to *Parameter*.

1. Optionally, link a memory file to the parameter to suggest possible values to the user who executes the script. To do so, click the underlined section next to *Values file* and select the file.

## Creating a memory file

There are two kinds of memory files: memory files created within the script, and permanent memory files that contain an array of values.

### Memory files created within the script

These files are used to hold a particular value used in a script. Within the script editor, you can manage these memory files as follows:

- To add a memory file, click *Add* in the *MEMORY FILES* section, or, alternatively, in a script action that requires a memory file, click the field where the memory file should be filled in and select *Create new memory file*.

- To configure a memory file, click the underlined sections in the *MEMORY FILES* section. The first section determines the memory file name, the second determines whether the file is volatile or persistent.

  > [!NOTE]
  > For volatile memory files, the life cycle of the values stored in the memory spaces is limited to the execution time of the script. Once the script is terminated, all data stored in the memory spaces is lost. For non-volatile memory files, the life cycle of the values stored in the memory spaces is unlimited. The values are stored in a file on the hard disk of the DMA. They will survive different script cycles and even DMA reboots.

### Permanent memory files

Outside of a script, you can create permanent memory files that contain an array of values. For example, a permanent memory file named “Cities” could have the names of various cities as its values.

These files can be managed In DataMiner Cube. Up to DataMiner 9.5.10, you can do so via the *Memory files* button in the lower left corner of the Automation card. From DataMiner 9.5.11 onwards, a separate *memory files* tab is available. See [How can I manage permanent memory files?](xref:How_can_I_manage_permanent_memory_files).
