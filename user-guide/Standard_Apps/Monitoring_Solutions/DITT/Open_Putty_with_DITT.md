---
uid: Open_Putty_with_DITT
---

# Opening PuTTY using DITT

To add a button to open PuTTY on the DITT visual overview:

1. Make sure the [DITT package](xref:Installing_DITT) is installed in the DataMiner System.

1. Make sure [PuTTY](https://www.putty.org/) is installed on your local machine.

1. Open the *DITT* element, and go to the *Registrations* page.

1. Right-click inside the table, select *Add new row*, and configure the following settings:

   - *User*: Your DataMiner Cube user name.

   - *Name*: `putty`

   - *Path*: The path where the PuTTY executable is stored. In most cases, this will be `C:\Program Files\PuTTY\putty.exe`.

     > [!NOTE]
     >
     > - The path must not contain any quotation marks.
     > - If the path is not valid, no new row will be added.

If you have configured everything correctly, on the *Tools* page, you will find a new *Putty* button. Click this button to open PuTTY.

> [!TIP]
> For more information about how to use PuTTY, refer to the [PuTTy User Manual](https://documentation.help/PuTTY/).
