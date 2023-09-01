using System.Diagnostics;

var a = new int[] { 0, 1, 2, 3, 4, 5 };
var p = new int[a.Length];
var r = new int[a.Length];
Init(a, p, r);
Union(a, p, r, 0, 1);
Union(a, p, r, 1, 2);
Union(a, p, r, 1, 5);
Union(a, p, r, 4, 5);

Debug.Assert(Find(p,2) == Find(p,4));
Console.WriteLine("success");



void Init(int[] a, int[] p, int[] r)
{
    for (int i = 0; i < a.Length; i++)
    {
        p[i] = i;
        r[i] = 1;
    }
}

int Find(int[] p, int i)
{
    while (i != p[i]){
        p[i] = p[p[i]];
        i = p[i];
    }
    return i;
}

bool Union(int[] a, int[] p, int[] r, int i, int j)
{
    int pi = Find(p, i);
    int pj = Find(p, j);
    if (pi == pj) return false;
    if (r[pi] >= r[pj])
    {
        p[pj] = pi;
        r[pi] += r[pj];
    }
    else
    {
        p[pi] = pj;
        r[pj] += r[pi];
    }
    return true;
}
