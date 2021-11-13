using ConsoleApp1.Services;

namespace ConsoleApp1.Factory
{
    public class TemplateFactory
    {
        private readonly IAlertTemplate _alertTemplate;

        public TemplateFactory(IAlertTemplate alertTemplate)
        {
            _alertTemplate = alertTemplate;
        }

        public string AlertTemplateName()
        {
            return _alertTemplate.CreatedTemplate("Test");
        }
    }
}
