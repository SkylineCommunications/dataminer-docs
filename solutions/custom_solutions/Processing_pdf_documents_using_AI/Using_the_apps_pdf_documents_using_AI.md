---
uid: using_the_apps_processing_pdf_documents
---

# Using the apps

After installing the package, setting up the necessary cloud services and entering the necessary configurations in DataMiner as described on [Installing the package](xref:installing_processing_pdf_documents), the apps described below should work without additional configuration.

## Interactive File Prompt Tool

This relatively simple app allows you to enter a prompt as you would do in the web UI of tools like ChatGPT and allows you to upload a file with it. The app is meant to demonstrate how DataMiner easily integrates with the LLM models everyone is familiar with nowadays. In the app, the prompt and file entered by the user will be processed by the configured LLM model, which will provide a response to the user.

These are some of the possible prompts:

- "Tell me a joke"
- "Please give me the frequency at which I can find the Satellite video feed specified in the attached document; please return it in JSON format with value and unit fields specified. Only return the JSON structure itself, and only return the fields specified in this prompt." + attach a document using the *Upload* button (an example document *Skyline_SatelliteOrder_Atalanta_Bruges.pdf* can be found in the documents folder of your DataMiner System under the folder */TextAnalysis PoC/*).

![Interactive prompt](~/dataminer/images/pdf_processing_interactive_prompt_tool_prompt.png)

![Interactive prompt response](~/dataminer/images/pdf_processing_interactive_prompt_tool_response.png)

> [!TIP]
> For more details on the implementation and how to start building your own solution based on this sample, refer to [Implementation details](xref:implementation_details_the_apps_processing_pdf_documents).

## Satellite Parameter Extractor

The Satellite Feed Ingest app uses predefined prompts in the background to extract satellite parameters from PDF documents. To use this app, users only need to click a button and then follow the steps in the pop-up window.

![Satellite Parameter Extractor](~/dataminer/images/pdf_processing_AI_Satellite_Feed_Ingest.png)

To process the PDF file, the app will first use Document Intelligence to convert the PDF into Markdown-formatted text, before sending it to the Large Language Models for further processing in two steps.

Based on the response of the model, a DOM instance is created that represents the satellite feed. The app allows you to open the result and compare the mapped values with the raw values extracted in the first step of the process.

The prompts sent to the LLM by the Automation script *SLC_TextAnalysis_Script* can be adapted. To do so, open DataMiner Cube and navigate to the documents folder */AI-sample/*. Two files are present in the folder:

- *Extract_Parameters_Prompt.txt*: This prompt is used to process the text and extract the raw parameters present in the document.
- *Map_Parameters_Prompt.txt*: This prompt is used to map the raw values found in the document to a list of allowed values. The file contains placeholders that are filled in with data from DataMiner in the Automation script. In this case, DataMiner will fill in the enum options defined in DOM for the different parameters.
