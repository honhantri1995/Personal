Popup Translator
=================

Features
----------
Translate amongst different languages (English, Japanese, French, Spanish, etc.) in two modes:

  - Popup mode
      + The source text is translated to destination text which is then displayed in a popup window.
      + This mode is useful for quick translation or UI control (buttons, message boxes, etc.) translation.

  - Translate and replace mode
      + The source text is translated to destination text, and then is replaced by the destination text.
      + This mode is useful for reading documents in docx or xlsx format.

Requirements
-------------
- Python version: 3.7

- Packages:
  + keyboard
  + pystray
  + translate
  + pyperclip
  + pythonnet
  + pyinstaller (used for generating exe file from Python scripts)