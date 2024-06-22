using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Gnome.SourceGen;

[Generator]
public class MySourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new MySyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not MySyntaxReceiver receiver)
            return;

        foreach (var classDeclaration in receiver.CandidateClasses)
        {
            var namespaceName = classDeclaration.Parent is NamespaceDeclarationSyntax namespaceDeclaration
                ? namespaceDeclaration.Name.ToString()
                : "";

            var source = this.GenerateSource(namespaceName, classDeclaration.Identifier.Text);
            context.AddSource($"{classDeclaration.Identifier.Text}.Generated.cs", SourceText.From(source, Encoding.UTF8));
        }
    }

    private string GenerateSource(string namespaceName, string className)
    {
        return $@"
namespace {namespaceName}
{{
    public partial class {className}
    {{
        public string GeneratedProperty {{ get; set; }}
    }}
}}";
    }

    private class MySyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> CandidateClasses { get; } = new();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration
                && classDeclaration.BaseList?.Types.Any(t => t.ToString() == "IMyInterface") == true)
            {
                this.CandidateClasses.Add(classDeclaration);
            }
        }
    }
}