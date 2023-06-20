---
uid: ConnectionsSerialPingPair
---

# Ping pair

When an element goes into timeout, it can go into so-called "slowpoll" mode. For more info on how to configure slow poll mode on an element, refer to the slow poll settings section on [Adding elements](xref:Adding_elements).

The ping pair is then used to ping the device until it responds again. In serial drivers, the ping pair can be determined with the ping attribute on a Pair. In case there is no pair with the ping attribute, the pair with the lowest ID that contains a response will be used as ping pair.
