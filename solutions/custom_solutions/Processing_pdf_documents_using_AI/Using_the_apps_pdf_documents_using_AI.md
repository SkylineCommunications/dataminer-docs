---
uid: using_the_apps_processing_pdf_documents
---

# Using the apps

After installing the package, setting up the necessary cloud services and entering the necessary configurations in DataMiner as described on [Installing the package](xref:installing_processing_pdf_documents), the apps described below should work without additional configuration.

## Interactive File Prompt Tool

This relatively simple app allows to write a prompt as you would do in the web UI of tools like Chat GPT and allows to upload a file with it. The app is meant to show how how DataMiner easily integrates with LLM models everyone is familiar with nowadays. In the app, the prompt and file entered by the user will be processed by the LLM model that was configured and will return the response to the user. More details on the implementation and how to start building your own solution from this sample, can be found on [Installing the package](xref:installing_processing_pdf_documents).

Possible prompts are the following:

- "Tell me a joke"
- "Please give me the frequency at which I can find the Satellite video feed specified in the attached document, please return it in json format with value and unit fields specified. Only return the json structure itself. And only return the fields specified in this prompt." + attach document using the Upload button (an example document *Skyline_SatelliteOrder_Atalanta_Bruges.pdf* can be found in the documents folder of your DataMiner system under the folder */TextAnalysis PoC/*).

![Interactive Prompt](~/dataminer/images/pdf_processing_interactive_prompt_tool_prompt.png)

![Interactive Prompt Response](~/dataminer/images/pdf_processing_interactive_prompt_tool_response.png)

## Satellite Parameter Extractor

The Satellite Feed Ingest app uses predefined prompts in the back to extract satellite parameters from pdf documents. The user can simply click the button and follow the interactive automation that pops up.

![Satellite Parameter Extractor](~/dataminer/images/pdf_processing_AI_Satellite_Feed_Ingest.png)

To process the pdf file, the app will first use Document Intelligence to convert the pdf into markdown formatted text before sending it to the Large Language Models for further processing in two steps. The prompts sent to the LLM by automation script `SLC_TextAnalysis_Script` can be adapted by opening DataMiner Cube and navigating to the documents folder */AI-sample/*. Two files are present in the folder:

- *Extract_Parameters_Prompt.txt*: this prompt is used to process the text and extract the raw parameters as they are present in the document.
- *Map_Parameters_Prompt.txt*: this prompt is used to map the raw values found in the document to a list of allowed values. The file contains placeholders which are filled in the automation script with data from DataMiner. In this case, DataMiner will fill it with the enum options defined on DOM for the different parameters.

Based on the response of the model, a DOM instance is created that represents the Satellite Feed. The app allows to open the result and to compare the mapped values with the raw values extracted in the first step of the process.

