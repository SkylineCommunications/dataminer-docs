---
uid: Find_interactive_client
---

# Find interactive client

Use this action to ask an interactive user to attach to the script. In a message box, the user will be asked to choose between the following two options:

- Attach: the script will start in a pop-up window.

- Ignore: the message box will be closed.

Both if the user accepts or ignores the request, an information event will be generated.

To configure the action:

- Next to *Show message*, click the underlined field to add the message that will appear in the message box.

- Next to *Timeout*, specify how long the script should wait for the user to react. When this timeout expires, the script will continue and the *FindInteractiveClient* method returns “False”.

> [!NOTE]
> - If, as an interactive client, you manually execute a script from DataMiner Cube, you are automatically attached.
> - It is also possible to add this action within a C# block in a script. For more information, see [FindInteractiveClient](xref:Skyline.DataMiner.Automation.Engine#Skyline_DataMiner_Automation_Engine_FindInteractiveClient_System_String_System_Int32_).
> - If an interactive script is launched, but it cannot be executed because an element or memory file is locked, a message will inform the user of which element or memory file is locked, and by whom.
