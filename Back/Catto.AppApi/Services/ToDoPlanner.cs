using Catto.DataLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoutePlanner.net;

namespace Catto.AppApi.Services
{
    public class ToDoPlanner
    {
        private List<JobTask> taskList;
        private List<JobTask> currentTaskList;
        public ToDoPlanner(List<JobTask> TaskList)
        {
            taskList = TaskList;
        }
        private List<string> nodes = new List<string>() { "hub", "1", "2", "3", "4", "5", "6", "7", "8" };
        private List<Connection> connections = new List<Connection> {new Connection(){ From ="1", ToRoute = "4", Cost = 9, Custom = "s", Bidirectional = true},
                                                      new Connection(){ From ="1", ToRoute = "2", Cost = 20, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="4", ToRoute = "7", Cost = 20, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="6", ToRoute = "8", Cost = 13, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="8", ToRoute = "7", Cost = 13, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="7", ToRoute = "hub", Cost = 3, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="hub", ToRoute = "2", Cost = 9, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="hub", ToRoute = "5", Cost = 7, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="5", ToRoute = "8", Cost = 30, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="5", ToRoute = "3", Cost = 9, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="2", ToRoute = "3", Cost = 7, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="4", ToRoute = "6", Cost = 3, Custom = "f", Bidirectional = true}};
        public List<int> GetTodayTodo()
        {
            currentTaskList = new List<JobTask>();

            foreach (var item in taskList)
            {
                if (item.Status == Statuses.Done | item.Status == Statuses.Vefication )
                {
                    continue;
                }
                
                var minTime = new TimeSpan(1, 0, 0, 0);
                switch (item.Priority)
                {
                    case 1:
                        minTime = TimeSpan.FromDays(1);
                        break;
                    case 2:
                        minTime = TimeSpan.FromDays(2);
                        break;
                    case 3:
                        minTime = TimeSpan.FromDays(3);
                        break;
                    default:
                        break;
                }
                if (currentTaskList.Count > 10)
                {
                    break;
                }
                if (item.DeadLine.Subtract(DateTime.Now) < minTime)
                {
                    currentTaskList.Add(item);
                }
            }
            var destList = new List<string>();
            foreach (var item in currentTaskList)
            {
                destList.Add(item.Location);
            }
            var targets = destList;
            var route = new RouteCreator();
            route.Nodes = nodes;
            route.Connections = connections;
            var a = route.GetRoute("hub", destList);

            var output = new List<int>();
            foreach (var item in a)
            {
                foreach (var task in currentTaskList)
                {
                    if (task.Location == item )
                    {
                        output.Add(task.Id);
                    }
                }

            }
            return output;
        }
    }
}
