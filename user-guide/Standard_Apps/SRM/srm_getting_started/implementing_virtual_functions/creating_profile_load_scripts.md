---
uid: creating_profile_load_scripts
---

# Creating Profile-Load Scripts

A [Profile-Load Script (PLS)](xref:srm_scripting#profile-load-script-pls) is responsible for the orchestration of a specific virtual function. It is typically created for a specific virtual function exposed by a specific connector.

To create a PLS:

1. Start from the example script *SRM_ProfileLoadScriptTemplate*, which is included in the SRM framework.

1. Add a script dummy named *FunctionDVE*, and link it to the protocol function DVE.

   A protocol function DVE is dynamically generated when a function definition is uploaded. Its name consists of the main protocol name and the name of the function.

1. Configure the script to set the configuration parameters on the virtual function of a connector.

1. To make sure the PLS is executed when a specific virtual function is orchestrated, when you have created the script, assign it to a profile definition:

   1. In the Profiles module, select the profile definition in the *definitions* tab.

   1. In the *Scripts* section, click *Add* to add the script. See [Configuring profile definitions](xref:Configuring_profile_definitions).

   > [!NOTE]
   > If the same function is exposed by multiple connectors, different PLSs can be listed for the same profile definition.
