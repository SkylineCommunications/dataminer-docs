---
uid: Working_with_DITT
---

# Working with DataMiner IT Tools

When you [install the DITT package](xref:Installing_DITT), a *DITT* element will be added in the *DataMiner IT Tools* view in your DataMiner System.

In DataMiner Cube, you can access this element by navigating to it in the Surveyor, or by opening it under *Apps* > *Applications*.

On the *Tools* page of the element, you can use the *Ping* and *Tracert* buttons to perform a ping or trace operation to the local host. This way you can check the correct functioning of the DITT package. You can also configure the element to show a [PuTTY Button](xref:Open_Putty_with_DITT) as well. However, DITT is mainly intended to be [implemented in other visual overviews](xref:Implementing_DITT_in_Visio).

In the DITT element itself, the following pages are available:

- *Operation Overview*: This page contains a table where you can track each ping or tracert request that was sent using DITT.

- *Subscriptions*: The table on this page contains the configuration for the *Ping* and *Tracert* buttons.

  > [!CAUTION]
  > Changing the values in this table could damage the correct functioning of DITT.

- *Registrations*: This page is where you can configure the path where the PuTTY executable is stored for each user. See [Opening PuTTY using DITT](xref:Open_Putty_with_DITT).

- *Tools*: This page contains the main DITT buttons (*Ping* and *Tracert*). A [PuTTY button](xref:Open_Putty_with_DITT) can also be added.

- *Configuration*: Contains the following parameters:

  - *Request Processing*: Press this button to stop processing ping, tracert, and open PuTTY requests.

  - *Operation*: Shows *Processing* if a current request is being processed, or *Idle* if the system is free to process a request.
