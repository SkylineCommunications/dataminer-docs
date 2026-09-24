---
metadata_version: 1
uid: UIComponentsTextBox
description: "Define a DataMiner text box with a write parameter and optionally limit the number of characters accepted for string values."
---

# Text box

Enables the user to enter text.

To define a text box, define a parameter of type "write".

![DataMiner Cube text box](~/develop/images/uitextbox.png)

> [!NOTE]
>
> - Typically, a corresponding read parameter will exist for a write parameter. Therefore, the use of a text box is atypical. Instead, an editable label is commonly used.
> - For text boxes holding string values, the Range tag can also be used to limit the number of characters a user is allowed to enter.
