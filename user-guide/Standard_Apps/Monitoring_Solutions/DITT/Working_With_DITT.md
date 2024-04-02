---
uid: Working_With_DITT
---

# Implementing the DITT in an external Visio

## Configuration

> [!NOTE]
> To configure the DITT in any Visio, the [installation] (xref:Installing_DITT) of the DITT package is mandatory.


1. Download the Visio of the DITT package, located in `C:\GIT\Visios\Customers\Protocols\Skyline Communications\Skyline\DataMiner IT Tools`.

1. Copy and paste the Ping and Tracert buttons from the DITT Visio located in *Tools* Page into any Visio diagram (User's Visio).

![Ping and Tracert Buttons](~/user-guide/images/DITT_Buttons.png)



3. Copy and paste the pages Ping and Tracert from the DITT visio to the User's Visio.

![Ping and Tracert Pages](~/user-guide/images/DITT_Pages.png)

4. Finally, copy and paste the Init Var value from the *Tools* page to the page where the buttons will be utilized.

![DITT Init Vars](~/user-guide/images/DITT_Init_Vars.png)


## IP Address Configuration

Users need to modify the configuration of the DITT ping and traceroute buttons by adjusting their respective parameters. This modification can be achieved by inserting either a placeholder or a default value inside the _parameter3 Value field in the desired buutton.

## Configuration

> [!NOTE]
> This example is going to use the 8.8.8.8 Address, instead of the localhost default address.

1. Change the _parameter3 value to a valid IP Addres or a Placeholder.

![DITT Change IP Address](~/user-guide/images/DITT_IP_Address.png)


2. Check if the value also changed in the Data shape *Execute* of the desired buutton, after the equals of OperationsArguments.

![DITT Check change in IP Address](~/user-guide/images/DITT_IP_Address_Check.png)


3. If both values are equal, the process is finished, if not, perform the neccesary changes.


> [!NOTE]
> The default IP Address for the DITT ping and traceroute is set to the localhost address.