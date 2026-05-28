#:sdk Naratteu.SourceGenerator.Sdk@0.0.11

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics.CodeAnalysis;
using System.Text;

[Generator]
public class SampleGenerator : IIncrementalGenerator
{
    void IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            ctx.AddEmbeddedAttributeDefinition();
            ctx.AddSource("FriendAttribute.g.cs", """
            namespace Sample
            {
                [Microsoft.CodeAnalysis.Embedded]
                public class FriendAttribute : System.Attribute;
            }
            """);
        });
        context.RegisterSourceOutput(
            context.SyntaxProvider.ForAttributeWithMetadataName("Sample.FriendAttribute", (_, _) => true, (c, _) => c).Collect(),
            (ctx, sources) =>
            {
                ctx.AddSource($"Hello.g.cs", $$"""
                namespace Sample
                {
                    public static class Hello
                    {
                        public static void World() => System.Console.WriteLine("Hello {{string.Join(", ", sources.Select(s => s.TargetSymbol.Name))}} !");
                    }
                }
                """);
            });
    }
}