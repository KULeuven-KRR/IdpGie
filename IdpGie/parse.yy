%output=Parser.cs 
%namespace IdpGie.Parser
%parsertype IdpParser

%using System.Linq;
%using IdpGie.Utils;

%tokentype Token

%visibility public

%union{
    public String                      str;
    public IFunctionInstance           ter;
    public HeadTail<FunctionInstance>  vter;
    public Atom                        atm;
    public HeadTail<Atom>              vatm;
}

%sharetokens
%start idpdraw

%YYSTYPE StateStructure
%YYLTYPE LexSpan

%token IDENTIFIER STRING OBR CBR DOT OFB CFB OPA COMMA FLT INT
%type   <str>   identifier
%type   <ter>   term
%type   <vter>  terms
%type   <atm>   atom predatom
%type   <vatm>  atoms

%%

idpdraw     : atoms                                         {this.result = new DrawTheory($1.ToList());}
            ;

atoms       : /* empty */                                   {$$ = null;}
            | DOT                                           {$$ = null;}
            | atom DOT atoms                                {$$ = new HeadTail<Atom>($1,$3);}
            ;

atom        : predatom                                      {$$ = $1;}
            | error                                         {$$ = null;}
            ;

predatom    : identifier OBR terms CBR                      {$$ = this.Context.CreateAtom($1,$3);}
            | identifier                                    {$$ = this.Context.CreateAtom($1);}
            ;

terms       : /* empty */                                   { $$ = null;}
            | term                                          { $$ = new HeadTail<FunctionInstance>($1);}
            | term COMMA terms                              { $$ = new HeadTail<FunctionInstance>($1,$3);}
            ;

term        : identifier OBR terms CBR                      { $$ = this.Context.CreateFunctionInstance($1,$3);}
            | identifier                                    { $$ = this.Context.CreateFunctionInstance($1);}
            | list                                          { $$ = $1;}
            | INT                                           { $$ = new IdpdIntegerFunction(@1.ToString());}
            | FLT                                           { $$ = new IdpdFloatFunction(@1.ToString());}
            | STRING                                        { $$ = new IdpdStringFunction(@1.LiteralString());}
            ;

list        : OFB CFB                                       { $$ = new ArrayTailFunction();}
            ;

identifier  : IDENTIFIER                                    { $$ = @1.ToString();}
            ;

%%

private LocalInputContext context;
private DrawTheory result;

public LocalInputContext Context {
    get {
        return this.context;
    }
    set {
        this.context = value;
    }
}

public DrawTheory Result {
    get {
        return this.result;
    }
}
  
public IdpParser (ScanBase sb) : base(sb) {
    this.context = new LocalInputContext();
}