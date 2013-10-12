%using QUT.Gppg;

%namespace IdpGie.Parsing

%scannertype MiniZincLexer
%scanbasetype ScanBase
%tokentype Token

%option stack, minimize, parser, verbose, codepage:raw, out:Lexer.cs

%option codepage:raw

WHITESPACE      [\r\t\n ]*
COMMA           ,
ID              [^ \[\]()=,\.\r\t\n\"]*
STR             \"[^\n\"]*\"
OBR             (
CBR             )
DOT             \.
OFB             \[
CFB             \]
OPA             =


%%

{ID}		    {return Token.IDENTIFIER;}
{STR}		    {return Token.STRING;}
{OBR}           {return Token.OBR;}
{CBR}           {return Token.CBR;}
{DOT}           {return Token.DOT;}
{OFB}           {return Token.OFB;}
{CFB}           {return Token.CFB;}
{OPA}           {return Token.OPA;}
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