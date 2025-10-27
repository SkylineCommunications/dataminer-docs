---
uid: Implementing_DITT_in_Visio
---

# Implementing DITT in a visual overview

By integrating DITT functionality in other visual overviews, you can efficiently ping any network device. You can also use placeholders for IP addresses to allow for dynamic adjustments, resulting in tailored ping and tracert operations across different elements.

To implement DITT in another visual overview:

1. Make sure the [DITT package](xref:Installing_DITT) is installed.

1. Download the Visio file of the DITT package, located in the folder `C:\GIT\Visios\Customers\Protocols\Skyline Communications\Skyline\DataMiner IT Tools`.

1. Copy and paste the *Ping* and *Tracert* buttons from the *Tools* page of the DITT Visio file to your own Visio file.

   ![Ping and Tracert buttons](~/dataminer/images/DITT_Buttons.png)

1. Copy and paste the *Ping* and *Tracert* pages from the DITT Visio file to your own Visio file.

   ![Ping and Tracert pages](~/dataminer/images/DITT_Pages.png)

1. Copy and paste the *InitVar* value from the *Tools* page to the page where the buttons will be used.

   ![DITT InitVar](~/dataminer/images/DITT_Init_Vars.png)

1. Modify the configuration of the DITT *Ping* and *Tracert* buttons by setting the *_parameter3* field of the button to either a placeholder or a default value:

   1. In the *_parameter3* field, enter either a valid IP address or a placeholder.

      ![DITT IP address](~/dataminer/images/DITT_IP_Address.png)

   1. Check whether, in the *Execute* data field of the button, the value following `OperationsArguments=` has changed.

      ![DITT check change in IP address](~/dataminer/images/DITT_IP_Address_Check.png)

      If both values are equal, the configuration is complete. If not, manually adjust the value following `OperationsArgument=`.

   > [!NOTE]
   > The IP address of the *Ping* and *Tracert* buttons is by default set to "localhost". In the example screenshots above, IP address 8.8.8.8 is used instead of the default address.
