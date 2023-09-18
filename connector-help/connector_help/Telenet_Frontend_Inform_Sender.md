---
uid: Connector_help_Telenet_Frontend_Inform_Sender
---

# Telenet Frontend Inform Sender

This protocol is responsible for the **forwarding of state messages** towards NetCool. These are forwarded as **SNMP** Inform messages.

The protocol has also been adapted to send certain events to SAM BO.

## About

On each back-end DataMiner Agent, there is a state collector element that receives **status updates** from the local back-end CPE Collectors. These are updates in online/offline state for CM, STB and eMTA, as well as an update of the NACO state for the CM. The updates are forwarded every 10 seconds towards the front-end Inform sender.

Between the back-end Inform collector and the front-end Inform sender a **heartbeat** is implemented. When the heartbeat fails, the back-end Inform collector buffers the updates until the heartbeat is recovered. Upon recovery, state changes are forwarded with a maximum block size to prevent overload of the front end.

Processing on the **front-end Inform sender** works as follows:

- When messages enter, they are placed on a stack. This stack gets checked with an interval defined as max trap rate, which is by default 100. That means that every 10 ms the stack is checked to see if a message needs to be sent. When a message is sent to NetCool, the message is placed in an online stack.
- When NetCool sends back the ACK for that specific message, it is removed from the stack. Because messages are sent asynchronously, several messages can be on the online stack.
- When DataMiner receives a NACK message, the message is moved from the online to the offline stack.
- As soon as an entry is available in the offline stack, no new messages are sent until a response has been received on all pending messages, i.e. until the online stack is empty.
- When the online stack is empty and there are messages in the offline stack, the first entry of the offline stack is sent. As long as no ACK is received from NetCool, the connector keeps sending this specific message.
- When ACKs are received again, first the offline stack messages are sent, and afterwards any new messages are processed.
- When NACK messages are detected, all new messages entering in the front-end Inform collector are backed up in "*onlineRecoveryStack.txt*". Messages in the offline stack get backed up in the "*offlineRecoveryStack.txt*".
- Inform messages for which the SNMP layer does not receive an ACK are re-sent every 30 seconds, for a maximum duration of 10 minutes. After this period, a NACK is sent towards DataMiner.

## Installation and configuration

This connector uses a **virtual** connection and does not need any user information during element creation.

Once the element has been created, the **destination address** must be filled in on the **General** page.

## Usage

### General page

This page displays the current status of the forwarding system.

You can also configure the **destination addresses** on this page, and enable or disable the **forwarding** of the traps/informs.

With the parameter **NetCool Sync State**, you can verify if DataMiner still receives ACKs from NetCool.
