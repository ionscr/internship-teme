using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Services
{
    public class AlertTemplate: IAlertTemplate
    {
        public string CreatedTemplate(string name)
        {
            return "Name = " + name;
        }
    }
}
