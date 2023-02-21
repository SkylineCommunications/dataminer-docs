---
uid: Dump_Spectrum_Preset_Content
---

# Dump Spectrum Preset Content

This tool can be used to visualize the content of the otherwise binary spectrum preset *.dat* files. The tool connects to the local DMA and uses SLSpectrum to read the content of the preset file. It can only be used on a DMA that has **at least one active spectrum element**.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/dumpspectrumpresetcontent/).

To run this tool:

1. Extract the zip you downloaded to a folder on the DMA you want to investigate.

1. Run the tool using a command prompt, passing in the path to a preset file (the file name can contain wildcards), as illustrated below.

An output file (*-astext.txt*) will be created next to the *preset.dat* file, which shows the contents of the preset.

Usage:

```txt
PS C:\Path> .\DumpSpectrumPresetContent.exe -help

Usage: DumpSpectrumPresetContent.exe [options]

-u, --user=VALUE User name

-p, --pwd=VALUE Password

-i, --in=VALUE Path to spectrum preset to list (can contain * wildcards to tackle multiple files)

-h, --help [Optional] Show the help
```

For example:

```txt
PS C:\Path> .\DumpSpectrumPresetContent.exe -i '.\1001.3360-after.dat'

Connecting to localhost...

Finding a spectrum element to temporarily use

Input/Output folder: .

Input: 1001.3360-after.dat

Output: 1001.3360-after-astext.txt

Temporary Element: Lite element info: 'Simulated Spectrum' (7/28)

Temporary Protocol: Skyline Spectrum Simulation

Temporary User: Wouter

Temporary writing: Skyline Spectrum Simulation.6cd8d2aae44c40bea567c9275d1975cf-1001.3360-after

Fetching preset content

Cleaning up temp file
```

Example output file:

![Output_File](~/user-guide/images/Output_File.png)
