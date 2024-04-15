---
uid: Basic_Information
---

# Basic Information

After [installing the DITT Package](xref:Installing_DITT), users will find the DITT element under "Dataminer IT Tools" view in the surveyor. 
Going to the *Tools* page, the buttons ping and tracert can be triggered to perform a ping or trace to the localhost, this can be performed solely to verify the correct functioning of the DITT package.

> [!NOTE]
> The DITT is meant to be implemented in other Visios, rather than being used on its own. to do so, please [configure the DITT](xref:Working_With_DITT) under any Visio of your own. 
> Or configure the [PuTTY Button](xref:Open_Putty_with_DITT).


### Pages in DITT

Here it is a quick summary of the pages inside the DITT element and their purpose:

   - *Operation Overview*: Track each request that was sent using DITT, whether it is ping or tracert

   - *Subscriptions*: Necessary configurations for the ping and tracert buttons. Changing these values might damage the correct functioning of the DITT

   - *Registrations*: The path where the PuTTY executable is stored for each user.

   - *Tools*: Page to view and use the different buttons of the DITT (Ping, tracert), for the PuTTY buton follow the instructions [here](xref:Open_Putty_with_DITT). 

   - *Configuration*: Sets different states of the DITT:
        1. Request Processing: Press the button to stop processing ping, tracert and open PuTTy requests.
        1. Operation: Shows "processing" if a current request is being processed or idle if the system is free to have a request.
