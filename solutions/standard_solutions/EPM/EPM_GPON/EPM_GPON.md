---
uid: EPM_xPON
---

# DataMiner EPM xPON

The xPON branch of the DataMiner EPM Solution is designed to manage Gigabit Passive Optical Network (xPON) deployments.

In a typical xPON deployment, there are four main components:

- **Optical Line Termination (OLT)**: The main traffic concentrator and control device for the underlying network. Its main function is to control the traffic flow in both directions (upstream and downstream, i.e. TX and RX in xPON).

- **Optical Fiber**: The xPON transmission medium. Its size (in number of fiber strands) depends on each implementation.

- **Optical Splitter**: In basic terms, this is a prism. A single strand of fiber enters it, and its signal can be divided up to four times at each stage.

- **Optical Network Terminal (ONT)**: The terminal device located at the subscriber premises. This is the last physical connection between the subscriber and the OLT in the network.

![xPON deployment](~/dataminer/images/EPM_GPON_deploy.png)

Other implementations are also possible. Those are focused on distance (less splits and longer fiber) or on speed (less subscribers by port). However, in general this typical deployment has the best balance between coverage, speed, and number of subscribers.
