---
uid: Configuring_Mobile_Gateway_in_DataMiner_Cube
---

# Configuring Mobile Gateway in DataMiner Cube

1. In DataMiner Cube, go to *Apps* > *System Center \> Mobile Gateway*.

2. At the top of the screen, next to *Cellphone location*, click *\<Click to select>*, select the DataMiner Agent containing the *C:\\Skyline DataMiner\\Mobile Gateway\\Config.xml* file in which you have configured all necessary device settings, and click *Apply*.

    > [!NOTE]
    > When you click *Apply*, the cell phone modem will be initialized. Note that, in some cases, this can take up to two minutes.

3. In the *configuration* tab:

    1. Specify the PIN and PUK codes of the SIM card, and enter the telephone number of the SMS Service Center. See [Cellphone settings](#cellphone-settings)

    2. Specify which users are allowed to be called by Mobile Gateway. See [Destinations](#destinations)

    3. Specify which users are allowed to call Mobile Gateway. See [Remote users](#remote-users)

    4. Click *Apply*.

4. Click the *commands* tab, and configure all the commands you want Mobile Gateway users to be able to enter. See [Commands](#commands)

## Cellphone settings

In the *cellphone settings* section, enter the following data:

- The PIN code of the SIM card.

- The PUK code of the SIM card.

- The telephone number of the SMS Service Center, which is needed to send text messages.

    If no number is specified in this tag, the telephone number of the service center is read from the SIM card. Default: +32475161616

## Destinations

In the *destination* section, specify which users are allowed to be called by Mobile Gateway.

- Select *Allow all* if you allow Mobile Gateway to call any number.

- Select *Allow all users/groups* if you only allow Mobile Gateway to call users known to the DataMiner System.

To add a custom destination:

1. In the *Custom destinations* section, click *Add*.

2. Select *Tel nr.*, *User*, or *Group*.

3. Enter a telephone number, or select a user or user group from the list.

To delete a custom destination:

- Hover over the destination, and click the small *X*.

## Remote users

In the *remote users* section, specify which users are allowed to call Mobile Gateway.

- Select *Allow all* if you allow anyone to call Mobile Gateway.

- Select *Allow all users/groups* if you only allow users known to the DataMiner System to call Mobile Gateway.

To add a custom user or user group:

1. In the *Custom remote users* section, click Add.

2. Select *Tel nr.*, *User*, or *Group*.

3. Enter a telephone number, or select a user or user group from the list.

To delete a custom user or user group:

- Hover over the user or the user group, and click the small *X*.

## Commands

In the *commands* tab, configure all the commands you want Mobile Gateway users to be able to enter.

> [!NOTE]
> Each command can contain one or more actions.

To add a command:

1. Click *New*.

2. In the *Name* field, replace “New command” by the actual command users will have to enter.

3. Click *Add action*.

4. Select one of the following actions:

    | Action | Description                                                                                                                                                                                                                                                                                      |
    |----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Get      | Retrieves the current value of a read parameter                                                                                                                                                                                                                                                  |
    | GetX     | Retrieves the current value of a read parameter, as well as the following update information:<br> -  time of last update<br> -  user who performed the last update |
    | Set      | Updates the value of a write parameter.                                                                                                                                                                                                                                                          |

5. Click *\<Click to select>*, and select an element from the list.

6. Click *\<Click to select>*, and select a parameter from the list.

7. If, in step 4, you selected *Set*, then enter the new parameter value, and click the green *OK* button.

    - If you select the *Default* checkbox, the parameter value you specified in the command will be considered the default value. In other words, when someone sends the Set command without specifying a value, then the parameter will be set to the value you specified in the command.

8. If you want to add another action, repeat from step 3, if not, click *Save*.

To delete a command:

- In the list of commands on the left, right-click the command, and select *Delete*.

To duplicate a command (e.g. in order to create a new command based on an existing one):

- In the list of commands on the left, right-click the command, and select *Duplicate*.

To export commands to a CSV file:

1. In the list of commands on the left, right-click underneath the last command, and select *Export*.

2. In the *Save* window, select a folder, enter the name of the CSV file, and click *Save*.

To import commands from a CSV file:

1. In the list of commands on the left, right-click underneath the last command, and select *Import*.

2. In the *Open* window, select the CSV file containing the commands, and click *Open*.

To move a command action up or down in the list of actions to be executed:

1. In the list of commands on the left, select the command.

2. On the right, hover over the action, and click the small *Up* or *Down* arrow.

To delete a command action from the list of actions to be executed:

1. In the list of commands on the left, select the command.

2. On the right, hover over the action, and click the small *X*.

To execute an ad hoc command (e.g. for test purposes):

- Select a command in the list on the left, and click the *Execute* button in the lower right corner.

    > [!NOTE]
    > This option is only available if you are logged in with a user profile that has a phone number configured.

> [!TIP]
> See also:
> [Command reference](xref:Command_reference)
