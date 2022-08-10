---
uid: DIS_2.11
---

# DIS 2.11

## New features

### IDE

#### New shortcut menu option: Repeat Selected Text \[ID_18109\]

In both the XML editor and the C# editor, you can now use the new right-click menu option *Repeat Selected Text...*

This option allows you to select a particular piece of text and have it copied a number of times. Moreover, by inserting variables and formulas in the text to be copied, you can have parts of the text change automatically from copy to copy.

1. Select the text that has to be repeated, right-click, and select *Repeat Selected Text...*
2. In the *DIS Repeater* window, if necessary, go to the *Template* box, and edit the text you want to have repeated.
3. If you want to insert a variable (or a formula including a variable) in the text to be repeated, then do the following:

    - Place your cursor where you want the variable of formula to be inserted, and click *Insert placeholder*.
    - If necessary, change the default placeholder that appeared at the location where you placed your cursor: a single value “x” delimited by “$” characters. You could change it to e.g. “$x+5$”.

4. At the bottom of the window, select *Overwrite Selection*, if you want the text you selected to be overwritten by the text that is currently displayed in the *Preview* box.
5. Click *OK* to have the text in the *Preview* box pasted in the editor.

##### Using '$' characters inside a formula

When you insert a variable or a formula into the text to be copied, that variable or formula is delimited by “$” characters. If you want to use a “$” character inside a formula, you have to put an escape character in front of it. Example: $(x\*10)+"\\$"$.

##### Defining the range of value 'x'

The range of value “x” can be defined using the range definition boxes at the top of the window.

There are two ways to define the range:

- Specify a starting “x” value in *Start* and a number of iterations in *Count*.
- Specify a starting “x” value in *Start* and an ending “x” value in *End*.

In both cases, you can also specify a step size in *Step*.

### XML Schema

#### Discreet tag: New displayIconAndLabel attribute \[ID_18286\]

The Protocol.Params.Param.Measurement.Discreets.Discreet tag now has a new attribute:

- displayIconAndLabel

#### New tag: WebSocketMessageType \[ID_18287\]

The following tag has been added to the Protocol Schema:

- Protocol.Commands.Command.WebSocketMessageType

#### New tag: Mib \[ID_18290\]

The following tag has been added to the Protocol Schema:

- Protocol.Mib

## Changes

### Enhancements

#### IDE - Generate Write Parameters: Warning if a write parameter already exists \[ID_18252\]

When you select the \<Param> tags of one or more read parameters, you can select the shortcut menu option *Generate Write for Read Parameter...* to have a write parameter created for each of the read parameters you selected.

In the *Generate Write Parameters* window, each read parameter in the list now has a checkbox in front of it. This checkbox will by default be selected, meaning that a write parameter will be created when you click *OK*. If, however, a read parameter already has an associated write parameter, then its checkbox will by default not be selected. This will prevent you from creating duplicate write parameters.

As is the case with duplicate parameter IDs, duplicate parameter names will now also be indicated by a red border.

> [!NOTE]
>
> - As long as there is at least one row showing a duplicate parameter ID or duplicate parameter name, the *OK* button will be disabled and a warning icon will be displayed in the top-right corner of the window.
> - Only rows of which the checkbox is selected are taken into account when performing the above-mentioned validation.

#### IDE - XML editor: XML declaration now also updated when encoding is changed to UTF-8 \[ID_18253\]

DataMiner requires all protocol files to use UTF-8 encoding. If you open a protocol in Visual Studio that does not use UTF-8 encoding, a warning message will appear, asking whether you want the encoding to be corrected.

Up to now, when you allowed the encoding to be corrected, the encoding of the file was updated, but the encoding specified in the XML declaration was not. As a result, Visual Studio would revert the encoding update when you saved the file.

From now on, when you allow the encoding to be corrected, the XML declaration will be updated as well.

#### Schema - EnumHttpRequestVerb: List updated \[ID_18284\]

The list of allowed values for the Protocol.HTTP.Session.Connection.Request.Headers.Header@verb attribute (EnumHttpRequestVerb) has been updated.

Added values:

- COPY (WebDav)
- HEAD
- LOCK (WebDav)
- MKCOL (WebDav)
- OPTIONS
- PATCH
- PROPFIND (WebDav)
- PROPPATCH (WebDav)
- TRACK (IIS)
- UNLOCK (WebDav)

Removed values:

- CONNECT

#### Schema - EnumSNMP: Value 'true' removed \[ID_18285\]

The value “true” has been removed from the list of allowed values for the Protocol.SNMP tag (EnumSNMP). This value is not supported by DataMiner.

#### Schema - HTTP headers: Three categories \[ID_18291\]

From now on, HTTP headers are split into three categories:

- Request headers
- Response headers
- Entity headers (i.e. headers that can be used both in a request and a response)

#### IDE: Enhanced table snippets \[ID_18325\]

The table snippets “Table Basic” and “Table SNMP” have been improved.

- A Primary Key parameter has been added.
- The Interprete tag has been removed.
- The bulk option has been replaced by the multipleGetNext option.
- The Instance option has been added to “Table SNMP”.

#### IDE - Exceptions snippet: ‘state’ attribute of Display tag now set to 'disabled' by default \[ID_18326\]

When you insert an Exceptions snippet in a Protocol.xml file, the state attribute of the Exception.Display tag will now by default be set to “disabled”.
