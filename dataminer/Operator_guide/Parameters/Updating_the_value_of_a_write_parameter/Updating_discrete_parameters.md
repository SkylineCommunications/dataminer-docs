---
uid: Updating_discrete_parameters
---

# Updating discrete parameters

In case the discrete parameter only has two possible values, it will have a toggle control:

- Click the toggle button to select one value; click it again to select the other value.

![Discrete parameter toggle button](~/dataminer/images/Discrete_Parameter_Toggle.png)<br>*Discrete parameter with toggle control in DataMiner 10.4.5*

In case there are a number of possible values, the parameter will have a selection box control:

- Open the selection box and select one of the listed values.

![Discrete parameter selection box](~/dataminer/images/Discrete_Parameter_Selection_Box_Control.png)<br>*Discrete parameter with selection box control in DataMiner 10.4.5*

In case the parameter can contain particular pieces of text, it will have a text box control:

1. Click inside the text box.

1. Enter the value by typing or pasting it.

![Discrete parameter text box](~/dataminer/images/Discrete_Parameter_Text_Box.png)<br>*Discrete parameter with text box control in DataMiner 10.4.6*

   > [!NOTE]
   > When you update the value of a string parameter, DataMiner checks both the format (e.g. capitalization) and the length of the new string before sending it to the device. If you enter a value that is not accepted by the protocol, the change to the parameter will not be accepted.
