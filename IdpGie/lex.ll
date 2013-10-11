%using QUT.Gppg;

%namespace IdpGie.Parsing

%scannertype MiniZincLexer
%scanbasetype ScanBase
%tokentype Token

%option stack, minimize, parser, verbose, codepage:raw, out:Lexer.cs

%option codepage:raw

WHITESPACE		[\r\t\n ]*
ID				[^ \[\]()=,\.\r\t\n\"]*
STR				\"[^\n\"]*\"

%%

{ID}		    {return Token.IDENTIFIER;}
{STR}		    {return Token.STRING;}
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