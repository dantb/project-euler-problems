using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class LargestProductInGrid : IProblem
    {
        private string Grid = string.Concat(
            "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 ",
            "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 ",
            "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 ",
            "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 ",
            "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 ",
            "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 ",
            "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 ",
            "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 ",
            "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 ",
            "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 ",
            "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 ",
            "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 ",
            "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 ",
            "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 ",
            "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 ",
            "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 ",
            "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 ",
            "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 ",
            "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 ",
            "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48 ");

        public int ProblemId { get { return 11; } }

        public double GetSolution()
        {
            Grid theGrid = new Grid(Grid, 20);

            HashSet<long> maximumInDirections = new HashSet<long>();
            maximumInDirections.Add(theGrid.MaxHorizontalProduct());
            maximumInDirections.Add(theGrid.MaxVerticalProduct());
            maximumInDirections.Add(theGrid.MaxSouthEastProduct());
            maximumInDirections.Add(theGrid.MaxSouthWestProduct());

            return maximumInDirections.Max();
        }
    }

    public class Grid
    {
        Node[,] _theData;
        int Dimension = 0;

        public Grid(string theGrid, int dimension)
        {
            Dimension = dimension;
            _theData = new Node[dimension, dimension];
            string[] splitter = theGrid.Split(' ');
            int col = 0;
            for (int row = 0; row < dimension; row++)
            {
                while (col < dimension)
                {
                    if (_theData[row, col] == null)
                    {
                        CreateNewNodeWithAdjacent(dimension, splitter, col, row);
                    }
                    else
                    {
                        LinkExistingNodeWithAdjacent(dimension, splitter, col, row);
                    }
                    col++;
                }
                col = 0;
            }
        }

        internal long MaxHorizontalProduct()
        {
            HashSet<long> products = new HashSet<long>();
            for (int row = 0; row < Dimension; row++)
            {
                Node rowStartNode = _theData[row, 0];
                while (rowStartNode.East.East.East != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.East.Data *
                                   rowStartNode.East.East.Data *
                                   rowStartNode.East.East.East.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.East;
                }
            }
            return products.Max();
        }

        internal long MaxVerticalProduct()
        {
            HashSet<long> products = new HashSet<long>();
            for (int col = 0; col < Dimension; col++)
            {
                Node rowStartNode = _theData[0, col];
                while (rowStartNode.South.South.South != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.South.Data *
                                   rowStartNode.South.South.Data *
                                   rowStartNode.South.South.South.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.South;
                }
            }
            return products.Max();
        }

        internal long MaxSouthEastProduct()
        {
            HashSet<long> products = new HashSet<long>();
            //does upper right half of grid
            for (int col = 0; col < Dimension; col++)
            {
                Node rowStartNode = _theData[0, col];
                while (rowStartNode.SouthEast?.SouthEast?.SouthEast != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.SouthEast.Data *
                                   rowStartNode.SouthEast.SouthEast.Data *
                                   rowStartNode.SouthEast.SouthEast.SouthEast.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.SouthEast;
                }
            }
            //lower left half of grid, start at row 1 to avoid duplicate leading diagonal
            for (int row = 1; row < Dimension; row++)
            {
                Node rowStartNode = _theData[row, 0];
                while (rowStartNode.SouthEast?.SouthEast?.SouthEast != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.SouthEast.Data *
                                   rowStartNode.SouthEast.SouthEast.Data *
                                   rowStartNode.SouthEast.SouthEast.SouthEast.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.SouthEast;
                }
            }
            return products.Max();
        }

        internal long MaxSouthWestProduct()
        {
            HashSet<long> products = new HashSet<long>();
            //does upper left half of grid
            for (int col = Dimension - 1; col >= 0; col--)
            {
                Node rowStartNode = _theData[0, col];
                while (rowStartNode.SouthWest?.SouthWest?.SouthWest != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.SouthWest.Data *
                                   rowStartNode.SouthWest.SouthWest.Data *
                                   rowStartNode.SouthWest.SouthWest.SouthWest.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.SouthWest;
                }
            }
            //lower right half of grid, start at row 1 to avoid duplicate leading diagonal
            for (int row = 1; row < Dimension; row++)
            {
                Node rowStartNode = _theData[row, Dimension - 1];
                while (rowStartNode.SouthWest?.SouthWest?.SouthWest != null)
                {
                    long product = rowStartNode.Data *
                                   rowStartNode.SouthWest.Data *
                                   rowStartNode.SouthWest.SouthWest.Data *
                                   rowStartNode.SouthWest.SouthWest.SouthWest.Data;
                    products.Add(product);
                    rowStartNode = rowStartNode.SouthWest;
                }
            }
            return products.Max();
        }

        private void LinkExistingNodeWithAdjacent(int dimension, string[] splitter, int col, int row)
        {
            //if not null add adjacent if they're are null, otherwise link to existing
            Node theNode = _theData[row, col];
            if (col + 1 < dimension)
            {
                if (_theData[row, col + 1] == null)
                {
                    Node eastNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row, col + 1)]));
                    theNode.East = eastNode;
                    _theData[row, col + 1] = eastNode;
                }
                else
                {
                    theNode.East = _theData[row, col + 1];
                }
            }
            if (row + 1 < dimension)
            {
                if (_theData[row + 1, col] == null)
                {
                    Node southNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col)]));
                    theNode.South = southNode;
                    _theData[row + 1, col] = southNode;
                }
                else
                {
                    theNode.South = _theData[row + 1, col];
                }

                if (col + 1 < dimension)
                {
                    if (_theData[row + 1, col + 1] == null)
                    {
                        Node southEastNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col + 1)]));
                        theNode.SouthEast = southEastNode;
                        _theData[row + 1, col + 1] = southEastNode;
                    }
                    else
                    {
                        theNode.SouthEast = _theData[row + 1, col + 1];
                    }
                }
                if (col - 1 >= 0)
                {
                    if (_theData[row + 1, col - 1] == null)
                    {
                        Node southWestNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col - 1)]));
                        theNode.SouthWest = southWestNode;
                        _theData[row + 1, col - 1] = southWestNode;
                    }
                    else
                    {
                        theNode.SouthWest = _theData[row + 1, col - 1];
                    }
                }
            }
        }

        private void CreateNewNodeWithAdjacent(int dimension, string[] splitter, int col, int row)
        {
            //make this node
            Node newNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row, col)]));
            _theData[row, col] = newNode;
            if (col + 1 < dimension)
            {
                Node eastNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row, col + 1)]));
                newNode.East = eastNode;
                _theData[row, col + 1] = eastNode;
            }
            if (row + 1 < dimension)
            {
                Node southNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col)]));
                newNode.South = southNode;
                _theData[row + 1, col] = southNode;

                if (col + 1 < dimension)
                {
                    Node southEastNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col + 1)]));
                    newNode.SouthEast = southEastNode;
                    _theData[row + 1, col + 1] = southEastNode;
                }
                if (col - 1 > 0)
                {
                    Node southWestNode = new Node(int.Parse(splitter[IndexFromRowAndCol(row + 1, col - 1)]));
                    newNode.SouthWest = southWestNode;
                    _theData[row + 1, col - 1] = southWestNode;
                }
            }
        }

        private int IndexFromRowAndCol(int row, int col)
        {
            return (row * Dimension) + col;
        }
    }

    public class Node
    {
        public int Data = 0;
        public Node South;
        public Node East;
        public Node SouthWest;
        public Node SouthEast;

        public Node(int data)
        {
            Data = data;
        }
    }
}
