using ConsoleTools;
using System;
using CommandRunner.Commands;
using System.Linq;
using Ninject;
using System.Collections.Generic;
using TestMonkey2.Engine;

namespace CommandRunner
{
    class Program
    {

        private static void HandleCommand(ICommand command)
        {
            Console.WriteLine(command.FriendlyName);
            var needsInput = command as INeedsInput;
            if (needsInput == null || needsInput.Input())
            {
                var result = command.Go();
                if (!result)
                {
                    Console.WriteLine("Error while running command!");
                }
            }
            else
            {
                Console.WriteLine("Input was wrong!");
            }
            Console.WriteLine("Press the ANY key to return to the menu...");
            Console.ReadKey();
        }

        private static void HandleQueue(ICommand[] commands)
        {
            foreach (var command in commands)
            {
                Console.WriteLine(command.FriendlyName);
                var needsInput = command as INeedsInput;
                var result = command.Go();
                if (!result)
                {
                    Console.WriteLine("Error while running command!");
                    break;
                }
            }
            Console.WriteLine("Press the ANY key to return to the menu...");
            Console.ReadKey();

        }


        public static List<T> GetInstancesOfInterfaceImplementingClasses<T>(Func<Type, T> activator)
        {
            Type interfaceType = typeof(T);
            return AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(x => x.GetTypes())
                   .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                   .Select(x => activator(x)).ToList();
        }


        public class TestBuilder
            {
            
            }

        static void Main(string[] args)
        {
            try
            {
                var profile = new object();
                var test = new string[] {
                    $"B12B...3.4.5...",
                    $"B6B..T..T",
                    $"..3.",
                    $"...",
                    $"..3.",
                    $"...",
                    $"...T..T",
                };

                var context = new CommandContext();
                var kernel = new Ninject.StandardKernel();
                kernel.Bind<CommandContext>().ToConstant(context);

                var mainCommandQueue = new List<string>();
                var teardownCommandQueue = new List<string>();
                var teardownCommandQueues = new List<List<String>>();
                //var test = kernel.GetAll<CommandTree>();

                var buildup = true;
                var teardown = false;
                //foreach (var t in test.Split(","))
                //{
                //    switch (t)
                //    {
                //        case "B":
                //            buildup = false;
                //            teardown = true;
                //            break;
                //        case "T":
                //            teardown = false;
                //            break;
                //        default:

                //            if (teardown)
                //            {
                //                teardownCommandQueue.Add(t);
                //                break;
                //            }

                //            mainCommandQueue.Add(t);

                //            break;
                //    }
                //}


                var all = GetInstancesOfInterfaceImplementingClasses<ICommand>((x) => (ICommand)kernel.Get(x));

                foreach (var c in all)
                {
                    Console.WriteLine(c.FriendlyName);
                }

                var queue = new Queue<string>();
                queue.Enqueue("startprofiler");
                queue.Enqueue("startselenium");
                queue.Enqueue("load");
                var tearDownStack = new Stack<Queue<string>>();
                var scopeStack = new Stack<string>();
                var testStack = new Stack<string>();
                testStack.Count();

                var resultTree = new TreeNode<string>("base");
                //resultTree.AddChild()


                var item = "";
                scopeStack.Push("a");
                Func<int> level = () => testStack.Count(); // short hand for how deep we are
                Func<string> currentStep = () => "currentstep";
                while (queue.Any())
                {
                    item = queue.Dequeue();
                    Console.WriteLine(item);

                    switch (item)
                    {
                        case "load":
                            testStack.Push("test2");
                            // create new scope
                            scopeStack.Push("b");
                            queue.Enqueue(currentStep());
                            break;
                        default:
                            // just do it
                            break;

                    }

                    if (queue.Count() == 0 && level() > 0)
                    {
                        testStack.Pop();
                        queue.Enqueue(currentStep());

                    }

                   
                }





            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press the ANY key to continue...");
            Console.ReadKey();
            //var writeToFileCommand = new WriteToFileCommand(context);
            //var command = (ICommand)writeToFileCommand;

            //var needsInput = writeToFileCommand as INeedsInput;
            //if (needsInput == null || needsInput.Input())
            //{
            //    Console.WriteLine(command.FriendlyName);
            //    command.Go();
            //}


            //   var subMenu = new ConsoleMenu(args, level: 1)
            //.Add("Sub_One", () => SomeAction("Sub_One"))
            //.Add("Sub_Two", () => SomeAction("Sub_Two"))
            //.Add("Sub_Three", () => SomeAction("Sub_Three"))
            //.Add("Sub_Four", () => SomeAction("Sub_Four"))
            //.Add("Sub_Close", ConsoleMenu.Close)
            //.Configure(config =>
            //{
            //    config.Selector = "--> ";
            //    config.EnableFilter = true;
            //    config.Title = "Submenu";
            //    config.EnableBreadcrumb = true;
            //    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            //});

            //   var menu = new ConsoleMenu(args, level: 0)
            //     .Add("One", () => SomeAction("One"))
            //     .Add("Two", () => SomeAction("Two"))
            //     .Add("Three", () => SomeAction("Three"))
            //     .Add("Sub", subMenu.Show)
            //     .Add("Change me", (thisMenu) => thisMenu.CurrentItem.Name = "I am changed!")
            //     .Add("Close", ConsoleMenu.Close)
            //     .Add("Action then Close", (thisMenu) => { SomeAction("Close"); thisMenu.CloseMenu(); })
            //     .Add("Exit", () => Environment.Exit(0))
            //     .Configure(config =>
            //     {
            //         config.Selector = "--> ";
            //         config.EnableFilter = true;
            //         config.Title = "Main menu";
            //         config.EnableWriteTitle = false;
            //         config.EnableBreadcrumb = true;
            //     });

            //   menu.Show();
        }
    }
}
