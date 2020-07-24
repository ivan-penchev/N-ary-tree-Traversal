using NUnit.Framework;
using Playground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Test
{
    public class Tests
    {
        [DatapointSource]
    public Node tree =  new Node(
            1,
            new Node(
                2,
                new Node(
                22,
                new Node(33),
                new Node(34)),
              new Node(
                77,
                new Node(37),
                new Node(44)),
                new Node(3),
                new Node(4)),
            new Node(
                5,
                new Node(6),
                new Node(7)));
  
        [Theory]
        public void Next_Returns13Elements_True()
        {
            var n = tree;
            var elementsInNode = 13;


            var numberOfElements = 0;
            while (n != null)
            {
                numberOfElements++;
                n = n.Next();
            }

            Assert.AreEqual(elementsInNode, numberOfElements,
                            $"We expected: {elementsInNode } in node, we received: {numberOfElements}");
        }
  
    [Test]
    public void GetPathways_MethodExist_True()
    {
           bool methodFound = false;
           Assembly thisAssembly = Assembly.GetAssembly(typeof(Node));
           foreach (MethodInfo method in GetExtensionMethods(thisAssembly,
                typeof(Node)))
            {
                if (method.Name == "CalculateAllPossiblePaths")
                {
                    methodFound = true;
                }
            }
            Assert.True(methodFound, "Calculate Paths extension method for Node class does not exist");
      //Original idea of this test was to invoke the method.
      //I however hit a wall with "Parameter Count mismatch"
    }
    [Test]
    public void Test()
    {
        // Test tree:
        // 
        // 1
        // +-2
        //   +-3
        //   +-4
        // +-5
        //   +-6
        //   +-7
        //
        var root = new Node(
            1,
            new Node(
                2,
                new Node(3),
                new Node(4)),
            new Node(
                5,
                new Node(6),
                new Node(7)));

        var n = root;
      
        Assert.AreEqual(1, n.Data);
        n = n.Next();
        Assert.AreEqual(2, n.Data);
        n = n.Next();
        Assert.AreEqual(3, n.Data);
        n = n.Next();
        Assert.AreEqual(4, n.Data);
        n = n.Next();
        Assert.AreEqual(5, n.Data);
        n = n.Next();
        Assert.AreEqual(6, n.Data);
        n = n.Next();
        Assert.AreEqual(7, n.Data);
        n = n.Next();
        Assert.IsNull(n);
    }
  //based on Jon Skeet - https://stackoverflow.com/questions/299515/reflection-to-identify-extension-methods
  private IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,
        Type extendedType)
        {
            var query = assembly.GetTypes()
                .Where(type => type.IsSealed
                                && !type.IsGenericType
                                && !type.IsNested)
                .Select(s => s.GetMethods(BindingFlags.Static
                            | BindingFlags.Public
                            | BindingFlags.NonPublic)
                .Where(method => 
                        method.IsDefined(typeof(ExtensionAttribute), false) 
                        && method.GetParameters()[0].ParameterType == extendedType))
                .FirstOrDefault();
            return query;
        }
    }
}