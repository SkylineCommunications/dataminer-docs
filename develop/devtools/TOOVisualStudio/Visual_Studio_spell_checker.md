---
uid: Visual_Studio_spell_checker
---

# Visual Studio spell checker

An editor extension that checks the spelling of comments, strings, and plain text.

## Installation

1. Download the plugin.

    - For Visual Studio 2017 or later: from <https://marketplace.visualstudio.com/items?itemName=EWoodruff.VisualStudioSpellCheckerVS2017andLater>

    - For Visual Studio 2015, 2013: from <https://visualstudiogallery.msdn.microsoft.com/a23de100-31a1-405c-b4b7-d6be40c3dfff>.

    - For Visual Studio 2010: from <https://github.com/EWSoftware/VSSpellChecker/releases>.

2. Open the file

3. Click *Install*.

4. Click *Close*.

## Configuration

In Visual Studio, select *Tools* > *Spell Checker* > *Edit Global Configuration*.

*Dictionary Settings* page:

- Language should be set to English, United States (en-US).

![](~/develop/images/SpellCheckerLanguage.png)
<br>Figure 156: *Global Spell Checker Configuration Settings: Dictionary Settings*

*XML Files* page:

- This page displays two columns: *Ignored XML Elements* and *Spell Checked Attributes*.

	![](~/develop/images/SpellCheckerXML.png)
	<br>Figure 157: *Global Spell Checker Configuration Settings: XML Files*

    - The *Ignored XML Elements* column allows you to add XML elements that should be ignored by the spell checker.

        For example, the following elements can be added: *LengthType*, *Type*, *RawType*.

    - The *Spell Checked Attributes* column allows you to add XML attributes that should be ignored by the spell checker.

        For example, the following attribute can be added: name.

    > [!NOTE]
    > The name of XML elements and attributes is case sensitive.
    >
