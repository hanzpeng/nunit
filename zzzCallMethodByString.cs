using System;
using System.Reflection;
using NUnit.Framework;

namespace CallMethodByString
{
    public class zzzCallMethodByString
    {
        [Test]
        public void Test1()
        {
            Type myType = typeof(MyClass);
            var result = (int) myType.InvokeMember(
                "Add", 
                BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, 
                null,
                null, 
                new Object[] { 1, 2 });
            Assert.AreEqual(3, (int)result);
        }


    }
    public static class MyClass
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

    }
}
