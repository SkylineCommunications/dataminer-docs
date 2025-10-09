---
uid: Assistant_Predefined_Questions
---

# Adding custom predefined questions

When you start a new chat session in the *Insights* or *Documentation* tab, six predefined questions are displayed to help you get started quickly. Instead of typing a question, you can click one of the question tiles.

![Predefined questions](~/dataminer/images/Assistant_PredefinedQuestions.png)

On the *Insights* tab, you can use custom predefined questions to tailor the Assistant to your workflows, making it faster and easier to get the insights you need the most. To add a new custom question, you need to edit the JSON file directly:

1. On the DMA, go to the following folder: `C:\Skyline DataMiner\Documents\assistant`.

1. Open the file *insights_questions.json*.

1. Locate the question you want to replace. Each question in the file is defined as a JSON object with the following properties:

   | # | Property | Description |
   |:--:|--|--|
   | (1) | `icon` | Name of the [Material icon](https://fonts.google.com/icons) displayed next to the question. |
   | (2) | `title` | The text that appears as the heading of the predefined question. |
   | (3) | `content` | The question that will be sent to the Assistant when you click the predefined question. |
   | (4) | `color` | The RGB color (comma-separated values) used for the icon. |

   ![Predefined question](~/dataminer/images/Assistant_Predefined_Question.png)

1. Replace the existing question with your own, keeping the same structure and ensuring the JSON syntax remains valid.

   For example:

   ```json
   {
    "icon": "notifications_active",
    "title": "Active alarms",
    "content": "Can you give me a brief overview of the active alarms in my system?",
    "color": "102, 204, 0"
   }
   ```

   > [!TIP]
   > Use clear and specific wording in your questions to get the most accurate responses. See [Writing effective prompts](xref:Assistant_WritingPrompts).
