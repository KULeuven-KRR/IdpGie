%using QUT.Gppg;

%namespace IdpGie.Parser

%scannertype Lexer
%scanbasetype ScanBase
%tokentype Token

%option stack, minimize, parser, verbose, codepage:raw, out:Lexer.cs

%option codepage:raw

WHITESPACE      [\r\t\n ]*
COMMA           ,
ID              [^ \[\]()=,\.\r\t\n\"]*
STR             \"[^\n\"]*\"
OBR             \(
CBR             \)
DOT             \.
OFB             \[
CFB             \]
OPA             =


%%

{ID}		    {return (int) Token.IDENTIFIER;}
{STR}		    {return (int) Token.STRING;}
{OBR}           {return (int) Token.OBR;}
{CBR}           {return (int) Token.CBR;}
{DOT}           {return (int) Token.DOT;}
{OFB}           {return (int) Token.OFB;}
{CFB}           {return (int) Token.CFB;}
{OPA}           {return (int) Token.OPA;}
{WHITESPACE}    {}

/* ------------------------------------------ */
%{
    yylloc = new LexSpan(tokLin, tokCol, tokELin, tokECol, tokPos, tokEPos, buffer);
%}
/* ------------------------------------------ */

%%
public IEnumerable<Token> Tokenize() {
    int tok;
    do {
        tok = yylex();
        yield return (Token) tok;
    } while (tok > (int)Token.EOF);
}