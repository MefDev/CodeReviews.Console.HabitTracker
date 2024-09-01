using System;
using Spectre.Console;
using Spectre.Console.Cli;
namespace CodingLogger.Controller
{
    public class Controller
    {
        public Controller()
        {
        }
        public void DisplayMenu()
        {
            RenderCustomLine("DodgerBlue1", "Coding Logger Menu");
            var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.LightSteelBlue1)
            .AddColumn(new TableColumn("[bold DodgerBlue1]Option[/]").Centered().Width(15)).Width(80)
            .AddColumn(new TableColumn("[bold gray]Description[/]"))
            .AddRow("[bold DodgerBlue1]a [/] ", " - Add a coding session")
            .AddRow("[bold DodgerBlue1]v [/] ", " - View a coding session")
            .AddRow("[bold DodgerBlue1]d [/] ", " - Delete a coding session")
            .AddRow("[bold DodgerBlue1]u [/] ", " - Update a coding session")
            .AddRow("[bold DodgerBlue1]s [/] ", " - View all coding sessions")
            .AddRow("[bold DodgerBlue1]q [/] ", " - Exit");
            AnsiConsole.Write(table.Centered());
            string userInput = AnsiConsole.Ask<string>("[bold DodgerBlue1]Your option?[/] ");
           
        } 
        private void RenderCustomLine(string color, string title)
        {
            var rule = new Rule($"[{color}]{title}[/]");
            rule.RuleStyle($"{color} dim");
            AnsiConsole.Write(rule);
        }
        private static string DisplayUserInputOption(string name)
        {
            string message = "Enter a coding session";
            string? option = null;
            switch (name)
            {
                case "id":
                    AnsiConsole.Markup($"[bold DodgerBlue1]{message} {name}: [/]");
                    break;
                case "start":
                    AnsiConsole.Markup($"[bold DodgerBlue1]{name} date (yyyy-MM-dd): [/]");
                    break;
                case "end":
                    AnsiConsole.Markup($"[bold DodgerBlue1]{name} date (yyyy-MM-dd): [/]");
                    break;
                default:
                    break;
            }

            while (string.IsNullOrEmpty(option))
            {
                option = Console.ReadLine();
            }
            return option;

        }
    }
}

