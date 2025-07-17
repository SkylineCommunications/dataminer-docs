---
uid: Working_with_Mobile_Gateway_in_DataMiner_Cube
---

# Working with Mobile Gateway in DataMiner Cube

To open the Mobile Gateway app:

- In DataMiner Cube, go to *Apps* > *System Center \> Mobile Gateway*.

To check the current status of the cell phone modem:

- Check the large *Cellphone status* tile at the top of the screen.

To check the current signal strength of the cell phone modem:

- Check the large *Signal strength* tile at the top of the screen.

    > [!NOTE]
    > The signal strength is expressed as a percentage.

To reset the cell phone modem:

- Click *Reset cellphone* at the top of the screen.

    > [!NOTE]
    > This button is only available when the Mobile Gateway has been initialized.

To send an ad hoc text message:

- Click *Send text message...* at the top of the screen.

    > [!NOTE]
    > This button is only available when the Mobile Gateway has been initialized.

To execute an ad hoc command (e.g. for test purposes):

- In the *commands* tab, select a command in the list on the left, and click *Execute*.

    > [!NOTE]
    > This option is only available if you are logged in with a user profile that has a phone number configured.

To check the status of all DataMiner Agents that can use Mobile Gateway:

- In the *status* tab, check the *DataMiner Agents* table:

    | Column   | Description                                                          |
    |------------|----------------------------------------------------------------------|
    | DMA        | The name of the DataMiner Agent                                      |
    | IP Address | The IP address of the DataMiner Agent                                |
    | Status     | The current status of the DataMiner Agent                            |
    | Time       | The time at which the status of the DataMiner Agent was last changed |

To check the list of text messages waiting to be sent:

- In the *status* tab, check the *SMS stack* table:

    | Column   | Description                  |
    |------------|------------------------------|
    | Message    | The content of the message   |
    | IP Address | The number of the cell phone |
    | Type       | SMS (i.e. text message)      |

To remove a text message that has not yet been sent:

- In the *status* tab, select the message in the *SMS stack* table and click the *Remove SMS* button in the lower right corner.
