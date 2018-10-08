using System.Collections.Generic;
using SharpDX;

namespace SeldatMRMS.RobotView
{
    class Node
    {
        public Vector2 Position;
        public List<Node> Next = new List<Node>();
        public Node came_from = null;//dinh di toi
        public double g = 0;//gia thanh duong di dinh ban dau den n
        public double h = 0;//gia thanh uoc luong den dich
        public double f = 0;//gia thanh uoc luong
        public void MakeLink(ref Node node)
        {
            this.Next.Add(node);
            node.Next.Add(this);
        }
        public float Distance(Node node)
        {
            return Vector2.Distance(this.Position, node.Position);
        }
        public Node(Vector2 pos)
        {
            this.Position = pos;
            Next.Clear();
            this.came_from = null;
        }
    }
}
