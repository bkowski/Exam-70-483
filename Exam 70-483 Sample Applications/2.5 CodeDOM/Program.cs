using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

namespace _2._5_CodeDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeCompileUnit ccu = HelloWorldCodeDOM();

            CSharpCodeProvider provider = new CSharpCodeProvider();

            using(StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
                provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
                tw.Close();
            }
        }

        static CodeCompileUnit HelloWorldCodeDOM()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello World!"));

            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);

            return compileUnit;
        }
    }
}
