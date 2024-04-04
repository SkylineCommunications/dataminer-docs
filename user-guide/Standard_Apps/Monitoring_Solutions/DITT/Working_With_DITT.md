---
uid: Working_With_DITT
---

# Implementing DITT in a visual overview

## Configuration

> [!NOTE]
> Before you can configure DITT in a visual overview, you first have to [install the DITT package](xref:Installing_DITT).

1. Download the Visio file of the DITT package, located in `C:\GIT\Visios\Customers\Protocols\Skyline Communications\Skyline\DataMiner IT Tools`.

1. Copy and paste the *Ping* and *Tracert* buttons from the *Tools* page of the DITT Visio file to your own Visio file.

   ![Ping and Tracert buttons](~/user-guide/images/DITT_Buttons.png)

1. Copy and paste the *Ping* and *Tracert* pages from the DITT Visio file to your own Visio file.

   ![Ping and Tracert pages](~/user-guide/images/DITT_Pages.png)

1. Copy and paste the *InitVar* value from the *Tools* page to the page on which the buttons will be used.

   ![DITT InitVar](~/user-guide/images/DITT_Init_Vars.png)

## Configuration of the IP address

Modify the configuration of the DITT *Ping* and *Tracert* buttons by adjusting their respective parameters. To do so, set the *_parameter3* field of the button in question to either a placeholder or a default value.

> [!NOTE]
> In the following example, IP address 8.8.8.8 is used instead of the default address "localhost".

1. In the *_parameter3* field, enter either a valid IP address or a placeholder.

   ![DITT IP address](~/user-guide/images/DITT_IP_Address.png)

1. Check whether, in the *Execute* data field of the button in question, the value following `OperationsArguments=` has changed.

   ![DITT check change in IP address](~/user-guide/images/DITT_IP_Address_Check.png)

1. If both values are equal, the process is finished. If not, make the necessary changes.

> [!NOTE]
> The IP address of the *Ping* and *Tracert* buttons is by default set to "localhost".
