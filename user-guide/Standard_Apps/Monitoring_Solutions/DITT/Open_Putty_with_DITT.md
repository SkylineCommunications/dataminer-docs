---
uid: Open_Putty_with_DITT
---

# Opening PuTTY using DITT

To add a button to open PuTTY on the DITT visual overview:

> [!NOTE]
>
> - To use the PuTTY button inside the DITT element, it is necessary to have [installated PuTTy](https://www.putty.org/) in your local machine.

1. Make sure the [DITT package](xref:Installing_DITT) is installed.

1. Click the *DITT* element, and go to the *Registrations* page.

1. Right-click inside the table, select *Add new row*, and adjust the following settings based on your preferences:

   - *User*: Your DataMiner Cube user name

   - *Name*: *putty*

   - *Path*: The path where the PuTTY executable is stored. In most cases, this will be `C:\Program Files\PuTTY\putty.exe`.

     > [!NOTE]
     >
     > - The path must not contain any quotation marks.
     > - If the path is not valid, no new row will be added.

If you have configured everything correctly, on the *Tools* page, you will find a new button called *Putty*. Click this button to open PuTTY.
To further information about PuTTY and its use, please refer to the [PuTTy Oficial docomentation](https://documentation.help/PuTTY/).