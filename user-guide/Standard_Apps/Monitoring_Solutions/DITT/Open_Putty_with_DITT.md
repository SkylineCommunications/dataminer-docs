---
uid: Open_Putty_with_DITT
---

# Opening PuTTY using DITT

## Configuration

> [!NOTE]
> Before you can configure the DITT PuTTY button in a visual overview, you first have to [install the DITT package](xref:Installing_DITT).

1. Click the *DITT* element, and go to the *Registrations* page.

1. Right-click inside the table, select *Add new row...*, and adjust the following settings based on your preferences:

   - *User*: Your DataMiner Cube user name

   - *Name*: putty

   - *Path*: The path where the PuTTY executable is stored. In most cases, this will be `C:\Program Files\PuTTY\putty.exe`.

     > [!NOTE]
     >
     > - The path should be added without any quotes whatsoever.
     > - If the path is not valid, no new row will be added.

If the process was performed correctly, on the *Tools* page, you will find a new button called *Putty*. Clicking it should automatically open PuTTY.
