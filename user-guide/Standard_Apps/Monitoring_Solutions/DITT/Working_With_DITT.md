---
uid: Working_With_DITT
---

# Implementing DITT in a visual overview

Through seamless integration into different visual overviews, the DITT empowers users to efficiently ping any desired network device. Notably, placeholders for IP addresses allow for dynamic adjustments, resulting in tailored pings and tracerts across varying Visio files. This adaptability underscores the DITT's versatility, enabling precise network diagnostics tailored to diverse configurations.

To implement DITT in a visual overview of your own:

1. Make sure the [DITT package](xref:Installing_DITT) is installed.

1. Download the Visio file of the DITT package, located in the folder `C:\GIT\Visios\Customers\Protocols\Skyline Communications\Skyline\DataMiner IT Tools`.

1. Copy and paste the *Ping* and *Tracert* buttons from the *Tools* page of the DITT Visio file to your own Visio file.

   ![Ping and Tracert buttons](~/user-guide/images/DITT_Buttons.png)

1. Copy and paste the *Ping* and *Tracert* pages from the DITT Visio file to your own Visio file.

   ![Ping and Tracert pages](~/user-guide/images/DITT_Pages.png)

1. Copy and paste the *InitVar* value from the *Tools* page to the page where the buttons will be used.

   ![DITT InitVar](~/user-guide/images/DITT_Init_Vars.png)

1. Modify the configuration of the DITT *Ping* and *Tracert* buttons by setting the *_parameter3* field of the button to either a placeholder or a default value:

   1. In the *_parameter3* field, enter either a valid IP address or a placeholder.

      ![DITT IP address](~/user-guide/images/DITT_IP_Address.png)

   1. Check whether, in the *Execute* data field of the button, the value following `OperationsArguments=` has changed.

      ![DITT check change in IP address](~/user-guide/images/DITT_IP_Address_Check.png)

      If both values are equal, the configuration is complete. If not, the user should manually adjust the value following OperationsArgument.

   > [!NOTE]
   > The IP address of the *Ping* and *Tracert* buttons is by default set to "localhost". In the example screenshots above, IP address 8.8.8.8 is used instead of the default address.
