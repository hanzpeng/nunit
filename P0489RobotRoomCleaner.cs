using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{


    // This is the robot's control interface.
    // You should not implement it, or speculate about its implementation
    interface Robot
    {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move();

        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft();
        public void TurnRight();

        // Clean the current cell.
        public void Clean();
    }


    class P0489RobotRoomCleaner
    {
        HashSet<(int, int)> IsClean = new();
        Dictionary<string, string> ReverseDir = new();
        int[][] Dir = new int[][] { new int[]{-1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };
        Robot robot;
        public void CleanRoom(Robot robot)
        {
            this.robot = robot;
            Clean(0, 0, 0);
        }
        public void Clean(int i, int j, int inDir)
        {
            robot.Clean();
            IsClean.Add((i, j));
            for (int k = 0; k < 4; k++)
            {
                int dir = (inDir + k) % 4;
                int r = i + Dir[dir][0];
                int c = j + Dir[dir][1];
                if (!IsClean.Contains((r,c)))
                {
                    if (!robot.Move())
                    {
                        IsClean.Add((r, c));
                    }
                    else
                    {
                        Clean(r, c, dir);
                        robot.TurnRight();
                        robot.TurnRight();
                    }
                }
                robot.TurnRight();
            }
            robot.TurnRight();
            robot.TurnRight();
            robot.Move();
        }
    }
}
