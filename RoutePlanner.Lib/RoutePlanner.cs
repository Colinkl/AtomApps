using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace RoutePlanner.net
{
    public class RouteCreator
    {
        private Dictionary<string, uint> nodesList;

        private Graph<string, string> graph { get; set; }
        public RouteCreator()
        {
             graph = new Graph<string, string>() + "a";
            nodesList = new Dictionary<string, uint>();
        }

        private List<string> nodes;

        public List<string> Nodes
        {
            get => nodes;
            set
            {
                if (nodes == value)
                {
                    return;
                }

                nodes = value;
            }
        }

        private List<Connection> connections;
        public List<Connection> Connections
        {
            get => connections;
            set
            {
                connections = value;
            }

        }

        public List<string> GetRoute(string start, List<string> destinations)
        {            
            foreach (var node in nodes)
            {
                //graph.AddNode(node);
                var id = graph.AddNode(node);
                nodesList.Add(node, id);
            }
            foreach (var connection in connections)
            {
                if (connection.Bidirectional)
                {
                    graph.Connect(nodesList[connection.ToRoute], nodesList[connection.From], connection.Cost, connection.Custom);
                }
                graph.Connect(nodesList[connection.From], nodesList[connection.ToRoute], connection.Cost, connection.Custom);
            }
            var remainingDest = destinations;
            string currentLocation = start;
            var Route = new List<string> ();
            if (nodesList == null)
            {
                return null;
            }
            Route.Add(currentLocation);
            while (remainingDest.Count != 0)
            {
                int minLenght = -1;
                string nearestDest = null;
                foreach (var destination in remainingDest)
                {
                    ShortestPathResult result = graph.Dijkstra(nodesList[currentLocation], nodesList[destination]);
                    if (minLenght == -1)
                    {
                        minLenght = result.Distance;
                        nearestDest = destination;
                    }
                    if (minLenght > result.Distance)
                    {
                        minLenght = result.Distance;
                        nearestDest = destination;
                    }
                }
                currentLocation = nearestDest;
                if (minLenght > 999999)
                {
                    Route.Add("error");
                    break;
                }
                Route.Add($"{nearestDest}  {minLenght}");
                remainingDest.Remove(currentLocation);
            }
            return Route;
        }


    }
}
