﻿using System;
using System.Collections.Generic;
using MexTK.Commands;
using MexTK.Commands.Animation;
using MexTK.Commands.MEX;

namespace MexTK
{
    class Program
    {
        private static List<ICommand> Commands = new List<ICommand>()
        {
            new CmdFighterFunction(),
            new CmdCspCompressor(),
            new CmdPortFigatree(),
            new CmdAddSymbol(),
            new CmdTrimDAT(),
            new CmdRetargetAnimation(),
            new CmdOptimizeFigatree(),
            new CmdMoveLogicTemplateGenerator(),
            new CmdGenerateDatFile(),
            new CmdDebugSymbols()
        };

        static void Main(string[] args)
        {
            //args = new string[] { "-db", "GTME01.map", "melee.link" };

            if (args.Length > 0)
            {
                foreach (var cmd in Commands)
                {
                    if (args[0].Equals(cmd.ID()))
                    {
                        if (!cmd.DoIt(args))
                            PrintInstruction();
                        break;
                    }
                }
            }
            else
            {
                PrintInstruction();
                Console.WriteLine();
                Console.WriteLine("exiting...");
                System.Threading.Thread.Sleep(1000);
            }

#if DEBUG
            Console.ReadLine();
#endif
        }
        

        /// <summary>
        /// 
        /// </summary>
        private static void PrintInstruction()
        {
            Console.WriteLine(@"MexTK");

            Console.WriteLine();

            foreach (var cmd in Commands)
            {
                Console.WriteLine($"{cmd.ID()} {cmd.Name()}:".PadRight(20, '-'));
                Console.WriteLine();
                Console.WriteLine(cmd.Help());
                Console.WriteLine();
            }
        }
    }
}
