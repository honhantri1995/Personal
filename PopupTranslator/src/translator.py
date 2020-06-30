from datetime import datetime
import translate

from conf import Conf
from messagebox import MessageBox
from constants import ExceptionEnum

HISTORY_FILE = '../log/history.txt'

class Translator:
    def __init__(self):
        pass

    def translate(self, org_text):
        org_text_after_fixed = self.__fix_char_error_in_org_text(org_text)

        config = Conf()
        try:
            trans = translate.Translator(to_lang=config.get_dest_lang(), from_lang=config.get_source_lang())
            translated_text = trans.translate(org_text_after_fixed)
        except Exception as e:
            ms = MessageBox()
            ms.show_error(e)
            raise ValueError(ExceptionEnum.CANNOT_TRANSLATE)

        translated_text_after_fixed = self.__fix_char_error_in_translated_text(translated_text)

        return translated_text_after_fixed

    '''
        This is a trick to fix newline error caused by the translate API.
        Details:
            - If a line is ended with '\n', the translate API automatically remove the '\n', causing merging multiple paragraphs into one (we don't want this).
            - If a line is ended with '\r\n', the transplale API converts the '\r\n' to '&#xD;' (we also don't want this)
              but it doesn't merging paragraphs (we want this)
            - So, I found a trick to having multiple paragraphs while eliminating the stupid '&#xD;' (also ensure the correct meaning translation)
              That is replacing all '\n' and '\r\n' by ' • ' in the original text, and in the translated text, replace all ' • ' by '\r\n'.
    '''
    def __fix_char_error_in_org_text(self, org_text):
        return org_text.replace('\r\n', ' • ').replace('\n', ' • ')

    def __fix_char_error_in_translated_text(self, translated_text):
        return translated_text.replace(' • ', '\r\n').replace("&#39;", "'").replace('&quot;', '"').replace('&gt;', ' >').replace('&lt;', '< ')

    def write_to_history(self, org_text, translated_text):
        with open(HISTORY_FILE, "a+", encoding="utf-8") as file:
            # mm/dd/YY H:M:S
            now = datetime.now().strftime("%m/%d/%Y %H:%M:%S")
            text_list = [
                '===============================================================================================================================================================',
                '{}:',
                'From: {}\n',
                'To: {}',
                '===============================================================================================================================================================\n\n'
            ]
            file.write('\n'.join(text_list).format(now, org_text, translated_text))