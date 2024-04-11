---
uid: DITTIntegration
---

# DataMiner IT Tools(DITT) Integration

You can use DITT (DataMiner IT Tools) in an EPM environment to ping and trace any device that has an endpoint. With the use of the DITT, there is no extra code needed. You can add the ping button and trace button to your Visio and which will connect to the DITT and perform the desire operation.

Once the ping and tracert buttons have been created, a shape data field needs to be added to both shapes to connect them with the DITT tool.

![image](~/user-guide/images/EPM_DITT_integration.png)

- Execute: Here will you define the variables that will be passed to the DITT to perform the desire command.
- Element: the element where the Visio belongs
- VdxPage: This allow a pop up window to show the results of the command.
- Options(Optional): This allow you to add certain options to customize your experience.
- LinkOptions(Optional): This allow you to add options to the pop up window.

For more detailed information, check out the following links:

- [Making a shape display a particular page](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing) actions are used.
- [Configuring a page to execute a script](xref:Configuring_a_page_to_execute_a_script_automatically) actions are used.
