
Console.WriteLine(int.MaxValue);
Console.WriteLine(int.MinValue);
Console.WriteLine(int.MaxValue%10);
Console.WriteLine(int.MinValue % 10);

Console.WriteLine(Reverse(-123));


int Reverse(int x)
{
    int rev = 0;
    while (x != 0)
    {
        int pop = x % 10;
        x /= 10;
        if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
        if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
        rev = rev * 10 + pop;
    }
    return rev;
}

public class Solution
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}



