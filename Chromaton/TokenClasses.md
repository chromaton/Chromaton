Shared Tokens
-------------

Comment
    Comment.Block
        Block comments, like `/* */` in C-like languages, `<!-- -->` in HTML, `(* *)` in Pascal, or any insignificant text in Brainfuck.
    Comment.Line
        Line comments, like `//` in C-like languages, the shell style comment `#`, or `'` in Visual Basic.  The rule here is that the comment must be terminated by a new line.
Whitespace
    Whitespace.Insignificant
        Ignored whitespace, like most whitespace in most languages.
    Whitespace.Significant
        Significant whitespace, like indentation in Python, Haml, and certain modes of `F#`.

Tokens for Imperative Languages
-------------------------------

Comment
    Comment.Documentation
        Comments used for documentation, like `///` in C#, `'''` in Visual Basic, or `/**` for Javadoc.
Grouping
    Grouping.Statements
        Statement grouping symbols, like `{` and `}` in C-like languages.
    Grouping.Expression
        Expression grouping symbols, like `(` and `)` when not used as an operator in most languages.
    Grouping.Separator
        Expression and tuple separator, like `,` when not used as an operator in most languages.
Name
    Name.Identifier
        Names of types, variables, and fields in most languages.
Operator
    Operator.Symbol
        Non-word operators, like `+` or `*` in most languages, or `>`; `+`; or `.` in Brainfuck.
    Operator.Keyword
        Word operators, like `and` or `not` in Python and F#, `sizeof` in C-like languages, `is` and `as` in C#, or `instanceof` in Java.

Tokens for Declarative Languages
--------------------------------


Tokens for Markup Languages
---------------------------

Name
    Name.Attribute
        Name of an attribute in markup languages, like the 'style' in `<b style="foo"></b>` for HTML.
    Name.Element
        Name of an element in markup languages, like the 'b' in `<b> </b>` for HTML, the 'b' in `{\b  }` in RTF, or the 'textbf' in `\textbf{ }` in LaTeX.
Delimiter
    Delimiter.Tag
        Delimiter for tags in markup languages, like the angle brackes and slashes in `<br />` for HTML, and the slashes and curly braces in `{\b bold}` and `\textbf{bold}` for RTF and LaTeX (respectively).
        For HTML and XML this also includes the start and end of processing instructions, CDATA sections, and etc. (for example: `<!`, `<?`, and `?>`).
    Delimiter.Literal
        Delimiter for sections of literal text in markup languages, like `[CDATA[`, `[INCLUDE[`, `[IGNORE[` and `]]` in XML.
Entity
    Entity.Named
        For named entities in markup languages, like `&copy;` in HTML.
    Entity.Number
        For entities expressed with their numeric representation, like `&#169;` in HTML, or `\'a9` or `\u00a9?` in RTF.
Text
    Text.Plain
        Text that is displayed as-is to the user, like the entire contents of text files, or the contents of most nodes in an HTML document.
