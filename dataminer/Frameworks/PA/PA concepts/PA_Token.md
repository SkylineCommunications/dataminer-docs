---
uid: PA_Token
---

# Token

Tokens are mainly used to exchange standard data between [queue elements](xref:PA_Queue_Element).

When an activity is completed, it generates one single new token and sends it to the next queue element.

There are two types of tokens:

- **Main token**: A token pushed into a process.

- **Child token**: A token generated within a process when an activity is completed and the queue responsible for the next activity needs to be notified.
