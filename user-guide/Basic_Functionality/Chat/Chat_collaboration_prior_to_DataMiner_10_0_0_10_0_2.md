---
uid: Chat_collaboration_prior_to_DataMiner_10_0_0_10_0_2
---

# Chat collaboration prior to DataMiner 10.0.0/10.0.2

In DataMiner versions prior to DataMiner 10.0.0/10.0.2, chat collaboration is done using the *Contacts* window.

### Opening the Contacts window

To open the *Contacts* window:

- In the header bar of DataMiner Cube, click your user name.

#### Contacts and client sessions

The *Contacts* window lists all users who are currently logged on the DMS.

On the right of the user name, you find the computer name and the number of DataMiner client sessions that user is currently running:

```txt
[User name] ([Computer name]) ([Number of sessions])
```

If you hover the mouse pointer over one of the listed users, a tooltip appears, containing the following details:

- User name & computer name:

    ```txt
    [User name] ([Computer name])
    ```

- Client sessions (i.e. a line for every client session that user is running):

    ```txt
    [DataMiner client application] online since [Start of session]
    ```

### Starting a chat session with another DataMiner user

To start a chat session with another user:

- Double-click the name of the user.

    A tab representing the chat session is added to the *Contacts* window.

> [!NOTE]
> You can also right-click the name of the user and click *Start chat session* in the shortcut menu.

#### Sending a message

1. Go to the tab representing the chat session.

2. Enter your message in the empty text box at the bottom of the tab and click *Send*.

The message you sent is added to the list of messages exchanged during the current chat session. The current time and your user name are automatically added in front of the message.

> [!NOTE]
> You can only send chat messages if you have been granted the user permission *Collaboration \> UI available*.

#### Reading a message

By default, when you receive a chat message from another user, your user name will start to blink in the header bar.

1. Click the blinking user name to open the *Contacts* dialog box.

2. Click the blinking label of the tab representing the chat session.

### Ending a chat session

1. Go to the tab representing the chat session you want to end.

2. To the right of the tab label, click X.

> [!NOTE]
> By default, you can only end a chat session if you started it yourself. However, if you have been granted the user permission *Collaboration* > *Disconnect other users*, you can end every single chat session, no matter who started it.
