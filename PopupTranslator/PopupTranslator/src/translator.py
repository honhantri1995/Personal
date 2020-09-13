import translate

from conf import Conf
from logger import Logger
from messagebox import MessageBox
from constants import ExceptionEnum

class Translator:
    def __init__(self):
        pass

    def translate(self, org_text):
        org_text_after_fixed = self.__fix_char_error_in_org_text(org_text)

        config = Conf.get_instance()
        try:
            trans = translate.Translator(to_lang=config.get_dest_lang(), from_lang=config.get_source_lang())
            translated_text = trans.translate(org_text_after_fixed)
        except Exception as e:
            # Write log
            logger = Logger.get_instance()
            logger.get_instance().error('Failed to translate! ' + 'Details: ' + str(e))
            # Show message box
            mb = MessageBox()
            mb.show_error('Failed to translate!' + '\n\nDetails: ' + str(e))

            raise ValueError(ExceptionEnum.CANNOT_TRANSLATE)

        translated_text_after_fixed = self.__fix_char_error_in_translated_text(translated_text)

        return translated_text_after_fixed

    def __fix_char_error_in_org_text(self, org_text):
        '''
            This is a trick to fix newline error caused by the translate API.
            Details:
                - If a line is ended with '\n', the translate API automatically remove the '\n', causing merging multiple paragraphs into one (we don't want this).
                - If a line is ended with '\r\n', the transplale API converts the '\r\n' to '&#xD;' (we also don't want this)
                but it doesn't merging paragraphs (we want this)
                - So, I found a trick to having multiple paragraphs while eliminating the stupid '&#xD;' (also ensure the correct meaning translation)
                That is replacing all '\n' and '\r\n' by ' • ' in the original text, and in the translated text, replace all ' • ' by '\r\n'.
        '''
        return org_text.replace('\r\n', ' • ').replace('\n', ' • ')

    def __fix_char_error_in_translated_text(self, translated_text):
        return translated_text.replace(' • ', '\r\n').replace("&#39;", "'").replace('&quot;', '"').replace('&gt;', ' >').replace('&lt;', '< ')