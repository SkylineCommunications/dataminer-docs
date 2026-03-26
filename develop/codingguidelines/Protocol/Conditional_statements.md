---
uid: Conditional_statements
---

# Conditional statements

- To avoid exceptions and increase performance by skipping unnecessary comparisons, use the conditional-AND operator ("&&") instead of the &-operator, and the conditional-OR operator ("\|\|") instead of the \|-operator. This will avoid unnecessary evaluations (also known as short-circuit evaluation).

- In a conditional-AND statement, the condition that is most likely to fail should be put first. In a conditional-OR statement, the condition that is most likely to succeed should be put first.

- In selection statements (i.e., if-else and in some cases switch statements) the data distribution should be kept in mind. For example, when implementing a switch statement with three possible cases, e.g., A, B and C, while it is known that C will occur most of the time, performance can be optimized by first checking for C.
