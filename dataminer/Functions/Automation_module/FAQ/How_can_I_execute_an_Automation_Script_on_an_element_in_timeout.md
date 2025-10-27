---
uid: How_can_I_execute_an_Automation_Script_on_an_element_in_timeout
---

# How can I execute an Automation Script on an element in timeout?

Normally, when you run an Automation script on an element in timeout, the script will fail.

However, there are two different ways to ensure a script will run successfully regardless of the state of the elements.

- In DataMiner Cube, in the *General* section of the Automation script card, select *Do not fail when elements are not active or in timeout*. See [General script configuration](xref:General_script_configuration).

- Alternatively, add a comment action with value *skipElementChecks=true* as the first action in the script. This way, the script will be executed even if included elements are in a timeout state. See [Comment](xref:Comment).
