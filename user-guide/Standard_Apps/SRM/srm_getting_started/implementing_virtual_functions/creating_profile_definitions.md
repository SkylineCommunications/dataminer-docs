---
uid: creating_profile_definitions
---

# Creating profile definitions

After you have created profile parameters, the next step is to create [profile definitions](xref:srm_definitions#profile-definition), to which virtual functions and virtual function interfaces can be linked. A profile definition is needed for each virtual function and its interfaces.

You can configure the profile definitions in the [Profiles module](xref:Configuring_profile_definitions):

- **For each virtual function** that you want to use, make sure there is a **profile definition with a similar name** as the virtual function.
- **For each virtual function interface** that needs to be supported, make sure there is a **profile definition with a similar name** as the interface.
- **Add the related profile parameters** to the profile definitions.

For example, in DataMiner 10.2.0:

![Profile definitions in Cube](~/user-guide/images/ProfileDefinitionsExample.png)
