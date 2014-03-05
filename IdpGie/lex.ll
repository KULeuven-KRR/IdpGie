%using QUT.Gppg;

%namespace IdpGie.Parser

%scannertype Lexer
%scanbasetype ScanBase
%tokentype Token

%option stack, minimize, parser, verbose, codepage:raw, out:Parser/Lexer.cs

%option codepage:raw

SAT             SATISFIABLE
ARR             array
WHITESPACE      [\r\t\n ]*
COMMA           ,
ID              [^ \[\]()=,\.\r\t\n\"]*
INT             ([\+\-])?([0-9]+|0x[0-9A-Fa-f]+||0o[0-7]+)
FLT             ([\+\-])?[0-9]+\.([0-9]*)?([Ee]([\+\-])?[0-9]+)?|NaN
STR             \"[^\n\"]*\"
OBR             \(
CBR             \)
DOT             \.
OFB             \[
CFB             \]
OPA             =
COMMENT         \/\/[^\n]*\n
IMPLY           \-\:


%%

{COMMENT}       {}
{SAT}           {}
{ARR}           {return (int) Token.ARRAY;}
{IMPLY}         {return (int) Token.IMPLY;}
{FLT}           {return (int) Token.FLT;}
{INT}           {return (int) Token.INT;}
{ID}            {return (int) Token.IDENTIFIER;}
{STR}           {return (int) Token.STRING;}
{OBR}           {return (int) Token.OBR;}
{CBR}           {return (int) Token.CBR;}
{DOT}           {return (int) Token.DOT;}
{OFB}           {return (int) Token.OFB;}
{CFB}           {return (int) Token.CFB;}
{OPA}           {return (int) Token.OPA;}
{COMMA}         {return (int) Token.COMMA;}
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