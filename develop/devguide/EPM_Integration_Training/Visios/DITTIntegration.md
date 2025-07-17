---
uid: DITTIntegration
---

# Performing ping and tracert operations using DITT

You can use [DITT (DataMiner IT Tools)](xref:Dataminer_IT_Tool_Overview) in an EPM environment to ping and trace any device that has an endpoint. With DITT, you can do this without any need for extra code. You can add the ping button and trace button to your visual overview and use them to connect to DITT and perform the desired operation.

For detailed info, see [Implementing DITT in a visual overview](xref:Implementing_DITT_in_Visio).

Example:

![DITT integration example](~/develop/images/EPM_DITT_integration.png)

The following shape data fields are used in this example:

- **Execute**: Defines the variables that will be passed to DITT to perform the desired command. (See [Configuring a page to execute a script](xref:Configuring_a_page_to_execute_a_script_automatically).)

  In the example above:

  ```text
  Script:DITT Controller||UserSession=[cardVar:_Guid];OperationType=Ping;OperationArguments=[param:[cardvar:_partitionElement],2002,[cardvar:_field]];UserName=[thisusername];HostingDma=[cardVar:_DmaId]||Click to Ping Device|NoConfirmation
  ```

- **Element**: Indicates the element that the visual overview is used for. (See [Linking a shape to an element](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group).)

- **VdxPage**: This is used to open a pop-up window to show the results of the command. (See [Making a shape display a particular page](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing).)

- **Options**: You can use this to add certain options to customize your experience.

- **LinkOptions**: You can use this to customize the pop-up window.
