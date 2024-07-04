---
uid: Making_a_shape_set_a_file_path_to_a_session_variable
---

# Making a shape set a file path to a session variable

It is possible to change a shape into a control that opens a dialog box where you can select a file. The session variable will then be populated with the path to that file.

To configure this, specify the following shape data on the shape:

- **SetVar**: Set this shape data field to the name of the variable.
- **Source**: Set this shape data field to *OpenFileDialog*.
- **SetVarOptions**: This shape data field allows you to specify the following options, using a pipe character ("\|") as separator:

  - By default, the shape will be displayed as a button. However, if you want it to be displayed the same way in Visual Overview as in Visio, set this shape data field to *Control=Shape*.
  - To resolve a mapped network drive to the correct network location (e.g. to resolve *T:\\MyLocation* to *\\\\NetworkLocation\\User\\MyLocation*), specify the option *ResolveToUNC*.

For example, to create a button that opens a dialog box to populate the “Path” variable with the selected file path, specify the following shape data:

| Shape data field | Value          |
|------------------|----------------|
| SetVar           | Path           |
| Source           | OpenFileDialog |
