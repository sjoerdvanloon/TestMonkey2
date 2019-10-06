using System;
using System.Collections.Generic;
using System.Text;

namespace TestMonkey2.Engine.ActionCommands
{
    public interface IUseSelenium
    {

    }

    public interface IReadVariables
    {

    }

    public interface IReadParameters
    {

    }

    public interface IWriteVariables
    {

    }

    public interface IRequireElements
    {
        
    }

    public class ElementIdentifier
    {
        public int Type { get; set; }
        public string Identifier { get; set; }
    }

    public interface IOptionalElements
    {

    }

    public interface IHasChoice
    {
        
    }

    public class Selenium
    {

    }

    public class ClickCommand : IRequireElements //IWait
    {
        public  ClickCommand(Selenium s)
            {
            }
        public void Execute(Element e)
        {
           // e.Click
        }
    }

    public class Variable
    {

    }

    public class Parameter
    {
        public string Value;
    }

    public class Element
    {

    }

    public class Choice
    {
        public string Value;
    }

    public class IfCommand
    {
        public void Execute(Parameter p1, Choice c1, Choice c2)
        {
            var map = new Dictionary<String, Func<bool>>
            {
                { "empty", () => string.IsNullOrWhiteSpace(p1.Value)},
                { "guid", () => false },
                { "number", () => false}
            };
            bool bit = c1.Value == "is";
            bool result = map[c2.Value]();
        }

        public void Execute(Parameter p1, Choice c1, Parameter p2)
        {
            bool bit = c1.Value == "is";
            bool result = string.Compare(p1.Value, p2.Value, true) == 0;
        }
    }

    // next 
    // next

    public class ElseCommand
    {

    }

    public class EndIfCommand
    {

    }
}
