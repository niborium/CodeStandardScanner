using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeStandardScanner
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide a folder path.");
                return;
            }

            string folderPath = args[0];

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Folder not found: {folderPath}");
                return;
            }

            var violations = new List<string>();

            ScanFolder(folderPath, violations);

            if (violations.Count == 0)
            {
                Console.WriteLine("All files follow the specified standards.");
            }
            else
            {
                Console.WriteLine("The following files violate the standards:");
                foreach (var violation in violations)
                {
                    Console.WriteLine(violation);
                }
            }
        }

        static void ScanFolder(string folderPath, List<string> violations)
        {
            var fileExtensions = new[] { ".ts", ".tsx" };

            foreach (var fileExtension in fileExtensions)
            {
                foreach (var filePath in Directory.GetFiles(folderPath, $"*{fileExtension}", SearchOption.AllDirectories))
                {
                    var code = File.ReadAllText(filePath);
                    var fileViolations = CheckCodeStandards(code);
                    if (fileViolations.Count > 0)
                    {
                        violations.Add($"File: {filePath}\nViolations:\n{string.Join("\n", fileViolations)}\n");
                    }
                }
            }
        }

        static List<string> CheckCodeStandards(string code)
        {
            var violations = new List<string>();

            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot();

            // Rule: Avoid using 'var' for variable declarations
            var variableDeclarations = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            foreach (var declaration in variableDeclarations)
            {
                if (declaration.Type.IsVar)
                {
                    violations.Add($"Avoid using 'var' for variable declaration: {declaration}");
                }
            }

            // Rule: Class names should be PascalCase
            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var declaration in classDeclarations)
            {
                if (!char.IsUpper(declaration.Identifier.ValueText[0]))
                {
                    violations.Add($"Class name should be PascalCase: {declaration}");
                }
            }

            return violations;
        }
    }
}