---
uid: DashboardStepper
---

# Stepper

This component can be used to display states from a stateful DOM definition or instance. 

To configure the component: 
1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).
    - In case a DOM definition feed is applied, the component shows all the states on the happy path of that definition. The happy path contains all the states an instance from a certain definition would go through if it were to follow the normal flow. Applying a DOM definition feed to a Stepper component is only possible in Low-Code Apps.
    - When a DOM instance is fed to the component, it shows the full history of every state the instance has been in until the current state. Based on that state, it calculates the rest of the happy path, which is then shown after the current state.


2. Optionally, configure the template for the component. In the *Layout* tab, the *Appearance* setting can be used to change the template of the component. Users can pick a template from a list of 13 presets.
