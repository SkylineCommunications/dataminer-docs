---
uid: Checking_the_connection_state_of_an_element
---

# Checking the connection state of an element

To check the connection state of an element:

1. Open the element card. See [Element cards](xref:Element_cards).

1. Go to the page *General parameters*.

1. Scroll to the *Communication Info* table at the bottom of the page.

   In this table, detailed information on the connection is displayed, such as the connection name, type and state.     Several connection states are possible:

   | Connection state | Description                                                                              |
   |--------------------|------------------------------------------------------------------------------------------|
   | Undefined          | Initial state: no connection has been set up yet.                                        |
   | Responding         | For a serial connection. Connection has been set up and communication is up and running. |
   | Not responding     | For a serial connection. Connection has been set up, but communication has stopped.      |
   | Connected          | For a smart-serial connection. Connection has been set up.                               |
   | Disconnected       | For a smart-serial connection. Connection has been lost.                                 |

   > [!NOTE]
   > For serial ports, the connection state is usually either Responding or Not Responding, depending on whether the socket was open or closed. However, if the option *closeConnectionOnResponse* is used in the protocol, a connection will be opened and then immediately closed as soon as a message has been sent, and the response has been received. In that case, the connection state will show "Undefined" all the time.
