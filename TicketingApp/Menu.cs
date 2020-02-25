﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class Menu {
        public static string displayTicketSelectionMenu() {
            var menu = "\n 1) Bug Tickets" +
                "\n 2) Enhacment Tickets" +
                "\n 3) Task Tickets" +
                "\n 4) Exit";
            return menu;
        }
        public static string displayTicketMenu() {
            var menu = "\n 1) Search Tickets" + 
                "\n 2) Add a Ticket" + 
                "\n 3) Select a diffrent ticket type";
            return menu;
        }
        public static string displaySearchMenu() {
            var menu = "\n 1) Search by Summary"+
            "\n 2) Search by Status" + 
            "\n 3) Search by Priority" +
            "\n 4) Search by Submitter" + 
            "\n 5) Search by Assigned" + 
             "\n 6) Search by Watcher" +
            "\n 7) Display all Tickets";
            return menu;
        }

        public static int getInput() {
            var input = Console.ReadLine();
            int parsedInput;
            parsedInput = int.TryParse(input, out parsedInput) ? parsedInput : 0;
            if(parsedInput == 0) {
                Console.WriteLine("Please enter vaild input (a number)");
            }
            return parsedInput;
        }
        public static void displayResults(List<Ticket> ticketList) {
            int pageSize = 3, pageCounter = 0; 
            var ticketPage = ticketList.Take(pageSize).ToList();
            while (ticketPage.Count() > 0) {
                foreach (var ticket in ticketPage) {
                    var watchers = string.Join(", ", ticket.Watching.ToArray());
                    if (ticket is BugTicket bugTicket) {
                        Console.WriteLine($" TicketID: {bugTicket.TicketID}");
                        Console.WriteLine($" Summary: {bugTicket.Summary}");
                        Console.WriteLine($" Status: {bugTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {bugTicket.Priority}");
                        Console.WriteLine($" Submitter: {bugTicket.Submitter}");
                        Console.WriteLine($" Assgined: {bugTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}");
                        Console.WriteLine($" Severity: {bugTicket.Severity} ");
                        Console.WriteLine("\n");
                    }
                    else if (ticket is EnhancementTicket enhancementTicket) {
                        Console.WriteLine($" TicketID: {enhancementTicket.TicketID}");
                        Console.WriteLine($" Summary: {enhancementTicket.Summary}");
                        Console.WriteLine($" Status: {enhancementTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {enhancementTicket.Priority}");
                        Console.WriteLine($" Submitter: {enhancementTicket.Submitter}");
                        Console.WriteLine($" Assgined: {enhancementTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}"); 
                        Console.WriteLine($" Software: {enhancementTicket.Software}"); 
                        Console.WriteLine($" Cost: {enhancementTicket.Cost}"); 
                        Console.WriteLine($" Reason: {enhancementTicket.Reason}"); 
                        Console.WriteLine($" Estimate: {enhancementTicket.Estimate}");
                        Console.WriteLine("\n");
                    }
                    else if (ticket is TaskTicket taskTicket) {
                        Console.WriteLine($" TicketID: {taskTicket.TicketID}");
                        Console.WriteLine($" Summary: {taskTicket.Summary}");
                        Console.WriteLine($" Status: {taskTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {taskTicket.Priority}");
                        Console.WriteLine($" Submitter: {taskTicket.Submitter}");
                        Console.WriteLine($" Assgined: {taskTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}"); 
                        Console.WriteLine($" Task Name: {taskTicket.TaskName}"); 
                        Console.WriteLine($" Due Date: {taskTicket.DueDate}");
                        Console.WriteLine("\n");
                    } 

                }
                Console.WriteLine("Press space to conintue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar) {
                    pageCounter++;
                    ticketPage = ticketList.Skip(pageSize * pageCounter).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                }
            }

        } 
    }
}