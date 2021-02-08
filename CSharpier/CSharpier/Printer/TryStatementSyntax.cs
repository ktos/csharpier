using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier
{
    public partial class Printer
    {
        private Doc PrintTryStatementSyntax(TryStatementSyntax node)
        {
            var parts = new Parts();
            this.PrintAttributeLists(node, node.AttributeLists, parts);
            parts.Push(
                String("try"),
                this.PrintBlockSyntax(node.Block),
                HardLine,
                Join(
                    HardLine,
                    node.Catches.Select(this.PrintCatchClauseSyntax)
                )
            );
            if (node.Finally != null) {
                parts.Push(
                    HardLine,
                    this.PrintFinallyClauseSyntax(node.Finally)
                );
            }
            return Concat(parts);
        }
    }
}