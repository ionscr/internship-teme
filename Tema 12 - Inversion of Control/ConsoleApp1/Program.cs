using System;
using ConsoleApp1.Factory;
using ConsoleApp1.Infrastructure;
using ConsoleApp1.Services;

namespace ConsoleApp1
{
    class Program
    {
        static Program()
        {
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            var tempFactoryInstance = ServiceLocator.Resolve<TemplateFactory>();
            var tableTemplate = new TableTemplate(tempFactoryInstance);
            tableTemplate.Alert();

        }
    }

    public class TableTemplate
    {
        private readonly TemplateFactory _templateFactory;

        public TableTemplate(TemplateFactory templateFactory)
        {
            _templateFactory = templateFactory;
        }

        public void Alert()
        {
            var temp = _templateFactory.AlertTemplateName();
        }
    }
}
